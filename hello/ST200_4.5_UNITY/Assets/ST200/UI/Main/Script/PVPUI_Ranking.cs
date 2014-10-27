using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PVPUI_Ranking : MonoBehaviour {

	public UILabel m_TitleLabel;
	public GameObject m_WorldRankBlackImage;
	public UILabel m_WorldRankingLabel;
	public GameObject m_FriendRankBlackImage;
	public UILabel m_FriendRankingLabel;
	public PVPUI_RankingDisplay m_RankDisplayer;
	public PVPUI_Rank_RewardDisplayer m_RewardDisplayer;

	void Awake()
	{
		m_TitleLabel.text = Constant.COLOR_SUBSHIP_SUBTITLE + TextManager.Instance.GetString(257);
		m_WorldRankingLabel.text = TextManager.Instance.GetString(266);
		m_FriendRankingLabel.text = TextManager.Instance.GetString(267);
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

	protected bool m_WorldRankInitFlag = false;
	public void ShowWorldRank()
	{
		NGUITools.SetActive(m_WorldRankBlackImage.gameObject, false);
		NGUITools.SetActive(m_FriendRankBlackImage.gameObject, true);

		if(!m_WorldRankInitFlag)
		{
			Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
			{
				if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
				{	
					m_RankDisplayer.InitRankList(PVPDataManager.Instance.m_WorldRankList);
				}else
				{
					
				}
			};
			Managers.DataStream.PVP_Request_WorldRank();
		}
		m_WorldRankInitFlag = true;
		m_RankDisplayer.InitRankList (PVPDataManager.Instance.m_WorldRankList);
	}

	protected bool m_FriendRankInitFlag = false;
	public void ShowFriendRank()
	{
		NGUITools.SetActive(m_WorldRankBlackImage.gameObject, true);
		NGUITools.SetActive(m_FriendRankBlackImage.gameObject, false);

		if(!m_FriendRankInitFlag)
		{
			Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
			{
				if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
				{	
					m_RankDisplayer.InitRankList(PVPDataManager.Instance.m_FriendRankList);
				}else
				{
					
				}
			};
			Managers.DataStream.PVP_Request_FriendRank();
		}
		m_FriendRankInitFlag = true;
		m_RankDisplayer.InitRankList (PVPDataManager.Instance.m_FriendRankList);
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
