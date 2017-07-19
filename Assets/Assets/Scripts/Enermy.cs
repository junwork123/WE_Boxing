using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour{

	public float moveSpeed = 5.0f;
	public float rotationSpeed = 5.0f;
	GameObject target;
	Animator mAnim; 	// 애니메이션

	public static float Power = 1;
	public static float HP = 100;
	public float hookDamage = 10;
	public float japDamage = 5;
	public float upperDamage = 15;
	public float comboDamage = 35;

	// Use this for initialization
	void Start () {
		mAnim = GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag ("Player");
		Player.OnPlayerAttack += this.OnPlayerAttack;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{ 
		init();
		Move ();
		//Attack ();;
	} 

	void init() {
		mAnim.SetBool ("Left", false);
		mAnim.SetBool ("Right", false);
		mAnim.SetBool ("Damaged", false);
	}

	void OnPlayerAttack(){
		mAnim.SetBool ("Damaged", true);
		print (this.name +" get damaged : " + Player.Power);
	}

	void OnCollisionEnter( Collision col ){
		
		if ( col.transform.tag == "HandCol" ){
			//applyDamage (Player.Power);
			//col.transform.SendMessage ("applyDamage", Player.playerPower);
		}

	}
	/*
	void Attack(){
		// 어택 모드 설정
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			mAnim.SetInteger ("AttackMode", 1);
			atkPower = hookDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			mAnim.SetInteger ("AttackMode", 2);
			atkPower = japDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			mAnim.SetInteger ("AttackMode", 3);
			atkPower = upperDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			mAnim.SetInteger ("AttackMode", 4);
			atkPower = comboDamage;
		}

		// 왼쪽, 오른쪽 설정
		if (Input.GetMouseButton (0)) { 
			mAnim.SetBool ("Right", false);
			mAnim.SetBool ("Left", true);
		} else if (Input.GetMouseButton (1)) { 
			mAnim.SetBool ("Left", false);
			mAnim.SetBool ("Right", true);
		}
	}
*/
	void Move(){
		transform.rotation = Quaternion.Slerp (transform.rotation, 
			Quaternion.LookRotation (target.transform.position - transform.position), 1);
	
		float distance = Vector3.Distance (target.transform.position, transform.position);

		if (distance > 5.0f)
			transform.Translate (Vector3.forward * Time.smoothDeltaTime * moveSpeed);
		
		else if (distance <= 1.0f) {
			transform.Translate (Vector3.back * Time.smoothDeltaTime * moveSpeed);

		}
	}
			
}
