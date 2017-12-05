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
		if (SaveArduino.serial_L.IsOpen && dir == 1 )
            SaveArduino.serial_L.Write ("1");
		else if(SaveArduino.serial_R.IsOpen && dir == 2)
            SaveArduino.serial_R.Write("1");
        else
            Debug.Log ("not open - punch");
	}
	public void shoot() {
		if (SaveArduino.serial_R.IsOpen || SaveArduino.serial_L.IsOpen)
        {
            SaveArduino.serial_L.Write("5");
            SaveArduino.serial_R.Write("5");
        }
		else
			Debug.Log ("not open - shoot");	
	}

}