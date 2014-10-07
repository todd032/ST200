using UnityEngine;
using System.Collections;

public class GameStageEnemyObject_Range_Shoot  : GameStageEnemyObject {

	protected GamePlayAttackFX m_TargetFX;
	public GameStageEnemyHealthDisplayer m_SpecialGauge;
	public GamePlayRangeDisplayer m_RangeDisplayer;

	public override void Init (PlayerShip _playership, StageEnemyData _enemydata, bool _marked)
	{
		base.Init (_playership, _enemydata, _marked);
		m_ShipAnimation.PlayIdleAnimation();
		m_RangeDisplayer.Init(_enemydata.SpecialEffectValue2);
	}

	
	float CurSpecialGauge = 0f;
	public override void ProcessAttack(float _timer)
	{
		base.ProcessAttack(_timer);
		if(Vector2.Distance(transform.position, m_PlayerShip.transform.position) < m_StageEnemyData.SpecialEffectValue2)
		{
			if(m_TargetFX == null)
			{
				m_TargetFX = GamePlayFXManager.Instance.GetAttackFX(GamePlayAttackFX_Type.FX_Attack_Target);
			}

			m_TargetFX.SetPosition(m_PlayerShip.transform.position);

			CurSpecialGauge += _timer * m_StageEnemyData.SpecialGaugeSpeed;
			if(CurSpecialGauge > m_StageEnemyData.SpecialGaugeMax)
			{
				CurSpecialGauge = 0f;
				Shoot();
			}
		}else
		{
			bool subshipmatched = false;
			for(int i = 0; i < m_PlayerSubShipList.Count; i++)
			{
				PlayerSubShip ship = m_PlayerSubShipList[i];
				if(Vector2.Distance(transform.position, ship.transform.position) < m_StageEnemyData.SpecialEffectValue2)
				{
					if(m_TargetFX == null)
					{
						m_TargetFX = GamePlayFXManager.Instance.GetAttackFX(GamePlayAttackFX_Type.FX_Attack_Target);
					}
					
					m_TargetFX.SetPosition(ship.transform.position);
					CurSpecialGauge += _timer * m_StageEnemyData.SpecialGaugeSpeed;
					if(CurSpecialGauge > m_StageEnemyData.SpecialGaugeMax)
					{
						CurSpecialGauge = 0f;
						Shoot();
					}
					break;
				}
			}

			if(!subshipmatched)
			{
				if(m_TargetFX != null)
				{
					m_TargetFX.Done();
					m_TargetFX = null;
				}
				CurSpecialGauge -= _timer * m_StageEnemyData.SpecialGaugeSpeed;
				CurSpecialGauge = Mathf.Max(CurSpecialGauge, 0f);
			}
		}

		m_SpecialGauge.UpdateHealth(CurSpecialGauge, m_StageEnemyData.SpecialGaugeMax);
	}
	
	public override void PlayDeadAnimation ()
	{
		base.PlayDeadAnimation ();
		
		StartCoroutine(DeadAnimation());
	}
	
	public override void Dead ()
	{
		base.Dead ();
		if(m_TargetFX != null)
		{
			m_TargetFX.Done();
			m_TargetFX = null;
		}
		gameObject.SetActive(false);
	}
	
	protected IEnumerator DeadAnimation()
	{
		//set collider false
		m_Collider.enabled = false;
		
		//play dead sprite animation 
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion2, transform.position);
		m_ShipAnimation.PlayDeadAnimation();
		
		yield return new WaitForSeconds(1f);
		
		Dead();
		yield break;
	}
	
	public override void Shoot ()
	{
		base.Shoot ();
		GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, transform.position);
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion3,m_PlayerShip.transform.position);
		float maxdistance = 10f;
		float soundratio = (Mathf.Max(maxdistance - Vector2.Distance(transform.position, m_PlayerShip.transform.position), 0f) / maxdistance);
		Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_SHOOT_ENEMY, false, soundratio);

		if(Vector2.Distance(transform.position, m_PlayerShip.transform.position) < m_StageEnemyData.SpecialEffectValue2)
		{
			m_PlayerShip.AddHitForce(transform.position, (m_PlayerShip.transform.position - transform.position).normalized * m_StageEnemyData.SpecialEffectValue3);
			m_PlayerShip.DoDamage(m_StageEnemyData.SpecialEffectValue, Constant.ST200_GAMEPLAY_DAMAGE_TYPE_BULLET);
		}else
		{
			for(int i = 0; i < m_PlayerSubShipList.Count; i++)
			{
				PlayerSubShip ship = m_PlayerSubShipList[i];
				if(Vector2.Distance(transform.position, ship.transform.position) < m_StageEnemyData.SpecialEffectValue2)
				{
					ship.AddHitForce(transform.position, (ship.transform.position - transform.position).normalized * m_StageEnemyData.SpecialEffectValue3);
					ship.DoDamage(m_StageEnemyData.SpecialEffectValue);
					break;
				}
			}
		}
	}
	
	
	public override void DefendLinePass ()
	{
		base.DefendLinePass ();
		PlayDeadAnimation();
	}
	

}