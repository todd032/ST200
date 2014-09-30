using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class EnemyDeadEffectObject : DHPoolGameObject {
	
	public float _destroyTime = 0.5f;
	
	
	public GameObject _cellBubbleGameObject ;
	public int _cellBubbleObjectCreateNumber = 1 ;
	
	
	public GameObject _cellGameObject ;
	public int _cellObjectCreateNumber = 1 ;
	
	
	protected List<EnemyEffectBubbleCellSpriteObject> _cellBubbleGameObjectList ;
	protected List<EnemyEffectExplosionCellSpriteObject> _cellGameObjectList ;
	
	
	protected override void Awake() {
		base.Awake() ;
		
		_cellBubbleGameObjectList = new List<EnemyEffectBubbleCellSpriteObject>() ;
		_cellGameObjectList = new List<EnemyEffectExplosionCellSpriteObject>() ;

		
		for(int i =0 ; i < _cellBubbleObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellBubbleGameObject) as GameObject ;
			EnemyEffectBubbleCellSpriteObject _enemyEffectBubbleCellSpriteObject = _go.GetComponent<EnemyEffectBubbleCellSpriteObject>() as EnemyEffectBubbleCellSpriteObject ;
			_enemyEffectBubbleCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_enemyEffectBubbleCellSpriteObject.InitEnemyEffectExplosionCellSpriteObject() ;
			
			_cellBubbleGameObjectList.Add(_enemyEffectBubbleCellSpriteObject) ;
		}
		
		
		for(int i =0 ; i < _cellObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellGameObject) as GameObject ;
			EnemyEffectExplosionCellSpriteObject _enemyEffectExplosionCellSpriteObject = _go.GetComponent<EnemyEffectExplosionCellSpriteObject>() as EnemyEffectExplosionCellSpriteObject ;
			_enemyEffectExplosionCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_enemyEffectExplosionCellSpriteObject.InitEnemyEffectExplosionCellSpriteObject() ;
			
			_cellGameObjectList.Add(_enemyEffectExplosionCellSpriteObject) ;
		}
		
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
		
		
		foreach(EnemyEffectBubbleCellSpriteObject _enemyEffectBubbleCellSpriteObject in _cellBubbleGameObjectList){
			_enemyEffectBubbleCellSpriteObject.ResetEnemyEffectExplosionCellSpriteObject(createPosition) ;
		}
		
		
		foreach(EnemyEffectExplosionCellSpriteObject _enemyEffectExplosionCellSpriteObject in _cellGameObjectList){
			_enemyEffectExplosionCellSpriteObject.ResetEnemyEffectExplosionCellSpriteObject(createPosition) ;
		}
		
	}
	
	public virtual void StartAction(){
		
		foreach(EnemyEffectBubbleCellSpriteObject _enemyEffectBubbleCellSpriteObject in _cellBubbleGameObjectList){
			_enemyEffectBubbleCellSpriteObject.StartMoveAcation() ;
		}
		
		
		foreach(EnemyEffectExplosionCellSpriteObject _enemyEffectExplosionCellSpriteObject in _cellGameObjectList){
			_enemyEffectExplosionCellSpriteObject.StartMoveAcation() ;
		}
		
		
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
