/* BloodRepeatScript.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodRepeatScript : MonoBehaviour {
    public GameObject prefab = null;
    GameObject target;

    private AudioSource hsAudio;
    public AudioClip Right_Hook;

    private AudioSource hsAudio2;
    public AudioClip Jab;

    // Use this for initialization
    void Start () {

        target = GameObject.FindGameObjectWithTag("Enermy");

        this.hsAudio = this.gameObject.AddComponent<AudioSource> ();
        this.hsAudio.clip = this.Right_Hook;
        this.hsAudio.loop = false;

        this.hsAudio2 = this.gameObject.AddComponent<AudioSource>();
        this.hsAudio2.clip = this.Jab;
        this.hsAudio2.loop = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
       
        if(Input.GetMouseButton(0))
        {

            Instantiate(prefab, target.transform);
            this.hsAudio.Play();
            this.enabled = false;

            if (Input.GetMouseButton(0))
                this.enabled = true;
        }
        if (Input.GetMouseButton(1))
        {
            Instantiate(prefab, target.transform);
            this.hsAudio2.Play();
            this.enabled = false;

            if (Input.GetMouseButton(1))
                this.enabled = true;
        }
        
        
    }
    void Move()
    {
        prefab.transform.rotation = Quaternion.Slerp(prefab.transform.rotation,
        Quaternion.LookRotation(target.transform.position - prefab.transform.position), 1);
    }
}
