using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LuckyPresentPopupView : MonoBehaviour {

	public List<LuckyPresentItemObject> m_LuckyPresentItemObjectList;

	public GameObject m_ExplainWindow;
	public UILabel m_ExplainCouponLabel;
	public UILabel m_ExplainGachaAvailableCountLabel;

	public GameObject m_PresentWindow;

	public GameObject m_PickOneLabelGameObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowPopupView()
	{
		NGUITools.SetActive(gameObject, true);
		NGUITools.SetActive(m_ExplainWindow, true);
		NGUITools.SetActive(m_PresentWindow, false);
		UpdateView();
	}

	public void HidePopupView()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		NGUITools.SetActive(gameObject, false);
	}

	public void UpdateView()
	{
		m_ExplainCouponLabel.text = "x "+Managers.UserData.LuckyCoupon.ToString();
		m_ExplainGachaAvailableCountLabel.text = (Managers.UserData.LuckyCoupon / Managers.GameBalanceData.LuckyGachaPerCoupon).ToString();
	}

	private void OnClickLuckyPresentGachaButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if((Managers.UserData.LuckyCoupon / Managers.GameBalanceData.LuckyGachaPerCoupon) > 0)
		{
			m_PickOneLabelGameObject.gameObject.SetActive(true);
			NGUITools.SetActive(m_ExplainWindow, false);
			NGUITools.SetActive(m_PresentWindow, true);
			for(int i = 0; i < m_LuckyPresentItemObjectList.Count; i++)
		    {
				m_LuckyPresentItemObjectList[i].Reset(this);
			}
		}
	}

	public void OnClickPresentItem(LuckyPresentItemObject _itemobject)
	{
		m_PickOneLabelGameObject.gameObject.SetActive(false);
		//remove 5 luckypresent
		Managers.UserData.LuckyCoupon -= Managers.GameBalanceData.LuckyGachaPerCoupon;
		List<GameBalanceDataManager.LuckyPresent> LuckyPresents = Managers.GameBalanceData.GetLuckyPresentGachaList(3);

		//modify data and save user data
		Managers.UserData.GivePresent(LuckyPresents[0].ItemType, LuckyPresents[0].ItemAmount);
		Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null;

		// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
		Managers.UserData.UpdateSequence++;
		Managers.DataStream.Network_SaveUserData_Input_1(Managers.UserData.GetUserDataStruct());
		// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.

		List<LuckyPresentItemObject> tempLuckyPresentItemObjects = new List<LuckyPresentItemObject>(m_LuckyPresentItemObjectList);
		for(int i = 0; i < tempLuckyPresentItemObjects.Count; i++)
		{
			if(tempLuckyPresentItemObjects[i] == _itemobject)
			{
				_itemobject.StartShowAnim(LuckyPresents[0].ItemType, LuckyPresents[0].ItemAmount, true);
				tempLuckyPresentItemObjects.RemoveAt(i);
				LuckyPresents.RemoveAt(0);
				break;
			}
		}

		for(int i = 0; i < LuckyPresents.Count; i++)
		{
			tempLuckyPresentItemObjects[i].StartShowAnim(LuckyPresents[i].ItemType, LuckyPresents[i].ItemAmount, false);
		}
	}

	public void OnClickOpenChestOk()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		NGUITools.SetActive(m_ExplainWindow, true);
		NGUITools.SetActive(m_PresentWindow, false);
		UpdateView();
	}
}
