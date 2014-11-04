using UnityEngine;
using System.Collections;

public class PVPUI_PVPList : MonoBehaviour {

	public UILabel m_TitleLabel;

	public PVPUI_RecommandTapUI m_RecommandUI;
	public GameObject m_RecommandTapBlackUI;
	public UILabel m_RecommandLabel;

	public PVPUI_FriendTapUI m_FriendUI;
	public GameObject m_FriendTapBlackUI;
	public UILabel m_FriendLabel;

	void Awake()
	{
		m_TitleLabel.text = Constant.COLOR_SUBSHIP_SUBTITLE + TextManager.Instance.GetString(255);
		m_RecommandLabel.text = TextManager.Instance.GetString(264);
		m_FriendLabel.text = TextManager.Instance.GetString(265);
	}

	public void InitUI(bool _showfriend)
	{
		if(!_showfriend)
		{
			ShowRecommandUI();
		}else
		{
			ShowFriendUI();
		}
	}

	public void UpdateUI()
	{
		//Debug.Log("WTF..?");
		m_RecommandUI.UpdateUI();
		m_FriendUI.UpdateUI();
	}

	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive(gameObject, false);
	}

	public void HideAll()
	{
		m_RecommandUI.RemoveUI();
		m_FriendUI.RemoveUI();
	}

	public void ShowRecommandUI()
	{
		m_RecommandUI.ShowUI();
		m_RecommandUI.InitUI();

		NGUITools.SetActive(m_RecommandTapBlackUI.gameObject, false);
		
		m_FriendUI.RemoveUI();
		NGUITools.SetActive(m_FriendTapBlackUI.gameObject, true);
	}

	public void ShowFriendUI()
	{
		m_FriendUI.ShowUI();
		m_FriendUI.InitFriendList();
		NGUITools.SetActive(m_FriendTapBlackUI.gameObject, false);

		m_RecommandUI.RemoveUI();
		NGUITools.SetActive(m_RecommandTapBlackUI.gameObject, true);
	}

	public void OnClickPVPRecommand()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ShowRecommandUI();
	}

	public void OnClickFriend()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		ShowFriendUI();
	}

	public bool OnEscapePress()
	{
		if(m_RecommandUI.OnEscapePress())
		{
			return true;
		}else if(m_FriendUI.OnEscapePress())
		{
			return true;
		}

		return false;
	}
}
