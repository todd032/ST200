using UnityEngine;
using System.Collections;

public class GameStageEnemyObject_ItemShip : GameStageEnemyObject {
	
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

	public override void OnEnemyCrashEnter(GameStageEnemyObject _opp)
	{
		Vector3 myvelocity = m_MoveSpeed;
		Vector3 oppvelocity = _opp.m_MoveSpeed;
		
		Vector3 hitvector = (transform.position - _opp.transform.position).normalized;
		
		Vector3 relativevelocity = oppvelocity - myvelocity;
		
		//Vector3 force = hitvector * Mathf.Max(Vector3.Dot(hitvector, relativevelocity), 0.5f);
		Vector3 force = hitvector * Mathf.Max(Vector3.Dot(hitvector, relativevelocity), 5f);
		m_MoveSpeed += force;
	}
}
