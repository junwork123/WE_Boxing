/* BloodRepeatScript.cs */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodRepeatScript : MonoBehaviour {
	
	public GameObject prefab = null;
	public float time = 0.5f;

	// Use this for initialization
	void Start () {
		Player.OnPlayerAttack += this.OnPlayerAttack;
	}

	void OnPlayerAttack(){
			GameObject w = Instantiate(prefab, transform);
			Destroy(w, time);
	}
}