using UnityEngine;
using System.Collections;

public class SubmarineBody : MonoBehaviour {

	public delegate void DelegateParam1(Collider col);
	public delegate void DelegateParam2(int state); //State 0 : Action Success  , 1 : Forced Stop Action
	public BoxCollider m_Collider;
	private  DelegateParam1 _onTriggerEnterEx;
	public event DelegateParam1 OnTriggerEnterEx {
        add{
			_onTriggerEnterEx = null ;
            if (_onTriggerEnterEx == null)
                _onTriggerEnterEx += value;
        }
        remove{
            _onTriggerEnterEx -= value;
        }
    }

	private  DelegateParam1 _onTriggerStayEx;
	public event DelegateParam1 OnTriggerStayEx {
		add{
			_onTriggerStayEx = null ;
			if (_onTriggerStayEx == null)
				_onTriggerStayEx += value;
		}
		remove{
			_onTriggerStayEx -= value;
		}
	}

	
	private  DelegateParam2 _invincibilityActionDone; 
	public event DelegateParam2 InvincibilityActionDone {
        add{
			
			_invincibilityActionDone = null ;
			
            if (_invincibilityActionDone == null)
                _invincibilityActionDone += value;
        }
        remove{
            _invincibilityActionDone -= value;
        }
    }
	
	
	
	/*
	[HideInInspector]
	public enum CharacterState {
		Idle,
		Entree,
		Play,
		Fever,
		Booster,
		Dead,
		Revive,
		GameOver
	}  ;
	
	[HideInInspector]
	public CharacterState _characterState = CharacterState.Idle ;
	*/
	
	protected Vector2 _spriteSize ;
	public Vector2 SpriteSize 
	{
		get { return _spriteSize ; }
	}
	
	protected Vector2 _spriteCenter ;
	public Vector2 SpriteCenter 
	{
		get { return _spriteCenter ; }
	}
	
	
	private tk2dAnimatedSprite _thisAnimationSprite ;
//	private string _initClipName ;
	
	
	private void Awake() {
	
		_thisAnimationSprite = GetComponent<tk2dAnimatedSprite>() as tk2dAnimatedSprite ;

		_spriteSize = new Vector2(_thisAnimationSprite.GetBounds().extents.x, _thisAnimationSprite.GetBounds().extents.y) ;
		_spriteCenter = new Vector2(_thisAnimationSprite.GetBounds().center.x, _thisAnimationSprite.GetBounds().center.y) ;		
		m_Collider = collider as BoxCollider;
		m_Collider.size = new Vector3(0.2f,0.14f,4f);
	}
	
	private void Start() {
//		_initClipName = _thisAnimationSprite.CurrentClip.name ;
	}
	
	//-- OnTriggerEneter!!
	private void OnTriggerEnter(Collider col){
		if ( _onTriggerEnterEx != null) {
			 _onTriggerEnterEx(col);
		}		
	}

	private void OnTriggerStay(Collider col)
	{
		if(_onTriggerStayEx != null)
		{
			_onTriggerStayEx(col);
		}
	}

	//collider control
	public void SetCollider(Vector3 _size)
	{
		m_Collider.size = _size;
	}

	//-- Animation Action
	public void AnimationPlay(){
		if(!_thisAnimationSprite.Playing) {
			_thisAnimationSprite.Play() ;
		}
	}
	
	public void AnimationStop(){
		if(_thisAnimationSprite.Playing) {
			_thisAnimationSprite.Stop() ;
		}
	}
	
	public void AnimationResume() {
		if(_thisAnimationSprite.Paused) {
			_thisAnimationSprite.Resume() ;
		}
	}
	
	public void AnimationPause() {
		if(!_thisAnimationSprite.Paused) {
			_thisAnimationSprite.Pause() ;
		}
	}
	
	/*
	// Submarine Change State
	public void SubmarineDead(){
		
		if(!_thisAnimationSprite.IsPlaying("SubmarineDead")){
			_thisAnimationSprite.Play("SubmarineDead");
			_thisAnimationSprite.animationCompleteDelegate = null ;
		}
		
	}
	*/
	
	
	//-- Action!!
	public void InvincibilityActionStart(){
		StartCoroutine(DoFadeInOutAction(4, 0.2f, 0.1f, 0.1f, 0.1f)) ;
	}
	
	public void InvincibilityActionStop() {
		//StopCoroutine("DoFadeInOutAction") ;
		StopAllCoroutines() ;
		_thisAnimationSprite.color  = Color.white ;
		
		if(_invincibilityActionDone != null){
			_invincibilityActionDone(1) ;	
		}
		
	}
	
	
	
	
	// Fade In/Out
	private IEnumerator DoFadeInOutAction(int fadeCnt, float fadeDelaySec, float fadeInSec, float delaySec, float fadeOutSec) {
		
		for(int i = 0 ; i < fadeCnt ; i++) {
			yield return StartCoroutine(FadeInOutModule(fadeInSec,delaySec,fadeOutSec)) ;
			// Delay
			yield return new WaitForSeconds(fadeDelaySec);
		}
		
		if(_invincibilityActionDone != null){
			_invincibilityActionDone(0) ;	
		}
		
		_thisAnimationSprite.color  = Color.white ;
	}

	private IEnumerator FadeInOutModule(float fadeInSec, float delaySec, float fadeOutSec) {
		// FadeIn/FadeOut
		
		//yield return null ;
		
		// Start Fade Out
		bool isFadeOutDone = false ;
		float remainSeconds = 0f ;
		
		while(!isFadeOutDone) {
			
			remainSeconds += Time.deltaTime; 
			
			Color spriteAlphaColor = _thisAnimationSprite.color;
			spriteAlphaColor.a  = 1f - (remainSeconds / fadeOutSec) ;
	
			if(spriteAlphaColor.a <= 0f) {
				spriteAlphaColor.a = 0f ;
				isFadeOutDone = true ;
			}
			
			_thisAnimationSprite.color  = spriteAlphaColor;
			
			yield return null ;
		}
		
		// Delay
		yield return new WaitForSeconds(delaySec);
		
		// Start Fade In
		bool isFadeInDone = false ;
		remainSeconds = 0f;
		
		while(!isFadeInDone) {
			
			remainSeconds += Time.deltaTime; 
	
			Color spriteAlphaColor = _thisAnimationSprite.color;
			spriteAlphaColor.a  = remainSeconds / fadeInSec;
	
			if(spriteAlphaColor.a >= 1f) {
				spriteAlphaColor.a = 1f ;
				isFadeInDone = true ;
			}
			
			_thisAnimationSprite.color  = spriteAlphaColor;
			
			yield return null ;
		}
		
		yield return null ;

	}
	//
	
	
}
