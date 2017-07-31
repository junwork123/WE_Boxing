using UnityEngine;

public class Characters : MonoBehaviour, ICharacters
{
	public float moveSpeed = 5f;
	public float hookDamage = 5;
	public float japDamage = 5;
	public float upperDamage = 5;
	public float comboDamage = 5;

	public static float Power = 1;
	public static float HP = 100;

	public Animator mAnim; 	// 애니메이션
	public Rigidbody mRigidbody;
	public BoxCollider []mHands;
	public BoxCollider mHand_L;
	public BoxCollider mHand_R;

	public GameObject target;

	public virtual void Start(){}
	public virtual void applyDamage(float Damage){}
	public virtual void getDamage(float Damage){}
	public virtual void Attack(){}
	public virtual void Move(){}
	public virtual void Init(){}

}


