using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SubmarineDoubleScoreEffectObject : MonoBehaviour {

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
	
	protected List<SubmarineDoubleScoreEffectCellSpriteObject> _cellGameObjectList ;
	
	protected virtual void Awake ()
	{
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_cellGameObjectList = new List<SubmarineDoubleScoreEffectCellSpriteObject>() ;
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
			SubmarineDoubleScoreEffectCellSpriteObject _submarineDoubleScoreEffectCellSpriteObject = _go.GetComponent<SubmarineDoubleScoreEffectCellSpriteObject>() as SubmarineDoubleScoreEffectCellSpriteObject ;
			_submarineDoubleScoreEffectCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineDoubleScoreEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			
			_cellGameObjectList.Add(_submarineDoubleScoreEffectCellSpriteObject) ;
		}
		
		SetActiveSpriteObject(false) ;
		
	}
	
	public virtual void ChangeStateSubmarineDoubleScoreEffect(bool getItemDoubleScore){
		
		if(getItemDoubleScore){
			
			SetActiveSpriteObject(true) ;
			
			StopCoroutine("EffectStart") ;
			
			foreach(SubmarineDoubleScoreEffectCellSpriteObject _submarineDoubleScoreEffectCellSpriteObject in _cellGameObjectList){
				_submarineDoubleScoreEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			}
			
			StartCoroutine("EffectStart") ;
		}else{
			
			foreach(SubmarineDoubleScoreEffectCellSpriteObject _submarineDoubleScoreEffectCellSpriteObject in _cellGameObjectList){
				_submarineDoubleScoreEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			}
			
			StopCoroutine("EffectStart") ;
			
			SetActiveSpriteObject(false) ;
		}
		
	}
	
	
	public virtual IEnumerator EffectStart(){
		
		float t = 0.4f ;
		
		yield return null ;
		
		
		while(true){
			
			t += Time.deltaTime ;
			
			if(t >= 0.4f){
				
				SubmarineDoubleScoreEffectCellSpriteObject selectObject = null ;
				
				foreach(SubmarineDoubleScoreEffectCellSpriteObject _submarineDoubleScoreEffectCellSpriteObject in _cellGameObjectList){
					if(!_submarineDoubleScoreEffectCellSpriteObject.IsActiveSpriteObject()){
						selectObject = _submarineDoubleScoreEffectCellSpriteObject ;
						break ;	
					}
				}
				
				if(selectObject != null){
					selectObject.ResetSubmarineCellSpriteObject(_thisTransform.position) ;
					selectObject.StartMoveAcation() ;
					t = 0f ;
				}
				
			}
			
			foreach(SubmarineDoubleScoreEffectCellSpriteObject _submarineDoubleScoreEffectCellSpriteObject in _cellGameObjectList){
				if(_submarineDoubleScoreEffectCellSpriteObject.IsActiveSpriteObject()){
					_submarineDoubleScoreEffectCellSpriteObject.SetTransformPosition(_thisTransform.position) ;
				}
			}
			
			
			yield return null ;
			
		}
		
		
	}
	
}
