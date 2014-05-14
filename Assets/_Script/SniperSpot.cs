using UnityEngine;
using System.Collections;

public class SniperSpot : MonoBehaviour {
	
	public bool isEnabled;
	public bool placed;
	public Transform sniperSiluet;
	public Transform sniperPrefab;
	// Use this for initialization
	void Start () {
		GameObject.FindWithTag( "Managers" ).GetComponent<PlayerManager>().AddSpot( this );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter () {
		if( isEnabled && !placed ){
			sniperSiluet.gameObject.GetComponent<Renderer>().enabled = true;
			sniperSiluet.position = transform.position;		
		}	
	}
	
	void OnMouseOver () {
		
		if( Input.GetMouseButtonDown( 0 ) ){
			Instantiate( sniperPrefab, transform.position, Quaternion.identity );
			sniperSiluet.gameObject.GetComponent<Renderer>().enabled = false;
			isEnabled = false;
			placed = true;
			GameObject.FindWithTag( "Managers" ).GetComponent<PlayerManager>().sniperCount--;
		}
	}
	
	void OnMouseExit () {
		sniperSiluet.gameObject.GetComponent<Renderer>().enabled = false;		
	}
	

	
	
}
