using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {


	#region Test
	public Transform soldierPrefab;
	#endregion

	#region Textures
	public Texture2D sellectionBox;
	public Texture2D progressBar;
	public Texture2D backgroundProgressBar;
	public Texture2D[] soldierIcons;	
	#endregion
	
	#region References
	public Transform sellectionCircle;
	private Camera mainCamera;
	#endregion
	
	#region Game Time & Speed
	public bool isGamePaused;
	
	private float gameTime;
	private int gameSpeed;
	#endregion
	
	#region Soldier Icons
	private bool areSoldierIconsShown;
	private Vector2 soldierIconDimension;
	private Vector2 soldierIconPosition;
	private Rect soldierIconRect;
 	private Vector2 soldierIconsDimension;
	private Vector2 soldierIconsPosition;
	private Rect soldierIconsRect;
	#endregion
		
	#region Sellection Box
	private Vector2 sellectionBoxPosition;
	private Vector2 sellectionBoxDimensions;
	#endregion
	
	#region Progress Bar
	private bool isProgressbarShown;
	private Vector2 progressbarDimensions;	
	private Vector2 progressbarPosition;
	private Rect progressbarRect;
	
	public bool IsProgressBarShown {
		set{ isProgressbarShown = value; }	
	}
	#endregion
	
	#region Units
	public int sniperCount = 1;
	private List<SniperSpot> sniperSpots;
	
	public Soldier activeSoldier;
	public List<Soldier> soldiers;
	
	public Soldier ActiveSoldier {
		get{ return activeSoldier; }
		set{ activeSoldier = value; }
	}
	#endregion
	
	#region Environment
	private Door activeDoor;
	#endregion
	
	#region Waves
	private bool wavesStarted = false;
	#endregion
	
	
	
	
	// Use this for initialization
	void Awake () {
		#region References
		mainCamera = Camera.mainCamera;
		#endregion
		
		#region Game Time & Speed
		isGamePaused = false;
		
		gameSpeed = 1;
		gameTime = Time.deltaTime*gameSpeed;
		#endregion
		
		#region Soldier Icons
		
		#endregion
		
		#region Sellection Box
		sellectionBoxDimensions = new Vector2( sellectionBox.width, sellectionBox.height );	
		#endregion
		
		#region Progress Bar
		isProgressbarShown = false;
		progressbarDimensions = new Vector2( backgroundProgressBar.width, backgroundProgressBar.height );
		progressbarPosition = new Vector2( (Screen.width-backgroundProgressBar.width)/2, Screen.height-140 );
		progressbarRect = new Rect( progressbarPosition.x,
								   progressbarPosition.y,
								   progressbarDimensions.x,
								   progressbarDimensions.y );
		#endregion
		
		#region Units
		soldiers = new List<Soldier>();
		sniperSpots = new List<SniperSpot>();
		#endregion

		#region Test
		Instantiate( soldierPrefab, new Vector3( 0.0f, 1.1f, 0.0f ), Quaternion.identity );
		#endregion
	}
	
	
	void OnGUI () {
		
		if( activeSoldier != null ){
			//SellectionBox();
			//Bar( activeSoldier.PercentHealth );
			if( activeSoldier.isBusy ){
				Bar( 0.5f );	
			}
		}
		
		if( areSoldierIconsShown ){
			SoldierIcons();	
		}
		
		if( !wavesStarted ){
			if( GUI.Button( new Rect( 10, 10, 100, 20 ), "Start" ) ){
				wavesStarted = true;
				gameObject.GetComponent<ZombieManager>().StartWaves( 0 );
			}
			if( sniperCount>0 ){
				if( GUI.Button( new Rect( 10, 35, 100, 20 ), "Sniper x"+sniperCount ) ){
					foreach( SniperSpot sniper in sniperSpots ){
						if( sniper.isEnabled ){
							sniper.isEnabled = false;	
						} else {
							sniper.isEnabled = true;	
						}
					}
				}
			}
		}
	}
	
	void Update () {
				
	}
	
	private void Bar ( float progress ) {
		GUI.DrawTexture( progressbarRect, backgroundProgressBar  );
		GUI.DrawTexture( progressbarRect, progressBar, ScaleMode.ScaleAndCrop, false, progress * progressbarDimensions.x );
	}
	
	private void SellectionBox () {
		GUI.DrawTexture( new Rect( sellectionBoxDimensions.x,
									sellectionBoxDimensions.y,
									sellectionBoxPosition.x,
									sellectionBoxPosition.y ), sellectionBox );
									
	}
	
	private void SoldierIcons () {
		int i = 0;
		GUI.BeginGroup( soldierIconsRect );
		foreach( Soldier soldier in soldiers ){
			if( soldier == activeSoldier ){
				
			} else {
				if( GUI.Button( new Rect( soldierIconPosition.x,
											soldierIconPosition.y,
											soldierIconDimension.x,
											soldierIconDimension.y ), soldierIcons[0] ) ){
					
				}
			}
			i++;
		}
		GUI.EndGroup();
	}
	
		
	public void AddSoldier ( Soldier soldier ) {
		soldiers.Add( soldier );
		Debug.Log( "Added :"+soldier.ToString() );
	}
	
	public void SetActiveSoldier ( Soldier soldier ){
		if( activeSoldier == null ){
			activeSoldier = soldier;
			sellectionCircle.parent = activeSoldier.transform;
			sellectionCircle.localPosition = new Vector3( 0.0f, -1.0f, 0.0f );
			sellectionCircle.renderer.enabled = true;
		} else if( activeSoldier == soldier ) {
			activeSoldier = null;
			sellectionCircle.parent = null;
			sellectionCircle.renderer.enabled = false;
		} else {
			activeSoldier = soldier;
			sellectionCircle.parent = activeSoldier.transform;
			sellectionCircle.localPosition = new Vector3( 0.0f, -1.0f, 0.0f );
		}
	}
	
	public void AddSpot ( SniperSpot sniperSpot ) {
		sniperSpots.Add( sniperSpot );
	}
	
	
	
}
