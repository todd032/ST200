using UnityEngine;
using System.Collections;
using System.Collections.Generic ;


public class PaymentPopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void PaymentPopupViewDelegate(PaymentPopupView paymentPopupView, int state);
	protected PaymentPopupViewDelegate _paymentPopupViewDelegate ;
	public event PaymentPopupViewDelegate PaymentPopupViewEvent {
		add{
			//_paymentPopupViewDelegate = null ;
			
			//if (_paymentPopupViewDelegate == null)
			if(_paymentPopupViewDelegate != value)
			{
        		_paymentPopupViewDelegate += value;
			}
        }
		
		remove{
            _paymentPopupViewDelegate -= value;
		}
	}

	public GameObject m_PaymentEventObject;
	public GameObject _paymentPopupGoldInfoViewGameObject ; 
	private PaymentPopupGoldInfoView _paymentPopupGoldInfoView ;
	public UISprite m_GoldPopUpViewButton;
	
	public GameObject _paymentPopupJewelInfoViewGameObject ;
	private PaymentPopupJewelInfoView _paymentPopupJewelInfoView ;
	public UISprite m_JewelPopUpViewButton;

	public GameObject _paymentPopupAlertViewGameObject ;
	private PaymentPopupAlertView _paymentPopupAlertView ;
	
	//public GameObject _paymentPopupChocolateAlertViewGameObject ; //Remove !!!!!
	//private PaymentPopupChocolateAlertView _paymentPopupChocolateAlertView ; //Remove !!!!!
	//
	public IndicatorPopupView _indicatorPopupView ;
	//

	public PaymentBuyConfirmView m_PaymentConfirmView;
	
	//private int _gainChocolateCount = -1 ;
	//private bool _isTStorePaymenting = false ;

	private GameBalanceDataManager.PaymentBuyInfoBalance m_paymentBuyInfoBalance;
	private int m_paymentItemValueType;
	private float m_paymentItemValue;
	private int m_productValueType;
	private int m_productValue;

	private string m_strInApp_Code;
	private int m_intInApp_Price;

	public UILabel m_TitleLabel;
	public UILabel m_GoldLabel;
	public UILabel m_CoinLabel;

	private void Awake(){

		m_strInApp_Code = "";
		m_intInApp_Price = 0;

		m_TitleLabel.text = Constant.COLOR_STORE_TITLE + TextManager.Instance.GetString(87);
		m_GoldLabel.text = Constant.COLOR_STORE_TAP + TextManager.Instance.GetString(88);
		m_CoinLabel.text = Constant.COLOR_STORE_TAP + TextManager.Instance.GetString(89);

	}
	
	private void Start() {

	}

	public void GoldInfoViewDelegate(PaymentGoldBuyButton _paymentButton, int _paymentBuyButtonIndexNumber) {

		m_PaymentConfirmView.LoadView(_paymentButton, null, null, _paymentBuyButtonIndexNumber);
	}

	public void JewelInfoViewDelegate(PaymentJewelBuyButton _paymentButton, int _paymentBuyButtonIndexNumber) {

		m_PaymentConfirmView.LoadView(null, _paymentButton, null, _paymentBuyButtonIndexNumber);
	}

	public void TorpedoInfoViewDelegate(PaymentTorpedoBuyButton _paymentButton, int _paymentBuyButtonIndexNumber) {

		if (Managers.UserData != null && Managers.GameBalanceData != null) {
			
			m_paymentBuyInfoBalance = Managers.GameBalanceData.GetPaymentTorpedoBuyInfoBalance(_paymentBuyButtonIndexNumber) ;
			
			m_paymentItemValueType = m_paymentBuyInfoBalance.PaymentItemValueType;
			m_paymentItemValue = m_paymentBuyInfoBalance.PaymentItemValue ;
			m_productValueType = m_paymentBuyInfoBalance.ProductValueType ;
			m_productValue = m_paymentBuyInfoBalance.ProductValue ;

			if(0 + m_productValue > 999)
			{
				//set type as over count 999
				_paymentPopupAlertView.LoadPaymentPopupAlertView(71) ;
			}else
			{
				m_PaymentConfirmView.LoadView(null, null, _paymentButton, _paymentBuyButtonIndexNumber);
			}
		}
	}
	
	//Delegate
	public void PaymentPopupGoldInfoViewDelegate(PaymentGoldBuyButton paymentGoldBuyButton, int paymentBuyButtonIndexNumber) {
		/// Purchase....
		if (Managers.UserData != null && Managers.GameBalanceData != null) {
			
			m_paymentBuyInfoBalance = Managers.GameBalanceData.GetPaymentGoldBuyInfoBalance(paymentBuyButtonIndexNumber) ;
			
			m_paymentItemValueType = m_paymentBuyInfoBalance.PaymentItemValueType;
			m_paymentItemValue = m_paymentBuyInfoBalance.PaymentItemValue ;
			m_productValueType = m_paymentBuyInfoBalance.ProductValueType ;
			m_productValue = m_paymentBuyInfoBalance.ProductValue ;
			
			
			/// Money Process..
			if(m_paymentItemValueType == 1){
				
				int spendState = Managers.UserData.SetSpendGold((int)m_paymentItemValue) ;
				
				if(spendState == 1) 
				{
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
					
					if(m_productValueType == 1){ //Gold
						Managers.UserData.SetPurchaseGold(m_productValue) ;
					}else if(m_productValueType == 2){ //Jewel
						Managers.UserData.SetPurchaseJewel(m_productValue) ;
					}
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Gain,false);
					
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_PURCHASE_OK) ;
					
					
					if(Managers.DataStream != null)
					{

						if(Managers.UserData != null){

							Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
							Managers.UserData.UpdateSequence++;
							UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
							
							// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
							Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
							// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.


						}
					}


					//Save Log...
					///Connect
					/// 201 : 골드상품1 , 202 : 골드상품2 , 203 : 골드상품3 , 204 : 골드상품4 , 205 : 골드상품5 , 206 : 골드상품6
					int itemCode = 0 ;
					if(m_paymentBuyInfoBalance.PaymentItemIndex == 1){
						itemCode = 201 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 2){
						itemCode = 202 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 3){
						itemCode = 203 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 4){
						itemCode = 204 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 5){
						itemCode = 205 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 6){
						itemCode = 206 ;
					}
					
					StartCoroutine(Managers.DataStream.Network_SaveLog(5, itemCode)) ; //5 : PaymentView

				}else{
					// Pop Up Payment Window...
					////Debug.Log("Pop Up Payment Window... Gold") ;
				}
					
			}else if(m_paymentItemValueType == 2){
					
				int spendState = Managers.UserData.SetSpendJewel((int)m_paymentItemValue) ;
					
				if(spendState == 1) {
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
					
					if(m_productValueType == 1){ //Gold
						Managers.UserData.SetPurchaseGold(m_productValue) ;
						ST200KLogManager.Instance.SaveShopSpendCrystal("GOLD", (int)m_paymentItemValue);
					}else if(m_productValueType == 2){ //Jewel
						Managers.UserData.SetPurchaseJewel(m_productValue) ;
					}
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Gain,false);
					
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_PURCHASE_OK) ;
					
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

					//Save Log...
					///Connect
					/// 201 : 골드상품1 , 202 : 골드상품2 , 203 : 골드상품3 , 204 : 골드상품4 , 205 : 골드상품5 , 206 : 골드상품6
					int itemCode = 0 ;
					if(m_paymentBuyInfoBalance.PaymentItemIndex == 1){
						itemCode = 201 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 2){
						itemCode = 202 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 3){
						itemCode = 203 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 4){
						itemCode = 204 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 5){
						itemCode = 205 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 6){
						itemCode = 206 ;
					}
					
					StartCoroutine(Managers.DataStream.Network_SaveLog(5, itemCode)) ; //5 : PaymentView
					///
					
				}else{
					// Pop Up Payment Window...	
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_RECHARGE_COIN) ;
				}
					
			}
			
		}
		
		if(_paymentPopupViewDelegate != null) {
			_paymentPopupViewDelegate(this,100) ; //Reload Gold&Jewel Info view
		}
		
	}
	
	public void PaymentPopupJewelInfoViewDelegate(PaymentJewelBuyButton paymentJewelBuyButton, int paymentBuyButtonIndexNumber) {
		/// Purchase....
		if(Managers.UserData != null && Managers.GameBalanceData != null) {
			
			m_paymentBuyInfoBalance = Managers.GameBalanceData.GetPaymentJewelBuyInfoBalance(paymentBuyButtonIndexNumber) ;
			
			m_paymentItemValueType = m_paymentBuyInfoBalance.PaymentItemValueType;
			m_paymentItemValue = m_paymentBuyInfoBalance.PaymentItemValue ;
			
			m_productValueType = m_paymentBuyInfoBalance.ProductValueType ;
			m_productValue = m_paymentBuyInfoBalance.ProductValue ;
			
			
			/// Money Process..
			if(m_paymentItemValueType == 1){
				
				int spendState = Managers.UserData.SetSpendGold((int)m_paymentItemValue) ;
				
				if(spendState == 1) {
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
					
					if(m_productValueType == 1){ //Gold
						Managers.UserData.SetPurchaseGold(m_productValue) ;
					}else if(m_productValueType == 2){ //Jewel
						Managers.UserData.SetPurchaseJewel(m_productValue) ;
					}
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Gain,false);
					
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_PURCHASE_OK) ;
					
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
					
				}else{
					// Pop Up Payment Window...
					////Debug.Log("Pop Up Payment Window... Gold") ;
				}
					
				if(_paymentPopupViewDelegate != null) {
					_paymentPopupViewDelegate(this,100) ; //Reload Gold&Jewel Info view
				}
				
			}else if(m_paymentItemValueType == 2){
					
				int spendState = Managers.UserData.SetSpendJewel((int)m_paymentItemValue) ;
					
				if(spendState == 1) {
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
					
					if(m_productValueType == 1){ //Gold
						Managers.UserData.SetPurchaseGold(m_productValue) ;
					}else if(m_productValueType == 2){ //Jewel
						Managers.UserData.SetPurchaseJewel(m_productValue) ;
					}
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Gain,false);
					
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_PURCHASE_OK) ;
					
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
					
				}else{
					// Pop Up Payment Window...	
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_RECHARGE_COIN) ;
				}
					
				if(_paymentPopupViewDelegate != null) {
					_paymentPopupViewDelegate(this,100) ; //Reload Gold&Jewel Info view
				}
				
			}else if(m_paymentItemValueType == 3){ //Cash
				
				
				//_gainChocolateCount = -1 ; //init Chocolate Count!!
				
				InApp_SetProductInfo();

				if(m_strInApp_Code == null || m_strInApp_Code.Equals("")){

					Debug.Log("st200 PaymentPopupView.PaymentPopupJewelInfoViewDelegate().m_strInApp_Code == null || m_strInApp_Code.Equals()");
					// 데이터가 올바르지 않습니다. 다시 실행해 주세요.
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
					return ;
				}

				///Payment Connect....!!!!!!
				_indicatorPopupView.LoadIndicatorPopupView() ;

#if UNITY_IPHONE

				InApp_CallIAP_iOS();

#elif UNITY_ANDROID 

				//TStore...
				if (Constant.CURRENT_MARKET.Equals("3")){

					InApp_CallIAP_Tstore();

					// Naver InApp.
				} else if (Constant.CURRENT_MARKET.Equals("4")){

					InApp_CallIAP_Naver();

					//Google PlayStore..
				} else if (Constant.CURRENT_MARKET.Equals("2")){

					InApp_CallIAP_Google();
				}
#endif
			}
		}

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
		
	}
	
	
	public void PaymentPopupTorpedoInfoViewDelegate(PaymentTorpedoBuyButton paymentTorpedoBuyButton, int paymentBuyButtonIndexNumber) {
		/// Purchase....
		
		if(Managers.UserData != null && Managers.GameBalanceData != null) {
			
			m_paymentBuyInfoBalance = Managers.GameBalanceData.GetPaymentTorpedoBuyInfoBalance(paymentBuyButtonIndexNumber) ;
			
			m_paymentItemValueType = m_paymentBuyInfoBalance.PaymentItemValueType;
			m_paymentItemValue = m_paymentBuyInfoBalance.PaymentItemValue ;
			m_productValueType = m_paymentBuyInfoBalance.ProductValueType ;
			m_productValue = m_paymentBuyInfoBalance.ProductValue ;

			/// Money Process..
			if(m_paymentItemValueType == 1){
				
				int spendState = Managers.UserData.SetSpendGold((int)m_paymentItemValue) ;
				
				if(spendState == 1) {
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
					
					if(m_productValueType == 1){ //Gold
						Managers.UserData.SetPurchaseGold(m_productValue) ;
					}else if(m_productValueType == 2){ //Jewel
						Managers.UserData.SetPurchaseJewel(m_productValue) ;
					}else if(m_productValueType == 4) {//Torpedo
						/// Here....
						////Debug.Log("Purchase Torpedo... : " + productValue) ;
						Managers.Torpedo.AddTorpedo(m_productValue);
						//Managers.Torpedo.RechargeTorpedo(productValue) ;
						
					}
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Gain,false);
					
					_paymentPopupAlertView.LoadPaymentPopupAlertView(1) ;
					
					//Save Log...
					///Connect
					/// 101 : 어뢰상품1 , 102 : 어뢰상품2 , 103 : 어뢰상품3 , 104 : 어뢰상품4 , 105 : 어뢰상품5 , 106 : 어뢰상품6
					int itemCode = 0 ;
					if(m_paymentBuyInfoBalance.PaymentItemIndex == 1){
						itemCode = 101 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 2){
						itemCode = 102 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 3){
						itemCode = 103 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 4){
						itemCode = 104 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 5){
						itemCode = 105 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 6){
						itemCode = 106 ;
					}
					
					StartCoroutine(Managers.DataStream.Network_SaveLog(5, itemCode)) ; //5 : PaymentView
					///
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

				}else{
					// Pop Up Payment Window...
					////Debug.Log("Pop Up Payment Window... Gold") ;
				}
					
			}else if(m_paymentItemValueType == 2){
					
				int spendState = Managers.UserData.SetSpendJewel((int)m_paymentItemValue) ;
					
				if(spendState == 1) {
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
					
					if(m_productValueType == 1){ //Gold
						Managers.UserData.SetPurchaseGold(m_productValue) ;
					}else if(m_productValueType == 2){ //Jewel
						Managers.UserData.SetPurchaseJewel(m_productValue) ;
					}else if(m_productValueType == 4) {//Torpedo
						/// Here....
						////Debug.Log("Purchase Torpedo... : " + productValue) ;
						Managers.Torpedo.AddTorpedo(m_productValue);
						ST200KLogManager.Instance.SaveShopSpendCrystal("TORPEDO", (int)m_paymentItemValue);
						//Managers.Torpedo.RechargeTorpedo(productValue) ;
						
					}
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Gain,false);
					
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_PURCHASE_OK) ;
					
					//Save Log...
					///Connect
					/// 101 : 어뢰상품1 , 102 : 어뢰상품2 , 103 : 어뢰상품3 , 104 : 어뢰상품4 , 105 : 어뢰상품5 , 106 : 어뢰상품6
					int itemCode = 0 ;
					if(m_paymentBuyInfoBalance.PaymentItemIndex == 1){
						itemCode = 101 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 2){
						itemCode = 102 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 3){
						itemCode = 103 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 4){
						itemCode = 104 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 5){
						itemCode = 105 ;
					}else if(m_paymentBuyInfoBalance.PaymentItemIndex == 6){
						itemCode = 106 ;
					}
					
					StartCoroutine(Managers.DataStream.Network_SaveLog(5, itemCode)) ; //5 : PaymentView
					///
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
				}else{
					// Pop Up Payment Window...	
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_RECHARGE_COIN) ;
				}
					
			}
			
		}
		
		if(_paymentPopupViewDelegate != null) {
			_paymentPopupViewDelegate(this,100) ; //Reload Gold&Jewel Info view
		}
		
	}
	
	public void OnClickGoldInfoViewButton()
	{
		_paymentPopupJewelInfoView.RemovePaymentPopupJewelInfoView() ;
		_paymentPopupGoldInfoView.LoadPaymentPopupGoldInfoView() ;

		m_GoldPopUpViewButton.spriteName = "main_tap_selected";
		m_JewelPopUpViewButton.spriteName = "main_tap_not_selected";
	}

	public void OnClickJewelInfoViewButton()
	{
		_paymentPopupGoldInfoView.RemovePaymentPopupGoldInfoView() ;
		_paymentPopupJewelInfoView.LoadPaymentPopupJewelInfoView() ;

		m_GoldPopUpViewButton.spriteName = "main_tap_not_selected";
		m_JewelPopUpViewButton.spriteName = "main_tap_selected";
	}

	//----
	private void PaymentPopupGoldInfoViewButtonDelegate(PaymentPopupGoldInfoView paymentPopupGoldInfoView, int state) {
		if(state == 1){ //Gold
			//Nothing..
		}else if(state == 2){ //Jewel
			_paymentPopupGoldInfoView.RemovePaymentPopupGoldInfoView() ;
			_paymentPopupJewelInfoView.LoadPaymentPopupJewelInfoView() ;
		}else if(state == 3){ //Torpedo
			_paymentPopupGoldInfoView.RemovePaymentPopupGoldInfoView() ;
			_paymentPopupJewelInfoView.RemovePaymentPopupJewelInfoView() ;
		}
	}
	
	private void PaymentPopupJewelInfoViewButtonDelegate(PaymentPopupJewelInfoView paymentPopupJewelInfoView, int state) {
		
		if(state == 1){ //Gold
			_paymentPopupJewelInfoView.RemovePaymentPopupJewelInfoView() ;
			_paymentPopupGoldInfoView.LoadPaymentPopupGoldInfoView() ;
		}else if(state == 2){ //Jewel
			//Nothing..
		}else if(state == 3){ //Torpedo
			_paymentPopupGoldInfoView.RemovePaymentPopupGoldInfoView() ;
			_paymentPopupJewelInfoView.RemovePaymentPopupJewelInfoView() ;
		}
		
	}
	
	private void PaymentPopupTorpedoInfoViewButtonDelegate(PaymentPopupTorpedoInfoView paymentPopupTorpedoInfoView, int state){
		
		if(state == 1){ //Gold
			_paymentPopupJewelInfoView.RemovePaymentPopupJewelInfoView() ;
			_paymentPopupGoldInfoView.LoadPaymentPopupGoldInfoView() ;
		}else if(state == 2){ //Jewel
			_paymentPopupGoldInfoView.RemovePaymentPopupGoldInfoView() ;
			_paymentPopupJewelInfoView.LoadPaymentPopupJewelInfoView() ;
		}else if(state == 3){ //Torpedo
			//Nothing..
		}
		
	}
	
	
	
	//----
	private void PaymentPopupAlertViewDelegate(PaymentPopupAlertView paymentPopupAlertView, int alertType) {
		if(alertType == 2){ //Go PaymentView Jewel....
			_paymentPopupGoldInfoView.RemovePaymentPopupGoldInfoView() ;
			_paymentPopupJewelInfoView.LoadPaymentPopupJewelInfoView() ;
		}else if(alertType == 11){ //Purchase Jewel after ChocolateAlertView

		}else if(alertType == 101)
		{
			//show luckycoupon
			if(GameUIManager.Instance != null)
		   	{
				GameUIManager.Instance.ShowLuckyCouponAlert();
			}
		}
	}



	//----------
	public void InitLoadPaymentPopupView(){
		
		_paymentPopupGoldInfoView = _paymentPopupGoldInfoViewGameObject.GetComponent<PaymentPopupGoldInfoView>() as PaymentPopupGoldInfoView ;
		_paymentPopupGoldInfoView.PaymentPopupGoldInfoViewEvent += GoldInfoViewDelegate ;
		_paymentPopupGoldInfoView.PaymentPopupGoldInfoViewButtonEvent += PaymentPopupGoldInfoViewButtonDelegate ;
		
		_paymentPopupJewelInfoView = _paymentPopupJewelInfoViewGameObject.GetComponent<PaymentPopupJewelInfoView>() as PaymentPopupJewelInfoView ;
		_paymentPopupJewelInfoView.PaymentPopupJewelInfoViewEvent += JewelInfoViewDelegate ;
		_paymentPopupJewelInfoView.PaymentPopupJewelInfoViewButtonEvent += PaymentPopupJewelInfoViewButtonDelegate ;
		
		_paymentPopupAlertView = _paymentPopupAlertViewGameObject.GetComponent<PaymentPopupAlertView>() as PaymentPopupAlertView ;
		_paymentPopupAlertView.PaymentPopupAlertViewOkEvent += PaymentPopupAlertViewDelegate ;
		_paymentPopupAlertView.InitLoadPaymentPopupAlertView() ;
		
		_indicatorPopupView.IndicatorPopupViewEvent += null ;
		_indicatorPopupView.InitLoadIndicatorPopupView() ;
		//
		
	}
	
	public void LoadPaymentPopupView(int selectView) {
		NGUITools.SetActive(gameObject, true) ;

		//check time and show 10th event
		if(Managers.GameBalanceData.TenthDownloadEventFlag == 1 &&
			Managers.UserData.GetSyncServerTime() > Managers.GameBalanceData.TenthDownloadEventStartTimer &&
		   Managers.UserData.GetSyncServerTime() < Managers.GameBalanceData.TenthDownloadEventEndTimer)
		{
			NGUITools.SetActive(m_PaymentEventObject.gameObject, false);
		}else
		{
			NGUITools.SetActive(m_PaymentEventObject.gameObject, false);
		}

		if(selectView == Constant.ST200_POPUP_RECHARGE_COIN){ //Open Gold
			OnClickGoldInfoViewButton();
		}else if(selectView == Constant.ST200_POPUP_RECHARGE_JEWEL){ //Open Jewel
			OnClickJewelInfoViewButton();
		}else if(selectView == 3){ //Open Torpedo
			//OnClickTorpedoInfoViewButton();
		}
		
	}
	
	public void RemovePaymentPopupView() {
		
		_indicatorPopupView.RemoveIndicatorPopupView() ;
		NGUITools.SetActive(_paymentPopupAlertView.gameObject, false) ;
		//NGUITools.SetActive(_paymentPopupChocolateAlertView.gameObject, false) ; // Remove !!!!!
		
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void OnClickPaymentPopupViewCloseButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupViewDelegate != null) {
			_paymentPopupViewDelegate(this,500) ; //Close PaymemtPopupView
		}
		
		RemovePaymentPopupView() ;
	}




	private void InApp_SetProductInfo(){

#if UNITY_IPHONE

		// 크리스탈 10.
		if (m_paymentBuyInfoBalance.PaymentItemIndex == 1){
			
			m_strInApp_Code = "com.polycube.st200.Bullion.10" ;
			
			// 크리스탈 33.
		} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 2){
			
			m_strInApp_Code = "com.polycube.st200.Bullion.33" ;
			
			// 크리스탈 60.
		} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 3){
			
			m_strInApp_Code = "com.polycube.st200.Bullion.60" ;
			
			// 크리스탈 130.
		} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 4){
			
			m_strInApp_Code = "com.polycube.st200.Bullion.130" ;
			
			// 크리스탈 420.
		} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 5){
			
			m_strInApp_Code = "com.polycube.st200.Bullion.420" ;
			
			// 크리스탈 750.
		} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 6){
			
			m_strInApp_Code = "com.polycube.st200.Bullion.750" ;
		}

