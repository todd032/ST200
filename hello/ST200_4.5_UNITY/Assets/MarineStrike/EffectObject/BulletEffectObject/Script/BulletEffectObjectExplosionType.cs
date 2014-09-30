using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class BulletEffectObjectExplosionType : DHPoolGameObject {
	
	//
	private float _bulletExplosionDamage ;
	//
	
	public float _destroyTime = 0.5f;
	
	
	public GameObject _baseGameObject ;
	protected BulletEffectExplosionBaseSpriteObject _bulletEffectExplosionBaseSpriteObject ;
	
	public GameObject _splashGameObject ;
	protected BulletEffectExplosionSplashSpriteObject _bulletEffectExplosionSplashSpriteObject ;
	
	public GameObject _cellGameObject ;
	public int _cellObjectCreateNumber = 1 ;
	
	
	protected List<BulletEffectExplosionCellSpriteObject> _cellGameObjectList ;
	
	protected override void Awake() {
		base.Awake() ;
		
		_cellGameObjectList = new List<BulletEffectExplosionCellSpriteObject>() ;
		
		
		GameObject _baseGo = Instantiate(_baseGameObject) as GameObject ;
		_bulletEffectExplosionBaseSpriteObject = _baseGo.GetComponent<BulletEffectExplosionBaseSpriteObject>() as BulletEffectExplosionBaseSpriteObject ;
		_bulletEffectExplosionBaseSpriteObject.ThisTransform.parent = _thisTransform ;
		_bulletEffectExplosionBaseSpriteObject.InitBulletEffectExplosionBaseSpriteObject() ;
		
		
		GameObject _splashGo = Instantiate(_splashGameObject) as GameObject ;
		_bulletEffectExplosionSplashSpriteObject = _splashGo.GetComponent<BulletEffectExplosionSplashSpriteObject>() as BulletEffectExplosionSplashSpriteObject ;
		_bulletEffectExplosionSplashSpriteObject.InitBulletEffectExplosionBaseSpriteObject() ;
		_bulletEffectExplosionSplashSpriteObject.ThisTransform.parent = _thisTransform ;

		
		
		//for(int i =0 ; i < _cellObjectCreateNumber ; i++){
		//	GameObject _go = Instantiate(_cellGameObject) as GameObject ;
		//	BulletEffectExplosionCellSpriteObject _bulletEffectExplosionCellSpriteObject = _go.GetComponent<BulletEffectExplosionCellSpriteObject>() as BulletEffectExplosionCellSpriteObject ;
		//	_bulletEffectExplosionCellSpriteObject.ThisTransform.parent = _thisTransform ;
		//	_bulletEffectExplosionCellSpriteObject.InitBulletEffectExplosionCellSpriteObject() ;
		//	
		//	_cellGameObjectList.Add(_bulletEffectExplosionCellSpriteObject) ;
		//}
		
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
		
		_bulletEffectExplosionBaseSpriteObject.ResetBulletEffectExplosionBaseSpriteObject(createPosition) ;
		
		_bulletEffectExplosionSplashSpriteObject.ResetBulletEffectExplosionBaseSpriteObject(new Vector3(createPosition.x, createPosition.y, createPosition.z-0.01f)) ;
		
		//foreach(BulletEffectExplosionCellSpriteObject _bulletEffectExplosionCellSpriteObject in _cellGameObjectList){
		//	_bulletEffectExplosionCellSpriteObject.ResetBulletEffectExplosionCellSpriteObject(createPosition) ;
		//}
		
	}
	
	public virtual void ResetEffectObject(Vector3 createPosition, float bulletExplosionDamage){
		
		_thisTransform.position = createPosition ;
		
		//
		_bulletExplosionDamage = bulletExplosionDamage ;
		//
		
		_bulletEffectExplosionBaseSpriteObject.ResetBulletEffectExplosionBaseSpriteObject(createPosition) ;
		
		_bulletEffectExplosionSplashSpriteObject.ResetBulletEffectExplosionBaseSpriteObject(createPosition) ;
		//
		//foreach(BulletEffectExplosionCellSpriteObject _bulletEffectExplosionCellSpriteObject in _cellGameObjectList){
		//	_bulletEffectExplosionCellSpriteObject.ResetBulletEffectExplosionCellSpriteObject(createPosition) ;
		//}
		
	}
	
	public virtual void StartAction(){
		
		_bulletEffectExplosionBaseSpriteObject.StartAcation() ;
		
		_bulletEffectExplosionSplashSpriteObject.StartMoveAcation() ;
		//
		//foreach(BulletEffectExplosionCellSpriteObject _bulletEffectExplosionCellSpriteObject in _cellGameObjectList){
		//	_bulletEffectExplosionCellSpriteObject.StartMoveAcation() ;
		//}
		
		StartCoroutine("CheckDestory") ;
		
	}
	
	
	//-------------------
	public float CrashActionAndReturnDamage(EnemyObject enemyObject){
		return _bulletExplosionDamage ;
	}
	
	public float CrashActionAndReturnDamage(){
		return _bulletExplosionDamage ;
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
