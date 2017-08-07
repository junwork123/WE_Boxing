using UnityEngine;
using System.Collections;

public class State_Attack : State_FSM<Enermy>
{
	static readonly State_Attack instance = new State_Attack();
	public static State_Attack  Instance
	{
		get	{ return instance; }
	}

	static State_Attack() { }
	private State_Attack() { }

	public override void EnterState(Enermy _Enermy)
	{
		// 타겟 유무 확인
		if( _Enermy.target == null)
			return;
	}

	public override void UpdateState(Enermy _Enermy)
	{
		// 죽음 유무 확인
		if (_Enermy.HP <= 0)
		{
			_Enermy.ChangeState(State_Die.Instance);
		}

		// 타겟이 죽지 않은 상태에서, 사정거리 내에, 공격이 가능한 각도일 때
		if (!_Enermy.target.mAnim.GetBool("isDead") && _Enermy.CheckRange() && _Enermy.CheckAngle())
		{
				//float Damage = _Enermy.Damage;
				//_Enermy.MGR.SlimeAttack(Damage);

				_Enermy.ChaseTime = 0.0f;
		}
		else
		{
			_Enermy.ChangeState(State_Move.Instance);
		}
	}

	public override void ExitState(Enermy _Enermy)
	{

	}

}