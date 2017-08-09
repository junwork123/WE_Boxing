using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters<Enermy>
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

	public override void Start(){
		mCamera = GetComponentInChildren<Camera> ();
		mAnim.SetInteger ("AttackMode", 1);

		Cursor.lockState = CursorLockMode.Locked;

	}

	void FixedUpdate () 
	{ 
		Init();
		Move ();
		Attack ();
		Avoid ();
	} 

	public override void Init() {
		mAnim.SetBool ("Left", false);
		mAnim.SetBool ("Right", false);
		mAnim.SetBool ("Damaged", false);
	}

	public override void applyDamage(){
		Player.OnPlayerAttack ();
		print (this.name +" applied damage : " + this.Damage);
	}

	public override void getDamage(){ }

	void OnTriggerEnter( Collider col ){

		if ( col.transform.tag == "HandCol" ){
			mAnim.SetBool ("Damaged", true);
			//print (this.name +" get damaged : " + Player.Damage);
			//Player.OnPlayerAttack ();
			//col.transform.SendMessage ("applyDamage", Player.playerDamage);
		}

	}


	public override void Move(){

		float moveFB = Input.GetAxis ("Horizontal");
		float moveLR = Input.GetAxis ("Vertical");

		mDir = new Vector3 (moveFB, 0, moveLR);
		transform.Translate (mDir * Time.smoothDeltaTime * moveSpeed);
		//mRigidbody.AddForce (mDir * moveSpeed * Time.smoothDeltaTime, ForceMode.Force);
		//mRigidbody.velocity = mDir * moveSpeed;

		mAnim.SetFloat ("moveFB", moveLR);
		mAnim.SetFloat ("moveLR", moveFB);

	}


	public override void Attack(){

		Avoid ();
		// 어택 모드 설정
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			mAnim.SetInteger ("AttackMode", 1);
			Damage = hookDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			mAnim.SetInteger ("AttackMode", 2);
			Damage = japDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			mAnim.SetInteger ("AttackMode", 3);
			Damage = upperDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			mAnim.SetInteger ("AttackMode", 4);
			Damage = comboDamage;
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

	public override void Avoid(){


		if (Input.GetKey (KeyCode.Q)) {
			mAnim.SetBool ("guard", true);

		} else if (Input.GetKey (KeyCode.E)) {
			mAnim.SetBool ("dodge", true);


		} else if (Input.GetKey (KeyCode.R)) {
			mAnim.SetBool ("weaving", true);


		}

		if (Input.GetKey (KeyCode.Q | KeyCode.E | KeyCode.R)){
			mAnim.SetBool ("Left", false);
			mHand_L.enabled = false;

			mAnim.SetBool ("Right", false);
			mHand_R.enabled = false;
		} else{
			mAnim.SetBool ("guard", false);
			mAnim.SetBool ("dodge", false);
			mAnim.SetBool ("crouch", false);
			mAnim.SetBool ("weaving", false);

		}



	}

}