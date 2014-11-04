using UnityEngine;
using System.Collections;

public class PVPUI_RecommandTapUI : MonoBehaviour {
		
	public GameObject m_FirstObject;
	public GameObject m_SecondObject;
	public GameObject m_ThirdObject;

	public PVPUI_UserInfoObject m_FirstRecommandUserInfo;
	public PVPUI_UserInfoObject m_SecondRecommandUserInfo;
	public PVPUI_UserInfoObject m_ThirdRecommandUserInfo;

	bool initflag = false;
	public void InitUI()
	{
		//if(!initflag)
		//{
		//	SetUserInfo(false);
		//	Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
		//	{
		//		if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
		//		{					
		//			SetUserInfo(true);
		//			m_FirstRecommandUserInfo.Init(PVPDataManager.Instance.m_PVPRecommendInfoList[0]);
		//			m_SecondRecommandUserInfo.Init(PVPDataManager.Instance.m_PVPRecommendInfoList[1]);
		//			m_ThirdRecommandUserInfo.Init(PVPDataManager.Instance.m_PVPRecommendInfoList[2]);
		//			
		//			m_FirstRecommandUserInfo.SetAsRecommend();
		//			m_SecondRecommandUserInfo.SetAsRecommend();
		//			m_ThirdRecommandUserInfo.SetAsRecommend();
		//		}else
		//		{
		//			Managers.DataStream.PVP_Request_Recommend(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage());
		//		}
		//	};
		//	Managers.DataStream.PVP_Request_Recommend(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage());
		//}
		//
		//initflag = true;		
		if(PVPDataManager.Instance.m_PVPRecommendInfoList.Count > 0)
		{
			m_FirstRecommandUserInfo.Init(PVPDataManager.Instance.m_PVPRecommendInfoList[0]);
		}

		if(PVPDataManager.Instance.m_PVPRecommendInfoList.Count > 1)
		{
			NGUITools.SetActive(m_SecondObject.gameObject, true);
			m_SecondRecommandUserInfo.Init(PVPDataManager.Instance.m_PVPRecommendInfoList[1]);		
		}else
		{
			NGUITools.SetActive(m_SecondObject.gameObject, false);
		}

		if(PVPDataManager.Instance.m_PVPRecommendInfoList.Count > 2)
		{
			NGUITools.SetActive(m_ThirdObject.gameObject, true);
			m_ThirdRecommandUserInfo.Init(PVPDataManager.Instance.m_PVPRecommendInfoList[2]);
		}else
		{
			NGUITools.SetActive(m_ThirdObject.gameObject, false);
		}
		
		m_FirstRecommandUserInfo.SetAsRecommend();
		m_SecondRecommandUserInfo.SetAsRecommend();
		m_ThirdRecommandUserInfo.SetAsRecommend();
	}

	public void UpdateUI()
	{
		InitUI();
	}

	protected void SetUserInfo(bool _flag)
	{
		NGUITools.SetActive(m_FirstRecommandUserInfo.gameObject, _flag);
		NGUITools.SetActive(m_SecondRecommandUserInfo.gameObject, _flag);
		NGUITools.SetActive(m_ThirdRecommandUserInfo.gameObject, _flag);
	}

	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive(gameObject, false);
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			
		}
		
		return false;
	}
}
