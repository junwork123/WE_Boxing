using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class ComportManager : MonoBehaviour
{
	public SerialPort serial_L;
	public SerialPort serial_R;
	public string[] ports;
	int portIdx = 0;
	int cnt = 0;

	public Toggle [] _Toggle;
	public Text[] _ToggleText;

	void Awake()
	{
		ports = SerialPort.GetPortNames();

		foreach (Text t in _ToggleText) {
			if (portIdx < ports.Length)
				t.text = ports [portIdx++];
		}
	}

	public void setPortName(int idx){
		if (cnt == 0)
			serial_L.PortName = ports [idx];
		else if (cnt == 1)
			serial_R.PortName = ports [idx];
		else
			cnt = 0;
		
		cnt++;
	}

	public void Open(){

		// 포트 연결
		if ( (!serial_L.IsOpen) && (!serial_R.IsOpen) ) {

			try{
				serial_L.Open();
				serial_R.Open();
			} catch{
				Debug.Log ("error");
			} finally{
				Debug.Log ("Connected " + serial_L.PortName );
				Debug.Log ("Connected " + serial_R.PortName );

				foreach(Toggle t in _Toggle)
					t.isOn = false;

			}
		}
	}

}
