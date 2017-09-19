using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class ArduInput : MonoBehaviour
{
	public SerialPort serial;
    public int dir;

    public void Awake()
    {
        if( dir == 1 )
            serial = SaveArduino.serial_L;
        else if (dir == 2 )
            serial = SaveArduino.serial_R;
    }

    public void punch(){
		if (serial.IsOpen)
			serial.Write ("1");
		else
			Debug.Log ("not open - punch");
	}
	public void shoot() {
		if (serial.IsOpen)
			serial.Write ("5");
		else
			Debug.Log ("not open - shoot");	
	}

}