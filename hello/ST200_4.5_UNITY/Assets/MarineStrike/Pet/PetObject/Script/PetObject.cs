using UnityEngine;
using System.Collections;

public class PetObject : MonoBehaviour {

	public enum PetState
	{
		Idle,
		Action,
		Dead
	}

	protected PetState m_State = PetState.Idle;

	private Transform m_ThisTransform ;
	public Transform ThisTransform
	{
		get { return m_ThisTransform ; }
	}

	public tk2dAnimatedSprite m_AnimatedSprite;

	public int m_Index = 0;
	public float m_BulletSpeed = 2f;

	//set datas from gamebalancedata
	public int m_PetType;
	public float m_BulletDamage = 5f;
	public float m_BulletDelay = 0.35f;
	public float m_EffectDuration = 2f;
	public float m_ItemDuration = 1.1f;
	public int[] m_ItemSpawnIndexes;
	public int[] m_ItemSpawnProbability;
	//set datas end

	public PetBulletObject m_BulletPrefabObject;
	protected bool m_Process = true;
	public Transform m_FollowPosition;
	public Submarine m_Submarine;
	protected bool m_DoNotAttackFlag = false;

	protected virtual void Awake()
	{
		m_ThisTransform = transform;
	}

	protected virtual void Start()
	{

	}

	protected virtual void FixedUpdate()
	{
		Process();
	}

	public virtual void Process()
	{
		if(m_Process)
		{
			if(m_FollowPosition != null)
			{
				m_ThisTransform.position = Vector3.Lerp(m_ThisTransform.position, m_FollowPosition.position, Time.deltaTime * 7f);
			}
		}
	}

	public virtual void Init(Submarine _submarine, Transform _follow)
	{
		m_Submarine = _submarine;
		m_FollowPosition = _follow;
	}

	public virtual void StartPet()
	{
		m_Process = true;
		m_State = PetState.Idle;
		StartCoroutine(m_State.ToString());
	}

	protected virtual IEnumerator Idle()
	{
		yield break;
	}

	protected virtual IEnumerator Action()
	{
		yield break;
	}

	protected virtual IEnumerator Dead()
	{
		yield break;
	}


	public void DoNotAttack()
	{
		m_DoNotAttackFlag = true;
		m_State = PetState.Idle;
		StopAllCoroutines();
		//Debug.Log(gameObject.name + " DO NOT ATTACK");
	}

	public void DoAttack()
	{
		m_DoNotAttackFlag = false;
		//Debug.Log(gameObject.name + " ATTACK");
		StartCoroutine(m_State.ToString());
	}

	protected virtual bool DoNotAttackFlag()
	{
		return m_DoNotAttackFlag;
	}
}
