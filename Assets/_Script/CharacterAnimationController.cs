using UnityEngine;
using System.Collections;

public class CharacterAnimationController : MonoBehaviour {

	public Animator animator;
	public float forwardSpeed;
	public float rightSpeed;
	public bool isTurning;
	public bool isFiring;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		//animation["PA_WarriorForward_Clip"].speed = 10;
		forwardSpeed = 0.0f;
		rightSpeed = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//This code wont get any input
		//forwardSpeed = Input.GetAxis( "Vertical" )*10;
		//rightSpeed = Input.GetAxis( "Horizontal" )*10;
		/*
		if( rightSpeed != 0.0f ){
			transform.Rotate( transform.up*Time.deltaTime*rightSpeed );
		}

		animator.SetFloat( "forwardSpeed", forwardSpeed );
		animator.SetFloat( "rightSpeed", rightSpeed );

		//Check for Attack
		if( forwardSpeed == 0.0f ){
			if( rightSpeed == 0.0f ){
				if( Input.GetMouseButtonDown( 0 )){
					if( isFiring == false ){
						isFiring = true;
						animator.SetBool ( "isAttacking", isFiring );
					}
				}
				if( Input.GetMouseButtonUp( 0 )){
					if( isFiring ){
						isFiring = false;
						animator.SetBool ( "isAttacking", isFiring );
					}
				}
			}
		}
		*/
	}

	public void UpdateSpeed( float speed ){
		forwardSpeed = speed;
		//Debug.Log ( "Character speed: " + speed );
		animator.SetFloat( "forwardSpeed", forwardSpeed );
	}
}