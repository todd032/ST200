using UnityEngine;
using System.Collections;

public class RankingSceneTutorial1 : TutorialChildView {
	
	
	protected override void Awake(){
		base.Awake() ;
	}
	
	protected override void Start() {
		base.Start() ;
	}
	
	protected override void SetSetTutorialChildView(){
		base.SetSetTutorialChildView() ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(1, 1) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
		
		NGUITools.SetActive(_tutorialIntroducerCharacterSprite.gameObject, true) ;
		_tutorialIntroducerCharacterSprite.animation.Play("TutorialCharacterEnterAni") ;
		
		StartCoroutine("TutorialAction1") ;
		
	}
	
	protected virtual IEnumerator TutorialAction1() {
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "마린스트라이크 튜토리얼 시작." ;
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "반가워. 내이름은 메리.\n[ea2626]마린스트라이크[000000]에 온걸 환영해." ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(1, 3) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
}
