using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sniper : MonoBehaviour {
	
	
	private ZombieManager zombieManager;
	public float distanceSqr;
	
	private Transform target;
	
	private bool isRotating;
	
	private float aimingTime;
	private float shootingTime;
	private float changingTargetTime;
	private float reloadTime;
	
	
	private bool isAimig;
	private bool isFiring;
	
	// Use this for initialization
	void Start () {
		GameObject.FindWithTag( "Managers" ).GetComponent<ZombieManager>();

	}
	
	// Update is called once per frame
	void Update () {
		if( target == null ){
			if( NewTarget() ){
					
			}
		}
	}
	
	void OnMouseOver () {
		if( Input.GetMouseButtonDown( 0 ) ){
			
		}
	}
	
	public bool NewTarget () {
		foreach( Zombie zombie in zombieManager.zombies ){
			if( (transform.position - zombie.transform.position ).sqrMagnitude <= distanceSqr ){
				RaycastHit rayhit;
				Physics.Raycast( transform.position, zombie.transform.position-transform.position, out rayhit );
				if( rayhit.collider.gameObject.GetComponent<Zombie>() == zombie ){
					
				}
				target = zombie.transform;
				return true;
			}
		}
		return false;
	}
	
	public void CheckTarget () {
		
	}
	
	private IEnumerator Snipe () {
		if( isAimig ){
			yield return new WaitForSeconds( aimingTime );		
		}
		
	}
	
}
