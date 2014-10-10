using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStageEnemyObject_Mine : GameStageEnemyObject {

	public List<Transform> m_ShootTransform = new List<Transform>();
	public GameStageEnemyHealthDisplayer m_SpecialGauge;
	
	public override void Init (PlayerShip _playership, StageEnemyData _enemydata, bool _marked)
	{
		base.Init (_playership, _enemydata, _marked);
		m_ShipAnimation.PlayIdleAnimation();
	}
	
	
	float CurSpecialGauge = 0f;
	float MineGauge = 0f;
	public override void ProcessAttack(float _timer)
	{
		base.ProcessAttack(_timer);
		CurSpecialGauge += _timer * m_StageEnemyData.SpecialGaugeSpeed;
		MineGauge += _timer * m_StageEnemyData.SpecialGaugeSpeed;
		if(CurSpecialGauge > m_StageEnemyData.SpecialGaugeMax)
		{
			CurSpecialGauge = 0f;
			Shoot();
		}

		if(MineGauge > m_StageEnemyData.SpecialGaugeMax * 2f)
		{
			MineGauge = 0f;
			ShootMine();
		}
		m_SpecialGauge.UpdateHealth(CurSpecialGauge, m_StageEnemyData.SpecialGaugeMax);
	}
	
	public override void PlayDeadAnimation ()
	{
		base.PlayDeadAnimation ();
		
		StartCoroutine(DeadAnimation());
	}
	
	public override void Dead ()
	{
		base.Dead ();
		gameObject.SetActive(false);
	}
	
	protected IEnumerator DeadAnimation()
	{
		//set collider false
		m_Collider.enabled = false;
		
		//play dead sprite animation 
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion2, transform.position);
		m_ShipAnimation.PlayDeadAnimation();
		
		yield return new WaitForSeconds(1f);
		
		Dead();
		yield break;
	}
	
	public override void Shoot ()
	{
		base.Shoot ();
		
		GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Smoke, transform.position);
		
		float maxdistance = 10f;
		float soundratio = (Mathf.Max(maxdistance - Vector2.Distance(transform.position, m_PlayerShip.transform.position), 0f) / maxdistance);
		Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_SHOOT_ENEMY, false, soundratio);
		
		GameBulletManager.Instance.ShootBullet(GamePlayBulletType.ENEMY_BULLET, 
		                                       m_StageEnemyData.SpecialEffectValue, 
		                                       m_ShootTransform[0].transform.position, 
		                                       m_ShootTransform[0].transform.up * m_StageEnemyData.SpecialEffectValue2, 
		                                       m_StageEnemyData.SpecialEffectValue3, 
		                                       1f,
		                                       0,
		                                       1f);
	}

	protected void ShootMine()
	{
	//	float maxdistance = 10f;
	//	float soundratio = (Mathf.Max(maxdistance - Vector2.Distance(transform.position, m_PlayerShip.transform.position), 0f) / maxdistance);
	//	Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_SHOOT_ENEMY, false, soundratio);
		
		GameBulletManager.Instance.ShootBullet(GamePlayBulletType.ENEMY_MINE, 
		                                       m_StageEnemyData.SpecialEffectValue, 
		                                       m_ShootTransform[1].transform.position, 
		                                       Vector3.zero, 
		                                       m_StageEnemyData.SpecialEffectValue3, 
		                                       1f,
		                                       0,
		                                       10f);
	}
	
	public override void DefendLinePass ()
	{
		base.DefendLinePass ();
		PlayDeadAnimation();
	}
}
