using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	WayPoint nextWaypoint;
	CharacterController characterController;
	UnitManager unitManager;

	int enemyID;
	public int EnemyID{
		get{ return enemyID;} 
		set{ enemyID = value; }
	}

	#region Movement
	float moveSpeed;
	float distanceSqr;
	#endregion

	EnemyStates enemyState;

	// Use this for initialization
	void Start () {
		enemyState = EnemyStates.Waypoint;
		characterController = gameObject.GetComponent<CharacterController>();

		unitManager = GameObject.FindWithTag( "Managers" ).GetComponent<UnitManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver () {
		if( unitManager.activeSoldier ){
			if( Input.GetMouseButtonDown(1) ){
				Debug.Log ( "Mouse Right Click On Enemy" );
				float rangeSqr = Vector3.SqrMagnitude( transform.position - unitManager.ActiveSoldier.transform.position );
				if( unitManager.ActiveSoldier.RangeSqr <= rangeSqr ){
					Debug.Log ( "Attacking" );
				}
			} else if( Input.GetMouseButtonDown(0) ){
				
			}
		}
	}
}
