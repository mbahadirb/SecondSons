using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {
	public float timeDelay;
	// Use this for initialization
	void Start () {
		StartCoroutine( "DestroyThis" );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator DestroyThis () {
		yield return new WaitForSeconds( timeDelay );
		Destroy( gameObject );
	}
}
