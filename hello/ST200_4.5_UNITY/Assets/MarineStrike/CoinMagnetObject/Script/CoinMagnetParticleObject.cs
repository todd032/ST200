using UnityEngine;
using System.Collections;

public class CoinMagnetParticleObject : CoinMagnetBaseObject {

	//public Transform _particleSystemTargetObject ;
	//protected ParticleSystem _particleSystem ;
	
	public CommonEffectObjectTwinkle _commonEffectObjectTwinkle ;
	
	protected override void Awake() {
		base.Awake() ;
		
		//_particleSystem = _particleSystemTargetObject.particleSystem ;
		
	}
	
	//---
	public override void ResetSpriteObject(Vector3 createPosition, Transform submarineTransform){ 
		base.ResetSpriteObject(createPosition, submarineTransform) ;
		
		if(_commonEffectObjectTwinkle != null){
			_commonEffectObjectTwinkle.ResetEffectObject(_thisTransform.position, SpriteSize) ;
			_commonEffectObjectTwinkle.StartAction() ;
		}
		
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
