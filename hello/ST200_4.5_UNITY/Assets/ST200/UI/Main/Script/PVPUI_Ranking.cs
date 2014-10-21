using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PVPUI_Ranking : MonoBehaviour {

	public UILabel m_TitleLabel;
	public GameObject m_WorldRankBlackImage;
	public GameObject m_FriendRankBlackImage;
	public PVPUI_RankingDisplay m_RankDisplayer;
	public PVPUI_Rank_RewardDisplayer m_RewardDisplayer;

	void Awake()
	{
		m_TitleLabel.text = Constant.COLOR_SUBSHIP_SUBTITLE + TextManager.Instance.GetString(257);
	}

	public void ShowUI()
	{
		NGUITools.SetActive (gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive (gameObject, false);
	}

	public void InitUI()
	{
		ShowWorldRank();
	}

	public void ShowRankUI()
	{
		m_RankDisplayer.ShowUI();
		m_RewardDisplayer.RemoveUI();
	}
	public void ShowRewardUI()
	{
		m_RankDisplayer.RemoveUI();
		m_RewardDisplayer.ShowUI();

		m_RewardDisplayer.InitUI();
	}

	public void ShowWorldRank()
	{
		NGUITools.SetActive(m_WorldRankBlackImage.gameObject, false);
		NGUITools.SetActive(m_FriendRankBlackImage.gameObject, true);

		List<UserPVPRankInfoData> pvplist = new List<UserPVPRankInfoData>();
		for(int i = 0; i < 50; i++)
		{
			UserPVPRankInfoData newdata = new UserPVPRankInfoData();
			newdata.UserNickName = "world" + i.ToString();
			newdata.CharacterIndex = Random.Range(1,4);
			newdata.ShipIndex = Random.Range(1, 7);
			newdata.ShipLevel = Random.Range(1,10);
			newdata.LoseCount = Random.Range(1,100);
			newdata.WinCount = Random.Range(1,100);
			newdata.Rank = i + 1;
			newdata.UserID = "HI" + i.ToString();

			pvplist.Add(newdata);
		}
		m_RankDisplayer.InitRankList(pvplist);
	}

	public void ShowFriendRank()
	{
		NGUITools.SetActive(m_WorldRankBlackImage.gameObject, true);
		NGUITools.SetActive(m_FriendRankBlackImage.gameObject, false);

		List<UserPVPRankInfoData> pvplist = new List<UserPVPRankInfoData>();
		for(int i = 0; i < 50; i++)
		{
			UserPVPRankInfoData newdata = new UserPVPRankInfoData();
			newdata.UserNickName = "friend" + i.ToString();
			newdata.CharacterIndex = Random.Range(1,4);
			newdata.ShipIndex = Random.Range(1, 7);
			newdata.ShipLevel = Random.Range(1,10);
			newdata.LoseCount = Random.Range(1,100);
			newdata.WinCount = Random.Range(1,100);
			newdata.Rank = i + 1;
			newdata.UserID = "HI" + i.ToString();
			
			pvplist.Add(newdata);
		}
		m_RankDisplayer.InitRankList(pvplist);
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		GameUIManager.Instance.m_PVPUI.ShowPVPUI();
	}

	public void OnClickWorldRankButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		//temp init
		ShowWorldRank();
	}

	public void OnClickFriendRankButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		//temp init
		ShowFriendRank();
	}

	public void OnClickRewardButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ShowRewardUI();
	}

}
