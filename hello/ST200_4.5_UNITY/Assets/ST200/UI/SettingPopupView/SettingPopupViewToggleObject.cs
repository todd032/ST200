using UnityEngine;
using System.Collections;

public class SettingPopupViewToggleObject : MonoBehaviour {

	public UILabel m_OptionNameLabel;
	public UISprite m_CheckSprite;

	public void Init(string _name, bool _option)
	{
		m_OptionNameLabel.text = _name;
		SetOption(_option);
	}

	public void SetOption(bool _option)
	{
		NGUITools.SetActive(m_CheckSprite.gameObject, _option);
	}
}
