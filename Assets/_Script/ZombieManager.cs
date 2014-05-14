using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieManager : MonoBehaviour {
	
	private PlayerManager playerManager;
	
	public float waveTimeDelay;
	public float zombieSpawnTimeDelay;
		
	public int numberOfWaves;
	public int waveIndex;
	public int[] numberOfZombies;
	private int zombieIndex;
	
	public List<Zombie> zombies;
	
	public List<SpawnPoint> spawnPoints;

	
	// Use this for initialization
	void Awake () {
		//zombies = new List<Zombie>();
		//spawnPoints = new List<SpawnPoint>( 6 );
		
		playerManager = gameObject.GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void StartWaves ( int index ) {
		
		waveIndex = index;
		zombieIndex = 0;
		StartCoroutine( "ZombieSpawn" );	
		
	}
	
	IEnumerator ZombieSpawn () {
		/*
		while( playerManager.isGamePaused ){
			yield return new WaitForSeconds( 1.0 );	
		}
		*/	
		if( waveIndex < numberOfWaves ){
			//Spawn a zombie at a random spawn point
			int rand = ((int)Random.Range(0,spawnPoints.Count-1));
			Debug.Log( rand );
			spawnPoints[rand].SpawnZombie();
			//increase index so we can check if it is next wave or just another zombie to be spawned
			zombieIndex++;
			if( zombieIndex >= numberOfZombies[waveIndex] ){
				//Next wave it is
				waveIndex++;
				zombieIndex = 0;
				yield return new WaitForSeconds( waveTimeDelay );
				
			} else {
				//Next zombie it is
				yield return new WaitForSeconds( zombieSpawnTimeDelay );
			
			}
			StartCoroutine( "ZombieSpawn" );
	
			
		}
	}
	
	public void AddSpawnPoint ( SpawnPoint spawnPoint ) {
		Debug.Log( "ZombieManager" );
		spawnPoints.Add( spawnPoint );		 
	}
	
	public void AddZombie ( Zombie zombie ) {
		zombies.Add( zombie );	
	}
}
