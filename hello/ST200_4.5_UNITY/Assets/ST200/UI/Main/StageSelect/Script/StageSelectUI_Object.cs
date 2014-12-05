using UnityEngine;
using System.Collections;

public class StageSelectUI_Object : MonoBehaviour {

	public StageSelectUI m_StageSelectUI;
	public StageData m_StageData;
	
	public UILabel m_StageNameLabel;
	public GameObject m_ClearSprite;
	public GameObject m_CurrentStageSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void InitUI(StageSelectUI _stageselectui, StageData _stagedata)
	{
		m_StageSelectUI = _stageselectui;
		m_StageData = _stagedata;

		m_StageNameLabel.text = TextManager.Instance.GetReplaceString(309, m_StageData.Index.ToString());
		UpdateUI();
	}
	
	public void UpdateUI()
	{
		UserStageData userstagedata = Managers.UserData.GetUserStageData(m_StageData.Index);
		
		if(m_StageData.Locked == 1)
		{
			NGUITools.SetActive(m_ClearSprite.gameObject, false);
			NGUITools.SetActive(m_CurrentStageSprite.gameObject, false);
		}else if(userstagedata.IsClear)
		{
			NGUITools.SetActive(m_ClearSprite.gameObject, true);
			NGUITools.SetActive (m_CurrentStageSprite.gameObject, false);
		}else if(userstagedata.IsOpen)
		{
			NGUITools.SetActive(m_ClearSprite.gameObject, false);
			NGUITools.SetActive(m_CurrentStageSprite.gameObject, true);
		}else
		{
			NGUITools.SetActive(m_ClearSprite.gameObject, false);
			NGUITools.SetActive(m_CurrentStageSprite.gameObject, false);
		}


	}
	
	public void OnClickStage()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		m_StageSelectUI.SelectStage(m_StageData);
	}
}
