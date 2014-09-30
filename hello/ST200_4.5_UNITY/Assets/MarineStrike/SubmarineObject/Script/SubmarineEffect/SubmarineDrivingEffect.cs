using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SubmarineDrivingEffect : MonoBehaviour {
	
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
	
	protected List<SubmarineDrivingEffectBubbleCellSpriteObject> _cellGameObjectList ;
		
	
	private float _currentGameSpeed ;
	
	
	private void Awake ()
	{
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_cellGameObjectList = new List<SubmarineDrivingEffectBubbleCellSpriteObject>() ;
		
	}
	
	private void Start() {
		
	}
	
	private void Update () {
	
	}
	
	public void InitialzieEffectObject() {
		
		for(int i =0 ; i < _cellObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellGameObject) as GameObject ;
			SubmarineDrivingEffectBubbleCellSpriteObject _submarineDrivingEffectBubbleCellSpriteObject = _go.GetComponent<SubmarineDrivingEffectBubbleCellSpriteObject>() as SubmarineDrivingEffectBubbleCellSpriteObject ;
			_submarineDrivingEffectBubbleCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineDrivingEffectBubbleCellSpriteObject.InitSubmarineCellSpriteObject() ;
			
			_cellGameObjectList.Add(_submarineDrivingEffectBubbleCellSpriteObject) ;
		}
		
		StartCoroutine("ChangeEffectSpeed") ;
		
	}
	
	
	public void InitialzieEffectObject(Vector3 createPosition) {
		_thisTransform.position = createPosition ;
		
		for(int i =0 ; i < _cellObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellGameObject) as GameObject ;
			SubmarineDrivingEffectBubbleCellSpriteObject _submarineDrivingEffectBubbleCellSpriteObject = _go.GetComponent<SubmarineDrivingEffectBubbleCellSpriteObject>() as SubmarineDrivingEffectBubbleCellSpriteObject ;
			_submarineDrivingEffectBubbleCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineDrivingEffectBubbleCellSpriteObject.InitSubmarineCellSpriteObject() ;
			
			_cellGameObjectList.Add(_submarineDrivingEffectBubbleCellSpriteObject) ;
		}
		
		StartCoroutine("ChangeEffectSpeed") ;
		
	}
	
	
	//--Control
	public void EffectPlay(){
		
		StopCoroutine("ChangeEffectSpeed") ;
		
		foreach(SubmarineDrivingEffectBubbleCellSpriteObject _submarineDrivingEffectBubbleCellSpriteObject in _cellGameObjectList){
			_submarineDrivingEffectBubbleCellSpriteObject.InitSubmarineCellSpriteObject() ;
		}
		
		StartCoroutine("ChangeEffectSpeed") ;
		
	}
	
	public void EffectStop(){
		StopCoroutine("ChangeEffectSpeed") ;
	}
	
	
	public void ChangeEffectPerSpeed(float gameSpeed) {
		
		if(gameSpeed < 3f){
			_currentGameSpeed = (gameSpeed * 0.7f);	
		}else{
			_currentGameSpeed = (3f * 0.7f) ;
		}
		
	}
	
	private IEnumerator ChangeEffectSpeed() {
		
		float t = 0.05f ;
		
		yield return null ;
		
		
		while(true){
			
			t += Time.deltaTime ;
			
			if(t >= 0.05f){
				
				SubmarineDrivingEffectBubbleCellSpriteObject selectObject = null ;
				
				foreach(SubmarineDrivingEffectBubbleCellSpriteObject _submarineDrivingEffectBubbleCellSpriteObject in _cellGameObjectList){
					if(!_submarineDrivingEffectBubbleCellSpriteObject.IsActiveSpriteObject()){
						selectObject = _submarineDrivingEffectBubbleCellSpriteObject ;
						break ;	
					}
				}
				
				if(selectObject != null){
					selectObject.ResetSubmarineCellSpriteObject(_thisTransform.position) ;
					selectObject.StartMoveAcation(_currentGameSpeed) ;
					t = 0f ;
				}
				
			}
			
			yield return null ;
			
		}
		
	}
	
}
