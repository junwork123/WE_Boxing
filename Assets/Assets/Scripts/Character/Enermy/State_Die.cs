using UnityEngine;
using System.Collections;

public class State_Die : State_FSM<Enermy>
{
	static readonly State_Die instance = new State_Die();
	public static State_Die Instance
	{
		get	{ return instance; }
	}
	float Count = 5f;
	float time = 0f;

	static State_Die() { }
	private State_Die() { }

	public override void EnterState(Enermy _Enermy)
	{
		_Enermy.mAnim.SetBool ("isDead", true);
	}

	public override void UpdateState(Enermy _Enermy)
	{
		time += Time.deltaTime;

		_Enermy.mAnim.SetBool ("isDead", true);
		_Enermy.mAnim.SetBool ("Left", false);
		_Enermy.mAnim.SetBool ("Right", false);
		_Enermy.mAnim.SetBool ("guard", false);

		if( _Enermy.isActiveAndEnabled && time >= Count)
		{
			_Enermy.gameObject.SetActive(false);
			time = 0f;
			UnityEngine.SceneManagement.SceneManager.LoadScene("Gameover",UnityEngine.SceneManagement.LoadSceneMode.Single);
		}
	}

	public override void ExitState(Enermy _Enermy)
	{

	}
}
