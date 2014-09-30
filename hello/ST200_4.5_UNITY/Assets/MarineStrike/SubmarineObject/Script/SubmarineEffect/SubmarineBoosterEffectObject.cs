using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SubmarineBoosterEffectObject : MonoBehaviour {
	
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
	
	protected Animation _animation ;
	
	public GameObject _cellGameObject ;
	public int _cellObjectCreateNumber = 1 ;
	
	protected List<SubmarineBoosterEffectCellSpriteObject> _cellGameObjectList ;
	
	
	protected virtual void Awake (){
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_animation = _thisGameObject.animation ;
		
		_cellGameObjectList = new List<SubmarineBoosterEffectCellSpriteObject>() ;
		
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
			SubmarineBoosterEffectCellSpriteObject _submarineBoosterEffectCellSpriteObject = _go.GetComponent<SubmarineBoosterEffectCellSpriteObject>() as SubmarineBoosterEffectCellSpriteObject ;
			_submarineBoosterEffectCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineBoosterEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			
			_cellGameObjectList.Add(_submarineBoosterEffectCellSpriteObject) ;
		}
		
		SetActiveSpriteObject(false) ;
		
	}
	
	public virtual void ChangeStateSubmarineBoosterEffect(bool getItemBooster){
		
		if(getItemBooster){
			
			SetActiveSpriteObject(true) ;
			
			StopCoroutine("EffectStart") ;
			
			foreach(SubmarineBoosterEffectCellSpriteObject _submarineBoosterEffectCellSpriteObject in _cellGameObjectList){
				_submarineBoosterEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			}
			
			StartCoroutine("EffectStart") ;
			
			if(!_animation.isPlaying){
				_animation.Play() ;
			}
			
		}else{
			
			if(_animation.isPlaying){
				_animation.Stop() ;
			}
			
			StopCoroutine("EffectStart") ;
			
			SetActiveSpriteObject(false) ;
		}
		
	}
	
	public virtual IEnumerator EffectStart(){
		
		float t = 0.05f ;
		
		yield return null ;
		
		
		while(true){
			
			t += Time.deltaTime ;
			
			if(t >= 0.05f){
				
				SubmarineBoosterEffectCellSpriteObject selectObject = null ;
				
				foreach(SubmarineBoosterEffectCellSpriteObject _submarineBoosterEffectCellSpriteObject in _cellGameObjectList){
					if(!_submarineBoosterEffectCellSpriteObject.IsActiveSpriteObject()){
						selectObject = _submarineBoosterEffectCellSpriteObject ;
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
