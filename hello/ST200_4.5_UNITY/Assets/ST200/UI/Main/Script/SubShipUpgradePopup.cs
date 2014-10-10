using UnityEngine;
using System.Collections;

public class SubShipUpgradePopup : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UILabel m_ShipNameLabel;
	public UILabel m_LevelLabel;
	public UILabel m_UpgradeCostLabel;
	public UILabel m_DescriptionLabel;
	public UILabel m_SpecialLabel;
	public UISprite m_UISprite;

	public GameObject m_UpgradeButton;
	public GameObject m_MaxButton;

	protected int CurSubShipIndex;
	// Use this for initialization
	void Start () {
		m_TitleLabel.text = Constant.COLOR_SUBSHIP_UPGRADE_TITLE + TextManager.Instance.GetString(102);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowUI(int _subshipindex)
	{
		NGUITools.SetActive (gameObject, true);
		CurSubShipIndex = _subshipindex;

		SubShipDescriptionInfo description = Managers.GameBalanceData.GetSubShipDescriptionInfo(CurSubShipIndex);
		UserSubShipData usersubshipdata = Managers.UserData.GetUserSubShipData(CurSubShipIndex);
		SubShipStatInfo cursubshipstatinfo = Managers.GameBalanceData.GetSubShipStatInfo(CurSubShipIndex, usersubshipdata.Level);
		SubShipStatInfo nextsubshipstatinfo = Managers.GameBalanceData.GetSubShipStatInfo(CurSubShipIndex, usersubshipdata.Level + 1);

		m_ShipNameLabel.text = Constant.COLOR_SUBSHIP_UPGRADE_NAME + description.ShipName;
		m_DescriptionLabel.text = Constant.COLOR_SUBSHIP_UPGRADE_DESCRIPTION + TextManager.Instance.GetReplacedString(description.ShipDescription);
		m_SpecialLabel.text = Constant.COLOR_SUBSHIP_UPGRADE_SPECIALDESCRIPTION + description.ShipSpecialDescription;

		m_UISprite.spriteName = ImageResourceManager.Instance.GetMainUISubShipImageName(CurSubShipIndex);
		m_UISprite.MakePixelPerfect();

		m_LevelLabel.text = Constant.COLOR_SUBSHIP_UPGRADE_LEVEL + "LV." + usersubshipdata.Level.ToString();

		if(nextsubshipstatinfo.ShipIndex == 0)
		{
			NGUITools.SetActive(m_UpgradeButton.gameObject, false);
			NGUITools.SetActive(m_MaxButton.gameObject, true);
		}else
		{
			NGUITools.SetActive(m_UpgradeButton.gameObject, true);
			NGUITools.SetActive(m_MaxButton.gameObject, false);
		}
		string coststring = "0";
		if(nextsubshipstatinfo.Cost != 0)
		{
			coststring = nextsubshipstatinfo.Cost.ToString("#,#");
		}
		m_UpgradeCostLabel.text = Constant.COLOR_WHITE + coststring;
	}

	public void HideUI()
	{
		NGUITools.SetActive (gameObject, false);
	}

	public void OnClickUpgradeButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(Managers.UserData != null && Managers.GameBalanceData != null){
			
			UserSubShipData selectshipdata = Managers.UserData.GetUserSubShipData(CurSubShipIndex);
			
			SubShipStatInfo shipinfo = Managers.GameBalanceData.GetSubShipStatInfo(CurSubShipIndex, selectshipdata.Level + 1);
			
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
							Managers.UserData.UpdateSequence++;
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
							Managers.UserData.UpdateSequence++;
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

			ShowUI(CurSubShipIndex);
		}
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		HideUI();
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			HideUI();
			return true;
		}
		return false;
	}
}
