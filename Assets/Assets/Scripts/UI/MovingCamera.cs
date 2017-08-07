using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour {

    public GameObject goCamera;
    public GameObject Startbutton;
    public GameObject Quitbutton;
    public GameObject Settingbutton;
	bool isFirst = true; // 임시로 만든 시작변수

    // Use this for initialization
    void Start()
    {
        //StartCoroutine("PayRun");
    }

    IEnumerator PayRun()
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
    }
    // Update is called once per frame
    void Update()
    {
		// 임시로 만든 시작기능
		if (Input.anyKeyDown && isFirst == true) {
			StartCoroutine ("PayRun");
			Startbutton.gameObject.SetActive (false);
			Quitbutton.gameObject.SetActive (false);
			Settingbutton.gameObject.SetActive (false);
			isFirst = false;
		}
    }
    
    public void PressKey(int nKey)
    {
        //처음 데이터 받기
        Vector3 rectTemp = this.goCamera.transform.localPosition;

        switch (nKey)
        {
            case 1: //start
                StartCoroutine("PayRun");
                Startbutton.gameObject.SetActive(false);
                Quitbutton.gameObject.SetActive(false);
                Settingbutton.gameObject.SetActive(false);
                break;
            case 2: //up, quit
                Startbutton.gameObject.SetActive(false);
                Quitbutton.gameObject.SetActive(false);
                Settingbutton.gameObject.SetActive(false);
                break;
            case 3: //right, setting
                Startbutton.gameObject.SetActive(false);
                Quitbutton.gameObject.SetActive(false);
                Settingbutton.gameObject.SetActive(false);
                break;
        }

        //완성된 데이터 저장
        this.goCamera.transform.localPosition = rectTemp;
    }
}
