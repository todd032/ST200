using UnityEngine;
using System.Collections;

public class GameShopManager : MonoBehaviour {
 
	public GameUIManager m_UIManager;
	//
	public IndicatorPopupView _indicatorPopupView ;

	public UILabel m_TitleLabel;
	public UILabel m_ReadyLabel;

	private bool _isTutorialMode = false ;
	
	private void Awake(){


		m_TitleLabel.text = Constant.COLOR_READY_TITLE + TextManager.Instance.GetString(115);
		m_ReadyLabel.text = Constant.COLOR_MAIN_SHIP_READY + TextManager.Instance.GetString(116);
		Managers.UserData.PreviousPageIndex = 2 ;
		
		//
		_indicatorPopupView.IndicatorPopupViewEvent += null ;
				
		if ( Managers.Audio != null) Managers.Audio.PlayBGMSound(AudioManager.BGM_SOUND.BGM_Main,true);

		InitializeGameItemInfo() ;
		
		InitializeGameItemExplainInfo() ;
		InitGameItemStatus();
		//_subweaponGachaPopupView.InitializeSubweaponGachaPopupView() ;
		
		//
		_indicatorPopupView.InitLoadIndicatorPopupView() ;

		if(Managers.UserData != null){
			if(Managers.UserData.GetTutorialState()){

				_isTutorialMode = false ;

			}else{

//				_isTutorialMode = true ;
//				_shopSceneTutorialView.LoadShopSceneTutorialView() ;

				// 테스트용 - 튜토리얼 막기.
				_isTutorialMode = false ;

			}
		}
	}
	
	private void Start () {

	}


	// Update is called once per frame
	private void Update () {	

	}
	
	public void UpdateUI()
	{
		InitGameItemStatus();
		UpdateButtonUI() ;
		LoadGameItemExplain(_selectItemIndex) ;
		UpdateGameItemEquip();
	}
	
	private void UIRootAlertViewDelegate(UIRootAlertView uiRootAlertView, int alertType) {
		if(alertType == 1){ // Purchase Ok
			//Nothing...
		}else if(alertType == 2){ // Recharge Jewel..
			GameUIManager.Instance.LoadPaymentPopupView(2) ;
		}else if(alertType == 3){ // Recharge Gold..
			GameUIManager.Instance.LoadPaymentPopupView(1) ;
		}else if(alertType == 4) { //Recharge Torpedo
			GameUIManager.Instance.LoadPaymentPopupView(3) ;
		}		
	}
	
	
	public UISprite _dontTouchPanel ;


	// Game Item Explain
	public UILabel _itemNameLabel ;
	public UILabel _itemExplainLabel ;

	public GameObject m_BuyButton_Coin;
	public GameObject m_BuyButton_Cash;
	public UILabel m_ItemPurchaseValueLabel ;
	public UILabel m_ItemPurchaseValueLabel2;

	private void InitializeGameItemExplainInfo(){
		
		
	}
	
	private void LoadGameItemExplain(int selectItemType){
		
		string languageCode = "En" ; //Default..
		
		if(Managers.UserData != null){
			languageCode = Managers.UserData.LanguageCode ;
		}
		
		if(Managers.GameBalanceData != null){

			GameBalanceDataManager.GameItemMessageData messagedata = Managers.GameBalanceData.GetGameItemMessage(selectItemType);
			_itemNameLabel.text = Constant.COLOR_READY_ITEMNAME + TextManager.Instance.GetString ( messagedata.ItemNameTextIndex) ;
			_itemExplainLabel.text = Constant.COLOR_READY_ITEMDESCRIPTION +  TextManager.Instance.GetString ( messagedata.ItemDescriptionTextIndex);
			
			GameBalanceDataManager.GameItemBalance gameItemBalance = Managers.GameBalanceData.GetGameItemBalance(selectItemType) ;
			
			int valueType = gameItemBalance.ValueType ;
			int currentItemValue = gameItemBalance.ItemValue ;
			
			string valueTypeString = "[ffffff]" ;
			if(valueType == 1){
				//valueTypeString = "[ffc800]" ;
			}else if(valueType == 2){
				//valueTypeString = "[00ffff]" ;
			}

			if(valueType == 1)
			{
				NGUITools.SetActive(m_BuyButton_Coin.gameObject, true);
				NGUITools.SetActive(m_BuyButton_Cash.gameObject, false);
			}else if(valueType == 2)
			{
				NGUITools.SetActive(m_BuyButton_Coin.gameObject, false);
				NGUITools.SetActive(m_BuyButton_Cash.gameObject, true);
			}

			m_ItemPurchaseValueLabel.text = valueTypeString + currentItemValue.ToString("#,#") ;
			m_ItemPurchaseValueLabel2.text = valueTypeString + currentItemValue.ToString("#,#") ;
		}
		
	}

