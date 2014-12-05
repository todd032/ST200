using UnityEngine;
using System.Collections;

public class Main_AttackAlertPopup : MonoBehaviour {

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

	protected UserHistoryData m_UserInfoData;
	// Use this for initialization
	void Start () {
		m_TitleLabel.text = TextManager.Instance.GetString(278);
		m_DescriptionLabel1.text = TextManager.Instance.GetString(279);
		m_DescriptionLabel2.text = TextManager.Instance.GetString(280);
		m_OkLabel.text = TextManager.Instance.GetString(281);
		m_CloseLabel.text = TextManager.Instance.GetString(135);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitUI(UserHistoryData _userinfodata)
	{
		m_UserInfoData = _userinfodata;
		
		m_NickNameLabel.text = Constant.COLOR_WHITE + _userinfodata.m_UserInfoData.UserNickName;

		ShipDescriptionInfo description = Managers.GameBalanceData.GetShipDescriptionInfo(m_UserInfoData.m_UserInfoData.ShipIndex);
		m_ShipLabel.text = Constant.COLOR_GOLD	+ TextManager.Instance.GetString(description.ShipNameTextIndex) + "\nLv. " + m_UserInfoData.m_UserInfoData.ShipLevel;
		
		m_CharacterSprite.spriteName = ImageResourceManager.Instance.GetWorldRankingCharacterImage(m_UserInfoData.m_UserInfoData.CharacterIndex.ToString());
		m_ShipSprite.spriteName = ImageResourceManager.Instance.GetMainUIShipImageName(m_UserInfoData.m_UserInfoData.ShipIndex);

		string[] timestring = TextManager.GetDHM(m_UserInfoData.PastSecond);
		m_TimerLabel.text = Constant.COLOR_PVP_ATTACK_ALERT_DESCRIPTION + timestring[0] + TextManager.Instance.GetString(270) + " " + 
			timestring[1] + TextManager.Instance.GetString(271) + " " + 
				timestring[2] + TextManager.Instance.GetString(272) + TextManager.Instance.GetString(273);

	}

	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive(gameObject, false);
	}

	protected bool m_ClickOk = false;
	public void OnClickOkButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(m_ClickOk)
		{
			return;
		}

		m_ClickOk = true;
		Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
		{
			if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
			{					
				Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input2, string strResult_Extend_Input2) => 
				{
					if(intResult_Code_Input2 == Constant.NETWORK_RESULTCODE_OK)
					{							
						GameUIManager.Instance.SwitchToPVPUI();
						GameUIManager.Instance.m_PVPUI.ShowHistoryUI(false);
						RemoveUI();
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
		};
		Managers.DataStream.PVP_Request_Recommend(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage());
		//RemoveUI();
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		RemoveUI();
		GameUIManager.Instance.m_MainUI.CheckFriendAddPopup();
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
