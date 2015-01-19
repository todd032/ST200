using UnityEngine;
using System.Collections;

public class Constant : MonoBehaviour {

	/// <summary>
	/// CHEATING MODE ON/OFF
	/// </summary>
	/// 
	public readonly static bool VALTEST1 = false;
	public readonly static bool CONNECTFROMUS = false;
    // 프로젝트 정보 ----------------------------------------------------------------------------------------------------------------
    public readonly static string AppVersionInfo = "1.5.0";
    public readonly static string DefalutAppName = "defalut_app_name" ;
    
    public readonly static string AppNameString = "40" ; //VersionCode...
    public readonly static string CURRENT_MARKET = "2" ; // 2 : PlayStore   3 : TStore  4 : Naver.

    
    // 개발 or 상용 모드 ----------------------------------------------------------------------------------------------------------------
#if UNITY_EDITOR
	public static readonly bool PROJECTMODE_Develop = true; //상용시 false로..
	public static readonly bool PROJECTMODE_BalanceTest = true; //상용시 false, 테스트용 벨런스 데이터를 가지고 옴..
	public static readonly bool PROJECTMODE_OutDebugMessage = true; //상용시 false로..
	public static readonly bool PROJECTMODE_IabTest = false; //상용시 false로..
#else
	public static readonly bool PROJECTMODE_Develop = false; //상용시 false로..
	public static readonly bool PROJECTMODE_BalanceTest = false; //상용시 false, 테스트용 벨런스 데이터를 가지고 옴..
	public static readonly bool PROJECTMODE_OutDebugMessage = false; //상용시 false로..
	public static readonly bool PROJECTMODE_IabTest = false; //상용시 false로..
#endif
    
    // Scene ----------------------------------------------------------------------------------------------------------------
    public static readonly string SCENE_Polycube = "Polycube";
    public static readonly string SCENE_Intro = "Intro";
    public static readonly string SCENE_Main = "Main";
    public static readonly string SCENE_Ranking = "Ranking";
    public static readonly string SCENE_Shop = "Shop";
    public static readonly string SCENE_GameMainLoadingScene = "GameMainLoadingScene";
    public static readonly string SCENE_GameMain = "GameMain";
    public static readonly string SCENE_SubMarineSelect = "SubMarineSelect";
	public static readonly string SCENE_AssetLoading = "AssetLoadingScene";
	public static readonly string SCENE_Explain = "ExplainScene";

    // 환경변수(Preference) Key ------------------------------------------------------------------------------------------------------------------------
	public static readonly string PREFKEY_Agreement_INT = "PREFKEY_Agreement_INT";
	public static readonly string PREFKEY_MainScene_To_RankingScene_INT = "PREFKEY_MainScene_To_RankingScene_INT";
    public static readonly string PREFKEY_ReadUserData_Extend = "PREFKEY_ReadUserData_Extend";
	public static readonly string PREFKEY_ExperiencePopup_Mode_INT = "PREFKEY_ExperiencePopup_Mode_INT";
	public static readonly string PREFKEY_MyRank_Before_INT = "PREFKEY_MyRank_Before_INT";
	public static readonly string PREFKEY_ThisGameScore_INT = "PREFKEY_ThisGameScore_INT";

	// 공지&이벤트&크로스 팝업 관련. --------------------------------------------------------------------------------------------------------------------------------------------
	public static readonly int HIDETODAY_Yes_INT = 1;
	public static readonly int HIDETODAY_No_INT = 2;
	
	public static readonly int POPUPTYPE_Notice_INT = 1;
	public static readonly int POPUPTYPE_Event_INT = 2;
	public static readonly int POPUPTYPE_Ranking_INT = 3;
	public static readonly int POPUPTYPE_Cross_INT = 4;
	
	public static readonly string PREFKEY_IndexHide_PopupNotice_STR = "PREFKEY_IndexHide_PopupNotice_STR";
	public static readonly string PREFKEY_IndexHide_PopupEvent_STR = "PREFKEY_IndexHide_PopupEvent_STR";
	public static readonly string PREFKEY_IndexHide_PopupRanking_STR = "PREFKEY_IndexHide_PopupRanking_STR";
	public static readonly string PREFKEY_IndexHide_PopupCross_STR = "PREFKEY_IndexHide_PopupCross_STR";

	public static readonly string PREFKEY_IndexHide_ChangeTime_PopupNotice_STR = "PREFKEY_IndexHide_ChangeTime_PopupNotice_STR";
	public static readonly string PREFKEY_IndexHide_ChangeTime_PopupEvent_STR = "PREFKEY_IndexHide_ChangeTime_PopupEvent_STR";
	public static readonly string PREFKEY_IndexHide_ChangeTime_PopupRanking_STR = "PREFKEY_IndexHide_ChangeTime_PopupRanking_STR";
	public static readonly string PREFKEY_IndexHide_ChangeTime_PopupCross_STR = "PREFKEY_IndexHide_ChangeTime_PopupCross_STR";

	public static readonly string PREFKEY_NetworkResult_GetConData_STR = "PREFKEY_NetworkResult_GetConData_STR";

	//public static readonly string POPUPEVENT_TO_CHARACTER = "goto:shop";
	//public static readonly string POPUPEVENT_TO_SUBMARINE = "APP_SUBMARINE";
	public static readonly string POPUPEVENT_TO_CASH = "goto:shop";
	// -------------------------------------------------------------------------------------------------------------------------------------------------------

    
    // 통신 관련 --------------------------------------------------------------------------------------------------------------------------------------------
    public static readonly string CHECKSUM_Key = "tjralsthsqkqh";
    
	public static string URL_RELEASE_SERVER_URL = "http://st200.polycube.co.kr/";
    public static readonly string URL_RELEASE_Connect = "st200/connect.php";
    public static readonly string URL_RELEASE_ConfigData = "st200/config_data.php";
    public static readonly string URL_RELEASE_UserData = "st200/user_data.php";
    public static readonly string URL_RELEASE_Message = "st200/message.php";
    public static readonly string URL_RELEASE_BannerTouch = "st200/banner_touch.php";
    public static readonly string URL_RELEASE_ClanBattle = "st200/clan_battle.php";
    public static readonly string URL_RELEASE_Token = "st200/token.php";
    public static readonly string URL_RELEASE_ItemLog = "st200/item_log.php";
    public static readonly string URL_RELEASE_AppCharge = "st200/appcharge.php";
	public static readonly string URL_RELEASE_WorldRanking_Get = "https://wrank.polycube.co.kr/st200/get_ranking.php";
	public static readonly string URL_RELEASE_WorldRanking_Update = "https://wrank.polycube.co.kr/st200/update_result.php";
	public static readonly string URL_RELEASE_NICKNAME = "https://wrank.polycube.co.kr/st200/check_nickname.php";
	public static readonly string URL_RELEASE_PushInfo = "http://14.63.165.28/st200/push.php";
	public static readonly string URL_RELEASE_PvpInfo = "st200/pvp.php";

	public static string URL_DEVELOP_SERVER_URL = "http://14.63.165.28/";
	public static readonly string URL_DEVELOP_Connect = "st200/connect.php";
	public static readonly string URL_DEVELOP_ConfigData = "st200/config_data.php";
	public static readonly string URL_DEVELOP_UserData = "st200/user_data.php";
	public static readonly string URL_DEVELOP_Message = "st200/message.php";
	public static readonly string URL_DEVELOP_BannerTouch = "st200/banner_touch.php";
	public static readonly string URL_DEVELOP_ClanBattle = "st200/clan_battle.php";
	public static readonly string URL_DEVELOP_Token = "st200/token.php";
	public static readonly string URL_DEVELOP_ItemLog = "st200/item_log.php";
	public static readonly string URL_DEVELOP_AppCharge = "st200/appcharge.php";
	public static readonly string URL_DEVELOP_WorldRanking_Get = "https://wrank.polycube.co.kr/st200/get_ranking.php";
	public static readonly string URL_DEVELOP_WorldRanking_Update = "https://wrank.polycube.co.kr/st200/update_result.php";
	public static readonly string URL_DEVELOP_NICKNAME = "https://wrank.polycube.co.kr/st200/check_nickname.php";
	public static readonly string URL_DEVELOP_PushInfo = "http://14.63.165.28/st200/push.php";
	public static readonly string URL_DEVELOP_PvpInfo = "st200/pvp.php";

	// 크로스광고 팝업 기능 추가(by 최원석 14.04.30) ----- Start.
	public static readonly string URL_Popup_Info = "http://gamehub.polycube.co.kr/cross_popup/popup_info.php";
	public static readonly string URL_Popup_Touch = "http://gamehub.polycube.co.kr/cross_popup/popup_touch.php";

	// 크로스광고 팝업 기능 추가(by 최원석 14.04.30) ----- End.

