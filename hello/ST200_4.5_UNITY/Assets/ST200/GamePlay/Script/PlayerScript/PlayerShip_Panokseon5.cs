using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShip_Panokseon5 : PlayerShip {

	public override void Shoot()
	{
		bool shootfront = false;
		
		Vector3 frontdirection = m_LookingVector;

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
			}
		}

		//for(int i = 0; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
		//{
		//	GameStageEnemyObject enemy = GameStageManager.Instance.m_ActiveEnemyList[i];
		//
		//	if(Vector2.Distance(enemy.transform.position, transform.position) < m_ShipStatInfo.BulletSpeed)
		//	{
		//		if(!shootfront)
		//		{
		//			if(Vector2.Angle(frontdirection, enemy.transform.position - transform.position) < 10f)
		//			{
		//				shootfront = true;
		//			}
		//		}
		//	}
		//}
		
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
			                                       0.5f,
			                                       TeamIndex,
			                                       1f);

			GameBulletManager.Instance.ShootBullet(GamePlayBulletType.PLAYER_BULLET, 
			                                       AttackDamage / 2f, 
			                                       m_ShootTransform[1].position, 
			                                       m_ShootTransform[1].transform.up * m_ShipStatInfo.BulletSpeed, 
			                                       m_ShipStatInfo.BulletPushForce / 2f,
			                                       0.5f,
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
