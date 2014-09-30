using UnityEngine;
using System.Collections;

public class EnemyArmorObject : EnemyObject {
	
	public GameObject _damageMarkIcon ;
	
	protected bool isArmor = true ;
	
	protected override void Awake () {
		base.Awake ();
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
		
		// Damage Mark Icon Invisible
		if(_damageMarkIcon != null){
			_damageMarkIcon.SetActive(false) ;	
		}
		//
		
	}
	
	public override void ResetPatternObject(float settingValue, float weightLevel){		
        base.ResetPatternObject(settingValue,weightLevel) ;
		
		// Damage Mark Icon Invisible
		if(_damageMarkIcon != null){
			_damageMarkIcon.SetActive(false) ;	
		}
		//
		
		isArmor = true ;
		
    }
	
	public override void DestroyPatternObject(int destroyType) {
		base.DestroyPatternObject(destroyType) ;
	}
	
	//--
	public override void StartPatternObject() {
		base.StartPatternObject() ;
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
	}
	
	public override void AnimationResume() {
		base.AnimationResume() ;
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
		
	
		float bulletdamage=0f; 
		
		if (coll.CompareTag("BULLET")){
			if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Damaged,false);
			
			SubmarineBulletObject _submarineBulletObject = coll.GetComponent<SubmarineBulletObject>() as SubmarineBulletObject ;
			bulletdamage = _submarineBulletObject.CrashActionAndReturnDamage(this) ;
			
		}else if (coll.CompareTag("BULLET_SUB")){
			
			if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Damaged,false);
			
