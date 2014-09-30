using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SubmarinePowerShotEffectObject : MonoBehaviour {

	protected GameObject _thisGameObject ;
	protected Transform _thisTransform ;
	
	public GameObject ThisGameObject 
	{
        get { return _thisGameObject ; }
    }
	
	public Transform ThisTransform
    {
        get { return _thisTransform ; }
    }
	
	
	public GameObject _cellGameObject ;
	public int _cellObjectCreateNumber = 1 ;
	
	protected List<SubmarinePowerShotEffectCellSpriteObject> _cellGameObjectList ;
	
	protected virtual void Awake ()
	{
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_cellGameObjectList = new List<SubmarinePowerShotEffectCellSpriteObject>() ;
	}
	
	protected virtual void Start() {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		
	}
	
	public virtual void SetActiveSpriteObject(bool isActiveSpriteObject) {
		_thisGameObject.SetActive(isActiveSpriteObject) ;
	}
	
	public virtual bool IsActiveSpriteObject() {
		return _thisGameObject.activeSelf ;
	}
	
	
	public virtual void InitializeEffectObject(){
		
		for(int i =0 ; i < _cellObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellGameObject) as GameObject ;
			SubmarinePowerShotEffectCellSpriteObject _submarinePowerShotEffectCellSpriteObject = _go.GetComponent<SubmarinePowerShotEffectCellSpriteObject>() as SubmarinePowerShotEffectCellSpriteObject ;
			_submarinePowerShotEffectCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarinePowerShotEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			
			_cellGameObjectList.Add(_submarinePowerShotEffectCellSpriteObject) ;
		}
		
		SetActiveSpriteObject(false) ;
		
	}
	
	
	
	public virtual void ChangeStateSubmarinePowerShotEffect(bool getItemPowerShot){
		
		if(getItemPowerShot){
			
			SetActiveSpriteObject(true) ;
			
			StopCoroutine("EffectStart") ;
			
			foreach(SubmarinePowerShotEffectCellSpriteObject _submarinePowerShotEffectCellSpriteObject in _cellGameObjectList){
				_submarinePowerShotEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			}
			
			StartCoroutine("EffectStart") ;
		}else{
			StopCoroutine("EffectStart") ;
			
			SetActiveSpriteObject(false) ;
		}
		
	}
	
	
	public virtual IEnumerator EffectStart(){
		
		float t = 0.1f ;
		
		yield return null ;
		
		
		while(true){
			
			t += Time.deltaTime ;
			
			if(t >= 0.1f){
				
				SubmarinePowerShotEffectCellSpriteObject selectObject = null ;
				
				foreach(SubmarinePowerShotEffectCellSpriteObject _submarinePowerShotEffectCellSpriteObject in _cellGameObjectList){
					if(!_submarinePowerShotEffectCellSpriteObject.IsActiveSpriteObject()){
						selectObject = _submarinePowerShotEffectCellSpriteObject ;
						break ;	
					}
				}
				
				if(selectObject != null){
					selectObject.ResetSubmarineCellSpriteObject(_thisTransform.position) ;
					selectObject.StartMoveAcation() ;
					t = 0f ;
				}
				
			}
			
			/*
			foreach(SubmarinePowerShotEffectCellSpriteObject _submarinePowerShotEffectCellSpriteObject in _cellGameObjectList){
				if(_submarinePowerShotEffectCellSpriteObject.IsActiveSpriteObject()){
					_submarinePowerShotEffectCellSpriteObject.SetTransformPosition(_thisTransform.position) ;
				}
			}
			*/
			
			yield return null ;
			
		}
		
		
	}
	
}
