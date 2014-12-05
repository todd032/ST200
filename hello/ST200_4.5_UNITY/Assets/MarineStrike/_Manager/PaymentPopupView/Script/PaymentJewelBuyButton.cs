using UnityEngine;
using System.Collections;

public class PaymentJewelBuyButton : MonoBehaviour {

	[HideInInspector]
	public delegate void PaymentJewelBuyButtonDelegate(PaymentJewelBuyButton paymentJewelBuyButton, int paymentBuyButtonIndexNumber);
	protected PaymentJewelBuyButtonDelegate _paymentBuyButtonDelegate ;
	public event PaymentJewelBuyButtonDelegate PaymentJewelBuyButtonEvent {
		add{
			
			_paymentBuyButtonDelegate = null ;
			
			if (_paymentBuyButtonDelegate == null)
        		_paymentBuyButtonDelegate += value;
        }
		
		remove{
            _paymentBuyButtonDelegate -= value;
		}
	}
	
	
	///
	public UISprite _buttonBackgroundSprite ;
	public UISprite m_OutLineSprite;
	public UILabel _cashValueInfoLabel ;
	public UILabel _valueInfoLabel ;

	public UISprite m_ItemImage;
	public UISprite m_EffectSprite;
	public UISprite m_BonusSprite;
	public UILabel m_BonusLabel;


	private int _paymentBuyButtonIndexNumber ;
	public int PaymentBuyButtonIndexNumber{
		get { return _paymentBuyButtonIndexNumber ; }
	}	
	
	
	private GameObject _thisGameObject ;
	private Transform _thisTransform ;
	
	
	private void Awake(){
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
	}
	
	private void Start() {
		
	}
	
	
	public void InitLoadPaymentBuyButton(int paymentBuyButtonIndexNumber){
		
		_paymentBuyButtonIndexNumber = paymentBuyButtonIndexNumber ;
		
		if(paymentBuyButtonIndexNumber == 1){
			_thisTransform.localPosition = new Vector3(-262f, -55f, 0f) ;
		}else if(paymentBuyButtonIndexNumber == 2){
			_thisTransform.localPosition = new Vector3(-157f, -55f, 0f) ;
		}else if(paymentBuyButtonIndexNumber == 3){
			_thisTransform.localPosition = new Vector3(-52f, -55f, 0f) ;
		}else if(paymentBuyButtonIndexNumber == 4){
			_thisTransform.localPosition = new Vector3(53f, -55f, 0f) ;
		}else if(paymentBuyButtonIndexNumber == 5){
			_thisTransform.localPosition = new Vector3(158f, -55f, 0f) ;
		}else if(paymentBuyButtonIndexNumber == 6){
			_thisTransform.localPosition = new Vector3(263f, -55f, 0f) ;
		}
		
		
		
		SetPaymentBuyButton(paymentBuyButtonIndexNumber) ;
		
	}
	
	public void SetPaymentBuyButton(int paymentBuyButtonIndexNumber){
		
		
		if(paymentBuyButtonIndexNumber == -1){
			NGUITools.SetActive(_thisGameObject, false) ;
			return ;	
		}else{
			NGUITools.SetActive(_thisGameObject, true) ;
		}
		
		
		
		if(Managers.GameBalanceData != null){
		
			m_ItemImage.spriteName = ImageResourceManager.Instance.GetMainUIShopGoldImageName(_paymentBuyButtonIndexNumber);
			m_ItemImage.MakePixelPerfect();

			if(_paymentBuyButtonIndexNumber > 3)
			{
				m_EffectSprite.spriteName = "storeui_effect_2";
			}else
			{
				m_EffectSprite.spriteName = "storeui_effect_1";
			}
			m_EffectSprite.MakePixelPerfect();
#if UNITY_IPHONE
			GameBalanceDataManager.PaymentBuyInfoBalance paymentBuyInfoBalance = Managers.GameBalanceData.GetPaymentJewelIOSBuyInfoBalance(paymentBuyButtonIndexNumber) ;	

#elif UNITY_ANDROID 
			GameBalanceDataManager.PaymentBuyInfoBalance paymentBuyInfoBalance = Managers.GameBalanceData.GetPaymentJewelBuyInfoBalance(paymentBuyButtonIndexNumber) ;

#endif
			
			string paymentItemValueString ="";
						
			float paymentItemValue = paymentBuyInfoBalance.PaymentItemValue ;

#if UNITY_ANDROID
			if(paymentItemValue == 0f) {
				paymentItemValueString += paymentItemValue.ToString() ;
			}else{
				paymentItemValueString += paymentItemValue.ToString("#,#") ;
			}
#elif UNITY_IPHONE
			paymentItemValueString += paymentItemValue.ToString() ;
#endif
			
			//paymentItemValueString += paymentItemValue.ToString() ;
			#if UNITY_ANDROID
			paymentItemValueString = "\\" + paymentItemValueString;
			#elif UNITY_IPHONE
			paymentItemValueString = "$" + paymentItemValueString;
			#endif

			_cashValueInfoLabel.text = Constant.COLOR_STORE_ITEMCOST + paymentItemValueString ;
			

			float productValue = paymentBuyInfoBalance.ProductValue ;
			string productValueString = "" ;
			
			if(productValue == 0f) {
				productValueString += productValue.ToString() ;
			}else{
				productValueString += productValue.ToString("#,#") ;
			}

#if UNITY_ANDROID 
			//if(Constant.CURRENT_MARKET == "2" && Managers.UserData.FirstInAppPurchaseFlag == 0)
			//{
			//	productValueString = Mathf.CeilToInt(productValue * 1.5f).ToString("#,#");
			//}
#endif
			int curval = paymentBuyInfoBalance.ProductValue;

			int originproductval = (int)(curval * 100 / (100 + (float)paymentBuyInfoBalance.BonusPercent));
			int bonusamount = curval - originproductval;
			//Debug.Log("ORIGIN: " + originproductval);

			productValueString = originproductval.ToString("#,#");// + TextManager.Instance.GetString(217);
			if(bonusamount != 0)
			{
				productValueString += " +" + bonusamount.ToString("#,#");
			}

			_valueInfoLabel.text = Constant.COLOR_STORE_ITEMCOUNT + productValueString ;

			if(paymentBuyInfoBalance.BonusPercent == 0f)
			{
				NGUITools.SetActive (m_BonusLabel.gameObject, false);
				NGUITools.SetActive (m_BonusSprite.gameObject, false);
			}else
			{
				NGUITools.SetActive (m_BonusLabel.gameObject, true);
				NGUITools.SetActive (m_BonusSprite.gameObject, true);
				m_BonusLabel.text = paymentBuyInfoBalance.BonusPercent.ToString() + "%";
			}

			if(paymentBuyInfoBalance.PaymentItemIndex == 6)
			{
				NGUITools.SetActive (m_OutLineSprite.gameObject, true);
			}else
			{
				NGUITools.SetActive (m_OutLineSprite.gameObject, false);
			}
		}
		
	}
	
	
	
	public void OnClickPaymentBuyButton(){
		
		if(_paymentBuyButtonDelegate != null) {
			_paymentBuyButtonDelegate(this,PaymentBuyButtonIndexNumber) ;
		}
	}
	
}