#elif UNITY_ANDROID
		
		// SK T Store.
		if (Constant.CURRENT_MARKET.Equals("3")){
			
			// 크리스탈 10.
			if (m_paymentBuyInfoBalance.PaymentItemIndex == 1){
				
				m_strInApp_Code = "0910023020" ;
				
				// 크리스탈 33.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 2){
				
				m_strInApp_Code = "0910023021" ;
				
				// 크리스탈 60.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 3){
				
				m_strInApp_Code = "0910023022" ;
				
				// 크리스탈 130.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 4){
				
				m_strInApp_Code = "0910023023" ;
				
				// 크리스탈 420.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 5){
				
				m_strInApp_Code = "0910023024" ;
				
				// 크리스탈 750.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 6){
				
				m_strInApp_Code = "0910023025" ;
			}
			
			// Naver InApp.
		} else if (Constant.CURRENT_MARKET.Equals("4")){
			
			// 크리스탈 10.
			if (m_paymentBuyInfoBalance.PaymentItemIndex == 1){
				
				m_strInApp_Code = "1000011895" ;
				m_intInApp_Price = 1100;
				
				// 크리스탈 33.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 2){
				
				m_strInApp_Code = "1000011896" ;
				m_intInApp_Price = 3300;
				
				// 크리스탈 60.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 3){
				
				m_strInApp_Code = "1000011897" ;
				m_intInApp_Price = 5500;
				
				// 크리스탈 130.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 4){
				
				m_strInApp_Code = "1000011898" ;
				m_intInApp_Price = 11000;							
				
				// 크리스탈 420.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 5){
				
				m_strInApp_Code = "1000011899" ;
				m_intInApp_Price = 33000;							
				
				// 크리스탈 750.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 6){
				
				m_strInApp_Code = "1000011900" ;
				m_intInApp_Price = 55000;
			}

			// Google Playstore.
		} else if (Constant.CURRENT_MARKET.Equals("2")){ //Google PlayStore..
			
			// 크리스탈 10.
			if (m_paymentBuyInfoBalance.PaymentItemIndex == 1){
				
				m_strInApp_Code = "st200_gold_10" ;
				
				// 크리스탈 33.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 2){
				
				m_strInApp_Code = "st200_gold_30" ;
				
				// 크리스탈 60.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 3){
				
				m_strInApp_Code = "st200_gold_50" ;
				
				// 크리스탈 130.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 4){
				
				m_strInApp_Code = "st200_gold_100" ;
				
				// 크리스탈 420.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 5){
				
				m_strInApp_Code = "st200_gold_300" ;
				
				// 크리스탈 750.
			} else if (m_paymentBuyInfoBalance.PaymentItemIndex == 6){
				
				m_strInApp_Code = "st200_gold_500" ;
			}
			
		}

		#endif
	}

	private void InApp_CallIAP_iOS(){

		#if UNITY_IPHONE

		Managers.Payment.PaymentManagerOkEvent += (returnProductIdentifier) => {
			
			//Debug.Log(" st200 PaymentPopupView.InApp_CallIAP_iOS.PaymentPopupJewelInfoViewDelegate().PaymentManagerOkEvent.returnProductIdentifier = " + returnProductIdentifier);
			//Debug.Log(" st200 PaymentPopupView.InApp_CallIAP_iOS.PaymentPopupJewelInfoViewDelegate().PaymentManagerOkEvent.productValueType = " + productValueType);
			
			_indicatorPopupView.RemoveIndicatorPopupView();
			
			if (m_strInApp_Code.Equals(returnProductIdentifier)){
				
				if (m_productValueType == 1){ //Gold
					
					Managers.UserData.SetPurchaseGold(m_productValue) ;
					
				} else if (m_productValueType == 2){ //Jewel
					
					Managers.UserData.SetPurchaseJewel(m_productValue) ;
				}
				
				if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Gain,false);
				
				// SaveUserData.
				if(Managers.DataStream != null){
					
					if(Managers.UserData != null){
						
						Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
						Managers.UserData.UpdateSequence++;
						UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
						
						Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
					}
				}
				
				
			}else{
				
				// 데이터가 올바르지 않습니다. 다시 실행해 주세요.
				_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
			}
			
			if(_paymentPopupViewDelegate != null) {
				
				_paymentPopupViewDelegate(this,100) ; //Reload Gold&Jewel Info view
			}
			
			//End Connect!!
			//_indicatorPopupView.RemoveIndicatorPopupView() ;
			
		};
		
		
		//Managers.Payment.PaymentManagerErrorEvent += PaymentManagerErrorDelegate  => {
		Managers.Payment.PaymentManagerErrorEvent += (errorMessage, state) => {	
			
			//Debug.Log(" st200 PaymentPopupView.InApp_CallIAP_iOS.PaymentPopupJewelInfoViewDelegate().PaymentManagerErrorEvent.errorMessage = " + errorMessage);
			//Debug.Log(" st200 PaymentPopupView.InApp_CallIAP_iOS.PaymentPopupJewelInfoViewDelegate().PaymentManagerErrorEvent.state = " + state.ToString());
			
			_indicatorPopupView.RemoveIndicatorPopupView() ;
			
			if(state == 1){
				//1: 통신이 원활하지 않습니다. 다시 결제해주세요.
				
				_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_NO_GOOD_NETWORK) ;
				
			} else if (state == 2){
				//2: 결제가 취소 되었습니다.
				
				_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_CANCELED) ;
				
			} else if (state == 3){
				//3: 데이터가 올바르지 않습니다. 다시 실행해 주세요.
				
				_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
			}
			
		};
		
		//Debug.Log(" st200 PaymentPopupView.PaymentPopupJewelInfoViewDelegate().m_strInApp_Code = " + m_strInApp_Code);
		
		Managers.Payment.PurchaseProduct(m_strInApp_Code, 1) ;

		#endif
	}

	private void InApp_CallIAP_Google(){


#if UNITY_ANDROID 

		Managers.Payment.PaymentManagerOkEvent += (returnProductIdentifier) => {
			//Debug.Log("PAYMENT TRUE EVENT");
			if(m_strInApp_Code.Equals(returnProductIdentifier)){
				
				if(m_productValueType == 1){ //Gold
					Managers.UserData.SetPurchaseGold(m_productValue) ;
				}else if(m_productValueType == 2){ //Jewel
					Managers.UserData.SetPurchaseJewel(m_productValue) ;
				}
				
				if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Gain,false);
				_indicatorPopupView.RemoveIndicatorPopupView() ;
				
				_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_SUCCESS);

			}else{
				
				_indicatorPopupView.RemoveIndicatorPopupView() ;
				
				// 데이터가 올바르지 않습니다. 다시 실행해 주세요.
				Debug.Log("st200 PaymentPopupView.InApp_CallIAP_Google().PaymentManagerOkEvent");
				_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
			}
			
			if(_paymentPopupViewDelegate != null) {
				_paymentPopupViewDelegate(this,100) ; //Reload Gold&Jewel Info view
			}
			
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
		};
		
		
		//Managers.Payment.PaymentManagerErrorEvent += PaymentManagerErrorDelegate  => {
		Managers.Payment.PaymentManagerErrorEvent += (errorMessage, state) => {	
			Debug.Log("PAYMENT ERROR EVENT ERROR: " + errorMessage + " STATE: " + state);
			
			if(state == 1){
				//1: 통신이 원활하지 않습니다. 다시 결제해주세요.
				_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_NO_GOOD_NETWORK) ;
			}else if(state == 2){
				//2: 결제가 취소 되었습니다.	
				_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_CANCELED) ;
			}else if(state == 3){
				Debug.Log("st200 PaymentPopupView.InApp_CallIAP_Google().PaymentManagerErrorEvent");
				//3: 데이터가 올바르지 않습니다. 다시 실행해 주세요.
				_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
			}
			
			//End Connect!!
			_indicatorPopupView.RemoveIndicatorPopupView() ;
			
		};
		
		//--------
		Managers.Payment.PaymentManagerConsumeOkEvent += (returnProductIdentifier) => {
			//Debug.Log("CONSUME TRUE EVENT");
			if(m_strInApp_Code.Equals(returnProductIdentifier)){
				Managers.Payment.PurchaseProduct(m_strInApp_Code, 1);
			}
		};
		
		Managers.Payment.PaymentManagerConsumeErrorEvent += () => {
			//Debug.Log("CONSUME ERROR EVENT");
			//통신이 원활하지 않습니다. 다시 결제해주세요.
			_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_NO_GOOD_NETWORK);
			
			//End Connect!!
			_indicatorPopupView.RemoveIndicatorPopupView() ;
		} ;
		
		//--------
		Managers.Payment.PaymentManagerQueryInventoryOkEvent += (purchases) => {
			//Debug.Log("QUERY TRUE EVENT");
			bool isExistProductIdentifier = false ;
			
			if ( purchases.Count > 0 ){	
				for ( int i = 0 ; i < purchases.Count ; i ++ ){
					if(m_strInApp_Code.Equals(purchases[i].productId)){
						isExistProductIdentifier = true ;
						break ;
					}								
				}
			}
			
			//Debug.Log("EXIST PRODUCT IDENTIFIER: " + isExistProductIdentifier + "  PURCHASE COUNT: " + purchases.Count);
			
			if(isExistProductIdentifier){
				Managers.Payment.ConsumeProduct(m_strInApp_Code) ;
			}else{
				Managers.Payment.PurchaseProduct(m_strInApp_Code, 1) ;
			}
			
		};
		
		Managers.Payment.PaymentManagerQueryInventoryErrorEvent += () => {
			//Debug.Log("QUERY ERROR EVENT");
			//통신이 원활하지 않습니다. 다시 결제해주세요.
			_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_NO_GOOD_NETWORK) ;
			
			//End Connect!!
			_indicatorPopupView.RemoveIndicatorPopupView() ;
		} ;
		
		Managers.Payment.QueryInventoryProduct() ;
		
		/// End Payment....

		#endif
	}

	private void InApp_CallIAP_Tstore(){

#if UNITY_ANDROID 

		if(Managers.TstoreAndroidBridge != null){
			
			_indicatorPopupView.RemoveIndicatorPopupView() ;
			
			Managers.TstoreAndroidBridge.TstoreAndroidBridgeManagerOkEvent += (returnProductIdentifier) => {
				
				_indicatorPopupView.RemoveIndicatorPopupView() ;
				
				if(m_strInApp_Code.Equals(returnProductIdentifier)){
					
					if(m_productValueType == 1){ //Gold
						Managers.UserData.SetPurchaseGold(m_productValue) ;
					}else if(m_productValueType == 2){ //Jewel
						Managers.UserData.SetPurchaseJewel(m_productValue) ;
					}
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Gain,false);

					if (Managers.DataStream != null){
						
						if (Managers.UserData != null){
							
							Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
							Managers.UserData.UpdateSequence++;
							UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
							Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
						}
					}

				}else{

					Debug.Log("st200 PaymentPopupView.InApp_CallIAP_Tstore().TstoreAndroidBridgeManagerOkEvent");
					// 데이터가 올바르지 않습니다. 다시 실행해 주세요.
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
				}
				
				if(_paymentPopupViewDelegate != null) {
					_paymentPopupViewDelegate(this,100) ; //Reload Gold&Jewel Info view
				}
			};
			
			Managers.TstoreAndroidBridge.TstoreAndroidBridgeManagerErrorEvent += (errorMessage, state) => {	
				
				_indicatorPopupView.RemoveIndicatorPopupView() ;
				
				if(state == 1){
					//1: 통신이 원활하지 않습니다. 다시 결제해주세요.
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_NO_GOOD_NETWORK) ;
				}else if(state == 2){
					//2: 결제가 취소 되었습니다.	
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_CANCELED) ;
				}else if(state == 3){
					Debug.Log("st200 PaymentPopupView.InApp_CallIAP_Tstore().TstoreAndroidBridgeManagerErrorEvent");
					//3: 데이터가 올바르지 않습니다. 다시 실행해 주세요.
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) ;
				}else if(state == 4){
					// 결제 모듈 호출을 실패하였습니다.\n게임 종료 후 다시 결제해 주세요.
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_FAILED_TO_CALL) ;
				}
			};
			
			Managers.TstoreAndroidBridge.CallPaymentRequest(m_strInApp_Code) ;
			
		}else{
			
			// Connect Icon End!!!
			_indicatorPopupView.RemoveIndicatorPopupView() ;
			
			//2: 결제가 취소 되었습니다.	
			_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_CANCELED) ;
			
		}

		#endif
	}

	private void InApp_CallIAP_Naver(){

#if UNITY_ANDROID 

		if (Managers.NaverAndroidBridge != null){
			
			_indicatorPopupView.RemoveIndicatorPopupView() ;
			
			Managers.NaverAndroidBridge.EventDelegate_NaverAndroidBridgeManager += (boolSuccess_Input) => {

				Debug.Log ("st200 PaymentPopupView.InApp_CallIAP_Naver.EventDelegate_NaverAndroidBridgeManager.boolSuccess_Input = " + boolSuccess_Input.ToString());

				_indicatorPopupView.RemoveIndicatorPopupView() ;
				
				if (boolSuccess_Input){

					Debug.Log ("st200 PaymentPopupView.InApp_CallIAP_Naver.EventDelegate_NaverAndroidBridgeManager.m_productValueType = " + m_productValueType.ToString());

					if (m_productValueType == 1){ //Gold
						
						Managers.UserData.SetPurchaseGold(m_productValue) ;
						
					} else if (m_productValueType == 2){ //Jewel
						
						Managers.UserData.SetPurchaseJewel(m_productValue) ;
					}
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Gain,false);

					if (Managers.DataStream != null){
						
						if (Managers.UserData != null){
							
							Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
							Managers.UserData.UpdateSequence++;
							UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
							Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
						}
					}

				} else {
					
					//1: 통신이 원활하지 않습니다. 다시 결제해주세요.
					_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_NO_GOOD_NETWORK) ;
				}
				
				if(_paymentPopupViewDelegate != null) {
					_paymentPopupViewDelegate(this,100) ; //Reload Gold&Jewel Info view
				}
			};

			Debug.Log ("st200 PaymentPopupView.InApp_CallIAP_Naver.m_strInApp_Code = " + m_strInApp_Code);
			Debug.Log ("st200 PaymentPopupView.InApp_CallIAP_Naver.m_intInApp_Price = " + m_intInApp_Price.ToString());

			Managers.NaverAndroidBridge.NaverInApp_requestPayment(m_strInApp_Code, m_intInApp_Price, "") ;
			
			
		}else{
			
			// Connect Icon End!!!
			_indicatorPopupView.RemoveIndicatorPopupView() ;
			
			//2: 결제가 취소 되었습니다.	
			_paymentPopupAlertView.LoadPaymentPopupAlertView(Constant.ST200_POPUP_MESSAGE_INAPP_CANCELED) ;
			
		}

		#endif
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			if(_paymentPopupAlertView.OnEscapePress())
			{
				return true;
			}else if(m_PaymentConfirmView.OnEscapePress())
			{
				return true;
			}else
			{
				RemovePaymentPopupView();
				return true;
			}
		}

		return false;
	}
}
