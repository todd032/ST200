using UnityEngine;
using System.Collections;

public class GachaAnimation : MonoBehaviour {

	public SubShipInfoObject m_SubshipInfoObject;

	public UILabel m_OkLabel;

	public GameObject m_UpgradeGameObject;
	public UILabel m_UpgradeLabel;
	public UITweener m_Light;

	void Start()
	{
		m_OkLabel.text = TextManager.Instance.GetString(41);
		m_UpgradeLabel.text = TextManager.Instance.GetString (234);
	}

	public void ShowUI()
	{
		NGUITools.SetActive (gameObject, true);
		m_Light.ResetToBeginning();
		m_Light.Play(true);
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

	public void PlayAnimation(int _index, bool _isupgrade)
	{
		ShowUI();
		NGUITools.SetActive(m_UpgradeGameObject.gameObject, _isupgrade);
		m_SubshipInfoObject.Init(null, _index);
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		HideUI();
	}
}
