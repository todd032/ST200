using UnityEngine;
using System.Collections;

public class MainTutorial_SubShip : MonoBehaviour {

	public GameObject m_Explain1;
	public GameObject m_Explain2;
	public GameObject m_Explain3;
	public GameObject m_Explain4;
	public UILabel m_ExplainLabel1;
	public UILabel m_ExplainLabel3;
	public UILabel m_ExplainLabel4;
	public SubShipScroller m_Scroller;
	void Awake()
	{
		m_ExplainLabel1.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(236);
		m_ExplainLabel3.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(204);
		m_ExplainLabel4.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(205);
		m_Explain1.gameObject.SetActive(true);
		m_Explain2.gameObject.SetActive(false);
		m_Explain3.gameObject.SetActive(false);
		m_Explain4.gameObject.SetActive(false);
	}


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(m_Explain3.gameObject.activeSelf && m_Scroller.m_DestScrollPointer >= 1f)
		{
			m_Explain3.gameObject.SetActive (false);
			m_Explain4.gameObject.SetActive (true);
		}
	}

	public void OnClickDictionary()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_GameReady,false);
		GameUIManager.Instance.m_MainUI.m_SubShipSelectUI.OnClickDictionaryClick();
		m_Explain1.gameObject.SetActive (false);
		m_Explain2.gameObject.SetActive (true);
	}

	public void OnClickDictionaryClose()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_GameReady,false);
		GameUIManager.Instance.m_MainUI.m_SubShipSelectUI.m_SubShipDictionary.OnClickCloseButton();
		m_Explain2.gameObject.SetActive (false);
		m_Explain3.gameObject.SetActive (true);
	}
}
