using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class ToggleButton : MonoBehaviour
{
	public Toggle _Toggle;
	public void OnOff()
	{
        /*
		if (_Toggle.isOn == true)
			_Toggle.isOn = false;
		else*/
			_Toggle.isOn = true;

	}
		
}