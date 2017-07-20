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
	public float hookDamage = 5;
	public float japDamage = 5;
	public float upperDamage = 5;
	public float comboDamage = 5;

	bool isHolding = false;

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
		if (isHolding == false) {

			isHolding = true;
			StartCoroutine ("Holding");
		}
	}

	void OnTriggerEnter( Collider col ){
		
		if ( col.transform.tag == "HandCol" ){
			target.GetComponent<Player>().applyDamage (Player.Power);
		}

	}

	IEnumerator Holding(){
		
		float ratio1 = 0.2f;
		float ratio2 = 0.5f;
		float countTime = mAnim.GetCurrentAnimatorClipInfo(0).Length;
		yield return new WaitForSeconds(countTime * ratio1);

		mAnim.SetBool ("Damaged", true);


		yield return new WaitForSeconds(countTime * ratio2);

		HP -= Player.Power;
		print (this.name + " get damaged : " + HP);
		isHolding = false;

		if (HP <= 0) {
			mAnim.SetBool ("Died", true);
			yield return null; 
		}
		
	}
	/*
	void Attack(){
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
