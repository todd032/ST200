using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SubmarineStartBoosterReadyEffectObject : DHPoolGameObject {

	public GameObject _baseGameObject ;
	public int _baseObjectCreateNumber = 1 ;
	
	public GameObject _cellGameObject ;
	public int _cellObjectCreateNumber = 1 ;
	
	
	protected List<SubmarineEtcEffectGatherBaseSpriteObject> _baseGameObjectList ;
	protected List<SubmarineEtcEffectGatherCellSpriteObject> _cellGameObjectList ;
	
	
	protected override void Awake() {
		base.Awake() ;
		
		_baseGameObjectList = new List<SubmarineEtcEffectGatherBaseSpriteObject>() ;
		_cellGameObjectList = new List<SubmarineEtcEffectGatherCellSpriteObject>() ;
		
		
		for(int i =0 ; i < _baseObjectCreateNumber ; i++){
			GameObject _baseGo = Instantiate(_baseGameObject) as GameObject ;
			SubmarineEtcEffectGatherBaseSpriteObject _submarineEtcEffectGatherBaseSpriteObject = _baseGo.GetComponent<SubmarineEtcEffectGatherBaseSpriteObject>() as SubmarineEtcEffectGatherBaseSpriteObject ;
			_submarineEtcEffectGatherBaseSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineEtcEffectGatherBaseSpriteObject.InitSubmarineEtcEffectGatherBaseSpriteObject(Color.white) ;
			
			_baseGameObjectList.Add(_submarineEtcEffectGatherBaseSpriteObject) ;
		}
		
		
		for(int i =0 ; i < _cellObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellGameObject) as GameObject ;
			SubmarineEtcEffectGatherCellSpriteObject _submarineEtcEffectGatherCellSpriteObject = _go.GetComponent<SubmarineEtcEffectGatherCellSpriteObject>() as SubmarineEtcEffectGatherCellSpriteObject ;
			_submarineEtcEffectGatherCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineEtcEffectGatherCellSpriteObject.InitSubmarineEtcEffectGatherCellSpriteObject(Color.white) ;
			
			_cellGameObjectList.Add(_submarineEtcEffectGatherCellSpriteObject) ;
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
			StopCoroutine("EffectStart") ;
			PoolManager.Despawn(_thisGameObject) ;
		}
	}
	
	public virtual void ResetEffectObject(){
	}
	
	public virtual void ResetEffectObject(Vector3 createPosition, Color _color){

		m_FollowTransform = null;
		_thisTransform.position = createPosition ;
		
		foreach(SubmarineEtcEffectGatherBaseSpriteObject _submarineEtcEffectGatherBaseSpriteObject in _baseGameObjectList){
			_submarineEtcEffectGatherBaseSpriteObject.InitSubmarineEtcEffectGatherBaseSpriteObject(_color) ;
		}
		
		foreach(SubmarineEtcEffectGatherCellSpriteObject _submarineEtcEffectGatherCellSpriteObject in _cellGameObjectList){
			_submarineEtcEffectGatherCellSpriteObject.InitSubmarineEtcEffectGatherCellSpriteObject(_color) ;
		}
		
	}

	protected Transform m_FollowTransform;
	public virtual void ResetEffectObject(Transform _transform, Color _color){

		m_FollowTransform = _transform;
		_thisTransform.position = _transform.position - Vector3.forward * 2f;
		
		foreach(SubmarineEtcEffectGatherBaseSpriteObject _submarineEtcEffectGatherBaseSpriteObject in _baseGameObjectList){
			_submarineEtcEffectGatherBaseSpriteObject.InitSubmarineEtcEffectGatherBaseSpriteObject(_color) ;
		}
		
		foreach(SubmarineEtcEffectGatherCellSpriteObject _submarineEtcEffectGatherCellSpriteObject in _cellGameObjectList){
			_submarineEtcEffectGatherCellSpriteObject.InitSubmarineEtcEffectGatherCellSpriteObject(_color) ;
		}
		
	}

	public virtual void StartAction(){
		
		StartCoroutine("EffectStart") ;
		
	}
	
	public virtual IEnumerator EffectStart(){
		
		float ballT = 0f ;
		float splashT = 0f ;
		
		yield return null ;
		
		
		while(true){

			if(m_FollowTransform != null)
			{
				transform.position = m_FollowTransform.position - Vector3.forward * 2f;
			}

			ballT += Time.deltaTime ;
			splashT += Time.deltaTime ;
			
			if(ballT >= 0.02f){
				
				SubmarineEtcEffectGatherCellSpriteObject selectObject = null ;
				
				foreach(SubmarineEtcEffectGatherCellSpriteObject _submarineEtcEffectGatherCellSpriteObject in _cellGameObjectList){
					if(!_submarineEtcEffectGatherCellSpriteObject.IsActiveSpriteObject()){
						selectObject = _submarineEtcEffectGatherCellSpriteObject ;
						break ;	
					}
				}
				
				if(selectObject != null){
					selectObject.ResetSubmarineEtcEffectGatherCellSpriteObject(_thisTransform.position) ;
					selectObject.StartMoveAcation() ;
					ballT = 0f ;
				}
				
			}
			
			
			if(splashT >= 0.3f){
				
				SubmarineEtcEffectGatherBaseSpriteObject selectObject = null ;
				
				foreach(SubmarineEtcEffectGatherBaseSpriteObject _submarineEtcEffectGatherBaseSpriteObject in _baseGameObjectList){
					if(!_submarineEtcEffectGatherBaseSpriteObject.IsActiveSpriteObject()){
						selectObject = _submarineEtcEffectGatherBaseSpriteObject ;
						break ;	
					}
				}
				
				if(selectObject != null){
					selectObject.ResetSubmarineEtcEffectGatherBaseSpriteObject(_thisTransform.position) ;
					selectObject.StartMoveAcation() ;
					splashT = 0f ;
				}
				
			}
			
			yield return null ;
			
		}
		
		
	}
	
}
