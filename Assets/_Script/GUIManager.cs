using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	public Texture2D sellectionBox;
	public Texture2D barBackground;
	public Texture2D bar;
	
	private Camera mainCamera;
	private UnitManager unitManager;
	
	private bool showProgressBar;
	
	private float size = 0;
	private float progress;
	private float startTime;
	private float actionTime;
	
	public bool showMouseOverMessage;
	public string mouseOverMessage;
	// Use this for initialization
	void Awake () {
		mainCamera = Camera.mainCamera;
		unitManager = GameObject.FindWithTag( "UnitManager" ).GetComponent<UnitManager>();
		showProgressBar = true;
		startTime = 0.0f;
		actionTime = 5.0f;
		
	}
	
	
	void OnGUI () {
		/*
		if( showMouseOverMessage ){
			ShowMouseOverMessage();	
		}
		
		if( unitManager.activeSoldier.isBusy ){
			progress = (Time.time-unitManager.activeSoldier.actionStart)/unitManager.activeSoldier.actionTime;
			Progress( progress );
		}
		//ProgressBar( barBackground.width );
		
		
		Vector3 screenPos = mainCamera.WorldToScreenPoint( unitManager.activeSoldier.transform.position );
		
		GUI.Label( new Rect( screenPos.x-12,
								Screen.height-screenPos.y-16,
								32,
								32 ), sellectionBox );
				
		int index = 0;
		foreach( Actions action in unitManager.activeSoldier.abilites ) {
			if( GUI.Button( new Rect( 10, 
										10+20*index,
										100,
										20 ), action.ToString() ) ){
				unitManager.activeSoldier.nextAction = action;	
			}
			index++;
			
		}
		*/
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ProgressBar ( float limit ) {
		GUI.Label( new Rect( Screen.width/2-64,
								Screen.height-100,
								barBackground.width,
								barBackground.height ), barBackground );
		
		GUI.DrawTexture( new Rect( Screen.width/2-64,
								Screen.height-100,
								barBackground.width*Mathf.Clamp01(size),
								barBackground.height ), bar, ScaleMode.ScaleAndCrop, false, barBackground.width/barBackground.height );
		if( size<limit*0.05f ){
			size = Time.time*0.05f;
		}
	}
	
	public void Progress ( float percent ){
		
		GUI.DrawTexture( new Rect( Screen.width/2-64,
							Screen.height-100,
							barBackground.width,
							barBackground.height ), barBackground );
		GUI.DrawTexture( new Rect( Screen.width/2-64,
							Screen.height-100,
							barBackground.width*Mathf.Clamp01(percent),
							barBackground.height ), bar, ScaleMode.ScaleAndCrop, false, barBackground.width*Mathf.Clamp01(percent)/barBackground.height );
		
	
	}
	
	private void ShowMouseOverMessage () {
		GUI.Label( new Rect( Screen.width/2-50,
								Screen.height-140,
								100,
								20 ), mouseOverMessage );
	}
}
