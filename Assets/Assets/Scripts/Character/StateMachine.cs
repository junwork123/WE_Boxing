using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine <T>
{
	private T Owner;
	private State_FSM<T> CurrentState;
	private State_FSM<T> PreviousState;

	// 변수 초기화
	public void Awake()
	{
		CurrentState = null;
		PreviousState = null;
	}

	// 상태 변경
	public void ChangeState(State_FSM<T> _NewState)
	{
		// 같은 상태일 경우 종료
		if(_NewState == CurrentState)
			return;

		PreviousState = CurrentState;

		// 현재 상태를 있다면 빠져나옴
		if( CurrentState != null)
			CurrentState.ExitState(Owner);


		CurrentState = _NewState;

		// 새로 적용된 상태가 null이 아니면 실행
		if( CurrentState != null)
			CurrentState.EnterState(Owner);

	}

	// 초기상태설정
	public void Initial_Setting(T _Owner, State_FSM<T> _InitialState)
	{
		Owner = _Owner;
		ChangeState(_InitialState);
	}

	// 상태 업데이트
	public void Update ()
	{
		if(CurrentState != null)
			CurrentState.UpdateState(Owner);
	}

	// 이전 상태로 되돌림
	public void StateRevert()
	{
		if(PreviousState != null)
			ChangeState(PreviousState);
	}
}
