using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMeteorObject : EnemyObject {

	protected float _screenSizeHeight ;
	protected float _screenSizeWidth ;
	public Transform _TargetObject;
	public float _bulletCurrentMoveSpeed;

	protected override void Awake () {
		base.Awake ();

		_screenSizeHeight = 2f * Camera.main.orthographicSize;
		_screenSizeWidth = _screenSizeHeight * Camera.main.aspect;
	}
	
	protected override void Start () {
		base.Start();
		
	}
	
	//****** EnemyObject Override ******//
	//-- 
	public override void SetActivePatternObject(bool isActivePatternObject) {
		base.SetActivePatternObject(isActivePatternObject) ;
	}
	
	public override void ResetPatternObject(float settingValue){
		base.ResetPatternObject(settingValue) ;
	}

	public override void ResetPatternObject(float settingValue, float weightLevel){			    
		_currentWeightLevel = weightLevel ;
		
		//if ( damaged_markObject !=null) damaged_markObject.SetActive(false);
		
		_enemyHealth = initEnemyHealth  +  (initEnemyIncreaseHealth * _currentWeightLevel) ;
		_currentHealth = _enemyHealth ;
		
		_healthGaugeComponent.HealthDamage(_enemyHealth , _currentHealth , 0f);
		_enemyState = EnemyState.Idle;
	}
	
	public override void DestroyPatternObject(int destroyType) {
		base.DestroyPatternObject(destroyType) ;
	}
	
	//--
	public void StartPatternObject(Transform _target, float _speed) {
		//Debug.Log("START CALLED");
		_TargetObject = _target;
		ThisTransform.position = new Vector3((_screenSizeWidth * 0.5f)+SpriteSize.x, _TargetObject.position.y, ThisTransform.position.z) ;
		
		_bulletCurrentMoveSpeed = _speed;
		_enemyState = EnemyState.Idle;
		StartCoroutine(_enemyState.ToString());
	}
	
	public override void StopPatternObject() {
		base.StopPatternObject() ;
	}
	
	//--
	public override void AnimationPlay() {
		base.AnimationPlay() ;
	}
	
	public override void AnimationStop() {
		base.AnimationStop() ;
	}
	
	public override void AnimationPause() {
		base.AnimationPause() ;
		
		_enemyState = EnemyState.Pause ;
	}
	
	public override void AnimationResume() {
		base.AnimationResume() ;
		
		_enemyState = EnemyState.Idle ;
		
	}

	public bool isDone()
	{
		return (_enemyState == EnemyState.Gone);
	}

	//--
	
	protected override void SyncData() {
		base.SyncData() ;
	}
	//****** EnemyObject Override End ******//
	
	
	protected override void OnTriggerEnter(Collider coll){
		
		Vector2 pos = Camera.main.WorldToScreenPoint(_thisTransform.position);
		if(pos.x > Screen.width * _collisionScope) return;
		
		
		if(_enemyState == EnemyState.Dead || _enemyState == EnemyState.Gone) return ;
		
		if (coll.CompareTag("FX_BOOSTER")){
			_enemyState = EnemyState.Dead ;
			return;	
		}
		
		
		if (coll.CompareTag("BULLET")){
			
			if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Damaged,false);
			
			SubmarineBulletObject _submarineBulletObject = coll.GetComponent<SubmarineBulletObject>() as SubmarineBulletObject ;
			_submarineBulletObject.CrashActionAndReturnDamage(this) ;
			
		}else if (coll.CompareTag("BULLET_SUB")){
			
			if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Damaged,false);
			
			SubweaponBulletObject _subweaponBulletObject = coll.GetComponent<SubweaponBulletObject>() as SubweaponBulletObject ;
			_subweaponBulletObject.CrashActionAndReturnDamage(this) ;
			
		}else if (coll.CompareTag("BULLET_SPREAD")){
			// Nothing...
			if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Damaged,false);
			
		}else if (coll.CompareTag("SUBMARINE")) {
			
		}else if(coll.CompareTag("SPECIALATTACK"))
		{
			_enemyState = EnemyState.Dead;
		}
		
	}
	
	
	
	
	
	
	//FSM
	//Idle
	bool move = false;
	bool warningcreated = false;
	protected  virtual IEnumerator Idle(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
		move = false;
		warningcreated = false;
		MeteorWaningObject _meteorWaningObject = null;
		yield return null;

		float timer = 0f;
		while(_enemyState == EnemyState.Idle) {
			if(!move)
			{
				if(!warningcreated)
				{
					GameObject _go = PoolManager.Spawn("MeteorWaningObject")  ;
					_meteorWaningObject = _go.GetComponent<MeteorWaningObject>() as MeteorWaningObject ;
					_meteorWaningObject.ResetSpriteObject(ThisTransform.position) ;
					warningcreated = true;
				}else
				{
					timer += Time.deltaTime;
					if(timer > 1f)
					{
						timer = 0f;
						move = true;
						_meteorWaningObject.DestroyGameObject(0);
					}
				}

			}else
			{
				if(!_thisAnimatedSprite.IsPlaying("MeteorBullet_idle2")){
					_thisAnimatedSprite.Play("MeteorBullet_idle2");
					_thisAnimatedSprite.animationCompleteDelegate = null ;
					_thisAnimatedSprite.animationEventDelegate = null ;
				}

				float amtMove = 4f * Time.deltaTime;		//need speed from outside
				_thisTransform.Translate(-Vector3.right * amtMove, Space.World);
								
				if(_thisTransform.position.x < (-(_screenSizeWidth*0.5f) - SpriteSize.x)){
					_enemyState = EnemyState.Gone ;
				}
			}
			//_thisTransform.Rotate(Vector3.forward * (5f*Time.timeScale), Space.World);
			
			yield return null;
			
		}
		
		StartCoroutine(_enemyState.ToString());
		
	}
	
	//Pause
	protected  virtual IEnumerator Pause(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
		yield return null;
		
		while(_enemyState == EnemyState.Pause) {
			
			yield return null;
			
		}
		
		StartCoroutine(_enemyState.ToString());
		
	}
	
	
	protected virtual IEnumerator Dead(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;

		GameObject _go = PoolManager.Spawn("EnemyDeadEffectObject") ;
		EnemyDeadEffectObject _enemyDeadEffectObject = _go.GetComponent<EnemyDeadEffectObject>() as EnemyDeadEffectObject ;
		_enemyDeadEffectObject.ResetEffectObject(_thisTransform.position) ;
		_enemyDeadEffectObject.StartAction() ;

		_enemyState = EnemyState.Gone ;
		
		yield return null;

		StartCoroutine(_enemyState.ToString());
		
	}
	
	protected virtual IEnumerator Gone(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
		DestroyPatternObject(0) ;
		
		yield return null;
		
	}
}
