using UnityEngine;
using System.Collections;

public class PVPUI_History_UserInfoObject : MonoBehaviour {
	
	public UISprite m_CharacterSprite;
	public UISprite m_ShipSprite;
	public UILabel m_NickNameLabel;
	public UILabel m_ShipLevelLabel;
	public UILabel m_ResultLabel;
	
	public GameObject m_RevengeButton;
	public GameObject m_FixButton;
	public UILabel m_FixTimeLabel;
	
	public UserInfoData m_UserInfoData;
	public void Init(UserInfoData _userinfodata, bool _win)
	{
		m_UserInfoData = _userinfodata;
		
		m_NickNameLabel.text = Constant.COLOR_WHITE + _userinfodata.UserNickName;
		m_ShipLevelLabel.text = Constant.COLOR_GOLD	+ "Lv. " + m_UserInfoData.ShipLevel;
		
		m_FixTimeLabel.text = Constant.COLOR_BLACK + "TIMER";
		
		m_CharacterSprite.spriteName = ImageResourceManager.Instance.GetMainUICharacterImageName(m_UserInfoData.CharacterIndex);
		m_ShipSprite.spriteName = ImageResourceManager.Instance.GetMainUIShipImageName(m_UserInfoData.ShipIndex);

		if(_win)
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
	}


	
	public void OnClickRevengeButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		PVPDataManager.Instance.SetSelectPVPUserInfo(m_UserInfoData);
		GameUIManager.Instance.m_PVPUI.ShowDetailUI();
	}
}