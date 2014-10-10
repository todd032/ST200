using UnityEngine;
using System.Collections;

public class PlayerShip_Panokseon3 : PlayerShip {
	
	public override void Shoot()
	{
		bool shoot = false;		
		Vector3 frontdirection = m_LookingVector;		
		for(int i = 0; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
		{
			GameStageEnemyObject enemy = GameStageManager.Instance.m_ActiveEnemyList[i];
			if(Vector2.Distance(enemy.transform.position, transform.position) < m_ShipStatInfo.BulletSpeed)
			{
				if(!shoot)
				{
					if(Vector2.Angle(frontdirection, enemy.transform.position - transform.position) < 40f)
					{
						shoot = true;
					}
				}
			}
		}

		if(shoot)
		{
			for(int i = 0; i < m_ShootTransform.Count; i++)
			{
				GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Player_Shoot, m_ShootTransform[i].position);
				GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, m_ShootTransform[i].position);

				GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
				                                       AttackDamage, 
				                                       m_ShootTransform[i].position, 
				                                       m_ShootTransform[i].transform.up * m_ShipStatInfo.BulletSpeed, 
				                                       m_ShipStatInfo.BulletPushForce,
				                                       0.3f,
				                                       TeamIndex,
				                                       1f);
			}
			m_AttackTimer -= AttackMaxGauge;
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_SHOOT_PLAYER, false);
			
			if(m_ShootDelegate != null)
			{
				m_ShootDelegate(this);
			}
		}
	}
	
}
