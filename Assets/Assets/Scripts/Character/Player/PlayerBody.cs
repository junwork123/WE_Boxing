using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class PlayerBody : MonoBehaviour {

	public Transform tranformCam;
	public Transform tranformBody;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// 카메라가 바라보는 방향으로
		// y축 기준 회전
		//tranformBody.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, tranformCam.transform.eulerAngles.y, 0.0f));
		/*
		Vector3 prePosition = new Vector3 (tranformCam.transform.eulerAngles.x, 0.0f, tranformCam.transform.eulerAngles.z);
			
		Quaternion toRotation = transform.rotation * Quaternion.LookRotation (prePosition);
		tranformBody.transform.rotation = Quaternion.Slerp (transform.rotation, toRotation, Time.deltaTime);*/
	}
}
