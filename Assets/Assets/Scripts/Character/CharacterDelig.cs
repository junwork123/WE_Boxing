using System.Collections;
using UnityEngine;


public abstract class CharacterDelig : MonoBehaviour
{
	public GameObject obj;

	public abstract void applyDamage (); // 타격 시 작동되는 함수 
	public abstract void getDamage (); // 피격 시 작동되는 함수 
	//public abstract void setCallback(); // 콜백 등록 함수 
}


