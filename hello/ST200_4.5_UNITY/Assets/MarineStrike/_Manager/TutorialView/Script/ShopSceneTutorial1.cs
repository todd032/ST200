using UnityEngine;
using System.Collections;

public class ShopSceneTutorial1 : TutorialChildView {
	
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
			_tutorialChildViewDelegate(1, 1) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
		_tutorialIndexNumber++ ;
		
		if(_tutorialIndexNumber == 1){ //아이템샵 설명.
			
			NGUITools.SetActive(_tutorialIntroducerCharacterSprite.gameObject, true) ;
			_tutorialIntroducerCharacterSprite.animation.Play("TutorialCharacterEnterAni") ;
		
			
			StartCoroutine("TutorialAction2") ;
			
			//StartCoroutine("TutorialAction1") ;
			
		}
		/*else if(_tutorialIndexNumber == 2){ //아이템 항목 설명.
		
			StartCoroutine("TutorialAction2") ;
			
		}
		*/
		
	}
	
	protected virtual IEnumerator TutorialAction1() {
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "아이템샵 설명." ;
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "이곳은 [ea2626]아이템샵[000000]이야. 아이템을 구매할 수 있고\n헬퍼피쉬소환, 골드및 크리스탈 충전등 전투에 필요한 모든것이 있지." ;
		
		yield return new WaitForSeconds(1f) ;
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(1, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
	
	protected virtual IEnumerator TutorialAction2() {
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "아이템 설명." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(-180f, 35f, 0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(370f, 250f, 1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "자! 여기서 유용한 [ea2626]아이템[000000]들을 구매 할 수 있어.\n더 많은 적과 보스를 무찌르기 위해서 여기 있는 [ea2626]아이템[000000]들을 이용하면 좋을꺼야." ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(1, 3) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
}
