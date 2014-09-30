using UnityEngine;
using System.Collections;

public class ShopSceneTutorial3 : TutorialChildView {
	
	public UISprite _tutorialFocusSptire ;
	
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
		
		if(_tutorialIndexNumber == 1){ //헬퍼피쉬 소환.
			
			NGUITools.SetActive(_tutorialIntroducerCharacterSprite.gameObject, true) ;
			_tutorialIntroducerCharacterSprite.animation.Play("TutorialCharacterEnterAni") ;
		
			StartCoroutine("TutorialAction1") ;
			
		}else if(_tutorialIndexNumber == 2){ // 골드 및 크리스탈 구매.
		
			StartCoroutine("TutorialAction2") ;
			
		}
		
	}
	
	protected virtual IEnumerator TutorialAction1() {
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "헬퍼피쉬 소환." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(-297f, -148f, 0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(113f, 116f, 1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "[ea2626]헬퍼피쉬[000000]를 소환할 수 있어.\n레전드 헬퍼피쉬 하나씩은 가지고 있어야지?" ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
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
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "골드 및 크리스탈 구매." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(-120f, -148f, 0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(220f, 116f, 1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "구매 또는 업그레이드를 하기 위해서는 비용이 필요해.\n이곳에서 바로 구매할 수 있고, 모든 화면 상단에도 있으니 언제든지 구매할 수 있어." ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(3, 3) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
}
