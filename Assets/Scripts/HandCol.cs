using UnityEngine;
using System.Collections;

public class PlayerAttackScript : MonoBehaviour {

	//플레이어의 C# 스크립트 값을 저장하는 변수
	public Player player;

	// Use this for initialization
	void Start () {

		// 게임이 시작되면 플레이어 오브젝트에서 플레이어 스크립트 값을 가져옴
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
		// 플레이어의 무기 콜라이더 정보를 기록
		player.mHandCol = gameObject.GetComponent<BoxCollider>();
		// 플레이어의 무기 콜라이더를 꺼줌
		gameObject.GetComponent<BoxCollider>().enabled = false;
	}

	// 무기와 적이 부딪힐때 처리
	void OnTriggerEnter(Collider other)
	{
		//적과 부딪힐때만 충돌처리 일어나도록 처리
		if (other.tag == "Enemy")
		{
			// 적을 뒤로 밀려나게 하기 위한 방향벡터 생성
			Vector3 _Vec = (other.transform.position - transform.position).normalized;
			_Vec.y=0; // y축 이동 생기지 않도록 리셋
			other.transform.localPosition += _Vec * 0.5f; // 밀려나는 값 
			other.SendMessage("applyDamage",Player.Power); // 충돌체의 데미지 구문 호출
		}

	}
}
