using UnityEngine;
using System.Collections;

public class SubmarineBulletObject : DHPoolSpriteObject {
	
	
	// FSM
	public enum	FireBulletState { Idle , Clash , Dead , Gone} ;
	protected FireBulletState _fireBulletState = FireBulletState.Idle;
	
	protected int _bulletType ;
	protected float _bulletDamage ;
	protected float _bulletSpeed ;
	protected float m_SlowEffectValue = 1f;
	protected string _currentSpriteName ;
	
	
	protected override void Awake (){
		base.Awake ();
	}
	
	public override void SetActiveSpriteObject(bool isActiveSpriteObject) {
		base.SetActiveSpriteObject(isActiveSpriteObject) ;
	}
	
	public override void DestroySpriteObject(int destroyType) {
		base.	DestroySpriteObject(destroyType) ;
	}
	
	// Use this for initialization
	protected override void Start () {
	
	}
	
	
	//-------
	public virtual Vector2 ResetFireBulletAction(string bulletSpriteName, int bulletType, float bulletDamage, float bulletSpeed, float sloweffectvalue){
		
		_bulletType = bulletType ;
		_bulletDamage = bulletDamage ;
		_bulletSpeed = bulletSpeed ;
		m_SlowEffectValue = sloweffectvalue;
		
		
		
		if( (_currentSpriteName != null) && _currentSpriteName.Equals(bulletSpriteName)) {
			
		}else{
			
			_thisSprite.SetSprite(_thisSprite.Collection.GetSpriteIdByName(bulletSpriteName)) ;
			_spriteSize = new Vector2(_thisSprite.GetBounds().extents.x, _thisSprite.GetBounds().extents.y) ;
			
			_currentSpriteName = bulletSpriteName ;
			
		}
		
		return _spriteSize ;
		
	}
	
	public virtual void FireBulletAction(Vector3 createPosition) {
		
		_thisTransform.position = createPosition ;
		
		_fireBulletState = FireBulletState.Idle ;
		StartCoroutine(_fireBulletState.ToString());
		
	}
	//--------
	
	//--------
	public virtual float CrashActionAndReturnDamage(EnemyObject enemyObject){
		
		float _damage = 0f;
		
		if(_bulletType != 1) {
			_damage = _bulletDamage ;
		}
		
		_fireBulletState = FireBulletState.Clash ;
		
		return _damage ;
	}

	public virtual float CrashActionAndReturnDamage(){
		
		float _damage = 0f;
		
		if(_bulletType != 1) {
			_damage = _bulletDamage ;
		}
		
		_fireBulletState = FireBulletState.Clash ;
		
		return _damage ;
	}

	public virtual float GetSlowEffectValue()
	{
		return m_SlowEffectValue;
	}
	
	
	//---FSM
	protected  virtual IEnumerator Idle(){
		
		
		yield return null;
	
		while(_fireBulletState == FireBulletState.Idle) {
			
			float amtMove = _bulletSpeed * Time.deltaTime;		
			_thisTransform.Translate(Vector3.right * amtMove);
			
			if((_thisTransform.position.x < -(_screenSizeWidth*0.5f) || _thisTransform.position.x > (_screenSizeWidth*0.5f)) ||
				(_thisTransform.position.y < -(_screenSizeHeight*0.5f) || _thisTransform.position.y > (_screenSizeHeight*0.5f)) ){
				_fireBulletState = FireBulletState.Dead ;
			}
			
			yield return null;
			
		}
		
		StartCoroutine(_fireBulletState.ToString());
		
	}
	
	
	
	
	//Clash	
	protected virtual IEnumerator Clash(){
		
		// Spawn Bullet effect..
		if(_bulletType == 1) {
			GameObject _go = PoolManager.Spawn("BulletEffectObjectExplosionType") ;
			BulletEffectObjectExplosionType _bulletEffectObjectExplosionType = _go.GetComponent<BulletEffectObjectExplosionType>() as BulletEffectObjectExplosionType ;
			_bulletEffectObjectExplosionType.ResetEffectObject(_thisTransform.position,_bulletDamage * 0.5f) ;
			_bulletEffectObjectExplosionType.StartAction() ;
		}else{
			GameObject _go = PoolManager.Spawn("BulletEffectObject") ;
			BulletEffectObjectNormalType _bulletEffectObjectNormalType = _go.GetComponent<BulletEffectObjectNormalType>() as BulletEffectObjectNormalType ;
			_bulletEffectObjectNormalType.ResetEffectObject(_thisTransform.position) ;
			_bulletEffectObjectNormalType.StartAction() ;
			//BulletEffectObject _bulletEffectObject = _go.GetComponent<BulletEffectObject>() as BulletEffectObject ;
			//_bulletEffectObject.ResetEffectObject(_thisTransform.position) ;
		}

		
		_fireBulletState = FireBulletState.Gone ;
		
		yield return null;
		
		/*
		while(_fireBulletState == FireBulletState.Clash) {
			
			yield return null;
			
		}
		*/
		
		StartCoroutine(_fireBulletState.ToString());
		
	}
	
	//Dead	
	protected virtual IEnumerator Dead	(){
		
		_fireBulletState = FireBulletState.Gone ;
		
		yield return null;
		
		/*
		while(_fireBulletState == FireBulletState.Dead) {
			
			yield return null;
			
		}
		*/
		
		StartCoroutine(_fireBulletState.ToString());
		
	}
	
	protected virtual IEnumerator Gone(){
		
		DestroySpriteObject(0) ;
		
		yield return null;
		
	}

}
