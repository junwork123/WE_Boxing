using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class VRGaze : MonoBehaviour {

	bool triggerEnter = false;
	float progress = 0.0f;

	public UnityEvent selectEvent;

	void Update(){

		if (triggerEnter) {
			progress = progress + Time.deltaTime;
			GetComponent<Slider> ().value = progress;

			if (progress >= 1f) {
				selectEvent.Invoke ();
				//Destroy (gameObject);
			}

		}
			
	}

	void OnGazeEnter(){
		triggerEnter = true;
	}

	void OnGazeExit(){
		triggerEnter = false;
		progress = 0f;
		GetComponent<Slider> ().value = 0f;
	}
}