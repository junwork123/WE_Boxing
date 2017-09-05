using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Player : Characters<Enermy>
{
	// 움직임 변수

	float Count = 10f;
	float time = 0f;

	private float rotationX;
	private float rotationY;

	public Vector3 mDir;
	public bool isUnBeatTime = false;
	public IEnumerator mCorutine;

	public Transform tranformBody;
	public Transform tranformCam;
	public SkinnedMeshRenderer mRender;

	// 델리게이트 
	public PlayerDelig mDelig;

	public void Awake(){
		mAnim.SetInteger ("AttackMode", 1);

		mDir = InputTracking.GetLocalPosition (VRNode.CenterEye);
		mDelig._AttackHandler += mDelig.getDamage;


		mAnim.SetBool ("isDead", false);
		mAnim.SetBool ("Left", false);
		mAnim.SetBool ("Right", false);
		mAnim.SetBool ("guard", false);
		HP = 200;
	}

	void Update () 
	{ 
		if (this.HP > 0 && this.gameObject.activeSelf == true ) {
			MoveRot ();
			MovePos ();
			Attack ();
		} else {
			if (mAnim.GetBool ("isDead") == false) {
				mAnim.SetBool ("isDead", true);
				mAnim.SetBool ("Left", false);
				mAnim.SetBool ("Right", false);
				mAnim.SetBool ("guard", false);
				SoundManager.instance.BGMSound ("Lose");
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


	public void MoveRot(){
		// 카메라가 바라보는 방향으로
		// y축 기준 회전
		//tranformBody.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, tranformCam.transform.eulerAngles.y, 0.0f));

		Vector3 mDir = InputTracking.GetLocalRotation (VRNode.CenterEye).eulerAngles;
		mDir.x = 0;
		mDir.z = 0;
		tranformBody.transform.rotation = Quaternion.Euler (mDir);

	}

	public void MovePos(){

		// 캐릭터 몸체 이동
		mDir = InputTracking.GetLocalPosition (VRNode.CenterEye);
		mDir.y = 0;
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