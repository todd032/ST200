using UnityEngine;
using System.Collections;

public class MainTutorial_REady : MonoBehaviour {

	public GameObject m_ReadyGameObject1;
	public GameObject m_ReadyGameObject2;
	public UILabel m_UILabel1;
	public UILabel m_UILabel2;

	void Awake()
	{
		m_UILabel1.text = TextManager.Instance.GetString (216);
		m_UILabel2.text = TextManager.Instance.GetString (216);
		ShowReadyObject1();
	}

	public void ShowReadyObject1()
	{
		NGUITools.SetActive(m_ReadyGameObject1.gameObject ,true);
		NGUITools.SetActive(m_ReadyGameObject2.gameObject ,false);
	}

	public void ShowReadyObject2()
	{
		NGUITools.SetActive(m_ReadyGameObject1.gameObject ,false);
		NGUITools.SetActive(m_ReadyGameObject2.gameObject ,true);
	}
}