	public void UpdateButtonUI()
	{
		if ( Managers.UserData != null)  {
			
			m_ShoutItem.UpdateUI(_selectItemIndex == Constant.ST200_ITEM_SHOUT,
			                     Managers.UserData.GetGameItemEquip(Constant.ST200_ITEM_SHOUT),
			                     Managers.UserData.GetGameItemCount(Constant.ST200_ITEM_SHOUT));
			m_SingijeonItem.UpdateUI(_selectItemIndex == Constant.ST200_ITEM_SINGIJEON,
			                         Managers.UserData.GetGameItemEquip(Constant.ST200_ITEM_SINGIJEON),
			                         Managers.UserData.GetGameItemCount(Constant.ST200_ITEM_SINGIJEON));
			m_ContinueItem.UpdateUI(_selectItemIndex == Constant.ST200_ITEM_REVIVE,
			                        Managers.UserData.GetGameItemEquip(Constant.ST200_ITEM_REVIVE),
			                        Managers.UserData.GetGameItemCount(Constant.ST200_ITEM_REVIVE));
			m_PowerUpItem.UpdateUI(_selectItemIndex == Constant.ST200_ITEM_POWERUP,
			                       Managers.UserData.GetGameItemEquip(Constant.ST200_ITEM_POWERUP),
			                       Managers.UserData.GetGameItemCount(Constant.ST200_ITEM_POWERUP));
			m_HealthUpItem.UpdateUI(_selectItemIndex == Constant.ST200_ITEM_HEALTHUP,
			                        Managers.UserData.GetGameItemEquip(Constant.ST200_ITEM_HEALTHUP),
			                        Managers.UserData.GetGameItemCount(Constant.ST200_ITEM_HEALTHUP));
			
		}

		/*
		m_ShoutItem.SetSelected(false);
		m_SingijeonItem.SetSelected(false);
		m_ContinueItem.SetSelected(false);
		m_PowerUpItem.SetSelected(false);
		m_HealthUpItem.SetSelected(false);

		if(_selectItemIndex == Constant.ST200_ITEM_SHOUT)
		{
			m_ShoutItem.SetSelected(true);
		}else if(_selectItemIndex == Constant.ST200_ITEM_SINGIJEON)
		{
			m_SingijeonItem.SetSelected(true);
		}else if(_selectItemIndex == Constant.ST200_ITEM_REVIVE)
		{
			m_ContinueItem.SetSelected(true);
		}else if(_selectItemIndex == Constant.ST200_ITEM_POWERUP)
		{
			m_PowerUpItem.SetSelected(true);
		}else if(_selectItemIndex == Constant.ST200_ITEM_HEALTHUP)
		{
			m_HealthUpItem.SetSelected(true);
		}
		*/
	}

