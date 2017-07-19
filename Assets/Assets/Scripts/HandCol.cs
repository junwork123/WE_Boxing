using UnityEngine;
using System.Collections;

public class HandCol : MonoBehaviour {
	
	public Player player;

	void Start () {
		player = GetComponent<Player> ();
	}

	void OnTriggerEnter(Collider col)
	{
		//적과 부딪힐때만 충돌처리 일어나도록 처리
		if (col.tag == "Enemy")
		{
			player.applyDamage (Player.Power);

		}

	}
}
