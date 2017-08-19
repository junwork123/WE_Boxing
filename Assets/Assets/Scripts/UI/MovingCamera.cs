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

	public Player player;
	public Enermy enermy;

	const int ON = 1;
	const int OFF = 0;

    // Use this for initialization
    void Start()
    {
		startCanvasG.alpha = 1;
		startCanvas.enabled = true;

		settingCanvasG.alpha = 0;
		settingCanvas.enabled = false;
		//StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
		
        yield return new WaitForSeconds(0.3f);
        Camera.allCameras[4].depth = 6;
        yield return new WaitForSeconds(1);
        Camera.allCameras[3].depth = 7;
        yield return new WaitForSeconds(1);
        Camera.allCameras[2].depth = 8;
        yield return new WaitForSeconds(1);
        Camera.allCameras[1].depth = 9;
        yield return new WaitForSeconds(1);
        Camera.allCameras[0].depth = 10;

		Debug.Log (this.ToString());
		StopCoroutine (StartGame());
    }
	/*
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown (KeyCode.Alpha1))
			PressButton (1);
		if (Input.GetKeyDown (KeyCode.Alpha2))
			PressButton (2);
		if (Input.GetKeyDown (KeyCode.Alpha3))
			PressButton (3);
		if (Input.GetKeyDown (KeyCode.Alpha4))
			PressButton (4);
    }
    */
    public void PressButton(int number)
    {

		switch (number) {
		case 1: //start button
			Crosshair.isStarted = true;
			//goCamera.SetActive (false);

			Cursor.lockState = CursorLockMode.Locked;

			OnOff (startCanvas, startCanvasG, OFF);// 스타트 캔버스 hide
			OnOff (settingCanvas, settingCanvasG, OFF);// 스타트 캔버스 hide
			goCamera.SetActive (false);
			player.gameObject.SetActive (false);
			enermy.gameObject.SetActive (false);
			//StartCoroutine ("StartGame");

			break;
		case 2: // setting button
			OnOff (startCanvas, startCanvasG, OFF); // 스타트 캔버스 hide
			OnOff (settingCanvas, settingCanvasG, ON);// 세팅 캔버스 reveal
			break;
		case 3: // quit button
			OnOff (startCanvas, startCanvasG, OFF);
			OnOff (settingCanvas, settingCanvasG, OFF);
			// @#@ 종료 코드 삽입
			break;

		case 4: // back button
			OnOff (startCanvas, startCanvasG, ON);
			OnOff (settingCanvas, settingCanvasG, OFF);
			break;
			
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