    public static readonly string NETWORK_SENDMODE_GetConData = "GetConData";
    public static readonly string NETWORK_SENDMODE_MakeBalanceData = "MakeBalanceData";
    public static readonly string NETWORK_SENDMODE_ReadBalanceData = "ReadBalanceData";
    public static readonly string NETWORK_SENDMODE_ReadBalanceDataDebug = "ReadBalanceDataDebug";
    public static readonly string NETWORK_SENDMODE_ReadUserData = "ReadUserData";
    public static readonly string NETWORK_SENDMODE_ReadUserDataExp = "ReadUserDataExp";
	public static readonly string NETWORK_SENDMODE_DeleteUserData = "DeleteUserData";
    public static readonly string NETWORK_SENDMODE_SaveUserData = "SaveUserData";
    public static readonly string NETWORK_SENDMODE_ReadBattleData = "ReadBattleData";
    public static readonly string NETWORK_SENDMODE_SendMessageInfo = "SendMessageInfo";
    public static readonly string NETWORK_SENDMODE_GetMessageList = "GetMessageList";
    public static readonly string NETWORK_SENDMODE_OpenMessage = "OpenMessage";
    public static readonly string NETWORK_SENDMODE_MessageBlockUserList = "MessageBlockUserList";
    public static readonly string NETWORK_SENDMODE_GetGroupMessageStatus = "GetGroupMessageStatus";
	public static readonly string NETWORK_SENDMODE_OpenAllMessage = "OpenAllMessage";
	public static readonly string NETWORK_SENDMODE_SendGroupMessageInfo = "SendGroupMessageInfo";
	public static readonly string NETWORK_SENDMODE_SendGroupInviteInfo = "SendGroupInviteInfo";
    public static readonly string NETWORK_SENDMODE_CheckAndUpdateUser = "CheckAndUpdateUser";
    public static readonly string NETWORK_SENDMODE_SaveUserScore = "SaveUserScore";
    public static readonly string NETWORK_SENDMODE_SaveToken = "SaveToken";
    public static readonly string NETWORK_SENDMODE_GetPushOnOff = "GetPushOnOff";
    public static readonly string NETWORK_SENDMODE_SetPushOnOff = "SetPushOnOff";
    public static readonly string NETWORK_SENDMODE_SaveLog = "SaveLog";
    public static readonly string NETWORK_SENDMODE_SaveChargeDataTest = "SaveChargeDataTest";
    public static readonly string NETWORK_SENDMODE_SaveChargeData = "SaveChargeData";
	public static readonly string NETWORK_SENDMODE_PVPRecommendList = "RecommendList";
	public static readonly string NETWORK_SENDMODE_PVPFriendList = "FriendsList";
	public static readonly string NETWORK_SENDMODE_PVPFriendSearchList = "SearchFriends";
	public static readonly string NETWORK_SENDMODE_PVPFriendAdd = "AddFriends";
	public static readonly string NETWORK_SENDMODE_PVPFriendRemove = "RemoveFriends";
	public static readonly string NETWORK_SENDMODE_PVPSaveResult = "SaveBattleResult";
	public static readonly string NETWORK_SENDMODE_PVPWorldRank = "RankListAll";
	public static readonly string NETWORK_SENDMODE_PVPFriendRank = "RankListFriends";
	public static readonly string NETWORK_SENDMODE_PVPHistory = "BattleHistory";
	public static readonly string NETWORK_SENDMODE_PVPPopup = "PopupHistory";
	public static readonly string NETWORK_SENDMODE_PVPFriendAddPopup = "PopupFriendAdd";

    public static readonly int NETWORK_RESULTCODE_OK = 1;
    public static readonly int NETWORK_RESULTCODE_Error_Network = 101;
    public static readonly int NETWORK_RESULTCODE_Error_CheckSum = 111;
    public static readonly int NETWORK_RESULTCODE_Error_UserData = 121;
    public static readonly int NETWORK_RESULTCODE_Error_BalanceData = 122;
    public static readonly int NETWORK_RESULTCODE_Error_TimeSync = 131;
    public static readonly int NETWORK_RESULTCODE_Error_Result_False = 142;
    public static readonly int NETWORK_RESULTCODE_Error_Result_Extend = 143;
    public static readonly int NETWORK_RESULTCODE_Error_Result_Data = 144;
	public static readonly int NETWORK_RESULTCODE_Error_UserSequence = 145;    
	public static readonly string NETWORK_RESULTCODE_Error_UserSequence_Message = "UPDATE_SEQUENCE_ERROR";
    
    public static readonly int ALLERTCODE_NetworkError = 11;
    public static readonly int ALLERTCODE_DataError = 21;
    
    // 아이템 및 상품 코드 & 이미지명 --------------------------------------------------------------------------------------------------------------------------------------------
    public static readonly int ITEM_CODE_Torpedo = 1;
    public static readonly int ITEM_CODE_Gold = 2;
    public static readonly int ITEM_CODE_Crystal = 3;
    public static readonly int ITEM_CODE_StartDash = 1001;
    public static readonly int ITEM_CODE_Shield = 1002;
    public static readonly int ITEM_CODE_LastAttack = 1003;
    public static readonly int ITEM_CODE_Repair = 1004;
    public static readonly int ITEM_CODE_Brake = 1005;
    public static readonly int ITEM_CODE_EMP = 1006;
    
    public static readonly string ITEM_NAME_Torpedo = "어뢰";
    public static readonly string ITEM_NAME_Gold = "코인";
    public static readonly string ITEM_NAME_Crystal = "크리스탈";
    public static readonly string ITEM_NAME_StartDash = "스타트 대시";
    public static readonly string ITEM_NAME_Shield = "보호막";
    public static readonly string ITEM_NAME_LastAttack = "라스트 어택";
    public static readonly string ITEM_NAME_Repair = "긴급수리";
    public static readonly string ITEM_NAME_Brake = "브레이크";
    public static readonly string ITEM_NAME_EMP = "EMP";
    public static readonly string ITEM_NAME_Pet = "펫";


	// 카카오 Response 코드 --------------------------------------------------------------------------------------------------------------------------------------------

	public static readonly int KAKAO_RESPONSE_CODE_Sucess = 0;
	public static readonly int KAKAO_RESPONSE_CODE_Error = -1;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Network = 4000;
	public static readonly int KAKAO_RESPONSE_CODE_Error_NotSupported_In_Guest_Mode = 8;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Success_Not_Verified = 10;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Under_Maintenance = -9798;
	public static readonly int KAKAO_RESPONSE_CODE_Error_NotEffective_AccessToken = -1000;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Common = -500;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Lower_Age_Limit = -451;
	public static readonly int KAKAO_RESPONSE_CODE_Error_NotEffective_RefreshToken = -400;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Invalid_Push_Token = -200;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Insufficient_Permission = -100;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Exceed_Invite_Chat_Limit = -31;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Exceed_Invite_1Day_Limit = -32;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Exceed_Invite_Message_Limit = -33;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Invite_Message_Blocked = -17;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Message_Block_User = -16;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Chat_Not_Found = -15;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Unsupported_Device = -14;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Unregisterd_User = -13;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Invalid_Request = -12;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Deactivated_User = -11;
	public static readonly int KAKAO_RESPONSE_CODE_Error_Not_Found = -10;
	public static readonly int KAKAO_RESPONSE_CODE_Error_CanNot_GetInfo_Certification = -41;
	public static readonly int KAKAO_RESPONSE_CODE_Error_CanNot_GetInfo_Kakao = 6;

	// 카카오 팝업 문구 --------------------------------------------------------------------------------------------------------------------------------------------
	public static readonly string KAKAO_POPUP_TEXT_Error_Network = "네트워크 접속이 원활하지 않습니다.  잠시 후 재시도하거나 게임을 종료 후 다시 시작 바랍니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_NotSupported_In_Guest_Mode = "Guest Login 상태에서는 지원하지 않는 기능입니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Success_Not_Verified = "계정 연결에는 성공하였으나 해당 사용자의 카카오계정은 아직 이메일 인증을 받지 않았습니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Under_Maintenance = "인증서버가 점검중입니다. 잠시 후 재시도하거나 게임을 종료 후 다시 시작 바랍니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_NotEffective_AccessToken = "장시간 접속하지 않아 게임을 다시 시작합니다. 진행 중이던 게임의 정보는 저장되지 않습니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Common = "네트워크 접속이 끊어졌습니다. 초기 화면으로 이동합니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Lower_Age_Limit = "해당 앱의 이용가능 연령에 미달하는 사용자입니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_NotEffective_RefreshToken = "네트워크 접속이 끊어졌습니다. 초기 화면으로 이동합니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Invalid_Push_Token = "네트워크 접속이 끊어졌습니다. 초기 화면으로 이동합니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Insufficient_Permission = "권한이 없습니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Exceed_Invite_Chat_Limit = "초대메시지를 보낼 수 없는 사용자입니다. 초대메시지는 같은 수신자에게는 30일에 1번만 보낼 수 있습니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Exceed_Invite_1Day_Limit = "1일 초대 횟수 30회를 초과하였습니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Exceed_Invite_Message_Limit = "더 이상 메시지를 보낼 수 없습니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Invite_Message_Blocked = "메시지 수신을 차단한 사용자입니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Message_Block_User = "메시지 수신을 차단한 사용자입니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Chat_Not_Found = "채팅방 정보를 찾을 수 없습니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Unsupported_Device = "메시지 수신을 차단한 사용자입니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Unregisterd_User = "등록되지 않은 사용자입니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Invalid_Request = "네트워크 접속이 끊어졌습니다. 초기 화면으로 이동합니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Deactivated_User = "탈퇴한 사용자입니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_Not_Found = "해당 사용자의 카카오 계정 정보를 찾을 수 없습니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_CanNot_GetInfo_Certification = "인증서버에서 정보를 불러올 수 없습니다. 초기화면으로 이동합니다.";
	public static readonly string KAKAO_POPUP_TEXT_Error_CanNot_GetInfo_Kakao = "카카오 정보를 불러올 수 없습니다. 초기화면으로 이동합니다.";

