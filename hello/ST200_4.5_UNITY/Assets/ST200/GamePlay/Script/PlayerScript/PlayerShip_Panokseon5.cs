using UnityEngine;
using System.Collections;

public class PlayerShip_Panokseon5 : PlayerShip {

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

			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Player_Shoot, m_ShootTransform[1].position);
			GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, m_ShootTransform[1].position);

			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       AttackDamage / 2f, 
			                                       m_ShootTransform[0].position, 
			                                       m_ShootTransform[0].transform.up * m_ShipStatInfo.BulletSpeed, 
			                                       m_ShipStatInfo.BulletPushForce / 2f,
			                                       0.5f);

			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       AttackDamage / 2f, 
			                                       m_ShootTransform[1].position, 
			                                       m_ShootTransform[1].transform.up * m_ShipStatInfo.BulletSpeed, 
			                                       m_ShipStatInfo.BulletPushForce / 2f,
			                                       0.5f);
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


	public override void DoDamage (float _damage, int _type)
	{

		//GameManager.Instance._cameraShakeScript.DoCameraShake(0.075f, 0.004f);
		Managers.UserData.Vibrate();
		float totaldamage = _damage;
		for(int i = 0; i < m_BuffList.Count; i++)
		{
			if(m_BuffList[i].BuffType == GameShipBuffType.INVINCIBLE)
			{
				totaldamage = 0f;
				break;
			}
		}

		if(_type == Constant.ST200_GAMEPLAY_DAMAGE_TYPE_CRASH)
		{
			totaldamage *= 0.7f;
		}

		if(m_CurHealth > 0f)
		{
			m_CurHealth -= totaldamage;
			GamePlayFXManager.Instance.StartFontFX(Color.red, transform.position, "-" + ((int)totaldamage).ToString()); 
			
			if(m_CurHealth <= 0f)
			{
				PlayDeadAnimation();
			}
		}
		if(m_DamagedDelegate != null)
		{
			m_DamagedDelegate(this, _damage);
		}
	}
}
