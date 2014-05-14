using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public Animation doorOpenAnimation;
	
	private PlayerManager playerManager;
	
	public bool isDoorOpen;
	public bool isBeingWelded;
	public bool isWelded;
	
	// Use this for initialization
	void Awake () {
		doorOpenAnimation.Stop();	
		isDoorOpen = false;

		playerManager = GameObject.FindWithTag( "Managers" ).GetComponent<PlayerManager>();
	}
	
	
	void OnMouseEnter () {		
		/*
		guiManager.showMouseOverMessage = true;
		if( isWelded ){
			guiManager.mouseOverMessage = "Door Wielded";
		} else {
			guiManager.mouseOverMessage = "Door";	
		}
		*/
	}
	
	void OnCollisionEnter ( Collision other ) {

	}
	
	void OnMouseOver () {
		
		if( Input.GetMouseButtonDown( 1 ) ){
			if( playerManager.ActiveSoldier.ActiveAbility == Ability.Use ){
				if( isWelded || isBeingWelded ){
					return;	
				} else {
					playerManager.ActiveSoldier.MoveToAct( Ability.UseDoor, this );
				}
				//playerManager.ActiveSoldier.UseDoor( this );			
			//} else if( playerManager.ActiveSoldier.nextAction == Actions.Wield ){
			//	playerManager.ActiveSoldier.MoveToAct( Ability.Weld, this );
			//} else if( playerManager.ActiveSoldier.nextAction == Actions.Break ){
				
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void UseDoor () {
		
		if( isDoorOpen ){
			doorOpenAnimation[ "SlidingDoorAnimation" ].speed = -1;
			doorOpenAnimation.Play();
			gameObject.layer = 8;	
			isDoorOpen = false;
		} else {
			doorOpenAnimation[ "SlidingDoorAnimation" ].speed = 1;
			doorOpenAnimation.Play();
			gameObject.layer = 9;
			isDoorOpen = true;
		}
		
	}
	


}
