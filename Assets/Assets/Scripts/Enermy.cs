using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : Characters
{
	IEnumerator mCorutine;
	Vector3 mDir;
	Vector3[] mDirArray = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
	public UnityEngine.AI.NavMeshAgent mNav;

	int attackMode;
	int attackDir;
	bool isHolding = false;

	Enermy(){}

	// Use this for initialization
	public override void Start () {

		mCorutine = Holding ();		
		mNav.SetDestination (target.transform.position);
		StartCoroutine (Tracking());

		Player.OnPlayerAttack += this.OnPlayerAttack;

	}

	void Update () 
	{ 
		Init();
		Move ();
		Attack ();
	} 

	public override void Init() {
		mAnim.SetBool ("Left", false);
		mAnim.SetBool ("Right", false);
		mAnim.SetBool ("Damaged", false);

		attackMode = Random.Range (1, 4); // 공격모션 : 훅 = 1, 잽 = 2, 어퍼 = 3, 콤보 = 4
		attackDir = Random.Range (0, 1); // 공격방향 : 왼쪽 = 0, 오른쪽 = 1
	}

	void OnTriggerEnter( Collider col ){

		// 손의 콜라이더에 닿았을 때
		if ( col.transform.tag == "HandCol" ){

			// 회피중이 아니라면 피격됬음을 알림
			// if( not avoid )
			target.GetComponent<Player>().applyDamage (Player.Power);
		}

	}

	public override void applyDamage(float damage){
	}

	public override void getDamage(float damage){
	}

	void OnPlayerAttack(){
		// 홀딩 상태가 아닐때만 피격
		if (isHolding == false) {

			isHolding = true;
			mCorutine = Holding ();
			StartCoroutine (mCorutine);
		}
	}
		
	// 코루틴 함수
	IEnumerator Holding(){
		
		float ratio1 = 0.2f;
		float ratio2 = 0.3f;
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
			//yield return null; 
		}
		
	}

	IEnumerator Tracking(){
		
		if (mNav.remainingDistance > 3.0f) {
			mDir = Vector3.forward;
			mNav.SetDestination (target.transform.position);
		}
		else if (mNav.remainingDistance <= mNav.stoppingDistance) {
			mDir = Vector3.back;
			mNav.Stop ();
		}
		else {
			//mDir = mDirArray[Random.Range(0, mDirArray.Length)];
			mDir = Vector3.left;
			mNav.SetDestination (target.transform.position);
		}
		transform.Translate (mDir * Time.smoothDeltaTime * moveSpeed);
		yield return new WaitForSeconds(1.0f);


	}

	public override void Attack(){


	}

	public override void Move(){
		// 플레이어 쪽으로 방향 회전

		transform.rotation = Quaternion.Slerp (transform.rotation, 
			Quaternion.LookRotation (target.transform.position - transform.position), 1);

		StartCoroutine (Tracking());
	
		/*
		float distance = Vector3.Distance (target.transform.position, transform.position);

		if (distance > 4.0f)
			mDir = Vector3.forward;
		else if (distance <= 1.0f) {
			mDir = Vector3.back;
		}
		else {
			//mDir = mDirArray[Random.Range(0, mDirArray.Length)];
			mDir = Vector3.left;
		}
			transform.Translate (mDir * Time.smoothDeltaTime * moveSpeed);
		*/
	}	
}
