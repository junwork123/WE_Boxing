using System.Collections;
using UnityEngine;


public class PlayerHead : MonoBehaviour
{
	public GameObject head;
	public GameObject VRCam;
	public GameObject headPos;

	// Use this for initialization
	void Start () {
		/*
		VRCam = Instantiate (VRCam, headPos.transform.position, headPos.transform.rotation);
		headPos.transform.SetParent (head.transform, false);
		VRCam.transform.SetParent (headPos.transform, false);*/
	}
	/*
	void Update(){
		//VRCam.transform.position = new Vector3 (VRCam.transform.position.x, VRCam.transform.position.y, VRCam.transform.position.z);
	}*/
}


