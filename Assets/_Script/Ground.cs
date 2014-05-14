using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	
	private Camera mainCamera;
	//private PlayerManager playerManager;
	private UnitManager unitManager;
	private GroundClick groundClick;
	
	private float groundHeight;
	
	RaycastHit rayHit;
	
	// Use this for initialization
	void Awake () {
		groundHeight = transform.position.y;
		mainCamera = Camera.mainCamera;
		GameObject managers = GameObject.FindWithTag( "Managers" );
		//playerManager = managers.GetComponent<PlayerManager>();
		unitManager = managers.GetComponent<UnitManager>();
		groundClick = managers.GetComponent<GroundClick>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver () {
		
		if( Input.GetMouseButtonDown( 1 ) ){
			if( unitManager.ActiveSoldier != null ){
				unitManager.ActiveSoldier.MoveTo( GetMousePosition() );
			}
		}
	}
	
	private Vector3 GetMousePosition () {
		Vector3 result = new Vector3(); 
		if( Physics.Raycast( mainCamera.ScreenPointToRay( Input.mousePosition ), out rayHit, Mathf.Infinity ) ){
			if( rayHit.transform.tag == "Ground" ){
				result = rayHit.point;
				result.y = groundHeight + 1.1f;
			}
		}
		Debug.Log( "Ground "+result ); 
		groundClick.OnGroundClick( result );
		return result;
	}
}
