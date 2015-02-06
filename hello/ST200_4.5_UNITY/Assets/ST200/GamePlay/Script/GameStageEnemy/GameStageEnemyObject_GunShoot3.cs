using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStageEnemyObject_GunShoot3  : GameStageEnemyObject {
	
	public List<Transform> m_ShootTransform = new List<Transform>();
	public GameStageEnemyHealthDisplayer m_SpecialGauge;
	
	public override void Init (PlayerShip _playership, StageEnemyData _enemydata, bool _marked)
	{
		base.Init (_playership, _enemydata, _marked);
		m_ShipAnimation.PlayIdleAnimation();
	}
	
	
	float CurSpecialGauge = 0f;
	public override void ProcessAttack(float _timer)
	{
		base.ProcessAttack(_timer);
		CurSpecialGauge += _timer * m_StageEnemyData.SpecialGaugeSpeed;
		if(CurSpecialGauge > m_StageEnemyData.SpecialGaugeMax)
		{
			Shoot();
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
		bool shootleft = false;
		bool shootright = false;
		
		Vector3 frontdirection = m_LookingDirection;
		Vector3 leftdirection = Vector3.Cross(Vector3.forward, m_LookingDirection);
		Vector3 rightdirection = -leftdirection;
		
		Transform m_LeftTarget = null;
		Transform m_RightTarget = null;

		List<Transform> m_TargetList = new List<Transform>();
		m_TargetList.Add(m_PlayerShip.transform);
		for(int i = 0; i < m_PlayerSubShipList.Count; i++)
		{
			m_TargetList.Add(m_PlayerSubShipList[i].transform);
		}

		for(int i = 0; i < m_TargetList.Count; i++)
		{
			Transform enemy = m_TargetList[i];
			if(enemy.gameObject.activeSelf && Vector2.Distance(enemy.transform.position, transform.position) < m_StageEnemyData.SpecialEffectValue2)
			{				
				if(!shootleft)
				{
					if(Vector2.Angle(leftdirection, enemy.transform.position - transform.position) < 32.5f)
					{
						shootleft = true;
						m_LeftTarget = enemy.transform;
					}
				}
				if(!shootright)
				{
					if(Vector2.Angle(rightdirection, enemy.transform.position - transform.position) < 32.5f)
					{
						shootright = true;
						m_RightTarget = enemy.transform;
					}
				}
			}
		}

		if(shootleft)
		{
			for(int i = 0; i < m_ShootTransform.Count / 2; i++)
			{
				Vector3 movedirection =  (m_LeftTarget.transform.position - m_ShootTransform[i].transform.position);
				movedirection.z = 0f;
				movedirection.Normalize();
				GameBulletManager.Instance.ShootBullet(GamePlayBulletType.ENEMY_GUN, 
				                                       m_StageEnemyData.SpecialEffectValue, 
				                                       m_ShootTransform[i].transform.position, 
				                                       movedirection.normalized * m_StageEnemyData.SpecialEffectValue2, 
				                                       m_StageEnemyData.SpecialEffectValue3, 
				                                       0.3f,
				                                       0,
				                                       1f);
			}
		}
		if(shootright)
		{
			for(int i = m_ShootTransform.Count / 2; i < m_ShootTransform.Count; i++)
			{
				Vector3 movedirection =  (m_RightTarget.transform.position - m_ShootTransform[i].transform.position);
				movedirection.z = 0f;
				movedirection.Normalize();
				GameBulletManager.Instance.ShootBullet(GamePlayBulletType.ENEMY_GUN, 
				                                       m_StageEnemyData.SpecialEffectValue, 
				                                       m_ShootTransform[i].transform.position, 
				                                       movedirection.normalized * m_StageEnemyData.SpecialEffectValue2, 
				                                       m_StageEnemyData.SpecialEffectValue3, 
				                                       0.3f,
				                                       0,
				                                       1f);
			}
		}

		if(shootright || shootleft)
		{
			//m_ArrowTimer = 0f;
			//Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_ARROW_SHOOT, false);
			CurSpecialGauge = 0f;
			StartCoroutine(ShootArrowFXSound());
		}
	}
	
	protected IEnumerator ShootArrowFXSound()
	{
		for(int i = 0; i < 4; i++)
		{
			float maxdistance = 5f;
			float maxsound = 0.4f;
			float soundratio = (Mathf.Max(maxdistance - Vector2.Distance(transform.position, m_PlayerShip.transform.position), 0f) / maxdistance * maxsound);
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_SHOOT_GUN, false, soundratio);
			yield return new WaitForSeconds(0.05f);
		}
	}
	
}