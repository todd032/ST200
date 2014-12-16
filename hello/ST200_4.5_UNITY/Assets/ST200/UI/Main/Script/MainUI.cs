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
	public Main_AttackAlertPopup m_AttackAlertPopup;
	public Main_FriendAddPopup m_FriendAddPopup;

	public MainUI_ModeSelect m_ModeSelectUI;

	public GameObject m_KakaoInviteButton;
	public GameObject m_FacebookInviteButton;
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

		if(Managers.CountryCode == "kr")
		{
			NGUITools.SetActive(m_KakaoInviteButton.gameObject, true);
			NGUITools.SetActive(m_FacebookInviteButton.gameObject, false);
		}else
		{
			NGUITools.SetActive(m_KakaoInviteButton.gameObject, false);
			NGUITools.SetActive(m_FacebookInviteButton.gameObject, true);
		}
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
			}else if(m_AttackAlertPopup.OnEscapePress())
			{
				return true;
			}else if(m_FriendAddPopup.OnEscapePress())
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
			}else if(m_ModeSelectUI.OnEscapePress())
			{
				return true;
			}
		}

		return false;
	}

	public void OnClickGameReadyButton(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_GameReady,false);

		if(Constant.AppVersionInfo == "1.2.3" || Constant.AppVersionInfo == "1.2.4")
		{
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
							
						}else if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
						{
							GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR); 
						} else {
							
							//	_uiRootAlertView.LoadUIRootAlertView(21) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
							//	_uiRootAlertView.UIRootAlertViewEvent += UIRootAlertViewDelegate ;
						}
						//Debug.Log("RESULT: " + intResult_Code_Input);
						Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null;
					};
					
					Managers.UserData.UpdateSequence++;
					UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
					
					Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
					// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
				}
			}
		}else
		{
			m_ModeSelectUI.ShowUI();
		}
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

	public void OnClickKakaoButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(ST200KakaoLink.g_Instance.InitLink(TextManager.Instance.GetString(246), TextManager.Instance.GetReplaceString(247, Managers.UserData.UserNickName),
		                                   TextManager.Instance.GetString(250)))
		{
			ST200KakaoLink.g_Instance.SendKakaoLinkMessage();
		}else
		{
			GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_INSTALL_KAKAO);
		}
	}

	public void OnClickFacebookButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

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
			}else
			{
				//m_AttackAlertPopup show
				CheckAttackHistoryPopup();
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
				} else if(intNetworkResult_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
				{
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR); 
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
			}else
			{
				//m_AttackAlertPopup show
				CheckAttackHistoryPopup();
			}
		}
		
	}


	public void CheckAttackHistoryPopup()
	{
		Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
		{
			if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
			{	
				//Debug.Log("stresult: " + strResult_Extend_Input);
				JSONNode root = JSON.Parse(strResult_Extend_Input);			
				
				JSONNode friendlist = root["BattleLast"];
				//Debug.Log("TOTAL FRIEND SEARCH COUNT: " + friendlist.Count);
				if(friendlist.Count > 0)
				{
					UserHistoryData historydata = new UserHistoryData();
					for(int friendindexno = 0; friendindexno < friendlist.Count; friendindexno++)
					{
						JSONNode userdata = friendlist[friendindexno];
						//Debug.Log("TOTAL: " + userdata.ToString());
						
						int userindex = userdata["pvp_user_index"].AsInt;
						string nickname = userdata["nickname"];
						int battlecount = userdata["battle_count"].AsInt;
						int wincount = userdata["win_count"].AsInt;
						int losecount = userdata["lose_count"].AsInt;
						JSONNode armdata = userdata["armed_data"];
						int characterindex = armdata["CharacterIndex"].AsInt;
						int tacticindex = armdata["TacticIndex"].AsInt;
						int shipindex = armdata["ShipIndex"].AsInt;
						int shiplevel = armdata["ShipLevel"].AsInt;
						JSONArray subshipindex = armdata["SubShipIndexList"].AsArray;
						JSONArray subshiplevel = armdata["SubShipLeveList"].AsArray;
						int reward = userdata["winning_reward"].AsInt;
						int repairsec = userdata["sec_under_repair"].AsInt;
						
						UserInfoData infodata = new UserInfoData();
						infodata.UserIndex = userindex;
						infodata.UserNickName = nickname;
						infodata.CharacterIndex = characterindex;
						infodata.TacticIndex = tacticindex;
						infodata.ShipIndex = shipindex;
						infodata.ShipLevel = shiplevel;
						int[] subshipindexlist = new int[]{0,0,0,0};
						int[] subshiplevellist = new int[]{0,0,0,0};
						for(int j = 0; j < subshipindexlist.Length; j++)
						{
							if(subshipindex.Count > j)
							{
								subshipindexlist[j] = subshipindex[j].AsInt;
							}
						}
						for(int j = 0; j < subshiplevellist.Length; j++)
						{
							if(subshiplevel.Count > j)
							{
								subshiplevellist[j] = subshiplevel[j].AsInt;
							}
						}
						infodata.SubShipIndexList = subshipindexlist;
						infodata.SubShipLevelList = subshiplevellist;
						
						infodata.RewardAmount = reward;
						infodata.RepairSecond = repairsec;
						//Debug.Log("REARD: " +infodata.RewardAmount + " COME: " + reward);
						historydata.m_UserInfoData = infodata;
						historydata.PastSecond = userdata["psec"].AsInt;
						historydata.Win = userdata["Win"].AsBool;
					}
					m_AttackAlertPopup.ShowUI();
					m_AttackAlertPopup.InitUI(historydata);
				}else
				{
					CheckFriendAddPopup();
				}
			}else
			{
				CheckFriendAddPopup();
			}
		};
		Managers.DataStream.PVP_Request_Popup();
	}

	public void CheckFriendAddPopup()
	{
		Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
		{
			if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
			{	
				//Debug.Log("stresult: " + strResult_Extend_Input);
				JSONNode root = JSON.Parse(strResult_Extend_Input);			
				
				JSONNode friendlist = root["PopUpList"];
				//Debug.Log("TOTAL FRIEND SEARCH COUNT: " + friendlist.Count);
				if(friendlist.Count > 0)
				{
					List<UserHistoryData> friendaddedlist = new List<UserHistoryData>();
					UserHistoryData historydata = new UserHistoryData();
					for(int friendindexno = 0; friendindexno < friendlist.Count; friendindexno++)
					{
						JSONNode userdata = friendlist[friendindexno];
						//Debug.Log("TOTAL: " + userdata.ToString());
						
						int userindex = userdata["pvp_user_index"].AsInt;
						string nickname = userdata["nickname"];
						int battlecount = userdata["battle_count"].AsInt;
						int wincount = userdata["win_count"].AsInt;
						int losecount = userdata["lose_count"].AsInt;
						JSONNode armdata = userdata["armed_data"];
						int characterindex = armdata["CharacterIndex"].AsInt;
						int tacticindex = armdata["TacticIndex"].AsInt;
						int shipindex = armdata["ShipIndex"].AsInt;
						int shiplevel = armdata["ShipLevel"].AsInt;
						JSONArray subshipindex = armdata["SubShipIndexList"].AsArray;
						JSONArray subshiplevel = armdata["SubShipLeveList"].AsArray;
						int reward = userdata["winning_reward"].AsInt;
						int repairsec = userdata["sec_under_repair"].AsInt;
						
						UserInfoData infodata = new UserInfoData();
						infodata.UserIndex = userindex;
						infodata.UserNickName = nickname;
						infodata.CharacterIndex = characterindex;
						infodata.TacticIndex = tacticindex;
						infodata.ShipIndex = shipindex;
						infodata.ShipLevel = shiplevel;
						int[] subshipindexlist = new int[]{0,0,0,0};
						int[] subshiplevellist = new int[]{0,0,0,0};
						for(int j = 0; j < subshipindexlist.Length; j++)
						{
							if(subshipindex.Count > j)
							{
								subshipindexlist[j] = subshipindex[j].AsInt;
							}
						}
						for(int j = 0; j < subshiplevellist.Length; j++)
						{
							if(subshiplevel.Count > j)
							{
								subshiplevellist[j] = subshiplevel[j].AsInt;
							}
						}
						infodata.SubShipIndexList = subshipindexlist;
						infodata.SubShipLevelList = subshiplevellist;
						
						infodata.RewardAmount = reward;
						infodata.RepairSecond = repairsec;
						//Debug.Log("REARD: " +infodata.RewardAmount + " COME: " + reward);
						historydata.m_UserInfoData = infodata;
						historydata.PastSecond = 0;//userdata["psec"].AsInt;
						friendaddedlist.Add(historydata);
					}

					m_FriendAddPopup.ShowUI();
					m_FriendAddPopup.InitUI(friendaddedlist);
				}
			}else
			{
				
			}
		};
		Managers.DataStream.PVP_Request_Friend_Add_Popup();
	}
}
