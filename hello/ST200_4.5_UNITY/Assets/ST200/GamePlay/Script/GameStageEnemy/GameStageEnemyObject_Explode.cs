using UnityEngine;
using System.Collections;

public class GameStageEnemyObject_Explode : GameStageEnemyObject {
	
	public override void Init (PlayerShip _playership, StageEnemyData _enemydata, bool _marked)
	{
		base.Init (_playership, _enemydata, _marked);
		m_ShipAnimation.PlayIdleAnimation();
	}

	public override void PlayDeadAnimation ()
	{
		base.PlayDeadAnimation ();

		StartCoroutine(DeadAnimation());
	}

	public override void Dead ()
	{
		base.Dead ();
		m_ShipAnimation.PlayIdleAnimation();
		//Debug.Log("???");
		gameObject.SetActive(false);
	}
	
	protected IEnumerator DeadAnimation()
	{
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion2, transform.position);
		//set collider false
		m_Collider.enabled = false;
		//play dead sprite animation 
		m_ShipAnimation.PlayDeadAnimation();
		
		yield return new WaitForSeconds(1f);

		Dead();
		yield break;
	}

	public override void OnPlayerCrashEnter (PlayerShip _ship)
	{
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion1, transform.position);
		Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_SHOOT_PLAYER, false);
		_ship.AddHitForce(transform.position, (_ship.transform.position - transform.position).normalized * m_StageEnemyData.SpecialEffectValue2);
		_ship.DoDamage(m_StageEnemyData.SpecialEffectValue, Constant.ST200_GAMEPLAY_DAMAGE_TYPE_EXPLODE);
		PlayDeadAnimation();
	}

	public override void OnPlayerSubShipCrashEnter(PlayerSubShip _ship)
	{
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion1, transform.position);
		Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_SHOOT_PLAYER, false);
		_ship.AddHitForce(transform.position, (_ship.transform.position - transform.position).normalized * m_StageEnemyData.SpecialEffectValue2);
		_ship.DoDamage(m_StageEnemyData.SpecialEffectValue);
		PlayDeadAnimation();
	}

	public override void DefendLinePass ()
	{
		base.DefendLinePass ();
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion1, transform.position);
		PlayDeadAnimation();
	}
}