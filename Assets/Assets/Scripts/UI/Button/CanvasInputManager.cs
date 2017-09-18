using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class CanvasInputManager : MonoBehaviour
{
	public ComportManager ComMgr;
	public void Update(){
		if (Input.GetKey (KeyCode.O))
			Reset ();
		
		if (Input.GetKey (KeyCode.P)) {
			if( Time.timeScale == 0 )
				Time.timeScale = 1f;
			else
				Time.timeScale = 0f;
		}

		if (Input.GetKey (KeyCode.Keypad1))
			ComMgr._Toggle [0].isOn = true;
		
		if (Input.GetKey (KeyCode.Keypad2))
			ComMgr._Toggle [1].isOn = true;
		
		if (Input.GetKey (KeyCode.Keypad3))
			ComMgr._Toggle [2].isOn = true;
		
		if (Input.GetKey (KeyCode.Keypad4))
			ComMgr._Toggle [3].isOn = true;
		
		if (Input.GetKey (KeyCode.Keypad5))
			ComMgr._Toggle [4].isOn = true;
		
	}

	public void Reset()
	{
		foreach (Toggle e in ComMgr._Toggle) {
			e.isOn = false;
		}
	}

}