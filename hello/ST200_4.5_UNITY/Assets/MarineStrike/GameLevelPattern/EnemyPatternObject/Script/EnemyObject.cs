using UnityEngine;
using System.Collections;

public class EnemyObject : PatternObject {

	public enum EnemyObjectType { Enemy_None = 0, Enemy1=1, Enemy2=2, Enemy3=3, Enemy4=4, Enemy5=5, Enemy6=6, Enemy_Mine=51,
		Enemy7=7, Enemy8=8,}	;
	public EnemyObjectType _enemyObjectType = EnemyObjectType.Enemy_None;
	
	
	// FSM
	//public enum EnemyState { Idle, Pause, Crash, SubIdle, SubCrash, Explosion, Dead, Gone} ;
	public enum EnemyState { Idle, Pause, SubIdle, Explosion, Dead, Gone} ;
	protected EnemyState _enemyState = EnemyState.Idle;
	
	
	// HealthGauge
	public Transform healthGauge;
	public Vector2 healthGaugePosition;
	protected HealthGauge _healthGaugeComponent;
	
	
	// Protected
	protected tk2dAnimatedSprite _thisAnimatedSprite;
	
	protected float initEnemyHealth ;
	protected float initEnemyIncreaseHealth ;
	protected float initEnemyAttackDamage ; // == Crash Damage
	
	
	protected float _enemyHealth ;
	protected float _enemyAttackDamage ;
	protected float _currentHealth	;
	
	
	protected float _collisionScope = 1.03f ; //screen collision start scope
	
	protected float _currentWeightLevel ;
	

	
 	protected override void Awake () {
		base.Awake ();
	
		_thisAnimatedSprite = GetComponentInChildren<tk2dAnimatedSprite>() as tk2dAnimatedSprite;
		
		Transform healthGaugeTransform = Instantiate(healthGauge) as Transform;
        healthGaugeTransform.parent = _thisTransform;
		healthGaugeTransform.localPosition = new Vector3 (healthGaugePosition.x , healthGaugePosition.y , _thisTransform.localPosition.z);
		_healthGaugeComponent = healthGaugeTransform.GetComponent<HealthGauge>() as HealthGauge;
		
		
		SyncData() ;
		
	}
	
	protected override void Start () {
		base.Start();
		
	}
	
	//****** PatternObject Override ******//
	//-- 
	public override void SetActivePatternObject(bool isActivePatternObject) {
		base.SetActivePatternObject(isActivePatternObject) ;
	}
	
	public override void ResetPatternObject(float settingValue){
		base.ResetPatternObject(settingValue) ;
	}
	
	
	public override void ResetPatternObject(float settingValue, float weightLevel){		
        base.ResetPatternObject(settingValue,weightLevel) ;

		_currentWeightLevel = weightLevel ;
		
		//if ( damaged_markObject !=null) damaged_markObject.SetActive(false);
		
		_enemyHealth = initEnemyHealth  +  (initEnemyIncreaseHealth * _currentWeightLevel) ;
		_currentHealth = _enemyHealth ;
		
		_healthGaugeComponent.HealthDamage(_enemyHealth , _currentHealth , 0f);
		
		_enemyState = EnemyState.Idle;
		StartCoroutine(_enemyState.ToString());
		//Debug.Log ("ENEMY HEALTH: " + _enemyHealth);
    }
	
	public override void DestroyPatternObject(int destroyType) {
		base.DestroyPatternObject(destroyType) ;
		
		if(destroyType == 1) {
			if(_thisGameObject.activeSelf) {
				_enemyState = EnemyState.Dead ;
			}
		}
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
		
		if(_thisAnimatedSprite != null && !_thisAnimatedSprite.Paused){
			_thisAnimatedSprite.Pause() ;
		}
		
	}
	
	public override void AnimationResume() {
		base.AnimationResume() ;
		
		if(_thisAnimatedSprite != null && _thisAnimatedSprite.Paused){
			_thisAnimatedSprite.Resume() ;
		}
		
	}
	//--
	//****** PatternObject Override End ******//
	
	
	protected virtual void SyncData() {

		
	}
	
	protected virtual void OnTriggerEnter (Collider coll){
		
	}
	
}
