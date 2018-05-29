using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour{







	//default values are weird so you modfiy them before using
	
	[SerializeField] private Vector3 movement = new Vector3(50,50,50);
	[Range(0,2)]
	[SerializeField] private float period = 0.1f;
	
	
	
	// Use this for initialization
	void Start (){
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update (){

		if (period < Mathf.Epsilon){
			return;
		}		
		float delta  = (Mathf.Sin(Time.timeSinceLevelLoad/period)+1)/2;
		transform.position = startPos+(movement*delta);
		
		
	}


	private Vector3 startPos;
}
