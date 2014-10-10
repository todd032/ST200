using UnityEngine;
using System.Collections;

public class PlayerShip_Panokseon4 : PlayerShip {
	
	protected float m_ArrowTimer;
	protected float m_ArrowMaxGaugeFactor = 5f;
	protected float m_ArrowDistanceFactor = 0.6f;
	public override void ProcessAttack(float _timer)
	{
		base.ProcessAttack(_timer);
		m_ArrowTimer += _timer * AttackGaugeSpeed * m_ArrowMaxGaugeFactor;
		if(m_ArrowTimer > AttackMaxGauge)
		{
			ShootArrow();
		}
	}
	
	public override void Shoot()
	{
		bool shootfront = false;
		
		Vector3 frontdirection = m_LookingVector;
		
		for(int i = 0; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
		{
			GameStageEnemyObject enemy = GameStageManager.Instance.m_ActiveEnemyList[i];
			if(Vector2.Distance(enemy.transform.position, transform.position) < m_ShipStatInfo.BulletSpeed)
			{
				if(!shootfront)
				{
					if(Vector2.Angle(frontdirection, enemy.transform.position - transform.position) < 10f)
					{
						shootfront = true;
					}
				}
			}
		}
		
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

		
		if(shootfront)
		{
			m_AttackTimer -= AttackMaxGauge;
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_SHOOT_PLAYER, false);
			
			if(m_ShootDelegate != null)
			{
				m_ShootDelegate(this);
			}
		}
	}
	
	
	public void ShootArrow()
	{
		bool shootleft = false;
		bool shootright = false;
		
		Vector3 frontdirection = m_LookingVector;
		Vector3 leftdirection = Vector3.Cross(Vector3.forward, m_LookingVector);
		Vector3 rightdirection = -leftdirection;

		Transform m_LeftTarget = null;
		Transform m_RightTarget = null;
		for(int i = 0; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
		{
			GameStageEnemyObject enemy = GameStageManager.Instance.m_ActiveEnemyList[i];
			if(Vector2.Distance(enemy.transform.position, transform.position) < m_ShipStatInfo.BulletSpeed * m_ArrowDistanceFactor)
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
			for(int i = 5; i < 9; i++)
			{
				Vector3 movedirection =  (m_LeftTarget.transform.position - m_ShootTransform[i].transform.position);
				movedirection.z = 0f;
				movedirection.Normalize();
				GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_ARROW, 
				                                       AttackDamage / m_ArrowMaxGaugeFactor / 4f, 
				                                       m_ShootTransform[i].position, 
				                                       movedirection * m_ShipStatInfo.BulletSpeed * m_ArrowDistanceFactor,
				                                       0f,//m_ShipStatInfo.BulletPushForce / m_ArrowMaxGaugeFactor,
				                                       1f,
				                                       TeamIndex,
				                                       1f);
			}
		}
		
		if(shootright)
		{
			for(int i = 1; i < 5; i++)
			{
				Vector3 movedirection =  (m_RightTarget.transform.position - m_ShootTransform[i].transform.position);
				movedirection.z = 0f;
				movedirection.Normalize();
				GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_ARROW, 
				                                       AttackDamage / m_ArrowMaxGaugeFactor / 4f, 
				                                       m_ShootTransform[i].position, 
				                                       movedirection * m_ShipStatInfo.BulletSpeed * m_ArrowDistanceFactor,
				                                       0f,//m_ShipStatInfo.BulletPushForce / m_ArrowMaxGaugeFactor,
				                                       1f,
				                                       TeamIndex,
				                                       1f);
			}
		}
		
		if(shootright || shootleft)
		{
			m_ArrowTimer = 0f;
			//Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_ARROW_SHOOT, false);
			StartCoroutine(ShootArrowFXSound());
		}
	}

	protected IEnumerator ShootArrowFXSound()
	{
		for(int i = 0; i < 4; i++)
		{
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_ARROW_SHOOT, false);
			yield return new WaitForSeconds(0.05f);
		}
	}
}
