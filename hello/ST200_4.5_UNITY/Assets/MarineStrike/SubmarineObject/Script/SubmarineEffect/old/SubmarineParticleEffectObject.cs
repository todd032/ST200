using UnityEngine;
using System.Collections;

public class SubmarineParticleEffectObject : SubmarineEffectObject {

	// Protected.
	protected ParticleSystem _particleSystem ;
	
	
	protected override void Awake ()
	{
		base.Awake ();
		
		_particleSystem = _thisGameObject.particleSystem ;
		
	}
	
	protected override void Start() {
		base.Start() ;	
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update() ;
	}
	
	/*
	public override void InitializeEffectObject() {
		base.InitialzieEffectObject() ;
	}
	
	public override void InitializeEffectObject(Vector3 createPosition) {
		base.InitialzieEffectObject(createPosition) ;
	}
	
	public override void StartEffectObject(){
		base.StartEffectObject() ;
	}
	
	//--
	public override void StopEffectObject() {
		base.StopEffectObject() ;
	}
	*/
	
	
	//********	
	//--
	public override void EffectPlay(){
		if(!IsActiveEffectObject()) return ;
		
		base.EffectPlay() ;
		
		if(_particleSystem.isStopped && !_particleSystem.isPaused){
			_particleSystem.Play() ;
		}
	}
	
	public override void EffectStop(){
		if(!IsActiveEffectObject()) return ;
		
		base.EffectStop() ;
		
		if(_particleSystem.isPlaying || _particleSystem.isPaused){
			_particleSystem.Stop() ;
		}
	}
	
	public override void EffectResume(){
		if(!IsActiveEffectObject()) return ;
		
		base.EffectResume() ;
		
		if(_particleSystem.isPaused){
			_particleSystem.Play() ;
		}
		
	}
	
	public override void EffectPause(){
		if(!IsActiveEffectObject()) return ;
		
		base.EffectPause() ;
		
		if(!_particleSystem.isPaused && _particleSystem.isPlaying){
			_particleSystem.Pause() ;
		}
		
	}
	
}
