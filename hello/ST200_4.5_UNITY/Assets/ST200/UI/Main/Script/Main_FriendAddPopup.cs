using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main_FriendAddPopup : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UILabel m_DescriptionLabel1;
	public UILabel m_DescriptionLabel2;
	public UILabel m_TimerLabel;
	public UILabel m_OkLabel;
	public UILabel m_CloseLabel;
	public UISprite m_CharacterSprite;
	public UISprite m_ShipSprite;
	public UILabel m_NickNameLabel;
	public UILabel m_ShipLabel;

	protected List<UserHistoryData> m_UserInfoDataList;
	// Use this for initialization
	void Start () {		
		m_TitleLabel.text = TextManager.Instance.GetString(282);
		m_DescriptionLabel1.text = TextManager.Instance.GetString(283);
		m_DescriptionLabel2.text = TextManager.Instance.GetString(284);
		m_OkLabel.text = TextManager.Instance.GetString(285);
		m_CloseLabel.text = TextManager.Instance.GetString(135);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitUI(List<UserHistoryData> _userinfodatalist)
	{
		m_UserInfoDataList = _userinfodatalist;

		if(m_UserInfoDataList.Count > 0)
		{
			UserHistoryData curuserinfodata = m_UserInfoDataList[0];

			ShipDescriptionInfo shipdescription =  Managers.GameBalanceData.GetShipDescriptionInfo(curuserinfodata.m_UserInfoData.ShipIndex);

			m_NickNameLabel.text = Constant.COLOR_WHITE + curuserinfodata.m_UserInfoData.UserNickName;
			m_ShipLabel.text = Constant.COLOR_GOLD	+ TextManager.Instance.GetString(shipdescription.ShipNameTextIndex) + " Lv. " + curuserinfodata.m_UserInfoData.ShipLevel;
			
			m_CharacterSprite.spriteName = ImageResourceManager.Instance.GetWorldRankingCharacterImage(curuserinfodata.m_UserInfoData.CharacterIndex.ToString());
			m_ShipSprite.spriteName = ImageResourceManager.Instance.GetMainUIShipImageName(curuserinfodata.m_UserInfoData.ShipIndex);

			NGUITools.SetActive (m_TimerLabel.gameObject, false);
			//string[] timestring = TextManager.GetDHM(curuserinfodata.PastSecond);
			//m_TimerLabel.text = Constant.COLOR_PVP_ATTACK_ALERT_DESCRIPTION + timestring[0] + TextManager.Instance.GetString(270) + " " + 
			//	timestring[1] + TextManager.Instance.GetString(271) + " " + 
			//		timestring[2] + TextManager.Instance.GetString(272) + TextManager.Instance.GetString(273);

		}
	}

	protected void UpdateUI()
	{		
		if(m_UserInfoDataList.Count > 0)
		{
			UserHistoryData curuserinfodata = m_UserInfoDataList[0];

			ShipDescriptionInfo shipdescription = Managers.GameBalanceData.GetShipDescriptionInfo(curuserinfodata.m_UserInfoData.ShipIndex);

			m_NickNameLabel.text = Constant.COLOR_WHITE + curuserinfodata.m_UserInfoData.UserNickName;
			m_ShipLabel.text = Constant.COLOR_GOLD	+ TextManager.Instance.GetString(shipdescription.ShipNameTextIndex) + " Lv. " + curuserinfodata.m_UserInfoData.ShipLevel;
			
			m_CharacterSprite.spriteName = ImageResourceManager.Instance.GetWorldRankingCharacterImage(curuserinfodata.m_UserInfoData.CharacterIndex.ToString());
			m_ShipSprite.spriteName = ImageResourceManager.Instance.GetMainUIShipImageName(curuserinfodata.m_UserInfoData.ShipIndex);
			
			NGUITools.SetActive (m_TimerLabel.gameObject, false);
			//string[] timestring = TextManager.GetDHM(curuserinfodata.PastSecond);
			//m_TimerLabel.text = Constant.COLOR_PVP_ATTACK_ALERT_DESCRIPTION + timestring[0] + TextManager.Instance.GetString(270) + " " + 
			//	timestring[1] + TextManager.Instance.GetString(271) + " " + 
			//		timestring[2] + TextManager.Instance.GetString(272) + TextManager.Instance.GetString(273);
			
		}
	}


	protected bool CheckMoreUser()
	{
		if(m_UserInfoDataList.Count > 1)
		{
			m_UserInfoDataList.RemoveAt(0);
			UpdateUI();
			return true;
		}
		return false;
	}

	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void RemoveUI(bool _addfriend)
	{
		if(CheckMoreUser())
		{
			return;
		}else
		{
			Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
			{
				if(_addfriend)
				{
					if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
					{					
						Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input2, string strResult_Extend_Input2) => 
						{
							if(intResult_Code_Input2 == Constant.NETWORK_RESULTCODE_OK)
							{							
								GameUIManager.Instance.SwitchToPVPUI();
								GameUIManager.Instance.m_PVPUI.ShowPVPUI(true);
								NGUITools.SetActive (gameObject, false);
							}else
							{
								Managers.DataStream.PVP_Request_FriendList(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage());
							}
						};
						Managers.DataStream.PVP_Request_FriendList(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage());
					}else
					{
						Managers.DataStream.PVP_Request_Recommend(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage());
					}
				}else
				{
					NGUITools.SetActive (gameObject, false);
				}
			};
			Managers.DataStream.PVP_Request_Recommend(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage());
		}
	}

	public void OnClickOkButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		PVPDataManager.Instance.AddToFriend(m_UserInfoDataList[0].m_UserInfoData);
		GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_PVP_FRIENDADD_SUCCESS,
		                                           new string[]{m_UserInfoDataList[0].m_UserInfoData.UserNickName});
		RemoveUI(true);
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		RemoveUI(false);
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			OnClickCloseButton();
			return true;
		}
		return false;

	}
}
