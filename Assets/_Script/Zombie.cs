using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
	
	public WayPoint nextWaypoint;
	private CharacterController characterController;
	private ZombieManager zombieManager;
	
	public float moveSpeed;
	public float distanceSqr;
	
	public ZombieStates zombieState;
	public bool inBaricade;
	
	// Use this for initialization
	void Start () {
		
		zombieState = ZombieStates.Waypoint;
		characterController = gameObject.GetComponent<CharacterController>();
		
		zombieManager = GameObject.FindWithTag( "Managers" ).GetComponent<ZombieManager>();
		
		// FindClosestSpawnPoint
		float distance = 100000.0f;
		SpawnPoint sp;
		for( int i=0; i<zombieManager.spawnPoints.Count; i++ ){
			if( (transform.position-zombieManager.spawnPoints[i].transform.position).sqrMagnitude<distance ){
				distance = (transform.position-zombieManager.spawnPoints[i].transform.position).sqrMagnitude;
				sp = zombieManager.spawnPoints[i];	
				nextWaypoint = sp.wayPoint;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if( zombieState == ZombieStates.Waypoint ){
			if( nextWaypoint != null ){
				if( distanceSqr >= ( transform.position - nextWaypoint.position ).sqrMagnitude ){
					nextWaypoint = nextWaypoint.nextWayPoint;		
				} else {
					characterController.SimpleMove( (nextWaypoint.position-transform.position).normalized*moveSpeed );	
				}
			}  else {
				if( inBaricade ){
					zombieState = ZombieStates.AttackGate;
				}
				zombieState = ZombieStates.Idle;
				
			}
		}
	}
	
	
	public void AttackBarricade () {
			
	}
	
	public void StartMove (  ) {
		//nextWaypoint = waypoint;
		//gameObject.GetComponent<CharacterController>().SimpleMove( (nextWaypoint-transform.position).Normalize()*moveSpeed );
	}
}
