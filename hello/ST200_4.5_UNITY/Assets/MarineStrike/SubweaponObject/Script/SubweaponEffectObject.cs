using UnityEngine;
using System.Collections;

public class SubweaponEffectObject : MonoBehaviour {

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
	
	// Protected
	protected tk2dAnimatedSprite _thisAnimatedSprite;
	
	
	protected virtual void Awake() {
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_thisAnimatedSprite = GetComponent<tk2dAnimatedSprite>() as tk2dAnimatedSprite;
		
	}
	
	// Use this for initialization
	protected virtual void Start () {
	}
	
	protected virtual void Update () {
	}
	
	
	public virtual void InitializeEffectObject() {
		if(_thisGameObject.activeSelf){
			_thisGameObject.SetActive(false) ;	
		}
	}
	
	public virtual void InitializeEffectObject(Vector3 createPosition) {
		if(_thisGameObject.activeSelf){
			_thisGameObject.SetActive(false) ;	
		}
		_thisTransform.position = createPosition ;
	}
	
	public virtual void StartEffectObject(){
		if(!_thisGameObject.activeSelf){
			_thisGameObject.SetActive(true) ;	
		}
		EffectPlay() ;
	}
	
	//--
	public virtual void StopEffectObject() {
		EffectStop() ;
		
		if(_thisGameObject.activeSelf){
			_thisGameObject.SetActive(false) ;	
		}
		
	}
	
	//--
	public virtual void EffectPlay(){
		
		if(!_thisAnimatedSprite.IsPlaying(_animationName)){
			_thisAnimatedSprite.Play(_animationName);
			_thisAnimatedSprite.animationCompleteDelegate =  null;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
		
	}
	
	public virtual void EffectStop(){
		
		if(_thisAnimatedSprite.IsPlaying(_animationName)){
			_thisAnimatedSprite.Stop() ;
		}
		
	}
	
	public virtual void EffectResume(){
		
		if(_thisAnimatedSprite.Paused){
			_thisAnimatedSprite.Resume() ;
		}
		
	}
	
	public virtual void EffectPause(){
		if(!_thisAnimatedSprite.Paused){
			_thisAnimatedSprite.Pause() ;
		}
	}
	
	
	protected virtual bool IsActiveEffectObject() {
		return _thisGameObject.activeSelf ;
	}
	
}
