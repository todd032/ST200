using UnityEngine;
using System.Collections;

public class PVPUI_RecommandTapUI : MonoBehaviour {
		
	public PVPUI_UserInfoObject m_FirstRecommandUserInfo;
	public PVPUI_UserInfoObject m_SecondRecommandUserInfo;
	public PVPUI_UserInfoObject m_ThirdRecommandUserInfo;

	public void InitUI()
	{
		m_FirstRecommandUserInfo.SetAsRecommend();
		m_SecondRecommandUserInfo.SetAsRecommend();
		m_ThirdRecommandUserInfo.SetAsRecommend();
	}

	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive(gameObject, false);
	}
}
