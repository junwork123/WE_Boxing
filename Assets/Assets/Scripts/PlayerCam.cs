using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCam: MonoBehaviour {

	Ray mRay;
	RaycastHit mHit;
	public Camera mCamera;
	public Canvas mCanvas;
	public RawImage crossHair_blue;
	public RawImage crossHair_red;
	public RawImage crossHair_yellow;

	// Use this for initialization
	void Start () {
		/*
		Transform target = GameObject.Find ("Enermy").transform;
		transform.LookAt (target);
		*/
		setCrosshairColor ("blue");
	}

	void FixedUpdate(){
		mRay = mCamera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(mRay, out mHit))
		{
			if (mHit.transform.tag == "Enermy") {
				// 이미지 클래스를 사용하려면 
				// using UnityEngine.UI;를 추가해야함

				setCrosshairColor ("red");
				// blue -> 진하게
				// red -> 너무 어두움
				// yellow -> 초록색
				 
			}else
				setCrosshairColor ("blue");
				
		}


	}
	// Update is called once per frame
	void LateUpdate () {

	}

	void setCrosshairColor(string color){
		if (color == "blue") {
			crossHair_blue.enabled = true;

			crossHair_red.enabled = false;
			crossHair_yellow.enabled = false;

		} else if (color == "red") {
			crossHair_red.enabled = true;

			crossHair_blue.enabled = false;
			crossHair_yellow.enabled = false;

		} else if (color == "yellow") {
			crossHair_yellow.enabled = true;

			crossHair_blue.enabled = false;
			crossHair_red.enabled = false;
		}
			
	}
}
