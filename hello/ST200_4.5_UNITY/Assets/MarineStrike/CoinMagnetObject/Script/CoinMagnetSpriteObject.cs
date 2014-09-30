using UnityEngine;
using System.Collections;

public class CoinMagnetSpriteObject : CoinMagnetBaseObject {

	protected override void Awake() {
		base.Awake() ;
	}
	
	//---
	public override void ResetSpriteObject(Vector3 createPosition, Transform submarineTransform){ 
		base.ResetSpriteObject(createPosition, submarineTransform) ;
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
