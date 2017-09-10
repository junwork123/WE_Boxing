using System.Collections;
using UnityEngine;


public class PlayerDelig : CharacterDelig
{
	Player _Player;
	public ArduInput _LeftInput;
	public ArduInput _RightInput;

	public delegate void AttackHandler();
	public AttackHandler _AttackHandler;

	public void Start(){
		obj = GameObject.Find ("Player");
		_Player = obj.GetComponent<Player> ();

	}

	public override void applyDamage(){
		print (_Player.name +" applied damage : " + _Player.Damage);
	}

	public override void getDamage(){
		print (_Player.name +" get damage");

		_Player.HP -= _Player.target.Damage;

		if (_Player.HP > 1) {

			_Player.isUnBeatTime = true;
			// 플레이어 피격 모션 비활성화
			//_Player.mAnim.SetBool ("Damaged", true);
			_Player.mCorutine = UnBeatTime ();
			StartCoroutine (_Player.mCorutine);
			SoundManager.instance.PainSound ();
		}

	}
		
	// 코루틴 함수
	IEnumerator UnBeatTime(){

		/*
		int countTime = 0;
		while (countTime < 2) {

			if (countTime % 2 == 0)
				_Player.mRender.material.color = Color.blue;//new Color32 (255, 255, 255, 90);
			else
				_Player.mRender.material.color = Color.red;// (255, 255, 255, 180);

			yield return new WaitForSeconds (0.1f);

			countTime++;
		}*/

		_Player.mRender.material.color = Color.red;// (255, 255, 255, 180);
		yield return new WaitForSeconds (0.1f);

		Debug.Log ("player hunt");
		_LeftInput.shoot ();
		_RightInput.shoot ();

		_Player.mRender.material.color = new Color32 (255, 255, 255, 255);
		_Player.isUnBeatTime = false;
		_Player.mAnim.SetBool ("Damaged", false);

		yield return null;

	}
}

