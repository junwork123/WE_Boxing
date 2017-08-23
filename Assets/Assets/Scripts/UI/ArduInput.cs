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
		sp = new SerialPort("COM5", 115200, 
						System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
		sp.RtsEnable = true;
		sp.Handshake = Handshake.None;
		sp.ReadTimeout = 200;
			
		ports = SerialPort.GetPortNames();

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
	void Update () {

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			OnOff (1);
		}else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			OnOff (2);
		}else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			OnOff (3);
		}else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			OnOff (4);
		}else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			OnOff (5);
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			Debug.Log ("Attempt to Open");
			Open ();

		}
		if(Input.GetKeyDown(KeyCode.R)){
			foreach(Toggle t in _Toggle)
				t.isOn = false;

			Debug.Log ("Reset Buttons");
		}


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

	public void OnOff(int idx)
	{
		idx = idx - 1;
		if (_Toggle[idx].isOn == true)
			_Toggle[idx].isOn = false;
		else
			_Toggle[idx].isOn = true;

	}
}