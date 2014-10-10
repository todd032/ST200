using UnityEngine;
using System.Collections;

public class GameBulletObject_Player_Mine : GameBulletObject {
	
	
	public void OnEnemyShipCrash(GameStageEnemyObject _enemyobject)
	{
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion3, _enemyobject.transform.position);
		Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_HIT_SOUND, false);
		_enemyobject.AddHitForce(transform.position, (_enemyobject.transform.position - transform.position).normalized * m_PushForce);
		_enemyobject.DoDamage(m_Damage);
		
		if(m_BulletGoneDelegate != null)
		{
			m_BulletGoneDelegate(this);
		}
	}
	
	public override void OnBorderHit()
	{
		base.OnBorderHit();
		Debug.Log("does it disappear?");
		GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Miss, transform.position);
	}
	
	protected override void OnTriggerEnter2D(Collider2D _col)
	{
		if(_col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			OnEnemyShipCrash(_col.gameObject.GetComponent<GameStageEnemyObject>());
		}
	}
}