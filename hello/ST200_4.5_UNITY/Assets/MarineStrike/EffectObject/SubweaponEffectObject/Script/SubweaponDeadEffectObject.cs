using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SubweaponDeadEffectObject : DHPoolGameObject {

	public float _destroyTime = 0.5f;
	
	public GameObject _cellGameObject ;
	public int _cellObjectCreateNumber = 1 ;
	
	
	protected List<SubweaponEffectExplosionCellSpriteObject> _cellGameObjectList ;
	
	protected override void Awake() {
		base.Awake() ;
		
		_cellGameObjectList = new List<SubweaponEffectExplosionCellSpriteObject>() ;
		
		for(int i =0 ; i < _cellObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellGameObject) as GameObject ;
			SubweaponEffectExplosionCellSpriteObject _subweaponEffectExplosionCellSpriteObject = _go.GetComponent<SubweaponEffectExplosionCellSpriteObject>() as SubweaponEffectExplosionCellSpriteObject ;
			_subweaponEffectExplosionCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_subweaponEffectExplosionCellSpriteObject.InitSubweaponEffectExplosionCellSpriteObject() ;
			
			_cellGameObjectList.Add(_subweaponEffectExplosionCellSpriteObject) ;
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
		
		foreach(SubweaponEffectExplosionCellSpriteObject _subweaponEffectExplosionCellSpriteObject in _cellGameObjectList){
			_subweaponEffectExplosionCellSpriteObject.ResetSubweaponEffectExplosionCellSpriteObject(createPosition) ;
		}
		
	}
	
	public virtual void StartAction(){
		foreach(SubweaponEffectExplosionCellSpriteObject _subweaponEffectExplosionCellSpriteObject in _cellGameObjectList){
			_subweaponEffectExplosionCellSpriteObject.StartMoveAcation() ;
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
