using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class ArduInput : MonoBehaviour
{
    public string[] ports;
	int portIdx;
	SerialPort sp;

	public Toggle [] _Toggle;
	public Text[] _ToggleText;
	bool togglo_on = false;

    void Start()
    {
		sp = new SerialPort();
        ports = SerialPort.GetPortNames();

		if (!sp.IsOpen) {
			sp.PortName = "No Devices";
			sp.BaudRate = 115200;
			sp.RtsEnable = true;
		}
			
		foreach (Text t in _ToggleText) {
			if (portIdx < ports.Length)
				t.text = ports [portIdx++];
		}
		/*
        Maindropdown.options.Clear();
		List<Dropdown.OptionData> names = new List<Dropdown.OptionData> ();

        foreach (string c in ports)
        {
			Dropdown.OptionData name = new Dropdown.OptionData (c);
			names.Add (name);
        }

		Maindropdown.AddOptions(names);*/
    }

	public void Open(){

		for (int i = 0; i < _Toggle.Length; i++) {
			if( _Toggle[i].isOn == true ){
				if (togglo_on == false) {
					togglo_on = true;
					sp.PortName = _ToggleText[i].text;
				} else {
					Debug.Log ("too many toggle selected");
					return;
				}
			}
		}

		if (!sp.IsOpen) {

			try{
				sp.Open ();
			} catch{
				Debug.Log ("error");
			} finally{
				Debug.Log ("Connected " + sp.PortName);

				foreach(Toggle t in _Toggle)
					t.isOn = false;
			}
		}
	}

	public void punch(){
		if (sp.IsOpen)
			sp.Write ("1");
		else
			Debug.Log ("not open - punch");
	}
	public void shoot() {
		if (sp.IsOpen)
			sp.Write ("2");
		else
			Debug.Log ("not open - shoot");	
	}
}