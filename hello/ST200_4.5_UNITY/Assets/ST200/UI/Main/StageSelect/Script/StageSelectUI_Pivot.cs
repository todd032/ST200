using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageSelectUI_Pivot : MonoBehaviour {

	public StageSelectUI m_StageSelectUI;
	public List<StageSelectUI_Object> m_StageSelectUIObjectList = new List<StageSelectUI_Object>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(int _startindex)
	{
		for(int i = 0; i < m_StageSelectUIObjectList.Count; i++)
		{
			m_StageSelectUIObjectList[i].InitUI(m_StageSelectUI, Managers.GameBalanceData.GetStageData(_startindex + i));
		}
	}

	public void UpdateUI()
	{
		for(int i = 0; i < m_StageSelectUIObjectList.Count; i++)
		{
			m_StageSelectUIObjectList[i].UpdateUI();
		}
	}
}
