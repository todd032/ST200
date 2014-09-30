using UnityEngine;
using System.Collections;

public class GameStageEnemyObject_Normal : GameStageEnemyObject {

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
	}

	
	public override void DefendLinePass ()
	{
		base.DefendLinePass ();
		PlayDeadAnimation();
	}

}
