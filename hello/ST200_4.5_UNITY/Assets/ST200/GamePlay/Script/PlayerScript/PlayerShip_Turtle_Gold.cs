using UnityEngine;
using System.Collections;

public class PlayerShip_Turtle_Gold : PlayerShip {

	protected float m_MineTimer;
	protected float m_FireTimer;
	public override void ProcessAttack(float _timer)
	{
		base.ProcessAttack(_timer);
		m_MineTimer += _timer * AttackGaugeSpeed;
		m_FireTimer += _timer * AttackGaugeSpeed;
		if(m_MineTimer > AttackMaxGauge * 2f)
		{
			ShootMine();
		}

		if(m_FireTimer > AttackMaxGauge / 30f)
		{
			ShootFire();
		}
	}

	public override void Shoot()
	{
		bool shootleft = false;
		bool shootright = false;
		
		Vector3 frontdirection = m_LookingVector;
		Vector3 leftdirection = Vector3.Cross(Vector3.forward, m_LookingVector);
		Vector3 rightdirection = -leftdirection;
		
		for(int i = 0; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
		{
			GameStageEnemyObject enemy = GameStageManager.Instance.m_ActiveEnemyList[i];
			if(Vector2.Distance(enemy.transform.position, transform.position) < m_ShipStatInfo.BulletSpeed)
			{

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
			                                       0.5f);
			
			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       AttackDamage / 2f, 
			                                       m_ShootTransform[2].position, 
			                                       m_ShootTransform[2].transform.up * m_ShipStatInfo.BulletSpeed, 
			                                       m_ShipStatInfo.BulletPushForce / 2f,
			                                       0.5f);
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
			                                       0.5f);
			
			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       AttackDamage / 2f, 
			                                       m_ShootTransform[4].position, 
			                                       m_ShootTransform[4].transform.up * m_ShipStatInfo.BulletSpeed, 
			                                       m_ShipStatInfo.BulletPushForce / 2f,
			                                       0.5f);
		}
		
		if(shootright || shootleft)
		{
			m_AttackTimer -= AttackMaxGauge;
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_SHOOT_PLAYER, false);
			
			if(m_ShootDelegate != null)
			{
				m_ShootDelegate(this);
			}
		}
	}


	public void ShootMine()
	{
		bool fire = false;
		Vector3 direction = -m_LookingVector;
		
		for(int i = 0; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
		{
			GameStageEnemyObject enemy = GameStageManager.Instance.m_ActiveEnemyList[i];
			if(Vector2.Distance(enemy.transform.position, transform.position) < m_ShipStatInfo.BulletSpeed)
			{
				if(!fire)
				{
					if(Vector2.Angle(direction, enemy.transform.position - transform.position) < 30f)
					{
						fire = true;
					}
				}
				//fire = true;
			}
		}

		if(fire)
		{
			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_MINE, 
			                                       AttackDamage, 
			                                       m_ShootTransform[5].position, 
			                                       Vector3.zero, 
			                                       m_ShipStatInfo.BulletPushForce,
			                                       1f);
			m_MineTimer = 0f;
		}
	}

	public void ShootFire()
	{
		bool fire = false;
		Vector3 direction = m_LookingVector;
		for(int i = 0; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
		{
			GameStageEnemyObject enemy = GameStageManager.Instance.m_ActiveEnemyList[i];
			if(Vector2.Distance(enemy.transform.position, transform.position) < m_ShipStatInfo.BulletSpeed)
			{
				if(!fire)
				{
					if(Vector2.Angle(direction, enemy.transform.position - transform.position) < 30f)
					{
						fire = true;
					}
				}
				//fire = true;
			}
		}

		if(fire)
		{
			//GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Player_Shoot, m_ShootTransform[0].position);
			//GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, m_ShootTransform[0].position);
			
			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_FIRE, 
			                                       AttackDamage / 5f, 
			                                       m_ShootTransform[0].position, 
			                                       m_ShootTransform[0].transform.up * m_ShipStatInfo.BulletSpeed, 
			                                       m_ShipStatInfo.BulletPushForce / 5f,
			                                       1f);
			m_FireTimer = 0f;
		}
	}
}