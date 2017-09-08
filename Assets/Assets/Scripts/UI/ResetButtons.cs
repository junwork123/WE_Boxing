using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class ResetButtons : MonoBehaviour
{
	public Toggle [] _Toggle;

	public void Update(){
		if (Input.GetKey (KeyCode.R))
			Reset ();
	}

	public void Reset()
	{
		foreach (Toggle e in _Toggle) {
			e.isOn = false;
		}
	}

}