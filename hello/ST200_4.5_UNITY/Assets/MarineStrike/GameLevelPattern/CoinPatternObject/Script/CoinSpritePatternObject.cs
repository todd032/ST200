using UnityEngine;
using System.Collections;

public class CoinSpritePatternObject : CoinBasePatternObject {
	
	
	protected override void Awake() {
		base.Awake() ;
	}
	
	//---
	
	public override void ResetPatternObject(float settingValue, float weightLevel){
		base.ResetPatternObject(settingValue, weightLevel) ;
		
		_currentGameLevel = settingValue ;
		
		_coinState = CoinState.Idle;
		StartCoroutine(_coinState.ToString());
		
	}
	
	public override void ResetPatternObject(float settingValue){ //Use PatternObjectSet
		base.ResetPatternObject(settingValue) ;
		
		_currentGameLevel = settingValue ;
		
		_coinState = CoinState.Idle;
		StartCoroutine(_coinState.ToString());
		
	}
	
	public override void ResetPatternObject(){ //Use PatternObjectSet
		base.ResetPatternObject() ;
		
		_coinState = CoinState.Idle;
		StartCoroutine(_coinState.ToString());
		
	}
	
	public override void DestroyPatternObject(int destroyType) {
		base.DestroyPatternObject(destroyType) ;
	}
	
	
	//--
	public override void AnimationPlay() {
		base.AnimationPlay() ;
	}
	
	public override void AnimationStop() {
		base.AnimationStop() ;
	}
	
	public override void AnimationPause() {
		base.AnimationPause() ;
	}
	
	public override void AnimationResume() {
		base.AnimationResume() ;
	}
	
}
