using UnityEngine;
using System.Collections;

public class ExplainUI : MonoBehaviour {

	protected float m_Timer = 0f;
	public float m_AutoChangeTimer = 10f;
	public float m_TextFlowSpeed = 100f;

	public GameObject m_EnglishLabel;
	public GameObject m_KorLabel;

	// Use this for initialization
	void Start () {
		if(Managers.LanguageCode == PFPFileManager.LANGUAGE_KOR)
		{
			m_KorLabel.gameObject.SetActive(true);
			m_EnglishLabel.gameObject.SetActive(false);
		}else
		{
			m_KorLabel.gameObject.SetActive(false);
			m_EnglishLabel.gameObject.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			ChangeScene();
		}

	}

	void FixedUpdate()
	{
		Process();
	}

	public void Process()
	{
		m_Timer += Time.deltaTime;
		m_EnglishLabel.transform.localPosition += Vector3.up * Time.deltaTime * m_TextFlowSpeed;
		m_KorLabel.transform.localPosition += Vector3.up * Time.deltaTime * m_TextFlowSpeed;
		if(m_Timer > m_AutoChangeTimer)
		{
			ChangeScene();
		}
	}

	public void ChangeScene()
	{
		Application.LoadLevel(Constant.SCENE_Ranking);
	}
}
