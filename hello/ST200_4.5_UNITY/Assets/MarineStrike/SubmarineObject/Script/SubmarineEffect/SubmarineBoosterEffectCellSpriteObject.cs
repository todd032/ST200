using UnityEngine;
using System.Collections;

public class SubmarineBoosterEffectCellSpriteObject : MonoBehaviour {

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
	
	
	public enum CellColorType { White, RandomColor} ;
	public CellColorType _cellColorType = CellColorType.White;
	
	public Vector2 _minGapCreatePostion ;
	public Vector2 _maxGapCreatePostion ;
	
	public Vector2 _minGapMovePostion ;
	public Vector2 _maxGapMovePostion ;
	
	public float _moveSpeed ;
	
	// Protected
	protected tk2dSprite _thisSprite;
	
	// FSM
	public enum	FSMState { Idle , Move, Gone} ;
	protected FSMState _fsmState = FSMState.Idle;
	
	
	protected float randomPositionX ;
	protected float randomPositionY ;
	
	
	private void Awake(){
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_thisSprite = GetComponent<tk2dSprite>() as tk2dSprite;
		
	}
	
	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
	
	}
	
	public virtual void SetActiveSpriteObject(bool isActiveSpriteObject) {
		_thisGameObject.SetActive(isActiveSpriteObject) ;
	}
	
	public virtual bool IsActiveSpriteObject() {
		return _thisGameObject.activeSelf ;
	}
	
	public virtual void InitSubmarineCellSpriteObject(){
		SetActiveSpriteObject(false) ;
	}
	
	public virtual void ResetSubmarineCellSpriteObject(Vector3 createPosition){
		
		randomPositionX = Random.Range(_minGapCreatePostion.x, _maxGapCreatePostion.x) ;
		randomPositionY = Random.Range(_minGapCreatePostion.y, _maxGapCreatePostion.y) ;
		_thisTransform.position = new Vector3(createPosition.x + randomPositionX, createPosition.y + randomPositionY, createPosition.z) ;
		
		SetActiveSpriteObject(true) ;
		
		
		if(_cellColorType == CellColorType.White){
		
			_thisSprite.color = Color.white ;
			
		}else if(_cellColorType == CellColorType.RandomColor){
			/*
			int randomSelect = Random.Range(0, 4) ;
			
			if(randomSelect == 0){
				_thisSprite.color = new Color(255f/255f, 162f/255f, 12f/255f, 1f) ;	
			}else if(randomSelect == 1){
				_thisSprite.color = new Color(200f/255f, 30f/255f, 230f/255f, 1f) ;	
			}else if(randomSelect == 2){
				_thisSprite.color = new Color(255f/255f, 220f/255f, 66f/255f, 1f) ;
			}else if(randomSelect == 3){
				_thisSprite.color = new Color(255f/255f, 66f/255f, 98f/255f, 1f) ;
			}
			*/
		}
		
		_fsmState = FSMState.Idle ;
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
	public virtual void StartMoveAcation(){
		
		_fsmState = FSMState.Move;
		
	}
	
	
	public virtual void SetTransformPosition(Vector3 newPosition){
		_thisTransform.position = new Vector3(_thisTransform.position.x, newPosition.y,  _thisTransform.position.z) ;
	}
	
	
	// FSM
	protected virtual IEnumerator Idle() {
		
		yield return null ;
		
		while(_fsmState == FSMState.Idle) {
			
			yield return null;
			
		}
		
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
	
	protected virtual IEnumerator Move() {
		
		float randomDirectPositionX = Random.Range(_minGapMovePostion.x, _maxGapMovePostion.x) ;
		float randomDirectPositionY = Random.Range(_minGapMovePostion.y, _maxGapMovePostion.y) ;
		
		
		Vector3 startPosition = _thisTransform.position ;
		Vector3 endPosition = new Vector3(startPosition.x+randomDirectPositionX, startPosition.y+randomDirectPositionY, startPosition.z) ;
		
		
		float t = 0f ;
		bool isDone = false ;
		
		yield return null ;
		
		while(_fsmState == FSMState.Move) {
			
			if(!isDone){
				t += (Time.deltaTime*_moveSpeed) ;
				
				_thisTransform.position = Vector3.Lerp(startPosition,endPosition,t) ;
				
				//if(_thisTransform.position == endPosition) {
				if(_thisTransform.position.x == endPosition.x) {
					_fsmState = FSMState.Gone ;
					isDone = true ;
				}
			}
			
			yield return null;
			
		}
		
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
	protected virtual IEnumerator Gone() {
	
		SetActiveSpriteObject(false) ;
		
		yield return null ;
		
	}
	
}
