using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubShipSelectUI : MonoBehaviour {

	public SubShipScroller m_SubShipScroll;
	public Object m_SubShipScollObject;
	public List<SubShipInfoObject> m_SubShipInfoObjectList = new List<SubShipInfoObject>();
	public GachaAnimation m_GachaAnimation;
	public SubShipDictionary m_SubShipDictionary;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init()
	{
		UpdateUI();
		m_SubShipScroll.ResetPosition();
	}

	public void UpdateUI()
	{
		List<int> subshiporderedbygradelist = new List<int>();
		int maxgrade = 0;
		int lowgrade = 999;
		for(int i = 0 ; i < Managers.GameBalanceData.m_SubShipDescriptionInfoList.Count; i++)
		{
			SubShipDescriptionInfo subshipdescriptioninfo = Managers.GameBalanceData.m_SubShipDescriptionInfoList[i];
			if(subshipdescriptioninfo.Grade > maxgrade)
			{
				maxgrade = subshipdescriptioninfo.Grade;
			}
			if(subshipdescriptioninfo.Grade < lowgrade)
			{
				lowgrade = subshipdescriptioninfo.Grade;
			}
		}

		for(int i = lowgrade; i <= maxgrade; i++)
		{
			for(int j = 0; j < Managers.GameBalanceData.m_SubShipDescriptionInfoList.Count; j++)
			{
				SubShipDescriptionInfo subshipdescriptioninfo = Managers.GameBalanceData.m_SubShipDescriptionInfoList[j];
				if(i == subshipdescriptioninfo.Grade )
				{
					subshiporderedbygradelist.Add(subshipdescriptioninfo.ShipIndex);
				}
			}
		}

		//check purchased subship and do things
		int subshipinfoojbectlistcount = 0;
		for(int i = 0 ; i < subshiporderedbygradelist.Count; i++)
		{
			//Debug.Log("I: " + i);
			UserSubShipData usersubshipdata = Managers.UserData.GetUserSubShipData(subshiporderedbygradelist[i]);

			if(usersubshipdata.IsPurchase)
			{
				if(subshipinfoojbectlistcount < m_SubShipInfoObjectList.Count)
				{
					m_SubShipInfoObjectList[subshipinfoojbectlistcount].Init(this, usersubshipdata.IndexNumber);
					//Debug.Log ("exist FOR: " + usersubshipdata.IndexNumber);
				}else
				{
					GameObject go = Instantiate(m_SubShipScollObject) as GameObject;
					SubShipInfoObject subshipinfoobject = go.GetComponent<SubShipInfoObject>();
					subshipinfoobject.Init(this, usersubshipdata.IndexNumber);
					m_SubShipInfoObjectList.Add(subshipinfoobject);

					SubShipScrollObject scrollobject = go.GetComponent<SubShipScrollObject>();
					m_SubShipScroll.AddScrollObject(scrollobject);
					//Debug.Log ("CREATE FOR: " + usersubshipdata.IndexNumber);
				}
				subshipinfoojbectlistcount++;
			}
		}
	}

	public bool OnEscapePress()
	{
		if(m_SubShipDictionary.OnEscapePress())
		{
			return true;
		}else if(m_GachaAnimation.OnEscapePress())
		{
			return true;
		}else if(gameObject.activeSelf)
		{
			OnClickCloseButton();
			return true;
		}
		return false;
	}

	public void OnClickDictionaryClick()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		m_SubShipDictionary.ShowUI();
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		GameUIManager.Instance.m_MainUI.ChangePanel(1);
	}
}
