using UnityEngine;
using System.Collections;

public class SettingPopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void Delegate_SettingPopupView(SettingPopupView _settingPopupView_Input, int intState_Input);
	protected Delegate_SettingPopupView _delegate_SettingPopupView ;
	public event Delegate_SettingPopupView Event_Delegate_SettingPopupView {
		add{
			
			_delegate_SettingPopupView = null ;
			
			if (_delegate_SettingPopupView == null)
        		_delegate_SettingPopupView += value;
        }
		
		remove{
            _delegate_SettingPopupView -= value;
		}
	}

	public UILabel m_TitleLabel;
	public SettingPopupViewToggleObject m_SoundOption;
	public SettingPopupViewToggleObject m_VibrateOption;
	public SettingPopupViewToggleObject m_PushOption;
	public UILabel m_QNALabel;
	public UILabel m_UserIDLabel;
	public UILabel m_TutorialLabel;
	public GameObject m_InitButton;
	// ==================== Unity Override 정의 - Start ====================
	void Awake() {
		
	}
	
	void Start() {

	}
	
	private void Update() {
	
	}

	public void Init()
	{
		// 진동은 항상 켜져 있는 걸로 함.
		//Managers.UserData.SaveVibrate(true) ;
		
		if (Managers.UserData != null){
			
			// BGM On, Off 상태 설정.
			m_TitleLabel.text = Constant.COLOR_SETTING_TITLE + TextManager.Instance.GetString(62);
			m_SoundOption.Init (Constant.COLOR_SETTING_OPTION + TextManager.Instance.GetString(63), Managers.UserData.SoundFlag);
			m_VibrateOption.Init(Constant.COLOR_SETTING_OPTION + TextManager.Instance.GetString(64), Managers.UserData.VibrateFlag);
			//Debug.Log("VIB FLAG: " + Managers.UserData.VibrateFlag);
			m_PushOption.Init (Constant.COLOR_SETTING_OPTION + TextManager.Instance.GetString(65), Managers.UserData.PushFlag);
			m_QNALabel.text = Constant.COLOR_SETTING_QNA + TextManager.Instance.GetString(66);
			m_TutorialLabel.text = Constant.COLOR_SETTING_QNA + TextManager.Instance.GetString(225);

		}
		Process_Network_GetPushOnOff ();
		m_UserIDLabel.text = Constant.COLOR_SETTING_OPTION + "ID: " + Managers.UserData.UserID;

		if(Constant.VALTEST1)
		{
			m_InitButton.gameObject.SetActive(true);
		}else
		{
			m_InitButton.gameObject.SetActive(false);
		}
#if UNITY_EDITOR
		m_InitButton.gameObject.SetActive(true);
#endif
	}

	// ==================== Unity Override 정의 - End ====================

	// ==================== Public Method 정의 - Start ====================
	public void InitLoadSettingPopupView(){
		
		NGUITools.SetActive(gameObject, false) ;
		Init();
	}
	
	public void LoadSettingPopupView() {
		
		NGUITools.SetActive(gameObject, true) ;
		Init ();
	}
	
	public void RemoveSettingPopupView() {
		
		NGUITools.SetActive(gameObject, false) ;
	}

	private void Process_Network_GetPushOnOff(){
		
		//		//Debug.Log ("ST110 SettingPopupView.Process_Network_GetPushOnOff() Run!!!");
		
		// IndicatorView - On
		if (_delegate_SettingPopupView != null) {
			_delegate_SettingPopupView(this, 1001) ;	
		}
		
		Managers.DataStream.Event_Delegate_DataStreamManager_GetPushOnOff += (strPushOnOffInfo_Input, intNetworkResultCode_Input) => {
			
			// IndicatorView - Off
			if (_delegate_SettingPopupView != null) {
				_delegate_SettingPopupView(this, 1002) ;	
			}
			
			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){

				if (strPushOnOffInfo_Input.Equals("1")){
					
					//_PushAlarmButtonOff.isChecked = false ;
					//_PushAlarmButtonOn.isChecked = true ;
					Managers.UserData.PushFlag = true;
				} else if (strPushOnOffInfo_Input.Equals("0")){
					
					//_PushAlarmButtonOff.isChecked = true ;
					//_PushAlarmButtonOn.isChecked = false ;
					Managers.UserData.PushFlag = false;
				}
				
			}else{
				
				//_PushAlarmButtonOff.isChecked = true ;
				//_PushAlarmButtonOn.isChecked = false ;
			}

			m_PushOption.SetOption(Managers.UserData.PushFlag);
			Managers.DataStream.Event_Delegate_DataStreamManager_GetPushOnOff += null;
		};
		
		StartCoroutine(Managers.DataStream.Network_GetPushOnOff()) ;
		
	}

	public void OnClickTutorialButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

		GameUIManager.Instance.m_MainTutorial.StartTutorial();
		GameUIManager.Instance.m_MainUI.ChangePanel(1);
		RemoveSettingPopupView();
	}


	public void OnClickSoundButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		Managers.UserData.SoundFlag = !Managers.UserData.SoundFlag;
		m_SoundOption.SetOption(Managers.UserData.SoundFlag);
		if(!Managers.UserData.SoundFlag)
		{
			Managers.Audio.StopBGMSound();
		}else
		{
			Managers.Audio.PlayBGMSound(AudioManager.BGM_SOUND.BGM_Main, true);
		}
	}

	public void OnClickVibrateButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		Managers.UserData.VibrateFlag = !Managers.UserData.VibrateFlag;
		m_VibrateOption.SetOption(Managers.UserData.VibrateFlag);
		//Debug.Log("?: " + Managers.UserData.VibrateFlag);
	}
	
	// ==================== Button Click 정의 - Start ====================
	public void OnClickSettingPopupViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_delegate_SettingPopupView != null) {
			_delegate_SettingPopupView(this, 500) ;	
		}
		
		RemoveSettingPopupView() ;
		
	}

	public void OnClick_QnA_Button(){

		//Debug.Log ("ST110 SettingPopupView.OnClick_QnA_Button() Run !!!");

		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);


		#if UNITY_IPHONE && !UNITY_EDITOR

		string strQnA_Url = "mailto:master@polycube.co.kr";

		string strQnA_Subject ="";
		string strQnA_Body = "";
		if(PFPFileManager.Instance.m_SelectedLanguage == PFPFileManager.LANGUAGE_KOR)
		{
			strQnA_Subject = "?subject=%EA%B2%8C%EC%9E%84%EB%AC%B8%EC%9D%98(" +  Managers.UserData.UserNickName + ")";
			strQnA_Body = "&body=%EA%B2%8C%EC%9E%84ID:" + Managers.UserData.UserNickName;
		}else
		{
			strQnA_Subject = Constant.QNA_Subject_STR_ENG + Managers.UserData.UserNickName + ")";
			strQnA_Body = Constant.QNA_Body_STR_ENG + Managers.UserData.UserNickName + "\n\n\n";
		}

		Application.OpenURL(strQnA_Url + strQnA_Subject + strQnA_Body);

		//Debug.Log ("ST110 SettingPopupView.OnClick_QnA_Button() Mail = " + strQnA_Url + strQnA_Subject + strQnA_Body);
		
		#elif UNITY_ANDROID && !UNITY_EDITOR

		string strQnA_Url = "mailto:master@polycube.co.kr";
		string strQnA_Subject ="";
		string strQnA_Body = "";
		if(PFPFileManager.Instance.m_SelectedLanguage == PFPFileManager.LANGUAGE_KOR)
		{
			strQnA_Subject = Constant.QNA_Subject_STR + Managers.UserData.UserNickName + ")";
			strQnA_Body = Constant.QNA_Body_STR + Managers.UserData.UserNickName + "\n\n\n";
		}else
		{
			strQnA_Subject = Constant.QNA_Subject_STR_ENG + Managers.UserData.UserNickName + ")";
			strQnA_Body = Constant.QNA_Body_STR_ENG + Managers.UserData.UserNickName + "\n\n\n";
		}

		Application.OpenURL(strQnA_Url + strQnA_Subject + strQnA_Body);

		#endif

	}

	public void OnClick_SetPush(){

//		//Debug.Log ("ST110 SettingPopupView.Process_Network_SetPush_On() Run!!!");

		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

		// IndicatorView - On
		if (_delegate_SettingPopupView != null) {
			_delegate_SettingPopupView(this, 1001) ;	
		}
		
		Managers.DataStream.Event_Delegate_DataStreamManager_SetPushOnOff += (strPushOnOffInfo_Input, intNetworkResultCode_Input) => 
		{
			
			// IndicatorView - Off
			if (_delegate_SettingPopupView != null) {
				_delegate_SettingPopupView(this, 1002) ;	
			}

			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
				
				if (strPushOnOffInfo_Input.Equals("1")){
					
					//_PushAlarmButtonOff.isChecked = false ;
					//_PushAlarmButtonOn.isChecked = true ;
					Managers.UserData.PushFlag = true;
				} else if (strPushOnOffInfo_Input.Equals("0")){
					
					//_PushAlarmButtonOff.isChecked = true ;
					//_PushAlarmButtonOn.isChecked = false ;
					Managers.UserData.PushFlag = false;
				}
				
			} else {
				
				//_PushAlarmButtonOff.isChecked = false ;
				//_PushAlarmButtonOn.isChecked = true ;
			}
			m_PushOption.SetOption(Managers.UserData.PushFlag);
			Managers.DataStream.Event_Delegate_DataStreamManager_SetPushOnOff += null;
		};
		
		StartCoroutine(Managers.DataStream.Network_SetPushOnOff(!Managers.UserData.PushFlag)) ;
	}

	public void OnClickReset()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

		for(int i = 0 ; i < Managers.UserData.m_UserShipDataList.Count; i++)
		{
			UserShipData usershipdata = Managers.UserData.m_UserShipDataList[i];
			usershipdata.Level = 1;
			Managers.UserData.SetUserShipData(usershipdata);

			Managers.UserData.InitializeShipData();
			Managers.UserData.InitializeStageData();
			Managers.UserData.InitializeSubShipData();
			Managers.UserData.GameCoin = 0;
		}
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			RemoveSettingPopupView();
			return true;
		}
		
		return false;
	}
}
