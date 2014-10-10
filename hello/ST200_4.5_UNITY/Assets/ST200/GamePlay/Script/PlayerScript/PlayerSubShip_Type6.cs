using UnityEngine;
using System.Collections;

public class PlayerSubShip_Type6 : PlayerSubShip {
	
	float aiprocesstimer = 0f;
	public override void ProcessAI (float _timer)
	{
		//try follow playership
		aiprocesstimer += _timer;
		if(aiprocesstimer > 0.5f)
		{
			bool followplayership = false;
			float distancefromplayer = Vector2.Distance(transform.position, m_PlayerShip.transform.position);
			if(distancefromplayer > 10f)
			{
				Vector3 shipdeltadirection = m_PlayerShip.transform.position - transform.position;
				shipdeltadirection.z = 0f;
				followplayership = true;
				m_HeadDirection = shipdeltadirection;
				m_HeadDirection = m_PlayerShip.m_LookingVector;
			}else if(distancefromplayer < 4f)
			{
				m_HeadDirection = m_PlayerShip.m_LookingVector;
			}else
			{
				Vector3 shipdeltadirection = m_PlayerShip.transform.position - transform.position;
				shipdeltadirection.z = 0f;
				m_HeadDirection = shipdeltadirection;
				m_HeadDirection = m_PlayerShip.m_LookingVector;
			}

			if(!followplayership)
			{
				//find enemy ship in range if not found, follow player ship
				GameStageEnemyObject targetenemy = null;
				float prevdistance = 0f;
				for(int i = 0; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
				{
					GameStageEnemyObject curenemy = GameStageManager.Instance.m_ActiveEnemyList[i];
					float curdistance = Vector2.Distance(transform.position, curenemy.transform.position);

					if(targetenemy == null)
					{
						if(curdistance < m_StatInfo.SpecialEffectValue2)
						{
							targetenemy = curenemy;
							prevdistance = Vector2.Distance(transform.position, curenemy.transform.position);
						}
					}else
					{
						if(curdistance < prevdistance)
						{
							targetenemy = curenemy;
							prevdistance = curdistance;
						}
					}
				}
				
				if(targetenemy == null)
				{
					m_HeadDirection = (m_PlayerShip.transform.position - transform.position).normalized;
				}else
				{
					float distance = Vector2.Distance(transform.position, targetenemy.transform.position);
					
					if(distance < m_StatInfo.SpecialEffectValue2)
					{
						Vector3 shipdeltadirection = targetenemy.transform.position - transform.position;
						shipdeltadirection.z = 0f;
						
						Vector3 targetdirection = shipdeltadirection;
						targetdirection.z = 0f;
						m_HeadDirection = targetdirection;
					}else
					{
						Vector3 shipdeltadirection = targetenemy.transform.position - transform.position;
						shipdeltadirection.z = 0f;
						m_HeadDirection = shipdeltadirection;
					}
				}
			}

			if(Vector2.Distance(transform.position, Vector3.zero) > Managers.GameBalanceData.GamePlayReturnToBattleMaxDistance)
			{
				m_HeadDirection = -transform.position.normalized;
			}
		}
	}

	public override void Shoot()
	{
		bool shootfront = false;
		
		Vector3 frontdirection = m_LookingVector;
		
		for(int i = 0; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
		{
			GameStageEnemyObject enemy = GameStageManager.Instance.m_ActiveEnemyList[i];
			Vector3 deltapos = enemy.transform.position - transform.position;
			deltapos.z = 0f;
			if(Vector2.Distance(enemy.transform.position, transform.position) < m_StatInfo.SpecialEffectValue2)
			{
				//Debug.Log("pos	: " + Vector2.Distance(enemy.transform.position, transform.position) + " ANGLE: " + Vector2.Angle(frontdirection, deltapos));
				if(!shootfront)
				{
					if(Vector2.Angle(frontdirection, deltapos) < 10f)
					{
						shootfront = true;
					}
				}
			}
		}
		
		if(shootfront)
		{
			for(int i = 0; i < 2; i++)
			{
				GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Player_Shoot, m_ShootTransform[i].position);
				GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, m_ShootTransform[i].position);
				
				GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
				                                       SpecialValue1, 
				                                       m_ShootTransform[i].position, 
				                                       m_ShootTransform[i].transform.up * m_StatInfo.SpecialEffectValue2, 
				                                       m_StatInfo.SpecialEffectValue3,
				                                       0.5f,
				                                       TeamIndex,
				                                       1f);
			}
		}
		
		if(shootfront)
		{
			m_AttackTimer -= m_StatInfo.SpecialGaugeMax;
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_SHOOT_PLAYER, false);
			
			if(m_ShootDelegate != null)
			{
				m_ShootDelegate(this);
			}
		}
	}
	
}