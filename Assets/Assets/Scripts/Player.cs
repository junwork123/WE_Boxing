using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
	// 움직임 변수
	public float mouseSensitivity = 2f;
	public float upDownRange= 30;

	private float rotationX;
	private float rotationY;

	Vector3 mDir;
	public Camera mCamera;


	// 델리게이트 
	public delegate void PlayerAttackHandler();
	public static event PlayerAttackHandler OnPlayerAttack;

	Player(){}

	void Start(){
		mCamera = GetComponentInChildren<Camera> ();
		mAnim.SetInteger ("AttackMode", 1);

		Cursor.lockState = CursorLockMode.Locked;

	}

	void FixedUpdate () 
	{ 
		Init();
		Move ();
		Attack ();
	} 

	public override void Init() {
		mAnim.SetBool ("Left", false);
		mAnim.SetBool ("Right", false);
		mAnim.SetBool ("Damaged", false);
	}

	public override void applyDamage(float damage){
		Player.OnPlayerAttack ();
		print (this.name +" applied damage : " + Player.Power);
	}

	public override void getDamage(float damage){
	}

	void OnTriggerEnter( Collider col ){

		if ( col.transform.tag == "HandCol" ){
			mAnim.SetBool ("Damaged", true);
			//print (this.name +" get damaged : " + Player.Power);
			//Player.OnPlayerAttack ();
			//col.transform.SendMessage ("applyDamage", Player.playerPower);
		}

	}

	public override void Attack(){
		// 어택 모드 설정
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			mAnim.SetInteger ("AttackMode", 1);
			Power = hookDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			mAnim.SetInteger ("AttackMode", 2);
			Power = japDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			mAnim.SetInteger ("AttackMode", 3);
			Power = upperDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			mAnim.SetInteger ("AttackMode", 4);
			Power = comboDamage;
		}

		// 왼쪽 공격 설정
		if (Input.GetMouseButton (0)) { 
			mAnim.SetBool ("Left", true);
			mHand_L.enabled = true;

			mAnim.SetBool ("Right", false);
			mHand_R.enabled = false;

			// 오른쪽 공격 설정 
		} else if (Input.GetMouseButton (1)) { 
			mAnim.SetBool ("Left", false);
			mHand_L.enabled = false;

			mAnim.SetBool ("Right", true);
			mHand_R.enabled = true;

		} else {
			mHand_L.enabled = false;
			mHand_R.enabled = false;
		}
			
	}

	public override void Move(){
		
		float moveFB = Input.GetAxis ("Horizontal");
		float moveLR = Input.GetAxis ("Vertical");

		mDir = new Vector3 (moveFB, 0, moveLR);
		mDir = mCamera.transform.TransformDirection (mDir);
		mRigidbody.AddForce (mDir * moveSpeed * Time.smoothDeltaTime, ForceMode.Force);
		mRigidbody.velocity = mDir * moveSpeed;

		mAnim.SetFloat ("moveFB", moveLR);
		mAnim.SetFloat ("moveLR", moveFB);

		//좌우 회전
		rotationX = Input.GetAxis ("Mouse X") * mouseSensitivity + transform.localEulerAngles.y;

		//상하 회전
		rotationY += Input.GetAxis ("Mouse Y") * mouseSensitivity;
		rotationY = Mathf.Clamp (rotationY, -upDownRange, upDownRange);

		transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0f);
	}

}