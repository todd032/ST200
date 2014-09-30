using UnityEngine;
using System.Collections;

public class EnemyMineObject : EnemyObject {

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
	}
	
	public override void ResetPatternObject(float settingValue, float weightLevel){		
        base.ResetPatternObject(settingValue,weightLevel) ;        
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
		
		_enemyState = EnemyState.Pause ;
	}
	
	public override void AnimationResume() {
		base.AnimationResume() ;
		
		_enemyState = EnemyState.Idle ;
			
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
	protected  virtual IEnumerator Idle(){
		
		if(_enemyObjectType == EnemyObjectType.Enemy_None) yield break ;
		
        
		yield return null;
	
		while(_enemyState == EnemyState.Idle) {
			
			_thisTransform.Rotate(Vector3.forward * (5f*Time.timeScale), Space.World);
			
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
		
		if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Enemy_Dead,false);
		
		// Enemy Dead Effect
		GameObject _go = PoolManager.Spawn("EnemyMineDeadEffectObject") ;
		EnemyMineDeadEffectObject _enemyMineDeadEffectObject = _go.GetComponent<EnemyMineDeadEffectObject>() as EnemyMineDeadEffectObject ;
		_enemyMineDeadEffectObject.ResetEffectObject(_thisTransform.position) ;
		_enemyMineDeadEffectObject.StartAction() ;
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
