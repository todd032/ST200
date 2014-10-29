using UnityEngine;
using System.Collections;

public class GameBulletObject_Player_Mine : GameBulletObject {
	
	public tk2dSprite m_MineSprite;

	public override void Init (Vector3 _worldpos, float _damage, Vector3 _movespeed, float _pushforce, float _sizeratio, int _teamindex, float _remaintime)
	{
		base.Init (_worldpos, _damage, _movespeed, _pushforce, _sizeratio, _teamindex, _remaintime);
		m_MineSprite.SetSprite(m_MineSprite.GetSpriteIdByName(ImageResourceManager.Instance.GetGamePlayMineSpriteName(_teamindex))); 
	}

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

	public void OnPlayerShipHit(PlayerShip _playership)
	{
		if(_playership.TeamIndex != TeamIndex)
		{
			GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion3, _playership.transform.position);
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
			GamePlayFXManager.Instance.StartExplosionFX(GamePlayExplosionFX_Type.Explosion3, _ship.transform.position);
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
		//Debug.Log("does it disappear?");
		GamePlayFXManager.Instance.StartAttackFX(GamePlayAttackFX_Type.FX_Attack_Miss, transform.position);
	}
	
	protected override void OnTriggerEnter2D(Collider2D _col)
	{
		if(_col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			OnEnemyShipCrash(_col.gameObject.GetComponent<GameStageEnemyObject>());
		}else if(_col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			OnPlayerShipHit(_col.gameObject.GetComponent<PlayerShip>());
		}else if(_col.gameObject.layer == LayerMask.NameToLayer("Player_Sub"))
		{
			OnPlayerSubShipHit(_col.gameObject.GetComponent<PlayerSubShip>());
		}
	}
}