using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter ( Collider other ) {
		if( other.tag == "Player" ){
			other.GetComponent<CharacterController>().slopeLimit = 90.0f;
			other.GetComponent<CharacterController>().SimpleMove( Vector3.up );
			
			//other.transform.position = new Vector3( other.transform.position.x, 9.1f, other.transform.position.z ); 	
		}
	}
}
