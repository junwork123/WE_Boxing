using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch_Judgment : MonoBehaviour {

	public Vector3	Accel;
	public JointOrientation test;
	public static string attackMode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Jap_L") {
			if (Accel.x < 0.62 && Accel.y < 0.7500 && Accel.z < 0.4) {
				//string t1 = "Jap_L JL_X = " + Accel.x + "\tJL_Y = " + Accel.y + "\tJL_Z = " + Accel.z;
				Debug.Log ("Jap_L");
				attackMode = ("Jap_L");
				//test.updateReference = true;
			}

		}
		if (col.tag == "Jap_R") {
			if (Accel.x < 0.45 && Accel.y > -0.1000 && Accel.z < 0.2) {
			//string t1 = "Jap_R JR_X = " + Accel.x + "\tJR_Y = " + Accel.y + "\tJR_Z = " + Accel.z;
				Debug.Log ("Jap_R");
				attackMode = ("Jap_R");
			//test.updateReference = true;
			}
		}
		if (col.tag == "Hook_L") {
			if (Accel.x < 0.3 && Accel.y > 0.45000 && Accel.z < -0.1) {
				//string t1 = "Hook_L X = " + Accel.x + "\tY = " + Accel.y + "\tZ = " + Accel.z;
				Debug.Log ("Hook_L");
				attackMode = ("Hook_L");
			}
		}
		if (col.tag == "Hook_R") {
			if (Accel.x > -0.65 && Accel.y > - 0.5  && Accel.z < -0.2) {
				//string t1 = "Hook_R X = " + Accel.x + "\tY = " + Accel.y + "\tZ = " + Accel.z;
				Debug.Log ("Hook_R");
				attackMode = ("Hook_R");
			}
		}
		if (col.tag == "Upper_L") {
			if (Accel.x > 0.0 && Accel.y > 0.1  && Accel.z < 0.7) {
				//string t1 = "Upper_L X = " + Accel.x + "\tY = " + Accel.y + "\tZ = " + Accel.z;
				Debug.Log ("Upper_L");
				attackMode = ("Upper_L");
			}
		}
		if (col.tag == "Upper_R") {
			if (Accel.x < 0.2 && Accel.y < 0.33  && Accel.z < 0.5) {
				//string t1 = "Upper_R X = " + Accel.x + "\tY = " + Accel.y + "\tZ = " + Accel.z;
				Debug.Log ("Upper_R");
				attackMode = ("Upper_R");
			}
		}

		StartCoroutine (Delay ());
	}

	IEnumerator Delay(){
		yield return new WaitForSeconds (0.3f);
		attackMode = "";
		yield return null;
	}
	/*
	void OnTriggerExit(Collider col){
		attackMode = "";
	}*/
}
