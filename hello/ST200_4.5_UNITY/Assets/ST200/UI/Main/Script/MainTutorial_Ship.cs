using UnityEngine;
using System.Collections;

public class MainTutorial_Ship : MonoBehaviour {

	public GameObject m_Explain1;
	public GameObject m_Explain2;
	public GameObject m_Explain3;

	public UILabel m_ExplainLabel1;
	public UILabel m_ExplainLabel2;
	public UILabel m_ExplainLabel3;

	void Awake()
	{
		m_ExplainLabel1.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(202);
		m_ExplainLabel2.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(203);
		m_ExplainLabel3.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(194);
		m_Explain1.gameObject.SetActive(true);
		m_Explain2.gameObject.SetActive (false);
		m_Explain3.gameObject.SetActive (false);
	}

	public void OnClickExplain()
	{
		m_Explain1.gameObject.SetActive(false);
		m_Explain2.gameObject.SetActive (true);
	}

	public void OnClickExplain2()
	{
		m_Explain2.gameObject.SetActive(false);
		m_Explain3.gameObject.SetActive (true);
	}

}
