using UnityEngine;
using System.Collections;

public class RankingSceneTutorial3 : TutorialChildView {
	
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
		
		if(_tutorialIndexNumber == 1){ //미션..
			
			NGUITools.SetActive(_tutorialIntroducerCharacterSprite.gameObject, true) ;
			_tutorialIntroducerCharacterSprite.animation.Play("TutorialCharacterEnterAni") ;
		
			StartCoroutine("TutorialAction5") ; //잠수함변경..
			
			//StartCoroutine("TutorialAction1") ;
			
		}else if(_tutorialIndexNumber == 2){ //선물함..
		
			StartCoroutine("TutorialAction6") ; //캐릭터변경..
			
			//StartCoroutine("TutorialAction2") ;
			
		}else if(_tutorialIndexNumber == 3){ //초대..
		
			
			StartCoroutine("TutorialAction7") ; //게임시작..
			
			//StartCoroutine("TutorialAction3") ;
			
			//StartCoroutine("TutorialAction4") ;
			
		}
		/*
		else if(_tutorialIndexNumber == 4){ //설정..
		
			//StartCoroutine("TutorialAction4") ;
			StartCoroutine("TutorialAction5") ;
			
		}else if(_tutorialIndexNumber == 5){ //잠수함변경..
		
			//StartCoroutine("TutorialAction5") ;
			StartCoroutine("TutorialAction6") ;
			
		}else if(_tutorialIndexNumber == 6){ //캐릭터변경..
		
			//StartCoroutine("TutorialAction6") ;
			StartCoroutine("TutorialAction7") ;
			
		}else if(_tutorialIndexNumber == 7){ //게임시작..
		
			//StartCoroutine("TutorialAction7") ;
			
		}
		 */
		
	}
	
	protected virtual IEnumerator TutorialAction1() { //미션..
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "미션 설명." ;
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(92f,145f,0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(100f,70f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(1f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "마린스트라이크에는 여러가지 다양한 [ea2626]미션[000000]들이 준비되어있어.\n이정도 미션은 껌이겠지?" ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(3, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
		
	}
	
	protected virtual IEnumerator TutorialAction2() { //선물함..
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "선물함 설명." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(205f,145f,0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(100f,70f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "[ea2626]선물함[000000]은\n클랜장 또는 클랜친구들에게 온 선물이나 다양한 보상들을 확인하는곳이야." ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(3, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
	protected virtual IEnumerator TutorialAction3() { //초대..
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "친구 초대하기." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(250f,145f,0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(100f,70f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "[ea2626]초대[000000]는\n ....이야." ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(3, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
	protected virtual IEnumerator TutorialAction4() { //설정..
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "설정 설명." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(314f,145f,0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(100f,70f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "사운드가 마음에 든다면 [ea2626]설정[000000]에서 더 키울 수 있어.\n그외에도 여러가지 설정이 있으니 기호에 맞게 정하면 될꺼야." ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(3, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
	
	protected virtual IEnumerator TutorialAction5() { //잠수함변경..
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "잠수함 변경 및 구매, 무기 업그레이드 설명." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(125f,-15f,0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(160f,190f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "[ea2626]잠수함[000000]을 변경과 [ea2626]무기 업그레이드[000000]가 필요할 때는 이곳을 눌러.\n아참! 또한 이곳에서 [ea2626]헬퍼피쉬[000000]도 변경이 가능해.\n절대 잊지마~" ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(3, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
	protected virtual IEnumerator TutorialAction6() { //캐릭터변경..
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "캐릭터 변경 및 구매 설명." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(280f,-15f,0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(160f,190f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		//_tutorialMessageBalloonContentsLabel.text = "[ea2626]캐릭터[000000]를 바꾸고 싶을 때는 여기를 눌러.\n꼭 나를 선택해 줄꺼지?" ;
		_tutorialMessageBalloonContentsLabel.text = "[ea2626]캐릭터[000000]를 바꾸고 싶을 때는 여기를 눌러.\n[ea2626]BJ엣지님[000000] 캐릭터도 여기에 있다구..." ;

		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(3, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
	
	protected virtual IEnumerator TutorialAction7() { //게임시작..
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "준비하기." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(205f,-185f,0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(310f,90f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "자! 이제 [ea2626]준비하기[000000]를 눌러봐!" ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		
		//_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;		
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(3, 3) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
}
