using UnityEngine;
using System.Collections;

public class PVPUI : MonoBehaviour {

	public PVPUI_PVPList m_PVPUI;
	public PVPUI_Ranking m_PVPRankingUI;
	public PVPUI_History m_HistoryUI;
	public PVPUI_DetailUI m_DetailUI;

	public PVPUI_Menu_Button m_ListButton;
	public PVPUI_Menu_Button m_RankingButton;
	public PVPUI_Menu_Button m_HistoryButton;

	public void Init()
	{
		ShowPVPUI(false);

	}

	public void UpdateUI()
	{
		//Debug.Log("WTF..?");
		m_PVPUI.UpdateUI();
	}

	public void ShowPVPUI(bool _showfriend)
	{
		m_PVPUI.ShowUI();
		m_PVPUI.InitUI(_showfriend);

		m_PVPRankingUI.RemoveUI();

		m_HistoryUI.RemoveUI();

		m_DetailUI.RemoveUI();

		m_ListButton.SetSelected(true);
		m_RankingButton.SetSelected(false);
		m_HistoryButton.SetSelected(false);
	}

	public void ShowRankingUI()
	{
		m_PVPUI.RemoveUI();
		
		m_PVPRankingUI.ShowUI();
		m_PVPRankingUI.InitUI();

		m_HistoryUI.RemoveUI();

		m_DetailUI.RemoveUI();

		m_ListButton.SetSelected(false);
		m_RankingButton.SetSelected(true);
		m_HistoryButton.SetSelected(false);
	}

	public void ShowHistoryUI(bool _attack)
	{
		m_PVPUI.RemoveUI();
		
		m_PVPRankingUI.RemoveUI();

		m_HistoryUI.ShowUI();
		m_HistoryUI.InitUI(_attack);

		m_DetailUI.RemoveUI();

		m_ListButton.SetSelected(false);
		m_RankingButton.SetSelected(false);
		m_HistoryButton.SetSelected(true);
	}

	public void ShowDetailUI()
	{
		m_PVPUI.RemoveUI();
		m_HistoryUI.RemoveUI();
		m_DetailUI.ShowUI();
		m_DetailUI.InitUI();

		m_ListButton.SetSelected(false);
		m_RankingButton.SetSelected(false);
		m_HistoryButton.SetSelected(false);
	}

	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive(gameObject, false);
	}

	public void OnClickMainButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		GameUIManager.Instance.SwitchToGameMainUI();
	}

	public void OnClickPVPListButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ShowPVPUI(false);
	}
	public void OnClickRankButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ShowRankingUI();
	}
	public void OnClickHistoryButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ShowHistoryUI(true);
	}
	public void OnClickKakaoInviteButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ST200KakaoLink.g_Instance.InitLink(TextManager.Instance.GetString(246), TextManager.Instance.GetReplaceString(247, Managers.UserData.UserNickName),
		                                   TextManager.Instance.GetString(250));
		ST200KakaoLink.g_Instance.SendKakaoLinkMessage();
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{

		}
		
		return false;
	}


}
