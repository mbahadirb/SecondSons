using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour {

	#region Turn
	public bool isUserTurn;
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
	public Vector2 soldierIconDimension;
	public Vector2 soldierIconPosition;
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
	public int activeSoldierIndex;

	public Soldier activeSoldier;
	public List<Soldier> soldiers;
	
	public Soldier ActiveSoldier {
		get{ return activeSoldier; }
		set{ activeSoldier = value; }
	}

	public List<Enemy> enemies;
	#endregion
	
	#region Environment
	//private Door activeDoor;
	#endregion

	#region Prefabs
	public Transform soldierPrefab;
	public Transform enemyPrefab;
	#endregion

	void Start () {

	}

	// Use this for initialization
	void Awake () {
		#region References
		mainCamera = Camera.mainCamera;
		#endregion

		#region Game Time/Speed
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
		progressbarPosition = new Vector2( (Screen.width - progressbarDimensions.x)/2, Screen.height - 140 );
		progressbarRect = new Rect( progressbarPosition.x,
		                           	progressbarPosition.y,
		                           	progressbarDimensions.x,
		                           	progressbarDimensions.y );
		#endregion

		#region Units
		soldiers = new List<Soldier>();

		enemies = new List<Enemy>();
		#endregion

		#region Prefabs
		Instantiate( soldierPrefab, new Vector3( -10.0f, 1.1f, 0.0f ), Quaternion.identity );
		Instantiate( soldierPrefab, new Vector3( -10.0f, 1.1f, 3.0f ), Quaternion.identity );
		Instantiate( soldierPrefab, new Vector3( -10.0f, 1.1f, -3.0f ), Quaternion.identity );
		//Instantiate( enemyPrefab, new Vector3( 10.0f, 1.1f, 0.0f ), Quaternion.identity );
		#endregion

		soldierIconPosition = new Vector2( 0, 0 );
		soldierIconsDimension = new Vector2( 100, 100 );
	}

	void OnGUI () {

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

	public void AddSoldier ( Soldier soldier ) {
		soldiers.Add( soldier );
		soldier.SoldierID = soldiers.IndexOf( soldier );
		Debug.Log( "Added :"+soldier.ToString()+soldier.SoldierID );
	}

	public void AddEnemy ( Enemy enemy ) {
		enemies.Add( enemy );
		enemy.EnemyID =  enemies.IndexOf( enemy );
		//enemy.EnemyID = enemies.Count-1;
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


}
