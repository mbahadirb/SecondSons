using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	public float forwardSpeed;
	
	private bool isMovingForward;
	// Use this for initialization
	void Start () {
		forwardSpeed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.anyKeyDown ){
			if( Input.GetAxis( "Vertical" ) != 0.0f ){
				isMovingForward = true;		
			}
		} else {
			isMovingForward = false;	
		}
	}
	
	void FixedUpdate () {
		if( isMovingForward ){
			gameObject.GetComponent<Rigidbody>().AddRelativeForce( transform.forward*Input.GetAxis( "Vertical" ) );	
		}
	}
}
