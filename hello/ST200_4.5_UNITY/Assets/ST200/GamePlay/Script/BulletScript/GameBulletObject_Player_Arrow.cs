using UnityEngine;
using System.Collections;

public class GameBulletObject_Player_Arrow : GameBulletObject {
	
	
	public void OnEnemyShipCrash(GameStageEnemyObject _enemyobject)
	{
		GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.ARROW_HIT_FX, transform.position);
		Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_ARROW_HIT, false);
		_enemyobject.AddHitForce(transform.position, m_MoveSpeed.normalized * m_PushForce);
		_enemyobject.DoDamage(m_Damage);
		
		if(m_BulletGoneDelegate != null)
		{
			m_BulletGoneDelegate(this);
		}
	}

	public void OnObstacleCrash()
	{
		GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.ARROW_HIT_FX, transform.position);
		Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_ARROW_HIT, false);
		if(m_BulletGoneDelegate != null)
		{
			m_BulletGoneDelegate(this);
		}
	}

	public void OnPlayerShipHit(PlayerShip _playership)
	{
		if(_playership.TeamIndex != TeamIndex)
		{
			GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.ARROW_HIT_FX, transform.position);
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_ARROW_HIT, false);
			_playership.AddHitForce(transform.position, m_MoveSpeed.normalized * m_PushForce);
			_playership.DoDamage(m_Damage, Constant.ST200_GAMEPLAY_DAMAGE_TYPE_BULLET);
			
			if(m_BulletGoneDelegate != null)
			{
				m_BulletGoneDelegate(this);
			}
		}
	}
	
	public void OnPlayerSubShipHit(PlayerSubShip _ship)
	{
		if(_ship.TeamIndex != TeamIndex)
		{
			GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.ARROW_HIT_FX, transform.position);
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_ARROW_HIT, false);
			_ship.AddHitForce(transform.position, m_MoveSpeed.normalized * m_PushForce);
			_ship.DoDamage(m_Damage);
			
			if(m_BulletGoneDelegate != null)
			{
				m_BulletGoneDelegate(this);
			}
		}
	}


	public override void OnBorderHit()
	{
		base.OnBorderHit();
		
		GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.ARROW_MISS_FX, transform.position);
	}
	
	protected override void OnTriggerEnter2D(Collider2D _col)
	{
		if(_col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			OnEnemyShipCrash(_col.gameObject.GetComponent<GameStageEnemyObject>());
		}else if(_col.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
		{
			OnObstacleCrash();
		}else if(_col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			OnPlayerShipHit(_col.gameObject.GetComponent<PlayerShip>());
		}else if(_col.gameObject.layer == LayerMask.NameToLayer("Player_Sub"))
		{
			OnPlayerSubShipHit(_col.gameObject.GetComponent<PlayerSubShip>());
		}
	}
}
