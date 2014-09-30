using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SubmarineDeadReadyEffectObject : MonoBehaviour {

	private GameObject _thisGameObject ;
	private Transform _thisTransform ;
	
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
	
	protected List<SubmarineDeadReadyEffectCellSpriteObject> _cellGameObjectList ;
		
	
	private float _currentGameSpeed ;
	
	
	protected virtual void Awake(){
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_cellGameObjectList = new List<SubmarineDeadReadyEffectCellSpriteObject>() ;
		
	}
	
	protected virtual void Start() {
		
	}
	
	protected virtual void Update () {
	
	}
	
	public virtual void SetActiveSpriteObject(bool isActiveSpriteObject) {
		_thisGameObject.SetActive(isActiveSpriteObject) ;
	}
	
	public virtual bool IsActiveSpriteObject() {
		return _thisGameObject.activeSelf ;
	}
	
	public void InitialzieEffectObject() {
		
		for(int i =0 ; i < _cellObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellGameObject) as GameObject ;
			SubmarineDeadReadyEffectCellSpriteObject _submarineDeadReadyEffectCellSpriteObject = _go.GetComponent<SubmarineDeadReadyEffectCellSpriteObject>() as SubmarineDeadReadyEffectCellSpriteObject ;
			_submarineDeadReadyEffectCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineDeadReadyEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			
			_cellGameObjectList.Add(_submarineDeadReadyEffectCellSpriteObject) ;
		}
		
		SetActiveSpriteObject(false) ;
		
	}
	
	
	public virtual void ChangeStateSubmarineDeadReadyEffect(bool deadReadyMode){
		
		if(deadReadyMode){
			
			SetActiveSpriteObject(true) ;
			
			StopCoroutine("EffectStart") ;
			
			foreach(SubmarineDeadReadyEffectCellSpriteObject _submarineDeadReadyEffectCellSpriteObject in _cellGameObjectList){
				_submarineDeadReadyEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			}
			
			StartCoroutine("EffectStart") ;
			
		}else{
			
			StopCoroutine("EffectStart") ;
			
			SetActiveSpriteObject(false) ;
			
		}
		
	}
	
	
	public virtual IEnumerator EffectStart(){
		
		float t = 0.3f ;
		
		yield return null ;
		
		
		while(true){
			
			t += Time.deltaTime ;
			
			if(t >= 0.3f){
				
				SubmarineDeadReadyEffectCellSpriteObject selectObject = null ;
				
				foreach(SubmarineDeadReadyEffectCellSpriteObject _submarineDeadReadyEffectCellSpriteObject in _cellGameObjectList){
					if(!_submarineDeadReadyEffectCellSpriteObject.IsActiveSpriteObject()){
						selectObject = _submarineDeadReadyEffectCellSpriteObject ;
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
