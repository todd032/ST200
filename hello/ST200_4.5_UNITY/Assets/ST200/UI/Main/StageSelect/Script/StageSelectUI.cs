using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageSelectUI : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UILabel m_BackLabel;

	public UIScrollView m_ScrollView;
	public UIGrid m_Grid;
	public Object m_StageUIObject;
	public List<StageSelectUIObject> m_StageSelectUIObjectList = new List<StageSelectUIObject>();

	// Use this for initialization
	void Start () {
		m_TitleLabel.text = Constant.COLOR_MAIN_TITLE + TextManager.Instance.GetString (109);
		m_BackLabel.text = Constant.COLOR_RESULT_BUTTON + TextManager.Instance.GetString (110);
	}
	
	// Update is called once per frame
	void Update () {

	}

	bool m_Initflag = false;
	public void InitUI()
	{
		GameObject scrollobject = null;
		if(!m_Initflag)
		{
			//get stage datas and init
			for(int i = Managers.GameBalanceData._stageDataList.Count - 1; i >=  0; i--)
			{
				StageData stagedata = Managers.GameBalanceData._stageDataList[i];
				GameObject go = Instantiate(m_StageUIObject) as GameObject;
				StageSelectUIObject uiobject = go.GetComponent<StageSelectUIObject>();
				uiobject.InitUI(this, stagedata);

				go.transform.parent = m_Grid.transform;
				go.transform.localScale = Vector3.one;

				m_StageSelectUIObjectList.Add(uiobject);

				//UserStageData userstagedata = Managers.UserData.GetUserStageData(i);
				//if(userstagedata.IsClear)
				//{
				//	scrollobject = go;
				//}
				//if(scrollobject == null)
				//{
				//	scrollobject = go;
				//}
			}
			m_Grid.Reposition();
			//m_ScrollView.ResetPosition();

			Invoke("SmartPositioner", 0.3f);
		}
		UpdateUI();
		m_Initflag = true;
	}

	protected void SmartPositioner()
	{
		GameObject selectedobject = m_StageSelectUIObjectList[0].gameObject;
		int curopenstage = 0;
		for(int i = 0; i < m_StageSelectUIObjectList.Count; i++)
		{
			StageSelectUIObject curuiobject = m_StageSelectUIObjectList[i];
			UserStageData userstagedata = Managers.UserData.GetUserStageData(curuiobject.m_StageData.Index);
			if(userstagedata.IsOpen && curuiobject.m_StageData.Locked == 0)
			{
				if(userstagedata.IndexNumber > curopenstage)
				{
					curopenstage = userstagedata.IndexNumber;
					selectedobject = curuiobject.gameObject;
				}
			}
		}
		//Debug.Log("??: cur select object: " + curopenstage);
		//m_ScrollView.MoveAbsolute(Vector3.down * (selectedobject.transform.position.y - m_ScrollView.transform.position.y ));
		m_ScrollView.MoveRelative(Vector3.down * (selectedobject.transform.localPosition.y));
		//m_ScrollView.Drag();
	}

	public void UpdateUI()
	{
		for(int i = 0; i < m_StageSelectUIObjectList.Count; i++)
		{
			m_StageSelectUIObjectList[i].UpdateUI();
		}
	}

	public void SelectStage(StageData m_StageData)
	{
		if(Managers.GameBalanceData.GetStageData(m_StageData.Index).Locked == 1)
		{
			GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_STAGESELECT_LOCKED_STAGE);
		}else if(!Managers.UserData.GetUserStageData(m_StageData.Index).IsOpen)
		{
			GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_STAGE_LOCKED);
		}else
		{
			Managers.UserData.SelectedStageIndex = m_StageData.Index;
			GameUIManager.Instance.SwitchToGameShopManager();
		}
	}

	public void OnClickBackButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_GameStart,false);

		GameUIManager.Instance.SwitchToGameMainUI();
	}
}
