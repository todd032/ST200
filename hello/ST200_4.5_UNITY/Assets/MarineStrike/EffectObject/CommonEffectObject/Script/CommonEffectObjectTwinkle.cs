using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class CommonEffectObjectTwinkle : MonoBehaviour {
	
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
	
	protected List<CommonEffectObjectTwinkleCellSpriteObject> _cellGameObjectList ;
	
	protected Vector2 _baseObjectSpriteSize ;
	
	
	protected virtual void Awake() {
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_cellGameObjectList = new List<CommonEffectObjectTwinkleCellSpriteObject>() ;
		
		for(int i =0 ; i < _cellObjectCreateNumber ; i++){
			GameObject _go = Instantiate(_cellGameObject) as GameObject ;
			CommonEffectObjectTwinkleCellSpriteObject _commonEffectObjectTwinkleCellSpriteObject = _go.GetComponent<CommonEffectObjectTwinkleCellSpriteObject>() as CommonEffectObjectTwinkleCellSpriteObject ;
			_commonEffectObjectTwinkleCellSpriteObject.ThisTransform.parent = _thisTransform ;
			_commonEffectObjectTwinkleCellSpriteObject.InitCommonEffectCellSpriteObject() ;
			
			_cellGameObjectList.Add(_commonEffectObjectTwinkleCellSpriteObject) ;
		}
		
	}
	
	// Use this for initialization
	protected virtual void Start () {
		
	}
	
	
	public virtual void SetActiveSpriteObject(bool isActiveSpriteObject) {
		_thisGameObject.SetActive(isActiveSpriteObject) ;
	}
	
	public virtual bool IsActiveSpriteObject() {
		return _thisGameObject.activeSelf ;
	}
	
	
	public virtual void ResetEffectObject(){
	}
	
	public virtual void ResetEffectObject(Vector3 createPosition, Vector2 baseObjectSpriteSize){
		
		_thisTransform.position = createPosition ;
		
		_baseObjectSpriteSize = baseObjectSpriteSize ;
		
		foreach(CommonEffectObjectTwinkleCellSpriteObject _commonEffectObjectTwinkleCellSpriteObject in _cellGameObjectList){
			_commonEffectObjectTwinkleCellSpriteObject.InitCommonEffectCellSpriteObject() ;
		}
		
	}
	
	
	public virtual void StartAction(){
		
		StartCoroutine("EffectStart") ;
		
	}
	
	public virtual IEnumerator EffectStart(){
		
		float t = 0f ;
		
		yield return null ;
		
		
		while(true){
			
			t += Time.deltaTime ;
			
			if(t >= 0.2f){
				
				CommonEffectObjectTwinkleCellSpriteObject selectObject = null ;
				
				foreach(CommonEffectObjectTwinkleCellSpriteObject _commonEffectObjectTwinkleCellSpriteObject in _cellGameObjectList){
					if(!_commonEffectObjectTwinkleCellSpriteObject.IsActiveSpriteObject()){
						selectObject = _commonEffectObjectTwinkleCellSpriteObject ;
						break ;	
					}
				}
				
				if(selectObject != null){
					
					float randomPositionX = Random.Range(-_baseObjectSpriteSize.x, _baseObjectSpriteSize.x) ;
					float randomPositionY = Random.Range(-_baseObjectSpriteSize.y, _baseObjectSpriteSize.y) ;
					
					selectObject.ResetCommonEffectCellSpriteObject(new Vector3(_thisTransform.position.x + randomPositionX, _thisTransform.position.y + randomPositionY, _thisTransform.position.z-1f)) ;
					selectObject.StartMoveAcation() ;
					t = 0f ;
				}
				
			}
			
			yield return null ;
			
		}
		
		
	}
	
}