	public static readonly string KAKAO_POPUP_TEXT_UnRegister = "게임을 탈퇴하실 경우 모든 게임 데이터, 결제하신 모든 상품들과 구매내역이 삭제되며, 탈퇴 후에는 복구가 불가능합니다. 정말 탈퇴하시겠습니까?";

    
    // -------------------------------------------------------------------------------------------------------------------------------------------------------

	public static readonly string SETTING_POPUP_TEXT_Block_Kakao_On = "카카오톡에서 보내는 메세지를 받겠습니까?";
	public static readonly string SETTING_POPUP_TEXT_Block_Kakao_Off = "카카오톡에서 보내는 메세지를 받지 않겠습니까?";

	// -------------------------------------------------------------------------------------------------------------------------------------------------------
    
    public static readonly int INT_False = 0;
    public static readonly int INT_True = 1;
    
    public static readonly string STR_NONE = "NONE";
    
    public static readonly int SENDMODE_ReadUserData = 0;
    public static readonly int SENDMODE_ReadUserDataExp = 1;
    
	// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== Start.
	public static readonly string QNA_Subject_STR = "?subject=게임 문의(";
	public static readonly string QNA_Body_STR = "&body=앱 ID : ";

	public static readonly string QNA_Subject_STR_ENG = "?subject=Game Questions(";
	public static readonly string QNA_Body_STR_ENG = "?body=APP ID: ";
	// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== End.

    
    // -------------------------------------------------------------------------------------------------------------------------------------------------------
    

	/////
	private readonly static string UpdateInfoPopupView_TextLabel_en = "MarineStrike New Version" ;
	private readonly static string UpdateInfoPopupView_TextLabel_ko = "버전이 맞지 않습니다.\n새로운 버전을 다운 받아주세요." ;
	
