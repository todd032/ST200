using UnityEngine;
using System.Collections;

public class SubmarineAnimationEffectObject : SubmarineEffectObject {

	// Protected.
	protected Animation _animation ;
	
	protected override void Awake ()
	{
		base.Awake ();
		
		_animation = _thisGameObject.animation ;
		
	}
	
	protected override void Start() {
		base.Start() ;	
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update() ;
	}
	
	
	//********	
	//--
	public override void EffectPlay(){
		if(!IsActiveEffectObject()) return ;
		
		base.EffectPlay() ;
		
		if(!_animation.isPlaying){
			_animation.Play() ;
		}
	}
	
	public override void EffectStop(){
		if(!IsActiveEffectObject()) return ;
		
		base.EffectStop() ;
		
		if(_animation.isPlaying){
			_animation.Stop() ;
		}
	}
	
	public override void EffectResume(){
		if(!IsActiveEffectObject()) return ;
		
		base.EffectResume() ;
		
		if(!_animation.isPlaying){
			_animation.Play() ;
		}
		
	}
	
	public override void EffectPause(){
		if(!IsActiveEffectObject()) return ;
		
		base.EffectPause() ;
		
		if(_animation.isPlaying){
			_animation.Stop() ;
		}
	}
}
