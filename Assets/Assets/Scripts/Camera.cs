using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class angle : MonoBehaviour {
	public float sensitivity = 100.0f;
	float rotationX;
	float rotationY;
	float mouseMoveValueX;
	float mouseMoveValueY;

	// Use this for initialization
	void Start () {
		Transform target = GameObject.Find ("Enermy").transform;
		transform.LookAt (target);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		/*
		if (Input.GetMouseButton(0)) {
			mouseMoveValueX = Input.GetAxis ("Mouse X");
			mouseMoveValueY = Input.GetAxis ("Mouse Y");

			rotationY += mouseMoveValueX * sensitivity * Time.fixedDeltaTime;
			rotationX += mouseMoveValueY * sensitivity * Time.fixedDeltaTime;

			rotationY %= 360;
			rotationX %= 360;

			rotationX = Mathf.Clamp (rotationX, -140.0f, 140.0f);
			rotationY = Mathf.Clamp (rotationY, -140.0f, 140.0f);
			transform.eulerAngles = new Vector3 (-rotationX, rotationY, 0.0f);

		}
	*/
	}
}
