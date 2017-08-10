using System.Collections;
using UnityEngine;


public class PlayerDelig : CharacterDelig
{
	Player _Player;

	public void Start(){
		obj = GameObject.Find ("Player");
		_Player = obj.GetComponent<Player> ();
	}

	public override void applyDamage(){
		print (_Player.name +" applied damage : " + _Player.Damage);
	}

	public override void getDamage(){
		print (_Player.name +" get damage");
	}
		
}

