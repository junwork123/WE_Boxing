using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : Characters<Player>
{
	IEnumerator mCorutine;
	StateMachine<Enermy> mState;
	//Vector3[] mDirArray = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
	public Vector3 mDir;
	public UnityEngine.AI.NavMeshAgent mNav;


	public float attackDistance = 1.1f;
	float attackDir = 0.5f;
	bool isHolding = false;

	Enermy(){}

	// Use this for initialization
	public override void Start () {
		ResetState ();
		mCorutine = Holding ();		
		mNav.SetDestination (target.transform.position);

		Player.OnPlayerAttack += this.OnPlayerAttack;

	}

	void Update () 
	{ 
		mState.Update ();
	} 

	public void ChangeState(State_FSM<Enermy> _state){
		mState.ChangeState (_state);
	}

	public void ResetState(){
		mState = new StateMachine<Enermy> ();
		mState.Initial_Setting (this, State_Move.Instance);
	}

	// 공격 가능한 각도인지 체크
	// 내적값이 0.5보다 크면 정면
	public bool CheckAngle(){
		if (Vector3.Dot (target.transform.position, transform.position) < attackDir)
			return true;
		else
			return false;
	}
	// 공격 가능한 거리인지 체크
	public bool CheckDistance(){
		if (Vector3.Distance (target.transform.position, transform.position) < attackDistance)
			return true;
		else
			return false;
	}

	void OnTriggerEnter( Collider col ){

		// 손의 콜라이더에 닿았을 때
		if ( col.transform.tag == "HandCol" ){

			// 회피중이 아니라면 피격됬음을 알림
			// if( not avoid )
			target.applyDamage ();
		}

	}

	public override void applyDamage(){	}

	public override void getDamage(){ }

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
		HP -= target.Damage;
		print (this.name + " get damaged : " + HP);
		isHolding = false;
	}
}
