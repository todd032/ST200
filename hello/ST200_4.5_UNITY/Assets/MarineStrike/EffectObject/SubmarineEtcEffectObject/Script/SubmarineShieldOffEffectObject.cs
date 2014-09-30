using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SubmarineShieldOffEffectObject : DHPoolGameObject {

	public float _destroyTime = 0.5f;
	
	
	public GameObject _cellBubbleGameObject ;
	public int _cellBubbleObjectCreateNumber = 1 ;
	
	protected List<SubmarineEtcEffectBubbleCellSpriteObject> _cellBubbleGameObjectList ;
	
	
	protected override void Awake() {
		base.Awake() ;
		
		_cellBubbleGameObjectList = new List<SubmarineEtcEffectBubbleCellSpriteObject>() ;

		
		for(int i =0 ; i < _cellBubbleObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellBubbleGameObject) as GameObject ;
			SubmarineEtcEffectBubbleCellSpriteObject _submarineEtcEffectBubbleCellSpriteObject = _go.GetComponent<SubmarineEtcEffectBubbleCellSpriteObject>() as SubmarineEtcEffectBubbleCellSpriteObject ;
			_submarineEtcEffectBubbleCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineEtcEffectBubbleCellSpriteObject.InitSubmarineEtcEffectBubbleCellSpriteObject() ;
			
			_cellBubbleGameObjectList.Add(_submarineEtcEffectBubbleCellSpriteObject) ;
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
		
		
	}
	
	public virtual void StartAction(){
		
		foreach(SubmarineEtcEffectBubbleCellSpriteObject _submarineEtcEffectBubbleCellSpriteObject in _cellBubbleGameObjectList){
			_submarineEtcEffectBubbleCellSpriteObject.StartMoveAcation() ;
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
