using UnityEngine;
using System.Collections;

public class EnemyEffectBubbleCellSpriteObject : MonoBehaviour {
	
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
	
	public Vector2 _minGapCreatePostion ;
	public Vector2 _maxGapCreatePostion ;
	
	public Vector2 _minGapMovePostion ;
	public Vector2 _maxGapMovePostion ;
	
	public float _moveSpeed ;
	
	// Protected
	protected tk2dAnimatedSprite _thisAnimatedSprite;
	
	// FSM
	public enum	FSMState { Idle , Move} ;
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
	
	public virtual void InitEnemyEffectExplosionCellSpriteObject(){
		SetActiveSpriteObject(false) ;
	}
	
	public virtual void ResetEnemyEffectExplosionCellSpriteObject(Vector3 createPosition){
		
		randomPositionX = Random.Range(_minGapCreatePostion.x, _maxGapCreatePostion.x) ;
		randomPositionY = Random.Range(_minGapCreatePostion.y, _maxGapCreatePostion.y) ;
		_thisTransform.position = new Vector3(createPosition.x + randomPositionX, createPosition.y + randomPositionY, createPosition.z) ;
		
		SetActiveSpriteObject(true) ;
		
		
		_fsmState = FSMState.Idle ;
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
	public virtual void StartMoveAcation(){
		
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
		SetActiveSpriteObject(false) ;
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
		//Vector3 endPosition = Vector3.zero ;
		Vector3 endPosition = new Vector3(startPosition.x+randomDirectPositionX, startPosition.y+randomDirectPositionY, startPosition.z) ;
		
		
		float t = 0f ;
		bool isDone = false ;
		
		yield return null ;
		
		while(_fsmState == FSMState.Move) {
			
			if(!isDone){
				t += (Time.deltaTime*_moveSpeed) ;
				
				_thisTransform.Rotate(Vector3.forward * (5f*Time.timeScale), Space.World);
				_thisTransform.position = Vector3.Lerp(startPosition,endPosition,t) ;
				
				if(_thisTransform.position == endPosition) {
					isDone = true ;
				}
			}
			
			yield return null;
			
		}
		
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
}
