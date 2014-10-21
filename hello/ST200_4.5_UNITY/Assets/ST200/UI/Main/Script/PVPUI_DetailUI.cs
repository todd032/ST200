using UnityEngine;
using System.Collections;

public class PVPUI_DetailUI : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UILabel m_RewardLabel;
	public UILabel m_FightCostLabel;

	public PVPUI_Detail_PlayerUI m_PlayerUI;
	public PVPUI_Detail_OppUI m_OppUI;

	void Awake()
	{
		m_TitleLabel.text = Constant.COLOR_MAIN_SUBTITLE + TextManager.Instance.GetString(260);
	}

	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive(gameObject, false);
	}

	public void InitUI()
	{
		m_PlayerUI.InitUI();
		m_OppUI.InitUI(PVPDataManager.Instance.m_SelectedPVPUserInfo);
	}

	public void OnClickFightButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		Managers.UserData.SelectedGameType = Constant.ST200_GAMEMODE_PVP;
		Application.LoadLevel(Constant.SCENE_GameMainLoadingScene);
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		GameUIManager.Instance.m_PVPUI.ShowPVPUI();
	}
}
