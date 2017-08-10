using System.Collections;
using UnityEngine;


public class PlayerHead : MonoBehaviour
{
	public float velocity = 0.7f;
	public Camera mCamera;
	public bool isMoving;

	void Update(){
		// 카메라 방향에 따라
		Vector3 moveDirection = mCamera.transform.forward;
		moveDirection *= velocity * Time.deltaTime;
		moveDirection.y = 0.0f;
	}
}


