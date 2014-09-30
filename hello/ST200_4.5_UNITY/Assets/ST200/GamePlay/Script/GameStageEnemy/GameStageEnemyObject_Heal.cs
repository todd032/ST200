using UnityEngine;
using System.Collections;

public class GameStageEnemyObject_Heal : GameStageEnemyObject {

	public GameStageEnemyHealthDisplayer m_SpecialGauge;

	public override void Init (PlayerShip _playership, StageEnemyData _enemydata, bool _marked)
	{
		base.Init (_playership, _enemydata, _marked);
		m_ShipAnimation.PlayIdleAnimation();
	}
	
	float CurSpecialGauge = 0f;
	public override void ProcessAttack(float _timer)
	{
		base.ProcessAttack(_timer);
		CurSpecialGauge += _timer * m_StageEnemyData.SpecialGaugeSpeed;
		if(CurSpecialGauge > m_StageEnemyData.SpecialGaugeMax)
		{
			CurSpecialGauge = 0f;
			Heal ();
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

	public override void DefendLinePass ()
	{
		base.DefendLinePass ();
		PlayDeadAnimation();
	}

	public void Heal()
	{
		for(int i = 0 ; i < GameStageManager.Instance.m_ActiveEnemyList.Count; i++)
		{
			GameStageEnemyObject enemyobject = GameStageManager.Instance.m_ActiveEnemyList[i];
			if(enemyobject != this)
			{
				float radius = m_StageEnemyData.SpecialEffectValue2;
				float distance = Vector2.Distance(enemyobject.transform.position, transform.position);
				if(distance < radius && enemyobject.m_Health > 0f)
				{
					enemyobject.Heal(m_StageEnemyData.SpecialEffectValue);
					GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.HEAL_FX, enemyobject.transform.position);
				}
			}
		}
	}
}
