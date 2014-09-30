using UnityEngine;
using System.Collections;

public class SubShipDictionary : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UIScrollView m_ScrollView;
	void Start()
	{
		m_TitleLabel.text = Constant.COLOR_STORE_TITLE + TextManager.Instance.GetString(232);
	}

	public void ShowUI()
	{
		NGUITools.SetActive (gameObject, true);
		m_ScrollView.ResetPosition();
	}

	public void HideUI()
	{
		NGUITools.SetActive (gameObject, false);
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			OnClickCloseButton();
			return true;
		}
		return false;
   }

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		HideUI();
	}
}
