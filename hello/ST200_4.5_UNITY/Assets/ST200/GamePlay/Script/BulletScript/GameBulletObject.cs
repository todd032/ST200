using UnityEngine;
using System.Collections;

public class GameBulletObject : MonoBehaviour {

	public GamePlayBulletType m_Type;
	public Vector3 m_MoveSpeed;
	public float m_Damage;
	public float m_PushForce;
	public tk2dSprite m_BulletSprite;
	public float m_RemainTimer;
	//public float 

	public virtual void Init(Vector3 _worldpos, float _damage, Vector3 _movespeed, float _pushforce, float _sizeratio)
	{
		Vector3 newpos = _worldpos;
		newpos.z = Constant.ST200_GameObjectLayer_FX;
		transform.position = newpos;

		m_Damage = _damage;
		m_MoveSpeed = _movespeed;
		m_PushForce = _pushforce;
		m_BulletSprite.scale = Vector3.one * _sizeratio;
		processedtimer = 0f;
		transform.up = m_MoveSpeed.normalized;
	}

	protected float processedtimer = 0f;
	public virtual void Process(float _timer)
	{
		transform.position += m_MoveSpeed * _timer;

		processedtimer += _timer;
		if(processedtimer > m_RemainTimer)
		{
			OnBorderHit();
		}
	}

	public delegate void BulletGoneDelegate(GameBulletObject _bullet);
	protected BulletGoneDelegate m_BulletGoneDelegate;
	public event BulletGoneDelegate BulletGoneEvent
	{
		add
		{
			m_BulletGoneDelegate += value;
		}
		remove
		{
			m_BulletGoneDelegate -= value;
		}
	}

	public virtual void OnBorderHit()
	{
		if(m_BulletGoneDelegate != null)
		{
			m_BulletGoneDelegate(this);
		}
	}

	protected virtual void OnTriggerEnter2D(Collider2D _col)
	{

	}
}
