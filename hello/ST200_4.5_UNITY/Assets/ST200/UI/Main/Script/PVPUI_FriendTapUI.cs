using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PVPUI_FriendTapUI : MonoBehaviour {

	protected bool m_SearchFriendMode = false;
	public UIInput m_SearchFriendInput;
	public UILabel m_SearchNickNameLabel;

	protected List<UserInfoData> m_CurInfoList = new List<UserInfoData>();
	protected List<UserInfoData> m_FriendInfoDataList = new List<UserInfoData>();
	protected List<UserInfoData> m_FriendSearchInfoDataList = new List<UserInfoData>();
	public int m_FriendUIMaxCount = 6;
	public float m_FriendUIScrollViewHeight;
	public float m_FriendUIObjectHeight;
	protected float m_CurScrollPointer = 0f;
	protected float m_DestScrollPointer = 0f;
	public float m_MaxScrollPointer = 0f;
	public float m_StartYPos = 100f;
	public List<PVPUI_UserInfoObject> m_FriendUIList = new List<PVPUI_UserInfoObject>();
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
	}

	public void ShowUI()
	{
		NGUITools.SetActive (gameObject, true);
		m_SearchNickNameLabel.text = TextManager.Instance.GetString(256);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive (gameObject, false);
	}

	public void UpdateUI()
	{
		if(m_SearchFriendMode)
		{
			InitFriendSearchList();
		}else
		{
			InitFriendList();
		}
	}

	bool initfriendlist = false;
	public void InitFriendList()
	{
		m_SearchFriendMode = false;


		m_FriendUIMaxCount = (int)(m_FriendUIScrollViewHeight / m_FriendUIObjectHeight) + 2;
		m_MaxScrollPointer = PVPDataManager.Instance.m_FriendInfoList.Count - m_FriendUIMaxCount + 2;
		m_MaxScrollPointer = Mathf.Max(0f, m_MaxScrollPointer);
		
		for(int i = 0; i < m_FriendUIList.Count; i++)
		{
			m_FriendUIList[i].SetAsFriend();
		}
		m_CurInfoList = PVPDataManager.Instance.m_FriendInfoList;

		UpdateUIInfo();
	}

	protected void UpdateFriendUIList()
	{
		int m_curuserindex = (int)m_CurScrollPointer;

		bool updateui = false;
		//set position
		for(int i = 0; i < m_FriendUIList.Count; i++)
		{
			PVPUI_UserInfoObject ui = m_FriendUIList[i];

			Vector3 newpos = ui.transform.localPosition;
			newpos.x = 0f;

			float deltaindex = i - (m_CurScrollPointer) % m_FriendUIList.Count;
			if(deltaindex < -1f)
			{
				deltaindex += m_FriendUIList.Count;
			}

			if(deltaindex < -1f)
			{
				NGUITools.SetActive(ui.gameObject, false);
			}else if(deltaindex > m_FriendUIMaxCount)
			{
				NGUITools.SetActive(ui.gameObject, false);
			}else
			{
				newpos.y = m_StartYPos - deltaindex * m_FriendUIObjectHeight;
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
		for(int i = m_curuserindex; i < m_FriendUIList.Count + m_curuserindex; i++)
		{
			int curuiindex = i % m_FriendUIList.Count;
			int curuserindex = i;
			if(curuserindex < m_CurInfoList.Count)
			{
				m_FriendUIList[curuiindex].Init(m_CurInfoList[curuserindex]);
			}else
			{
				NGUITools.SetActive(m_FriendUIList[curuiindex].gameObject, false);
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

	public void OnClickCancleFriendSearch()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
	}

	public void OnSearchFriend()
	{
		if(m_SearchFriendInput.value.Length < 2)
		{
			m_SearchFriendMode = false;
			InitFriendList();
			GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_PVP_FRIEND_SEARCH_LENGTH_ERROR);
		}else
		{
			Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
			{
				if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
				{	
					if(strResult_Extend_Input == "0")
					{
						m_SearchFriendMode = false;
						InitFriendList();
						GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_PVP_FRIEND_SEARCH_NORESULT);
					}else
					{
						InitFriendSearchList();
					}
				}else
				{
					Managers.DataStream.PVP_Request_FriendSearch(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage(), m_SearchFriendInput.value);
				}
			};
			Managers.DataStream.PVP_Request_FriendSearch(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage(), m_SearchFriendInput.value);
			m_SearchFriendMode = true;
		}
	}

	public void InitFriendSearchList()
	{
		m_FriendSearchInfoDataList = PVPDataManager.Instance.m_FriendSearchInfoList;
		
		m_FriendUIMaxCount = (int)(m_FriendUIScrollViewHeight / m_FriendUIObjectHeight) + 2;
		m_MaxScrollPointer = m_FriendSearchInfoDataList.Count - m_FriendUIMaxCount + 2;
		m_MaxScrollPointer = Mathf.Max(0f, m_MaxScrollPointer);
		
		for(int i = 0; i < m_FriendUIList.Count; i++)
		{
			m_FriendUIList[i].SetAsFriendSearch();
		}

		m_CurInfoList = m_FriendSearchInfoDataList;
		UpdateUIInfo();
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			if(m_SearchFriendMode)
			{
				InitFriendList();
				return true;
			}
		}
		
		return false;
	}
}