	public static string UpdateInfoPopupViewTextLabelString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = UpdateInfoPopupView_TextLabel_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = UpdateInfoPopupView_TextLabel_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = UpdateInfoPopupView_TextLabel_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = UpdateInfoPopupView_TextLabel_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = UpdateInfoPopupView_TextLabel_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = UpdateInfoPopupView_TextLabel_en ;
		}
		
		return returnString ;
		
	}


	private readonly static string settingPopupView_SelectLanguage_en = "English" ;
	private readonly static string settingPopupView_SelectLanguage_ko = "한국어" ;
	private readonly static string settingPopupView_SelectLanguage_hant = "中國傳統" ;
	private readonly static string settingPopupView_SelectLanguage_hans = "简体中文版" ;
	private readonly static string settingPopupView_SelectLanguage_ja = "日本語" ;
	private readonly static string settingPopupView_SelectLanguage_fr = "français" ;
	
	public static string SettingPopupViewSelectLanguageString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = settingPopupView_SelectLanguage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = settingPopupView_SelectLanguage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = settingPopupView_SelectLanguage_hant ;
		}else if(languageCode.Equals("Hans")){
			returnString = settingPopupView_SelectLanguage_hans ;
		}else if(languageCode.Equals("Ja")){
			returnString = settingPopupView_SelectLanguage_ja ;
		}else if(languageCode.Equals("Fr")){
			returnString = settingPopupView_SelectLanguage_fr ;
		}
		
		return returnString ;
		
	}
	
	/////////////////////
	
	
	
	
	
	//////////////////
	private readonly static string gameCharaterSelectUI_Title_en = "Character" ;
	private readonly static string gameCharaterSelectUI_Title_ko = "캐릭터" ;
	
	public static string GetGameCharaterSelectUITitleString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = gameCharaterSelectUI_Title_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = gameCharaterSelectUI_Title_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = gameCharaterSelectUI_Title_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = gameCharaterSelectUI_Title_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = gameCharaterSelectUI_Title_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = gameCharaterSelectUI_Title_en ;
		}
		
		return returnString ;
		
	}
	
	
	private readonly static string gameSubmarineSelectUI_Title_en = "Submarine" ;
	private readonly static string gameSubmarineSelectUI_Title_ko = "잠수함" ;
	
	public static string GetGameSubmarineSelectUITitleString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = gameSubmarineSelectUI_Title_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = gameSubmarineSelectUI_Title_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = gameSubmarineSelectUI_Title_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = gameSubmarineSelectUI_Title_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = gameSubmarineSelectUI_Title_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = gameSubmarineSelectUI_Title_en ;
		}
		
		return returnString ;
		
	}
	
	
	//--
	private readonly static string gameSubmarineSelectUI_SubmarineCaptionView_BulletPower_en = "Power" ;
	private readonly static string gameSubmarineSelectUI_SubmarineCaptionView_BulletPower_ko = "파워" ;
	
	public static string GetGameSubmarineSelectUISubmarineCaptionViewBulletPowerString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletPower_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletPower_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletPower_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletPower_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletPower_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletPower_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string gameSubmarineSelectUI_SubmarineCaptionView_BulletSpeed_en = "Speed" ;
	private readonly static string gameSubmarineSelectUI_SubmarineCaptionView_BulletSpeed_ko = "발사속도" ;
	
	public static string GetGameSubmarineSelectUISubmarineCaptionViewBulletSpeedString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSpeed_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSpeed_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSpeed_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSpeed_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSpeed_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSpeed_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string gameSubmarineSelectUI_SubmarineCaptionView_BulletSplash_en = "Splash" ;
	private readonly static string gameSubmarineSelectUI_SubmarineCaptionView_BulletSplash_ko = "공격범위" ;
	
	public static string GetGameSubmarineSelectUISubmarineCaptionViewBulletSplashString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSplash_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSplash_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSplash_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSplash_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSplash_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = gameSubmarineSelectUI_SubmarineCaptionView_BulletSplash_en ;
		}
		
		return returnString ;
		
	}
	
	/////////////////////
	
	
	private readonly static string subweaponSlotPurchasePopup_PopupMessageLabel_en = "Slot Slot Slot" ;
	private readonly static string subweaponSlotPurchasePopup_PopupMessageLabel_ko = "슬롯을 추가하면 헬퍼 피쉬를 한 개 더 사용할 수 있습니다." ;
	
	public static string SubweaponSlotPurchasePopupMessageLabelString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponSlotPurchasePopup_PopupMessageLabel_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponSlotPurchasePopup_PopupMessageLabel_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponSlotPurchasePopup_PopupMessageLabel_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponSlotPurchasePopup_PopupMessageLabel_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponSlotPurchasePopup_PopupMessageLabel_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponSlotPurchasePopup_PopupMessageLabel_en ;
		}
		
		return returnString ;
		
	}
	
	/////////////////////
	
	
	private readonly static string subweaponSlotPurchasePopup_SlotTitleLabel_en = "Slot Attach" ;
	private readonly static string subweaponSlotPurchasePopup_SlotTitleLabel_ko = "슬롯추가" ;
	
	public static string SubweaponSlotPurchasePopupSlotTitleLabelString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponSlotPurchasePopup_SlotTitleLabel_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponSlotPurchasePopup_SlotTitleLabel_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponSlotPurchasePopup_SlotTitleLabel_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponSlotPurchasePopup_SlotTitleLabel_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponSlotPurchasePopup_SlotTitleLabel_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponSlotPurchasePopup_SlotTitleLabel_en ;
		}
		
		return returnString ;
		
	}
	
	/////////////////////
	
	
	//--- MissionRewardPopupView
	private readonly static string missionRewardPopupView_RewardTextLabel_en = "Reward Text Message" ;
	private readonly static string missionRewardPopupView_RewardTextLabel_ko = "미션 달성 보상을 획득하셨습니다." ;
	
	public static string MissionRewardPopupViewRewardTextLabelString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = missionRewardPopupView_RewardTextLabel_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = missionRewardPopupView_RewardTextLabel_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = missionRewardPopupView_RewardTextLabel_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = missionRewardPopupView_RewardTextLabel_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = missionRewardPopupView_RewardTextLabel_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = missionRewardPopupView_RewardTextLabel_en ;
		}
		
		return returnString ;
		
	}


	//--- MissionPopupView
	private readonly static string missionFailureTextLabel_en = "Failure" ;
	private readonly static string missionFailureTextLabel_ko = "미션실패" ;  //미션실패
	
	public static string MissionFailureTextLabelString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = missionFailureTextLabel_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = missionFailureTextLabel_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = missionFailureTextLabel_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = missionFailureTextLabel_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = missionFailureTextLabel_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = missionFailureTextLabel_en ;
		}
		
		return returnString ;
		
	}

	/////////////////////
	
	
	
	
	//--- SubweaponGachaPopupView
	private readonly static string subweaponGachaPopupView_SubweaponGachaCongratulationsLabel_en = "Congratulations" ;
	private readonly static string subweaponGachaPopupView_SubweaponGachaCongratulationsLabel_ko = "축하합니다." ;
	
	public static string SubweaponGachaPopupViewSubweaponGachaCongratulationsLabelString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponGachaPopupView_SubweaponGachaCongratulationsLabel_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponGachaPopupView_SubweaponGachaCongratulationsLabel_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponGachaPopupView_SubweaponGachaCongratulationsLabel_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponGachaPopupView_SubweaponGachaCongratulationsLabel_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponGachaPopupView_SubweaponGachaCongratulationsLabel_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponGachaPopupView_SubweaponGachaCongratulationsLabel_en ;
		}
		
		return returnString ;
		
	}
	
	/////
	private readonly static string subweaponGachaPopupView_SubweaponGachaCompleteLabel_Success_en = "New Helper Fish.." ;
	private readonly static string subweaponGachaPopupView_SubweaponGachaCompleteLabel_Success_ko = "새로운 헬퍼피쉬가 소환되었습니다." ;
	
	public static string SubweaponGachaPopupViewSubweaponGachaCompleteLabelSuccessString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Success_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Success_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Success_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Success_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Success_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Success_en ;
		}
		
		return returnString ;
		
	}
	
	/////
	private readonly static string subweaponGachaPopupView_SubweaponGachaCompleteLabel_Failure_en = "Already Helper Fish.." ;
	private readonly static string subweaponGachaPopupView_SubweaponGachaCompleteLabel_Failure_ko = "중복 소환되었습니다.\n\n소환비용의 절반을 돌려드립니다." ;
	
	public static string SubweaponGachaPopupViewSubweaponGachaCompleteLabelFailureString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Failure_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Failure_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Failure_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Failure_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Failure_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponGachaPopupView_SubweaponGachaCompleteLabel_Failure_en ;
		}
		
		return returnString ;
		
	}
	
	/////////////////////
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	//-------------------------------------------------------------------	
	private readonly static string subweaponPurchasePopupPopupGoldValueType_en = "Gold" ;
	private readonly static string subweaponPurchasePopupPopupGoldValueType_ko = "골드[ffffff]를" ;
	private readonly static string subweaponPurchasePopupPopupJewelValueType_en = "Crystal" ;
	private readonly static string subweaponPurchasePopupPopupJewelValueType_ko = "크리스탈[ffffff]을" ;
	private readonly static string subweaponPurchasePopupPopupMessage_en = "[ffffff]Subweapon Purchase {0}{1} [ffffff]Is Ok?" ;
	private readonly static string subweaponPurchasePopupPopupMessage_ko = "{0}{1} [ffffff]사용하여 헬퍼 피쉬를 소환하시겠습니까?" ;
	
	public static string SubweaponPurchasePopupPopupMessageLabelString(string languageCode, int valueType, int purchaseValue) {
	
		string returnString = "" ;
		
		string valueInfoString = "" ;
		
		if(valueType == 1){
			valueInfoString =  "[ffc800]" ;
		}else if(valueType == 2){
			valueInfoString =  "[00ffff]" ;
		}
		
		if(purchaseValue == 0){
			valueInfoString += purchaseValue.ToString() ;	
		}else{
			valueInfoString += purchaseValue.ToString("#,#") ;	
		}
		
		
		if(languageCode.Equals("En")){
			if(valueType == 1){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_en,valueInfoString,subweaponPurchasePopupPopupGoldValueType_en) ;	
			}else if(valueType == 2){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_en,valueInfoString,subweaponPurchasePopupPopupJewelValueType_en) ;	
			}
		}else if(languageCode.Equals("Ko")){
			if(valueType == 1){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_ko,valueInfoString,subweaponPurchasePopupPopupGoldValueType_ko) ;	
			}else if(valueType == 2){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_ko,valueInfoString,subweaponPurchasePopupPopupJewelValueType_ko) ;
			}
		}else if(languageCode.Equals("Hant")){
			if(valueType == 1){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_en,valueInfoString,subweaponPurchasePopupPopupGoldValueType_en) ;	
			}else if(valueType == 2){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_en,valueInfoString,subweaponPurchasePopupPopupJewelValueType_en) ;	
			}
		}else if(languageCode.Equals("Hans")){
			if(valueType == 1){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_en,valueInfoString,subweaponPurchasePopupPopupGoldValueType_en) ;	
			}else if(valueType == 2){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_en,valueInfoString,subweaponPurchasePopupPopupJewelValueType_en) ;	
			}
		}else if(languageCode.Equals("Ja")){
			if(valueType == 1){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_en,valueInfoString,subweaponPurchasePopupPopupGoldValueType_en) ;	
			}else if(valueType == 2){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_en,valueInfoString,subweaponPurchasePopupPopupJewelValueType_en) ;	
			}
		}else if(languageCode.Equals("Fr")){
			if(valueType == 1){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_en,valueInfoString,subweaponPurchasePopupPopupGoldValueType_en) ;	
			}else if(valueType == 2){
				returnString = string.Format(subweaponPurchasePopupPopupMessage_en,valueInfoString,subweaponPurchasePopupPopupJewelValueType_en) ;	
			}
		}
		
		return returnString ;
		
	}
	
	/////////////////////
	
	
	
	private readonly static string presentReceivePopupViewMessage1_en = "Receive Present Ok!!" ;
	private readonly static string presentReceivePopupViewMessage1_ko = "선물을 받았습니다." ;
	
	public static string PresentReceivePopupViewMessage1String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = presentReceivePopupViewMessage1_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = presentReceivePopupViewMessage1_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = presentReceivePopupViewMessage1_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = presentReceivePopupViewMessage1_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = presentReceivePopupViewMessage1_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = presentReceivePopupViewMessage1_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string presentReceivePopupViewMessage2_en = "Receive All Present Ok!!" ;
	private readonly static string presentReceivePopupViewMessage2_ko = "모든 선물을 받았습니다." ;
	
	public static string PresentReceivePopupViewMessage2String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = presentReceivePopupViewMessage2_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = presentReceivePopupViewMessage2_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = presentReceivePopupViewMessage2_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = presentReceivePopupViewMessage2_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = presentReceivePopupViewMessage2_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = presentReceivePopupViewMessage2_en ;
		}
		
		return returnString ;
		
	}
	/////////////////////
	

	private readonly static string alertCRCErrorMessage_en = "Package Error!" ;
	private readonly static string alertCRCErrorMessage_ko = "패키지가 올바르지 않습니다.\n해당 마켓에서 다시 설치 후 실행해 주세요." ;
	
	public static string AlertCRCMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertCRCErrorMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertCRCErrorMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertCRCErrorMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertCRCErrorMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertCRCErrorMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertCRCErrorMessage_en ;
		}
		
		return returnString ;
		
	}
	///////


	private readonly static string alertNetworkErrorMessage_en = "Network Error!" ;
	private readonly static string alertNetworkErrorMessage_ko = "통신상태가 불안정합니다.\n다시 실행해 주세요." ;
	
	public static string AlertNetworkErrorMessageString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertNetworkErrorMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertNetworkErrorMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertNetworkErrorMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertNetworkErrorMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertNetworkErrorMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertNetworkErrorMessage_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertDataErrorMessage_en = "Data Error!" ;
	private readonly static string alertDataErrorMessage_ko = "데이터가 올바르지 않습니다.\n다시 실행해 주세요." ;
	
	public static string AlertDataErrorMessageString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertDataErrorMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertDataErrorMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertDataErrorMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertDataErrorMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertDataErrorMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertDataErrorMessage_en ;
		}
		
		return returnString ;
		
	}
	

	/////////////////////
	
	private readonly static string alertPurchaseOkMessage_en = "Purchase Ok!" ;
	private readonly static string alertPurchaseOkMessage_ko = "구매를 완료하였습니다." ;
	
	public static string AlertPurchaseOkMessageString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertPurchaseOkMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertPurchaseOkMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertPurchaseOkMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertPurchaseOkMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertPurchaseOkMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertPurchaseOkMessage_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertQuitMessage_en = "Is Ok Quit?" ;
	private readonly static string alertQuitMessage_ko = "마린스트라이크를 나가시겠습니까?" ;
	
	public static string AlertQuitMessageString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertQuitMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertQuitMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertQuitMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertQuitMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertQuitMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertQuitMessage_en ;
		}
		
		return returnString ;
		
	}
	
	
	private readonly static string alertPaymentJewelGoMessage_en = "No more [00ffff]Crystal[ffffff].." ;
	private readonly static string alertPaymentJewelGoMessage_ko = "[00ffff]크리스탈[ffffff]이 부족합니다.\n[00ffff]크리스탈[ffffff] 구매창으로 이동하시겠습니까?" ;
	
	public static string AlertPaymentJewelGoMessageString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertPaymentJewelGoMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertPaymentJewelGoMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertPaymentJewelGoMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertPaymentJewelGoMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertPaymentJewelGoMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertPaymentJewelGoMessage_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertPaymentGoldGoMessage_en = "No more [ffc800]Gold[ffffff].." ;
	private readonly static string alertPaymentGoldGoMessage_ko = "[ffc800]골드[ffffff]가 부족합니다.\n[ffc800]골드[ffffff] 구매창으로 이동하시겠습니까?" ;
	
	public static string AlertPaymentGoldGoMessageString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertPaymentGoldGoMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertPaymentGoldGoMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertPaymentGoldGoMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertPaymentGoldGoMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertPaymentGoldGoMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertPaymentGoldGoMessage_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertPaymentTorpedoGoMessage_en = "No more [ffc800]Torpedo[ffffff].." ;
	private readonly static string alertPaymentTorpedoGoMessage_ko = "[ffc800]어뢰[ffffff]가 모두 소진되었습니다.\n[ffc800]어뢰[ffffff]를 구매하시겠습니까?" ;
	
	public static string AlertPaymentTorpedoGoMessageString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertPaymentTorpedoGoMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertPaymentTorpedoGoMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertPaymentTorpedoGoMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertPaymentTorpedoGoMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertPaymentTorpedoGoMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertPaymentTorpedoGoMessage_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertTorpedoRechargeInfoMessage_en = "Recharge Torpedo {0}Minute" ;
	private readonly static string alertTorpedoRechargeInfoMessage_ko = "[ffffff]마린스트라이크의 어뢰는 매 [ffc800]{0}[ffffff]마다 충전됩니다." ;
	
	public static string AlertTorpedoRechargeInfoMessageString(string languageCode) {
	
		string returnString = "" ;
		
		
		int quotient = Mathf.FloorToInt(Managers.GameBalanceData.NextRechargeTorpedoBaseTime/60f) ;
		int remainder = Managers.GameBalanceData.NextRechargeTorpedoBaseTime % 60 ;
		
		string nextRechargeTimeInfo = "" ;
		if(remainder > 0){
			nextRechargeTimeInfo = string.Format("{0:0}분{1:00}초", quotient, remainder);
		}else{
			nextRechargeTimeInfo = quotient.ToString()+"분" ;
		}
		
		
		if(languageCode.Equals("En")){
			returnString = string.Format(alertTorpedoRechargeInfoMessage_en, nextRechargeTimeInfo) ;
		}else if(languageCode.Equals("Ko")){
			returnString = string.Format(alertTorpedoRechargeInfoMessage_ko, nextRechargeTimeInfo) ;
		}else if(languageCode.Equals("Hant")){
			returnString = string.Format(alertTorpedoRechargeInfoMessage_en, nextRechargeTimeInfo) ;
		}else if(languageCode.Equals("Hans")){
			returnString = string.Format(alertTorpedoRechargeInfoMessage_en, nextRechargeTimeInfo) ;
		}else if(languageCode.Equals("Ja")){
			returnString = string.Format(alertTorpedoRechargeInfoMessage_en, nextRechargeTimeInfo) ;
		}else if(languageCode.Equals("Fr")){
			returnString = string.Format(alertTorpedoRechargeInfoMessage_en, nextRechargeTimeInfo) ;
		}
		
		return returnString ;
		
	}
	
	
	//
	private readonly static string alertPurchaseError1Message_en = "Purchase Error!" ;
	private readonly static string alertPurchaseError1Message_ko = "결제가 취소 되었습니다." ;
	
	public static string AlertPurchaseError1MessageString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertPurchaseError1Message_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertPurchaseError1Message_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertPurchaseError1Message_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertPurchaseError1Message_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertPurchaseError1Message_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertPurchaseError1Message_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertPurchaseError2Message_en = "Purchase Error!" ;
	private readonly static string alertPurchaseError2Message_ko = "통신이 원활하지 않습니다.\n다시 결제해주세요." ;
	
	public static string AlertPurchaseError2MessageString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertPurchaseError2Message_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertPurchaseError2Message_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertPurchaseError2Message_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertPurchaseError2Message_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertPurchaseError2Message_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertPurchaseError2Message_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertPurchaseError3Message_en = "Purchase Error!" ;
	private readonly static string alertPurchaseError3Message_ko = "데이터가 올바르지 않습니다.\n다시 실행해 주세요." ;
	
	public static string AlertPurchaseError3MessageString(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertPurchaseError3Message_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertPurchaseError3Message_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertPurchaseError3Message_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertPurchaseError3Message_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertPurchaseError3Message_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertPurchaseError3Message_en ;
		}
		
		return returnString ;
		
	}

	private readonly static string alertPurchaseError4Message_en = "Purchase Error!" ;
	private readonly static string alertPurchaseError4Message_ko = "결제 모듈 호출을 실패하였습니다.\n게임 종료 후 다시 결제해 주세요." ;
	
	public static string AlertPurchaseError4MessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertPurchaseError4Message_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertPurchaseError4Message_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertPurchaseError4Message_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertPurchaseError4Message_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertPurchaseError4Message_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertPurchaseError4Message_en ;
		}
		
		return returnString ;
		
	}

	/////////////////////
	
	
	//-----
	private readonly static string subweaponGrade1_en = "Normal" ;
	private readonly static string subweaponGrade1_ko = "노멀" ;
	
	public static string SubweaponGrade1String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponGrade1_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponGrade1_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponGrade1_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponGrade1_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponGrade1_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponGrade1_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponGrade2_en = "Elite" ;
	private readonly static string subweaponGrade2_ko = "엘리트" ;
	
	public static string SubweaponGrade2String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponGrade2_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponGrade2_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponGrade2_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponGrade2_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponGrade2_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponGrade2_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponGrade3_en = "Rare" ;
	private readonly static string subweaponGrade3_ko = "레어" ;
	
	public static string SubweaponGrade3String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponGrade3_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponGrade3_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponGrade3_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponGrade3_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponGrade3_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponGrade3_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponGrade4_en = "Unique" ;
	private readonly static string subweaponGrade4_ko = "유니크" ;
	
	public static string SubweaponGrade4String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponGrade4_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponGrade4_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponGrade4_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponGrade4_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponGrade4_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponGrade4_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponGrade5_en = "Legends" ;
	private readonly static string subweaponGrade5_ko = "레전드" ;
	
	public static string SubweaponGrade5String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponGrade5_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponGrade5_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponGrade5_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponGrade5_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponGrade5_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponGrade5_en ;
		}
		
		return returnString ;
		
	}
	
	//////
	
	
	private readonly static string subweaponTypeName1_en = "Type1" ;
	private readonly static string subweaponTypeName1_ko = "해마아" ;
	
	public static string SubweaponTypeName1String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponTypeName1_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponTypeName1_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponTypeName1_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponTypeName1_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponTypeName1_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponTypeName1_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponTypeName2_en = "Type2" ;
	private readonly static string subweaponTypeName2_ko = "오르챙" ;
	
	public static string SubweaponTypeName2String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponTypeName2_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponTypeName2_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponTypeName2_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponTypeName2_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponTypeName2_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponTypeName2_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponTypeName3_en = "Type3" ;
	private readonly static string subweaponTypeName3_ko = "뽀거" ;
	
	public static string SubweaponTypeName3String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponTypeName3_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponTypeName3_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponTypeName3_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponTypeName3_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponTypeName3_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponTypeName3_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponTypeName4_en = "Type4" ;
	private readonly static string subweaponTypeName4_ko = "뿌웅" ;
	
	public static string SubweaponTypeName4String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponTypeName4_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponTypeName4_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponTypeName4_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponTypeName4_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponTypeName4_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponTypeName4_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponTypeName5_en = "Type5" ;
	private readonly static string subweaponTypeName5_ko = "돌코" ;
	
	public static string SubweaponTypeName5String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponTypeName5_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponTypeName5_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponTypeName5_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponTypeName5_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponTypeName5_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponTypeName5_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponTypeName6_en = "Type6" ;
	private readonly static string subweaponTypeName6_ko = "퓨딩" ;
	
	public static string SubweaponTypeName6String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponTypeName6_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponTypeName6_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponTypeName6_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponTypeName6_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponTypeName6_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponTypeName6_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponTypeName7_en = "Type7" ;
	private readonly static string subweaponTypeName7_ko = "캐보" ;
	
	public static string SubweaponTypeName7String(string languageCode) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = subweaponTypeName7_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = subweaponTypeName7_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = subweaponTypeName7_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = subweaponTypeName7_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = subweaponTypeName7_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = subweaponTypeName7_en ;
		}
		
		return returnString ;
		
	}
	
	
	//------------------------
	private readonly static string subweaponBulletDelayTimeAbilityName_en = "BulletDelayTime {0}" ;
	private readonly static string subweaponBulletDelayTimeAbilityName_ko = "공격속도 {0}증가" ;
	
	public static string SubweaponBulletDelayTimeAbilityNameString(string languageCode, string abilityValue) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = string.Format(subweaponBulletDelayTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ko")){
			returnString = string.Format(subweaponBulletDelayTimeAbilityName_ko, abilityValue);
		}else if(languageCode.Equals("Hant")){
			returnString = string.Format(subweaponBulletDelayTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Hans")){
			returnString = string.Format(subweaponBulletDelayTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ja")){
			returnString = string.Format(subweaponBulletDelayTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Fr")){
			returnString = string.Format(subweaponBulletDelayTimeAbilityName_en, abilityValue);
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponBulletDamageAbilityName_en = "BulletDamage {0}" ;
	private readonly static string subweaponBulletDamageAbilityName_ko = "파워 {0}증가" ;
	
	public static string SubweaponBulletDamageAbilityNameString(string languageCode, string abilityValue) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = string.Format(subweaponBulletDamageAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ko")){
			returnString =string.Format(subweaponBulletDamageAbilityName_ko, abilityValue);
		}else if(languageCode.Equals("Hant")){
			returnString = string.Format(subweaponBulletDamageAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Hans")){
			returnString = string.Format(subweaponBulletDamageAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ja")){
			returnString = string.Format(subweaponBulletDamageAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Fr")){
			returnString = string.Format(subweaponBulletDamageAbilityName_en, abilityValue);
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponMagnetTimeAbilityName_en = "MagnetTime {0}" ;
	private readonly static string subweaponMagnetTimeAbilityName_ko = "자석 지속시간 {0}초 증가" ;
	
	public static string SubweaponMagnetTimeAbilityNameString(string languageCode, string abilityValue) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = string.Format(subweaponMagnetTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ko")){
			returnString = string.Format(subweaponMagnetTimeAbilityName_ko, abilityValue);
		}else if(languageCode.Equals("Hant")){
			returnString = string.Format(subweaponMagnetTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Hans")){
			returnString = string.Format(subweaponMagnetTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ja")){
			returnString = string.Format(subweaponMagnetTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Fr")){
			returnString = string.Format(subweaponMagnetTimeAbilityName_en, abilityValue);
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponDoubleScoreTimeAbilityName_en = "DoubleScoreTime {0}" ;
	private readonly static string subweaponDoubleScoreTimeAbilityName_ko = "더블스코어 지속시간 {0}초 증가" ;
	
	public static string SubweaponDoubleScoreTimeAbilityNameString(string languageCode, string abilityValue) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = string.Format(subweaponDoubleScoreTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ko")){
			returnString = string.Format(subweaponDoubleScoreTimeAbilityName_ko, abilityValue);
		}else if(languageCode.Equals("Hant")){
			returnString = string.Format(subweaponDoubleScoreTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Hans")){
			returnString = string.Format(subweaponDoubleScoreTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ja")){
			returnString = string.Format(subweaponDoubleScoreTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Fr")){
			returnString = string.Format(subweaponDoubleScoreTimeAbilityName_en, abilityValue);
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponBoosterTimeAbilityName_en = "BoosterTime {0}" ;
	private readonly static string subweaponBoosterTimeAbilityName_ko = "부스터 지속시간 {0}초 증가" ;
	
	public static string SubweaponBoosterTimeAbilityNameString(string languageCode, string abilityValue) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = string.Format(subweaponBoosterTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ko")){
			returnString = string.Format(subweaponBoosterTimeAbilityName_ko, abilityValue);
		}else if(languageCode.Equals("Hant")){
			returnString = string.Format(subweaponBoosterTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Hans")){
			returnString = string.Format(subweaponBoosterTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ja")){
			returnString = string.Format(subweaponBoosterTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Fr")){
			returnString = string.Format(subweaponBoosterTimeAbilityName_en, abilityValue);
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponPowerShotTimeAbilityName_en = "PowerShotTime {0}" ;
	private readonly static string subweaponPowerShotTimeAbilityName_ko = "파워업 지속시간 {0}초 증가" ;
	
	public static string SubweaponPowerShotTimeAbilityNameString(string languageCode, string abilityValue) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = string.Format(subweaponPowerShotTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ko")){
			returnString = string.Format(subweaponPowerShotTimeAbilityName_ko, abilityValue);
		}else if(languageCode.Equals("Hant")){
			returnString = string.Format(subweaponPowerShotTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Hans")){
			returnString = string.Format(subweaponPowerShotTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ja")){
			returnString = string.Format(subweaponPowerShotTimeAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Fr")){
			returnString = string.Format(subweaponPowerShotTimeAbilityName_en, abilityValue);
		}
		
		return returnString ;
		
	}
	
	private readonly static string subweaponBigGoldProbabilityAbilityName_en = "BigGoldProbability {0}%" ;
	private readonly static string subweaponBigGoldProbabilityAbilityName_ko = "왕골드 획득확률 {0}% 증가" ;
	
	public static string SubweaponBigGoldProbabilityAbilityNameString(string languageCode, string abilityValue) {
	
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = string.Format(subweaponBigGoldProbabilityAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ko")){
			returnString = string.Format(subweaponBigGoldProbabilityAbilityName_ko, abilityValue);
		}else if(languageCode.Equals("Hant")){
			returnString = string.Format(subweaponBigGoldProbabilityAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Hans")){
			returnString = string.Format(subweaponBigGoldProbabilityAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Ja")){
			returnString = string.Format(subweaponBigGoldProbabilityAbilityName_en, abilityValue);
		}else if(languageCode.Equals("Fr")){
			returnString = string.Format(subweaponBigGoldProbabilityAbilityName_en, abilityValue);
		}
		
		return returnString ;
		
	}















	//--------------------

	private readonly static string paymentPopupChocolateAlertViewMessage_en = "Chocolate {0}Count!" ;
	private readonly static string paymentPopupChocolateAlertViewMessage_ko = "아이템 구매 보상으로\n초콜렛을 {0}개 받았습니다! " ;
	
	public static string PaymentPopupChocolateAlertViewMessageString(string languageCode, int chocolateCount) {
		
		string returnString = "" ;
		
		string chocolateCountString = "" ;
		if(chocolateCount == 0){
			chocolateCountString = chocolateCount.ToString() ;
		}else{
			chocolateCountString = chocolateCount.ToString("#,#") ;	
		}
		
		if(languageCode.Equals("En")){
			returnString = string.Format(paymentPopupChocolateAlertViewMessage_en,chocolateCountString) ;
		}else if(languageCode.Equals("Ko")){
			returnString = string.Format(paymentPopupChocolateAlertViewMessage_ko,chocolateCountString) ;
		}else if(languageCode.Equals("Hant")){
			returnString = string.Format(paymentPopupChocolateAlertViewMessage_en,chocolateCountString) ;
		}else if(languageCode.Equals("Hans")){
			returnString = string.Format(paymentPopupChocolateAlertViewMessage_en,chocolateCountString) ;
		}else if(languageCode.Equals("Ja")){
			returnString = string.Format(paymentPopupChocolateAlertViewMessage_en,chocolateCountString) ;
		}else if(languageCode.Equals("Fr")){
			returnString = string.Format(paymentPopupChocolateAlertViewMessage_en,chocolateCountString) ;
		}
		
		return returnString ;
		
	}
	/////////////////////



	private readonly static string alertLogoutErrorMessage_en = "Logout Error!" ;
	private readonly static string alertLogoutErrorMessage_ko = "로그아웃이 실패하였습니다.\n다시 시도해 주세요." ;
	
	public static string AlertLogoutErrorMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertLogoutErrorMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertLogoutErrorMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertLogoutErrorMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertLogoutErrorMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertLogoutErrorMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertLogoutErrorMessage_en ;
		}
		
		return returnString ;
		
	}
	
	
	
	private readonly static string alertChangeClanErrorMessage_en = "Change Clan Error!" ;
	private readonly static string alertChangeClanErrorMessage_ko = "클랜 설정이 실패하였습니다.\n다시 시도해 주세요." ;
	
	public static string AlertChangeClanErrorMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertChangeClanErrorMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertChangeClanErrorMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertChangeClanErrorMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertChangeClanErrorMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertChangeClanErrorMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertChangeClanErrorMessage_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertChangeClanOkMessage_en = "Change Clan Ok!" ;
	private readonly static string alertChangeClanOkMessage_ko = "클랜 설정이 변경되었습니다.\n변경된 클랜으로 다시 시작됩니다." ;
	
	public static string AlertChangeClanOkMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertChangeClanOkMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertChangeClanOkMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertChangeClanOkMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertChangeClanOkMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertChangeClanOkMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertChangeClanOkMessage_en ;
		}
		
		return returnString ;
		
	}
	
	
	private readonly static string alertAccessTokenFailMessage_en = "ACCESSTOKEN Fail" ;
	private readonly static string alertAccessTokenFailMessage_ko = "회원 인증이 만료되었습니다.\n다시 로그인해주십시오." ;
	
	public static string AlertAccessTokenFailMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertAccessTokenFailMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertAccessTokenFailMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertAccessTokenFailMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertAccessTokenFailMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertAccessTokenFailMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertAccessTokenFailMessage_en ;
		}
		
		return returnString ;
		
	}
	
	
	private readonly static string alertNotClanMasterMessage_en = "Only use to Clan Master" ;
	private readonly static string alertNotClanMasterMessage_ko = "클랜장 기능으로 사용하실 수 없습니다." ;
	
	public static string AlertNotClanMasterMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertNotClanMasterMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertNotClanMasterMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertNotClanMasterMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertNotClanMasterMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertNotClanMasterMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertNotClanMasterMessage_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertSendGiftOkMessage_en = "Ok Send Gift" ;
	private readonly static string alertSendGiftOkMessage_ko = "선물을 보냈습니다." ;
	
	public static string AlertSendGiftOkMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertSendGiftOkMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertSendGiftOkMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertSendGiftOkMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertSendGiftOkMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertSendGiftOkMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertSendGiftOkMessage_en ;
		}
		
		return returnString ;
		
	}
	
	
	private readonly static string alertSendGiftErrorMessage_en = "Error Send Gift" ;
	private readonly static string alertSendGiftErrorMessage_ko = "선물을 보내실 수 없습니다." ;
	
	public static string AlertSendGiftErrorMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertSendGiftErrorMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertSendGiftErrorMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertSendGiftErrorMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertSendGiftErrorMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertSendGiftErrorMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertSendGiftErrorMessage_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertSendAllGiftOkMessage_en = "Ok All Send Gift" ;
	private readonly static string alertSendAllGiftOkMessage_ko = "모든 클랜원에게 어뢰를 선물하였습니다." ;
	
	public static string AlertSendAllGiftOkMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertSendAllGiftOkMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertSendAllGiftOkMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertSendAllGiftOkMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertSendAllGiftOkMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertSendAllGiftOkMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertSendAllGiftOkMessage_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertSendAllGiftErrorMessage_en = "Error All Send Gift" ;
	private readonly static string alertSendAllGiftErrorMessage_ko = "선물을 보내실 수 없습니다." ;
	
	public static string AlertSendAllGiftErrorMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertSendAllGiftErrorMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertSendAllGiftErrorMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertSendAllGiftErrorMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertSendAllGiftErrorMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertSendAllGiftErrorMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertSendAllGiftErrorMessage_en ;
		}
		
		return returnString ;
		
	}
	
	
	private readonly static string alertSendAllGiftLimitErrorMessage_en = "Error All Send Gift" ;
	private readonly static string alertSendAllGiftLimitErrorMessage_ko = "전체에게 선물하기는 1시간에 1번, 하루3번 가능합니다." ;
	
	public static string AlertSendAllGiftLimitErrorMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertSendAllGiftLimitErrorMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertSendAllGiftLimitErrorMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertSendAllGiftLimitErrorMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertSendAllGiftLimitErrorMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertSendAllGiftLimitErrorMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertSendAllGiftLimitErrorMessage_en ;
		}
		
		return returnString ;
		
	}
	
	
	
	private readonly static string alertSendAllInviteOkMessage_en = "Ok All Send Invite" ;
	private readonly static string alertSendAllInviteOkMessage_ko = "클랜원들에게 초대장을 보냈습니다." ;
	
	public static string AlertSendAllInviteOkMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertSendAllInviteOkMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertSendAllInviteOkMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertSendAllInviteOkMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertSendAllInviteOkMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertSendAllInviteOkMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertSendAllInviteOkMessage_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertSendAllInviteErrorMessage_en = "Error All Send Invite" ;
	private readonly static string alertSendAllInviteErrorMessage_ko = "클랜원 초대하기는 하루에 한번만 가능합니다." ;
	
	public static string AlertSendAllInviteErrorMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertSendAllInviteErrorMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertSendAllInviteErrorMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertSendAllInviteErrorMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertSendAllInviteErrorMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertSendAllInviteErrorMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertSendAllInviteErrorMessage_en ;
		}
		
		return returnString ;
		
	}
	
	private readonly static string alertSendAllNetworkErrorMessage_en = "Error : Network!!" ;
	private readonly static string alertSendAllNetworkErrorMessage_ko = "네트워크 오류입니다.\n잠시 후 다시 시도해 주세요." ;
	
	public static string AlertSendAllNetworkErrorMessageString(string languageCode) {
		
		string returnString = "" ;
		
		if(languageCode.Equals("En")){
			returnString = alertSendAllNetworkErrorMessage_en ;
		}else if(languageCode.Equals("Ko")){
			returnString = alertSendAllNetworkErrorMessage_ko ;
		}else if(languageCode.Equals("Hant")){
			returnString = alertSendAllNetworkErrorMessage_en ;
		}else if(languageCode.Equals("Hans")){
			returnString = alertSendAllNetworkErrorMessage_en ;
		}else if(languageCode.Equals("Ja")){
			returnString = alertSendAllNetworkErrorMessage_en ;
		}else if(languageCode.Equals("Fr")){
			returnString = alertSendAllNetworkErrorMessage_en ;
		}
		
		return returnString ;
		
	}
	#region PlayerPref Vals
	public readonly static string PLAYER_PREF_SOUND 								= "SOUND_FLAG";
	#endregion

	#region ST200 Object Z layer value
	public readonly static float ST200_GameObjectLayer_FontFX	 					= -35f;
	public readonly static float ST200_GameObjectLayer_Foreground 					= -30f;
	public readonly static float ST200_GameObjectLayer_BackgroundObstacles			= 0f;
	public readonly static float ST200_GameObjectLayer_EnemyEnergy 					= -8f;
	public readonly static float ST200_GameObjectLayer_FX		 					= -9f;	
	public readonly static float ST200_GameObjectLayer_FX_Particle 					= -10f;	
	public readonly static float ST200_GameObjectLayer_Background					= 10f;
	public readonly static float ST200_GameObjectLayer_BackgroundFX					= 9f;
	public readonly static float ST200_GameObjectLayer_PlayerShip					= 7f;
	public readonly static float ST200_GameObjectLayer_EnemyShip					= 8f;
	#endregion

	#region ST200 Enemy Type
	public readonly static int ENEMY_NORMAL 				= 1;
	public readonly static int ENEMY_SHOOT					= 2;
	public readonly static int ENEMY_EXPLODE 				= 3;
	public readonly static int ENEMY_BUFF_SHOOT				= 4;
	public readonly static int ENEMY_RANGE_SPEED			= 5;
	public readonly static int ENEMY_BUFF_HEAL				= 6;

	public readonly static int ENEMY_BOSS_1					= 7;
	#endregion

	#region ST200 Stage Clear Type
	public readonly static int ST200_STAGE_CLEAR_TYPE_ANNIHILATE 				= 1;
	public readonly static int ST200_STAGE_CLEAR_TYPE_SPECIALS	 				= 2;
	public readonly static int ST200_STAGE_CLEAR_TYPE_SURVIVAL	 				= 3;
	public readonly static int ST200_STAGE_CLEAR_TYPE_KILLTHEBOSS 				= 4;
	public readonly static int ST200_STAGE_CLEAR_TYPE_CLEARWAVE	 				= 5;
	#endregion

	#region Color Table
	public readonly static string COLOR_RED 									= "[ff0000]";
	public readonly static string COLOR_BLACK 									= "[000000]";
	public readonly static string COLOR_BLUE 									= "[0000ff]";
	public readonly static string COLOR_WHITE 									= "[ffffff]";
	public readonly static string COLOR_GOLD 									= "[f0c96e]";
	public readonly static string COLOR_STAGESELECT_ACTIVE						= "[ffd0a3]";
	public readonly static string COLOR_STAGESELECT_INACTIVE					= "[aeb6be]";

	public readonly static string COLOR_MAIN_TOP_LABEL							= "[fff6cc]";
	public readonly static string COLOR_MAIN_TITLE								= "[182b57]";
	public readonly static string COLOR_MAIN_NAME								= "[ffffff]";
	public readonly static string COLOR_MAIN_SHIP_DESCRIPTION					= "[455069]";
	public readonly static string COLOR_MAIN_SHIP_SPECIAL_DESCRIPTION			= "[ae0000]";
	public readonly static string COLOR_MAIN_SHIP_LEVEL							= "[ffffff]";
	public readonly static string COLOR_MAIN_SHIP_INFO							= "[5a4646]";
	public readonly static string COLOR_MAIN_SHIP_COST							= "[fff6cc]";
	public readonly static string COLOR_MAIN_BOT_LABEL							= "[03004c]";
	public readonly static string COLOR_MAIN_SHIP_READY							= "[fff2dc]";
	public readonly static string COLOR_MAIN_SHIP_READY_OUTLINE 				= "[7d082f]";
	public readonly static string COLOR_MAIN_SUBTITLE							= "[c0fdff]";
	public readonly static string COLOR_MAIN_TOPLABEL2							= "[EFE8CA]";

	public readonly static string COLOR_POPUP_TITLE				 				= "[ede7d9]";
	public readonly static string COLOR_POPUP_EXIT				 				= "[000000]";
	public readonly static string COLOR_POPUP_BUTTON			 				= "[fff2c1]";
	public readonly static string COLOR_POPUP_NICKNAME_TITLE	 				= "[431111]";
	public readonly static string COLOR_POPUP_NICKNAME_CONTENT		 			= "[000000]";
	public readonly static string COLOR_POPUP_NICKNAME_BUTTON		 			= "[fff2c1]";
	public readonly static string COLOR_STORE_TITLE					 			= "[182b57]";
	public readonly static string COLOR_STORE_TAP					 			= "[fffbd4]";
	public readonly static string COLOR_STORE_ITEMCOUNT				 			= "[a1442d]";
	public readonly static string COLOR_STORE_ITEMCOST				 			= "[532a1f]";
	public readonly static string COLOR_MAIL_TITLE					 			= "[431111]";
	public readonly static string COLOR_MAIL_INFO					 			= "[000000]";
	public readonly static string COLOR_MAIL_ITEMINFO				 			= "[532a1f]";
	public readonly static string COLOR_MAIL_RECEIVE				 			= "[ac412f]";
	public readonly static string COLOR_MAIL_RECEIVE_ALL			 			= "[fff2c1]";
	public readonly static string COLOR_CONTINUE_TITLE				 			= "[ffffff]";
	public readonly static string COLOR_CONTINUE_DESCRIPTION		 			= "[ffffff]";
	public readonly static string COLOR_CONTINUE_REVIVE				 			= "[ffa200]";
	public readonly static string COLOR_CONTINUE_REVIVE_OUTLINE		 			= "[FFA200]";
	public readonly static string COLOR_CONTINUE_GOLD_LABEL			 			= "[FFA200]";
	public readonly static string COLOR_CONTINUE_GOLD_AMOUNT		 			= "[FFF2C1]";
	public readonly static string COLOR_CONTINUE_BUTTON				 			= "[FFF2C1]";

	public readonly static string COLOR_RESULT_TITLE				 			= "[182B57]";
	public readonly static string COLOR_RESULT_REWARD				 			= "[455069]";
	public readonly static string COLOR_RESULT_REWARD_AMOUNT		 			= "[B33C37]";
	public readonly static string COLOR_RESULT_SCORE_TITLE			 			= "[FFFFFF]";
	public readonly static string COLOR_RESULT_SCORE_AMOUNT			 			= "[FFFFFF]";
	public readonly static string COLOR_RESULT_BUTTON				 			= "[FFF2C1]";

	public readonly static string COLOR_PVPRESULT_DESCRIPTION		 			= "[FFF2C1]";

	public readonly static string COLOR_SETTING_TITLE				 			= "[431111]";
	public readonly static string COLOR_SETTING_OPTION				 			= "[182B57]";
	public readonly static string COLOR_SETTING_QNA					 			= "[51699E]";

	public readonly static string COLOR_RANKING_TITLE				 			= "[431111]";
	public readonly static string COLOR_RANKING_RANKNUMB			 			= "[3C0101]";
	public readonly static string COLOR_RANKING_INFOLABEL				 		= "[3C0101]";

	public readonly static string COLOR_ATTEND_TITLE					 		= "[431111]";
	public readonly static string COLOR_ATTEND_DAYNUMBLABEL				 		= "[FF0000]";
	public readonly static string COLOR_ATTEND_DAYLABEL					 		= "[3C0101]";
	public readonly static string COLOR_ATTEND_ITEMNAMELABEL			 		= "[3C0101]";

	public readonly static string COLOR_READY_TITLE						 		= "[431111]";
	public readonly static string COLOR_READY_ITEMNAME					 		= "[FFFFFF]";
	public readonly static string COLOR_READY_ITEMDESCRIPTION			 		= "[455069]";
	public readonly static string COLOR_READY_ITEMAMOUNTOUTLINE			 		= "[671c13]";

	public readonly static string COLOR_SUBSHIP_TITLE					 		= "[ffffff]";
	public readonly static string COLOR_SUBSHIP_TAP					 			= "[fffada]";
	public readonly static string COLOR_SUBSHIP_SUBTITLE					 	= "[ffffff]";
	public readonly static string COLOR_SUBSHIP_GACHABUTTON				 		= "[431111]";
	public readonly static string COLOR_SUBSHIP_SHIPNAME				 		= "[431111]";
	public readonly static string COLOR_SUBSHIP_SELECT					 		= "[fff2c1]";
	public readonly static string COLOR_SUBSHIP_SELECTED				 		= "[431111]";

	public readonly static string COLOR_SUBSHIP_UPGRADE_TITLE			 		= "[431111]";
	public readonly static string COLOR_SUBSHIP_UPGRADE_NAME			 		= "[ffffff]";
	public readonly static string COLOR_SUBSHIP_UPGRADE_LEVEL			 		= "[ffffff]";
	public readonly static string COLOR_SUBSHIP_UPGRADE_DESCRIPTION		 		= "[455069]";
	public readonly static string COLOR_SUBSHIP_UPGRADE_SPECIALDESCRIPTION 		= "[ae0000]";

	public readonly static string COLOR_PVP_RESULT_DESCRIPTION_WIN		 		= "[ffd2c7]";
	public readonly static string COLOR_PVP_RESULT_DESCRIPTION_LOSE		 		= "[c7f6ff]";
	public readonly static string COLOR_PVP_ATTACK_ALERT_DESCRIPTION	 		= "[8A3324]";
	#endregion

	#region ST200 Pop up box message type
	public readonly static int ST200_POPUP_MESSAGE_EXIT 						= 0;
	public readonly static int ST200_POPUP_PURCHASE_OK							= 1;
	public readonly static int ST200_POPUP_RECHARGE_COIN						= 2;
	public readonly static int ST200_POPUP_RECHARGE_JEWEL 						= 3;
	public readonly static int ST200_POPUP_RECHARGE_HEART 						= 4;
	public readonly static int ST200_POPUP_RECHARGE_HEART_TOP_UI				= 5;
	public readonly static int ST200_POPUP_RECHARGE_HEART_NOTICE				= 6;
	public readonly static int ST200_POPUP_INSTALL_KAKAO						= 7;

	public readonly static int ST200_POPUP_MESSAGE_INCORRECTDATA 				= 1001;
	public readonly static int ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD				= 1002;
	public readonly static int ST200_POPUP_MESSAGE_PACKAGE_NOT_CORRECT			= 1003;
	public readonly static int ST200_POPUP_ERROR_USERSEQUENCE_ERROR 			= 1004;

	public readonly static int ST200_POPUP_MESSAGE_INAPP_FAILED_TO_CALL			= 2001;//previous 21
	public readonly static int ST200_POPUP_MESSAGE_INAPP_CANCELED				= 2002;
	public readonly static int ST200_POPUP_MESSAGE_INAPP_NO_GOOD_NETWORK		= 2003;
	public readonly static int ST200_POPUP_MESSAGE_INAPP_SUCCESS				= 2004;

	public readonly static int ST200_POPUP_MESSAGE_FAILED_TO_GET_PRESENT		= 3001;
	public readonly static int ST200_POPUP_MESSAGE_FAILED_TO_GET_HEART_FULL		= 3002;

	public readonly static int ST200_POPUP_MESSAGE_SUBSHIP_UNALBLE_TO_EQUIP 	= 4001;
	public readonly static int ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT2 			= 4002;
	public readonly static int ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT3 			= 4003;
	public readonly static int ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT4 			= 4004;
	public readonly static int ST200_POPUP_MESSAGE_SUBSHIP_UPGRADE_COMPLETE		= 4005;
	public readonly static int ST200_POPUP_MESSAGE_STAGESELECT_LOCKED_STAGE		= 4006;
	public readonly static int ST200_POPUP_MESSAGE_SUBSHIP_UNABLETO_GACHA		= 4007;
	public readonly static int ST200_POPUP_MESSAGE_SUBSHIP_UNABLETO_EQUIP_CHARACTER	= 4008;

	public readonly static int ST200_POPUP_MESSAGE_STAGE_LOCKED					= 6001;
	public readonly static int ST200_POPUP_MESSAGE_SHIP4_LOCKED					= 6002;
	public readonly static int ST200_POPUP_MESSAGE_SHIP3_LOCKED					= 6003;
	public readonly static int ST200_POPUP_MESSAGE_SHIP8_LOCKED					= 6004;

	public readonly static int ST200_POPUP_NICKNAME_INAPPROPRIATE_NAME			= 7001;
	public readonly static int ST200_POPUP_NICKNAME_ALREADY_EXIST				= 7002;
	public readonly static int ST200_POPUP_NICKNAME_SUCCESS						= 7003;

	public readonly static int ST200_POPUP_PVP_RECOMMANDLIST_GETERROR			= 8001;
	public readonly static int ST200_POPUP_PVP_FRIENDLIST_GETERROR				= 8002;
	public readonly static int ST200_POPUP_PVP_WOLDRANK_GETERROR				= 8003;
	public readonly static int ST200_POPUP_PVP_FRIENDRANK_GETERROR				= 8004;
	public readonly static int ST200_POPUP_PVP_FRIENDADD_SUCCESS				= 8005;
	public readonly static int ST200_POPUP_PVP_FRIENDADD_FAIL					= 8006;
	public readonly static int ST200_POPUP_PVP_FRIENDREMOVE_SUCCESS				= 8007;
	public readonly static int ST200_POPUP_PVP_FRIEND_SEARCH_NORESULT			= 8008;
	public readonly static int ST200_POPUP_PVP_FRIEND_SEARCH_LENGTH_ERROR		= 8009;
	#endregion

	#region ST200 ItemID
	public readonly static int ST200_ITEM_HEART									= 1;
	public readonly static int ST200_ITEM_COIN									= 5000;//2
	public readonly static int ST200_ITEM_JEWEL									= 5001;//3
	
	public readonly static int ST200_ITEM_SHOUT									= 4000;//1
	public readonly static int ST200_ITEM_SINGIJEON								= 4001;//2
	public readonly static int ST200_ITEM_POWERUP								= 4002;//2
	public readonly static int ST200_ITEM_HEALTHUP								= 4003;//2
	public readonly static int ST200_ITEM_REVIVE								= 4004;//3

	public readonly static int ST200_ITEM_CHARACTER_STARTCODE					= 1000;
	public readonly static int ST200_ITEM_SHIP_STARTCODE						= 2000;
	public readonly static int ST200_ITEM_SUBSHIP_STARTCODE						= 3000;
	public readonly static int ST200_ITEM_GAME_ITEM_START_CODE					= 4000;
	public readonly static int ST200_ITEM_SUBSHIP_TACTIC_STARTCODE				= 5000;
	#endregion

	#region ST200 Gameplay constants
	public readonly static int ST200_GAMEPLAY_DAMAGE_TYPE_BULLET 				= 1;
	public readonly static int ST200_GAMEPLAY_DAMAGE_TYPE_CRASH 				= 2;
	public readonly static int ST200_GAMEPLAY_DAMAGE_TYPE_NORETURN 				= 3;
	public readonly static int ST200_GAMEPLAY_DAMAGE_TYPE_EXPLODE 				= 4;
	#endregion

	#region ST200 GAME MODE
	public readonly static int ST200_GAMEMODE_STAGE_NORMAL						= 0;
	public readonly static int ST200_GAMEMODE_PVP								= 1;
	#endregion

	#region GCM Code
	public static readonly int FLAG_RECHARGE_PUSH								= 1;

	#endregion
}
