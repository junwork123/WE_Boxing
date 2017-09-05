using UnityEngine;
using System.Collections;

public class HandCol_P : MonoBehaviour {

	public Player me;
	public Enermy opponent;
	public BoxCollider mHand;
	public ArduInput _Input;

	void Awake () {
		mHand.enabled = false;
	}

	void OnTriggerEnter(Collider col)
	{
		//적과 부딪힐때만 충돌처리 일어나도록 처리
		if (col.tag == opponent.tag && opponent.isUnBeatTime == false) {
			opponent.mDelig._AttackHandler ();
			SoundManager.instance.AttackSound ();
			_Input.punch ();
		}
	}

}
