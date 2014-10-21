using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PVPDataManager : MonoBehaviour {

	public List<UserInfoData> m_PVPUserInfoList = new List<UserInfoData>();
	public UserInfoData m_SelectedPVPUserInfo;
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

	public void SetSelectPVPUserInfo(UserInfoData _info)
	{
		m_SelectedPVPUserInfo = _info;
	}

	public void SetUserInfoData(UserInfoData _data)
	{
		for(int i = 0; i < m_PVPUserInfoList.Count; i++)
		{
			UserInfoData infodata = m_PVPUserInfoList[i];
			if(infodata.UserID == _data.UserID)
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
		data.ShipLevel = 1;
		data.TacticIndex = 1;
		data.UserID = _userid;
		data.UserNickName = "FRIENDO" + Random.Range(0, 100).ToString();
		data.SubShipIndexList = new int[]{Random.Range(1,11),Random.Range(1,11),Random.Range(1,11),Random.Range(1,11)};
		data.SubShipLevelList = new int[]{Random.Range(1,5),Random.Range(1,5),Random.Range(1,5),Random.Range(1,5)};
		SetUserInfoData(data);
		return data;

		for(int i = 0; i < m_PVPUserInfoList.Count; i++)
		{
			UserInfoData infodata = m_PVPUserInfoList[i];
			if(infodata.UserID == _userid)
			{
				return infodata;
			}
		}
		
		return new UserInfoData();
	}
}
