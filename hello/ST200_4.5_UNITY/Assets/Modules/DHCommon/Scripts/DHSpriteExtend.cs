using UnityEngine;
using System.Collections;

[RequireComponent (typeof (tk2dSprite))]
public class DHSpriteExtend : MonoBehaviour {
	
	tk2dSprite thisSprite ;
	
	void OnEnable() {
	}
	
	// Use this for initialization
	void Start () {
	
		thisSprite = GetComponent<tk2dSprite>() as tk2dSprite ;
		
	}
	
	public void InitSpriteShowState(){
		Color spriteColor = thisSprite.color;
		spriteColor.a = 1f ;
		thisSprite.color  = spriteColor;
	}
	
	public void InitSpriteHideState(){
		Color spriteColor = thisSprite.color;
		spriteColor.a = 0f ;
		thisSprite.color  = spriteColor;
	}
	
	//--
	public IEnumerator FadeInFunction(float fadeInTime) {
		
		bool isFadeInDone = false ;
		float remainSeconds = 0.0f;
		
		while(!isFadeInDone) {
			
			remainSeconds += Time.deltaTime; 
	
			Color changeAlphaColor = thisSprite.color;
			changeAlphaColor.a = remainSeconds / fadeInTime;
	
			if(changeAlphaColor.a >= 1f) {
				changeAlphaColor.a = 1f ;
				isFadeInDone = true ;
			}
			
			thisSprite.color  = changeAlphaColor;
			
			yield return null ;
		}
		
	}
	
	//--
	public IEnumerator FadeOutFunction(float fadeOutTime) {
		
		bool isFadeOutDone = false ;
		float remainSeconds = 0.0f ;
		
		while(!isFadeOutDone) {
			
			remainSeconds += Time.deltaTime; 
			
			Color changeAlphaColor = thisSprite.color;
			changeAlphaColor.a  = 1.0f - (remainSeconds / fadeOutTime) ;
	
			if(changeAlphaColor.a <= 0f) {
				changeAlphaColor.a = 0f ;
				isFadeOutDone = true ;
			}
			
			thisSprite.color  = changeAlphaColor;
			
			yield return null ;
		}
		
	}
	
}
