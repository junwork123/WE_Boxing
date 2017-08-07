using UnityEngine;
using System.Collections;

public class HandCol_P : MonoBehaviour {

	public Player me;
	public Enermy opponent;
	public BoxCollider mHand;

	void Start () {
		mHand.enabled = false;
	}

	void OnTriggerEnter(Collider col)
	{
		//적과 부딪힐때만 충돌처리 일어나도록 처리
		if (col.tag == opponent.tag)
			me.applyDamage ();

	}
}
