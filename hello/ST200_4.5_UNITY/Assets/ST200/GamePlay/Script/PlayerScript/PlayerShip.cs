using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShip : MonoBehaviour {

	public GamePlayerShipType m_ShipType;

	public List<GameShipBuff> m_BuffList = new List<GameShipBuff>();

	public GameStageEnemyHealthDisplayer m_HealthGauge;
	public GameStageEnemyHealthDisplayer m_SpecialGauge;
	public ShipStatInfo m_ShipStatInfo;
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
	protected string m_MaxHealth = "";
	public float MaxHealth {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MaxHealth = encryptString ;
		}
		get {
			if(m_MaxHealth == null || m_MaxHealth.Equals("")){
				return 1f ;	
			}
			string decryptString = LoadingWindows.NextD(m_MaxHealth,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;

			for(int i = 0; i < m_BuffList.Count; i++)
			{
				if(m_BuffList[i].BuffType == GameShipBuffType.HEALTH_INCREASE)
				{
					decryptFloat *= m_BuffList[i].Value2;
				}
			}

			return decryptFloat;
		}
	}

	public float AttackDamage
	{
		get
		{
			float val = m_ShipStatInfo.BulletDamage;
			
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

	public float AttackGaugeSpeed
	{
		get
		{
			float val = m_ShipStatInfo.AttackGaugeSpeed;

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

	public float AttackMaxGauge
	{
		get
		{
			float val = m_ShipStatInfo.AttackMaxGauge;
			
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

	public float m_AttackTimer = 0f;

	/// <summary>
	/// set in world space direction only.  not position
	/// </summary>
	public Vector3 m_HeadDirection = Vector3.up;

	//[HideInInspector]
	protected float m_MoveResist = 0.9f;
	public Vector3 m_MoveSpeed;
	public float MaxMoveSpeed
	{
		get
		{
			float val = m_ShipStatInfo.MaxMoveSpeed;
			
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
			float val = m_ShipStatInfo.MoveForce;
			
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
			float val = m_ShipStatInfo.MaxRotationSpeed;
			
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
	/// <summary>
	/// -1f - turn clockwise
	/// 0 - no turn
	/// 1f - turn counterclodkwise
	/// </summary>
	public float TurnRotationInput = 0f;

	public float m_RotationMaxForce;
	public float m_RotationOuterForce;

	protected bool RowGaugeLeftPressed = false;
	protected bool RowGaugeRightPressed = false;
	public float CurRowGauge;
	public float RowGaugeLeft;
	public float RowGaugeRight;
	public float MaxRowGauge = 100f;
	public float RowGaugeLimitByPress = 0.6f;
	protected float MaxRowSpeed = 1f;
	protected float RowDecreaseFactor = 0.99f;

	[HideInInspector]
	public List<Transform> m_SubShipFollowList = new List<Transform>();
	public virtual void Init(ShipStatInfo _info)
	{
		m_ShipStatInfo = _info;
		MaxHealth = m_ShipStatInfo.Health;
		m_CurHealth = MaxHealth;

		List<Vector3> followtransformlist = new List<Vector3>();
		SubShipTacTic subshiptactic = Managers.GameBalanceData.GetSubShipTactic(Managers.UserData.GetCurrentGameCharacter().SelectedTactic);
		followtransformlist.Add(new Vector3(subshiptactic.ShipPosX1, subshiptactic.ShipPosY1, 0f));
		followtransformlist.Add(new Vector3(subshiptactic.ShipPosX2, subshiptactic.ShipPosY2, 0f));
		followtransformlist.Add(new Vector3(subshiptactic.ShipPosX3, subshiptactic.ShipPosY3, 0f));
		followtransformlist.Add(new Vector3(subshiptactic.ShipPosX4, subshiptactic.ShipPosY4, 0f));

		for(int i = 0; i < followtransformlist.Count; i++)
		{
			Vector3 pos = followtransformlist[i];
			GameObject follow = new GameObject("Followtransform_" + (i + 1).ToString());
			follow.transform.parent = transform;
			follow.transform.localPosition = pos;
			follow.transform.localEulerAngles = Vector3.zero;
			m_SubShipFollowList.Add(follow.transform);
		}

		MaxRowSpeed = Managers.GameBalanceData.GamePlayRowSpeed;
		RowDecreaseFactor = Managers.GameBalanceData.GamePlayRowResist;
	}

	public virtual void Process(float _timer)
	{
		if(m_CurHealth > 0f)
		{
			ProcessBuff(_timer);
			ProcessAttack(_timer);
			ProcessRowGauge(_timer);
			ProcessMovement(_timer);
			ProcessRotation(_timer);
		}
	}

	public virtual void AddBuff(GameShipBuff _buff)
	{
		if(_buff.BuffRemainType == GameShipBuffRemainType.INSTANCE)
		{
			if(_buff.BuffType == GameShipBuffType.HEAL)
			{
				Heal(_buff.Value1);
				GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.HEAL_FX,
				                                         transform.position);
			}
		}else
		{
			m_BuffList.Add(_buff);
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
		if(m_AttackTimer > AttackMaxGauge)
		{
			Shoot();
		}else
		{
			m_AttackTimer += _timer * AttackGaugeSpeed;
		}
		m_SpecialGauge.UpdateHealth(m_AttackTimer, AttackMaxGauge);
		m_HealthGauge.UpdateHealth(m_CurHealth, MaxHealth);
	}

	public virtual void ProcessMovement(float _timer)
	{				
		Vector3 targetdirection = Vector3.Cross(m_LookingVector, m_HeadDirection.normalized);//m_TargetTransform.position - transform.position;
		
		Vector3 lookingdirection = m_LookingVector;

		float leftforce = Mathf.Min(RowGaugeLeft, MaxRowGauge);
		float rightforce = Mathf.Min(RowGaugeRight, MaxRowGauge);
		Vector3 curmovespeed = m_LookingVector * Mathf.Max(MaxMoveSpeed * 0.1f, 
		                                                   (MaxMoveSpeed) * 
		                                                   (Mathf.Min(1f, (RowGaugeLeft + RowGaugeRight) / (MaxRowGauge * RowGaugeLimitByPress))
		 + Mathf.Max(0f, MaxRowSpeed * Mathf.Min(1f,(RowGaugeLeft + RowGaugeRight - 2f * MaxRowGauge * RowGaugeLimitByPress) / (MaxRowGauge * (1f - RowGaugeLimitByPress))))));

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
		//change speed to looking direction

		curmovespeed = lookingdirection.normalized * Vector3.Dot(curmovespeed, lookingdirection);
		transform.position += (curmovespeed + m_OuterForce) * _timer;

		m_OuterForce *= m_MoveResist;
		//set variables
		m_MoveSpeed = curmovespeed;
	}

	public virtual void ProcessRotation(float _timer)
	{
		float currotationspeed = RotationMaxSpeed * TurnRotationInput;
		if(currotationspeed > RotationMaxSpeed * 0.5f)
		{
			m_ShipAnimation.PlayMoveLeftAnimation();
		}else if(currotationspeed < -RotationMaxSpeed * 0.5f)
		{
			m_ShipAnimation.PlayMoveRightAnimation();
		}else
		{
			m_ShipAnimation.PlayIdleAnimation();
		}
		
		float maxrotationspeed = RotationMaxSpeed;

		float currotation = m_RotationAngle;
		currotation += (currotationspeed + m_RotationOuterForce) * _timer;
		if(currotation < -180f)
		{
			currotation = 360f + currotation;
		}else if(currotation > 180f)
		{
			currotation = -360f + currotation;
		}

		transform.eulerAngles = new Vector3(0f, 0f, currotation);
		m_RotationOuterForce *= m_RotationResist;
		m_RotationAngle = currotation;

		m_LookingVector = m_ShipAnimation.transform.up;
	}

//	public virtual void ProcessMovement(float _timer)
//	{
//		m_LookingVector = m_ShipAnimation.transform.up;
//		
//		Vector3 targetdirection = Vector3.Cross(m_LookingVector, m_HeadDirection.normalized);//m_TargetTransform.position - transform.position;
//		
//		Vector3 lookingdirection = m_LookingVector;
//		Vector3 curmovespeed = m_MoveSpeed;
//		float maxmovespeed = MaxMoveSpeed;
//		float maxmoveforce = MaxMoveForce;
//		
//		float nextrotationspeed = 0f;
//		if(targetdirection.z < 0f)
//		{
//			m_RotationSpeed = RotationMaxSpeed;
//		}else if(targetdirection.z > 0f)
//		{
//			m_RotationSpeed = -RotationMaxSpeed;
//		}else
//		{
//			m_RotationSpeed *= m_RotationResist;
//		}
//		float currotationspeed = m_RotationSpeed;
//		
//		float maxrotationspeed = RotationMaxSpeed;
//		float currotation = m_RotationAngle;
//		float targetrotation = Vector3.Angle(lookingdirection, targetdirection);
//		if(targetdirection == Vector3.zero)
//		{
//			targetrotation = 0f;
//		}
//		
//		//Debug.Log("CROSS: " + Vector3.Cross(lookingdirection, targetdirection).z);
//		if(Vector3.Cross(lookingdirection, targetdirection).z < 0f)
//		{
//			targetrotation = -targetrotation;
//		}
//		currotation += (currotationspeed + m_RotationOuterForce) * _timer;
//		if(currotation < -180f)
//		{
//			currotation = 360f + currotation;
//		}else if(currotation > 180f)
//		{
//			currotation = -360f + currotation;
//		}
//		
//		//change speed to looking direction
//		
//		curmovespeed = lookingdirection.normalized * Vector3.Dot(curmovespeed, lookingdirection);
//		curmovespeed += lookingdirection *  maxmoveforce * _timer;
//		if(curmovespeed.magnitude > maxmovespeed)
//		{
//			curmovespeed *= m_MoveResist;
//		}
//		
//		Vector3 rowspeed = MaxRowSpeed * Mathf.Min(1f, CurRowGauge / MaxRowGauge) * m_LookingVector;
//		//Debug.Log("CURMOVE: " + curmovespeed + " ROWSPEED: " + rowspeed);
//		//set transform variables
//		transform.position += (curmovespeed + m_OuterForce + rowspeed) * _timer;
//		transform.eulerAngles = new Vector3(0f, 0f, currotation);
//		
//		m_OuterForce *= m_MoveResist;
//		m_RotationOuterForce *= m_RotationResist;
//		
//		//set variables
//		m_MoveSpeed = curmovespeed;
//		//m_RotationSpeed = currotationspeed;
//		m_RotationAngle = currotation;
//		
//		//reset outer force
//		//m_OuterForce = Vector3.zero;
//	}

	public virtual void ProcessRowGauge(float _timer)
	{
		CurRowGauge *= RowDecreaseFactor;
		if(!RowGaugeLeftPressed)
		{
			RowGaugeLeft *= RowDecreaseFactor;
		}
		if(!RowGaugeRightPressed)
		{
			RowGaugeRight *= RowDecreaseFactor;

		}
		RowGaugeLeftPressed = false;
		RowGaugeRightPressed = false;

		if(m_CurHealth > 0f)
		{
			if(RowGaugeLeft <= MaxRowGauge * (RowGaugeLimitByPress + 0.05f) || RowGaugeRight <= MaxRowGauge * (RowGaugeLimitByPress + 0.05f))
			{
				m_ShipAnimation.PlayWaveAnimation(false);
			}else
			{
				m_ShipAnimation.PlayWaveAnimation(true);
			}
		}
	}

	public virtual void AddHitForce (Vector3 _hitpos, Vector3 _force)
	{		
		Vector3 deltapos = _hitpos - transform.position;
		deltapos.z = 0f;
		Vector3 lookingdirection = m_LookingVector;
		float deltaangle = Vector3.Angle(lookingdirection, deltapos);
		Vector3 crossvector = Vector3.Cross(lookingdirection, deltapos);
		if(crossvector.z < 0f)
		{
			deltaangle = -deltaangle;
		}
		
		Vector3 moveforce = _force;//Mathf.Abs(Mathf.Cos(deltaangle * Mathf.Deg2Rad)) * 100f;
		moveforce.z = 0f;
		//float rotationforce = _force.magnitude * Mathf.Cos(deltaangle * Mathf.Deg2Rad) * 50f;
		//if(crossvector.z > 0f)
		//{
		//	//moveforce = -moveforce;
		//	rotationforce = -rotationforce;
		//}
		//Debug.Log("rotationforce: " + rotationforce);
		
		m_OuterForce += moveforce;
		//m_RotationOuterForce += rotationforce;
	}

	public virtual void AddMoveForce(Vector3 _force)
	{
		m_OuterForce += _force;
	}

	public virtual void AddRowGauge(float _val)
	{
		CurRowGauge = Mathf.Min(MaxRowGauge * 1.2f, CurRowGauge + _val);
	}

	/// <summary>
	/// -1f - turn clockwise
	/// 0 - no turn
	/// 1f - turn counterclodkwise
	/// </summary>
	public virtual void SetRotationInput(float _input)
	{
		TurnRotationInput = _input;
	}

	/// <summary>	/// 
	/// [_type] 
	/// 0 - pressed
	/// 1 - tap
	/// </summary>
	public virtual void AddRowGauge(bool _isleft, float _val, int _type)
	{
		if(_type == 0)
		{
			if(_isleft)
			{
				if(RowGaugeLeft < MaxRowGauge * RowGaugeLimitByPress)
				{
					RowGaugeLeft = Mathf.Min(MaxRowGauge * RowGaugeLimitByPress, RowGaugeLeft + _val * Time.deltaTime);
					if(!RowGaugeLeftPressed)
					{
						RowGaugeLeftPressed = _isleft;
					}
				}
			}else
			{
				if(RowGaugeRight < MaxRowGauge * RowGaugeLimitByPress)
				{
					RowGaugeRight = Mathf.Min(MaxRowGauge * RowGaugeLimitByPress, RowGaugeRight + _val * Time.deltaTime);
					if(!RowGaugeRightPressed)
					{
						RowGaugeRightPressed = !_isleft;
					}
				}
			}
		}else if(_type == 1)
		{
			if(_isleft)
			{
				RowGaugeLeft = Mathf.Min(MaxRowGauge * 1.2f, RowGaugeLeft + _val);
			}else
			{
				RowGaugeRight = Mathf.Min(MaxRowGauge * 1.2f, RowGaugeRight + _val);
			}
		}
	}

	public delegate void ShootBulletDelegate(PlayerShip _player);
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

	public delegate void DamagedDelegate(PlayerShip _player, float _damage);
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
		//GameManager.Instance._cameraShakeScript.DoCameraShake(0.075f, 0.004f);
		Managers.UserData.Vibrate();
		float totaldamage = _damage;
		for(int i = 0; i < m_BuffList.Count; i++)
		{
			if(m_BuffList[i].BuffType == GameShipBuffType.INVINCIBLE)
			{
				totaldamage = 0f;
				break;
			}
		}

		if(m_CurHealth > 0f)
		{
			m_CurHealth -= totaldamage;
			GamePlayFXManager.Instance.StartFontFX(Color.red, transform.position, "-" + ((int)totaldamage).ToString()); 

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
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion2, transform.position);
		m_ShipAnimation.PlayDeadAnimation();
	}

	public virtual void CrashEnemyShip(GameStageEnemyObject _enemy)
	{
		_enemy.AddHitForce(transform.position, m_LookingVector * Mathf.Min(m_MoveSpeed.magnitude / m_ShipStatInfo.MaxMoveSpeed, 1f) * m_ShipStatInfo.PushForce);
		_enemy.DoDamage(m_ShipStatInfo.PushDamage);
		GameManager.Instance.PlayerCrashWithEnemyEvent();
	}

	public virtual void DragEnemyShip(GameStageEnemyObject _enemy)
	{
		_enemy.AddHitForce(transform.position, (_enemy.transform.position - transform.position).normalized );
	}

	public virtual void CrashPlayerSubShip(PlayerSubShip _ship)
	{
		_ship.AddHitForce(transform.position, m_LookingVector.normalized);// * Mathf.Min(m_MoveSpeed.magnitude / m_ShipStatInfo.MaxMoveSpeed, 1f) * m_ShipStatInfo.PushForce);
		//_enemy.DoDamage(m_ShipStatInfo.PushDamage);
	}
	
	public virtual void DragPlayerSubShip(PlayerSubShip _ship)
	{
		_ship.AddHitForce(transform.position, (_ship.transform.position - transform.position).normalized );
	}

	public virtual void OnStageItemEnter(StageItem _stageitem)
	{
		GameManager.Instance.PlayerStageItemGetEvent(this, _stageitem);
	}

	protected virtual void OnTriggerEnter2D(Collider2D _col)
	{
		if(_col != null)
		{
			if(_col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			{
				GameStageEnemyObject enemy = _col.gameObject.GetComponent<GameStageEnemyObject>();
				CrashEnemyShip(enemy);
			}else if(_col.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
			{
				AddCrashForce(_col.transform.position);
			}
			else if(_col.gameObject.layer == LayerMask.NameToLayer("Player_Sub"))
			{
				PlayerSubShip sub = _col.gameObject.GetComponent<PlayerSubShip>();
				CrashPlayerSubShip(sub);
			}
			else if(_col.gameObject.layer == LayerMask.NameToLayer("StageItem"))
			{
				StageItem stageitem = _col.gameObject.GetComponent<StageItem>();
				OnStageItemEnter(stageitem);
			}			       
		}
	}

	protected virtual void OnTriggerStay2D(Collider2D _col)
	{
		if(_col != null)
		{
			if(_col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			{
				GameStageEnemyObject enemy = _col.gameObject.GetComponent<GameStageEnemyObject>();
				DragEnemyShip(enemy);
			}else if(_col.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
			{
				AddCrashForce(_col.transform.position);
			}
			else if(_col.gameObject.layer == LayerMask.NameToLayer("Player_Sub"))
			{
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
			m_CurHealth = Mathf.Min(MaxHealth, m_CurHealth + _heal);
			GamePlayFXManager.Instance.StartFontFX(Color.green, transform.position, "+" + ((int)_heal).ToString()); 
		}
	}

	public virtual void Revive()
	{
		m_CurHealth = MaxHealth;
		m_ShipAnimation.PlayIdleAnimation();
	}
}
