using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class CanvasInputManager : MonoBehaviour
{
	public ComportManager ComMgr;
    public MovingCamera moveCam;

	public void Update(){
		if (Input.GetKey (KeyCode.O))
			Reset ();
		
		if (Input.GetKey (KeyCode.P)) {
			if( Time.timeScale == 0 )
				Time.timeScale = 1f;
			else
				Time.timeScale = 0f;
		}

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            moveCam.OnOff(moveCam.startCanvas, moveCam.startCanvasG, 1);
            moveCam.OnOff(moveCam.settingCanvas, moveCam.settingCanvasG, 0);
        }

        if (Input.GetKey (KeyCode.Keypad7))
			ComMgr._Toggle [0].isOn = true;
		
		if (Input.GetKey (KeyCode.Keypad8))
			ComMgr._Toggle [1].isOn = true;
		
		if (Input.GetKey (KeyCode.Keypad9))
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
        SaveArduino.serial_L.Close ();
        SaveArduino.serial_R.Close ();
	}

    public void BackCanvas()
    {
        moveCam.OnOff(moveCam.startCanvas, moveCam.startCanvasG, 1);
        moveCam.OnOff(moveCam.settingCanvas, moveCam.settingCanvasG, 0);

        moveCam.startCanvas.GetComponent<BoxCollider>().enabled = true;
        moveCam.settingCanvas.GetComponent<BoxCollider>().enabled = false;
    }

}