using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPadActor : MonoBehaviour {

	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnCollisionEnter(Collision other){
		//TODO test collsions
		
		Debug.Log("some one entered ");
	}

	private void OnCollisionStay(Collision other){
		Debug.Log("some one stay");

	}

	private void OnCollisionExit(Collision other){
		
		Debug.Log("some one exit");

	}
}
