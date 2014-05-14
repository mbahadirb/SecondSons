using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

[System.Serializable]

public class Soldier : MonoBehaviour {

	#region Animation
	public CharacterAnimationController animationController;
	#endregion

	#region Data
	private int soldierID;
	public int SoldierID{
		get{ return soldierID; }
		set{ soldierID = value; } 
	}
	#endregion

	#region References
	private Seeker seeker;
	private CharacterController characterController;
	//private PlayerManager playerManager;
	private UnitManager unitManager;
	#endregion
	
	#region Movement
	private List<Vector3> path;
	private int pathIndex;
	private Vector3 currentWP;
	private float nextWPDistanceSqr;
	
	private Vector3 direction;
	private Vector3 forwardDirection;
	
	private float turnSpeed;
	private float moveSpeed;
	#endregion
	
	#region Health 
	private float maxHealth;
	private float curHealth;
	private float percentHealth;
	
	public float MaxHealth {
		get{ return maxHealth; }
		set{ maxHealth = value; }
	}
	
	public float CurHealth {
		get{ return curHealth; }
		set{ curHealth = value; }
	}
	
	public float PercentHealth {
		get{ return percentHealth; }
		set{ percentHealth = value; }
	}
	#endregion
	
	#region Abilities
	private Ability activeAbility;
	public Ability ActiveAbility {
		get{ return activeAbility; }
		set{ activeAbility = value; }
	}
	
	private List<Ability> abilities;
	
	private Ability nextAction;
	private Ability action;
	
	public bool isBusy;
	
	//May add all below to ability class
	private float actionStart;
	private float actionTime;
	private float actionEnd;
	private float progress;
	
	public float Progress {
		get { return progress; }
	}
	//Will Add this to Ability
	private float rangeSqr;
	public float RangeSqr{
		get{ return rangeSqr; }
		set{ rangeSqr = value; }
	}
	#endregion
	
	#region Targets
	private Container container;
	private Door door;
	private Enemy enemy;
	#endregion
	
	// Use this for initialization
	void Awake () {
		#region References
		seeker = GetComponent<Seeker>();
		characterController = GetComponent<CharacterController>();
		//playerManager = GameObject.FindWithTag("Managers").GetComponent<PlayerManager>();
		//playerManager.AddSoldier( this );
		unitManager = GameObject.FindWithTag( "Managers" ).GetComponent<UnitManager>();
		unitManager.AddSoldier( this );

		#endregion
		
		#region Abilities
		activeAbility = Ability.Use;
		rangeSqr = 100.0f;
		#endregion
		
		#region Movement
		nextWPDistanceSqr = 3;

		turnSpeed = 3;
		moveSpeed = 5;
		#endregion

		#region Animation
		animationController = gameObject.GetComponentInChildren<CharacterAnimationController>();
		#endregion
	}
	
	void OnMouseOver () {
		if( Input.GetMouseButtonDown(0) ){
			Debug.Log ( "Mouse Click On Player" );
			//playerManager.SetActiveSoldier( this );
			unitManager.SetActiveSoldier( this );
		} else if( Input.GetMouseButtonDown(1) ){
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		#region Pathfing Update
		if( path == null || pathIndex >= path.Count || pathIndex < 0 ){
			return;	
		}
		
		currentWP = path[pathIndex];
		currentWP.y = transform.position.y;
		
		while( (currentWP-transform.position).sqrMagnitude < nextWPDistanceSqr ){
			pathIndex++;
			if( pathIndex >= path.Count ){
					if( (currentWP-transform.position).sqrMagnitude <nextWPDistanceSqr*0.5f ){
					AtTheEndOfPath();
					return;
				} else {
					pathIndex--;
					break;
				}
			} 
			currentWP = path[pathIndex];
			//currentWP.y = transform.position.y;
		}
		
		direction = currentWP - transform.position;
		
		transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation( direction ), turnSpeed*Time.deltaTime );
		transform.eulerAngles = new Vector3( 0, transform.eulerAngles.y, 0 );
		
		forwardDirection = transform.forward * moveSpeed;
		forwardDirection *= Mathf.Clamp01( Vector3.Dot( direction, transform.forward ) );
		forwardDirection.y = 0.0f;
		//Debug.Log( forwardDirection.ToString() );
		characterController.SimpleMove( forwardDirection );
		
		
		#endregion	
	}

	void OnGUI () {
		if( unitManager.ActiveSoldier == this ){
			if( GUI.Button( new Rect( soldierID*100, 20, 100, 100 ), "Soldier "+soldierID ) ){
				unitManager.SetActiveSoldier( this );
			}
		}
		else {
			if( GUI.Button( new Rect( soldierID*100, 0, 100, 100 ), "Soldier "+soldierID ) ){
				unitManager.SetActiveSoldier( this );
			}
		}


	}

	public void MoveTo ( Vector3 position ) {
		if( isBusy ){
			return;	
		}
		seeker.StartPath( transform.position, position, OnPathComplete );
		/*
		if( isBusy ) {
			return;	
		}
		seeker.StartPath( transform.position, position, OnPathComplete );	
		order = Orders.None;
		*/	
	}
	
	//For doors only
	public void MoveToAct ( Ability action, Door door ) {
		if( isBusy ){
			return;	
		}
			this.door =  door;
			this.action = action;
		if( ( transform.position - door.transform.position ).sqrMagnitude <= nextWPDistanceSqr ){
			TakeAction();		
		} else {
			MoveTo( door.transform.position );	
		}
	}
	
	private void OnPathComplete ( Path p ) {
		path = p.vectorPath;
		pathIndex = 0;
		//currentWP = path[pathIndex];
		animationController.UpdateSpeed( 1.0f );
		
	}
	
	private void AtTheEndOfPath () {
		pathIndex = -1;	
		animationController.UpdateSpeed( 0.0f );
		TakeAction();
	}
	
	private void TakeAction () {
		if( action == Ability.Idle ){
			return;	
		} else if( action == Ability.Attack ){
			
		} else if( action == Ability.Heal ){
			
		} else if( action == Ability.Loot ){
			
		} else if( action == Ability.Use ){
			
		} else if( action == Ability.UseDoor ){
			door.UseDoor();	
		} else if( action == Ability.Weld ){
			
		}
	}
	
	public bool AddAbility ( Ability newAbility ) {
		foreach( Ability ability in abilities ){
			if( ability == newAbility ){
				return false;	
			}
		}
		abilities.Add( newAbility );
		return true;
	}
	
	public void LootItem (  ) {
		
	}
	
	public void AdjustHealth ( float damage ) {
		curHealth += damage;
		if( curHealth > maxHealth ){
			curHealth = maxHealth;	
		} else if( curHealth < 0 ){
			//Die	
		}
		percentHealth = curHealth/maxHealth;
	}
	
}
