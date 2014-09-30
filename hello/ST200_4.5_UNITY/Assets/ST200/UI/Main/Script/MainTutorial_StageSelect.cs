using UnityEngine;
using System.Collections;

public class MainTutorial_StageSelect : MonoBehaviour {

	public UILabel m_Label;


	void Awake()
	{
		m_Label.text = TextManager.Instance.GetString(216);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameUIManager.Instance.m_StageSelectUI.m_ScrollView.ResetPosition();
	}
}
