using UnityEngine;
using System.Collections;

public class GamePlaySceneTutorial3 : TutorialChildView {
	
	
	public UISprite _tutorialUpArrowSprite ;
	public UISprite _tutorialDownArrowSprite ;
	
	public UISprite _tutorialFingerSprite ;
	
	private int _tutorialIndexNumber = 0 ;
	
	protected override void Awake(){
		base.Awake() ;
	}
	
	protected override void Start() {
		base.Start() ;
	}
	
	protected override void SetSetTutorialChildView(){
		base.SetSetTutorialChildView() ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(3, 1) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
		_tutorialIndexNumber++ ;
		
		if(_tutorialIndexNumber == 1){ //잠수함 조작 설명.
			
			NGUITools.SetActive(_tutorialIntroducerCharacterSprite.gameObject, true) ;
			_tutorialIntroducerCharacterSprite.animation.Play("TutorialCharacterEnterAni") ;
		
			StartCoroutine("TutorialAction1") ;
			
		}else if(_tutorialIndexNumber == 2){ //마린스트라이크 튜토리얼 종료.
		
			StartCoroutine("TutorialAction2") ;
			
		}
		
		
		
	}
	
	protected virtual IEnumerator TutorialAction1() {
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		
		NGUITools.SetActive(_tutorialUpArrowSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialDownArrowSprite.gameObject, false) ;
		_tutorialFingerSprite.animation.Stop("TutorialFingerAni") ;
		NGUITools.SetActive(_tutorialFingerSprite.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "잠수함 조작 설명." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "다음은 잠수함 조작방법 설명이야.\n상하로 움직이면 잠수함이 이동해.\n간단하지?" ;
		
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialUpArrowSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialDownArrowSprite.gameObject, true) ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFingerSprite.gameObject, true) ;
		_tutorialFingerSprite.animation.Play("TutorialFingerAni") ;
		
		
		yield return new WaitForSeconds(1f) ;

		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(3, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
		
	}
	
	protected virtual IEnumerator TutorialAction2() {
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		
		NGUITools.SetActive(_tutorialUpArrowSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialDownArrowSprite.gameObject, false) ;
		_tutorialFingerSprite.animation.Stop("TutorialFingerAni") ;
		NGUITools.SetActive(_tutorialFingerSprite.gameObject, false) ;
		
		
		_tutorialMessageBalloonTitleLabel.text = "마린스트라이크 튜토리얼 종료." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		
		
		//yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "이제 네가 [ea2626]영웅[000000]이 될 차례야!" ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(3, 3) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
	
	
	
	
	
}
