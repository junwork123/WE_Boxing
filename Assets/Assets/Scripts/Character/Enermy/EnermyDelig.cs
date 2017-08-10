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

		if (_Enermy.isHolding == false) {

			_Enermy.isHolding = true;
			_Enermy.mCorutine = Holding ();
			StartCoroutine (_Enermy.mCorutine);
		}
	
	}

	// 코루틴 함수
	IEnumerator Holding(){

		float ratio1 = 0.2f;
		float ratio2 = 0.3f;
		float countTime = _Enermy.mAnim.GetCurrentAnimatorClipInfo(0).Length;

		// ratio1 비율까지 기다렸다가 파라미터 변경
		yield return new WaitForSeconds(countTime * ratio1);
		_Enermy.mAnim.SetBool ("Damaged", true);

		// ratio2비율까지 기다렸다가 HP감소, 메시지 출력, 홀딩 상태 변경
		yield return new WaitForSeconds(countTime * ratio2);
		_Enermy.HP -= _Enermy.target.Damage;
		_Enermy.isHolding = false;

		StopCoroutine (_Enermy.mCorutine);
	}
}


