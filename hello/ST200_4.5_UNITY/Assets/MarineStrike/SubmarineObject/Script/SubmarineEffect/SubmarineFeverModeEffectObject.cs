using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SubmarineFeverModeEffectObject : MonoBehaviour {
	
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
	
	protected List<SubmarineFeverModeEffectCellSpriteObject> _cellGameObjectList ;
	
	protected virtual void Awake ()
	{
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_cellGameObjectList = new List<SubmarineFeverModeEffectCellSpriteObject>() ;
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
			SubmarineFeverModeEffectCellSpriteObject _submarineFeverModeEffectCellSpriteObject = _go.GetComponent<SubmarineFeverModeEffectCellSpriteObject>() as SubmarineFeverModeEffectCellSpriteObject ;
			_submarineFeverModeEffectCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineFeverModeEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			
			_cellGameObjectList.Add(_submarineFeverModeEffectCellSpriteObject) ;
		}
		
		SetActiveSpriteObject(false) ;
		
	}
	
	
	
	public virtual void ChangeStateSubmarineFeverModeEffect(bool feverMode){
		
		if(feverMode){
			
			SetActiveSpriteObject(true) ;
			
			StopCoroutine("EffectStart") ;
			
			foreach(SubmarineFeverModeEffectCellSpriteObject _submarineFeverModeEffectCellSpriteObject in _cellGameObjectList){
				_submarineFeverModeEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
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
				
				SubmarineFeverModeEffectCellSpriteObject selectObject = null ;
				
				foreach(SubmarineFeverModeEffectCellSpriteObject _submarineFeverModeEffectCellSpriteObject in _cellGameObjectList){
					if(!_submarineFeverModeEffectCellSpriteObject.IsActiveSpriteObject()){
						selectObject = _submarineFeverModeEffectCellSpriteObject ;
						break ;	
					}
				}
				
				if(selectObject != null){
					selectObject.ResetSubmarineCellSpriteObject(_thisTransform.position) ;
					selectObject.StartMoveAcation() ;
					t = 0f ;
				}
				
			}
			
			yield return null ;
			
		}
		
		
	}
	
	
	
}
