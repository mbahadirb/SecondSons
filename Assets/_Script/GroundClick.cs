using UnityEngine;
using System.Collections;

public class GroundClick : MonoBehaviour {
	
	
	public Transform groundClick;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnGroundClick ( Vector3 position ) {
		position.y -= 1.0f;
		Instantiate( groundClick, position, Quaternion.identity );
	}
}
