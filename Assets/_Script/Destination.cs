using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {


	private UnitManager unitManager;
	private Vector3 targetPosition;

	public Vector3 TargetPosition{
		get{ return targetPosition; }
		set{ targetPosition = value; }
	}

	// Use this for initialization
	void Start () {
		unitManager = GameObject.FindGameObjectWithTag( "Managers" ).GetComponent<UnitManager>();
		targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.anyKeyDown ){
			if( !Input.GetMouseButtonDown(1) ){
				Destroy( gameObject );
			}
		}
	}

	void OnMouseOver () {
		Debug.Log( "Destination Object" );
		if( Input.GetMouseButtonDown( 1 )){
			//unitManager move command to targetPosition
			unitManager.ActiveSoldier.MoveTo( targetPosition );
			Destroy( gameObject );
		}
	}
}
