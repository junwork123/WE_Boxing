using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class angle : MonoBehaviour {
	public float sensitivity = 100.0f;
	float rotationX;
	float rotationY;
	float mouseMoveValueX;
	float mouseMoveValueY;

	Vector3 screenCenter;

	// Use this for initialization
	void Start () {
		Transform target = GameObject.Find ("Enermy").transform;
		transform.LookAt (target);
		screenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

	}

	void FixedUpdate(){
		
		Ray ray = Camera.main.ScreenPointToRay(screenCenter);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 500f))
		{
			if (hit.collider.gameObject.tag == "Enermy")
			{
				print ("Enermy Detected");               
			}
		}
	}
	// Update is called once per frame
	void LateUpdate () {

	}
}
