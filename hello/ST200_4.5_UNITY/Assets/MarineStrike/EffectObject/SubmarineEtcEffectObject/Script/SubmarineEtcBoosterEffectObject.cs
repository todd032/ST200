using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SubmarineEtcBoosterEffectObject : DHPoolGameObject {

	public float _destroyTime = 0.5f;
	
	
	public GameObject _cellBubbleGameObject ;
	public int _cellBubbleObjectCreateNumber = 1 ;
	
	
	public GameObject _cellGameObject ;
	public int _cellObjectCreateNumber = 1 ;
	
	
	protected List<SubmarineEtcEffectBubbleCellSpriteObject> _cellBubbleGameObjectList ;
	protected List<SubmarineEtcEffectExplosionCellSpriteObject> _cellGameObjectList ;
	
	
	protected override void Awake() {

		base.Awake() ;
		
		_cellBubbleGameObjectList = new List<SubmarineEtcEffectBubbleCellSpriteObject>() ;
		_cellGameObjectList = new List<SubmarineEtcEffectExplosionCellSpriteObject>() ;

		
		for(int i =0 ; i < _cellBubbleObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellBubbleGameObject) as GameObject ;
			SubmarineEtcEffectBubbleCellSpriteObject _submarineEtcEffectBubbleCellSpriteObject = _go.GetComponent<SubmarineEtcEffectBubbleCellSpriteObject>() as SubmarineEtcEffectBubbleCellSpriteObject ;
			_submarineEtcEffectBubbleCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineEtcEffectBubbleCellSpriteObject.InitSubmarineEtcEffectBubbleCellSpriteObject() ;
			
			_cellBubbleGameObjectList.Add(_submarineEtcEffectBubbleCellSpriteObject) ;
		}
		
		
		for(int i =0 ; i < _cellObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellGameObject) as GameObject ;
			SubmarineEtcEffectExplosionCellSpriteObject _submarineEtcEffectExplosionCellSpriteObject = _go.GetComponent<SubmarineEtcEffectExplosionCellSpriteObject>() as SubmarineEtcEffectExplosionCellSpriteObject ;
			_submarineEtcEffectExplosionCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineEtcEffectExplosionCellSpriteObject.InitSubmarineEtcEffectExplosionCellSpriteObject() ;
			
			_cellGameObjectList.Add(_submarineEtcEffectExplosionCellSpriteObject) ;
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
		
		
		foreach(SubmarineEtcEffectBubbleCellSpriteObject _submarineEtcEffectBubbleCellSpriteObject in _cellBubbleGameObjectList){
			_submarineEtcEffectBubbleCellSpriteObject.ResetSubmarineEtcEffectBubbleCellSpriteObject(createPosition) ;
		}
		
		
		foreach(SubmarineEtcEffectExplosionCellSpriteObject _submarineEtcEffectExplosionCellSpriteObject in _cellGameObjectList){
			_submarineEtcEffectExplosionCellSpriteObject.ResetSubmarineEtcEffectExplosionCellSpriteObject(createPosition) ;
		}
		
	}
	
	public virtual void StartAction(){
		
		foreach(SubmarineEtcEffectBubbleCellSpriteObject _submarineEtcEffectBubbleCellSpriteObject in _cellBubbleGameObjectList){
			_submarineEtcEffectBubbleCellSpriteObject.StartMoveAcation() ;
		}
		
		
		foreach(SubmarineEtcEffectExplosionCellSpriteObject _submarineEtcEffectExplosionCellSpriteObject in _cellGameObjectList){
			_submarineEtcEffectExplosionCellSpriteObject.StartMoveAcation() ;
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
