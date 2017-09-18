using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
	// Use this for initialization
	public Player player;
	public Enermy enermy;

	public Slider hpBar_P;
	public Slider hpBar_E;
	public Text timer;
	public int limitTime;
	private int remainTime;

	public void Awake(){
		remainTime = limitTime;
		timer.text = remainTime.ToString();

	}

	public void Update(){
		hpBar_P.value = (float)player.HP / (float)player.HPMax;
		hpBar_E.value = (float)enermy.HP / (float)enermy.HPMax;
	}

	public void StartTimer (){
		StartCoroutine (TimeAttack ());
	}

	IEnumerator TimeAttack(){
		while (true) {
			yield return new WaitForSeconds (1.0f);
			remainTime = remainTime - 1;
			timer.text = remainTime.ToString();
			if (player.HP <= 0 || enermy.HP <= 0)
				yield break;
			
			if (remainTime == 0) {
				UnityEngine.SceneManagement.SceneManager.LoadScene("Gameover",UnityEngine.SceneManagement.LoadSceneMode.Single);
				//Application.Quit ();
			}


		}
	}
}
