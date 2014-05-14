using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	float cameraRotateSpeed = 20.0f;
	float cameraMoveSpeed = 20.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.anyKey ){
			if( Input.GetKey( KeyCode.Q ) ){
				transform.Rotate( -cameraRotateSpeed*Time.deltaTime*Vector3.up, Space.World );	
			} else if( Input.GetKey( KeyCode.E ) ){
				transform.Rotate( cameraRotateSpeed*Time.deltaTime*Vector3.up, Space.World );
			}
		}
		
		transform.position += cameraMoveSpeed*Time.deltaTime*( Input.GetAxis( "Vertical" )*transform.forward+Input.GetAxis( "Horizontal" )*transform.right );	
		
	}
}
