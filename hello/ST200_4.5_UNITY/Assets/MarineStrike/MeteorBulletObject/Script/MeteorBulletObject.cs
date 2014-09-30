using UnityEngine;
using System.Collections;

public class MeteorBulletObject : DHPoolGameObject {

	protected float _collisionScope = 1.03f ; //screen collision start scope


	public delegate void MeteorBulletObjectDelegate(MeteorBulletObject meteorBulletObject, int state);
	protected MeteorBulletObjectDelegate _meteorBulletObjectDelegate ;
	public event MeteorBulletObjectDelegate MeteorBulletObjectEvent {
		add{
			_meteorBulletObjectDelegate = null ;
			
			if (_meteorBulletObjectDelegate == null)
				_meteorBulletObjectDelegate += value;
		}
		
		remove{
			_meteorBulletObjectDelegate -= value;
		}
	}
	

	protected float _screenSizeHeight ;
	protected float _screenSizeWidth ;
	
	//protected tk2dSprite _thisSprite ; //Caching tk2dSprite.
	protected tk2dAnimatedSprite _thisAnimatedSprite;

	protected Vector2 _spriteSize ;
	protected Vector2 _spriteCenter ;
	
	protected Vector2 _spriteUntrimmedSize ;
	protected Vector2 _spriteUntrimmedCenter ;
	
	public tk2dAnimatedSprite ThisAnimatedSprite 
	{
		get { return _thisAnimatedSprite ; }
	}
	
	public Vector2 SpriteSize 
	{
		get { return _spriteSize ; }
	}
	
	public Vector2 SpriteCenter 
	{
		get { return _spriteCenter ; }
	}


	// FSM
	public enum	EnemyBulletState { Warning, Idle , Ready , Clash , Dead , Gone} ;
	protected EnemyBulletState _enemyBulletState = EnemyBulletState.Idle;
	
	
	// Public
	//public float moveSpeed ;
	//public float initAttackDamage ;

	
	//protected float _enemyAttackDamage ;


	public float _bulletBaseMoveSpeed = 2f ;
	protected float _bulletCurrentMoveSpeed ;
	
	protected override void Awake (){
		base.Awake ();

		_screenSizeHeight = 2f * Camera.main.orthographicSize;
		_screenSizeWidth = _screenSizeHeight * Camera.main.aspect;
		
		//_thisSprite = GetComponent<tk2dSprite>() as tk2dSprite ; //Caching tk2dSprite.

		_thisAnimatedSprite = GetComponent<tk2dAnimatedSprite>() as tk2dAnimatedSprite ;

		_spriteSize = new Vector2(_thisAnimatedSprite.GetBounds().extents.x, _thisAnimatedSprite.GetBounds().extents.y) ;
		_spriteCenter = new Vector2(_thisAnimatedSprite.GetBounds().center.x, _thisAnimatedSprite.GetBounds().center.y) ;		

	}
	
	// Use this for initialization
	protected override void Start () {
		
	}

	public virtual void SetActiveSpriteObject(bool isActiveSpriteObject) {
		_thisGameObject.SetActive(isActiveSpriteObject) ;
	}
	
	public virtual bool IsActiveSpriteObject() {
		return _thisGameObject.activeSelf ;
	}

	public virtual void DestroySpriteObject(int destroyType) {
		//base.DestroySpriteObject(destroyType) ;

		if(destroyType == 0) {
			PoolManager.Despawn(_thisGameObject) ;
			if(_meteorBulletObjectDelegate != null){
				_meteorBulletObjectDelegate(this,0) ;	
			}
		}else if(destroyType == 1){
			_enemyBulletState = EnemyBulletState.Dead ;
		}

	}
	
	
	protected virtual void OnTriggerEnter (Collider coll){

		Vector2 pos = Camera.main.WorldToScreenPoint(_thisTransform.position);
		if(pos.x > Screen.width * _collisionScope) return;
		
		
		if(_enemyBulletState == EnemyBulletState.Dead || _enemyBulletState == EnemyBulletState.Gone) return ;
		
		if (coll.CompareTag("FX_BOOSTER")){
			_enemyBulletState = EnemyBulletState.Dead ;
			return;	
		}
		
		
		if (coll.CompareTag("BULLET")){
			
			if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Damaged,false);

			SubmarineBulletObject _submarineBulletObject = coll.GetComponent<SubmarineBulletObject>() as SubmarineBulletObject ;
			_submarineBulletObject.CrashActionAndReturnDamage() ; //

		}else if (coll.CompareTag("BULLET_SUB")){
			
			if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Damaged,false);
			
