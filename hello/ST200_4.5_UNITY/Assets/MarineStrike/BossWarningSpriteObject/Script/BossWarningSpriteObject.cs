using UnityEngine;
using System.Collections;

public class BossWarningSpriteObject : DHPoolSpriteObject {
	
	protected override void Awake (){
		base.Awake ();	
	}
	
	public override void SetActiveSpriteObject(bool isActiveSpriteObject) {
		base.SetActiveSpriteObject(isActiveSpriteObject) ;
	}
	
	public override void ResetSpriteObject(){
		base.ResetSpriteObject() ;
	}
	
	public override void ResetSpriteObject(float settingValue){
		base.ResetSpriteObject(settingValue) ;
	}
	
	public override void DestroySpriteObject(int destroyType) {
		base.DestroySpriteObject(destroyType) ;
	}
	
	// Use this for initialization
	protected override void Start () {
	
	}
	
	public void BossWarningAction(int warningCnt, float warningDelaySec, float fadeInSec, float delaySec, float fadeOutSec) {
		StartCoroutine(DoBossWarningAction(warningCnt, warningDelaySec, fadeInSec, delaySec, fadeOutSec)) ;
	}
	
	protected IEnumerator DoBossWarningAction(int warningCnt, float warningDelaySec, float fadeInSec, float delaySec, float fadeOutSec) {

		for(int i = 0 ; i < warningCnt ; i++) {
			yield return StartCoroutine(BossWarningModule(fadeInSec,delaySec,fadeOutSec)) ;
			// Delay
			yield return new WaitForSeconds(delaySec);
		}
		
		if(_spriteObjectStateDelegate != null){
			_spriteObjectStateDelegate(this,0) ;	
		}
		
		DestroySpriteObject(0) ;
	}
	
	//-------------------
	protected IEnumerator BossWarningModule(float fadeInSec, float delaySec, float fadeOutSec) {
		// FadeIn/FadeOut
		
		//yield return null ;
		// Start Fade In
		bool isFadeInDone = false ;
		float remainSeconds = 0.0f;
		
		while(!isFadeInDone) {
			
			remainSeconds += Time.deltaTime; 
	
			Color spriteAlphaColor = _thisSprite.color;
			spriteAlphaColor.a  = remainSeconds / fadeInSec;
	
			if(spriteAlphaColor.a >= 1f) {
				spriteAlphaColor.a = 1f ;
				isFadeInDone = true ;
			}
			
			_thisSprite.color  = spriteAlphaColor;
			
			yield return null ;
		}
		
		// Delay
		yield return new WaitForSeconds(delaySec);
		
		
		// Start Fade Out
		bool isFadeOutDone = false ;
		remainSeconds = 0.0f ;
		
		while(!isFadeOutDone) {
			
			remainSeconds += Time.deltaTime; 
			
			Color spriteAlphaColor = _thisSprite.color;
			spriteAlphaColor.a  = 1.0f - (remainSeconds / fadeOutSec) ;
	
			if(spriteAlphaColor.a <= 0f) {
				spriteAlphaColor.a = 0f ;
				isFadeOutDone = true ;
			}
			
			_thisSprite.color  = spriteAlphaColor;
			
			yield return null ;
		}
		
		yield return null ;

	}
	
}
