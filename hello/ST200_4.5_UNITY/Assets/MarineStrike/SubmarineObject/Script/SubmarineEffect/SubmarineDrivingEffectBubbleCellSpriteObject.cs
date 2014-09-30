using UnityEngine;
using System.Collections;

public class SubmarineDrivingEffectBubbleCellSpriteObject : MonoBehaviour {
	
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
	
	
	public string _animationName ;
	
	public enum CellColorType { White, RandomColor} ;
	public CellColorType _cellColorType = CellColorType.White;
	
	public Vector2 _minGapCreatePostion ;
	public Vector2 _maxGapCreatePostion ;
	
	public Vector2 _minGapMovePostion ;
	public Vector2 _maxGapMovePostion ;
	
	public float _moveSpeed ;
	public float MoveSpeed {
		//get{ return _moveSpeed ; } 
		set{ _moveSpeed = value ; }
	}
	
	// Protected
	protected tk2dAnimatedSprite _thisAnimatedSprite;
	
	// FSM
	public enum	FSMState { Idle , Move, Gone} ;
	protected FSMState _fsmState = FSMState.Idle;
	
	
	protected float randomPositionX ;
	protected float randomPositionY ;
	
	
	private void Awake(){
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_thisAnimatedSprite = GetComponent<tk2dAnimatedSprite>() as tk2dAnimatedSprite;
		
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
		
			_thisAnimatedSprite.color = Color.white ;
			
		}else if(_cellColorType == CellColorType.RandomColor){
			
			_thisAnimatedSprite.color = Color.white ;
			
		}
		
		_fsmState = FSMState.Idle ;
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
	public virtual void StartMoveAcation(){
		
		_fsmState = FSMState.Move;
		
	}
	
	public virtual void StartMoveAcation(float _currentGameSpeed){
		
		_moveSpeed = _currentGameSpeed ;
		
		_fsmState = FSMState.Move;
		
	}
	
	
	// FSM
	protected virtual IEnumerator Idle() {
		
		yield return null ;
		
		while(_fsmState == FSMState.Idle) {
			
			yield return null;
			
		}
		
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
	
	private void AnimationCompleteDelegate(tk2dAnimatedSprite sprite, int clipId) {
		_fsmState = FSMState.Gone ;
	}
	
	protected virtual IEnumerator Move() {
		
		if(!_thisAnimatedSprite.IsPlaying(_animationName)){
			_thisAnimatedSprite.Play(_animationName);
			_thisAnimatedSprite.animationCompleteDelegate =  AnimationCompleteDelegate;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
		
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
				
				//_thisTransform.Rotate(Vector3.forward * (10f*Time.timeScale), Space.World);
				_thisTransform.position = Vector3.Lerp(startPosition,endPosition,t) ;
				
				if(_thisTransform.position == endPosition) {
					_fsmState = FSMState.Gone ;
					
					if(_thisAnimatedSprite.IsPlaying(_animationName)){
						_thisAnimatedSprite.Stop() ;
					}
					
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
