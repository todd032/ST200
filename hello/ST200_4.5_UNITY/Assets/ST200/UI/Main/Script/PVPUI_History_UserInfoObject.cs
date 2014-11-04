using UnityEngine;
using System.Collections;

public class PVPUI_History_UserInfoObject : MonoBehaviour {
	
	public UISprite m_CharacterSprite;
	public UISprite m_ShipSprite;
	public UILabel m_NickNameLabel;
	public UILabel m_ShipLevelLabel;
	public UILabel m_ResultLabel;
	
	public GameObject m_RevengeButton;
	public UISprite m_RevengeSprite;
	public GameObject m_FixButton;
	public UILabel m_FixTimeLabel;

	public UILabel m_FightTime;
	
	public UserHistoryData m_UserInfoData;
	public void Init(UserHistoryData _userinfodata)
	{
		m_UserInfoData = _userinfodata;
		
		m_NickNameLabel.text = Constant.COLOR_WHITE + _userinfodata.m_UserInfoData.UserNickName;
		m_ShipLevelLabel.text = Constant.COLOR_GOLD	+ "Lv. " + m_UserInfoData.m_UserInfoData.ShipLevel;
		
		m_FixTimeLabel.text = Constant.COLOR_BLACK + "TIMER";
		
		m_CharacterSprite.spriteName = ImageResourceManager.Instance.GetWorldRankingCharacterImage(m_UserInfoData.m_UserInfoData.CharacterIndex.ToString());
		m_ShipSprite.spriteName = ImageResourceManager.Instance.GetMainUIShipImageName(m_UserInfoData.m_UserInfoData.ShipIndex);

		if(m_UserInfoData.Win)
		{
			m_ResultLabel.text = TextManager.Instance.GetString(262);
			NGUITools.SetActive (m_RevengeButton.gameObject, false);
			NGUITools.SetActive (m_FixButton.gameObject, false);
		}else
		{
			m_ResultLabel.text = TextManager.Instance.GetString(263);
			NGUITools.SetActive (m_RevengeButton.gameObject, true);
			NGUITools.SetActive (m_FixButton.gameObject, false);
		}

		if(true)//m_UserInfoData.AttackHistory)
		{
			m_RevengeSprite.spriteName = "pvp_list_pvp_button";
		}else
		{
			m_RevengeSprite.spriteName = "pvp_log_list_pvp_button3";
		}

		if(m_UserInfoData.m_UserInfoData.RepairSecond > 0)
		{
			NGUITools.SetActive(m_RevengeButton.gameObject, false);
			NGUITools.SetActive(m_FixButton.gameObject, true);

			m_FixTimeLabel.text = TextManager.GetHM(m_UserInfoData.m_UserInfoData.RepairSecond);
		}else
		{
			NGUITools.SetActive(m_RevengeButton.gameObject, true);
			NGUITools.SetActive(m_FixButton.gameObject, false);
		}

		string[] timestring = TextManager.GetDHM(m_UserInfoData.PastSecond);
		m_FightTime.text = Constant.COLOR_RED + timestring[0] + TextManager.Instance.GetString(270) + " " + 
			timestring[1] + TextManager.Instance.GetString(271) + " " + 
				timestring[2] + TextManager.Instance.GetString(272) + TextManager.Instance.GetString(273);
	}


	
	public void OnClickRevengeButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		PVPDataManager.Instance.SetSelectPVPUserInfo(m_UserInfoData.m_UserInfoData);
		GameUIManager.Instance.m_PVPUI.ShowDetailUI();
	}
}