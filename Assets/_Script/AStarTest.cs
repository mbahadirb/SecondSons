using UnityEngine;
using System.Collections;
using Pathfinding;

public class AStarTest : MonoBehaviour {
	
	public Transform wall;
	private int point;
	// Use this for initialization
	void Start () {
		point = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		if( GUI.Button( new Rect( 10, 10, 100, 20 ), "Wall" ) ){
			Instantiate( wall, new Vector3( point, 1.6f, 0 ), Quaternion.identity );
			point++;
		}
		if( GUI.Button( new Rect( 10, 30, 100, 20 ), "Rescan" ) ){
			AstarPath.active.Scan();	
		}
	}
}
