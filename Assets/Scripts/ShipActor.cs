﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ShipActor : MonoBehaviour{






	
	[SerializeField]private float forceFactor = 1;
	[SerializeField]private float rotationFactor = 10;
	[SerializeField]private float gravityFactor = 0.5f;
	[SerializeField]private float reactive = 0.03f;
	
	
	
	// Use this for initialization
	private void Start (){
		myRigidbody = GetComponent<Rigidbody>();

		endPadLayer = LayerMask.NameToLayer("EndPad");
		startPadLayer = LayerMask.NameToLayer("StartPad");
		groundLayer = LayerMask.NameToLayer("Ground");
		obstacleLayer = LayerMask.NameToLayer("Obstacle");
		

	}
	
	// Update is called once per frame
	private void Update () {
		
		
		
		
		
		
		
		myRigidbody.AddForce(-Physics.gravity*gravityFactor);

		
		thrust();
		rotate();
		correct();



		if (Debug.isDebugBuild){
			useDebugKeys();
		}
		
	
			


		
	}


	private void thrust(){
		
		if (Input.GetKey(KeyCode.W)){
			myRigidbody.AddRelativeForce(Vector3.up*forceFactor,ForceMode.Force);	
		}


	}
	private void rotate(){
				
		if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)){		
			myRigidbody.AddTorque(Vector3.forward*rotationFactor);
		}
		
		
		if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)){		
			myRigidbody.AddTorque(-Vector3.forward*rotationFactor);
		}

	}

	private void correct(){
		
		float len = myRigidbody.velocity.magnitude;
		Vector3 velocityNorm = myRigidbody.velocity.normalized;
		Vector3 proj = Vector3.Project(velocityNorm, transform.up);
		
		//exponential correction factor
		myRigidbody.AddForce(-reactive * (myRigidbody.velocity - proj * len), ForceMode.Impulse);
		Debug.DrawLine(myRigidbody.position, myRigidbody.position + myRigidbody.velocity, Color.black, 0.0f, false);
	}
	
	
	
	private void OnCollisionEnter(Collision other){

		
		if (other.gameObject.layer == startPadLayer){
			Debug.Log("collided with start pad");
			
		}
		else if (other.gameObject.layer == endPadLayer){
	
			Debug.Log("collided with end pad");
			Utils.loadNextScene();
		}
		else if (other.gameObject.layer == groundLayer){
			Debug.Log("collided with ground");
		}
		else if (other.gameObject.layer == gameObject.layer){
			Debug.Log("collided with another ship");
		}
		else if (other.gameObject.layer == obstacleLayer){
			
			
			Debug.Log("collided with obstacle");
			Destroy(gameObject);
			Utils.reloadCurrentScene();
		}
		
		
		

	}

	
	private void useDebugKeys(){

		if (Input.GetKeyDown(KeyCode.Semicolon)){
			Utils.loadNextScene();
		}
	}

	private void OnCollisionStay(Collision other){
//		Debug.Log("some one stay");
//		Debug.Log("ship collision stay");
		

	}

	private void OnCollisionExit(Collision other){
		
//		Debug.Log("ship collision exit");
		

	}
	
	private Rigidbody myRigidbody;
	private int endPadLayer;
	private int startPadLayer;
	private int groundLayer;
	private int obstacleLayer;
}