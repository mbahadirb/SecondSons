using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	
	public WayPoint wayPoint;
	public GameObject zombiePrefab;
	
	private ZombieManager zombieManager;
	
	void Awake () {
		zombieManager = GameObject.FindWithTag( "Managers" ).GetComponent<ZombieManager>();
		zombieManager.AddSpawnPoint( this );
	}
	
	public void SpawnZombie () {
		GameObject zombie = Instantiate( zombiePrefab, transform.position, Quaternion.identity ) as GameObject;
		//zombie.GetComponent<Zombie>().StartMove();
	}
	
	/*
	
	public WayPoint wayPoint;
	public Transform zombiePrefab;
	
	private ZombieManager zombieManager;
	
	// Use this for initialization
	void Awake () {
		zombieManager = GameObject.FindWithTag( "Managers" ).GetComponent<ZombieManager>();
		zombieManager.AddSpawnPoint( this );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SpawnZombie () {
		Object zombie = Instantiate( zombiePrefab, transform.position, Quaternion.identity );
		(zombie as GameObject).GetComponent<Zombie>().StartMove( );//wayPoint );
		
		//zombieManager.AddZombie(zombie.GetComponent<Zombie>());	
	}
	*/
}
