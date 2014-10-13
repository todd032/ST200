using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSubShip_Type2 : PlayerSubShip {

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
			}
			
			if(!followplayership)
			{
				//find enemy ship in range if not found, follow player ship
				Transform targetenemy = null;
				float prevdistance = 0f;
				for(int i = 0; i < m_TargetList.Count; i++)
				{
					Transform curenemy = m_TargetList[i];
					float curdistance = Vector2.Distance(transform.position, curenemy.transform.position);
					if(curenemy.gameObject.activeSelf)
					{
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

						Vector3 targetdirection = Vector3.Cross(shipdeltadirection, Vector3.forward);
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
		bool shootleft = false;
		bool shootright = false;
		
		Vector3 frontdirection = m_LookingVector;
		Vector3 leftdirection = Vector3.Cross(Vector3.forward, m_LookingVector);
		Vector3 rightdirection = -leftdirection;
		
		for(int i = 0; i < m_TargetList.Count; i++)
		{
			Transform enemy = m_TargetList[i];
			if(enemy.gameObject.activeSelf && Vector2.Distance(enemy.transform.position, transform.position) < m_StatInfo.SpecialEffectValue2)
			{
				Vector3 deltapos = enemy.transform.position - transform.position;
				deltapos.z = 0f;
				if(!shootleft)
				{
					if(Vector2.Angle(leftdirection, deltapos) < 20f)
					{
						shootleft = true;
					}
				}
				if(!shootright)
				{
					if(Vector2.Angle(rightdirection, deltapos) < 20f)
					{
						shootright = true;
					}
				}
			}
		}
		if(shootleft)
		{
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Player_Shoot, m_ShootTransform[0].position);
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, m_ShootTransform[0].position);
			
			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       SpecialValue1, 
			                                       m_ShootTransform[0].position, 
			                                       m_ShootTransform[0].transform.up * m_StatInfo.SpecialEffectValue2, 
			                                       m_StatInfo.SpecialEffectValue3,
			                                       0.5f,
			                                       TeamIndex,
			                                       1f);
		}
		
		if(shootright)
		{
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Player_Shoot, m_ShootTransform[1].position);
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, m_ShootTransform[1].position);
			
			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       SpecialValue1, 
			                                       m_ShootTransform[1].position, 
			                                       m_ShootTransform[1].transform.up * m_StatInfo.SpecialEffectValue2, 
			                                       m_StatInfo.SpecialEffectValue3,
			                                       0.5f,
			                                       TeamIndex,
			                                       1f);
		}
		
		if(shootright || shootleft)
		{
			m_AttackTimer -= m_StatInfo.SpecialGaugeMax;
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_SHOOT_PLAYER, false);
		}
	}
	
}