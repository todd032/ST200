using UnityEngine;
using System.Collections;

public class SubweaponBulletObject : DHPoolSpriteObject {
	
	
	// FSM
	public enum	FireBulletState { Idle , Clash , Dead , Gone} ;
	protected FireBulletState _fireBulletState = FireBulletState.Idle;
	
	private int _bulletType ;
	private float _bulletDamage ;
	private float _bulletSpeed ;
	
	private string _currentSpriteName ;
	
	
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
	public virtual Vector2 ResetFireBulletAction(string bulletSpriteName, int bulletType, float bulletDamage, float bulletSpeed){
		
		_bulletType = bulletType ;
		_bulletDamage = bulletDamage ;
		_bulletSpeed = bulletSpeed ;
		
		
		
		
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
		}else{
			_damage = _bulletDamage ;
		}
		
		_fireBulletState = FireBulletState.Clash ;
		
		return _damage ;
	}

	public virtual float CrashActionAndReturnDamage(){
		
		float _damage = 0f;
		
		if(_bulletType != 1) {
			_damage = _bulletDamage ;
		}else{
			_damage = _bulletDamage ;
		}
		
		_fireBulletState = FireBulletState.Clash ;
		
		return _damage ;
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
			GameObject _go = PoolManager.Spawn("SubweaponBulletEffectObject") ;
			SubweaponBulletEffectObjectNormalType _subweaponBulletEffectObjectNormalType = _go.GetComponent<SubweaponBulletEffectObjectNormalType>() as SubweaponBulletEffectObjectNormalType ;
			_subweaponBulletEffectObjectNormalType.ResetEffectObject(_thisTransform.position) ;
			_subweaponBulletEffectObjectNormalType.StartAction() ;
		}else{
			GameObject _go = PoolManager.Spawn("SubweaponBulletEffectObject") ;
			SubweaponBulletEffectObjectNormalType _subweaponBulletEffectObjectNormalType = _go.GetComponent<SubweaponBulletEffectObjectNormalType>() as SubweaponBulletEffectObjectNormalType ;
			_subweaponBulletEffectObjectNormalType.ResetEffectObject(_thisTransform.position) ;
			_subweaponBulletEffectObjectNormalType.StartAction() ;
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
