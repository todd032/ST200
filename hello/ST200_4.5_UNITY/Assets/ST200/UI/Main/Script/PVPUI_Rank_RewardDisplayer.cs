using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PVPUI_Rank_RewardDisplayer : MonoBehaviour {

	public UILabel m_TapLabel;
	public UILabel m_DescriptionLabel;

	protected List<PVPRewardData> m_InfoDataList = new List<PVPRewardData>();
	public int m_UIMaxCount = 6;
	public float m_UIScrollViewHeight;
	public float m_UIObjectHeight;
	protected float m_CurScrollPointer = 0f;
	protected float m_DestScrollPointer = 0f;
	public float m_MaxScrollPointer = 0f;
	public float m_StartYPos = 100f;
	public List<PVPUI_Rank_RewardObject> m_InfoUIList = new List<PVPUI_Rank_RewardObject>();


	void Awake()
	{
		m_TapLabel.text = "[7c3500]" + TextManager.Instance.GetString(258);
		m_DescriptionLabel.text = Constant.COLOR_GOLD + TextManager.Instance.GetString(259);
	}

	// Update is called once per frame
	void Update () {
		UpdateScrollInput();
		if(Input.GetKey(KeyCode.UpArrow))
		{
			m_DestScrollPointer += 5f * Time.deltaTime;
		}else if(Input.GetKey(KeyCode.DownArrow))
		{
			m_DestScrollPointer -= 5f * Time.deltaTime;
		}
		m_DestScrollPointer = Mathf.Clamp(m_DestScrollPointer, 0f, m_MaxScrollPointer);
		m_CurScrollPointer = m_CurScrollPointer + (m_DestScrollPointer - m_CurScrollPointer) * 0.5f;
		
		UpdateUIList();
	}

	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive (gameObject, false);
	}

	public void InitUI()
	{
		InitList(PVPDataManager.Instance.m_RewardList);
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		GameUIManager.Instance.m_PVPUI.m_PVPRankingUI.ShowRankUI();
	}

	public void InitList(List<PVPRewardData> _list)
	{
		m_InfoDataList = _list;
		
		m_UIMaxCount = (int)(m_UIScrollViewHeight / m_UIObjectHeight) + 2;
		m_CurScrollPointer = m_DestScrollPointer = 0f;
		m_MaxScrollPointer = m_InfoDataList.Count - m_UIMaxCount + 2;		
		m_MaxScrollPointer = Mathf.Max(0f, m_MaxScrollPointer);
		
		UpdateUIInfo();
	}
	
	protected void UpdateUIList()
	{
		int m_curuserindex = (int)m_CurScrollPointer;
		
		bool updateui = false;
		//set position
		for(int i = 0; i < m_InfoUIList.Count; i++)
		{
			PVPUI_Rank_RewardObject ui = m_InfoUIList[i];
			
			Vector3 newpos = ui.transform.localPosition;
			newpos.x = 0f;
			
			float deltaindex = i - (m_CurScrollPointer) % m_InfoUIList.Count;
			if(deltaindex < -1f)
			{
				deltaindex += m_InfoUIList.Count;
			}
			
			if(deltaindex < -1f)
			{
				NGUITools.SetActive(ui.gameObject, false);
			}else if(deltaindex > m_UIMaxCount)
			{
				NGUITools.SetActive(ui.gameObject, false);
			}else
			{
				newpos.y = m_StartYPos - deltaindex * m_UIObjectHeight;
				if(!NGUITools.GetActive(ui.gameObject))
				{
					updateui = true;
				}
				NGUITools.SetActive(ui.gameObject, true);
			}
			ui.transform.localPosition = newpos;
		}
		
		if(updateui)
		{
			UpdateUIInfo();
		}
	}
	
	protected void UpdateUIInfo()
	{
		int m_curuserindex = (int)m_CurScrollPointer;
		for(int i = m_curuserindex; i < m_InfoUIList.Count + m_curuserindex; i++)
		{
			int curuiindex = i % m_InfoUIList.Count;
			int curuserindex = i;
			if(curuserindex < m_InfoDataList.Count)
			{
				PVPRewardData data = m_InfoDataList[curuserindex];
				m_InfoUIList[curuiindex].InitUI(
					"[" + data.WinColor + "]" + data.WinCount.ToString() + TextManager.Instance.GetString(248),
					data.ImageIndex,
					data.RewardString);					
			}else
			{
				NGUITools.SetActive(m_InfoUIList[curuiindex].gameObject, false);
			}
		}
	}
	
	protected Vector3 prevpos;	
	protected bool m_ScrollPressed = false;
	protected void UpdateScrollInput()
	{
		if(m_ScrollPressed)
		{
			if(Input.GetMouseButton(0))
			{
				m_DestScrollPointer -= (-Input.mousePosition.y + prevpos.y) / 200f;
				m_DestScrollPointer = Mathf.Clamp(m_DestScrollPointer, 0f, m_MaxScrollPointer);
				prevpos = Input.mousePosition;
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
}
