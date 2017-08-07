using System;


abstract public class State_FSM<T>
{
	abstract public void EnterState(T enermy);

	abstract public void UpdateState(T enermy);

	abstract public void ExitState(T enermy);

}


