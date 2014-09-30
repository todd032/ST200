using UnityEngine;
using System.Collections;

public class GameUIManager : MonoBehaviour {

	private static GameUIManager instance;
	public static GameUIManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(GameUIManager)) as GameUIManager;
			}
			return instance;
		}
	}

	public MainUI m_MainUI;
	public GameShopManager m_GameShopManager;
	public StageSelectUI m_StageSelectUI;
	public MainTutorial m_MainTutorial;

	public LuckyCouponAlertView m_LuckyCouponAlertView;
	public UIRootAlertView m_UIRootAlertView;
	void OnDestroy()
	{
		instance = null;
	}

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}

		if(Managers.Audio != null)
		{
			Managers.Audio.PlayBGMSound(AudioManager.BGM_SOUND.BGM_GAMEPLAY1,true);
		}

		SwitchToGameMainUI();

		
		_paymentPopupView = _paymentPopupViewObject.GetComponent<PaymentPopupView>() as PaymentPopupView ;
		_paymentPopupView.PaymentPopupViewEvent += PaymentPopupViewDelegate ;
		
		_paymentPopupView.InitLoadPaymentPopupView() ;

		m_UIRootAlertView.UIRootAlertViewEvent += UIRootAlertViewDelegate;

		InitializeGameTorpedoInfo();
	}

	void Update()
	{
		//if (Application.platform == RuntimePlatform.Android)
		{
			
			if (Input.GetKeyDown(KeyCode.Escape))
			{				
				OnEscapePress();
			}	

		}

#if UNITY_EDITOR
		//if(Input.GetKeyDown(KeyCode.Space))
		//{
		//	int gachaindex = Managers.GameBalanceData.GetGachaPet();
		//	int petgachaindex = 0;
		//	if(Managers.UserData.HasGamePet(gachaindex))
		//	{
		//		UserDataManager.GamePet pet = Managers.UserData.GetPet(gachaindex);
		//		pet.Level++;
		//		Managers.UserData.SetGamePet(pet);
		//		//Debug.Log("PET LEVELUP: " + pet.IndexNumber + " LEVEL: " + pet.Level);
		//		petgachaindex = pet.IndexNumber;
		//	}else
		//	{
		//		UserDataManager.GamePet pet = new UserDataManager.GamePet();
		//		pet.IndexNumber = gachaindex;
		//		pet.Level = 1;
		//		pet.IsSelect = 0;
		//		Managers.UserData.SetGamePet(pet);
		//		//Debug.Log("PET Created: " + pet.IndexNumber);
		//		petgachaindex = pet.IndexNumber;
		//	}
		//}
#endif
	}

	public bool OnEscapePress()
	{
		if(m_MainUI.OnEscapePress())
		{
			return true;
		}else if(m_UIRootAlertView.OnEscapePress())
		{
			return true;
		}else if(m_GameShopManager.OnEscapePress())
		{
			return true;
		}else if(_paymentPopupView.OnEscapePress()){

			return true;
		}else
		{
			LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_EXIT);
		}
		return false;
	}

	public void SwitchToGameMainUI()
	{
		m_DisplayTopBarSprite.spriteName = ImageResourceManager.Instance.GetTopBG(0);
		m_MainUI.gameObject.SetActive(true);
		//m_GameRankingManager.gameObject.SetActive(true);
		m_GameShopManager.gameObject.SetActive(false);
		m_StageSelectUI.gameObject.SetActive(false);

		m_MainUI.InitUI();

		LoadGameGoldAndGameJewelInfo();
		UpdateTorpedoUI();
		//m_GameRankingManager.UpdateUI ();
	}

	public void SwitchToGameShopManager()
	{
		m_DisplayTopBarSprite.spriteName = ImageResourceManager.Instance.GetTopBG(1);
		m_MainUI.gameObject.SetActive(false);
		//m_GameRankingManager.gameObject.SetActive(false);
		m_GameShopManager.gameObject.SetActive(true);
		m_StageSelectUI.gameObject.SetActive(false);

		m_GameShopManager.UpdateUI();

		LoadGameGoldAndGameJewelInfo();
		UpdateTorpedoUI();
	}

	public void SwitchToStageSelectManager()
	{
		m_DisplayTopBarSprite.spriteName = ImageResourceManager.Instance.GetTopBG(1);
		m_MainUI.gameObject.SetActive(false);
		//m_GameRankingManager.gameObject.SetActive(false);
		m_GameShopManager.gameObject.SetActive(false);
		m_StageSelectUI.gameObject.SetActive(true);

		m_StageSelectUI.InitUI();

		LoadGameGoldAndGameJewelInfo();
		UpdateTorpedoUI();
	}
	
	
	public UISprite m_DisplayTopBarSprite;
	public UILabel _displayGameGoldLabel ;
	public UILabel _displayGameJewelLabel ;
	
	public void LoadGameGoldAndGameJewelInfo(){
		
		if(Managers.UserData != null){
			
			int gameGold = Managers.UserData.GetCoinDisplayGold() ;
			if(gameGold == 0){
				_displayGameGoldLabel.text = Constant.COLOR_MAIN_TOP_LABEL + gameGold.ToString() ;
			}else{
				_displayGameGoldLabel.text = Constant.COLOR_MAIN_TOP_LABEL + gameGold.ToString("#,#") ;	
			}
			
			
			int gameJewel = Managers.UserData.GetJewelDisplay() ;
			if(gameJewel == 0) {
				_displayGameJewelLabel.text = Constant.COLOR_MAIN_TOP_LABEL + gameJewel.ToString() ;	
			}else {
				_displayGameJewelLabel.text = Constant.COLOR_MAIN_TOP_LABEL + gameJewel.ToString("#,#") ;	
			}
			
		}		
	}

	public TorpedoDisplayer m_TorpedoDisplayer;
	
	public UILabel _displayTorpedoLabel ;
	public UILabel _displayTorpedoTimeLabel ;
	public UISprite _displayTorpedoMaxSprite ;
	
	public void InitializeGameTorpedoInfo() {
		StartCoroutine("LoadGameTorpedoInfo") ;
	}
	
	private IEnumerator LoadGameTorpedoInfo(){
		
		while(true){
			
			UpdateTorpedoUI();
			
			yield return new WaitForSeconds(1f) ;
			
		}
		
	}

	public void UpdateTorpedoUI()
	{
		
		bool _isMax = false ;
		if(Managers.UserData != null){

			int torpedoCount = Managers.Torpedo.GetTorpedoCount(); //KakaoLeaderBoard.Instance.gameMe.heart;
			string timestring = "";
			if(torpedoCount == 0){
				_displayTorpedoLabel.text = "X "+ torpedoCount.ToString() ;
			}else{
				_displayTorpedoLabel.text = "X "+ torpedoCount.ToString("#,#") ;	
			}
			
			//Debug.Log("HEART COUNT: " +torpedoCount + " MAX : " +  KakaoLeaderBoard.Instance.gameInfo.rechargeable_heart);
			if(torpedoCount >= 5){
				//_displayTorpedoTimeLabel.text = "MAX" ;
				if(!_isMax){

					_isMax = true ;
				}
				
			}else{

				_isMax = false ;
				//}
				
				int remindTime = Managers.UserData.TorpedoRechargeNextTime - Managers.UserData.GetSyncServerTime() ;
				//Debug.Log("REMIND TIME: " + remindTime + "  REGEN START TIME: " + KakaoLeaderBoard.Instance.gameMe.heart_regen_starts_at + " SYNC: " + Managers.UserData.GetSyncServerTime());
				if(remindTime < 0){
					remindTime = 0 ;
				}
				
				
				if(remindTime > 0){
					
					int quotient = Mathf.FloorToInt(remindTime/60f) ; //System.Math.Floor(remindTime/60) ;
					int remainder = remindTime % 60 ;
					
					timestring = string.Format("{0:0}:{1:00}", quotient, remainder);
					
				}else{
					timestring = "0:00" ;	
				}
				
			}
			m_TorpedoDisplayer.UpdateUI(torpedoCount, timestring);
		}
	}

	public UIPanel _paymentPopupViewObject ;
	private PaymentPopupView _paymentPopupView ;

	public void OnClickPurchaseTorpedoButton() {
		
		//if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(Managers.UserData.TorpedoCount != 0)
		{
			return;
		}

		if ( Managers.Audio != null){
			Managers.Audio.PlayAllFXSoundStop() ;
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		}
		
		//_rankPanelView.DisableCurrentRankingPanel() ;
		//_paymentPopupView.LoadPaymentPopupView(3) ;
		LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_HEART);
	}

	public void OnClickPurchaseGameGoldButton() {
		
		//if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if ( Managers.Audio != null){
			Managers.Audio.PlayAllFXSoundStop() ;
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		}
		
		_paymentPopupView.LoadPaymentPopupView(Constant.ST200_POPUP_RECHARGE_COIN) ;
	}
	
	public void OnClickPurchaseGameJewelButton() {
		
		//if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if ( Managers.Audio != null){
			Managers.Audio.PlayAllFXSoundStop() ;
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		}
		
		_paymentPopupView.LoadPaymentPopupView(Constant.ST200_POPUP_RECHARGE_JEWEL) ;
	}
	
	//--Delegate
	public void PaymentPopupViewDelegate(PaymentPopupView paymentPopupView, int state) {
		if(state == 100) {
			LoadGameGoldAndGameJewelInfo() ;
		}
	}

	public void LoadPaymentPopupView(int _int)
	{
		_paymentPopupView.LoadPaymentPopupView(_int);
	}

	public void LoadUIRootAlertView(int _index)
	{
		m_UIRootAlertView.LoadUIRootAlertView(_index);
	}


	public void ShowLuckyCouponAlert()
	{
		m_LuckyCouponAlertView.ShowPopupView();
	}

	private void UIRootAlertViewDelegate(UIRootAlertView uiRootAlertView, int alertType) {
		//Debug.Log("HMMM...:" + alertType);

		if(alertType == Constant.ST200_POPUP_PURCHASE_OK){ // Purchase Ok
			//Debug.Log("?ASDASDSADSADA??");
			//Nothing...
		}else if(alertType == Constant.ST200_POPUP_RECHARGE_JEWEL){ // Recharge Jewel..
			_paymentPopupView.LoadPaymentPopupView(Constant.ST200_POPUP_RECHARGE_JEWEL) ;
		}else if(alertType == Constant.ST200_POPUP_RECHARGE_COIN){ // Recharge Gold..
			_paymentPopupView.LoadPaymentPopupView(Constant.ST200_POPUP_RECHARGE_COIN) ;
		}else if(alertType == Constant.ST200_POPUP_MESSAGE_EXIT){
			Application.Quit() ;
		}else if(alertType == Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT2)
		{
			//set purchase 
			Event_Purchase_SubShipSlot2();
		}else if(alertType == Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT3)
		{
			//set purchase 
			Event_Purchase_SubShipSlot3();
		}else if(alertType == Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT4)
		{
			//set purchase 
			Event_Purchase_SubShipSlot4();
		}else if(alertType == Constant.ST200_POPUP_RECHARGE_HEART)
		{
			//set purchase 
			Event_Recharge_Heart();
		}
	}


	#region UI_ALERT_VIEW DELETATE event functions

	protected void Event_Recharge_Heart()
	{
		if(Managers.UserData != null && Managers.GameBalanceData != null){
			
			//Debug.Log("HELLO?");
			int costvalue = Managers.GameBalanceData.TorpedoRechargeCost;
			int spendState = Managers.UserData.SetSpendJewel(costvalue) ;
			
			if(spendState == 1) {
				
				if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
				
				Managers.UserData.TorpedoCount = Managers.GameBalanceData.TorpedoMaxValue;
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
			
			UpdateTorpedoUI();
		}
	}


	protected void Event_Purchase_SubShipSlot2()
	{
		if(Managers.UserData != null && Managers.GameBalanceData != null){

			//Debug.Log("HELLO?");
			int costvalue = Managers.GameBalanceData.SubShipUnlockCost2;
			int spendState = Managers.UserData.SetSpendJewel(costvalue) ;
					
			if(spendState == 1) {
				
				if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);

				Managers.UserData.SubShipEquipAvailableSlotCount = 2;
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

			m_MainUI.UpdateUI();
		}
	}

	protected void Event_Purchase_SubShipSlot3()
	{
		if(Managers.UserData != null && Managers.GameBalanceData != null){
			
			int costvalue = Managers.GameBalanceData.SubShipUnlockCost3;
			int spendState = Managers.UserData.SetSpendJewel(costvalue) ;
			
			if(spendState == 1) {
				
				if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
				
				Managers.UserData.SubShipEquipAvailableSlotCount = 3;
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
			m_MainUI.UpdateUI();
		}
	}

	protected void Event_Purchase_SubShipSlot4()
	{
		if(Managers.UserData != null && Managers.GameBalanceData != null){
			
			int costvalue = Managers.GameBalanceData.SubShipUnlockCost4;
			int spendState = Managers.UserData.SetSpendJewel(costvalue) ;
			
			if(spendState == 1) {
				
				if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
				
				Managers.UserData.SubShipEquipAvailableSlotCount = 4;
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
			m_MainUI.UpdateUI();
		}
	}

	#endregion
}
