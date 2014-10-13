using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSubShip : MonoBehaviour {
	
	public GamePlayerSubShipType m_ShipType;

	protected List<Transform> m_TargetList = new List<Transform>();

	public PlayerShip m_PlayerShip;
	public List<GameShipBuff> m_BuffList = new List<GameShipBuff>();

	public GameStageEnemyHealthDisplayer m_HealthGauge;
	public GameStageEnemyHealthDisplayer m_SpecialGauge;
	public SubShipStatInfo m_StatInfo;
	public ShipAnimation m_ShipAnimation;
	public Vector3 m_LookingVector;
	public List<Transform> m_ShootTransform = new List<Transform>();
	
	/// <summary>
	/// 0 - forward
	/// 1 - left
	/// 2 - right
	/// </summary>
	public int m_ShootType;
	public Vector3 m_ShootPosition;
	public Vector3 m_ShootDirection;
	
	public float m_CurHealth;
	public float m_MaxHealth = 100f;
	
	public float SpecialValue1
	{
		get
		{
			float val = m_StatInfo.SpecialEffectValue;
			
			for(int i = 0; i < m_BuffList.Count; i++)
			{
				if(m_BuffList[i].BuffType == GameShipBuffType.ATTACK_DAMAGE_BUFF)
				{
					val *= m_BuffList[i].Value2;
				}
			}
			return val;
		}
	}
	
	public float GaugeSpeed
	{
		get
		{
			float val = m_StatInfo.SpecialGaugeSpeed;
			
			for(int i = 0; i < m_BuffList.Count; i++)
			{
				if(m_BuffList[i].BuffType == GameShipBuffType.ATTACK_SPEED_BUFF)
				{
					val *= m_BuffList[i].Value2;
				}
			}
			return val;
		}
	}

	public float m_AttackTimer = 0f;
	
	public float m_LeftBorder = -1f;
	public float m_RightBorder = 1f;
	
	public Vector3 m_HeadDirection = Vector3.up;
	
	//[HideInInspector]
	protected float m_MoveResist = 0.9f;
	public Vector3 m_MoveSpeed;
	public float MaxMoveSpeed
	{
		get
		{
			float val = m_StatInfo.MaxMoveSpeed;
			
			//for(int i = 0; i < m_BuffList.Count; i++)
			//{
			//	if(m_BuffList[i].BuffType == GameShipBuffType.ATTACK_SPEED_BUFF)
			//	{
			//		val *= m_BuffList[i].Value2;
			//	}
			//}
			return val;
		}
	}
	public float MaxMoveForce
	{
		get
		{
			float val = m_StatInfo.MoveForce;
			
			//for(int i = 0; i < m_BuffList.Count; i++)
			//{
			//	if(m_BuffList[i].BuffType == GameShipBuffType.ATTACK_SPEED_BUFF)
			//	{
			//		val *= m_BuffList[i].Value2;
			//	}
			//}
			return val;
		}
	}
	public Vector3 m_OuterForce;
	
	public float m_RotationInertia;//??need it??
	protected float m_RotationResist = 0.97f;
	/// <summary>
	/// this means the angle looking
	/// </summary>
	public float m_RotationAngle = 0f;
	public float m_RotationSpeed;
	public float RotationMaxSpeed
	{
		get
		{
			float val = m_StatInfo.MaxRotationSpeed;
			
			//for(int i = 0; i < m_BuffList.Count; i++)
			//{
			//	if(m_BuffList[i].BuffType == GameShipBuffType.ATTACK_SPEED_BUFF)
			//	{
			//		val *= m_BuffList[i].Value2;
			//	}
			//}
			return val;
		}
	}
	public float m_RotationOuterForce;

	protected int m_EquipIndex;
	public int TeamIndex = 0;
	public virtual void Init(SubShipStatInfo _info, int _equipindex, int _teamindex, PlayerShip _playership)
	{
		m_StatInfo = _info;
		TeamIndex = _teamindex;
		m_MaxHealth = m_StatInfo.Health;
		m_CurHealth = m_MaxHealth;
		m_PlayerShip = _playership;

		m_EquipIndex = _equipindex;

		Transform targettransform = m_PlayerShip.m_SubShipFollowList[m_EquipIndex - 1];
		transform.position = targettransform.position;
	}

	public virtual void AddBuff(GameShipBuff _buff)
	{
		m_BuffList.Add(_buff);
	}

	public virtual void Process(float _timer)
	{
		if(m_CurHealth > 0f)
		{
			ProcessBuff(_timer);
			ProcessAI(_timer);
			ProcessAttack(_timer);
			ProcessMovement(_timer);
		}else
		{

		}
	}

	public virtual void ProcessAI(float _timer)
	{
		//try follow playership
		if(Vector2.Distance(m_PlayerShip.transform.position, transform.position) > 5f)
		{
			m_HeadDirection = (m_PlayerShip.transform.position - transform.position).normalized;
		}else
		{
			m_HeadDirection = m_PlayerShip.m_LookingVector;
		}
	}

	public virtual void ProcessBuff(float _timer)
	{
		for(int i = 0 ; i < m_BuffList.Count;)
		{
			m_BuffList[i].Process(_timer);
			if(m_BuffList[i].IsDone())
			{
				m_BuffList.Remove(m_BuffList[i]);
			}else
			{
				i++;
			}
		}
	}

	public virtual void ProcessAttack(float _timer)
	{
		if(m_AttackTimer > m_StatInfo.SpecialGaugeMax)
		{
			Shoot();
		}else
		{
			m_AttackTimer += _timer * GaugeSpeed;
		}
		m_HealthGauge.UpdateHealth(m_CurHealth, m_StatInfo.Health);
		m_SpecialGauge.UpdateHealth(m_AttackTimer, m_StatInfo.SpecialGaugeMax);
	}

	bool m_Colllided = false;
	protected bool m_IsUsingTactic = false;
	public void SetUseTactic(bool _flag)
	{
		m_IsUsingTactic = _flag;
	}

	public virtual void ProcessMovement(float _timer)
	{
		if(m_IsUsingTactic)
		{
			Transform targettransform = m_PlayerShip.m_SubShipFollowList[m_EquipIndex - 1];
			Vector3 deltapos = targettransform.position - transform.position;
			Vector3 playershipdelta = targettransform.position - m_PlayerShip.transform.position;
			deltapos.z = 0f;
			if(m_Colllided)
			{
				m_MoveSpeed = deltapos.normalized;
				transform.up = Vector3.Lerp(transform.up, deltapos, 0.1f);
			}else
			{
				float distance = Vector2.Distance(transform.position, targettransform.position);
				if(distance < 0.1f)
				{
					m_MoveSpeed = m_PlayerShip.m_MoveSpeed;
					transform.up = Vector3.Lerp(transform.up, m_PlayerShip.m_LookingVector, 0.1f);
					//transform.position = targettransform.position;
					//transform.up = deltapos;
				}else if(distance < m_PlayerShip.m_MoveSpeed.magnitude)
				{
					m_MoveSpeed = deltapos.normalized + m_PlayerShip.m_MoveSpeed;
					transform.up = Vector3.Lerp(transform.up, m_PlayerShip.m_LookingVector, 0.1f);
					//transform.position = targettransform.position;
				}else
				{
					m_MoveSpeed = deltapos + m_PlayerShip.m_MoveSpeed;
					transform.up = Vector3.Lerp(transform.up, deltapos, 0.05f);
				}
			}		
			
			Vector3 targetdirection = Vector3.Cross(m_LookingVector, m_HeadDirection.normalized);//m_TargetTransform.position - transform.position;
			//targetdirection.z = 0f;
			
			Vector3 lookingdirection = m_LookingVector;
			Vector3 curmovespeed = m_MoveSpeed;
			float maxmovespeed = MaxMoveSpeed;
			float maxmoveforce = MaxMoveForce;
			
			float nextrotationspeed = 0f;
			if(targetdirection.z > 0f)
			{
				m_RotationSpeed = RotationMaxSpeed;
			}else if(targetdirection.z < 0f)
			{
				m_RotationSpeed = -RotationMaxSpeed;
			}else
			{
				m_RotationSpeed *= m_RotationResist;
			}
			float currotationspeed = m_RotationSpeed;
			float maxrotationspeed = RotationMaxSpeed;

			curmovespeed.z = 0f;
			transform.position += (curmovespeed + m_OuterForce) * _timer;
			
			m_OuterForce *= m_MoveResist;
			m_RotationOuterForce *= m_RotationResist;

			m_LookingVector = m_ShipAnimation.transform.up;
			m_Colllided = false;
		}else
		{			
			Vector3 targetdirection = Vector3.Cross(m_LookingVector, m_HeadDirection.normalized);//m_TargetTransform.position - transform.position;
			//targetdirection.z = 0f;
			
			Vector3 lookingdirection = m_LookingVector;
			Vector3 curmovespeed = m_MoveSpeed;
			float maxmovespeed = MaxMoveSpeed;
			float maxmoveforce = MaxMoveForce;
			
			float nextrotationspeed = 0f;
			if(targetdirection.z > 0f)
			{
				m_RotationSpeed = RotationMaxSpeed;
			}else if(targetdirection.z < 0f)
			{
				m_RotationSpeed = -RotationMaxSpeed;
			}else
			{
				m_RotationSpeed *= m_RotationResist;
			}
			float currotationspeed = m_RotationSpeed;
			
			float maxrotationspeed = RotationMaxSpeed;
			float currotation = m_RotationAngle;
			float targetrotation = Vector3.Angle(lookingdirection, targetdirection);
			if(targetdirection == Vector3.zero)
			{
				targetrotation = 0f;
			}
			
			//Debug.Log("CROSS: " + Vector3.Cross(lookingdirection, targetdirection).z);
			if(Vector3.Cross(lookingdirection, targetdirection).z < 0f)
			{
				targetrotation = -targetrotation;
			}
			
			currotation += (currotationspeed + m_RotationOuterForce) * _timer;
			if(currotation < -180f)
			{
				currotation = 360f + currotation;
			}else if(currotation > 180f)
			{
				currotation = -360f + currotation;
			}
			
			//change speed to looking direction
			
			curmovespeed = lookingdirection.normalized * Vector3.Dot(curmovespeed, lookingdirection);
			curmovespeed += lookingdirection *  maxmoveforce * _timer;
			if(curmovespeed.magnitude > maxmovespeed)
			{
				curmovespeed *= m_MoveResist;
			}
			curmovespeed.z = 0f;
			//set transform variables
			transform.position += (curmovespeed + m_OuterForce) * _timer;
			transform.eulerAngles = new Vector3(0f, 0f, currotation);
			
			m_OuterForce *= m_MoveResist;
			m_RotationOuterForce *= m_RotationResist;
			
			//set variables
			m_MoveSpeed = curmovespeed;
			//m_RotationSpeed = currotationspeed;
			m_RotationAngle = currotation;
			m_LookingVector = m_ShipAnimation.transform.up;
		}
	}
	
	public virtual void AddHitForce (Vector3 _hitpos, Vector3 _force)
	{
		Vector3 lookingdirection = m_LookingVector;
		Vector3 movingspeed = m_MoveSpeed;
		Vector3 relativeforce = _force - movingspeed;
		relativeforce.z = 0f;

		Vector3 forcedirection = (transform.position - _hitpos);
		forcedirection.z = 0f;
		forcedirection.Normalize();

		Vector3 totalforce = forcedirection * Mathf.Abs(Vector3.Dot(forcedirection, relativeforce));
		totalforce.z = 0f;
		//Debug.Log("TOTAL FORCE: " + totalforce + " FORCE DIRECTION : " + forcedirection);
		
		m_OuterForce += totalforce;// moveforce;
		//m_RotationOuterForce += rotationforce;
	}
	
	public delegate void ShootBulletDelegate(PlayerSubShip _player);
	protected ShootBulletDelegate m_ShootDelegate;
	public event ShootBulletDelegate ShootEvent
	{
		add
		{
			m_ShootDelegate += value;
		}
		remove
		{
			m_ShootDelegate -= value;
		}
	}
	
	public virtual void Shoot()
	{
		
	}
	
	public virtual void StayIdle()
	{
		m_ShipAnimation.PlayIdleAnimation();
	}
	
	public delegate void DamagedDelegate(PlayerSubShip _player, float _damage);
	protected DamagedDelegate m_DamagedDelegate;
	public event DamagedDelegate DamagedEvent
	{
		add	
		{
			m_DamagedDelegate += value;
		}
		remove
		{
			m_DamagedDelegate -= value;
		}
	}
	public virtual void DoDamage(float _damage)
	{
		if(m_CurHealth > 0f)
		{
			m_CurHealth -= _damage;
			GamePlayFXManager.Instance.StartFontFX(Color.red, transform.position,"-" + ((int)_damage).ToString());
			//Debug.Log(m_CurHealth);
			if(m_CurHealth <= 0f)
			{
				PlayDeadAnimation();
			}
		}

		if(m_DamagedDelegate != null)
		{
			m_DamagedDelegate(this, _damage);
		}
	}
	
	public virtual void PlayDeadAnimation()
	{
		StartCoroutine(IEPlayDeadAnimation());
	}

	protected virtual IEnumerator IEPlayDeadAnimation()
	{
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion1, transform.position);
		m_ShipAnimation.PlayDeadAnimation();

		yield return new WaitForSeconds(1f);
		transform.gameObject.SetActive(false);

		yield break;
	}

	public virtual void CrashEnemyShip(GameStageEnemyObject _enemy)
	{
		_enemy.AddHitForce(transform.position, m_LookingVector * Mathf.Min(m_MoveSpeed.magnitude / m_StatInfo.MaxMoveSpeed, 1f) * m_StatInfo.PushForce);
		_enemy.DoDamage(m_StatInfo.PushDamage);
	}
	
	public virtual void DragEnemyShip(GameStageEnemyObject _enemy)
	{
		_enemy.AddHitForce(transform.position, (_enemy.transform.position - transform.position).normalized );
	}

	public virtual void CrashPlayerSubShip(PlayerSubShip _ship)
	{
		_ship.AddHitForce(transform.position, m_MoveSpeed.normalized * Mathf.Min(m_MoveSpeed.magnitude / m_StatInfo.MaxMoveSpeed, 1f) * m_StatInfo.PushForce);
	}
	
	public virtual void DragPlayerSubShip(PlayerSubShip _ship)
	{
		_ship.AddHitForce(transform.position, (_ship.transform.position - transform.position).normalized );
	}

	public virtual void CrashPlayerShip(PlayerShip _ship)
	{
		//_ship.AddHitForce(transform.position, m_LookingVector * Mathf.Min(m_MoveSpeed.magnitude / m_StatInfo.MaxMoveSpeed, 1f) * m_StatInfo.PushForce);
	}
	
	public virtual void DragPlayerShip(PlayerShip _ship)
	{
		//_ship.AddHitForce(transform.position, (_ship.transform.position - transform.position).normalized );
	}

	protected virtual void OnTriggerEnter2D(Collider2D _col)
	{
		if(_col != null)
		{
			if(_col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			{
				m_Colllided = true;
				GameStageEnemyObject enemy = _col.gameObject.GetComponent<GameStageEnemyObject>();
				CrashEnemyShip(enemy);
			}else if(_col.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
			{
				m_Colllided = true;
				AddCrashForce(_col.transform.position);
			}
			else if(_col.gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				m_Colllided = true;
				PlayerShip player = _col.gameObject.GetComponent<PlayerShip>();
				CrashPlayerShip(player);
			}else if(_col.gameObject.layer == LayerMask.NameToLayer("Player_Sub"))
			{
				m_Colllided = true;
				PlayerSubShip sub = _col.gameObject.GetComponent<PlayerSubShip>();
				CrashPlayerSubShip(sub);
			}
		}
	}
	
	protected virtual void OnTriggerStay2D(Collider2D _col)
	{
		if(_col != null)
		{
			if(_col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			{
				m_Colllided = true;
				GameStageEnemyObject enemy = _col.gameObject.GetComponent<GameStageEnemyObject>();
				DragEnemyShip(enemy);
			}else if(_col.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
			{
				m_Colllided = true;
				AddCrashForce(_col.transform.position);
			}
			else if(_col.gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				m_Colllided = true;
				PlayerShip player = _col.gameObject.GetComponent<PlayerShip>();
				DragPlayerShip(player);
			}
			else if(_col.gameObject.layer == LayerMask.NameToLayer("Player_Sub"))
			{
				m_Colllided = true;
				PlayerSubShip sub = _col.gameObject.GetComponent<PlayerSubShip>();
				DragPlayerSubShip(sub);
			}
		}
	}
	
	/// <summary>
	/// hit with obstacles
	/// </summary>
	public virtual void AddCrashForce(Vector3 _opponentpos)
	{
		Vector3 myvelocity = m_MoveSpeed;
		Vector3 relativevelocity = -myvelocity;
		Vector3 hitvector = (transform.position - _opponentpos);
		hitvector.z = 0f;
		hitvector.Normalize();

		Vector3 force = hitvector * Mathf.Max (Vector3.Dot(hitvector, relativevelocity), 0.5f);
		force.z = 0f;
		m_OuterForce += force;
	}

	public virtual void Heal(float _heal)
	{
		if(m_CurHealth > 0f)
		{
			m_CurHealth = Mathf.Min(m_MaxHealth, m_CurHealth + _heal);
			GamePlayFXManager.Instance.StartFontFX(Color.green, transform.position, "+" + ((int)_heal).ToString());
		}
	}

	public virtual void Revive()
	{
		gameObject.SetActive(true);
		m_CurHealth = m_MaxHealth;
		m_ShipAnimation.PlayIdleAnimation();
	}

	public void AddTarget(Transform _target)
	{
		if(!m_TargetList.Contains(_target))
		{
			m_TargetList.Add(_target);
		}
	}
}
