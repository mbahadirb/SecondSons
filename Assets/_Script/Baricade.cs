using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Baricade : MonoBehaviour {
	
	public float maxHP;
	public float currentHP;
	public Zombie[] attackSpots;
	public List<Zombie> zombies;
	
	// Use this for initialization
	void Awake () {
		attackSpots = new Zombie[4];	
		zombies = new List<Zombie>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter ( Collider other ) {
		if( other.tag == "Zombie" ){
			//zombies.Add( other.gameObject.GetComponent<Zombie>());
			CheckAttacker( other.gameObject.GetComponent<Zombie>() );
		}
	}
	
	void CheckAttacker ( Zombie zombie ) {
		for( int i=0; i<attackSpots.Length; i++ ){
			if( attackSpots[i] == null ){
				attackSpots[i] = zombie;
				break;
			} else {
				zombies.Add( zombie );	
			}
		}
	}
	
	void CheckAttackers () {
		for( int i=0; i<attackSpots.Length; i++ ){
			if( attackSpots[i] == null ){
				if( zombies[0] != null ){
					attackSpots[i] = zombies[0];
					zombies.RemoveAt(0);
					attackSpots[i].transform.position = transform.position - new Vector3( 2.5f+i, 0, 1.0f );
				}
			}
		}
	}
}
