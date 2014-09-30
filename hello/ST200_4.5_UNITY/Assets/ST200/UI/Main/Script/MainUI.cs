using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class MainUI : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UILabel m_CharacterLabel;
	public UILabel m_ShipLabel;
	public UILabel m_SubShipLabel;

	public UILabel m_ReadyLabel;

	public UISprite m_CharacterSelectSprite;
	public UISprite m_ShipSelectSprite;
	public UISprite m_SubShipSelectSprite;

	public WorldRankingUI m_WorldRankingUI;
	public SettingPopupView m_SettingPopupView;
	public InboxPopupView m_InboxPopupView;
	public GameObject m_NewMessageGameObject;

	public MainUIShipDisplayer m_MainUIShipDisplayer;
	public ShipSelectUI m_ShipSelectUI;
	public CharacterSelectUI m_CharacterSelectUI;
	public SubShipSelectUI m_SubShipSelectUI;

	public AttendPopupView m_AttendPopupView;
	public EventPopupView m_EventPopupView;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitUI()
	{
		CheckPopupViews();
		m_TitleLabel.text = Constant.COLOR_MAIN_TITLE + TextManager.Instance.GetString(48);
		m_CharacterLabel.text = Constant.COLOR_MAIN_TOP_LABEL + TextManager.Instance.GetString(49);
		m_ShipLabel.text = Constant.COLOR_MAIN_TOP_LABEL + TextManager.Instance.GetString(50);

		m_ReadyLabel.text = Constant.COLOR_MAIN_SHIP_READY + TextManager.Instance.GetString(55);
		m_SubShipLabel.text = Constant.COLOR_MAIN_TOP_LABEL + TextManager.Instance.GetString(51);

		ChangePanel(1);
		m_MainUIShipDisplayer.Init();
		m_ShipSelectUI.InitUI();
		m_CharacterSelectUI.InitUI();
		m_SubShipSelectUI.Init();
		UpdateUI();
	}

	public void UpdateUI()
	{
		//InitializeGameGoldAndGameJewelInfo() ;
		//InitializeGameTorpedoInfo() ;
		//InitializeSubmarineAndCharacterInfo() ;
		//InitLuckyPresentObject();
		m_MainUIShipDisplayer.UpdateUI();
		m_ShipSelectUI.UpdateUI();
		m_CharacterSelectUI.UpdateUI();
		m_SubShipSelectUI.UpdateUI();

		if(Managers.UserData.InboxMessageCountNew > 0)
		{
			m_NewMessageGameObject.gameObject.SetActive(true);
		}else
		{
			m_NewMessageGameObject.gameObject.SetActive(false);
		}
	}


	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			if(m_AttendPopupView.OnEscapePress())
			{
				return true;
			}else if(m_EventPopupView.OnEscapePress())
			{
				return true;
			}else if(m_WorldRankingUI.OnEscapePress())
			{
				return true;
			}else if(m_InboxPopupView.OnEscapePress())
			{
				return true;
			}else if(m_SettingPopupView.OnEscapePress())
			{
				return true;
			}else if(m_ShipSelectUI.OnEscapePress())
			{
				return true;
			}else if(m_CharacterSelectUI.OnEscapePress())
			{
				return true;
			}else if(m_SubShipSelectUI.OnEscapePress())
			{
				return true;
			}
		}

		return false;
	}

	public void OnClickGameReadyButton(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_GameReady,false);
		
		// Connect Icon Start!!!!
		//_indicatorPopupView.LoadIndicatorPopupView();
		Managers.UserData.ExperienceIndex = 0;
		//
		
		if (Managers.DataStream != null){
			
			if (Managers.UserData != null){
				
				// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
				Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
					
					//_indicatorPopupView.RemoveIndicatorPopupView() ;
					
					if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK){
						
					//	_indicatorPopupView.RemoveIndicatorPopupView() ;
						GameUIManager.Instance.SwitchToStageSelectManager();
					} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network){
						
					//	_uiRootAlertView.LoadUIRootAlertView(11) ; // 통신상태가 불안정합니다. 다시 실행해 주세요.
					//	_uiRootAlertView.UIRootAlertViewEvent += UIRootAlertViewDelegate ;
						
					}else {
						
					//	_uiRootAlertView.LoadUIRootAlertView(21) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
					//	_uiRootAlertView.UIRootAlertViewEvent += UIRootAlertViewDelegate ;
					}
					//Debug.Log("RESULT: " + intResult_Code_Input);
					Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null;
				};
				
				UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
				
				Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
				// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
			}
		}

		//Debug.Log("click game ready");
	}

	public void OnClickMailButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		m_InboxPopupView.LoadInboxPopupView() ;
		Managers.UserData.InboxMessageCountNew = 0;
		UpdateUI();
		//m_MessageNewGameObject.gameObject.SetActive(false);
	}

	public void OnClickSettingButton(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

		m_SettingPopupView.LoadSettingPopupView() ;
	}

	public void OnClickRankingButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

		m_WorldRankingUI.ShowUI();
	}

	public void OnClickCharacterButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ChangePanel(1);
		m_CharacterSelectUI.UpdateUI();
	}

	public void OnClickShipButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ChangePanel(0);
		m_ShipSelectUI.UpdateUI();
	}
		
	public void OnClickSubShipButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ChangePanel(2);
		m_SubShipSelectUI.UpdateUI();
	}


	/// <summary>
	/// [_selected]
	/// 0 - ship
	/// 1 - character
	/// 2 - subship
	/// </summary>
	public int CurMode = 0;
	/// <summary>
	/// [_selected]
	/// 0 - ship
	/// 1 - character
	/// 2 - subship
	/// </summary>
	public void ChangePanel(int _selected)
	{
		CurMode = _selected;
		NGUITools.SetActive(m_ShipSelectUI.gameObject, false);
		NGUITools.SetActive(m_CharacterSelectUI.gameObject, false);
		NGUITools.SetActive(m_SubShipSelectUI.gameObject, false);
		if(_selected == 0)
		{
			NGUITools.SetActive(m_ShipSelectUI.gameObject, true);
			m_CharacterSelectSprite.spriteName = "main_tap_not_selected";
			m_ShipSelectSprite.spriteName = "main_tap_selected";
			m_SubShipSelectSprite.spriteName = "main_tap_not_selected";
		}else if(_selected == 1)
		{
			NGUITools.SetActive(m_CharacterSelectUI.gameObject, true);
			m_CharacterSelectSprite.spriteName = "main_tap_selected";
			m_ShipSelectSprite.spriteName = "main_tap_not_selected";
			m_SubShipSelectSprite.spriteName = "main_tap_not_selected";
		}else if(_selected == 2)
		{
			NGUITools.SetActive(m_SubShipSelectUI.gameObject, true);
			m_CharacterSelectSprite.spriteName = "main_tap_not_selected";
			m_ShipSelectSprite.spriteName = "main_tap_not_selected";
			m_SubShipSelectSprite.spriteName = "main_tap_selected";
			m_SubShipSelectUI.Init();
		}
	}


	
	// 이벤트 팝업뷰 추가 (by 최원석 14.05.12) ==================== Start.
	public void CheckPopupViews(){
		
		//Debug.Log("ST110 GameRankingManager.CheckPopupViews() Run!!");
		
		int intMainScene_To_RankingScene = PlayerPrefs.GetInt (Constant.PREFKEY_MainScene_To_RankingScene_INT);
		
		// Main 씬에서 Ranking 씬으로 넘어왔는지 여부 - true.
		if (intMainScene_To_RankingScene == Constant.INT_True) {
			
			// 출석 이벤트 정보 체크.
			CheckPopUpView_Attend();
			
			// Main 씬에서 Ranking 씬으로 넘어왔는지 여부 - false.
		} else {
			
			m_AttendPopupView.Hide_AttendPopupView();
			m_EventPopupView.PopupView_Remove();
			if(!Managers.UserData.TutorialFlagV119)
			{
				GameUIManager.Instance.m_MainTutorial.StartTutorial();
			}
		}
		
		PlayerPrefs.SetInt(Constant.PREFKEY_MainScene_To_RankingScene_INT, Constant.INT_False);
	}
	
	private void CheckPopUpView_Attend(){
		
		string strExtend_Json = PlayerPrefs.GetString(Constant.PREFKEY_ReadUserData_Extend);
		JSONNode jsonExtend_Root = JSON.Parse(strExtend_Json);
		string strExtend_Attend_set_index = jsonExtend_Root ["attend"]["set_index"];
		
		//Debug.Log("ST110 GameRankingManager.CheckPopUpView_Attend().strExtend_Json = " + strExtend_Json);
		//Debug.Log("ST110 GameRankingManager.CheckPopUpView_Attend().strExtend_Attend_set_index = " + strExtend_Attend_set_index);
		
		if (strExtend_Attend_set_index != null && !strExtend_Attend_set_index.Equals("")) {
			
			m_AttendPopupView.Event_AttendPopupView_NetworkResult += (intNetworkResult_Input) => {
				
				if (intNetworkResult_Input == Constant.NETWORK_RESULTCODE_OK){

				} else if (intNetworkResult_Input == Constant.NETWORK_RESULTCODE_Error_Network){
					
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD);
				} else {
					
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
				}
				
				m_AttendPopupView.Event_AttendPopupView_NetworkResult += null;
			};
			
			m_AttendPopupView.Show_AttendPopupView (strExtend_Json);
			
		} else {
			
			m_AttendPopupView.Hide_AttendPopupView();
			if(!Managers.UserData.TutorialFlagV119)
			{
				GameUIManager.Instance.m_MainTutorial.StartTutorial();
			}
		}
		
	}
}
