using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShip_Turtle1 : PlayerShip {
	
	public override void Shoot()
	{
		bool shootfront = false;
		bool shootleft = false;
		bool shootright = false;
		
		Vector3 frontdirection = m_LookingVector;
		Vector3 leftdirection = Vector3.Cross(Vector3.forward, m_LookingVector);
		Vector3 rightdirection = -leftdirection;
		

		for(int i = 0; i < m_TargetList.Count; i++)
		{
			Transform enemy = m_TargetList[i];
			if(enemy.gameObject.activeSelf && Vector2.Distance(enemy.transform.position, transform.position) < m_ShipStatInfo.BulletSpeed)
			{
				if(!shootfront)
				{
					if(Vector2.Angle(frontdirection, enemy.transform.position - transform.position) < 10f)
					{
						shootfront = true;
					}
				}
				if(!shootleft)
				{
					if(Vector2.Angle(leftdirection, enemy.transform.position - transform.position) < 10f)
					{
						shootleft = true;
					}
				}
				if(!shootright)
				{
					if(Vector2.Angle(rightdirection, enemy.transform.position - transform.position) < 10f)
					{
						shootright = true;
					}
				}
			}
		}
		//for(int i = 0; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
		//{
		//	GameStageEnemyObject enemy = GameStageManager.Instance.m_ActiveEnemyList[i];
		//	if(Vector2.Distance(enemy.transform.position, transform.position) < m_ShipStatInfo.BulletSpeed)
		//	{
		//		if(!shootfront)
		//		{
		//			if(Vector2.Angle(frontdirection, enemy.transform.position - transform.position) < 10f)
		//			{
		//				shootfront = true;
		//			}
		//		}
		//		if(!shootleft)
		//		{
		//			if(Vector2.Angle(leftdirection, enemy.transform.position - transform.position) < 10f)
		//			{
		//				shootleft = true;
		//			}
		//		}
		//		if(!shootright)
		//		{
		//			if(Vector2.Angle(rightdirection, enemy.transform.position - transform.position) < 10f)
		//			{
		//				shootright = true;
		//			}
		//		}
		//	}
		//}
		
		if(shootfront)
		{
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Player_Shoot, m_ShootTransform[0].position);
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, m_ShootTransform[0].position);
			
			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       AttackDamage, 
			                                       m_ShootTransform[0].position, 
			                                       m_ShootTransform[0].transform.up * m_ShipStatInfo.BulletSpeed, 
			                                       m_ShipStatInfo.BulletPushForce,
			                                       1f,
			                                       TeamIndex,
			                                       1f);
		}
		
		if(shootleft)
		{
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Player_Shoot, m_ShootTransform[1].position);
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, m_ShootTransform[1].position);
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Player_Shoot, m_ShootTransform[2].position);
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, m_ShootTransform[2].position);
			
			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       AttackDamage / 2f, 
			                                       m_ShootTransform[1].position, 
			                                       m_ShootTransform[1].transform.up * m_ShipStatInfo.BulletSpeed, 
			                                       m_ShipStatInfo.BulletPushForce / 2f,
			                                       0.5f,
			                                       TeamIndex,
			                                       1f);
			
			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       AttackDamage / 2f, 
			                                       m_ShootTransform[2].position, 
			                                       m_ShootTransform[2].transform.up * m_ShipStatInfo.BulletSpeed, 
			                                       m_ShipStatInfo.BulletPushForce / 2f,
			                                       0.5f,
			                                       TeamIndex,
			                                       1f);
		}
		
		if(shootright)
		{
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Player_Shoot, m_ShootTransform[3].position);
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, m_ShootTransform[3].position);
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Player_Shoot, m_ShootTransform[4].position);
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, m_ShootTransform[4].position);
			
			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       AttackDamage / 2f, 
			                                       m_ShootTransform[3].position, 
			                                       m_ShootTransform[3].transform.up * m_ShipStatInfo.BulletSpeed, 
			                                       m_ShipStatInfo.BulletPushForce / 2f,
			                                       0.5f,
			                                       TeamIndex,
			                                       1f);
			
			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       AttackDamage / 2f, 
			                                       m_ShootTransform[4].position, 
			                                       m_ShootTransform[4].transform.up * m_ShipStatInfo.BulletSpeed, 
			                                       m_ShipStatInfo.BulletPushForce / 2f,
			                                       0.5f,
			                                       TeamIndex,
			                                       1f);
		}
		
		if(shootright || shootleft || shootfront)
		{
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
		
		Vector3 leftdirection = Vector3.Cross(Vector3.forward, m_LookingVector);
		Vector3 rightdirection = -leftdirection;
		
		if(Vector2.Angle(leftdirection, _worldposition - transform.position) < 10f)
		{
			isinangle = true;
		}
		if(Vector2.Angle(rightdirection, _worldposition - transform.position) < 10f)
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
		//deadangledirectionlist.Add(new Vector3(1f,0f,0f));
		deadangledirectionlist.Add(new Vector3(1f,-1f,0f));
		deadangledirectionlist.Add(new Vector3(0f,-1f,0f));
		deadangledirectionlist.Add(new Vector3(-1f,-1f,0f));
		//deadangledirectionlist.Add(new Vector3(-1f,0f,0f));
		deadangledirectionlist.Add(new Vector3(-1f,1f,0f));
		return deadangledirectionlist;
	}

	public override List<Vector3> GetAttackDirectionList()
	{
		List<Vector3> directionlist = new List<Vector3>();
		directionlist.Add(new Vector3(0f,1f,0f));
		//directionlist.Add(new Vector3(1f,1f,0f));
		directionlist.Add(new Vector3(1f,0f,0f));
		//directionlist.Add(new Vector3(1f,-1f,0f));
		//directionlist.Add(new Vector3(0f,-1f,0f));
		//directionlist.Add(new Vector3(-1f,-1f,0f));
		directionlist.Add(new Vector3(-1f,0f,0f));
		//directionlist.Add(new Vector3(-1f,1f,0f));
		return directionlist;
	}
}
