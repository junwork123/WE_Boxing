using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class ComportText : MonoBehaviour
{
	public Text portName;
	public ArduInput _ArduInput;
	public int num;
	void Start()
	{
		portName.text = _ArduInput.ports[num];
	}
		
}