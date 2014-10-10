using UnityEngine;
using System.Collections;

public class GameBulletObject_Enemy_Mine : GameBulletObject {

		
	public override void Process(float _timer)
	{
		base.Process(_timer);
	}
	
	public void OnPlayerShipCrash(PlayerShip _player)
	{
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion3, _player.transform.position);
		Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_HIT_SOUND, false);
		_player.AddHitForce(transform.position, m_MoveSpeed.normalized * m_PushForce);
		_player.DoDamage(m_Damage, Constant.ST200_GAMEPLAY_DAMAGE_TYPE_BULLET);
		GameManager.Instance.PlayerHitByBulletEvent();

		if(m_BulletGoneDelegate != null)
		{
			m_BulletGoneDelegate(this);
		}
	}

	public void OnPlayerSubShipCrash(PlayerSubShip _player)
	{
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion3, _player.transform.position);
		Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_HIT_SOUND, false);
		_player.AddHitForce(transform.position, m_MoveSpeed.normalized * m_PushForce);
		_player.DoDamage(m_Damage);
		
		if(m_BulletGoneDelegate != null)
		{
			m_BulletGoneDelegate(this);
		}
	}


	public void OnObstacleCrash()
	{
		GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion3, transform.position);
		Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_BULLET_HIT_SOUND, false);
		if(m_BulletGoneDelegate != null)
		{
			m_BulletGoneDelegate(this);
		}
	}

	public override void OnBorderHit()
	{
		base.OnBorderHit();
		GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Miss, transform.position);
	}
	
	protected override void OnTriggerEnter2D(Collider2D _col)
	{
		if(_col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			OnPlayerShipCrash(_col.gameObject.GetComponent<PlayerShip>());
		}else if(_col.gameObject.layer == LayerMask.NameToLayer("Player_Sub"))
		{
			OnPlayerSubShipCrash(_col.gameObject.GetComponent<PlayerSubShip>());
		}else if(_col.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
		{
			OnObstacleCrash();
		}
	}
}
