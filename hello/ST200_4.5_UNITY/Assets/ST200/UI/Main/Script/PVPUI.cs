using UnityEngine;
using System.Collections;

public class PVPUI : MonoBehaviour {

	public PVPUI_PVPList m_PVPUI;
	public PVPUI_Ranking m_PVPRankingUI;
	public PVPUI_History m_HistoryUI;
	public PVPUI_DetailUI m_DetailUI;

	public void Init()
	{
		ShowPVPUI();

	}

	public void ShowPVPUI()
	{
		m_PVPUI.ShowUI();
		m_PVPUI.InitUI();

		m_PVPRankingUI.RemoveUI();

		m_HistoryUI.RemoveUI();

		m_DetailUI.RemoveUI();

	}

	public void ShowRankingUI()
	{
		m_PVPUI.RemoveUI();
		
		m_PVPRankingUI.ShowUI();
		m_PVPRankingUI.InitUI();

		m_HistoryUI.RemoveUI();

		m_DetailUI.RemoveUI();

	}

	public void ShowHistoryUI()
	{
		m_PVPUI.RemoveUI();
		
		m_PVPRankingUI.RemoveUI();

		m_HistoryUI.ShowUI();
		m_HistoryUI.InitUI();

		m_DetailUI.RemoveUI();

	}

	public void ShowDetailUI()
	{
		m_PVPUI.RemoveUI();
		m_HistoryUI.RemoveUI();
		m_DetailUI.ShowUI();
		m_DetailUI.InitUI();
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
		ShowPVPUI();
	}
	public void OnClickRankButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ShowRankingUI();
	}
	public void OnClickHistoryButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ShowHistoryUI();
	}
	public void OnClickKakaoInviteButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ST200KakaoLink.g_Instance.InitLink(TextManager.Instance.GetString(246), TextManager.Instance.GetString (247),
		                                   TextManager.Instance.GetString(250));
		ST200KakaoLink.g_Instance.SendKakaoLinkMessage();
	}
}
