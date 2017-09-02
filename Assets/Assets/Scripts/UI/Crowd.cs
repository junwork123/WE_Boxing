using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd : MonoBehaviour {

	public int index;
	float playTime;
	bool isPlaying;

	public void Start(){
		playTime = Random.Range (2, 8);
		StartCoroutine (playSound ());
		isPlaying = false;
	}

	public void Update(){
		if ( !isPlaying ) {
			if (index == 2)
				SoundManager.instance.BGMSound ("Noisy");
			else if (index == 3)
				SoundManager.instance.BGMSound ("Laugh");

			isPlaying = true;
		}
	}

	IEnumerator playSound(){
		
		while (true) {
			Debug.Log ("play");

			yield return new WaitForSeconds (playTime);
			playTime = Random.Range (5, 8);
			isPlaying = false;
		}
	}
}
