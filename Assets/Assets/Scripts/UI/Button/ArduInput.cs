using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class ArduInput : MonoBehaviour
{
	public SerialPort serial;

    void Awake()
    {
		serial = new SerialPort("COM5", 115200, 
						System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
		serial.RtsEnable = true;
		serial.Handshake = Handshake.None;
		serial.ReadTimeout = 200;
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