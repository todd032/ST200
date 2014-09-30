using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class EnemyExplosionEffectObject : DHPoolGameObject {
	
	public float _destroyTime = 0.5f;
	
	public GameObject _baseGameObject ;
	protected EnemyEffectExplosionBaseSpriteObject _enemyEffectExplosionBaseSpriteObject ;
	
	public GameObject _splashGameObject ;
	protected EnemyEffectExplosionSplashSpriteObject _enemyEffectExplosionSplashSpriteObject ;
	
	//public GameObject _cellGameObject ;
	//public int _cellObjectCreateNumber = 1 ;
	
	
	//protected List<EnemyEffectExplosionCellSpriteObject> _cellGameObjectList ;
	
	protected override void Awake() {
		base.Awake() ;
		
		//_cellGameObjectList = new List<EnemyEffectExplosionCellSpriteObject>() ;
		
		
		GameObject _baseGo = Instantiate(_baseGameObject) as GameObject ;
		_enemyEffectExplosionBaseSpriteObject = _baseGo.GetComponent<EnemyEffectExplosionBaseSpriteObject>() as EnemyEffectExplosionBaseSpriteObject ;
		_enemyEffectExplosionBaseSpriteObject.ThisTransform.parent = _thisTransform ;
		_enemyEffectExplosionBaseSpriteObject.InitEnemyEffectExplosionBaseSpriteObject() ;
		
		
		GameObject _splashGo = Instantiate(_splashGameObject) as GameObject ;
		_enemyEffectExplosionSplashSpriteObject = _splashGo.GetComponent<EnemyEffectExplosionSplashSpriteObject>() as EnemyEffectExplosionSplashSpriteObject ;
		_enemyEffectExplosionSplashSpriteObject.ThisTransform.parent = _thisTransform ;
		_enemyEffectExplosionSplashSpriteObject.InitEnemyEffectExplosionSplashSpriteObject() ;
		
		
		/*
		for(int i =0 ; i < _cellObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellGameObject) as GameObject ;
			EnemyEffectExplosionCellSpriteObject _enemyEffectExplosionCellSpriteObject = _go.GetComponent<EnemyEffectExplosionCellSpriteObject>() as EnemyEffectExplosionCellSpriteObject ;
			_enemyEffectExplosionCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_enemyEffectExplosionCellSpriteObject.InitEnemyEffectExplosionCellSpriteObject() ;
			
			_cellGameObjectList.Add(_enemyEffectExplosionCellSpriteObject) ;
		}
		*/
		
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
		if(destroyType == 0) {
			PoolManager.Despawn(_thisGameObject) ;
		}
	}
	
	public virtual void ResetEffectObject(){
	}
	
	public virtual void ResetEffectObject(Vector3 createPosition){
		
		_thisTransform.position = createPosition ;
		
		_enemyEffectExplosionBaseSpriteObject.ResetEnemyEffectExplosionBaseSpriteObject(createPosition) ;
		
		_enemyEffectExplosionSplashSpriteObject.ResetEnemyEffectExplosionSplashSpriteObject(new Vector3(createPosition.x, createPosition.y, createPosition.z-0.01f)) ;
		
		/*
		foreach(EnemyEffectExplosionCellSpriteObject _enemyEffectExplosionCellSpriteObject in _cellGameObjectList){
			_enemyEffectExplosionCellSpriteObject.ResetEnemyEffectExplosionCellSpriteObject(createPosition) ;
		}
		*/
		
	}
	
	public virtual void StartAction(){
		
		_enemyEffectExplosionBaseSpriteObject.StartAcation() ;
		
		_enemyEffectExplosionSplashSpriteObject.StartMoveAcation() ;
		
		/*
		foreach(EnemyEffectExplosionCellSpriteObject _enemyEffectExplosionCellSpriteObject in _cellGameObjectList){
			_enemyEffectExplosionCellSpriteObject.StartMoveAcation() ;
		}
		*/
		
		StartCoroutine("CheckDestory") ;
		
	}
	
	private IEnumerator CheckDestory(){
		
		float t = 0f ;
		bool isDone = false ;
		
		yield return null ;
		
		while(!isDone){
			
			t += Time.deltaTime ;
			
			if(t >= _destroyTime){
				
				isDone = true ;
			}
			
			yield return null ;
			
		}
		
		DestroySpriteObject(0) ;
		
	}
}
