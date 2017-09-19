using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class SaveArduino : MonoBehaviour
{
    static public SerialPort serial_L;
    static public SerialPort serial_R;

    void Awake()
    {
        DontDestroyOnLoad(this);
        serial_L = new SerialPort("COM5", 115200,
                        System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
        serial_L.RtsEnable = true;
        serial_L.Handshake = Handshake.None;
        serial_L.ReadTimeout = 20000;

        serial_R = new SerialPort("COM5", 115200,
                    System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
        serial_R.RtsEnable = true;
        serial_R.Handshake = Handshake.None;
        serial_R.ReadTimeout = 20000;

    }
}
