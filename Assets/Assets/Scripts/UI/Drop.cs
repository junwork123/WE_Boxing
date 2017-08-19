using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class Drop : MonoBehaviour
{
    public Dropdown Maindropdown;
    public Text text;
    public string[] ports;
	private SerialPort sp = new SerialPort ();//시리얼포트 객체

	public GameObject button;
   // public static SerialPort sp = new SerialPort("COM1", 9600);// Refrence to serialPort 
    void Start()
    {
        // Fill ports array with COM's Name available
        ports = SerialPort.GetPortNames();
        //clear/remove all option item
        Maindropdown.options.Clear();
		List<Dropdown.OptionData> names = new List<Dropdown.OptionData> ();

        foreach (string c in ports)
        {
			Dropdown.OptionData name = new Dropdown.OptionData (c);
			names.Add (name);
        }

		Maindropdown.AddOptions(names);
        //this swith from 1 to 0 is only to refresh the visual DdMenu
       // Maindropdown.value = 1;
        //Maindropdown.value = 0;
    }
    void Update()
	{
		//COM port Name that is currently selected on the dropDown Menu

		/*
		ports_state ();

		if (Maindropdown.value > 0) {
			text.text = ports [Maindropdown.value];
			foreach (string c in ports)
			{
				Maindropdown.options.Add(new Dropdown.OptionData() { text = c });
			}
			ports_state ();
		} else
			text.text = null;
		*/

    }

	void ports_state(){
		/*
		if (!sp.IsOpen) {
			button.SetActive (true);
		} else {
			button.SetActive (false);
		}*/
	}

	public void mySelect(){
		Maindropdown.Show ();
		Debug.Log (Maindropdown.options.Count);
	}

	public void Isopen(){

		string test_text = ports [Maindropdown.value];

		/*
		if (Maindropdown.value > 0)
			test_text = ports [Maindropdown.value];
		else
			test_text = "No Devices";*/
		
		if (!sp.IsOpen) {
			sp.PortName = test_text;
			Debug.Log (sp.PortName);
			sp.BaudRate = 115200;
			sp.RtsEnable = true;

			//button.SetActive (false);

			try{
				sp.Open ();
			} catch{
				Debug.Log ("error");
			} finally{
				Debug.Log ("Connected " + sp.PortName);
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