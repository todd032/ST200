using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SubmarineMagnetEffectObject : MonoBehaviour {
	
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
	
	protected List<SubmarineMagnetEffectCellSpriteObject> _cellGameObjectList ;
	
	
	protected SphereCollider _sphereCollider ;
	
	protected float _magnetAreaCharacter ;
	protected float _magnetAreaDropItem ;
	
	
	protected virtual void Awake (){
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_cellGameObjectList = new List<SubmarineMagnetEffectCellSpriteObject>() ;
		
		_sphereCollider = GetComponent<SphereCollider>() as SphereCollider  ; //Caching SphereCollider..
		
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
	
	
	public virtual void InitializeEffectObject(bool haveCharacterMagnet, float magnetAreaCharacter, float magnetAreaDropItem) {
		
		for(int i =0 ; i < _cellObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellGameObject) as GameObject ;
			SubmarineMagnetEffectCellSpriteObject _submarineMagnetEffectCellSpriteObject = _go.GetComponent<SubmarineMagnetEffectCellSpriteObject>() as SubmarineMagnetEffectCellSpriteObject ;
			_submarineMagnetEffectCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_submarineMagnetEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			
			_cellGameObjectList.Add(_submarineMagnetEffectCellSpriteObject) ;
		}
		
		_magnetAreaCharacter = magnetAreaCharacter ;
		_magnetAreaDropItem = magnetAreaDropItem ;
		
		ChangeStateSubmarineMagnetEffect(haveCharacterMagnet, false) ;
	}
	
	public virtual void ChangeStateSubmarineMagnetEffect(bool haveCharacterMagnet, bool getItemMagnet){
		
		if(!haveCharacterMagnet && !getItemMagnet){
			
			StopCoroutine("EffectStart") ;
			
			SetActiveSpriteObject(false) ;
			
		}else if(haveCharacterMagnet && getItemMagnet){
			//
			
			SetActiveSpriteObject(true) ;
			
			_sphereCollider.radius = (_magnetAreaCharacter + _magnetAreaDropItem) ;
			
			
			StopCoroutine("EffectStart") ;
			
			foreach(SubmarineMagnetEffectCellSpriteObject _submarineMagnetEffectCellSpriteObject in _cellGameObjectList){
				_submarineMagnetEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			}
			
			StartCoroutine("EffectStart") ;
			
		}else if(haveCharacterMagnet && !getItemMagnet){
			//
			
			SetActiveSpriteObject(true) ;
			
			_sphereCollider.radius = _magnetAreaCharacter ;
			
			StopCoroutine("EffectStart") ;
			
			foreach(SubmarineMagnetEffectCellSpriteObject _submarineMagnetEffectCellSpriteObject in _cellGameObjectList){
				_submarineMagnetEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			}
			
			StartCoroutine("EffectStart") ;
			
		}else if(!haveCharacterMagnet && getItemMagnet){
			//
			
			SetActiveSpriteObject(true) ;
			
			_sphereCollider.radius = _magnetAreaDropItem ;
			
			StopCoroutine("EffectStart") ;
			
			foreach(SubmarineMagnetEffectCellSpriteObject _submarineMagnetEffectCellSpriteObject in _cellGameObjectList){
				_submarineMagnetEffectCellSpriteObject.InitSubmarineCellSpriteObject() ;
			}
			
			StartCoroutine("EffectStart") ;
			
		}
		
	}
	
	public virtual IEnumerator EffectStart(){
		
		float t = 0.8f ;
		
		yield return null ;
		
		
		while(true){
			
			t += Time.deltaTime ;
			
			if(t >= 0.8f){
				
				SubmarineMagnetEffectCellSpriteObject selectObject = null ;
				
				foreach(SubmarineMagnetEffectCellSpriteObject _submarineMagnetEffectCellSpriteObject in _cellGameObjectList){
					if(!_submarineMagnetEffectCellSpriteObject.IsActiveSpriteObject()){
						selectObject = _submarineMagnetEffectCellSpriteObject ;
						break ;	
					}
				}
				
				if(selectObject != null){
					selectObject.ResetSubmarineCellSpriteObject(_thisTransform.position) ;
					selectObject.StartMoveAcation() ;
					t = 0f ;
				}
				
			}
				
			foreach(SubmarineMagnetEffectCellSpriteObject _submarineMagnetEffectCellSpriteObject in _cellGameObjectList){
				if(_submarineMagnetEffectCellSpriteObject.IsActiveSpriteObject()){
					_submarineMagnetEffectCellSpriteObject.SetTransformPosition(_thisTransform.position) ;
				}
			}
			
			yield return null ;
			
		}
		
		
	}
	
}
