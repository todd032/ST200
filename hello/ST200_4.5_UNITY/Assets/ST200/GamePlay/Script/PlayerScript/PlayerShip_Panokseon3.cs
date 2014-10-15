using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShip_Panokseon3 : PlayerShip {
	
	public override void Shoot()
	{
		bool shoot = false;		
		Vector3 frontdirection = m_LookingVector;		

		for(int i = 0; i < m_TargetList.Count; i++)
		{
			Transform enemy = m_TargetList[i];
			if(enemy.gameObject.activeSelf && Vector2.Distance(enemy.transform.position, transform.position) < m_ShipStatInfo.BulletSpeed)
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
		//for(int i = 0; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
		//{
		//	GameStageEnemyObject enemy = GameStageManager.Instance.m_ActiveEnemyList[i];
		//	if(Vector2.Distance(enemy.transform.position, transform.position) < m_ShipStatInfo.BulletSpeed)
		//	{
		//		if(!shoot)
		//		{
		//			if(Vector2.Angle(frontdirection, enemy.transform.position - transform.position) < 40f)
		//			{
		//				shoot = true;
		//			}
		//		}
		//	}
		//}

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

	public override bool IsInAttackAngle (Vector3 _worldposition)
	{
		bool isinangle = false;
		Vector3 frontdirection = m_LookingVector;
		if(Vector2.Angle(frontdirection, _worldposition - transform.position) < 10f)
		{
			isinangle = true;
		}
		
		return isinangle;
	}

	public override System.Collections.Generic.List<Vector3> GetDeadAngleDirectionList ()
	{
		List<Vector3> deadangledirectionlist = new List<Vector3>();
		//deadangledirectionlist.Add(new Vector3(0f,1f,0f));
		deadangledirectionlist.Add(new Vector3(1f,1f,0f));
		deadangledirectionlist.Add(new Vector3(1f,0f,0f));
		deadangledirectionlist.Add(new Vector3(1f,-1f,0f));
		deadangledirectionlist.Add(new Vector3(0f,-1f,0f));
		deadangledirectionlist.Add(new Vector3(-1f,-1f,0f));
		deadangledirectionlist.Add(new Vector3(-1f,0f,0f));
		deadangledirectionlist.Add(new Vector3(-1f,1f,0f));
		return deadangledirectionlist;
	}

	public override List<Vector3> GetAttackDirectionList()
	{
		List<Vector3> directionlist = new List<Vector3>();
		directionlist.Add(new Vector3(0f,1f,0f));
		//directionlist.Add(new Vector3(1f,1f,0f));
		//directionlist.Add(new Vector3(1f,0f,0f));
		//directionlist.Add(new Vector3(1f,-1f,0f));
		//directionlist.Add(new Vector3(0f,-1f,0f));
		//directionlist.Add(new Vector3(-1f,-1f,0f));
		//directionlist.Add(new Vector3(-1f,0f,0f));
		//directionlist.Add(new Vector3(-1f,1f,0f));
		return directionlist;
	}
}
