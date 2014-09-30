using UnityEngine;
using System.Collections;

public class PatternObject : MonoBehaviour {
	
	[HideInInspector]
	public delegate void PatternObjectDelegate(PatternObject patternObject, int state);
	protected PatternObjectDelegate _patternObjectStateDelegate ;
	public event PatternObjectDelegate PatternObjectStateDelegate {
		add{
			
			_patternObjectStateDelegate = null ;
			
			if (_patternObjectStateDelegate == null)
        		_patternObjectStateDelegate += value;
        }
		
		remove{
            _patternObjectStateDelegate -= value;
		}
	}
	
	public enum PatternObjectType {NONE, TRAP, ENEMY, ITEM, COIN} ;
	public PatternObjectType patternObjectType = PatternObjectType.NONE ;
	
	
	protected GameObject _thisGameObject ;
	protected Transform _thisTransform ; //Caching Transform.
	protected tk2dSprite _thisSprite ; //Caching tk2dSprite.
	
	protected Vector2 _spriteSize ;
	protected Vector2 _spriteCenter ;

	protected bool _isMove;
	protected float _movespeed;
	/// <summary>
	/// used to control movespeed such as slow effect;
	/// </summary>
	protected float _movespeedfactor;

	// Property
	public GameObject ThisGameObject 
	{
		get { return _thisGameObject ; }
	}
	
	public Transform ThisTransform 
	{
		get { return _thisTransform ; }
	}
	
	public tk2dSprite ThisSprite 
	{
		get { return _thisSprite ; }
	}
	
	public Vector2 SpriteSize 
	{
		get { return _spriteSize ; }
	}
	
	public Vector2 SpriteCenter 
	{
		get { return _spriteCenter ; }
	}
	//
	
	protected virtual void Awake() {
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ; //Caching Transform.
		_thisSprite = GetComponentInChildren<tk2dSprite>() as tk2dSprite ; //Caching tk2dSprite.
		
		//_spriteSize = new Vector2(_thisSprite.GetBounds().extents.x, _thisSprite.GetBounds().extents.y) ;
		//_spriteCenter = new Vector2(_thisSprite.GetBounds().center.x, _thisSprite.GetBounds().center.y) ;		
		_spriteSize = new Vector2(_thisSprite.GetUntrimmedBounds().extents.x, _thisSprite.GetUntrimmedBounds().extents.y) ;
		_spriteCenter = new Vector2(_thisSprite.GetUntrimmedBounds().center.x, _thisSprite.GetUntrimmedBounds().center.y) ;

	}
	
	protected virtual void Start() {
		
	}

	protected virtual void FixedUpdate()
	{
		if(_isMove)
		{
			//move 
			_thisTransform.position += -Vector3.right * _movespeed * _movespeedfactor * Time.deltaTime;
			//check bound
		}
	}

	protected virtual void CheckPatternObjectState()
	{

	}

	public virtual void SetActivePatternObject(bool isActivePatternObject) {
		_thisGameObject.SetActive(isActivePatternObject) ;
	}
	
	public virtual void ResetPatternObject(){
		
	}
	
	public virtual void ResetPatternObject(float settingValue){
		
	}
	
	public virtual void ResetPatternObject(float settingValue, float weightLevel){
		
	}
	
	public virtual void DestroyPatternObject(int destroyType) {
		if(destroyType == 0) {
			SetActivePatternObject(false) ;	
		}
	}
	
	//--
	public virtual void StartPatternObject() {
		
	}
	
	public virtual void StopPatternObject() {
		
	}
	
	//--
	public virtual void AnimationPlay() {
		
	}
	
	public virtual void AnimationStop() {
		
	}
	
	public virtual void AnimationPause() {
		
	}
	
	public virtual void AnimationResume() {
		
	}
}
