/* BloodRepeatScript.cs */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodRepeatScript : MonoBehaviour {
	
	public GameObject prefab = null;
	public float time = 0.5f;

	Vector3 mPos;

	// Use this for initialization
	void Start () {
		PlayerDelig.OnAttack += this.OnPlayerAttack;
		mPos = transform.localPosition;
		mPos.y = 2.5f;

	}

	void OnPlayerAttack(){
		GameObject w = Instantiate(prefab, mPos, Quaternion.identity);
		Destroy(w, time);
	}
}