			SubweaponBulletObject _subweaponBulletObject = coll.GetComponent<SubweaponBulletObject>() as SubweaponBulletObject ;
			bulletdamage = _subweaponBulletObject.CrashActionAndReturnDamage(this) ;
			
		}else if (coll.CompareTag("BULLET_SPREAD")){
			
			if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Damaged,false);
			
			BulletEffectObjectExplosionType _bulletEffectObjectExplosionType = coll.GetComponent<BulletEffectObjectExplosionType>() as BulletEffectObjectExplosionType ;
			bulletdamage = _bulletEffectObjectExplosionType.CrashActionAndReturnDamage() ;
			
	 	}else if (coll.CompareTag("SUBMARINE")) {
			StartCoroutine("Damaged") ;
		}else if(coll.CompareTag("SPECIALATTACK"))
		{
			if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Damaged,false);
			bulletdamage = _enemyHealth;
			isArmor = false;
		}
		
		
		if (bulletdamage <= 0 ) return;

		_healthGaugeComponent.HealthDamage(_enemyHealth , _currentHealth , bulletdamage);
			
		_currentHealth -= bulletdamage;
		
		
		if ( _currentHealth > 0.0f){
			//remain health
			if(isArmor){
				//_enemyState = EnemyState.Crash;	
				StartCoroutine("Damaged") ;
				
			}else{
				//_enemyState = EnemyState.SubCrash;	
				StartCoroutine("SubDamaged") ;
				
			}
			
		}else {
			//remain die
			if(isArmor){
				
				StopCoroutine("Damaged") ;
				
				// Damage Mark Icon Invisible
				if(_damageMarkIcon != null){
					_damageMarkIcon.SetActive(false) ;	
				}
				//
				
				
				// Enemy Dead Effect
				GameObject _go = PoolManager.Spawn("EnemyDeadEffectObject") ;
				EnemyDeadEffectObject _enemyDeadEffectObject = _go.GetComponent<EnemyDeadEffectObject>() as EnemyDeadEffectObject ;
				_enemyDeadEffectObject.ResetEffectObject(_thisTransform.position) ;
				_enemyDeadEffectObject.StartAction() ;
				//
				
				
				_enemyHealth = (initEnemyHealth  +  (initEnemyIncreaseHealth * _currentWeightLevel)) * 0.7f ; //70%
				_currentHealth = _enemyHealth ;
		
				_enemyState = EnemyState.SubIdle ;
				
				isArmor = false ;
				
			}else{
				
				StopCoroutine("SubDamaged") ;
				
				// Damage Mark Icon Invisible
				if(_damageMarkIcon != null){
					_damageMarkIcon.SetActive(false) ;	
				}
				//
				
				_enemyState = EnemyState.Dead ;	
			}
			
		}
	}
	
	
	
	//Damaged
	private void EnemyDamagedCompleteDelegate(tk2dAnimatedSprite sprite, int clipId) {
		
		// Damage Mark Icon Invisible
		if(_damageMarkIcon != null){
			_damageMarkIcon.SetActive(false) ;	
		}
		//
		
		string animationName =  "Ani_" + _enemyObjectType.ToString() + "_idle";
		if(!_thisAnimatedSprite.IsPlaying(animationName)){
			_thisAnimatedSprite.Play(animationName);
			_thisAnimatedSprite.animationCompleteDelegate = null ;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
	}
	
	protected virtual IEnumerator Damaged(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
		// Damage Mark Icon Visible
		if(_damageMarkIcon != null){
			_damageMarkIcon.SetActive(true) ;	
		}
		//
		
		string animationName =  "Ani_" + _enemyObjectType.ToString() + "_damaged";
		if(!_thisAnimatedSprite.IsPlaying(animationName)){
			_thisAnimatedSprite.Play(animationName);
			_thisAnimatedSprite.animationCompleteDelegate =  EnemyDamagedCompleteDelegate;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
		
		yield return null;
		
	}
	
	
	//Sub Damaged
	private void EnemySubDamagedCompleteDelegate(tk2dAnimatedSprite sprite, int clipId) {
		
		// Damage Mark Icon Invisible
		if(_damageMarkIcon != null){
			_damageMarkIcon.SetActive(false) ;	
		}
		//
		
		string animationName =  "Ani_" + _enemyObjectType.ToString() + "_sub_idle";
		if(!_thisAnimatedSprite.IsPlaying(animationName)){
			_thisAnimatedSprite.Play(animationName);
			_thisAnimatedSprite.animationCompleteDelegate = null ;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
	}
	
	protected virtual IEnumerator SubDamaged(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
		// Damage Mark Icon Visible
		if(_damageMarkIcon != null){
			_damageMarkIcon.SetActive(true) ;	
		}
		//
		
		string animationName =  "Ani_" + _enemyObjectType.ToString() + "_sub_damaged";
		if(!_thisAnimatedSprite.IsPlaying(animationName)){
			_thisAnimatedSprite.Play(animationName);
			_thisAnimatedSprite.animationCompleteDelegate =  EnemySubDamagedCompleteDelegate;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
		
		yield return null;
		
	}
	
	
	
	//FSM
	//Idle
	protected  virtual IEnumerator Idle(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
		
		string animationName =  "Ani_" + _enemyObjectType.ToString() + "_idle";
		if(!_thisAnimatedSprite.IsPlaying(animationName)){
			_thisAnimatedSprite.Play(animationName);
			_thisAnimatedSprite.animationCompleteDelegate = null ;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
        
		yield return null;
	
		while(_enemyState == EnemyState.Idle) {

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
	
	/*
	//Crash
	private void EnemyCrashCompleteDelegate(tk2dAnimatedSprite sprite, int clipId) {
		_enemyState = EnemyState.Idle ;
	}
	
	protected virtual IEnumerator Crash(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
		//
		
		string animationName =  "Ani_" + _enemyObjectType.ToString() + "_damaged";
		if(!_thisAnimatedSprite.IsPlaying(animationName)){
			_thisAnimatedSprite.Play(animationName);
			_thisAnimatedSprite.animationCompleteDelegate =  EnemyCrashCompleteDelegate;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
		
		yield return null;
		
		
		while(_enemyState == EnemyState.Crash) {
			
			yield return null;
			
		}
		
		StartCoroutine(_enemyState.ToString());
		
	}
	*/
	
	protected  virtual IEnumerator SubIdle(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
		
		string animationName =  "Ani_" + _enemyObjectType.ToString() + "_sub_idle";
		if(!_thisAnimatedSprite.IsPlaying(animationName)){
			_thisAnimatedSprite.Play(animationName);
			_thisAnimatedSprite.animationCompleteDelegate = null ;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
        
		yield return null;
	
		while(_enemyState == EnemyState.SubIdle) {

			yield return null;
			
		}
		
		StartCoroutine(_enemyState.ToString());
		
	}
	
	/*
	private void EnemySubCrashCompleteDelegate(tk2dAnimatedSprite sprite, int clipId) {
		_enemyState = EnemyState.SubIdle ;
	}
	
	protected virtual IEnumerator SubCrash(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
		//
		
		string animationName =  "Ani_" + _enemyObjectType.ToString() + "_sub_damaged";
		if(!_thisAnimatedSprite.IsPlaying(animationName)){
			_thisAnimatedSprite.Play(animationName);
			_thisAnimatedSprite.animationCompleteDelegate =  EnemySubCrashCompleteDelegate;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
		
		yield return null;
		
		
		while(_enemyState == EnemyState.SubCrash) {
			
			yield return null;
			
		}
		
		StartCoroutine(_enemyState.ToString());
		
	}
	*/
	
	protected virtual IEnumerator Dead(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
		if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Dead,false);
		
		// Enemy Dead Effect
		GameObject _go = PoolManager.Spawn("EnemyDeadEffectObject") ;
		EnemyDeadEffectObject _enemyDeadEffectObject = _go.GetComponent<EnemyDeadEffectObject>() as EnemyDeadEffectObject ;
		_enemyDeadEffectObject.ResetEffectObject(_thisTransform.position) ;
		_enemyDeadEffectObject.StartAction() ;
		//
		
		
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
		
		_enemyState = EnemyState.Gone ;
		
		//yield return null;
		
		/*
		while(_enemyState == EnemyState.Dead) {
			
			yield return null;
			
		}
		*/
		
		StartCoroutine(_enemyState.ToString());
		
	}
	
	protected virtual IEnumerator Gone(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
		DestroyPatternObject(0) ;
		
		yield return null;
		
	}
}
