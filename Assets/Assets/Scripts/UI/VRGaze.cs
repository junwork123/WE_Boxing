using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class VRGaze : MonoBehaviour {

	bool triggerEnter = false;
	float progress = 0.0f;
	public float waitTime = 1.5f;
	public GameObject button;
	public BoxCollider box;
	public Canvas pCanvas;
	public UnityEvent selectEvent;

	void Update(){
		// 부모 캔버스의 상태에 따라 콜라이더가 켜지고 꺼짐
			box.enabled = pCanvas.enabled;
		
		if (triggerEnter) {
			
			progress = progress + Time.deltaTime;
			//button.SetActive (false);

			if (progress >= waitTime) {
				selectEvent.Invoke ();
				progress = 0f;
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
	}
}