using UnityEngine;
using System.Collections;

public class CrossShockInfo : MonoBehaviour {

	public CrossShockAppInfo m_AppInfo;
	public UITexture m_IconTexture;
	public UILabel m_AppNameLabel;
	public UILabel m_AppDescriptionLabel;
	public UILabel m_CostLabel;
	public GameObject m_ButtonGameObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(CrossShockAppInfo _info)
	{
		m_AppInfo = _info;
		ImageResourceManager.Instance.AddQueue(_info.AppIcon, m_IconTexture);
		m_AppNameLabel.text = _info.AppName;
		m_AppDescriptionLabel.text = _info.AppDescription;
		m_CostLabel.text = _info.Reward;
	}

	void OnClickButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		CrossShockManager.Instance.GetClick(m_AppInfo);
	}
}
