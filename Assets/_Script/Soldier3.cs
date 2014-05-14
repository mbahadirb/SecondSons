using UnityEngine;
using System.Collections;
using Pathfinding;

public class Soldier3 : MonoBehaviour {
	
	private Seeker seeker;
	private CharacterController characterController;
	
	private UnitManager unitManager;
	
	public Vector3[] path;
	private int pathIndex; 
	private Vector3 currentWP;
	
	private float nextWPDistanceSqr;
	
	private Vector3 direction;
	private Vector3 forwardDirection;
	
	private float turnSpeed;
	private float moveSpeed;
	
	public bool isBusy;
	
	public float actionStart;
	public float actionTime;
	
	public Actions nextAction;
	public Actions[] abilites;
	public int level;
	
	private Orders order;
	
	private Lootable lootable;
	private Door door;
	
	private bool isWelding;
	// Use this for initialization
	void Awake () {
		order = Orders.None;
		
		nextWPDistanceSqr = 9;	//Adjust
		turnSpeed = 3.0f;
		moveSpeed = 5.0f;
		
		seeker = GetComponent<Seeker>();
		characterController = GetComponent<CharacterController>();
		unitManager = GameObject.FindWithTag( "UnitManager" ).GetComponent<UnitManager>();
		
	}
	
	void OnMouseOver () {
		if( Input.GetMouseButtonDown( 0 ) ){
			//unitManager.activeSoldier = this;		
		}
	}
	
	// Update is called once per frame
	void Update () {
		#region Pathfing Update
		if( path == null || pathIndex >= path.Length || pathIndex < 0 ){
			return;	
		}
		
		currentWP = path[pathIndex];
		currentWP.y = transform.position.y;
		
		while( (currentWP-transform.position).sqrMagnitude < nextWPDistanceSqr ){
			pathIndex++;
			if( pathIndex >= path.Length ){
					if( (currentWP-transform.position).sqrMagnitude <nextWPDistanceSqr*0.5f ){
					AtTheEndOfPath();
					return;
				} else {
					pathIndex--;
					break;
				}
			} 
			currentWP = path[pathIndex];
			currentWP.y = transform.position.y;
		}
		
		direction = currentWP - transform.position;
		
		transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation( direction ), turnSpeed*Time.deltaTime );
		transform.eulerAngles = new Vector3( 0, transform.eulerAngles.y, 0 );
		
		forwardDirection = transform.forward * moveSpeed;
		forwardDirection *= Mathf.Clamp01( Vector3.Dot( direction, transform.forward ) );
		
		characterController.SimpleMove( forwardDirection );
		
		
		#endregion
	}
	
	public void JustMove ( Vector3 position ) {
		if( isBusy ) {
			return;	
		}
		seeker.StartPath( transform.position, position, OnPathComplete );	
		order = Orders.None;
	}
	
	public void MoveTo ( Vector3 position ) {
		if( isBusy ) {
			return;	
		}
		seeker.StartPath( transform.position, position, OnPathComplete );		
	}
	
	void OnPathComplete ( Path p ) {
		Debug.Log( "Path Complete" );
		//path = p.vectorPath;
		pathIndex = 0;
		//currentWP = path[pathIndex];
		
	}
	
	void AtTheEndOfPath () {
		pathIndex = -1;	
		ExecuteOrder();
	}
	
	public void UseLootable ( Lootable lootable ) {
		if( isBusy ){
			return;	
		} else {
			if( (transform.position-lootable.transform.position).sqrMagnitude>4 ){
				MoveTo( lootable.transform.position );	
				order = Orders.Loot;
				this.lootable = lootable;
			} else {
				isBusy = true;	
				StartCoroutine( "LootTheObject" );
			}	
		}
	}
	
	private IEnumerator LootTheObject () {
		yield return new WaitForSeconds( 0.5f );
		isBusy = false;
	}
	
	public void UseDoor ( Door door ) {

		if( isBusy ){
			return;	
		} else {
			if( (transform.position-door.transform.position).sqrMagnitude>4 ){
				MoveTo( door.transform.position );	
				order = Orders.UseDoor;
				this.door = door;
			} else {
				isBusy = true;	
				StartCoroutine( "OpenTheDoor" );
			}
		}
		
		/*
		if( (transform.position-door.transform.position).sqrMagnitude>4 ){
			MoveTo( door.transform.position );	
			order = Orders.UseDoor;
			this.door = door;
		} else {
			door.UseDoor();
		}
		*/
		
	}
	
	private IEnumerator OpenTheDoor () {
		yield return new WaitForSeconds( 0.5f );
		isBusy = false;
	}
	
	public void Weld ( Door door ) {
		if( door.isDoorOpen ){
			return;	
		}
		if( isBusy ){
			return;
		} else {
			if( (transform.position-door.transform.position).sqrMagnitude>4 ){
				MoveTo( door.transform.position );	
				order = Orders.Weld;
				this.door = door;
			} else {
				isBusy = true;
				StartCoroutine( "WeldTheDoor" );
			}
		}
		
	}
	
	private IEnumerator WeldTheDoor () {
		door.isBeingWelded = true;
		actionStart = Time.time;
		actionTime = 2.0f;
		yield return new WaitForSeconds( 2.0f );
		if( door.isWelded ){
			door.isWelded = false;
		} else {
			door.isWelded = true;	
		}
		door.isBeingWelded = false;
		isBusy = false;
		nextAction = Actions.Use;
	}
	

	public float Progress {
		get{ return (Time.time - actionStart)/actionTime; }
	}
	
	private void ExecuteOrder () {
		if( order == Orders.None ){
			return;	
		} else if( order == Orders.Attack ){
			
		} else if( order == Orders.Break ){
			
		} else if( order == Orders.Loot ){
			lootable.LootTheObject();
		} else if( order == Orders.UseDoor ){
			door.UseDoor();	
		} else if( order == Orders.Weld ){
			isBusy = true;
			StartCoroutine( "WeldTheDoor" );
		}
		order = Orders.None;
	}
	
}