using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Crosshair: MonoBehaviour {

	Ray mRay;
	RaycastHit mHit;
    float defaultPosZ;
	public Camera mCamera;
	public RawImage crossHair_blue;
	public RawImage crossHair_red;
	public RawImage crossHair_yellow;
	GameObject CurrentGaze;

	// Use this for initialization
	void Start () {
        defaultPosZ = transform.localPosition.z;
		setCrosshairColor ("blue");
	}

	void FixedUpdate(){
        mRay = new Ray(mCamera.transform.position, mCamera.transform.rotation * Vector3.forward);

		if (Physics.Raycast(mRay, out mHit))
		{
            if (mHit.distance < defaultPosZ)
                transform.localPosition = new Vector3(0, 0, mHit.distance);
            else
                transform.localPosition = new Vector3(0, 0, defaultPosZ);

			if (mHit.transform.tag == "Enermy") {
				// 이미지 클래스를 사용하려면 
				// using UnityEngine.UI;를 추가해야함

				setCrosshairColor ("red");
				 
			} else if (mHit.transform.tag == "UI") {

				setCrosshairColor ("yellow");

				CurrentGaze = mHit.collider.gameObject;
				CurrentGaze.SendMessage ("OnGazeEnter", SendMessageOptions.DontRequireReceiver);
				//SendMessage ("OnHitInfo", mHit, SendMessageOptions.DontRequireReceiver);
			} else {
				setCrosshairColor ("blue");
				if( CurrentGaze != null )
					CurrentGaze.SendMessage ("OnGazeExit", SendMessageOptions.DontRequireReceiver);

			}
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
