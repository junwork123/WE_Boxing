using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class CanvasInputManager : MonoBehaviour
{
	public ComportManager ComMgr;
<<<<<<< HEAD
    public MovingCamera moveCam;

=======
>>>>>>> 848a8254390eb034c476f532aa0c4a061699fe39
	public void Update(){
		if (Input.GetKey (KeyCode.O))
			Reset ();
		
		if (Input.GetKey (KeyCode.P)) {
			if( Time.timeScale == 0 )
				Time.timeScale = 1f;
			else
				Time.timeScale = 0f;
		}

<<<<<<< HEAD
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
=======
		if (Input.GetKey (KeyCode.Keypad1))
			ComMgr._Toggle [0].isOn = true;
		
		if (Input.GetKey (KeyCode.Keypad2))
			ComMgr._Toggle [1].isOn = true;
		
		if (Input.GetKey (KeyCode.Keypad3))
>>>>>>> 848a8254390eb034c476f532aa0c4a061699fe39
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
<<<<<<< HEAD
        SaveArduino.serial_L.Close ();
        SaveArduino.serial_R.Close ();
	}

    public void BackCanvas()
    {
        moveCam.OnOff(moveCam.startCanvas, moveCam.startCanvasG, 1);
        moveCam.OnOff(moveCam.settingCanvas, moveCam.settingCanvasG, 0);

        moveCam.startCanvas.GetComponent<BoxCollider>().enabled = true;
        moveCam.settingCanvas.GetComponent<BoxCollider>().enabled = false;
=======
>>>>>>> 848a8254390eb034c476f532aa0c4a061699fe39
    }

}