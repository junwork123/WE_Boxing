using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioClip[] AttackCLIP;
	public AudioClip[] PainCLIP;
	public AudioClip[] BGMCLIP;
	AudioSource SOURCE;

	public static SoundManager instance;
	public static bool started;

	void Awake () {
		if (SoundManager.instance == null) 
		{
			SoundManager.instance = this;
		}
	}

	void Start()
	{
		SOURCE = GetComponent<AudioSource> ();
		started = false;
	}

	// Update is called once per fram
	public void AttackWindSound()
	{
		float SoundScale = 1f;
		if (started == true)
			SOURCE.PlayOneShot (AttackCLIP[0],SoundScale);
	}

	public void AttackSound()
	{
		int index = Random.Range(1,3);
		float SoundScale = 1f;
		if (started == true)
			SOURCE.PlayOneShot (AttackCLIP[index],SoundScale);
	}

	public void PainSound()
	{
		int index = Random.Range(0,2);
		float SoundScale = 1f;
		if (started == true)
			SOURCE.PlayOneShot (PainCLIP[index],SoundScale);
	}
	public void BGMSound(string name)
	{
		float SoundScale = 1f;
		int index = 2;
		switch (name) {
		case "Start":
			index = 0;
			break;

		case "End":
			index = 1;
			break;

		case "Noisy":
			index = 2;
			SoundScale = 0.5f;
			break;

		case "Laugh":
			index = 3;
			SoundScale = 0.5f;
			break;
		}
		if (started == true) 
			SOURCE.PlayOneShot (BGMCLIP [index], SoundScale);

	}
}
