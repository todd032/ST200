using UnityEngine;
using System.Collections;

public class GamePlaySceneTutorial2 : TutorialChildView {
	
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
			_tutorialChildViewDelegate(2, 1) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
		_tutorialIndexNumber++ ;
		
		if(_tutorialIndexNumber == 1){ //피버게이지 및 피버모드 설명.
			
			NGUITools.SetActive(_tutorialIntroducerCharacterSprite.gameObject, true) ;
			_tutorialIntroducerCharacterSprite.animation.Play("TutorialCharacterEnterAni") ;
		
			StartCoroutine("TutorialAction1") ;
			
		}else if(_tutorialIndexNumber == 2){ //브레이크와 EMP 아이템 사용.
		
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
		
		_tutorialMessageBalloonTitleLabel.text = "피버게이지 및 피버모드 설명." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(5f,-195f,0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(360f,85f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "적들을 많이 물리치면 [ea2626]피버게이지[000000]가 빨리 모여.\n피버게이지를 가득 채우면 [ea2626]피버모드[000000]돌입. 골드를 많이 획득할 수 있는 기회가 생겨!" ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(2, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
		
	}
	
	protected virtual IEnumerator TutorialAction2() {
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "브레이크와 EMP 아이템 사용." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(307f, -205f, 0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(145f,70f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "[ea2626]브레이크[000000]와 [ea2626]EMP[000000] 아이템을 구매하면 여기에 등록돼.\n브레이크와 EMP 아이템을 통해 위기를 순간을 극복해나갈 수 있으니 잊지마!" ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(2, 3) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
	
	
	
	
	
}
