using UnityEngine;
using System.Collections;

public class PVPUI_UserInfoObject : MonoBehaviour {

	public UISprite m_CharacterSprite;
	public UISprite m_ShipSprite;
	public UILabel m_NickNameLabel;
	public UILabel m_ShipLevelLabel;
	public UILabel m_RewardLabel;

	public GameObject m_FightButton;
	public GameObject m_AddFriendButton;
	public GameObject m_RemoveFriendButton;
	public GameObject m_FixButton;
	public UILabel m_FixTimeLabel;

	public UserInfoData m_UserInfoData;
	public void Init(UserInfoData _userinfodata)
	{
		m_UserInfoData = _userinfodata;

		m_NickNameLabel.text = Constant.COLOR_WHITE + _userinfodata.UserNickName;
		m_ShipLevelLabel.text = Constant.COLOR_GOLD	+ "Lv. " + m_UserInfoData.ShipLevel;
		m_RewardLabel.text = Constant.COLOR_WHITE + _userinfodata.RewardAmount.ToString();

		m_FixTimeLabel.text = Constant.COLOR_BLACK + "TIMER";

		m_CharacterSprite.spriteName = ImageResourceManager.Instance.GetWorldRankingCharacterImage(m_UserInfoData.CharacterIndex.ToString());
		m_ShipSprite.spriteName = ImageResourceManager.Instance.GetMainUIShipImageName(m_UserInfoData.ShipIndex);
	}

	public void SetAsRecommend()
	{
		NGUITools.SetActive(m_FightButton.gameObject, true);
		NGUITools.SetActive(m_AddFriendButton.gameObject, true);
		NGUITools.SetActive(m_RemoveFriendButton.gameObject, false);
		NGUITools.SetActive(m_FixButton.gameObject, false);
	}

	public void SetAsFriend()
	{
		NGUITools.SetActive(m_FightButton.gameObject, true);
		NGUITools.SetActive(m_AddFriendButton.gameObject, false);
		NGUITools.SetActive(m_RemoveFriendButton.gameObject, true);
		NGUITools.SetActive(m_FixButton.gameObject, false);
	}

	public void SetAsFriendSearch()
	{
		NGUITools.SetActive(m_FightButton.gameObject, false);
		NGUITools.SetActive(m_AddFriendButton.gameObject, true);
		NGUITools.SetActive(m_RemoveFriendButton.gameObject, false);
		NGUITools.SetActive(m_FixButton.gameObject, false);
	}

	public void OnClickAddFriendButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
	}

	public void OnClickRemoveFriendButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
	}

	public void OnClickFightButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		PVPDataManager.Instance.SetSelectPVPUserInfo(m_UserInfoData);
		GameUIManager.Instance.m_PVPUI.ShowDetailUI();
	}
}
