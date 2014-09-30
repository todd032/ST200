using UnityEngine;
using System.Collections;

public class DropPaticleItemObject : DropItemObject {
	
	//public Transform _particleSystemTargetObject ;
	//protected ParticleSystem _particleSystem ;
	
	public CommonEffectObjectTwinkle _commonEffectObjectTwinkle ;
	
	protected override void Awake (){
		base.Awake ();
		
		//_particleSystem = _particleSystemTargetObject.particleSystem ;
		
	}
	
	// Use this for initialization
	protected override void Start () {
		base.Start () ;
	}
	
	
	//-------
	public override void DropItemStartAction(Vector3 createPosition, float directionMoveInitMinPower, float directionMoveInitMaxPower, Vector2 directionMoveMinPower, Vector2 directionMoveMaxPower) {
		
		base.DropItemStartAction(createPosition, directionMoveInitMinPower, directionMoveInitMaxPower, directionMoveMinPower, directionMoveMaxPower) ;
		
		//EffectPlay() ;
		
		if(_commonEffectObjectTwinkle != null){
			_commonEffectObjectTwinkle.ResetEffectObject(_thisTransform.position, SpriteSize) ;
			_commonEffectObjectTwinkle.StartAction() ;
		}
		
	}
	//--------
	
	
	//---- Animation Controller
	public override void EffectPlay(){		
		base.EffectPlay() ;
		
		/*
		if(!IsActiveSpriteObject()) return ;
		
		if(_particleSystem.isStopped && !_particleSystem.isPaused){
			_particleSystem.Play() ;
		}
		*/
	}
	
	public override void EffectStop(){
		base.EffectStop() ;
		
		/*
		if(!IsActiveSpriteObject()) return ;
		
		if(_particleSystem.isPlaying || _particleSystem.isPaused){
			_particleSystem.Stop() ;
		}
		*/
	}
	
	public override void EffectResume(){
		base.EffectResume() ;
		
		/*
		if(!IsActiveSpriteObject()) return ;
		
		if(_particleSystem.isPaused){
			_particleSystem.Play() ;
		}
		*/
		
	}
	
	public override void EffectPause(){
		base.EffectPause() ;
		
		/*
		if(!IsActiveSpriteObject()) return ;
		
		if(!_particleSystem.isPaused && _particleSystem.isPlaying){
			_particleSystem.Pause() ;
		}
		*/
		
	}
}
