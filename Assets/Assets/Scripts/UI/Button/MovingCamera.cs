using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour {

    public GameObject goCamera;
    public GameObject Startbutton;
    public GameObject Quitbutton;
    public GameObject Settingbutton;

	public Canvas startCanvas;
	public Canvas settingCanvas;
	public CanvasGroup startCanvasG;
	public CanvasGroup settingCanvasG;

	public HPBar hpBar;

	const int ON = 1;
	const int OFF = 0;
	int isPressed = -1;

    // Use this for initialization
    void Awake()
    {
		startCanvasG.alpha = 1;
		startCanvas.enabled = true;

		settingCanvasG.alpha = 0;
		settingCanvas.enabled = false;
		//StartCoroutine("StartGame");

		Crosshair.isStarted = false;
		goCamera.SetActive (true);

		SoundManager.started = false;
    }

	public void Update(){
		if (Input.GetKeyDown (KeyCode.Backspace)) {
			OnOff (startCanvas, startCanvasG, ON);
			OnOff (settingCanvas, settingCanvasG, OFF);	
		}
	}


    public void PressButton(int number)
    {

		if (isPressed != number) {
			switch (number) {
			case 1: //start button
				Crosshair.isStarted = true;
			//goCamera.SetActive (false);

				Cursor.lockState = CursorLockMode.Locked;

				OnOff (startCanvas, startCanvasG, OFF);// 스타트 캔버스 hide
				OnOff (settingCanvas, settingCanvasG, OFF);// 스타트 캔버스 hide
				goCamera.SetActive (false);
				SoundManager.started = true;
				SoundManager.instance.BGMSound ("Start");
				//hpBar.StartTimer ();
			//StartCoroutine ("StartGame");

				break;
			case 2: // setting button
				OnOff (startCanvas, startCanvasG, OFF); // 스타트 캔버스 hide
				OnOff (settingCanvas, settingCanvasG, ON);// 세팅 캔버스 reveal
				break;
			case 3: // quit button
				OnOff (startCanvas, startCanvasG, OFF);
				OnOff (settingCanvas, settingCanvasG, OFF);
				Application.Quit ();
				break;

			case 4: // back button
				OnOff (startCanvas, startCanvasG, ON);
				OnOff (settingCanvas, settingCanvasG, OFF);
				break;
			}

			isPressed = number;
		}
    }

	public void OnOff(Canvas canvas, CanvasGroup canvasG, int FLAG){

		if (FLAG == ON) {
			canvasG.alpha = ON;
			canvas.enabled = true;
		} else {
			canvasG.alpha = OFF;
			canvas.enabled = false;
		}

	}

}
