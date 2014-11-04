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

	protected int m_StagePivotObjectCount = 40;
	protected int m_CurPivotIndex = 0;
	protected int m_PrevPivotIndex = 0;
	protected float m_CurPivotProgress;
	protected float m_DestPivotProgress;
	protected float m_MaxPivotProgress;
	protected bool m_ScrollPressed = false;
	public List<StageSelectUI_Pivot> m_StageSelectUI_PivotList = new List<StageSelectUI_Pivot>();
	public UISlider m_PivotSlider;
	public Transform m_BackgroundPivot;
	// Use this for initialization
	void Start () {
		m_TitleLabel.text = Constant.COLOR_MAIN_SUBTITLE + TextManager.Instance.GetString (109);
		m_BackLabel.text = Constant.COLOR_RESULT_BUTTON + TextManager.Instance.GetString (110);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow))
		{
			m_DestPivotProgress += 1f * Time.deltaTime;
		}else if(Input.GetKey(KeyCode.LeftArrow))
		{
			m_DestPivotProgress -= 1f * Time.deltaTime;
		}

		UpdateScrollInput();
		ProcessPivotList();
	}

	bool m_Initflag = false;
	public void InitUI()
	{
		GameObject scrollobject = null;
		if(!m_Initflag)
		{
			//get stage datas and init
			//for(int i = Managers.GameBalanceData._stageDataList.Count - 1; i >=  0; i--)
			//{
			//	StageData stagedata = Managers.GameBalanceData._stageDataList[i];
			//	GameObject go = Instantiate(m_StageUIObject) as GameObject;
			//	StageSelectUIObject uiobject = go.GetComponent<StageSelectUIObject>();
			//	uiobject.InitUI(this, stagedata);
			//
			//	go.transform.parent = m_Grid.transform;
			//	go.transform.localScale = Vector3.one;
			//
			//	m_StageSelectUIObjectList.Add(uiobject);
			//
			//	//UserStageData userstagedata = Managers.UserData.GetUserStageData(i);
			//	//if(userstagedata.IsClear)
			//	//{
			//	//	scrollobject = go;
			//	//}
			//	//if(scrollobject == null)
			//	//{
			//	//	scrollobject = go;
			//	//}
			//}
			//m_Grid.Reposition();
			////m_ScrollView.ResetPosition();
			//
			//Invoke("SmartPositioner", 0.3f);

			//init pivot things
			int laststage = 0;
			int finalstage = 0;
			for(int i = 0; i < Managers.GameBalanceData._stageDataList.Count; i++)
			{
				StageData curstagedata = Managers.GameBalanceData._stageDataList[i];
				UserStageData userstagedata = Managers.UserData.GetUserStageData(curstagedata.Index);
				if(userstagedata.IsOpen && curstagedata.Locked == 0)
				{
					if(userstagedata.IndexNumber > laststage)
					{
						laststage = userstagedata.IndexNumber;
					}
				}
				if(userstagedata.IndexNumber > finalstage)
				{
					finalstage = userstagedata.IndexNumber;
				}
			}

			m_CurPivotIndex = (laststage - 1) / m_StagePivotObjectCount;
			m_CurPivotProgress = m_CurPivotIndex + ((laststage - m_CurPivotIndex * m_StagePivotObjectCount) / 4f) * 0.08f;
			m_DestPivotProgress = m_CurPivotProgress;
			m_PrevPivotIndex = m_CurPivotIndex;
			m_MaxPivotProgress = (finalstage - 1)/ m_StagePivotObjectCount + 0.4f;
			UpdatePivotList();
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
			Managers.UserData.SelectedGameType = Constant.ST200_GAMEMODE_STAGE_NORMAL;
			GameUIManager.Instance.SwitchToGameShopManager();
		}
	}

	public void OnClickBackButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_GameStart,false);

		GameUIManager.Instance.SwitchToGameMainUI();
	}

	protected void ProcessPivotList()
	{
		m_DestPivotProgress = Mathf.Clamp(m_DestPivotProgress, 0f, m_MaxPivotProgress);
		m_CurPivotProgress = m_CurPivotProgress + (m_DestPivotProgress - m_CurPivotProgress) * 0.2f;

		m_CurPivotIndex = Mathf.RoundToInt(m_CurPivotProgress);
		if(m_PrevPivotIndex != m_CurPivotIndex)
		{
			m_PrevPivotIndex = m_CurPivotIndex;
			UpdatePivotList();
		}

		for(int i = 0; i < m_StageSelectUI_PivotList.Count; i++)
		{
			int curpivotarrayindex = (m_CurPivotIndex + i) % m_StageSelectUI_PivotList.Count;
			StageSelectUI_Pivot curpivot = m_StageSelectUI_PivotList[curpivotarrayindex];
			//position pivot according to curpivotarrayindex;
			float ydeltapos = (-m_CurPivotProgress + m_CurPivotIndex + (float)i - 1f) * 1120f;
			Vector3 newpos = Vector3.zero;
			newpos.x = 0f;
			newpos.y = ydeltapos;
			curpivot.transform.localPosition = newpos;
		}

		Vector3 bgnewpos = m_BackgroundPivot.transform.localPosition;
		bgnewpos.y = -1120f * m_CurPivotProgress;
		m_BackgroundPivot.transform.localPosition = bgnewpos;

		m_PivotSlider.value = m_CurPivotProgress / m_MaxPivotProgress;
	}

	protected void UpdatePivotList()
	{
		for(int i = 0; i < m_StageSelectUI_PivotList.Count; i++)
		{
			int curpivotarrayindex = (m_CurPivotIndex + i) % m_StageSelectUI_PivotList.Count;
			StageSelectUI_Pivot curpivot = m_StageSelectUI_PivotList[curpivotarrayindex];
			int curpivotindex = m_CurPivotIndex + i - 1;
			int curstageindex = curpivotindex * m_StagePivotObjectCount + 1;
			StageData startstagedata = Managers.GameBalanceData.GetStageData(curstageindex);
			if(startstagedata.Index == 0)
			{
				NGUITools.SetActive(curpivot.gameObject, false);
			}else
			{
				NGUITools.SetActive(curpivot.gameObject, true);
				curpivot.Init(curstageindex);
			}
		}
	}

	protected Vector3 prevpos;
	protected void UpdateScrollInput()
	{
		if(m_ScrollPressed)
		{
			if(Input.GetMouseButton(0))
			{
				#if UNITY_EDITOR
				m_DestPivotProgress += (-Input.mousePosition.y + prevpos.y) / 300f;
				m_DestPivotProgress = Mathf.Clamp(m_DestPivotProgress, 0f, m_MaxPivotProgress);
				prevpos = Input.mousePosition;
				#else
				m_DestPivotProgress -= Input.GetTouch(0).deltaPosition.y / 300f;
				m_DestPivotProgress = Mathf.Clamp(m_DestPivotProgress, 0f, m_MaxPivotProgress);
				#endif
			}
		}
	}
	public void OnPressScroll()
	{
		m_ScrollPressed = true;
		prevpos = Input.mousePosition;
	}

	public void OnReleaseScroll()
	{
		m_ScrollPressed = false;
		//m_DestPivotProgress = Mathf.RoundToInt( m_DestPivotProgress);
	}

	public void SetScrollPosition(float _dest)
	{
		m_DestPivotProgress = _dest;
		m_CurPivotProgress = m_DestPivotProgress;
	}
}
