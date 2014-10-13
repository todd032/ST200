using UnityEngine;
using System.Collections;

public class PlayerSubShip_Type5 : PlayerSubShip {
	
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
}