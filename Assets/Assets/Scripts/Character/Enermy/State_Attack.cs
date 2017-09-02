using UnityEngine;
using System.Collections;

public class State_Attack : State_FSM<Enermy>
{
	static readonly State_Attack instance = new State_Attack();
	public static State_Attack  Instance
	{
		get	{ return instance; }
	}

	public float AttackTime = 3.0f;
	public float MoveTime = 3.0f;
	public bool isAttack = false;
	float CurrenntTime = 0.0f;

	static State_Attack() { }
	private State_Attack() { }

	public override void EnterState(Enermy _Enermy)
	{
		Debug.Log("State_Attack");
		// 타겟 유무 확인
		if( _Enermy.target == null)
			return;
		if (_Enermy.mNav.remainingDistance > _Enermy.attackDistance) 
			_Enermy.ChangeState(State_Move.Instance);
	}

	public override void UpdateState(Enermy _Enermy)
	{
		// 죽음 유무 확인
		if (_Enermy.HP <= 0)
		{
			_Enermy.ChangeState(State_Die.Instance);
			SoundManager.instance.BGMSound("End");
		}
		if ( CurrenntTime > AttackTime )
			_Enermy.ChangeState(State_Move.Instance);
		/*
		if (isAttack == true) {
			_Enermy.ChangeState (State_Move.Instance);
			_Enermy.mAnim.SetBool ("guard", true);
			_Enermy.mAnim.SetBool ("Left", false);
			_Enermy.mAnim.SetBool ("Right", false);
		}
		// 타겟이 죽지 않은 상태에서, 사정거리 내에, 공격이 가능한 각도일 때
		if (!_Enermy.target.mAnim.GetBool("isDead") && _Enermy.CheckDistance() &&_Enermy.CheckAngle())
		{
			_Enermy.mAnim.SetBool ("guard", false);
			_Enermy.mAnim.SetInteger ("AttackMode", Random.Range (2, 2));
			_Enermy.mAnim.SetBool ("Left", Random.Range (0, 1) == 0 ? true : false);
			_Enermy.mAnim.SetBool ("Right", !_Enermy.mAnim.GetBool ("Left"));
			isAttack = true;
			//_Enermy.ChangeState (State_Move.Instance);
		}*/

		else
		{
			_Enermy.ChangeState(State_Move.Instance);
		}
	}

	public override void ExitState(Enermy _Enermy)
	{

	}
	/*
	void Tracking(Enermy _Enermy){
		
		// 적정 거리라면 랜덤하게 움직인다
		else {

			if (CurrenntTime > MoveTime) {
				_Enermy.mDir = Vector3.right;
			}
			else
				_Enermy.mDir = Vector3.left;

			_Enermy.mNav.SetDestination (_Enermy.target.transform.position);
		}
		_Enermy.transform.Translate (_Enermy.mDir * Time.smoothDeltaTime * _Enermy.moveSpeed);
		//yield return new WaitForSeconds(1.0f);


	}*/

}