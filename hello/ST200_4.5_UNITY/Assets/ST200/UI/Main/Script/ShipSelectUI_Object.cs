using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipSelectUI_Object : MonoBehaviour {

	#region Ship Region
	public int m_CurShipIndex;	
	public GameObject m_SelectShipButton;
	public GameObject m_BuyShipButton_Gold;
	public UILabel m_BuyShipLabel_Gold;
	public GameObject m_BuyShipButton_Cash;
	public UILabel m_BuyShipLabel_Cash;
	public GameObject m_UpgradeShipButton;
	public GameObject m_MaxUpgradeShipButton;
	public UILabel m_UpgradeShipLabel;
	
	public UISprite m_PlayerShipLockedSprite;
	public UISprite m_PlayerShipImage;
	public UILabel m_PlayerShipNameLabel;
	public UILabel m_PlayerShipDescriptionLabel;
	public UILabel m_PlayerShipSpecialDescriptionLabel;
	public UILabel m_PlayerShipLevelLabel;	
	
	public ShipSelectUI_StatDisplay m_AttackStatDisplay;
	public ShipSelectUI_StatDisplay m_DefendStatDisplay;
	public ShipSelectUI_StatDisplay m_MovementStatDisplay;
	
	public List<ShipSelectShipAttackDisplayer> m_ShipAttackDisplayerList = new List<ShipSelectShipAttackDisplayer>();
	public ParticleSystem m_UpgradeParticleSystem;
	#endregion
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void InitUI(int _index)
	{
		m_CurShipIndex = _index;
		UpdateUI();
		
		m_AttackStatDisplay.Init(Constant.COLOR_MAIN_SHIP_INFO + TextManager.Instance.GetString (56));
		m_DefendStatDisplay.Init(Constant.COLOR_MAIN_SHIP_INFO + TextManager.Instance.GetString (57));
		m_MovementStatDisplay.Init(Constant.COLOR_MAIN_SHIP_INFO + TextManager.Instance.GetString (58));
	}
	
	public void UpdateUI()
	{
		UserShipData usershipdata = Managers.UserData.GetUserShipData(m_CurShipIndex);
		ShipStatInfo shipstatinfo = Managers.GameBalanceData.GetShipStatInfo(m_CurShipIndex, usershipdata.Level);
		ShipStatInfo nextshipstatinfo = Managers.GameBalanceData.GetShipStatInfo(m_CurShipIndex, usershipdata.Level + 1);
		if(!usershipdata.IsPurchase)
		{
			NGUITools.SetActive(m_SelectShipButton.gameObject, false);
			if(shipstatinfo.ValueType == 1)
			{
				NGUITools.SetActive(m_BuyShipButton_Gold.gameObject, true);
				NGUITools.SetActive(m_BuyShipButton_Cash.gameObject, false);
			}else
			{
				NGUITools.SetActive(m_BuyShipButton_Gold.gameObject, false);
				NGUITools.SetActive(m_BuyShipButton_Cash.gameObject, true);
			}
			NGUITools.SetActive(m_UpgradeShipButton.gameObject, false);
			NGUITools.SetActive(m_MaxUpgradeShipButton.gameObject, false);
			
			NGUITools.SetActive (m_PlayerShipLockedSprite.gameObject, usershipdata.IsLocked);
		}else
		{
			NGUITools.SetActive (m_PlayerShipLockedSprite.gameObject, false);
			if(usershipdata.IsSelect)
			{
				NGUITools.SetActive(m_SelectShipButton.gameObject, false);
				NGUITools.SetActive(m_BuyShipButton_Gold.gameObject, false);
				NGUITools.SetActive(m_BuyShipButton_Cash.gameObject, false);
				if(Managers.GameBalanceData.GetShipStatInfo(usershipdata.IndexNumber, usershipdata.Level + 1).ShipIndex == 0)
				{
					//if max
					NGUITools.SetActive(m_UpgradeShipButton.gameObject, false);
					NGUITools.SetActive(m_MaxUpgradeShipButton.gameObject, true);
				}else
				{
					//if not max
					NGUITools.SetActive(m_UpgradeShipButton.gameObject, true);
					NGUITools.SetActive(m_MaxUpgradeShipButton.gameObject, false);
				}
			}else
			{
				NGUITools.SetActive(m_SelectShipButton.gameObject, true);
				NGUITools.SetActive(m_BuyShipButton_Gold.gameObject, false);
				NGUITools.SetActive(m_BuyShipButton_Cash.gameObject, false);
				NGUITools.SetActive(m_UpgradeShipButton.gameObject, false);
				NGUITools.SetActive(m_MaxUpgradeShipButton.gameObject, false);
			}
		}
		string buycost = "0";
		if(shipstatinfo.Cost != 0)
		{
			buycost = shipstatinfo.Cost.ToString("#,#");
		}
		
		string upgradecost = "0";
		if(nextshipstatinfo.Cost != 0)
		{
			upgradecost = nextshipstatinfo.Cost.ToString("#,#");
		}
		
		m_BuyShipLabel_Gold.text = Constant.COLOR_MAIN_SHIP_COST + buycost;
		m_BuyShipLabel_Cash.text = Constant.COLOR_MAIN_SHIP_COST + buycost;
		m_UpgradeShipLabel.text = Constant.COLOR_MAIN_SHIP_COST + upgradecost;
		//Debug.Log("? index: " + m_CurShipIndex + " SELECTED: " + usershipdata.IsSelect);
		ShipDescriptionInfo descriptioninfo = Managers.GameBalanceData.GetShipDescriptionInfo(m_CurShipIndex);
		
		//Debug.Log("index: " + m_CurShipIndex + " INN: " +descriptioninfo.ShipIndex +  "  DESCRIP: " + descriptioninfo.ShipDescription);
		m_PlayerShipImage.spriteName = ImageResourceManager.Instance.GetMainUIShipImageName(m_CurShipIndex);
		m_PlayerShipNameLabel.text = Constant.COLOR_MAIN_NAME + TextManager.Instance.GetString (descriptioninfo.ShipNameTextIndex);
		m_PlayerShipDescriptionLabel.text =  Constant.COLOR_MAIN_SHIP_DESCRIPTION + TextManager.Instance.GetString(descriptioninfo.ShipDescriptionTextIndex);
		m_PlayerShipSpecialDescriptionLabel.text = Constant.COLOR_MAIN_SHIP_SPECIAL_DESCRIPTION + TextManager.Instance.GetString(descriptioninfo.ShipSpecialDescriptionTextIndex);
		m_PlayerShipLevelLabel.text = Constant.COLOR_MAIN_SHIP_LEVEL + "LV."+usershipdata.Level.ToString();
		
		m_AttackStatDisplay.UpdateUI(shipstatinfo.AttackGrade , 100f);
		m_DefendStatDisplay.UpdateUI(shipstatinfo.DefenseGrade , 100f);
		m_MovementStatDisplay.UpdateUI(shipstatinfo.MovementGrade , 100f);
		
		for(int i = 0; i < m_ShipAttackDisplayerList.Count; i++)
		{
			m_ShipAttackDisplayerList[i].gameObject.SetActive(false);
		}
		m_ShipAttackDisplayerList[usershipdata.IndexNumber - 1].gameObject.SetActive(true);	

	}

	public void OnClickShipBuyButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(Managers.UserData != null && Managers.GameBalanceData != null){
			
			UserShipData selectshipdata = Managers.UserData.GetUserShipData(m_CurShipIndex);

			if(selectshipdata.IsLocked)
			{
				if(selectshipdata.IndexNumber == 4)
				{
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SHIP4_LOCKED);
				}else if(selectshipdata.IndexNumber == 3)
				{
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SHIP3_LOCKED);
				}else if(selectshipdata.IndexNumber == 8)
				{
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SHIP8_LOCKED);
				}

			}else if(!selectshipdata.IsPurchase){
				
				ShipStatInfo shipinfo = Managers.GameBalanceData.GetShipStatInfo(m_CurShipIndex, 1);

				int valueType = shipinfo.ValueType ;
				int submarineValue = shipinfo.Cost ;
				
				/// Money Process..
				if(valueType == 1){
					
					int spendState = Managers.UserData.SetSpendGold(submarineValue) ;
					
					if(spendState == 1) {
						
						if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
						
						ST200KLogManager.Instance.SaveShopSubmarinePurchase(m_CurShipIndex, valueType, submarineValue);
						selectshipdata.IsPurchase = true;
						Managers.UserData.SetSelectedUserShipData(selectshipdata);

						int itemcode = m_CurShipIndex + Constant.ST200_ITEM_SHIP_STARTCODE - 1;
						Managers.UserData.AddPurchaseList(itemcode);
						//send

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
						ST200KLogManager.Instance.SaveShopSubmarinePurchase(m_CurShipIndex, valueType, submarineValue);
						selectshipdata.IsPurchase = true;
						Managers.UserData.SetSelectedUserShipData(selectshipdata);
						//ReLoad...

						int itemcode = m_CurShipIndex + Constant.ST200_ITEM_SHIP_STARTCODE - 1;
						Managers.UserData.AddPurchaseList(itemcode);
						//send

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
				
			}else{
				//Debug.Log("Already purchased Character...") ;
			}
			GameUIManager.Instance.m_MainUI.UpdateUI();
		}
	}
	
	public void OnClickShipUpgradeButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(Managers.UserData != null && Managers.GameBalanceData != null){			
			GameUIManager.Instance.m_MainUI.m_ShipSelectUI.m_UpgradeConfirmPopUp.ShowPopup(m_CurShipIndex);
		}
	}
	
	public void OnClickShipSelectButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		UserShipData curshipdata = Managers.UserData.GetUserShipData(m_CurShipIndex);
		curshipdata.IsSelect = true;
		Managers.UserData.SetSelectedUserShipData(curshipdata);
		
		GameUIManager.Instance.m_MainUI.UpdateUI();
	}
	
	public void DisplayUpgradeEffect()
	{
		StartCoroutine(IEUpgradeEffectAnimation());
	}
	
	protected IEnumerator IEUpgradeEffectAnimation()
	{
		m_UpgradeParticleSystem.Stop();
		m_UpgradeParticleSystem.Play();
		UserShipData curshipdata = Managers.UserData.GetCurrentUserShipData();
		ShipStatInfo prevstatinfo = Managers.GameBalanceData.GetShipStatInfo(curshipdata.IndexNumber, curshipdata.Level - 1);
		ShipStatInfo curstatinfo = Managers.GameBalanceData.GetShipStatInfo(curshipdata.IndexNumber, curshipdata.Level);
		
		float labelupdatetimer = 0f;
		float labelupdatemaxtime = 1f;
		while(labelupdatetimer < labelupdatemaxtime)
		{
			labelupdatetimer += Time.deltaTime;
			m_AttackStatDisplay.UpdateUI(prevstatinfo.AttackGrade + (curstatinfo.AttackGrade - prevstatinfo.AttackGrade) * labelupdatetimer / labelupdatemaxtime,
			                             100f);
			m_DefendStatDisplay.UpdateUI(prevstatinfo.DefenseGrade + (curstatinfo.DefenseGrade - prevstatinfo.DefenseGrade) * labelupdatetimer / labelupdatemaxtime,
			                             100f);
			m_MovementStatDisplay.UpdateUI(prevstatinfo.MovementGrade + (curstatinfo.MovementGrade - prevstatinfo.MovementGrade) * labelupdatetimer / labelupdatemaxtime,
			                               100f);
			yield return new WaitForFixedUpdate();
		}
		
		GameUIManager.Instance.m_MainUI.UpdateUI();
		yield break;
	}
}
