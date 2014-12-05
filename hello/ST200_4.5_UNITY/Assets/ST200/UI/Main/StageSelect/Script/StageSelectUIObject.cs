using UnityEngine;
using System.Collections;

public class StageSelectUIObject : MonoBehaviour {

	public StageSelectUI m_StageSelectUI;
	public StageData m_StageData;

	public UILabel m_StageNameLabel;
	public UISprite m_StageBackgroundSprite;
	public UISprite m_LockedSprite;
	public UISprite m_ClearSprite;
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

		UpdateUI();
	}

	public void UpdateUI()
	{
		UserStageData userstagedata = Managers.UserData.GetUserStageData(m_StageData.Index);

		if(userstagedata.IsOpen && m_StageData.Locked == 0)
		{
			m_StageBackgroundSprite.spriteName = "stageselect_stage_bar";
			NGUITools.SetActive(m_LockedSprite.gameObject, false);
			m_StageNameLabel.text = Constant.COLOR_STAGESELECT_ACTIVE + TextManager.Instance.GetReplaceString(309, m_StageData.Index.ToString());
		}else
		{
			m_StageBackgroundSprite.spriteName = "stageselect_stage_bg_locked";
			NGUITools.SetActive(m_LockedSprite.gameObject, true);
			m_StageNameLabel.text = Constant.COLOR_STAGESELECT_INACTIVE + TextManager.Instance.GetReplaceString(309, m_StageData.Index.ToString());
		}

		if(userstagedata.IsClear)
		{
			NGUITools.SetActive(m_ClearSprite.gameObject, true);
		}else
		{
			NGUITools.SetActive(m_ClearSprite.gameObject, false);
		}
	}

	public void OnClickStage()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		m_StageSelectUI.SelectStage(m_StageData);
	}
}
