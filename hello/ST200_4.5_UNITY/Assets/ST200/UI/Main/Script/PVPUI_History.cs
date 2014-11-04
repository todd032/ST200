using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PVPUI_History : MonoBehaviour {

	public UILabel m_TitleLabe;
	public UILabel m_AttackLable;
	public GameObject m_AttackBlackObject;
	public UILabel m_DefendLabel;
	public GameObject m_DefendBlackObject;
	public PVPUI_History_Displayer m_Displayer;

	void Awake()
	{
		m_TitleLabe.text = Constant.COLOR_MAIN_SUBTITLE + TextManager.Instance.GetString(261);
		m_AttackLable.text = TextManager.Instance.GetString(268);
		m_DefendLabel.text = TextManager.Instance.GetString(269);
	}

	public void ShowUI()
	{
		NGUITools.SetActive (gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive (gameObject, false);
	}

	public void InitUI(bool _attack)
	{
		if(_attack)
		{
			ShowAttackHistory();
		}else
		{
			ShowDefendHistory();
		}
	}

	protected bool m_AttackInit = false;
	public void ShowAttackHistory()
	{
		NGUITools.SetActive(m_AttackBlackObject.gameObject, false);
		NGUITools.SetActive(m_DefendBlackObject.gameObject, true);

		if(!m_AttackInit)
		{
			Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
			{
				if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
				{	
					m_Displayer.InitList(PVPDataManager.Instance.m_HistoryAttackList);
				}else
				{
					
				}
			};
			Managers.DataStream.PVP_Request_History(0, Managers.UserData.GetUserMaxClearStage());
		}
		m_AttackInit = true;
		m_Displayer.InitList(PVPDataManager.Instance.m_HistoryAttackList);
	}

	protected bool m_DefendInit = false;
	public void ShowDefendHistory()
	{
		NGUITools.SetActive(m_AttackBlackObject.gameObject, true);
		NGUITools.SetActive(m_DefendBlackObject.gameObject, false);

		if(!m_DefendInit)
		{
			Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
			{
				if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
				{	
					m_Displayer.InitList(PVPDataManager.Instance.m_HistoryDefendList);
				}else
				{
					
				}
			};
			Managers.DataStream.PVP_Request_History(1, Managers.UserData.GetUserMaxClearStage());
		}
		m_DefendInit = true;
		m_Displayer.InitList(PVPDataManager.Instance.m_HistoryDefendList);
	}
	                          
	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		GameUIManager.Instance.m_PVPUI.ShowPVPUI(false);
	}

	public void OnClickAttackHistory()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ShowAttackHistory();
	}

	public void OnClickDefendHistory()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ShowDefendHistory();
	}
}
