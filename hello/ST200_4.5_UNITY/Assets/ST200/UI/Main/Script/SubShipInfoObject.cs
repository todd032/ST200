using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubShipInfoObject : MonoBehaviour {

	public SubShipSelectUI m_SubshipSelectUI;

	public UISprite m_ShipImage;
	public UILabel m_ShipNameLabel;
	public UILabel m_ShipLevelLabel;
	public List<GameObject> m_GradeMarkObjectList = new List<GameObject>();
	public GameObject m_SelectButton;
	public GameObject m_UpgradeCompleteButton;
	public GameObject m_UpgradeButton;
	public UILabel m_UpgradeCostLabel;
	public GameObject m_UpgradeGoldButton;
	public UILabel m_UpgradeGoldCostLabel;
	public UILabel m_DescriptionLabel;
	public UILabel m_SpecialDescriptionLabel;

	protected int m_ShipIndex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(SubShipSelectUI _subshipui, int _index)
	{
		m_SubshipSelectUI = _subshipui;

		m_ShipIndex = _index;

		SubShipDescriptionInfo descriptionifo = Managers.GameBalanceData.GetSubShipDescriptionInfo(m_ShipIndex);
		UserSubShipData usersubshipdata = Managers.UserData.GetUserSubShipData(m_ShipIndex);
		SubShipStatInfo nextsubshipstatinfo = Managers.GameBalanceData.GetSubShipStatInfo(usersubshipdata.IndexNumber,
		                                                                                  usersubshipdata.Level + 1);

		m_ShipImage.spriteName = ImageResourceManager.Instance.GetMainUISubShipImageName(_index);
		m_ShipNameLabel.text = descriptionifo.ShipName;
		for(int i = 0; i < m_GradeMarkObjectList.Count; i++)
		{
			if(descriptionifo.Grade == i + 1)
			{
				m_GradeMarkObjectList[i].SetActive(true);
			}else
			{
				m_GradeMarkObjectList[i].SetActive(false);
			}
		}

		m_ShipLevelLabel.text = "Lv." + usersubshipdata.Level.ToString();
		m_DescriptionLabel.text = Constant.COLOR_SUBSHIP_UPGRADE_DESCRIPTION + TextManager.Instance.GetReplacedString(descriptionifo.ShipDescription);
		m_SpecialDescriptionLabel.text = Constant.COLOR_RED + TextManager.Instance.GetReplacedString(descriptionifo.ShipSpecialDescription);

		if(usersubshipdata.IsSelect != 0)
		{
			if(nextsubshipstatinfo.ShipIndex != 0)
			{
				NGUITools.SetActive(m_SelectButton.gameObject, false);
				NGUITools.SetActive(m_UpgradeCompleteButton.gameObject, false);
				if(nextsubshipstatinfo.ValueType == 1)
				{
					NGUITools.SetActive(m_UpgradeButton.gameObject, true);
					NGUITools.SetActive(m_UpgradeGoldButton.gameObject, false);
				}else
				{
					NGUITools.SetActive(m_UpgradeButton.gameObject, false);
					NGUITools.SetActive(m_UpgradeGoldButton.gameObject, true);
				}
				string upgradecoststring = "0";
				if(nextsubshipstatinfo.Cost != 0)
				{
					upgradecoststring = nextsubshipstatinfo.Cost.ToString("#,#");
				}
				m_UpgradeCostLabel.text = upgradecoststring;
				m_UpgradeGoldCostLabel.text = upgradecoststring;
			}else
			{
				NGUITools.SetActive(m_SelectButton.gameObject, false);
				NGUITools.SetActive(m_UpgradeCompleteButton.gameObject, true);
				NGUITools.SetActive(m_UpgradeButton.gameObject, false);
				NGUITools.SetActive(m_UpgradeGoldButton.gameObject, false);
			}
		}else
		{
			NGUITools.SetActive(m_SelectButton.gameObject, true);
			NGUITools.SetActive(m_UpgradeCompleteButton.gameObject, false);
			NGUITools.SetActive(m_UpgradeButton.gameObject, false);
			NGUITools.SetActive(m_UpgradeGoldButton.gameObject, false);
		}
	}

	public void UpdateUI()
	{

	}

	public void OnClickUpgrade()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(Managers.UserData != null && Managers.GameBalanceData != null){
			
			UserSubShipData selectshipdata = Managers.UserData.GetUserSubShipData(m_ShipIndex);
			
			SubShipStatInfo shipinfo = Managers.GameBalanceData.GetSubShipStatInfo(m_ShipIndex, selectshipdata.Level + 1);
			
			int valueType = shipinfo.ValueType ;
			int submarineValue = shipinfo.Cost ;
			
			/// Money Process..
			if(valueType == 1){
				
				int spendState = Managers.UserData.SetSpendGold(submarineValue) ;
				
				if(spendState == 1) {
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
					
					//ST200KLogManager.Instance.SaveShopSubmarinePurchase(m_CurShipIndex, valueType, submarineValue);
					selectshipdata.Level++;
					Managers.UserData.SetUserSubShipData(selectshipdata);
					
					//ReLoad...
					
					if (Managers.DataStream != null){
						
						if(Managers.UserData != null){
							
							Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
							UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
							
							// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
							Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
							// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
							
						}
					}
					
					// ReLoad...Cash..
					GameUIManager.Instance.LoadGameGoldAndGameJewelInfo();
					
					//Purchase Ok Message
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_PURCHASE_OK);
					
				}else{
					// Pop Up Payment Window...
					//Debug.Log("Pop Up Payment Window... Gold") ;
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_COIN);
				}
				
			}else if(valueType == 2){
				
				int spendState = Managers.UserData.SetSpendJewel(submarineValue) ;
				
				if(spendState == 1) {
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
					//ST200KLogManager.Instance.SaveShopSubmarinePurchase(m_CurShipIndex, valueType, submarineValue);
					selectshipdata.Level++;
					Managers.UserData.SetUserSubShipData(selectshipdata);
					//ReLoad...
					
					if(Managers.DataStream != null){
						if(Managers.UserData != null){
							UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;								
							Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
							// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
						}
					}
					
					// ReLoad...Cash..
					GameUIManager.Instance.LoadGameGoldAndGameJewelInfo();					
					
					//Purchase Ok Message
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_PURCHASE_OK);
					
				}else{
					// Pop Up Payment Window...	
					//Debug.Log("Pop Up Payment Window... Jewel") ;
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_JEWEL);
				}
				
			}
			m_SubshipSelectUI.UpdateUI();
		}
	}

	public void OnClickSelect()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		//try to equip the ship
		bool isopen = true;
		bool equipedflag = false;
		for(int i = 1; i <= Managers.GameBalanceData.SubShipEquipAvailableMaxCount; i++)
		{
			if(Managers.GameBalanceData.GetGameCharacterInfoBalance(Managers.UserData.GetCurrentGameCharacter().IndexNumber).AvailableTacticSlot < i)
			{
				GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SUBSHIP_UNABLETO_EQUIP_CHARACTER);
				break;
			}

			if(Managers.UserData.SubShipEquipAvailableSlotCount < i)
			{
				//if not open byebye
				isopen = false;
				if(Managers.UserData.SubShipEquipAvailableSlotCount == 1)
				{
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT2);
				}else if(Managers.UserData.SubShipEquipAvailableSlotCount == 2)
				{
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT3);
				}else if(Managers.UserData.SubShipEquipAvailableSlotCount == 3)
				{
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT4);
				}
				break;
			}

			if(Managers.UserData.GetEquipedSubShipIndex(i) == 0)
			{
				equipedflag = true;
				//equip it
				UserSubShipData usersubshipdata = Managers.UserData.GetUserSubShipData(m_ShipIndex);
				usersubshipdata.IsSelect = i;
				Managers.UserData.SetUserSubShipData(usersubshipdata);
				break;
			}
		}
		
		//if can't equip show pop up to unlock or unequip previous ship
		if(isopen && !equipedflag)
		{
			GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SUBSHIP_UNALBLE_TO_EQUIP);
		}
		
		GameUIManager.Instance.m_MainUI.UpdateUI();
	}
}
