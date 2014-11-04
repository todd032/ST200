using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PVPDataManager : MonoBehaviour {

	public int MyWinCount = 0;
	public int MyLoseCount = 0;

	public List<UserInfoData> m_PVPRecommendInfoList = new List<UserInfoData>();
	public List<UserInfoData> m_FriendInfoList = new List<UserInfoData>();
	public List<UserInfoData> m_FriendSearchInfoList = new List<UserInfoData>();
	public List<UserInfoData> m_PVPUserInfoList = new List<UserInfoData>();
	public UserInfoData m_SelectedPVPUserInfo;

	public List<UserPVPRankInfoData> m_WorldRankList = new List<UserPVPRankInfoData>();
	public List<UserPVPRankInfoData> m_FriendRankList = new List<UserPVPRankInfoData>();
	public List<PVPRewardData> m_RewardList = new List<PVPRewardData>();

	public List<UserHistoryData> m_HistoryAttackList = new List<UserHistoryData>();
	public List<UserHistoryData> m_HistoryDefendList = new List<UserHistoryData>();

	private static PVPDataManager instance;
	public static PVPDataManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(PVPDataManager)) as PVPDataManager;
			}
			return instance;
		}
	}

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}

	public void SetPVPRecommendList(List<UserInfoData> _list)
	{
		m_PVPRecommendInfoList = _list;
	}

	public void AddPVPFriendList(UserInfoData _data)
	{
		if(!m_FriendInfoList.Contains(_data))
		{
			m_FriendInfoList.Add(_data);
		}
	}

	public void RemovePVPFriendList(UserInfoData _data)
	{
		if(m_FriendInfoList.Contains(_data))
		{
			m_FriendInfoList.Remove(_data);
		}
	}

	public void AddFriendSearchList(UserInfoData _data)
	{
		if(!m_FriendSearchInfoList.Contains(_data))
		{
			m_FriendSearchInfoList.Add(_data);
		}
	}

	public void RemoveFriendSearchList(UserInfoData _data)
	{
		if(m_FriendSearchInfoList.Contains(_data))
		{
			m_FriendSearchInfoList.Remove(_data);
		}
	}

	public void SetSelectPVPUserInfo(UserInfoData _info)
	{
		m_SelectedPVPUserInfo = _info;
		//Debug.Log("show me the money: " + _info.SubShipIndexList[0].ToString() + _info.SubShipIndexList[1].ToString());
	}

	public void SetUserInfoData(UserInfoData _data)
	{
		for(int i = 0; i < m_PVPUserInfoList.Count; i++)
		{
			UserInfoData infodata = m_PVPUserInfoList[i];
			if(infodata.UserIndex == _data.UserIndex)
			{
				m_PVPUserInfoList[i] = _data;
				return;
			}
		}

		m_PVPUserInfoList.Add(_data);
	}

	public UserInfoData GetUserInfoDataByNickName(string _nickname)
	{
		for(int i = 0; i < m_PVPUserInfoList.Count; i++)
		{
			UserInfoData infodata = m_PVPUserInfoList[i];
			if(infodata.UserNickName == _nickname)
			{
				return infodata;
			}
		}

		return new UserInfoData();
	}

	public UserInfoData GetUserInfoDataById(string _userid)
	{
		UserInfoData data = new UserInfoData();
		data.CharacterIndex = 1;
		data.ShipIndex = Random.Range(1, 8);
		data.ShipLevel = Random.Range (1,11);
		data.TacticIndex = 1;
		data.UserIndex = 1;
		data.UserNickName = "FRIENDO" + Random.Range(0, 100).ToString();
		data.SubShipIndexList = new int[]{Random.Range(1,11),Random.Range(1,11),Random.Range(1,11),Random.Range(1,11)};
		data.SubShipLevelList = new int[]{Random.Range(1,5),Random.Range(1,5),Random.Range(1,5),Random.Range(1,5)};
		SetUserInfoData(data);
		return data;

		for(int i = 0; i < m_PVPUserInfoList.Count; i++)
		{
			UserInfoData infodata = m_PVPUserInfoList[i];
			if(infodata.UserIndex == 1)
			{
				return infodata;
			}
		}
		
		return new UserInfoData();
	}

	public void AddToFriend(UserInfoData _data)
	{
		Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
		{
			if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
			{	
				AddPVPFriendList(_data);
				RemoveFriendSearchList(_data);

				if(GameUIManager.Instance != null && GameUIManager.Instance.m_PVPUI.gameObject.activeSelf)
				{
					GameUIManager.Instance.m_PVPUI.UpdateUI();
					//Debug.Log("WTF..?");
				}
			}else
			{

			}
		};
		Managers.DataStream.PVP_Request_FriendAdd(_data.UserIndex);
	}

	public void RemoveFromFriend(UserInfoData _data)
	{
		Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
		{
			if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
			{	
				RemovePVPFriendList(_data);
				if(GameUIManager.Instance != null)
				{
					GameUIManager.Instance.m_PVPUI.UpdateUI();
				}
			}else
			{

			}
		};
		Managers.DataStream.PVP_Request_FriendRemove(_data.UserIndex);
	}

	public bool IsInFriendList(int _userindex)
	{
		for(int i = 0; i < m_FriendInfoList.Count; i++)
		{
			if(m_FriendInfoList[i].UserIndex == _userindex)
			{
				return true;
			}
		}

		return false;
	}
}
