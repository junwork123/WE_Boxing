using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class ComportManager : MonoBehaviour
{
<<<<<<< HEAD
    public CanvasInputManager canvasMgr;

=======
	public SerialPort serial_L;
	public SerialPort serial_R;
>>>>>>> 848a8254390eb034c476f532aa0c4a061699fe39
	public string[] ports;
	int portIdx = 0;
	int cnt = 0;

	public Toggle [] _Toggle;
	public Text[] _ToggleText;

	void Awake()
	{
<<<<<<< HEAD

=======
>>>>>>> 848a8254390eb034c476f532aa0c4a061699fe39
        ports = SerialPort.GetPortNames();

		foreach (Text t in _ToggleText) {
			if (portIdx < ports.Length)
				t.text = ports [portIdx++];
		}
	}

	public void setPortName(int idx){
		if (cnt == 0)
<<<<<<< HEAD
			SaveArduino.serial_L.PortName = ports [idx];
		else if (cnt == 1)
            SaveArduino.serial_R.PortName = ports [idx];
=======
			serial_L.PortName = ports [idx];
		else if (cnt == 1)
			serial_R.PortName = ports [idx];
>>>>>>> 848a8254390eb034c476f532aa0c4a061699fe39
		else
			cnt = 0;
		
		cnt++;
	}

	public void Open(){

        // 포트 연결
<<<<<<< HEAD
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
=======
		if ( (!serial_L.IsOpen) && (!serial_R.IsOpen) ) {

			try{
				serial_L.Open();
				serial_R.Open();
			} catch{
				Debug.Log ("error");
			} finally{
				Debug.Log ("Connected " + serial_L.PortName );
				Debug.Log ("Connected " + serial_R.PortName );
>>>>>>> 848a8254390eb034c476f532aa0c4a061699fe39

            foreach (Toggle t in _Toggle)
                t.isOn = false;

        }
	}
<<<<<<< HEAD
=======
	}
>>>>>>> 848a8254390eb034c476f532aa0c4a061699fe39

}
