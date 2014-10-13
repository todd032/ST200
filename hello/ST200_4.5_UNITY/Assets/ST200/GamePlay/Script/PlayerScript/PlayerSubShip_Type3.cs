using UnityEngine;
using System.Collections;

public class PlayerSubShip_Type3 : PlayerSubShip {

	public GamePlayRangeDisplayer m_RangeDisplayer;


	public override void Init (SubShipStatInfo _info, int _equipindex, int _teamindex, PlayerShip _playership)
	{
		base.Init (_info, _equipindex, _teamindex, _playership);
		m_RangeDisplayer.Init(m_StatInfo.SpecialEffectValue2);
	}

	float aiprocesstimer = 0f;
	public override void ProcessAI (float _timer)
	{
		//try follow playership
		aiprocesstimer += _timer;
		if(aiprocesstimer > 0.5f)
		{
			//try follow playership
			if(Vector2.Distance(transform.position, m_PlayerShip.transform.position) > m_StatInfo.SpecialEffectValue2 * 5f / 6f)
			{
				m_HeadDirection = (m_PlayerShip.transform.position - m_PlayerShip.m_LookingVector * 1f - transform.position).normalized;
			}else
			{
				//Debug.Log("WORKING??????");
				m_HeadDirection = m_PlayerShip.m_LookingVector;
			}
		}
	}

	public override void Shoot()
	{
		if(Vector2.Distance(m_PlayerShip.transform.position, transform.position) < 	m_StatInfo.SpecialEffectValue2)
		{
			m_PlayerShip.Heal(SpecialValue1);
			GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.HEAL_FX, m_PlayerShip.transform.position);
		}

		for(int i = 0; i < GamePlayerManager.Instance.m_SubShipList.Count; i++)
		{
			PlayerSubShip ship = GamePlayerManager.Instance.m_SubShipList[i];
			if(ship.TeamIndex == TeamIndex && Vector2.Distance(ship.transform.position, transform.position) < m_StatInfo.SpecialEffectValue2)
			{
				ship.Heal(SpecialValue1);
				GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.HEAL_FX, ship.transform.position);
			}
		}

		for(int i = 0; i < GamePlayerManager.Instance.m_OppSubShipList.Count; i++)
		{
			PlayerSubShip ship = GamePlayerManager.Instance.m_OppSubShipList[i];
			if(ship.TeamIndex == TeamIndex && Vector2.Distance(ship.transform.position, transform.position) < m_StatInfo.SpecialEffectValue2)
			{
				ship.Heal(SpecialValue1);
				GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.HEAL_FX, ship.transform.position);
			}
		}

		m_AttackTimer -= m_StatInfo.SpecialGaugeMax;
	}
	
}