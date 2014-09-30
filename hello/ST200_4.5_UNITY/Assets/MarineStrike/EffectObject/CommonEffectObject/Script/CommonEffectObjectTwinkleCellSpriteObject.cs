using UnityEngine;
using System.Collections;

public class CommonEffectObjectTwinkleCellSpriteObject : MonoBehaviour {

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
	
	public virtual void InitCommonEffectCellSpriteObject(){
		SetActiveSpriteObject(false) ;
	}
	
	public virtual void ResetCommonEffectCellSpriteObject(Vector3 createPosition){
		
		_thisTransform.position = createPosition ;
		
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
		_fsmState = FSMState.Gone ;
	}
	
	protected virtual IEnumerator Move() {
		
		if(!_thisAnimatedSprite.IsPlaying(_animationName)){
			_thisAnimatedSprite.Play(_animationName);
			_thisAnimatedSprite.animationCompleteDelegate =  AnimationCompleteDelegate;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
		
		yield return null ;
		
		while(_fsmState == FSMState.Move) {
			
			yield return null;
			
		}
		
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
	protected virtual IEnumerator Gone() {
	
		SetActiveSpriteObject(false) ;
		
		yield return null ;
		
	}
	
}
