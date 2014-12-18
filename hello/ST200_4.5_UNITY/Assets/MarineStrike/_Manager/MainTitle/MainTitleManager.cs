using UnityEngine;
using System.Collections;
using SimpleJSON ;
using LitJson;
using System.Collections.Generic;


public class MainTitleManager : MonoBehaviour {
	
	// ==================== Layout 관련 변수 선언 - Start ====================
	public UIPanel _updateInfoPopupViewObject ;
	private UpdateInfoPopupView _updateInfoPopupView ;
	//	public UIPanel _noticePopupViewObject ;
	//	private NoticePopupView _noticePopupView ;
	public UIPanel _eventPopupViewObject ;
	private EventPopupView _eventPopupView ;
	public MainTitleNicknameView _nicknameView;
	public AgreementPopupView _agreementPopupView_KR;
	public AgreementPopupView m_AgreementPopupView_ENG;
	public IndicatorPopupView _indicatorPopupView ;
	public UIRootAlertView _uiRootAlertView ;
	public BannerView _bannerView ;
	public MessageAlertPopupView _messageAlertPopupView ;
	public UISprite _title_Touch_Screen ;

	public UISprite m_MainBg;
	// ==================== Layout 관련 변수 선언 - End ====================
	
	// ==================== PushInfo 통신 Data 관련 변수 선언 - Start ====================
	public struct PostData_PushInfo {
		
		private string strDeviceid;
		public string Deviceid{ get { return strDeviceid; } set { strDeviceid = value; } }
		
		private string strADID;
		public string ADID{ get { return strADID; } set { strADID = value; } }
		
		private string strOstype;
		public string Ostype{ get { return strOstype; } set { strOstype = value; } }
		
		private string strService;
		public string Service{ get { return strService; } set { strService = value; } }
		
		private string strMtype;
		public string Mtype{ get { return strMtype; } set { strMtype = value; } }
		
		private string strLanguage;
		public string Language{ get { return strLanguage; } set { strLanguage = value; 
			} }
		
		private string strCountry;
		public string Country{ get { return strCountry; } set { strCountry = value; } }
		
		private string strAppversion;
		public string AppVersion{ get { return strAppversion; } set { strAppversion = value; } }
	}
	private PostData_PushInfo m_PostData_PushInfo;
	// ==================== PushInfo 통신 Data 관련 변수 선언 - End ====================
	
	// ==================== PopUpList 관련 변수 선언 - Start ====================
	private List<PopUpListData> m_list_popUpListData_Notice;
	private PopUpListData m_popUpListData_Notice;
	private List<int> m_list_intIndexHide_Notice;
	private List<int> m_list_intIndexShown_Notice;

	private List<PopUpListData> m_list_popUpListData_Event;
	private PopUpListData m_popUpListData_Event;
	private List<int> m_list_intIndexHide_Event;
	private List<int> m_list_intIndexShown_Event;

	private List<PopUpListData> m_list_popUpListData_Cross;
	private PopUpListData m_popUpListData_Cross;
	private List<int> m_list_intIndexHide_Cross;
	private List<int> m_list_intIndexShown_Cross;

	// ==================== PopUpList 관련 변수 선언 - End ====================
	
	// ==================== GetConData 통신 파싱 관련 변수 선언 - Start ====================
	private string strAppDownloadURL ;
	
	private bool boolBanner_Enable = false ;
	private string strBanner_ImageURL ;
	private string strBanner_Link ;
	private bool boolBanner_Link_Enable = false ;
	private int intBanner_Type ;
	private string strBanner_EventIndex ;
	// ==================== GetConData 통신 파싱 관련 변수 선언 - End ====================
	
	// ==================== 기타 변수 선언 - Start ====================
	private bool boolGo_NextScene = false ;
	private string strUserID;
	

	// ==================== 기타 변수 선언 - End ====================
	
	
	
	// ==================== Unity Override 정의 - Start ====================
	private void Awake(){
		
		//Debug.Log("ST110 MainTitleManager.Awake() Run!!!");

		Awake_01_Initialize_Variable();
		Awake_02_Set_Delegate();
		Awake_03_Initialize_View();
		Awake_91_Initialize_Etc();

#if UNITY_ANDROID
		if(!Constant.CURRENT_MARKET.Equals("2"))
		{
			m_MainBg.spriteName = "main_age";
		}else
		{
			m_MainBg.spriteName = "main";
		}
#endif
	}
	
	private void Start () {
		
		//Debug.Log("ST110 MainTitleManager.Start() Run!!!");
		
		Start_01_Save_Token();
		
		Process_Main_01_SetInitDataStream_NoID();
		
	}
	
