using UnityEngine;
using System.Collections;

public class HandCol : MonoBehaviour {
	
	public Characters opponent;

	void Start () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		//적과 부딪힐때만 충돌처리 일어나도록 처리
		if (col.tag == opponent.tag)
		{
			if ( opponent is Player )
				opponent.applyDamage (Player.Power);

			else if ( opponent is Enermy )
				opponent.applyDamage (Enermy.Power);
		}

	}
}
