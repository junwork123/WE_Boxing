using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Punch_Judgment : MonoBehaviour {

	public Vector3   Accel;
	public JointOrientation test;
	public static string attackMode;
	/*
	private float[] arraccelX = new float[15];
	private float[] arraccelY = new float[15];
	private float[] arraccelZ = new float[15];*/
	public string t1 = "";
	public double s = 1, a = 0, i_c = 1.0001;
	public bool Jap_L = false, Jap_R = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Jap_L") {
			if (Jap_L != true) {
				a = Math.Sqrt (Accel.x * Accel.x + Accel.y * Accel.y + Accel.z * Accel.z);

				if (a > 1)
					s *= i_c;
				else
					s /= i_c;

				double accelrometerdata = s * a;

				//t1 += Accel.x + "\t" + Accel.y + "\t" + Accel.z + "\t" + accelrometerdata + "\n";

				if (Accel.y < 0.6 && Accel.z < -0.65 && accelrometerdata > 0.95001) {
					Jap_L = true;
					Debug.Log ("Jap_L");
					attackMode = ("Jap_L");
				}
				else if (Accel.y < 1.3 && accelrometerdata > 1.2001) {
					Jap_L = true;
					Debug.Log ("Hook_L");
					attackMode = ("Hook_L");
				}

			}
		}
		if (col.tag == "Jap_R") {
			if (Jap_R != true) {
				a = Math.Sqrt (Accel.x * Accel.x + Accel.y * Accel.y + Accel.z * Accel.z);

				if (a > 1)
					s *= i_c;
				else
					s /= i_c;

				double accelrometerdata = s * a;

				if ( (Accel.z < -0.8000 && accelrometerdata > 0.9501) ) {
					Jap_R = true;
					Debug.Log ("Jap_R");
					attackMode = ("Jap_R");
				}
				else if (Accel.y > 0.7555 && Accel.z > 0.95 && accelrometerdata > 1.1501) {
					Jap_R = true;
					Debug.Log ("Hook_R");
					attackMode = ("Hook_R");
				}

			}
		}
		StartCoroutine (Delay ());
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "Jap_L") {
			//Debug.Log (t1);
			a = 0;
			s = 1;
			t1 = "";
			Jap_L = false;
		}
		if (col.tag == "Jap_R") {
			//Debug.Log (t1);
			a = 0;
			s = 1;
			t1 = "";
			Jap_R = false;
		}
	}

	IEnumerator Delay(){
		yield return new WaitForSeconds (0.3f);
		attackMode = "";
		yield return null;
	}
}