	// Update is called once per frame
	private void Update () {	
		
		//if (Application.platform == RuntimePlatform.Android)
		{
			
			if (Input.GetKeyUp(KeyCode.Escape)){
				
				if (_indicatorPopupView.gameObject.activeSelf == false){
					
					if (_messageAlertPopupView.gameObject.activeSelf == true){
						
						_messageAlertPopupView.RemoveMessageAlertPopupView() ;
					} else {
						
						if (_uiRootAlertView.gameObject.activeSelf ==false){
							
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_EXIT) ;
						}
					}
				}
				
			}
		}
	}
	
	private void OnApplicationPause(bool pause){
		
		//Debug.Log("ST110 MainTitleManager.OnApplicationPause().pause = " + pause);
		
		if (pause){ //백그라운드로 들어갈 때.
			
			if ( Managers.Audio != null) {
				
				Managers.Audio.StopBGMSound() ;
			}

			
		} else { // 백그라운드에서 나올 때.
			
			if ( Managers.Audio != null) {
				
				Managers.Audio.StopBGMSound() ;
				Managers.Audio.PlayBGMSound(AudioManager.BGM_SOUND.BGM_Title,true);	
			}
		}
	}
	
	// ==================== Unity Override 정의 - End ====================
	
	private void Awake_01_Initialize_Variable(){
		
		 //Debug.Log("ST110 MainTitleManager.Awake_01_Initialize_Variable() Run!!");
		
		_updateInfoPopupView = _updateInfoPopupViewObject.GetComponent<UpdateInfoPopupView>() as UpdateInfoPopupView ;
		//		_noticePopupView = _noticePopupViewObject.GetComponent<NoticePopupView>() as NoticePopupView ;
		_eventPopupView = _eventPopupViewObject.GetComponent<EventPopupView>() as EventPopupView ;
		
		strUserID =  SystemInfo.deviceUniqueIdentifier;
#if UNITY_EDITOR
		strUserID = "22222229";
#endif

		Data_PostData_Push_Set ();

		Data_IndexHide_PopupNotice_Set ();
		Data_IndexHide_PopupEvent_Set ();
		Data_IndexHide_PopupCross_Set ();

		m_list_intIndexShown_Notice = new List<int> ();
		m_list_intIndexShown_Event = new List<int> ();
		m_list_intIndexShown_Cross = new List<int> ();

	}
	
	private void Awake_02_Set_Delegate(){
		
		 //Debug.Log("ST110 MainTitleManager.Awake_02_Set_Delegate() Run!!");
		
		_updateInfoPopupView.UpdateInfoPopupViewEvent += HandleDelegate_UpdateInfoPopupView ;
		_eventPopupView.Event_Delegate_EventPopupView += HandleDelegate_EventPopupView ;
		_nicknameView.Event_Delegate_NicknameView += HandleDelegate_NicknameView;
		_agreementPopupView_KR.AgreementPopupViewEvent += HandleDelegate_AgreementPopupView ;
		m_AgreementPopupView_ENG.AgreementPopupViewEvent += HandleDelegate_AgreementPopupView;
		_uiRootAlertView.UIRootAlertViewEvent += HandleDelegate_UIRootAlertView ;

		// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== Start.
		_uiRootAlertView.Event_Delegate_UIRootAlertView_Kakao += Delegate_UIRootAlertView_Kakao;
		// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== End.

		_bannerView.BannerViewEvent += HandleDelegate_BannerView ;
		_messageAlertPopupView.MessageAlertPopupViewEvent += HandleDelegate_MessageAlertPopupView ;
		_indicatorPopupView.IndicatorPopupViewEvent += null ;
		
		
	}
	
	private void Awake_03_Initialize_View(){
		
		 //Debug.Log("ST110 MainTitleManager.Awake_03_Initialize_View() Run!!");
		
		_updateInfoPopupView.InitLoadUpdateInfoPopupView() ;
		//		_noticePopupView.InitLoadNoticePopupView() ;
		_eventPopupView.PopupView_Initialize() ;
		_agreementPopupView_KR.InitAgreementPopupView() ;
		m_AgreementPopupView_ENG.InitAgreementPopupView();
		_indicatorPopupView.InitLoadIndicatorPopupView() ;
		_uiRootAlertView.InitLoadUIRootAlertView() ;
		_bannerView.InitLoadBannerView() ;
		_messageAlertPopupView.InitLoadMessageAlertPopupView() ;

		ShowGuestLoginButton(false);
		NGUITools.SetActive(_title_Touch_Screen.gameObject, false) ;

		
	}
	
	private void Awake_91_Initialize_Etc(){
		
		 //Debug.Log("ST110 MainTitleManager.Awake_91_Initialize_Etc() Run!!");
		
		if ( Managers.Audio != null) {
			
			Managers.Audio.StopBGMSound() ;
			Managers.Audio.PlayBGMSound(AudioManager.BGM_SOUND.BGM_Title,true);	
		}
		
		PlayerPrefs.SetInt(Constant.PREFKEY_MainScene_To_RankingScene_INT, Constant.INT_True);
		PlayerPrefs.SetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT, Constant.INT_False);
		
	}
	
	private void Start_01_Save_Token(){
		
		 //Debug.Log("ST110 MainTitleManager.Start_01_Save_Token() Run!!");
		//StartCoroutine(Managers.DataStream.Network_SaveToken()) ;
		#if UNITY_IPHONE && !UNITY_EDITOR
		Debug.Log( "Hello Start SaveToken" );
		StartCoroutine(Managers.DataStream.Network_SaveToken()) ;
		
		#elif UNITY_ANDROID && !UNITY_EDITOR	
		
		if ( GCM.GetRegistrationId () != null && !GCM.GetRegistrationId ().Equals("")){
			
			StartCoroutine(Managers.DataStream.Network_SaveToken()) ;
		}
		
		#endif
	}
	
	private void Process_Main_01_SetInitDataStream_NoID(){

		//Debug.Log("ST110 MainTitleManager.Process_Main_01_SetInitDataStream_NoID() Run!!");

		if (Managers.UserData.UserID == null
		    || Managers.UserData.UserID.Equals("")){

			Managers.DataStream.SetInitDataStream(strUserID,Constant.AppVersionInfo) ;
			//Managers.DataStream.SetInitDataStream("",Constant.AppVersionInfo) ;
			Process_Main_02_Network_GetConData ();
		} else {

			Process_Main_99_SetUi();

			//#if UNITY_EDITOR
			//
			//Process_Main_99_SetUi();
			//
			//#elif UNITY_IPHONE || UNITY_ANDROID
			//
			//Process_Main_99_SetUi();
			//
			////if (Managers.KaKao.isUserLogin()){
			////	
			////	Process_Main_99_SetUi();
			////
			////} else {
			////	
			////	Managers.DataStream.SetInitDataStream("",Constant.AppVersionInfo) ;
			////	Process_Main_02_Network_GetConData ();
			////}
			//
			//#endif
		}
	}
	
	private void Process_Main_02_Network_GetConData(){
		
		//Debug.Log("ST110 MainTitleManager.Process_Main_02_Network_GetConData() Run!!");
		
		// EventDelegate 정의 - GetConData.
		Managers.DataStream.Event_Delegate_DataStreamManager_GetConData += (strResultDataJson_Input, intNetworkResultCode_Input) => {
			
			_indicatorPopupView.RemoveIndicatorPopupView() ;
			
			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
				//Debug.Log("CHEC3");
				JSONNode jsonDataRoot = JSON.Parse(strResultDataJson_Input);
				
				Managers.UserData.AppVersionInfo = jsonDataRoot["CurrentVersion"] ;
				
				strAppDownloadURL = jsonDataRoot["DownloadURL"] ;

				boolBanner_Enable = jsonDataRoot["ImageBannerEnable"].AsBool ;
				strBanner_ImageURL = jsonDataRoot["ImageBannerURL"] ;
				strBanner_Link = jsonDataRoot["ImageBannerLink"] ;
				boolBanner_Link_Enable = jsonDataRoot["ImageBannerLinkEnable"].AsBool ; //터치 활성화 여부.
				intBanner_Type = jsonDataRoot["ImageBannerType"].AsInt ; // 1:nomal, 2:event, event의경우 아래 보상 interface를 호출하여야 함.
				strBanner_EventIndex = jsonDataRoot["ImageBannerEventIndex"] ; //배너 유니크 인덱스, 아래 보상 interface를 통해 서버로 전송해야 함.

				Data_PopupListData_PopupNotice_Set(strResultDataJson_Input);
				Data_PopupListData_PopupEvent_Set(strResultDataJson_Input);
				PlayerPrefs.SetString(Constant.PREFKEY_NetworkResult_GetConData_STR, strResultDataJson_Input);

				//Debug.Log("HI AM I CALLED?");
				Process_Main_03_Network_Popup_Info();
				
			} else if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_Error_Network){
				
				_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ;
				
			} else if(intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
			{
				_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
			}else {
				
				_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
			}
			
			Managers.DataStream.Event_Delegate_DataStreamManager_GetConData += null;
		};

		_indicatorPopupView.LoadIndicatorPopupView() ;
		StartCoroutine(Managers.DataStream.Network_GetConData()) ;
	}
	
	private void Process_Main_03_Network_Popup_Info(){
		
		 //Debug.Log("ST110 MainTitleManager.Process_Main_03_Network_Popup_Info() Run!!");
		//Debug.Log("CHEC???2:");
		// EventDelegate 정의 - Popup_Info.
		Managers.DataStream.Event_Delegate_DataStreamManager_Popup_Info += (intNetworkResultCode_Input, strNetworkResultData_Input) => {
			
			_indicatorPopupView.RemoveIndicatorPopupView() ;

			//Debug.Log("CHEC2: " + intNetworkResultCode_Input + "  RES: " + strNetworkResultData_Input);
			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){

				Data_PopupListData_PopupCross_Set(strNetworkResultData_Input);

				Process_Main_04_Network_ReadBalanceData();
				
			} else if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_Error_Network){
				
				_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ;
				
			} else if(intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
			{
				_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
			} else {
				
				_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
			}
			
			Managers.DataStream.Event_Delegate_DataStreamManager_Popup_Info += null;
		};
		
		// Popup_Info 퉁신하기.
		StartCoroutine(Managers.DataStream.Network_Popup_Info(m_PostData_PushInfo)) ;
		//Process_Main_04_Network_ReadBalanceData();
	}
	
	private void Process_Main_04_Network_ReadBalanceData(){
		
		 //Debug.Log("ST110 MainTitleManager.Process_Main_04_Network_ReadBalanceData() Run!!");
		
		if (Managers.DataStream != null){
			
			_indicatorPopupView.LoadIndicatorPopupView() ;
			
			// EventDelegate 정의 - ReadBalanceData.
			Managers.DataStream.Event_Delegate_DataStreamManager_ReadBalanceData += (intNetworkReadBalanceDataResultCode_Input) => {
				
				_indicatorPopupView.RemoveIndicatorPopupView() ;
				//Debug.Log("read balance data: " + intNetworkReadBalanceDataResultCode_Input);
				if (intNetworkReadBalanceDataResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
					//Debug.Log("CHEC1");
					Process_Main_11_Check_Agreement();
					
				} else if (intNetworkReadBalanceDataResultCode_Input == Constant.NETWORK_RESULTCODE_Error_Network){
					
					_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ;
					
				} else {
					
					_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
				}
				
				Managers.DataStream.Event_Delegate_DataStreamManager_ReadBalanceData += null;
			};
			
			// ReadBalanceData 퉁신하기.
			//Debug.Log("TRY READ BALANCE");
			StartCoroutine(Managers.DataStream.Network_ReadBalanceData()) ;
		}
		
	}
	
	private void Process_Main_11_Check_Agreement(){
		
		 //Debug.Log("ST110 MainTitleManager.Process_Main_11_Check_Agreement() Run!!");
		
		int intAgreement = PlayerPrefs.GetInt(Constant.PREFKEY_Agreement_INT);

#if UNITY_EDITOR
		//intAgreement = Constant.INT_False;
#endif

		if (intAgreement == Constant.INT_False)
		{

			if(Managers.LanguageCode == PFPFileManager.LANGUAGE_KOR)
			{
				_agreementPopupView_KR.LoadAgreementPopupView();
			}else
			{
				m_AgreementPopupView_ENG.LoadAgreementPopupView();
			}
		}
		else 
		{
			
			Process_Main_12_Check_Updata();
		}
		
	}
	
	private void Process_Main_12_Check_Updata(){

		//Debug.Log("ST110 MainTitleManager.Process_Main_12_Check_Updata() Run!!");

		if (Managers.UserData != null){
			//Debug.Log("CHEC");
			// 클라이언트 버전과 서버에 등록된 버전 체크.
			if (Managers.UserData.CheckAppVersionInfo(Managers.UserData.AppVersionInfo)){
				
				//Process_Main_21_Check_KakaoLogin();

				Process_Main_32_Network_ReadUserData();
			} else {
				
				_updateInfoPopupView.LoadUpdateInfoPopupView() ;
			}
		}
		
	}

	private void Process_Main_41_Check_NickName()
	{
		//_nicknameView.ShowView();
		if(Managers.UserData.UserNickName == null || Managers.UserData.UserNickName == "")
		{
			//show nicknameview;
			_nicknameView.ShowView();
		}else
		{
			Process_Main_41_Check_NoticePopup();
		}
	}
	
	private void Process_Main_41_Check_NoticePopup(){
		
		//Debug.Log("ST110 MainTitleManager.Process_Main_41_Check_NoticePopup() Run!!");

		List<PopUpListData> list_popUpListData = new List<PopUpListData>();

		if (m_list_intIndexShown_Notice.Count == 0)
		{			
			list_popUpListData = m_list_popUpListData_Notice;
			
		} else 
		{			
			if (m_list_popUpListData_Notice != null
			    && m_list_popUpListData_Notice.Count != 0)
			{				
				for (int i = 0; i < m_list_popUpListData_Notice.Count; i++)
				{					
					bool boolEqual = false;					
					for (int j = 0; j < m_list_intIndexShown_Notice.Count; j++)
					{					
						if (m_list_popUpListData_Notice[i].PopUpIndex.Equals(m_list_intIndexShown_Notice[j].ToString()))
						{							
							boolEqual = true;
							break;
						}
					}
					
					if (!boolEqual)
					{						
						list_popUpListData.Add(m_list_popUpListData_Notice[i]);
					}
				}
			}
		}

		m_popUpListData_Notice = new PopUpListData();

		if (list_popUpListData != null
		    && list_popUpListData.Count != 0){
			
			if (m_list_intIndexHide_Notice.Count == 0){
				
				m_popUpListData_Notice = list_popUpListData[0];
				
			} else {
				
				for (int i = 0; i < list_popUpListData.Count; i++){
					
					bool boolHideIndex = false;
					
					for (int j = 0; j < m_list_intIndexHide_Notice.Count; j++){
						
						if (list_popUpListData[i].PopUpIndex.Equals(m_list_intIndexHide_Notice[j].ToString())){
							
							boolHideIndex = true;
							break;
						}
					}
					
					if (!boolHideIndex){
						
						m_popUpListData_Notice = list_popUpListData[i];
						break;
					}
				}
				
			}
		}
		
		if (m_popUpListData_Notice.PopUpIndex == null
		    || m_popUpListData_Notice.PopUpIndex.Equals("")){
			
			Process_Main_42_Check_EventPopup();
			
		} else {

			StartCoroutine(_eventPopupView.PopupView_Show(
				Constant.POPUPTYPE_Notice_INT,
				int.Parse(m_popUpListData_Notice.PopUpIndex),
				m_popUpListData_Notice.ImageURL,
				m_popUpListData_Notice.LinkURL));

			m_list_intIndexShown_Notice.Add(int.Parse(m_popUpListData_Notice.PopUpIndex));
		}

	}

	private void Process_Main_42_Check_EventPopup(){

		//Debug.Log("ST110 MainTitleManager.Process_Main_42_Check_EventPopup() Run!!");

		List<PopUpListData> list_popUpListData = new List<PopUpListData>();

		if (m_list_intIndexShown_Event.Count == 0){

			list_popUpListData = m_list_popUpListData_Event;

		} else {

			if (m_list_popUpListData_Event != null
			    && m_list_popUpListData_Event.Count != 0){

				for (int i = 0; i < m_list_popUpListData_Event.Count; i++){
					
					bool boolEqual = false;
					
					for (int j = 0; j < m_list_intIndexShown_Event.Count; j++){
						
						if (m_list_popUpListData_Event[i].PopUpIndex.Equals(m_list_intIndexShown_Event[j].ToString())){
							
							boolEqual = true;
							break;
						}
					}
					
					if (!boolEqual){
						
						list_popUpListData.Add(m_list_popUpListData_Event[i]);
					}
				}
			}
		}

		m_popUpListData_Event = new PopUpListData();

		if (list_popUpListData != null
		    && list_popUpListData.Count != 0){
			
			if (m_list_intIndexHide_Event.Count == 0){
				
				m_popUpListData_Event = list_popUpListData[0];
				
			} else {
				
				for (int i = 0; i < list_popUpListData.Count; i++){
					
					bool boolHideIndex = false;
					
					for (int j = 0; j < m_list_intIndexHide_Event.Count; j++){
						
						if (list_popUpListData[i].PopUpIndex.Equals(m_list_intIndexHide_Event[j].ToString())){
							
							boolHideIndex = true;
							break;
						}
					}
					
					if (!boolHideIndex){
						
						m_popUpListData_Event = list_popUpListData[i];
						break;
					}
				}
				
			}
		}
		
		if (m_popUpListData_Event.PopUpIndex == null
		    || m_popUpListData_Event.PopUpIndex.Equals("")){
			
			Process_Main_43_Check_CrossPopup();
			
		} else {

			StartCoroutine(_eventPopupView.PopupView_Show(
				Constant.POPUPTYPE_Event_INT,
				int.Parse(m_popUpListData_Event.PopUpIndex),
				m_popUpListData_Event.ImageURL,
				m_popUpListData_Event.LinkURL));

			m_list_intIndexShown_Event.Add(int.Parse(m_popUpListData_Event.PopUpIndex));
		}

	}
	
	private void Process_Main_21_Check_KakaoLogin(){
		
		//Debug.Log("ST110 MainTitleManager.Process_Main_21_Check_KakaoLogin() Run!!");
		//Debug.Log("ST110 MainTitleManager.Process_Main_21_Check_KakaoLogin() Managers.UserData.UserID = " + Managers.UserData.UserID);
		//Debug.Log("ST110 MainTitleManager.Process_Main_21_Check_KakaoLogin() Managers.UserData.UserNickName = " + Managers.UserData.UserNickName);

		Process_Main_31_SetInitDataStream_KakaoID();

		//#if UNITY_EDITOR
		//
		//Process_Main_31_SetInitDataStream_KakaoID();
		//
		//#elif UNITY_IPHONE || UNITY_ANDROID
		//
		//if (Managers.KaKao.isUserLogin()){
		//
		//	Process_Kakao_02_ActionLocalUser();
		//
		//} else {
		//	
		//	NGUITools.SetActive(_kakaoLoginButton.gameObject, true);
		//	ShowGuestLoginButton(true);
		//}
		//
		//#endif
		
	}
	
	private void Process_Main_31_SetInitDataStream_KakaoID(){
		
		//Debug.Log("ST110 MainTitleManager.Process_Main_31_SetInitDataStream_KakaoID() Run!!");
		
		// EventDelegate 초기화 - KakaoManager_ActionWorldRankingData.
		//Managers.KaKao.Event_Delegate_KakaoManager_ActionWorldRankingData += null;


		if(!Managers.UserData.IsGuestMode)
		{
			#if !UNITY_EDITOR
			
			if (Managers.DataStream != null){
				
				strUserID = Managers.UserData.UserID;
			}
			
			#endif
		}
		Managers.DataStream.SetInitDataStream(strUserID, Constant.AppVersionInfo);
		
		Process_Main_32_Network_ReadUserData();
		
	}
	
	private void Process_Main_32_Network_ReadUserData(){
		
		//Debug.Log("ST110 MainTitleManager.Process_Main_32_Network_ReadUserData() Run!!");
		
		// EventDelegate 초기화 - ReadBalanceData.
		Managers.DataStream.Event_Delegate_DataStreamManager_ReadUserData += null;
		
		if (Managers.DataStream != null){
			
			_indicatorPopupView.LoadIndicatorPopupView() ;
			
			// EventDelegate 정의 - ReadUserData.
			Managers.DataStream.Event_Delegate_DataStreamManager_ReadUserData += (intNetworkReadUserDataResultCode_Input) => {
				
				_indicatorPopupView.RemoveIndicatorPopupView() ;
				//Debug.Log("READ USER DATA");
				if (intNetworkReadUserDataResultCode_Input == Constant.NETWORK_RESULTCODE_OK){

					Managers.UserData.UserID = strUserID;
					Process_Main_41_Check_NickName();
					
				} else if (intNetworkReadUserDataResultCode_Input == Constant.NETWORK_RESULTCODE_Error_Network){
					
					_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ;
					
				} else {
					
					_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
				}
			};
			
			StartCoroutine(Managers.DataStream.Network_ReadUserData()) ;
		}
	}
	
	private void Process_Main_43_Check_CrossPopup(){
		
		//Debug.Log("ST110 MainTitleManager.Process_Main_43_Check_CrossPopup() Run!!");

		List<PopUpListData> list_popUpListData = new List<PopUpListData>();
		
		if (m_list_intIndexShown_Cross.Count == 0){
			
			list_popUpListData = m_list_popUpListData_Cross;
			
		} else {
			
			if (m_list_popUpListData_Cross != null
			    && m_list_popUpListData_Cross.Count != 0){
				
				for (int i = 0; i < m_list_popUpListData_Cross.Count; i++){
					
					bool boolEqual = false;
					
					for (int j = 0; j < m_list_intIndexShown_Cross.Count; j++){
						
						if (m_list_popUpListData_Cross[i].PopUpIndex.Equals(m_list_intIndexShown_Cross[j].ToString())){
							
							boolEqual = true;
							break;
						}
					}
					
					if (!boolEqual){
						
						list_popUpListData.Add(m_list_popUpListData_Cross[i]);
					}
				}
			}
		}

		m_popUpListData_Cross = new PopUpListData();

		if (list_popUpListData != null
		    && list_popUpListData.Count != 0){
			
			if (m_list_intIndexHide_Cross.Count == 0){
				
				m_popUpListData_Cross = list_popUpListData[0];
				
			} else {
				
				for (int i = 0; i < list_popUpListData.Count; i++){
					
					bool boolHideIndex = false;
					
					for (int j = 0; j < m_list_intIndexHide_Cross.Count; j++){
						
						if (list_popUpListData[i].PopUpIndex.Equals(m_list_intIndexHide_Cross[j].ToString())){
							
							boolHideIndex = true;
							break;
						}
					}
					
					if (!boolHideIndex){
						
						m_popUpListData_Cross = list_popUpListData[i];
						break;
					}
				}
				
			}
		}
		
		if (m_popUpListData_Cross.PopUpIndex == null
		    || m_popUpListData_Cross.PopUpIndex.Equals("")){
			Debug.Log("NO POPUP");
			Process_Main_99_SetUi();
			
		} else {
			
			StartCoroutine(_eventPopupView.PopupView_Show(
				Constant.POPUPTYPE_Cross_INT,
				int.Parse(m_popUpListData_Cross.PopUpIndex),
				m_popUpListData_Cross.ImageURL,
				m_popUpListData_Cross.LinkURL));

			m_list_intIndexShown_Cross.Add(int.Parse(m_popUpListData_Cross.PopUpIndex));
		}
		
	}
	
	private void Process_Main_99_SetUi(){
		
		 //Debug.Log("ST110 MainTitleManager.Process_Main_99_SetUi() Run!!");
		
		// EventDelegate 초기화 - ReadUserData.
		Managers.DataStream.Event_Delegate_DataStreamManager_ReadUserData += null;
		
		_indicatorPopupView.RemoveIndicatorPopupView() ;
		
		//		boolBanner_Enable = false; // 테스트.
		//// //Debug.Log("BANNER: " + boolBanner_Enable);
		if (boolBanner_Enable)// && Managers.KaKao.isUserLogin())
		{
			//NGUITools.SetActive (_bannerView.gameObject, false);
			_bannerView.LoadBannerView(strBanner_ImageURL, strBanner_Link, boolBanner_Link_Enable, intBanner_Type, strBanner_EventIndex) ;
			
			//			// //Debug.Log("ST110 MainTitleManager.Process_14_SetUi().strBanner_ImageURL = " + strBanner_ImageURL);

		}

		NGUITools.SetActive(_title_Touch_Screen.gameObject, true) ;
		//NGUITools.SetActive(_replayIntroButton.gameObject, true) ;
		
		boolGo_NextScene = true ;
		//Debug.Log("?");

	}
	
	
	
	
	
	// ==================== Button Click 정의 - Start ====================
	
	public void OnClickGoMarineStrikeButton() {
		
		if(!boolGo_NextScene){
			
			return ;
		}
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_GameReady,false);
		
		// Torpedo..
		Managers.Torpedo.StartCheckTorpedo() ;
		//
		ST200KLogManager.Instance.SaveLogin();

		if(!PlayerPrefs.HasKey("EXPLAIN"))
		{
			PlayerPrefs.SetString("EXPLAIN", "hi");
			PlayerPrefs.Save();
			Application.LoadLevel(Constant.SCENE_Explain);
		}else
		{
			//Application.LoadLevel(Constant.SCENE_Explain);
			Application.LoadLevel(Constant.SCENE_Ranking);
		}
		
	}

	
	private void Process_Kakao_06_01_Network_DeleteUserData(){
		
		 //Debug.Log("ST110 MainTitleManager.Process_Kakao_06_01_Network_DeleteUserData() Run!!");
		
		_indicatorPopupView.LoadIndicatorPopupView() ;
		
		// EventDelegate 정의 - DataStreamManager_DeleteUserData.
		Managers.DataStream.Event_Delegate_DataStreamManager_DeleteUserData += (intNetworkResultCode_Input) => {
			
			_indicatorPopupView.RemoveIndicatorPopupView();
			
			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
				
				Process_Kakao_06_02_ActionWorldRankingData();
				
			} else {
				
				Process_Kakao_06_02_ActionWorldRankingData();
			}
			
			//Managers.KaKao.Event_Delegate_KakaoManager_ActionWorldRankingUpdateResult += null;
		};


		if(!Managers.UserData.IsGuestMode)
		{
			#if !UNITY_EDITOR
			
			if (Managers.DataStream != null){
				
				strUserID = Managers.UserData.UserID;
			}
			
			#endif
		}

		Managers.DataStream.SetInitDataStream(strUserID, Constant.AppVersionInfo);
		
		// DeleteUserData 퉁신하기.
		StartCoroutine(Managers.DataStream.Network_DeleteUserData()) ;
	}
	
	private void Process_Kakao_06_02_ActionWorldRankingData(){

	}
	
	// ==================== Kakao 로그인 프로세스 - End ====================
	
	// ==================== EventDelegate 정의 - Start ====================
	
	private void HandleDelegate_BannerView(BannerView bannerView, string messageText, int state){

		//Debug.Log("ST110 MainTitleManager.HandleDelegate_BannerView().messageText = " + messageText);
		//Debug.Log("ST110 MainTitleManager.HandleDelegate_BannerView().state = " + state);
		
		if(state == 1001){
			// Connect Icon Start!!!!
			_indicatorPopupView.LoadIndicatorPopupView() ;
			//	
		}else if(state == 1002){
			// Connect Icon End!!!!
			_indicatorPopupView.RemoveIndicatorPopupView() ;
			//
		}else if(state == 2001){
			_messageAlertPopupView.LoadMessageAlertPopupView(messageText) ;
		}
		
	}
	
	private void HandleDelegate_MessageAlertPopupView(MessageAlertPopupView messageAlertPopupView, int state) {
		//Nothing..
	}
	
	
	private void HandleDelegate_AgreementPopupView(AgreementPopupView agreementPopupView, int state) {
		
		//Debug.Log("ST110 MainTitleManager.HandleDelegate_AgreementPopupView().state = " + state);

		if (state == 100){
			
			Process_Main_12_Check_Updata();
		}
		
	}
	
	
	private void HandleDelegate_UpdateInfoPopupView(UpdateInfoPopupView updateInfoPopupView, int state){

		//Debug.Log("ST110 MainTitleManager.HandleDelegate_UpdateInfoPopupView().state = " + state);

		if(state == 100) { //UpdateInfoPopupView Close!!
			
			Application.OpenURL(strAppDownloadURL);
			
			//--
			Application.Quit() ;
			//--
			
		}
	}
	
	private void HandleDelegate_EventPopupView(int intPopupType_Input, int intState_Input) {

		//Debug.Log("ST110 MainTitleManager.HandleDelegate_EventPopupView().intPopupType_Input = " + intPopupType_Input);
		//Debug.Log("ST110 MainTitleManager.HandleDelegate_EventPopupView().intState_Input = " + intState_Input);

		if (intPopupType_Input == Constant.POPUPTYPE_Notice_INT) {

			if (intState_Input == Constant.HIDETODAY_Yes_INT){

				Data_IndexHide_PopupNotice_Save();
			}

			Process_Main_41_Check_NoticePopup();

		} else if (intPopupType_Input == Constant.POPUPTYPE_Event_INT){

			if (intState_Input == Constant.HIDETODAY_Yes_INT){

				Data_IndexHide_PopupEvent_Save();
			}

			Process_Main_42_Check_EventPopup();

		} else if (intPopupType_Input == Constant.POPUPTYPE_Cross_INT){

			if (intState_Input == Constant.HIDETODAY_Yes_INT){

				Data_IndexHide_PopupCross_Save();
			}

			Process_Main_43_Check_CrossPopup();
		}

	}

	private void HandleDelegate_NicknameView(int intState_Input) {
		
		//Debug.Log("ST110 MainTitleManager.HandleDelegate_EventPopupView().intPopupType_Input = " + intPopupType_Input);
		//Debug.Log("ST110 MainTitleManager.HandleDelegate_EventPopupView().intState_Input = " + intState_Input);
		if(intState_Input == Constant.ST200_POPUP_NICKNAME_SUCCESS)
		{
			Process_Main_41_Check_NoticePopup();
		}else
		{
			_uiRootAlertView.LoadUIRootAlertView(intState_Input);
		}
	}

	
	
	private void HandleDelegate_UIRootAlertView(UIRootAlertView uiRootAlertView, int alertType){
		
		if (alertType == 11){ // 통신상태가 불안정합니다. 다시 실행해 주세요.
			
			Application.Quit() ;
			
		} else if (alertType == 21){ // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
			
			Application.Quit() ;
			
		} else if (alertType == Constant.ST200_POPUP_MESSAGE_EXIT){
			
			Application.Quit() ;
			
		} else if (alertType == 9){ // 패키지가 올바르지 않습니다.\n해당 마켓에서 다시 설치 후 실행해 주세요.
			
			Application.Quit() ;
		}else if(alertType == 4003){ 
			//guest mode login

		}
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

	// ==================== EventDelegate 정의 - End ====================
	
	private void Data_PostData_Push_Set(){
		
		m_PostData_PushInfo = new PostData_PushInfo ();
		
		#if UNITY_IPHONE && !UNITY_EDITOR
		m_PostData_PushInfo.Deviceid = SystemInfo.deviceUniqueIdentifier;
		
		string strAdid = iPhone.advertisingIdentifier;
		
		if (strAdid == null 
		    || strAdid.Equals("") ) {
			
			strAdid = SystemInfo.deviceUniqueIdentifier;
			
			 //Debug.Log("ST110 MaintitleManager.Get_PostData_Push().strAdid == null || strAdid.Equals() ");
		}
		
		 //Debug.Log("ST110 MaintitleManager.Get_PostData_Push().strAdid = " + strAdid);
		m_PostData_PushInfo.ADID = strAdid;
		m_PostData_PushInfo.Service = "ST200";
		m_PostData_PushInfo.Ostype = "1";
		m_PostData_PushInfo.Mtype = "1";
		if(Managers.LanguageCode == PFPFileManager.LANGUAGE_KOR)
		{
			m_PostData_PushInfo.Language = "ko";
		}else
		{
			m_PostData_PushInfo.Language = "en";
		}
		//string strCountryCode = "us";//r100 webview something code
		m_PostData_PushInfo.Country = Managers.CountryCode;

		m_PostData_PushInfo.AppVersion = Constant.AppVersionInfo;

		#elif UNITY_ANDROID && !UNITY_EDITOR
		m_PostData_PushInfo.Deviceid = SystemInfo.deviceUniqueIdentifier;
		m_PostData_PushInfo.ADID = "";
		m_PostData_PushInfo.Service = "ST200";
		m_PostData_PushInfo.Ostype = "2";
		m_PostData_PushInfo.Mtype = Constant.CURRENT_MARKET;
		if(Managers.LanguageCode == PFPFileManager.LANGUAGE_KOR)
		{
			m_PostData_PushInfo.Language = "ko";
		}else
		{
			m_PostData_PushInfo.Language = "en";
		}
		m_PostData_PushInfo.Country = Managers.CountryCode;
		
		m_PostData_PushInfo.AppVersion = Constant.AppVersionInfo;
		# else
		m_PostData_PushInfo.Deviceid = SystemInfo.deviceUniqueIdentifier;
		m_PostData_PushInfo.ADID = "";
		m_PostData_PushInfo.Service = "ST200";
		m_PostData_PushInfo.Ostype = "2";
		m_PostData_PushInfo.Mtype = "2";
		if(Managers.LanguageCode == PFPFileManager.LANGUAGE_KOR)
		{
			m_PostData_PushInfo.Language = "ko";
		}else
		{
			m_PostData_PushInfo.Language = "en";
		}
		m_PostData_PushInfo.Country = "kr";
		m_PostData_PushInfo.AppVersion = Constant.AppVersionInfo;
		
		#endif
		
	}
	
	private void Data_PopupListData_PopupNotice_Set(string strJson_Input){
		
		 //Debug.Log("ST110 MaintitleManager.Data_PopupListData_PopupNotice_Set().strJson_Input = " + strJson_Input);
		
		m_list_popUpListData_Notice = new List<PopUpListData>();
		
		if (strJson_Input != null
		    && !strJson_Input.Equals ("")) {
			
			JSONNode jSonNode_Root = JSON.Parse(strJson_Input);
			JSONArray jSonArray_PopUpList = jSonNode_Root["PopUpNoticeList"].AsArray;
			
			if (jSonArray_PopUpList != null
			    && jSonArray_PopUpList.Count > 0){
				
				for (int i = 0; i < jSonArray_PopUpList.Count; i++){
					
					PopUpListData PopUpListData = new PopUpListData();
					PopUpListData.PopUpIndex = jSonArray_PopUpList[i]["Index"].Value;
					PopUpListData.ImageURL = jSonArray_PopUpList[i]["ImageURL"].Value;
					PopUpListData.LinkURL = jSonArray_PopUpList[i]["LinkURL"].Value;
					
					m_list_popUpListData_Notice.Add(PopUpListData);
				}
			}
		}
		
	}

	private void Data_IndexHide_PopupNotice_Set(){
		
		string strHideIndex_Json = PlayerPrefs.GetString(Constant.PREFKEY_IndexHide_PopupNotice_STR);
		string strHideIndex_ChangeTime = PlayerPrefs.GetString(Constant.PREFKEY_IndexHide_ChangeTime_PopupNotice_STR);
		string strDateToday = System.DateTime.Today.ToString ();
		
		if (!strHideIndex_ChangeTime.Equals(strDateToday)){
			
			strHideIndex_Json = "";
		}
		
		m_list_intIndexHide_Notice = new List<int> ();
		
		if (strHideIndex_Json != null
		    && !strHideIndex_Json.Equals("")){
			
			JSONArray jSonArray_HideIndex = JSON.Parse(strHideIndex_Json).AsArray;
			
			if (jSonArray_HideIndex != null
			    && jSonArray_HideIndex.Count > 0){
				
				for (int i = 0; i < jSonArray_HideIndex.Count; i++){
					
					int intHideIndex = int.Parse(jSonArray_HideIndex[i].Value);
					m_list_intIndexHide_Notice.Add(intHideIndex);
				}
			}
		}
		
		//Debug.Log ("ST110 MainTitleManager.Data_IndexHide_PopupNotice_Set().strHideIndex_Json = " + strHideIndex_Json);

	}

	private void Data_IndexHide_PopupNotice_Save(){

		m_list_intIndexHide_Notice.Add (int.Parse(m_popUpListData_Notice.PopUpIndex));
		string strHideIndex_Json = JsonMapper.ToJson(m_list_intIndexHide_Notice);
		
		string strDateToday = System.DateTime.Today.ToString ();
		
		PlayerPrefs.SetString (Constant.PREFKEY_IndexHide_PopupNotice_STR, strHideIndex_Json);
		PlayerPrefs.SetString (Constant.PREFKEY_IndexHide_ChangeTime_PopupNotice_STR, strDateToday);
		
		//Debug.Log ("ST110 MainTitleManager.Data_IndexHide_PopupNotice_Save().strHideIndex_Json = " + strHideIndex_Json);
		//Debug.Log ("ST110 MainTitleManager.Data_IndexHide_PopupNotice_Save().strDateToday = " + strDateToday);

	}

	private void Data_PopupListData_PopupEvent_Set(string strJson_Input){
		
		 //Debug.Log("ST110 MaintitleManager.Data_PopupListData_PopupEvent_Set().strJson_Input = " + strJson_Input);
		
		m_list_popUpListData_Event = new List<PopUpListData>();
		
		if (strJson_Input != null
		    && !strJson_Input.Equals ("")) {
			
			JSONNode jSonNode_Root = JSON.Parse(strJson_Input);
			JSONArray jSonArray_PopUpList = jSonNode_Root["PopUpEventList"].AsArray;
			
			if (jSonArray_PopUpList != null
			    && jSonArray_PopUpList.Count > 0){
				
				for (int i = 0; i < jSonArray_PopUpList.Count; i++){
					
					PopUpListData PopUpListData = new PopUpListData();
					PopUpListData.PopUpIndex = jSonArray_PopUpList[i]["Index"].Value;
					PopUpListData.ImageURL = jSonArray_PopUpList[i]["ImageURL"].Value;
					PopUpListData.LinkURL = jSonArray_PopUpList[i]["LinkURL"].Value;

					m_list_popUpListData_Event.Add(PopUpListData);
				}
			}
		}

	}

	private void Data_IndexHide_PopupEvent_Set(){
		
		string strHideIndex_Json = PlayerPrefs.GetString(Constant.PREFKEY_IndexHide_PopupEvent_STR);
		string strHideIndex_ChangeTime = PlayerPrefs.GetString(Constant.PREFKEY_IndexHide_ChangeTime_PopupEvent_STR);
		string strDateToday = System.DateTime.Today.ToString ();
		
		if (!strHideIndex_ChangeTime.Equals(strDateToday)){
			
			strHideIndex_Json = "";
		}
		
		m_list_intIndexHide_Event = new List<int> ();
		
		if (strHideIndex_Json != null
		    && !strHideIndex_Json.Equals("")){
			
			JSONArray jSonArray_HideIndex = JSON.Parse(strHideIndex_Json).AsArray;
			
			if (jSonArray_HideIndex != null
			    && jSonArray_HideIndex.Count > 0){
				
				for (int i = 0; i < jSonArray_HideIndex.Count; i++){
					
					int intHideIndex = int.Parse(jSonArray_HideIndex[i].Value);
					m_list_intIndexHide_Event.Add(intHideIndex);
				}
			}
		}
		
		//Debug.Log ("ST110 MainTitleManager.Data_IndexHide_PopupEvent_Set().strHideIndex_Json = " + strHideIndex_Json);

	}

	private void Data_IndexHide_PopupEvent_Save(){
		
		m_list_intIndexHide_Event.Add (int.Parse(m_popUpListData_Event.PopUpIndex));
		string strHideIndex_Json = JsonMapper.ToJson(m_list_intIndexHide_Event);
		
		string strDateToday = System.DateTime.Today.ToString ();
		
		PlayerPrefs.SetString (Constant.PREFKEY_IndexHide_PopupEvent_STR, strHideIndex_Json);
		PlayerPrefs.SetString (Constant.PREFKEY_IndexHide_ChangeTime_PopupEvent_STR, strDateToday);
		
		//Debug.Log ("ST110 MainTitleManager.Data_IndexHide_PopupEvent_Save().strHideIndex_Json = " + strHideIndex_Json);
		//Debug.Log ("ST110 MainTitleManager.Data_IndexHide_PopupEvent_Save().strDateToday = " + strDateToday);

	}

	private void Data_PopupListData_PopupCross_Set(string strJson_Input){
		
		// 테스트용.
		//	strJson_Input = "{\"status\":1,\"message\":\"OK\",\"PopUpList\":[{\"PopUpIndex\":10,\"ImageURL\":\"http://imgnews.naver.net/image/030/2014/05/07/559543_20140507135924_225_0001_59_20140507153007.jpg\",\"LinkURL\":\"http://www.naver.com/\"},{\"PopUpIndex\":12,\"ImageURL\":\"\",\"LinkURL\":\"\"},{\"PopUpIndex\":15,\"ImageURL\":\"\",\"LinkURL\":\"\"}]}";
		
		 //Debug.Log("ST110 MaintitleManager.Data_PopupListData_PopupCross_Set().strJson_Input = " + strJson_Input);
		
		m_list_popUpListData_Cross = new List<PopUpListData>();
		
		if (strJson_Input != null
		    && !strJson_Input.Equals ("")) {
			
			JSONNode jSonNode_Root = JSON.Parse(strJson_Input);
			JSONArray jSonArray_PopUpList = jSonNode_Root["PopUpList"].AsArray;
			
			if (jSonArray_PopUpList != null
			    && jSonArray_PopUpList.Count > 0){
				
				for (int i = 0; i < jSonArray_PopUpList.Count; i++){
					
					PopUpListData PopUpListData = new PopUpListData();
					PopUpListData.PopUpIndex = jSonArray_PopUpList[i]["PopUpIndex"].Value;
					PopUpListData.ImageURL = jSonArray_PopUpList[i]["ImageURL"].Value;
					PopUpListData.LinkURL = jSonArray_PopUpList[i]["LinkURL"].Value;
					
					m_list_popUpListData_Cross.Add(PopUpListData);
				}
			}
		}
		
	}
	
	private void Data_IndexHide_PopupCross_Set(){
		
		string strHideIndex_Json = PlayerPrefs.GetString(Constant.PREFKEY_IndexHide_PopupCross_STR);
		string strHideIndex_ChangeTime = PlayerPrefs.GetString(Constant.PREFKEY_IndexHide_ChangeTime_PopupCross_STR);
		string strDateToday = System.DateTime.Today.ToString ();
		
		if (!strHideIndex_ChangeTime.Equals(strDateToday)){
			
			strHideIndex_Json = "";
		}
		
		m_list_intIndexHide_Cross = new List<int> ();
		
		if (strHideIndex_Json != null
		    && !strHideIndex_Json.Equals("")){
			
			JSONArray jSonArray_HideIndex = JSON.Parse(strHideIndex_Json).AsArray;
			
			if (jSonArray_HideIndex != null
			    && jSonArray_HideIndex.Count > 0){
				
				for (int i = 0; i < jSonArray_HideIndex.Count; i++){
					
					int intCrossPopUp_HideIndex = int.Parse(jSonArray_HideIndex[i].Value);
					m_list_intIndexHide_Cross.Add(intCrossPopUp_HideIndex);
				}
			}
		}

		//Debug.Log ("ST110 MainTitleManager.Data_IndexHide_PopupCross_Set().strHideIndex_Json = " + strHideIndex_Json);

	}
	
	private void Data_IndexHide_PopupCross_Save(){
		
		m_list_intIndexHide_Cross.Add (int.Parse(m_popUpListData_Cross.PopUpIndex));
		string strHideIndex_Json = JsonMapper.ToJson(m_list_intIndexHide_Cross);
		
		string strDateToday = System.DateTime.Today.ToString ();
		
		PlayerPrefs.SetString (Constant.PREFKEY_IndexHide_PopupCross_STR, strHideIndex_Json);
		PlayerPrefs.SetString (Constant.PREFKEY_IndexHide_ChangeTime_PopupCross_STR, strDateToday);

		//Debug.Log ("ST110 MainTitleManager.Data_IndexHide_PopupCross_Save().strHideIndex_Json = " + strHideIndex_Json);
		//Debug.Log ("ST110 MainTitleManager.Data_IndexHide_PopupCross_Save().strDateToday = " + strDateToday);
		
	}

	public void ShowGuestLoginButton(bool _flag)
	{
#if UNITY_IPHONE
#else
#endif
	}

}
