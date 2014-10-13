using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBulletObject_Player_Fire : GameBulletObject {
		
	protected List<GameStageEnemyObject> m_HitEnemyObject = new List<GameStageEnemyObject>();
	protected float m_AnimTimer = 0f;

	public override void Init (Vector3 _worldpos, float _damage, Vector3 _movespeed, float _pushforce, float _sizeratio, int _teamindex, float _remaintime)
	{
		base.Init (_worldpos, _damage, _movespeed, _pushforce, _sizeratio, _teamindex, _remaintime);
		m_AnimTimer = 0f;
	}

	public override void Process (float _timer)
	{
		base.Process (_timer);
		ProcessFireDamage(_timer);
		ProcessFireAnim(_timer);
	}

	protected void ProcessFireDamage(float _timer)
	{
		for(int i = 0; i < m_HitEnemyObject.Count; i++)
		{
			m_HitEnemyObject[i].DoDamage(m_Damage * _timer);
		}
	}


	protected void ProcessFireAnim(float _timer)
	{
		m_AnimTimer += _timer;
		m_BulletSprite.scale = Vector3.Lerp(Vector3.one * 0.3f, Vector3.one, m_AnimTimer);
		float alpha = 1f - ( m_AnimTimer) * 0.25f;
		Color curcolor = m_BulletSprite.color;
		curcolor.a = alpha;
		m_BulletSprite.color = curcolor;
	}

	public void OnEnemyShipCrash(GameStageEnemyObject _enemyobject)
	{
		Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_ARROW_HIT, false);
		_enemyobject.DoDamage(m_Damage);
		_enemyobject.AddHitForce(transform.position, m_MoveSpeed.normalized * m_PushForce);
		if(m_BulletGoneDelegate != null)
		{
			m_BulletGoneDelegate(this);
		}
		//if(!m_HitEnemyObject.Contains(_enemyobject))
		//{
		//	m_HitEnemyObject.Add(_enemyobject);
		//}
	}
	public void OnPlayerShipHit(PlayerShip _playership)
	{
		if(_playership.TeamIndex != TeamIndex)
		{
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
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_ARROW_HIT, false);
			_ship.AddHitForce(transform.position, m_MoveSpeed.normalized * m_PushForce);
			_ship.DoDamage(m_Damage);
			
			if(m_BulletGoneDelegate != null)
			{
				m_BulletGoneDelegate(this);
			}
		}
	}

	protected void OnEnemyShipExit(GameStageEnemyObject _enemyobject)
	{
		if(m_HitEnemyObject.Contains(_enemyobject))
		{
			m_HitEnemyObject.Remove(_enemyobject);
		}
	}

	public void OnObstacleCrash()
	{
		//GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.ARROW_HIT_FX, transform.position);
		//Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_ARROW_HIT, false);
		m_HitEnemyObject.Clear ();
		if(m_BulletGoneDelegate != null)
		{
			m_BulletGoneDelegate(this);
		}
	}

	public override void OnBorderHit()
	{
		base.OnBorderHit();
		m_HitEnemyObject.Clear();
		//GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.ARROW_MISS_FX, transform.position);
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

	protected void OnTriggerExit2D(Collider2D _col)
	{
		if(_col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			OnEnemyShipExit(_col.gameObject.GetComponent<GameStageEnemyObject>());
		}
	}
}
