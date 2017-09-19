using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class ArduInput : MonoBehaviour
{
	public SerialPort serial;
<<<<<<< HEAD
    public int dir;

    public void Awake()
    {
        if( dir == 1 )
            serial = SaveArduino.serial_L;
        else if (dir == 2 )
            serial = SaveArduino.serial_R;
=======

    void Awake()
    {
		serial = new SerialPort("COM5", 115200, 
						System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
		serial.RtsEnable = true;
		serial.Handshake = Handshake.None;
		serial.ReadTimeout = 200;
>>>>>>> 848a8254390eb034c476f532aa0c4a061699fe39
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