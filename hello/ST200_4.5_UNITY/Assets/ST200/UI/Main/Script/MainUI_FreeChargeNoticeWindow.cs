using UnityEngine;
using System.Collections;

public class MainUI_FreeChargeNoticeWindow : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UILabel m_DescriptionLabel;
	public UILabel m_DescriptionLabel2;

	void Awake()
	{
		m_TitleLabel.text = TextManager.Instance.GetString(244);
		m_DescriptionLabel.text = TextManager.Instance.GetString (245);
		m_DescriptionLabel2.text = TextManager.Instance.GetString(302);
	}

	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive (gameObject, false);
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			OnClickOkButton();
			return true;
		}
		return false;
	}

	public void OnClickOkButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		RemoveUI();
	}

	public void OnClickTnkButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		TnkAd.Plugin.Instance.showAdList(TextManager.Instance.GetString(303));
	}

	public void OnClickTapjoyButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		#if UNITY_ANDROID && !UNITY_EDITOR
		//TnkAd.Plugin.Instance.showAdList("무료 금괴 받기");
		TapjoyPlugin.ShowOffers();
		#endif
	}
}
