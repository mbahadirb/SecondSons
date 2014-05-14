using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {
	
	
	public WayPoint nextWayPoint;
	public Vector3 position;
	// Use this for initialization
	void Awake () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
