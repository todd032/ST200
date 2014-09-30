using UnityEngine;
using System.Collections;

public class RankingSceneTutorial2 : TutorialChildView {
	
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
		
		if(_tutorialIndexNumber == 1){ //클랜 랭킹..
			
			NGUITools.SetActive(_tutorialIntroducerCharacterSprite.gameObject, true) ;
			_tutorialIntroducerCharacterSprite.animation.Play("TutorialCharacterEnterAni") ;
		
			StartCoroutine("TutorialAction1") ;
			
		}else if(_tutorialIndexNumber == 2){ //내점수..
		
			StartCoroutine("TutorialAction2") ;
			
		}else if(_tutorialIndexNumber == 3){ //클랜원들간의 랭킹..
		
			StartCoroutine("TutorialAction3") ;
			
		}else if(_tutorialIndexNumber == 4){ //TOP 랭킹..
		
			StartCoroutine("TutorialAction4") ;

		}

		/* Remove !!!!!
		else if(_tutorialIndexNumber == 5){ //클랜 배틀..
		
			StartCoroutine("TutorialAction5") ;
			
		}
		*/ // End Remove !!!!!
		
		
	}
	
	protected virtual IEnumerator TutorialAction1() {
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "클랜랭킹 설명." ;
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(-285f,150f,0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(120f,50f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(1f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "[ea2626]클랜랭킹[000000]은\n네가 가입한 클랜원들끼리의 랭킹을 확인 할 수 있는곳이야." ;
		
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
		
		_tutorialMessageBalloonTitleLabel.text = "내 정보창 설명." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		

		_tutorialFocusSptire.transform.localPosition = new Vector3(-175f, 68f, 0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(340f, 75f, 1f) ;

/* Remove !!!!!
#if UNITY_EDITOR
		
		_tutorialFocusSptire.transform.localPosition = new Vector3(-175f, 68f, 0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(340f, 75f, 1f) ;
		
#else
		
		if(AfreecaTvData.Instance.userInfo.clan_master_yn.Equals("Y")){ //
			_tutorialFocusSptire.transform.localPosition = new Vector3(-175f, 55f, 0f) ;
			_tutorialFocusSptire.transform.localScale = new Vector3(340f, 115f, 1f) ;
		}else{
			_tutorialFocusSptire.transform.localPosition = new Vector3(-175f, 68f, 0f) ;
			_tutorialFocusSptire.transform.localScale = new Vector3(340f, 75f, 1f) ;
		}

#endif
*/ // End Remove !!!!!
		
		
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "[ea2626]내 정보보기[000000]는\n너의 점수를 알아보기쉽게 위에 따로 준비했어." ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(2, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}
	
	protected virtual IEnumerator TutorialAction3() {
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "클랜원들간의 랭킹 설명." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;



		_tutorialFocusSptire.transform.localPosition = new Vector3(-175f, -85f, 0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(360f, 240f, 1f) ;


/* Remove !!!!!
#if UNITY_EDITOR
		
		_tutorialFocusSptire.transform.localPosition = new Vector3(-175f, -85f, 0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(360f, 240f, 1f) ;
		
#else
		
		if(AfreecaTvData.Instance.userInfo.clan_master_yn.Equals("Y")){ //
			_tutorialFocusSptire.transform.localPosition = new Vector3(-175f, -105f, 0f) ;
			_tutorialFocusSptire.transform.localScale = new Vector3(360f, 215f, 1f) ;
		}else{
			_tutorialFocusSptire.transform.localPosition = new Vector3(-175f, -85f, 0f) ;
			_tutorialFocusSptire.transform.localScale = new Vector3(360f, 240f, 1f) ;
		}

#endif
*/ // End Remove !!!!!
		
		
		
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "[000000]이곳은 [ea2626]클랜원들간의 랭킹[000000]을 확인할 수 있어.\n너와 함께하는 클랜원들과 선의의 경쟁을 하길바라." ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;
		
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(2, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		
	}

	protected virtual IEnumerator TutorialAction4() {
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "탑랭킹 설명." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(-175f,150f,0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(120f,50f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "[ea2626]탑랭킹[000000]은\n각 클랜의 최고 점수를 기록한 클랜원끼리의 랭킹이야." ;
		
		yield return new WaitForSeconds(1f) ;
		
		
		_tutorialFocusSptire.animation.Stop("TutorialFocusAni") ;
		_tutorialFocusSptire.alpha =1f ;
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, true) ;
		_tutorialTouchSprite.animation.Play("TutorialTouchAni") ;


		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(2, 3) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}


		/* Remove !!!!!
		if(_tutorialChildViewDelegate != null){
			_tutorialChildViewDelegate(2, 2) ;	//State 1:false , 2:true , 3:Tutorial Done..
		}
		*/ // End Remove !!!!!
		
	}

	protected virtual IEnumerator TutorialAction5() {
		
		NGUITools.SetActive(_tutorialTouchSprite.gameObject, false) ;
		_tutorialTouchSprite.animation.Stop("TutorialTouchAni") ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, false) ;
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, false) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, false) ;
		
		_tutorialMessageBalloonTitleLabel.text = "클랜배틀 설명." ;
		
		yield return new WaitForSeconds(0.5f) ;
		
		NGUITools.SetActive(_tutorialFocusSptire.gameObject, true) ;
		_tutorialFocusSptire.transform.localPosition = new Vector3(-70f,150f,0f) ;
		_tutorialFocusSptire.transform.localScale = new Vector3(100f,50f,1f) ;
		_tutorialFocusSptire.animation.Play("TutorialFocusAni") ;
		
		
		
		yield return new WaitForSeconds(0.7f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonSprite.gameObject, true) ;
		NGUITools.SetActive(_tutorialMessageBalloonTitleLabel.gameObject, true) ;
		
		
		yield return new WaitForSeconds(0.3f) ;
		
		NGUITools.SetActive(_tutorialMessageBalloonContentsLabel.gameObject, true) ;
		
		_tutorialMessageBalloonContentsLabel.text = "[ea2626]클랜 배틀[000000]은\n여러 클랜에 속한 모든 클랜원들의 점수가 합산되어 경쟁을 펼칠 수 있는곳이야." ;
		
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
