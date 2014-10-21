using UnityEngine;
using System.Collections;

public class MainUI_FreeChargeNoticeWindow : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UILabel m_DescriptionLabel;

	void Awake()
	{
		m_TitleLabel.text = Constant.COLOR_GOLD + TextManager.Instance.GetString(244);
		m_DescriptionLabel.text = Constant.COLOR_MAIN_SHIP_DESCRIPTION + TextManager.Instance.GetString (245);
	}

	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive (gameObject, false);
	}

	public void OnClickOkButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		RemoveUI();
	}
}
