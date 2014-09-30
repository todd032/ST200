using UnityEngine;
using System.Collections;

public class CoinParticlePatternObject : CoinBasePatternObject {
	
	//public Transform _particleSystemTargetObject ;
	//protected ParticleSystem _particleSystem ;
	
	public CommonEffectObjectTwinkle _commonEffectObjectTwinkle ;
	
	protected override void Awake() {
		base.Awake() ;
		
		//_particleSystem = _particleSystemTargetObject.particleSystem ;
		
	}
	
	//---
	
	public override void ResetPatternObject(float settingValue, float weightLevel){
		base.ResetPatternObject(settingValue, weightLevel) ;
		
		//AnimationPlay() ;
		
		if(_commonEffectObjectTwinkle != null){
			_commonEffectObjectTwinkle.ResetEffectObject(_thisTransform.position, SpriteSize) ;
			_commonEffectObjectTwinkle.StartAction() ;
		}
		
		_currentGameLevel = settingValue ;
		
		_coinState = CoinState.Idle;
		StartCoroutine(_coinState.ToString());
		
	}
	
	public override void ResetPatternObject(float settingValue){ //Use PatternObjectSet
		base.ResetPatternObject(settingValue) ;
		
		//AnimationPlay() ;
		
		if(_commonEffectObjectTwinkle != null){
			_commonEffectObjectTwinkle.ResetEffectObject(_thisTransform.position, SpriteSize) ;
			_commonEffectObjectTwinkle.StartAction() ;
		}
		
		_currentGameLevel = settingValue ;
		
		_coinState = CoinState.Idle;
		StartCoroutine(_coinState.ToString());
		
	}
	
	public override void ResetPatternObject(){ //Use PatternObjectSet
		base.ResetPatternObject() ;
		
		//AnimationPlay() ;
		
		if(_commonEffectObjectTwinkle != null){
			_commonEffectObjectTwinkle.ResetEffectObject(_thisTransform.position, SpriteSize) ;
			_commonEffectObjectTwinkle.StartAction() ;
		}
		
		_coinState = CoinState.Idle;
		StartCoroutine(_coinState.ToString());
		
	}
	
	public override void DestroyPatternObject(int destroyType) {
		base.DestroyPatternObject(destroyType) ;
	}
	
	
	//--
	public override void AnimationPlay() {
		base.AnimationPlay() ;
		/*
		if(_particleSystem.isStopped && !_particleSystem.isPaused){
			_particleSystem.Play() ;
		}
		*/
	}
	
	public override void AnimationStop() {
		base.AnimationStop() ;
		/*
		if(_particleSystem.isPlaying || _particleSystem.isPaused){
			_particleSystem.Stop() ;
		}
		*/
	}
	
	public override void AnimationPause() {
		base.AnimationPause() ;
		/*
		if(!_particleSystem.isPaused && _particleSystem.isPlaying){
			_particleSystem.Pause() ;
		}
		*/
	}
	
	public override void AnimationResume() {
		base.AnimationResume() ;
		/*
		if(_particleSystem.isPaused){
			_particleSystem.Play() ;
		}
		*/
	}
	
}
