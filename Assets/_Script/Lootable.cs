using UnityEngine;
using System.Collections;

public class Lootable : MonoBehaviour {
	
	private GUIManager guiManager;
	private UnitManager unitManager;
	// Use this for initialization
	void Awake () {
		//guiManager = GameObject.FindWithTag( "GUIManager" ).GetComponent<GUIManager>();
		//unitManager = GameObject.FindWithTag( "UnitManager" ).GetComponent<UnitManager>();
	}
	
	void OnMouseOver () {
		/*
		if( Input.GetMouseButtonDown( 1 ) ){
			if( unitManager.activeSoldier.nextAction == Actions.Use ){
				unitManager.activeSoldier.UseLootable( this );
			}
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void LootTheObject(){
		Debug.Log( "Shiny!!" );
	}
}
