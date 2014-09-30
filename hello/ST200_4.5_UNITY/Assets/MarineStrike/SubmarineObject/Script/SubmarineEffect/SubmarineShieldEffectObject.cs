using UnityEngine;
using System.Collections;

public class SubmarineShieldEffectObject : MonoBehaviour {
	
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
	
	
	protected tk2dSprite _thisSprite ; //Caching tk2dSprite.
	protected Animation _animation ;
	
	protected virtual void Awake ()
	{
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_thisSprite = GetComponent<tk2dSprite>() as tk2dSprite ; //Caching tk2dSprite.
		_animation = _thisGameObject.animation ;
		
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
	
	
	public virtual void InitializeEffectObject(bool haveCharacterShield, bool haveItemShield) {
		
		//SetActiveSpriteObject(false) ;
		
		ChangeStateSubmarineShieldEffect(haveCharacterShield, haveItemShield) ;
		
	}
	
	public virtual void ChangeStateSubmarineShieldEffect(bool haveCharacterShield, bool haveItemShield){
		
		if(!haveCharacterShield && !haveItemShield){
			if(_animation.isPlaying){
				_animation.Stop() ;
			}
			
			SetActiveSpriteObject(false) ;
			
		}else if(haveCharacterShield && haveItemShield){
			//
			SetActiveSpriteObject(true) ;
			
			_thisSprite.SetSprite(_thisSprite.Collection.GetSpriteIdByName("Fximg_shield2")) ;
			
			if(!_animation.isPlaying){
				_animation.Play() ;
			}
			
		}else if(haveCharacterShield || haveItemShield){
			//
			SetActiveSpriteObject(true) ;
			
			_thisSprite.SetSprite(_thisSprite.Collection.GetSpriteIdByName("Fximg_shield1")) ;
			
			if(!_animation.isPlaying){
				_animation.Play() ;
			}
			
		}
		
	}
	
	
}
