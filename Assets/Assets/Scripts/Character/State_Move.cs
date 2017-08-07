using UnityEngine;
using System;
using System.Collections;

public class State_Move : State_FSM<Enermy>
{
	static readonly State_Move instance = new State_Move();
	public static State_Move   Instance
	{
		get	{ return instance; }
	}

	private float ResetTime = 3f;
	private float CurrenntTime;
	IEnumerator mCorutine;


	static State_Move() { }
	private State_Move() { }

	public override void EnterState(Enermy _Enermy)
	{
		CurrenntTime = ResetTime;
	}

	public override void UpdateState(Enermy _Enermy)
	{
		// 죽음 유무 확인
		if (_Enermy.HP <= 0)
		{
			_Enermy.ChangeState(State_Die.Instance);
		}

		// 타겟 유무 확인
		if(_Enermy.target != null)
		{
			// 공격범위 안에 없다면 
			if(!_Enermy.CheckRange())
			{

				// 상대 바라보기
				_Enermy.transform.rotation = Quaternion.Slerp (_Enermy.transform.rotation, 
					Quaternion.LookRotation (_Enermy.target.transform.position - _Enermy.transform.position), 1);

				Tracking (_Enermy);
			}
			else
			{
				_Enermy.ChangeState(State_Attack.Instance);
			}

		}
		else
		{
			// 방향 재설정
			//SetRandDir(_Enermy);
			/*
			Vector3 pos = _Enermy.transform.position;
			pos += _Enermy.transform.forward * Time.smoothDeltaTime * (_Enermy.moveSpeed / 3f);
			_Enermy.transform.position = pos;*/
		}
		//_Enermy.Ani.CrossFade("Walk");
	}

	public override void ExitState(Enermy _Enermy)
	{
		//Debug.Log("State_Move를 종료합니다.");
	}

	// ResetTime 때 마다 임의의 방향으로 설정
	void SetRandDir(Enermy _Enermy)
	{
		CurrenntTime += Time.smoothDeltaTime;
		if (CurrenntTime >= ResetTime)
		{
			// 방향 재설정
			_Enermy.transform.forward = Quaternion.AngleAxis(UnityEngine.Random.Range(-60.0f, 60.0f), Vector3.up) * Vector3.forward;
			// 시간 재설정
			ResetTime = UnityEngine.Random.Range(1f, 3f);
			CurrenntTime = 0f;
		}
	}

	void Tracking(Enermy _Enermy){

		// 타겟과 거리가 멀다면 다가간다
		if (_Enermy.mNav.remainingDistance > 3.0f) {
			_Enermy.mDir = Vector3.forward;
			_Enermy.mNav.SetDestination (_Enermy.target.transform.position);
		}
		// 타겟과 너무 가깝지 않게 일정 거리를 유지한다
		else if (_Enermy.mNav.remainingDistance <= _Enermy.mNav.stoppingDistance) {
			_Enermy.mDir = Vector3.back;
			//_Enermy.mNav.Stop ();
		}
		// 적정 거리라면 랜덤하게 움직인다
		else {
			/*
			mDir = mDirArray[Random.Range(0, mDirArray.Length)];
			if (_Enermy.mDir.Equals (Vector3.left))
				_Enermy.mDir = Vector3.right;
			else
				_Enermy.mDir = Vector3.left;
				*/
			_Enermy.mNav.SetDestination (_Enermy.target.transform.position);
		}
		_Enermy.transform.Translate (_Enermy.mDir * Time.smoothDeltaTime * _Enermy.moveSpeed);
		//yield return new WaitForSeconds(1.0f);


	}
	/*
	public override void Move(){
		// 플레이어 쪽으로 방향 회전
		StartCoroutine (Tracking());
	}*/
}
