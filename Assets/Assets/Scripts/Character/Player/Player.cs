using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Player : Characters<Enermy>
{
	// 움직임 변수
	public float upDownRange = 30;

	float Count = 5f;
	float time = 0f;

	private float rotationX;
	private float rotationY;

	public Vector3 mDir;
	public bool isUnBeatTime = false;
	public IEnumerator mCorutine;
	public BoxCollider mMyoCol_L;
	public BoxCollider mMyoCol_R;

	public Transform tranformBody;
	public Transform tranformCam;

	// 델리게이트 
	public PlayerDelig mDelig;

	public void Start(){
		mAnim.SetInteger ("AttackMode", 1);
		this.gameObject.SetActive (true);

		mMyoCol_L.enabled = true;
		mMyoCol_R.enabled = true;
		//InputTracking.disablePositionalTracking = true;
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
					UnityEngine.SceneManagement.SceneManager.LoadScene("Gameover",UnityEngine.SceneManagement.LoadSceneMode.Single);
				}
			}
		}
	} 

	public override void Move(){
		// 카메라가 바라보는 방향으로
		// y축 기준 회전
		//tranformBody.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, tranformCam.transform.eulerAngles.y, 0.0f));

		mDir = InputTracking.GetLocalRotation (VRNode.CenterEye).eulerAngles;
		mDir.x = 0;
		mDir.z = 0;
		tranformBody.transform.rotation = Quaternion.Euler (mDir);

		//mDir = new Vector3 ( mAnim.GetFloat("moveLR"), 0, mAnim.GetFloat("moveFB") );
		mDir = InputTracking.GetLocalPosition (VRNode.CenterEye);
		mDir.y = 0;
		transform.Translate ( mDir * Time.smoothDeltaTime * moveSpeed );

		//InputTracking.Recenter ();
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