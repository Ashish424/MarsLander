using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipActor : MonoBehaviour{





	public float forceFactor = 1;
	public float rotationFactor = 10;
	public float gravityFactor = 0.5f;
	
	
	// Use this for initialization
	private void Start (){
		myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	private void Update () {
		
		
		
		
		myRigidbody.AddForce(-Physics.gravity*gravityFactor);
		if (Input.GetKey(KeyCode.W)){
			myRigidbody.AddRelativeForce(Vector3.up*forceFactor,ForceMode.Force);	
		}
		
		
		
		if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)){		
			myRigidbody.AddTorque(Vector3.forward*rotationFactor);
		}
		
		
		if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)){		
			myRigidbody.AddTorque(-Vector3.forward*rotationFactor);
		}


		
	}
	private Rigidbody myRigidbody;
}
