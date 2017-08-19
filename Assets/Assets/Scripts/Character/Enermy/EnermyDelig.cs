using System.Collections;
using UnityEngine;


public class EnermyDelig : CharacterDelig
{
	public Enermy _Enermy;

	public void Start(){
		obj = GameObject.Find ("Enermy");
		_Enermy = obj.GetComponent<Enermy> ();
	}

	public override void applyDamage(){
		print (_Enermy.name +" applied damage : " + _Enermy.Damage);
	}
		
	public override void getDamage(){
		print (_Enermy.name +" get damage");

		// 뒤로 밀림
		//_Enermy.mRigidbody.AddForce (Vector3.back, ForceMode.Impulse);
		// HP 감소
		_Enermy.HP -= _Enermy.target.Damage;

		if (_Enermy.HP > 1) {

			_Enermy.isUnBeatTime = true;
			_Enermy.mAnim.SetBool ("Damaged", true);
			_Enermy.mCorutine = UnBeatTime ();
			StartCoroutine (_Enermy.mCorutine);
		}

	}

	// 코루틴 함수
	IEnumerator UnBeatTime(){

		/*
		int countTime = 0;
		while (countTime < 2) {

			if (countTime % 2 == 0)
				_Enermy.mRender.material.color = Color.blue;//new Color32 (255, 255, 255, 90);
			else
				_Enermy.mRender.material.color = Color.red;// (255, 255, 255, 180);

			yield return new WaitForSeconds (0.1f);

			countTime++;
		}*/

		_Enermy.mRender.material.color = Color.red;// (255, 255, 255, 180);
		yield return new WaitForSeconds (0.1f);

		_Enermy.mRender.material.color = new Color32 (255, 255, 255, 255);
		_Enermy.isUnBeatTime = false;
		_Enermy.mAnim.SetBool ("Damaged", false);
		yield return null;

	}
}


