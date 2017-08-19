using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters<Enermy>
{
	// 움직임 변수
	public float mouseSensitivity = 2f;
	public float upDownRange = 30;

	float Count = 5f;
	float time = 0f;

	private float rotationX;
	private float rotationY;

	public Vector3 mDir;
	public Camera mCamera;

	// 델리게이트 
	public PlayerDelig mDelig;

	public void Start(){
		mAnim.SetInteger ("AttackMode", 1);
		this.gameObject.SetActive (false);
	}

	void Update () 
	{ 
		if (this.HP > 0 && this.gameObject.activeSelf == true ) {
			Move ();
			Attack ();
		} else {
			if (mAnim.GetBool ("isDead") == false) {
				mAnim.SetBool ("isDead", true);
				mAnim.SetBool ("Left", false);
				mAnim.SetBool ("Right", false);
				mAnim.SetBool ("guard", false);
			}
			else {
				time += Time.deltaTime;

				if (isActiveAndEnabled && time >= Count) {
					this.gameObject.SetActive (false);
					time = 0f;
				}
			}
		}
	} 

	void OnTriggerEnter( Collider col ){

		if ( col.transform.tag == "HandCol" ){
			//mDelig.getDamage ();
		}

	}

	public override void Move(){

		mDir = new Vector3 ( mAnim.GetFloat("moveLR"), 0, mAnim.GetFloat("moveFB") );
		transform.Translate ( mDir * Time.smoothDeltaTime * moveSpeed );
	}

	public override void Attack(){

		int _AttackMode = mAnim.GetInteger ("AttackMode");
		bool _AttackLeft = mAnim.GetBool ("Left");
		bool _AttackRight = mAnim.GetBool ("Right");

		switch (_AttackMode) {

		case 1:
			Damage = hookDamage;
			break;
		case 2:
			Damage = japDamage;
			break;
		case 3:
			Damage = upperDamage;
			break;
		case 4:
			Damage = comboDamage;
			break;

		}

		if( _AttackLeft == true )
			mHand_L.enabled = true;
		else
			mHand_L.enabled = false;

		if( _AttackRight == true )
			mHand_R.enabled = true;
		else
			mHand_R.enabled = false;

	}
}