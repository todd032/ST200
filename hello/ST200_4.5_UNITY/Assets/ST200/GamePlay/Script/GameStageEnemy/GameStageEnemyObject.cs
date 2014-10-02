using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStageEnemyObject : MonoBehaviour {

	public int m_Type = 0;

	public PlayerShip m_PlayerShip;
	public List<PlayerSubShip> m_PlayerSubShipList = new List<PlayerSubShip>();

	public ShipAnimation m_ShipAnimation;
	public GameStageEnemyHealthDisplayer m_HealthDisplayer;
	public tk2dSprite m_MarkerSprite;

	public StageEnemyData m_StageEnemyData;
	public Transform m_TargetTransform;
	public Collider2D m_Collider;

	public float m_Health;

	public Vector3 m_LookingDirection;
	//[HideInInspector]
	protected float m_MoveResist = 0.9f;
	public Vector3 m_MoveSpeed;
	public float MaxMoveSpeed
	{
		get
		{
			float val = m_StageEnemyData.MoveSpeed;
			
			//for(int i = 0; i < m_BuffList.Count; i++)
			//{
			//	if(m_BuffList[i].BuffType == GameShipBuffType.ATTACK_SPEED_BUFF)
			//	{
			//		val *= m_BuffList[i].Value2;
			//	}
			//}
			//Debug.Log("sppeed: " + val);
			return val;
		}
	}
	public float MaxMoveForce
	{
		get
		{
			float val = m_StageEnemyData.MoveForce;
			
			//for(int i = 0; i < m_BuffList.Count; i++)
			//{
			//	if(m_BuffList[i].BuffType == GameShipBuffType.ATTACK_SPEED_BUFF)
			//	{
			//		val *= m_BuffList[i].Value2;
			//	}
			//}
			//Debug.Log("VAL: " + val);
			return val;
		}
	}

	public float m_MaxMoveForce;
	public Vector3 m_OuterForce;
	//public Vector3 m_OuterForce;

	public float m_RotationInertia;//??need it??
	protected float m_RotationResist = 0.97f;
	/// <summary>
	/// this means the angle looking
	/// </summary>
	public float m_RotationAngle = 0f;
	public float m_RotationSpeed;
	public float m_RotationMaxSpeed;
	public float RotationMaxSpeed
	{
		get
		{
			float val = m_StageEnemyData.RotationSpeed;
			
			//for(int i = 0; i < m_BuffList.Count; i++)
			//{
			//	if(m_BuffList[i].BuffType == GameShipBuffType.ATTACK_SPEED_BUFF)
			//	{
			//		val *= m_BuffList[i].Value2;
			//	}
			//}
			//Debug.Log("ROTATION MAX SPEED: " + RotationMaxSpeed);
			return val;
		}
	}
	public float m_RotationOuterForce;
	public float m_RotationMaxForce;
	public bool m_Marked = false;


	public virtual void Init(PlayerShip _playership, StageEnemyData _enemydata, bool _marked)
	{
		m_PlayerShip = _playership;

		m_StageEnemyData = _enemydata;
		m_Marked = _marked;

		m_Collider.enabled = true;
		m_Health = _enemydata.Health;
		m_LookingDirection = -transform.up;

		m_MarkerSprite.gameObject.SetActive(_marked);
	}

	public virtual void SetSubShipList(List<PlayerSubShip> _shiplist)
	{
		m_PlayerSubShipList = _shiplist;
	}

	public virtual void Process(float _timer)
	{
		ProcessAI(_timer);
		ProcessMovement(_timer);
		if(m_Health > 0f)
		{
			ProcessAttack(_timer);
		}
		m_HealthDisplayer.UpdateHealth(m_Health, (float)m_StageEnemyData.Health);
		ProcessDamageFXDisplay(_timer);
	}

	protected float AITimer = 0f;
	public virtual void ProcessAI(float _timer)
	{
		AITimer += _timer;
		if(AITimer > 0.5f)
		{
			//set target to closest ship
			m_TargetTransform = m_PlayerShip.transform;
			float leastdistance = Vector2.Distance(transform.position, m_PlayerShip.transform.position);
			for(int i = 0; i < m_PlayerSubShipList.Count; i++)
			{
				PlayerSubShip subship = m_PlayerSubShipList[i];
				if(subship.m_CurHealth > 0f)
				{
					float curdist = Vector2.Distance(subship.transform.position, transform.position);
					if(curdist < leastdistance)
					{
						leastdistance = curdist;
						m_TargetTransform = subship.transform;
					}
				}
			}
	    }
	}

	public virtual void ProcessMovement(float _timer)
	{
		m_LookingDirection = -transform.up;
		
		Vector3 targetdirection =  transform.position;

		if(m_TargetTransform != null)
		{
			//targetdirection = GamePathManager.Instance.GetTargetPos(m_TargetTransform.position, transform.position) - transform.position;
			targetdirection = m_TargetTransform.position - transform.position;
		}
		targetdirection.z = 0f;

		Vector3 lookingdirection = m_LookingDirection;
		Vector3 curmovespeed = m_MoveSpeed;
		float maxmovespeed = MaxMoveSpeed;
		float maxmoveforce = MaxMoveForce;
		
		float nextrotationspeed = 0f;

		Vector3 targetcross = Vector3.Cross(lookingdirection, targetdirection);
		if(targetcross.z > 0f)
		{
			m_RotationSpeed = RotationMaxSpeed;
		}else if(targetcross.z < 0f)
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
		if(Vector3.Cross(lookingdirection, targetdirection).z > 0f)
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
		//set transform variables
		transform.position += (curmovespeed + m_OuterForce) * _timer;
		transform.eulerAngles = new Vector3(0f, 0f, currotation);
		
		m_OuterForce *= m_MoveResist;
		m_RotationOuterForce *= m_RotationResist;
		
		//set variables
		m_MoveSpeed = curmovespeed;
		//m_RotationSpeed = currotationspeed;
		m_RotationAngle = currotation;
	}

	public virtual void ProcessAttack(float _timer)
	{

	}

	/// <summary>
	/// Hit by ammo
	/// </summary>
	public virtual void AddHitForce(Vector3 _hitpos, Vector3 _force)
	{
		if(_force.magnitude == 0f)
		{
			return;
		}

		Vector3 lookingdirection = m_LookingDirection;
		Vector3 movingspeed = m_MoveSpeed;
		Vector3 relativeforce = _force - movingspeed;
		relativeforce.z = 0f;
		
		Vector3 forcedirection = (transform.position - _hitpos);
		forcedirection.z = 0f;
		forcedirection.Normalize();
		
		Vector3 totalforce = forcedirection * Mathf.Abs(Vector3.Dot(forcedirection, relativeforce));
		totalforce.z = 0f;

		float deltaangle = 0;
		Vector3 deltapos = _hitpos - transform.position;
		deltapos.z = 0f;

		Vector3 crossvector = Vector3.Cross(lookingdirection, deltapos);
		if(crossvector.z < 0f)
		{
			deltaangle = -deltaangle;
		}

		float rotationforce = totalforce.magnitude * Mathf.Cos(deltaangle * Mathf.Deg2Rad) * 10f / m_StageEnemyData.Weight;
		if(crossvector.z > 0f)
		{
			rotationforce = -rotationforce;
		}
		
		m_OuterForce += totalforce;// moveforce;
		m_RotationOuterForce += rotationforce;
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

	public virtual void OnEnemyCrashEnter(GameStageEnemyObject _opp)
	{
		Vector3 myvelocity = m_MoveSpeed;
		Vector3 oppvelocity = _opp.m_MoveSpeed;
		
		Vector3 hitvector = (transform.position - _opp.transform.position).normalized;
		
		Vector3 relativevelocity = oppvelocity - myvelocity;
		
		//Vector3 force = hitvector * Mathf.Max(Vector3.Dot(hitvector, relativevelocity), 0.5f);
		Vector3 force = hitvector * Mathf.Max(Vector3.Dot(hitvector, relativevelocity), 5f);
		m_MoveSpeed += force;
		
		DoDamage(m_StageEnemyData.SelfCrashDamage);
	}

	public virtual void OnEnemyCrashStay(GameStageEnemyObject _opp)
	{
		//DoDamage(0.1f);
		Vector3 myvelocity = m_MoveSpeed;
		Vector3 oppvelocity = _opp.m_MoveSpeed;
		
		Vector3 hitvector = (transform.position - _opp.transform.position).normalized;
		
		Vector3 relativevelocity = oppvelocity - myvelocity;
		
		//Vector3 force = hitvector * Mathf.Max(Vector3.Dot(hitvector, relativevelocity), 0.5f);
		Vector3 force = hitvector * Mathf.Max(Vector3.Dot(hitvector, relativevelocity), 5f);
		m_MoveSpeed += force;

	}

	public virtual void OnPlayerCrashEnter(PlayerShip _ship)
	{
		_ship.DoDamage(m_StageEnemyData.PlayerCrashDamage);
	}

	public virtual void OnPlayerSubShipCrashEnter(PlayerSubShip _ship)
	{
		_ship.DoDamage(m_StageEnemyData.PlayerCrashDamage);
	}

	public virtual void OnSwirlStay(Vector3 _swirlposition)
	{
		Vector3 directionvector = transform.position - _swirlposition;
		directionvector.z = 0f;
		directionvector.Normalize();
		float angle = Vector3.Angle(Vector3.right, directionvector.normalized);
		Vector3 upvector = Vector3.forward;
		
		Vector3 forcedirectionvector = Vector3.Cross(directionvector.normalized, upvector);
		m_OuterForce += forcedirectionvector * 20f * Time.fixedDeltaTime;
		m_OuterForce -= directionvector * 10f * Time.fixedDeltaTime;
		m_RotationOuterForce += 10f * Time.fixedDeltaTime;
		
		DoDamage(10f * Time.fixedDeltaTime);
	}

	protected virtual void OnTriggerEnter2D(Collider2D _col)
	{
		if(_col != null)
		{
			if(_col.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
			{
				AddCrashForce(_col.transform.position);
			}else if(_col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			{
				GameStageEnemyObject enemyobject = _col.GetComponent<GameStageEnemyObject>();
				if(enemyobject != null)
				{
					OnEnemyCrashEnter(enemyobject);
				}
			}else if(_col.gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				PlayerShip ship = _col.GetComponent<PlayerShip>();
				OnPlayerCrashEnter(ship);
			}else if(_col.gameObject.layer == LayerMask.NameToLayer("Player_Sub"))
			{
				PlayerSubShip ship = _col.GetComponent<PlayerSubShip>();
				OnPlayerSubShipCrashEnter(ship);
			}else if(_col.gameObject.layer == LayerMask.NameToLayer("DefendLine"))
			{
				DefendLinePass();
			}
		}
	}

	protected virtual void OnTriggerStay2D(Collider2D _col)
	{
		if(_col != null)
		{
			if(_col.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
			{
				AddCrashForce(_col.transform.position);
			}else if(_col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			{
				GameStageEnemyObject enemyobject = _col.GetComponent<GameStageEnemyObject>();
				if(enemyobject != null)
				{
					OnEnemyCrashStay(enemyobject);
				}
			}else if(_col.gameObject.layer == LayerMask.NameToLayer("Player"))
			{

			}
		}
	}

	public delegate void DamageDelegate(GameStageEnemyObject _enemyobject, float _value);
	protected DamageDelegate m_DamageDelegate;
	public event DamageDelegate DamageEvent
	{
		add
		{
			m_DamageDelegate += value;
		}remove
		{
			m_DamageDelegate -= value;
		}
	}

	public virtual void DoDamage(float _value)
	{	
		//Debug.Log("HHHH: " + _value +  " CURHP: " + m_Health);
		m_Health -= _value;
		m_TotalDamageAccumulated += _value;
		float curtimer = Time.time;

		//Debug.Log("? hp:" + m_Health);
		if(m_Health <= 0f && m_Health + _value > 0f)
		{
			PlayDeadAnimation();
		}

		if(m_DamageDelegate != null)
		{
			m_DamageDelegate(this, _value);
		}
	}

	protected float m_TotalDamageAccumulated = 0f;
	protected float m_DamageFontFXTimer = 0f;
	protected float m_DamageFontFXMaxTime = 0.4f;
	public virtual void ProcessDamageFXDisplay(float _timer)
	{
		m_DamageFontFXTimer += _timer;
		if(m_DamageFontFXTimer > m_DamageFontFXMaxTime)
		{
			m_DamageFontFXTimer = 0f;
			if(m_TotalDamageAccumulated != 0f)
			{
				GamePlayFXManager.Instance.StartFontFX(Color.red, transform.position, "-" + ((int)m_TotalDamageAccumulated).ToString());
				m_TotalDamageAccumulated = 0f;
			}
		}
	}

	public delegate void DefendLinePassDelegate(GameStageEnemyObject _enemyobject);
	protected DefendLinePassDelegate m_DefendLinePassDelegate;
	public event DefendLinePassDelegate DefendLinePassEvent
	{
		add
		{
			m_DefendLinePassDelegate += value;
		}
		remove
		{
			m_DefendLinePassDelegate -= value;
		}
	}

	public virtual void DefendLinePass()
	{
		if(m_DefendLinePassDelegate != null)
		{
			m_DefendLinePassDelegate(this);
		}
	}

	public delegate void DeadDelegate(GameStageEnemyObject _enemyobject);
	protected DeadDelegate m_DeadDelegate;
	public event DeadDelegate DeadEvent
	{
		add
		{
			m_DeadDelegate += value;
		}remove
		{
			m_DeadDelegate -= value;
		}
	}

	public virtual void Dead()
	{
		if(m_DeadDelegate != null)
		{
			m_DeadDelegate(this);
		}
	}

	public virtual void PlayDeadAnimation()
	{

	}

	public delegate void ShootDelegate(GameStageEnemyObject _enemyobject);
	protected ShootDelegate m_ShootDelegate;
	public event ShootDelegate ShootEvent
	{
		add
		{
			m_ShootDelegate += value;
		}remove
		{
			m_ShootDelegate -= value;
		}
	}

	public virtual void Shoot()
	{
		if(m_ShootDelegate != null)
		{
			m_ShootDelegate(this);
		}
	}

	public virtual void Heal(float _heal)
	{
		if(m_Health > 0f)
		{
			m_Health = Mathf.Min(m_StageEnemyData.Health, m_Health + _heal);
			GamePlayFXManager.Instance.StartFontFX(Color.green, transform.position, "+" + ((int)_heal).ToString());
		}
	}
}