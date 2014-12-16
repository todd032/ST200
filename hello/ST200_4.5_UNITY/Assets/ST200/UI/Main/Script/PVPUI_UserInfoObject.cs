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
	public UISprite m_AddFriendSprite;
	public GameObject m_RemoveFriendButton;
	public GameObject m_FixButton;
	public UILabel m_FixTimeLabel;
	public UISprite m_FlagSprite;

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
		m_RewardLabel.text = m_UserInfoData.RewardAmount.ToString();
		m_FlagSprite.spriteName = ImageResourceManager.Instance.GetFlagSpriteName(m_UserInfoData.Country);
		if(m_UserInfoData.RepairSecond > 0)
		{
			NGUITools.SetActive(m_FightButton.gameObject, false);
			NGUITools.SetActive(m_FixButton.gameObject, true);
			
			m_FixTimeLabel.text = TextManager.GetHM(m_UserInfoData.RepairSecond);
		}else
		{
			NGUITools.SetActive(m_FightButton.gameObject, true);
			NGUITools.SetActive(m_FixButton.gameObject, false);
		}

		if(PVPDataManager.Instance.IsInFriendList(m_UserInfoData.UserIndex))
		{
			m_AddFriendSprite.spriteName = "pvp_list_add_2";
			friend_addedflag = true;
			//Debug.Log("hi3");
		}else
		{
			m_AddFriendSprite.spriteName = "pvp_list_add";
			friend_addedflag = false;
			//Debug.Log("hi2");
		}

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

	bool friend_addedflag = false;
	public void OnClickAddFriendButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(!friend_addedflag)
		{
			m_AddFriendSprite.spriteName = "pvp_list_add_2";
			//Debug.Log("hi1");
			PVPDataManager.Instance.AddToFriend(m_UserInfoData);
			GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_PVP_FRIENDADD_SUCCESS,
			                                           new string[]{m_UserInfoData.UserNickName});
			friend_addedflag = true;
		}
	}

	public void OnClickRemoveFriendButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		PVPDataManager.Instance.RemoveFromFriend(m_UserInfoData);
		GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_PVP_FRIENDREMOVE_SUCCESS,
		                                           new string[]{m_UserInfoData.UserNickName});
	}

	public void OnClickFightButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		PVPDataManager.Instance.SetSelectPVPUserInfo(m_UserInfoData);
		GameUIManager.Instance.m_PVPUI.ShowDetailUI();
	}
}
