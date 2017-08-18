using System.Collections;
using UnityEngine;


public class PlayerHead : MonoBehaviour
{
	public Transform tranformCam;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		// 카메라가 바라보는 방향으로
		// y축 기준 회전
		tranformCam.transform.position = new Vector3(0f, 0f, 0f);

	}
}


