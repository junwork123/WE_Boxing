using UnityEngine;

public class Characters<T> : MonoBehaviour, ICharacters
{
	public float moveSpeed = 5f;
	public float hookDamage = 5;
	public float japDamage = 5;
	public float upperDamage = 5;
	public float comboDamage = 5;

	public float Damage = 1;
	public float HP = 100;

	public Animator mAnim; 	// 애니메이션
	public Rigidbody mRigidbody;
	public BoxCollider []mHands;
	public BoxCollider mHand_L;
	public BoxCollider mHand_R;

	public T target;

	public virtual void Start(){}
	public virtual void applyDamage(){}
	public virtual void getDamage(){}
	public virtual void Attack(){}
	public virtual void Move(){}
	public virtual void Init(){}

}


