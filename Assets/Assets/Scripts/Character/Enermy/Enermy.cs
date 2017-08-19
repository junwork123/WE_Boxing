using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : Characters<Player>
{
	
	StateMachine<Enermy> mState;
	public IEnumerator mCorutine;
	public Vector3 mDir;
	public UnityEngine.AI.NavMeshAgent mNav;
	public EnermyDelig mDelig;
	public SkinnedMeshRenderer mRender;

	public float attackDistance = 1.1f;
	public float attackDir = 0.5f;
	public bool isUnBeatTime = false;

	// Use this for initialization
	public void Start () {
		// Player 델리게이트에
		// Enermy 피격 함수를 등록
		PlayerDelig.OnAttack += mDelig.getDamage;
	
		ResetState ();
		//mCorutine = Holding ();		
		mNav.SetDestination (target.transform.position);
		this.gameObject.SetActive (false);

	}

	void Update () 
	{ 
		if( this.gameObject.activeSelf == true )
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
	// 내적값이 0.5보다 작으면 정면
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
			//mDelig.getDamage ();
		}

	}

}
