using UnityEngine;
using System.Collections;

public class MainTutorial_StageSelect : MonoBehaviour {

	public UILabel m_Label;
	public StageSelectUI_Object m_StageSelectUIObject;

	void Awake()
	{
		m_Label.text = TextManager.Instance.GetString(216);
		m_StageSelectUIObject.InitUI(GameUIManager.Instance.m_StageSelectUI, Managers.GameBalanceData.GetStageData(1));
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameUIManager.Instance.m_StageSelectUI.SetScrollPosition(0f);
	}
}
