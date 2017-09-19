using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class ComportManager : MonoBehaviour
{

    public CanvasInputManager canvasMgr;

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
			SaveArduino.serial_L.PortName = ports [idx];
		
		else if (cnt == 1)
            SaveArduino.serial_R.PortName = ports [idx];

		else
			cnt = 0;
		
		cnt++;
	}

	public void Open(){

        // 포트 연결
        if ((!SaveArduino.serial_L.IsOpen) && (!SaveArduino.serial_R.IsOpen))
        {

            try
            {
                SaveArduino.serial_L.Open();
            }
            catch
            {
                Debug.Log("Error Serial_L");
            }
            try
            {
                SaveArduino.serial_R.Open();
            }
            catch
            {
                Debug.Log("Error Serial_R");
            }

            // 타격 테스트
            SaveArduino.serial_L.Write("1");
            SaveArduino.serial_R.Write("1");

            // 피격 테스트 
            SaveArduino.serial_L.Write("5");
            SaveArduino.serial_R.Write("5");

            canvasMgr.BackCanvas();

            Debug.Log("Connected " + SaveArduino.serial_L.PortName);
            Debug.Log("Connected " + SaveArduino.serial_R.PortName);

            foreach (Toggle t in _Toggle)
                t.isOn = false;

        }
	}

}
