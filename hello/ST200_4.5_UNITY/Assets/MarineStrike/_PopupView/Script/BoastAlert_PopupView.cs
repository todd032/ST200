using UnityEngine;
using System.Collections;

public class BoastAlert_PopupView : MonoBehaviour {

	// ==================== Layout 관련 변수 선언 - Start ====================
	public UILabel BoastAlert_Text_Label;
	public UIButton BoastAlert_OK_Button;
	public UIButton BoastAlert_Cancle_Button;
	public UIButton BoastAlert_Close_Button;
	public UIPanel IndicatorPopupView;
	public UIPanel _uiRootAlertViewObject ;

	private IndicatorPopupView m_IndicatorPopupView;
	private UIRootAlertView _uiRootAlertView ;
	// ==================== Layout 관련 변수 선언 - End ====================

	// ==================== Delegate & Event 인터페이스 선언 - Start ====================
	[HideInInspector]
	public delegate void Delegate_BoastAlert_PopupView(string strUserId_Input);
	protected Delegate_BoastAlert_PopupView _delegate_BoastAlert_PopupView ;
	public event Delegate_BoastAlert_PopupView Event_Delegate_BoastAlert_PopupView {
		add {
			_delegate_BoastAlert_PopupView = null;
			if (_delegate_BoastAlert_PopupView == null){
				_delegate_BoastAlert_PopupView += value;
			}
		}
		remove {
			_delegate_BoastAlert_PopupView -= value;
		}
	}
	// ==================== Delegate & Event 인터페이스 선언 - End ====================


	private string m_strUserId;
	private string m_strUserNickName;
	private int m_intUserScore;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(string strUserId_Input){

		gameObject.SetActive (true);

		Init_01_SetLayout_Default ();
		Init_02_SetUserInfo (strUserId_Input);
		Init_03_SetLayout_Text ();

	}

	private void Init_01_SetLayout_Default(){

		m_IndicatorPopupView = IndicatorPopupView.GetComponent<IndicatorPopupView> () as IndicatorPopupView;
		m_IndicatorPopupView.InitLoadIndicatorPopupView ();

		_uiRootAlertView = _uiRootAlertViewObject.GetComponent<UIRootAlertView>() as UIRootAlertView ;

		// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== Start.
		_uiRootAlertView.Event_Delegate_UIRootAlertView_Kakao += Delegate_UIRootAlertView_Kakao;
		// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== End.

		BoastAlert_OK_Button.gameObject.SetActive (true);
		BoastAlert_Cancle_Button.gameObject.SetActive (true);
		BoastAlert_Close_Button.gameObject.SetActive (false);
	}

	private void Init_02_SetUserInfo(string strUserId_Input){

		m_strUserId = strUserId_Input;
//		//Debug.Log ("ST110 BoastAlert_PopupView.Init_02_SetUserInfo().m_strUserId = " + m_strUserId);

		//for (int i = 0; i < KakaoLeaderBoard.Instance.appGameFriends.Count; i++){
		//
//		//	//Debug.Log ("ST110 BoastAlert_PopupView.Init_02_SetUserInfo().userID = " + KakaoLeaderBoard.Instance.appGameFriends[i].user_id);
		//
		//	if (KakaoLeaderBoard.Instance.appGameFriends[i].user_id.Equals(m_strUserId)){
		//
		//		m_strUserNickName = KakaoLeaderBoard.Instance.appGameFriends[i].nickname;
		//		m_intUserScore = PlayerPrefs.GetInt(Constant.PREFKEY_ThisGameScore_INT);
		//
//		//		//Debug.Log ("ST110 BoastAlert_PopupView.Init_02_SetUserInfo().m_strUserNickName = " + m_strUserNickName);
		//
		//	}
		//}

	}

	private void Init_03_SetLayout_Text(){

		string strTextQuest = m_strUserNickName + "님에게\r\n카카오톡으로 자랑하겠습니까?";

		BoastAlert_Text_Label.text = strTextQuest;
	}

	private void OnClick_OK(){

		Process_Kakao_ActionSendMessage ();
	}

	private void OnClick_Cancle(){

		gameObject.SetActive (false);
	}

	private void OnClick_Close(){

		if (_delegate_BoastAlert_PopupView != null){
			
			_delegate_BoastAlert_PopupView(m_strUserId);
		}

		gameObject.SetActive (false);
	}

	private void Process_Kakao_ActionSendMessage(){

		//ST200KLogManager.Instance.SaveGameBoast(m_strUserId);
		////Debug.Log("ST110 BoastAlert_PopupView.Process_Kakao_ActionSendMessage() Run!!!");
		//
		//m_IndicatorPopupView.LoadIndicatorPopupView ();
		//
		//// EventDelegate 정의 - KakaoManager_ActionUpdateResult.
		//Managers.KaKao.Event_Delegate_KakaoManager_ActionSendMessage += (intResultCode_Input) => {
		//
		//	//Debug.Log("ST110 BoastAlert_PopupView.Process_Kakao_ActionSendMessage().Event_Delegate_KakaoManager_ActionSendMessage.intResultCode_Input = " + intResultCode_Input);
		//
		//	m_IndicatorPopupView.RemoveIndicatorPopupView();
		//
		//	if (intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess){
		//
		//		Managers.UserData.FriendMessageSent++;
		//		if(Managers.UserData.FriendMessageSent % 5 == 0)
		//		{
		//			Managers.UserData.AddLuckyCoupon(1);
		//		}
		//
		//		SetLayout_End();
		//		
		//	} else {
		//
		//		gameObject.SetActive(false);
		//		_uiRootAlertView.LoadUIRootAlertView_Kakao(intResultCode_Input);
		//	}
		//	
		//	Managers.KaKao.Event_Delegate_KakaoManager_ActionSendMessage += null;
		//};
		//
		//// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== Start.
		//string[] replacestrings = new string[]
		//{
		//	KakaoLeaderBoard.Instance.gameMe.nickname ,
		//	m_intUserScore.ToString("#,#"),
		//};
		//string strBoastMessage = TextManager.Instance.GetReplaceString(184, replacestrings);
		//	//KakaoLeaderBoard.Instance.gameMe.nickname + "님이 " + m_intUserScore.ToString("#,#") +" 점을 기록했습니다!  \\"아! 열바다\\" 지금 게임도전!";
		//// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== End.
		//
		//Managers.KaKao.ActionSendMessage(m_strUserId, strBoastMessage);
	}

	private void SetLayout_End(){

		//Debug.Log("ST110 BoastAlert_PopupView.SetLayout_End() Run !!! Start!!!");

		BoastAlert_OK_Button.gameObject.SetActive (false);

		BoastAlert_Cancle_Button.gameObject.SetActive (false);

		BoastAlert_Close_Button.gameObject.SetActive (true);

		BoastAlert_Text_Label.text = "메시지를 보냈습니다!";

	}

	// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== Start.
	private void Delegate_UIRootAlertView_Kakao (int intKakaoResponseCode_Input){
		
		if (intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_CanNot_GetInfo_Certification
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_Common
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_NotEffective_RefreshToken
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_Invalid_Push_Token
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_Invalid_Request
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_CanNot_GetInfo_Certification
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_CanNot_GetInfo_Kakao){
			
			Application.LoadLevel(Constant.SCENE_Main);
		}
	}
	// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== End.

}
