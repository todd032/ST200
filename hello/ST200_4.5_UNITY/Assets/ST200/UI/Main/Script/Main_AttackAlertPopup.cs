using UnityEngine;
using System.Collections;

public class Main_AttackAlertPopup : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UILabel m_DescriptionLabel1;
	public UILabel m_DescriptionLabel2;
	public UILabel m_TimerLabel;
	public UILabel m_OkLabel;

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
		m_OkLabel.text = TextManager.Instance.GetString(147);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitUI(UserHistoryData _userinfodata)
	{
		m_UserInfoData = _userinfodata;
		
		m_NickNameLabel.text = Constant.COLOR_WHITE + _userinfodata.m_UserInfoData.UserNickName;
		m_ShipLabel.text = Constant.COLOR_GOLD	+ Managers.GameBalanceData.GetShipDescriptionInfo(m_UserInfoData.m_UserInfoData.ShipIndex).ShipName + " Lv. " + m_UserInfoData.m_UserInfoData.ShipLevel;
		
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

	public void OnClickOkButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		RemoveUI();
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			OnClickOkButton();
			return true;
		}
		return false;

	}
}
