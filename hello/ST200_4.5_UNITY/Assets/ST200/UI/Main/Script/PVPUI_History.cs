using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PVPUI_History : MonoBehaviour {

	public UILabel m_TitleLabe;
	public PVPUI_History_Displayer m_Displayer;

	void Awake()
	{
		m_TitleLabe.text = Constant.COLOR_MAIN_SUBTITLE + TextManager.Instance.GetString(261);
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
		List<UserInfoData> templist = new List<UserInfoData>();
		for(int i = 0; i < 20; i++)
		{
			UserInfoData newdata = PVPDataManager.Instance.GetUserInfoDataById("history" + i.ToString());
			templist.Add(newdata);
		}

		m_Displayer.InitList(templist);
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		GameUIManager.Instance.m_PVPUI.ShowPVPUI();
	}
}
