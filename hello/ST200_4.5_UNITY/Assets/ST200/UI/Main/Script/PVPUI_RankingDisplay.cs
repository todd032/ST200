using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PVPUI_RankingDisplay : MonoBehaviour {
	
	protected List<UserPVPRankInfoData> m_RankInfoDataList = new List<UserPVPRankInfoData>();
	public int m_UIMaxCount = 6;
	public float m_UIScrollViewHeight;
	public float m_UIObjectHeight;
	protected float m_CurScrollPointer = 0f;
	protected float m_DestScrollPointer = 0f;
	public float m_MaxScrollPointer = 0f;
	public float m_StartYPos = 100f;
	public List<PVPUI_Rank_InfoObject> m_RankUserInfoUIList = new List<PVPUI_Rank_InfoObject>();
	// Use this for initialization
	void Start () {
		
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
		
		UpdateFriendUIList();
		UpdateLoadingImage();
	}

	public UISprite m_LoadingSprite;
	public int m_LoadingCurFrame = 0;
	public int m_LoadingUpdateframe = 3;
	public void UpdateLoadingImage()
	{
		m_LoadingCurFrame++;
		if(m_LoadingCurFrame % m_LoadingUpdateframe == 0)
		{
			m_LoadingSprite.transform.Rotate(Vector3.forward, -24f);
		}

		if(m_RankInfoDataList.Count == 0)
		{
			ShowLoadingUI();
		}else
		{
			HideLoadingUI();
		}
	}

	public void ShowLoadingUI()
	{
		NGUITools.SetActive(m_LoadingSprite.gameObject, true);
	}
	
	public void HideLoadingUI()
	{
		NGUITools.SetActive(m_LoadingSprite.gameObject, false);
	}
	
	public void OnClickSearchPlayer()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
	}
	
	public void ShowUI()
	{
		NGUITools.SetActive (gameObject, true);
	}
	
	public void RemoveUI()
	{
		NGUITools.SetActive (gameObject, false);
	}
	
	public void InitRankList(List<UserPVPRankInfoData> _list)
	{
		m_RankInfoDataList = _list;
		
		m_UIMaxCount = (int)(m_UIScrollViewHeight / m_UIObjectHeight) + 2;
		m_CurScrollPointer = m_DestScrollPointer = 0f;
		m_MaxScrollPointer = m_RankInfoDataList.Count - m_UIMaxCount + 2;		
		m_MaxScrollPointer = Mathf.Max(0f, m_MaxScrollPointer);
		
		UpdateUIInfo();
	}
	
	protected void UpdateFriendUIList()
	{
		int m_curuserindex = (int)m_CurScrollPointer;
		
		bool updateui = false;
		//set position
		for(int i = 0; i < m_RankUserInfoUIList.Count; i++)
		{
			PVPUI_Rank_InfoObject ui = m_RankUserInfoUIList[i];
			
			Vector3 newpos = ui.transform.localPosition;
			newpos.x = 0f;
			
			float deltaindex = i - (m_CurScrollPointer) % m_RankUserInfoUIList.Count;
			if(deltaindex < -1f)
			{
				deltaindex += m_RankUserInfoUIList.Count;
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
		for(int i = m_curuserindex; i < m_RankUserInfoUIList.Count + m_curuserindex; i++)
		{
			int curuiindex = i % m_RankUserInfoUIList.Count;
			int curuserindex = i;
			if(curuserindex < m_RankInfoDataList.Count)
			{
				UserPVPRankInfoData userdata = m_RankInfoDataList[curuserindex];
				m_RankUserInfoUIList[curuiindex].InitUI(
					curuserindex == 0,
					userdata.Rank,
					userdata.UserNickName,
					userdata.CharacterIndex,
					userdata.ShipIndex,
					userdata.ShipLevel,
					userdata.WinCount,
					userdata.LoseCount
					);
			}else
			{
				NGUITools.SetActive(m_RankUserInfoUIList[curuiindex].gameObject, false);
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