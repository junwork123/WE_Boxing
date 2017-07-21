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

	int attackMode;
	int attackDir;

	bool isHolding = false;

	// Use this for initialization
	void Start () {
		mAnim = GetComponent<Animator> ();

		target = GameObject.FindGameObjectWithTag ("Player");
		Player.OnPlayerAttack += this.OnPlayerAttack;
	}

	void Update () 
	{ 
		StartCoroutine ("changeState");
		init();
		Move ();
		Attack ();
	} 

	void init() {
		mAnim.SetBool ("Left", false);
		mAnim.SetBool ("Right", false);
		mAnim.SetBool ("Damaged", false);

		attackMode = Random.Range (1, 4); // 공격모션 : 훅 = 1, 잽 = 2, 어퍼 = 3, 콤보 = 4
		attackDir = Random.Range (0, 1); // 공격방향 : 왼쪽 = 0, 오른쪽 = 1
	}

	void OnTriggerEnter( Collider col ){

		if ( col.transform.tag == "HandCol" ){
			target.GetComponent<Player>().applyDamage (Player.Power);
		}

	}

	void OnPlayerAttack(){
		// 홀딩 상태가 아닐때만 피격
		if (isHolding == false) {

			isHolding = true;
			StartCoroutine ("Holding");
		}
	}
		
	// 코루틴 함수
	IEnumerator Holding(){
		
		float ratio1 = 0.2f;
		float ratio2 = 0.4f;
		float countTime = mAnim.GetCurrentAnimatorClipInfo(0).Length;

		// ratio1 비율까지 기다렸다가 파라미터 변경
		yield return new WaitForSeconds(countTime * ratio1);
		mAnim.SetBool ("Damaged", true);

		// ratio2비율까지 기다렸다가 HP감소, 메시지 출력, 홀딩 상태 변경
		yield return new WaitForSeconds(countTime * ratio2);
		HP -= Player.Power;
		print (this.name + " get damaged : " + HP);
		isHolding = false;

		if (HP <= 0) {
			mAnim.SetBool ("Died", true);
			yield return null; 
		}
		
	}

	void Attack(){


	}

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

	IEnumerator changeState(){
		yield return new WaitForSeconds (1f);

	}
			
}
