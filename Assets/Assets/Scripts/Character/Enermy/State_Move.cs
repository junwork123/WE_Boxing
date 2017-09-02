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

	static State_Move() { }
	private State_Move() { }

	public override void EnterState(Enermy _Enermy)
	{
		Debug.Log("State_Move");
	}

	public override void UpdateState(Enermy _Enermy)
	{
		// 죽음 유무 확인
		if (_Enermy.HP <= 0)
		{
			_Enermy.ChangeState(State_Die.Instance);
			SoundManager.instance.BGMSound("End");
		}

		// 타겟 유무 확인
		if(_Enermy.target != null)
		{
			// 공격거리, 각도 안에 있다면 
			if(_Enermy.CheckDistance() && _Enermy.CheckAngle() )
			{
				//Debug.Log("ENERMY BEING ATTACK");
				_Enermy.ChangeState(State_Attack.Instance);
			}
			else
			{
				// 상대 바라보기
				_Enermy.transform.rotation = Quaternion.Slerp (_Enermy.transform.rotation, 
					Quaternion.LookRotation (_Enermy.target.transform.position - _Enermy.transform.position), 1);

				// 상대에게 다가가기
				_Enermy.mNav.SetDestination (_Enermy.target.transform.position);
				//Debug.Log("APPROCHING ENERMY");
				//_Enermy.transform.Translate (_Enermy.mDir * Time.smoothDeltaTime * _Enermy.moveSpeed);

			}

		}

	}

	public override void ExitState(Enermy _Enermy)
	{
		//Debug.Log("State_Move를 종료합니다.");
	}

}