			SubweaponBulletObject _subweaponBulletObject = coll.GetComponent<SubweaponBulletObject>() as SubweaponBulletObject ;
			_subweaponBulletObject.CrashActionAndReturnDamage() ; //

		}else if (coll.CompareTag("BULLET_SPREAD")){
			// Nothing...
			if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Damaged,false);

		}else if (coll.CompareTag("SUBMARINE")) {

			_enemyBulletState = EnemyBulletState.Clash;

		}

	}
	
	
	
	//-------
	public void MeteorBulletAction(float createPositionY, float moveSpeed, bool isMomently) {
		
		ThisTransform.position = new Vector3((_screenSizeWidth * 0.5f)+SpriteSize.x, createPositionY, ThisTransform.position.z) ;
		
		_bulletCurrentMoveSpeed = (moveSpeed + _bulletBaseMoveSpeed);

		
		if(isMomently){
			_enemyBulletState = EnemyBulletState.Idle ;	
		}else{
			_enemyBulletState = EnemyBulletState.Warning ;
		}
		
		StartCoroutine(_enemyBulletState.ToString());
		
	}
	
	public void MeteorBulletMomentlyAction(){
		
		if(_enemyBulletState == EnemyBulletState.Warning){
			_enemyBulletState = EnemyBulletState.Idle ;	
		}
		
	}
	
	public void MeteorBulletChangeSpeed(float moveSpeed){
		_bulletCurrentMoveSpeed = (moveSpeed + _bulletBaseMoveSpeed) ;
	}
	
	
	//FSM
	//--------
	private IEnumerator Warning(){


		GameObject _go = PoolManager.Spawn("MeteorWaningObject")  ;
		MeteorWaningObject _meteorWaningObject = _go.GetComponent<MeteorWaningObject>() as MeteorWaningObject ;
		_meteorWaningObject.ResetSpriteObject(ThisTransform.position) ;

		
		float t = 0f ;
		
		yield return null;
		
		while(_enemyBulletState == EnemyBulletState.Warning) {
			
			t += Time.deltaTime ;
			
			if(t >= 1.0f){
				t = 0f ;
				_enemyBulletState = EnemyBulletState.Idle ;
			}
			
			yield return null;
			
		}


		_meteorWaningObject.DestroyGameObject(0) ;


		StartCoroutine(_enemyBulletState.ToString());
		
	}
	
	
	//Idle
	protected  virtual IEnumerator Idle(){

		if(!_thisAnimatedSprite.IsPlaying("MeteorBullet_idle")){
			_thisAnimatedSprite.Play("MeteorBullet_idle");
			_thisAnimatedSprite.animationCompleteDelegate = null ;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}

		
		yield return null;
		
		
		while(_enemyBulletState == EnemyBulletState.Idle) {
			
			float amtMove = _bulletCurrentMoveSpeed * Time.deltaTime;		
			_thisTransform.Translate(-Vector3.right * amtMove, Space.World);

			//_thisTransform.Rotate(Vector3.forward * (10f*Time.timeScale), Space.World);

			
			if(_thisTransform.position.x < (-(_screenSizeWidth*0.5f) - SpriteSize.x)){
				_enemyBulletState = EnemyBulletState.Gone ;
			}
			
			yield return null;
			
		}
		
		StartCoroutine(_enemyBulletState.ToString());
		
	}
	
	//Ready
	private IEnumerator Ready(){
		
		
		yield return null;
		
		while(_enemyBulletState == EnemyBulletState.Ready) {
			
			yield return null;
			
		}
		
		StartCoroutine(_enemyBulletState.ToString());
		
	}
	
	
	//Clash	
	protected virtual IEnumerator Clash(){
		

		// Enemy Dead Effect
		GameObject _go = PoolManager.Spawn("EnemyDeadEffectObject") ;
		EnemyDeadEffectObject _enemyDeadEffectObject = _go.GetComponent<EnemyDeadEffectObject>() as EnemyDeadEffectObject ;
		_enemyDeadEffectObject.ResetEffectObject(_thisTransform.position) ;
		_enemyDeadEffectObject.StartAction() ;
		//
		
		
		_enemyBulletState = EnemyBulletState.Gone ;
		
		yield return null;

		
		StartCoroutine(_enemyBulletState.ToString());
		
	}
	
	//Dead	
	protected virtual IEnumerator Dead(){

		if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Dead,false);
		
		// Enemy Dead Effect
		GameObject _go = PoolManager.Spawn("EnemyDeadEffectObject") ;
		EnemyDeadEffectObject _enemyDeadEffectObject = _go.GetComponent<EnemyDeadEffectObject>() as EnemyDeadEffectObject ;
		_enemyDeadEffectObject.ResetEffectObject(_thisTransform.position) ;
		_enemyDeadEffectObject.StartAction() ;
		//
		
		/*
		int enemyObjectIndex = 0;
		if (_enemyObjectType == EnemyObjectType.Enemy1){
			enemyObjectIndex = 111;
		}else if (_enemyObjectType == EnemyObjectType.Enemy2){
			enemyObjectIndex = 112;
		}else if (_enemyObjectType == EnemyObjectType.Enemy3){
			enemyObjectIndex = 113;
		}else if (_enemyObjectType == EnemyObjectType.Enemy4){
			enemyObjectIndex = 114;
		}else if (_enemyObjectType== EnemyObjectType.Enemy5){
			enemyObjectIndex = 115;
		}else if (_enemyObjectType== EnemyObjectType.Enemy6){
			enemyObjectIndex = 116;
		}else if (_enemyObjectType== EnemyObjectType.Enemy_Mine){
			enemyObjectIndex = 121;
		}
		
		if(_patternObjectStateDelegate != null){
			_patternObjectStateDelegate(this,enemyObjectIndex) ;	
		}
		*/

		if(_meteorBulletObjectDelegate != null){
			_meteorBulletObjectDelegate(this,1) ;	
		}

		_enemyBulletState = EnemyBulletState.Gone ;
		
		yield return null;

		
		StartCoroutine(_enemyBulletState.ToString());
		
	}
	
	protected virtual IEnumerator Gone(){
		
		DestroySpriteObject(0) ;
		
		yield return null;
		
	}
}