	public void OnClickShoutButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		_selectItemIndex = Constant.ST200_ITEM_SHOUT;
		CheckGameItemCanBuy(_selectItemIndex);
		UpdateUI();
	}

	public void OnClickSingijeonButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		_selectItemIndex = Constant.ST200_ITEM_SINGIJEON;
		CheckGameItemCanBuy(_selectItemIndex);
		UpdateUI();
	}

	public void OnClickReviveButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		_selectItemIndex = Constant.ST200_ITEM_REVIVE;
		CheckGameItemCanBuy(_selectItemIndex);
		UpdateUI();
	}

	public void OnClickPowerUpButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		_selectItemIndex = Constant.ST200_ITEM_POWERUP;
		CheckGameItemCanBuy(_selectItemIndex);
		UpdateUI();
	}

	public void OnClickHealthUpButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		_selectItemIndex = Constant.ST200_ITEM_HEALTHUP;
		CheckGameItemCanBuy(_selectItemIndex);
		UpdateUI();
	}

	public void OnClickGameItemBuy()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		BuyItem(_selectItemIndex);
	}

	protected void InitGameItemStatus()
	{
		int gamecoin = 0;
		int gamejewel = 0;
		for(int i = 0; i < Managers.GameBalanceData._gameItemBalanceList.Count; i++)
		{
			GameBalanceDataManager.GameItemBalance gameitembalance = Managers.GameBalanceData._gameItemBalanceList[i];
			UserDataManager.GameItem gameitem = Managers.UserData.GetGameItem(gameitembalance.ItemType);

			if(Managers.UserData.GetGameItemEquip(gameitem.ItemType))
			{
				if(gameitem.ItemCount > 0)
				{
					
				}else
				{
					if(gameitembalance.ValueType == 1)
					{
						gamecoin += gameitembalance.ItemValue;
					}else
					{
						gamejewel += gameitembalance.ItemValue;
					}
				}
			}
		}

		if(gamecoin > Managers.UserData.GameCoin || gamejewel > Managers.UserData.GameJewel)
		{
			//Debug.Log("ASDASWDWDWDW???");
			Managers.UserData.ResetGameItemEquip();
		}
	}

	protected void CheckGameItemCanBuy(int _index)
	{
		UserDataManager.GameItem curgameitem = Managers.UserData.GetGameItem(_index);
		if(Managers.UserData.GetGameItemEquip(_index))
		{
			Managers.UserData.ToggleGameItemEquip(_selectItemIndex);
		}else
		{
			if(curgameitem.ItemCount > 0)
			{
				Managers.UserData.ToggleGameItemEquip(_selectItemIndex);
			}else
			{
				GameBalanceDataManager.GameItemBalance gameitembalance = Managers.GameBalanceData.GetGameItemBalance(_index);
				int valuetype = gameitembalance.ValueType;
				int itemvalue = gameitembalance.ItemValue;
				if(valuetype == 1)
				{
					if(Managers.UserData.ShopDisplayGameCoin >= itemvalue)
					{
						Managers.UserData.ToggleGameItemEquip(_selectItemIndex);
					}else
					{
						GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_COIN);
					}
				}else
				{
					if(Managers.UserData.ShopDisplayGameJewel >= itemvalue)
					{
						Managers.UserData.ToggleGameItemEquip(_selectItemIndex);
					}else
					{
						GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_JEWEL);
					}
				}
			}
		}
	}

	protected void UpdateGameItemEquip()
	{
		Managers.UserData.ShopDisplayGameCoin = Managers.UserData.GameCoin;
		Managers.UserData.ShopDisplayGameJewel = Managers.UserData.GameJewel;
		for(int i = 0; i < Managers.GameBalanceData._gameItemBalanceList.Count; i++)
		{
			GameBalanceDataManager.GameItemBalance gameitembalance = Managers.GameBalanceData._gameItemBalanceList[i];
			UserDataManager.GameItem gameitem = Managers.UserData.GetGameItem(gameitembalance.ItemType);

			if(Managers.UserData.GetGameItemEquip(gameitem.ItemType))
			{
				if(gameitem.ItemCount > 0)
				{

				}else
				{
					if(gameitembalance.ValueType == 1)
					{
						//Debug.Log("HAHA");
						Managers.UserData.ShopDisplayGameCoin -= gameitembalance.ItemValue;
					}else
					{
						Managers.UserData.ShopDisplayGameJewel -= gameitembalance.ItemValue;
					}
				}
			}
		}

		GameUIManager.Instance.LoadGameGoldAndGameJewelInfo();
	}

	protected void BuyItem(int _itemcode)
	{
		if(Managers.GameBalanceData != null){
			
			GameBalanceDataManager.GameItemBalance gameItemBalance = Managers.GameBalanceData.GetGameItemBalance(_itemcode) ;
			
			int valueType = gameItemBalance.ValueType ;
			int currentItemValue = gameItemBalance.ItemValue ;

			if(Managers.UserData != null){
				
				/// Money Process..
				if(valueType == 1){
					
					int spendState = Managers.UserData.SetSpendGold(currentItemValue) ;
					
					if(spendState == 1) {
						
						if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
						
						Managers.UserData.SetPurchaseGameItem(	_itemcode, 1) ;
						
						//ReLoad...
						UpdateButtonUI() ;
						
						
						if(Managers.DataStream != null){
							if(Managers.UserData != null){
								
								Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;

								Managers.UserData.UpdateSequence++;
								UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
								
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
								Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
							}
						}
						
						StartCoroutine(Managers.DataStream.Network_SaveLog(4, _itemcode)) ; //4 : ItemShop
						ST200KLogManager.Instance.SaveShopItemPurchase(_itemcode, currentItemValue);
						// ReLoad...Cash..
						GameUIManager.Instance.LoadGameGoldAndGameJewelInfo() ;
						
					}else{
						// Pop Up Payment Window...
						//Debug.Log("Pop Up Payment Window... Gold") ;
						GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_COIN);
					}
					
				}else if(valueType == 2){
					
					int spendState = Managers.UserData.SetSpendJewel(currentItemValue) ;
					
					if(spendState == 1) {
						
						if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
						
						Managers.UserData.SetPurchaseGameItem(	_itemcode, 1) ;
						
						//ReLoad...
						UpdateButtonUI() ;
						
						
						if(Managers.DataStream != null){
							
							if(Managers.UserData != null){
								
								Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
								Managers.UserData.UpdateSequence++;
								UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
								
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
								Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
							}
						}
												
						StartCoroutine(Managers.DataStream.Network_SaveLog(4, _itemcode)) ; //4 : ItemShop
						
						// ReLoad...Cash..
						GameUIManager.Instance.LoadGameGoldAndGameJewelInfo() ;
						
					}else{
						// Pop Up Payment Window...	
						//Debug.Log("Pop Up Payment Window... Jewel") ;
						GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_JEWEL);
					}
				}
			}
		}
	}

	// Game Item Button
	public ItemButtonSelectorSpriteObject _itemSelectSprite ;

	public GameShopItemButtonObject m_ShoutItem;
	public GameShopItemButtonObject m_SingijeonItem;
	public GameShopItemButtonObject m_ContinueItem;
	public GameShopItemButtonObject m_PowerUpItem;
	public GameShopItemButtonObject m_HealthUpItem;

	private int _selectItemIndex ;  // 1:StartBooster , 2:Shield , 3:LastBooster , 4:Revive , 5:Brake , 6:EMP , 7:Subwapon , 8:Gold , 9:Jewel
	
	
	private void InitializeGameItemInfo(){
		_selectItemIndex = Constant.ST200_ITEM_SHOUT;
		Managers.UserData.ShopDisplayGameCoin = Managers.UserData.GameCoin;
		//Managers.UserData.ResetGameItemEquip();
		UpdateUI();
	}



	// 월드랭킹 수정부분 (14.04.12 by 최원석) - Start
	public void OnClickGameStartButton(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_GameStart,false);
		
		NGUITools.SetActive(_dontTouchPanel.gameObject, true) ;

		if (Managers.Torpedo.HaveTorpedo()){
				
			// Connect Icon Start!!!!
			_indicatorPopupView.LoadIndicatorPopupView() ;
			//

			//add item for purchased
			for(int i = 0; i < Managers.GameBalanceData._gameItemBalanceList.Count; i++)
			{
				GameBalanceDataManager.GameItemBalance gameitembalance = Managers.GameBalanceData._gameItemBalanceList[i];
				UserDataManager.GameItem gameitem = Managers.UserData.GetGameItem(gameitembalance.ItemType);
				
				if(Managers.UserData.GetGameItemEquip(gameitem.ItemType) && gameitem.ItemCount == 0)
				{
					//Debug.Log("SET PURCHASE:" + gameitem.ItemType);
					Managers.UserData.SetPurchaseGameItem(gameitem.ItemType, 1);

					int itemcode = gameitem.ItemType;
					Managers.UserData.AddPurchaseList(itemcode);
					//
				}
			}
			//end 

			Managers.Torpedo.ConsumeTorpedo();
			Managers.UserData.GameJewel = Managers.UserData.ShopDisplayGameJewel;
			Managers.UserData.GameCoin = Managers.UserData.ShopDisplayGameCoin;

			if (Managers.DataStream != null){
				
				if (Managers.UserData != null){

					// 카카오 리더보드에 점수 저장하기.
					#if UNITY_EDITOR

					// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
					Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
						//Debug.Log("GAME START RESULT: " + intResult_Code_Input);

						_indicatorPopupView.RemoveIndicatorPopupView() ;
						
						if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK){
							
							_indicatorPopupView.RemoveIndicatorPopupView() ;
							
							NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
							
							ST200KLogManager.Instance.SaveGameStart();
							ST200KLogManager.Instance.SendToServer();

							Application.LoadLevel(Constant.SCENE_GameMainLoadingScene);
						} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network){
							Managers.Torpedo.AddTorpedo(1);
							GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ; // 통신상태가 불안정합니다. 다시 실행해 주세요.
							
						}else if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
						{
							NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
							Managers.Torpedo.AddTorpedo(1);
							GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
						}else 
						{						
							NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
							Managers.Torpedo.AddTorpedo(1);
							GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
						}
					};
					Managers.UserData.UpdateSequence++;
					UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
					
					Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
					// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
					
					#else

					Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
						
						_indicatorPopupView.RemoveIndicatorPopupView() ;
						
						if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK){
							
							NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
							
							ST200KLogManager.Instance.SaveGameStart();
							ST200KLogManager.Instance.SendToServer();
							Application.LoadLevel(Constant.SCENE_GameMainLoadingScene);
							
						} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network){
							
							GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ; // 통신상태가 불안정합니다. 다시 실행해 주세요.
							Managers.Torpedo.AddTorpedo(1);
						} else if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
						{
							NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
							Managers.Torpedo.AddTorpedo(1);
							GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
						}else {
							
							NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
							Managers.Torpedo.AddTorpedo(1);
							GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
						}
					};

					Managers.UserData.UpdateSequence++;
					UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
					
					Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);

					#endif
					
				}
			}
			Debug.Log("GAME START CLICKED");
		}else{
			
			NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
			
			GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_HEART) ; //Go PaymentView Torpedo....
		}
	}

	public void OnClickExit (){
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		Managers.UserData.ShopDisplayGameCoin = Managers.UserData.GameCoin;
		GameUIManager.Instance.SwitchToStageSelectManager();
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			m_UIManager.SwitchToGameMainUI();
			return true;
		}
		return false;
	}
}