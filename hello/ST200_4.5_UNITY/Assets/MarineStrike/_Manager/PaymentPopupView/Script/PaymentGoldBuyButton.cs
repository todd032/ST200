using UnityEngine;
using System.Collections;

public class PaymentGoldBuyButton : MonoBehaviour {

	[HideInInspector]
	public delegate void PaymentGoldBuyButtonDelegate(PaymentGoldBuyButton paymentGoldBuyButton, int paymentBuyButtonIndexNumber);
	protected PaymentGoldBuyButtonDelegate _paymentBuyButtonDelegate ;
	public event PaymentGoldBuyButtonDelegate PaymentGoldBuyButtonEvent {
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
	public UISprite m_ItemImage;
	public UISprite m_EffectSprite;
	public UILabel _cashValueInfoLabel ;
	public UILabel _valueInfoLabel ;
	
	public UISprite _bonusIconSprite ;
	public UILabel _bonusValueInfoLabel ;
	
	
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
		
			GameBalanceDataManager.PaymentBuyInfoBalance paymentBuyInfoBalance = Managers.GameBalanceData.GetPaymentGoldBuyInfoBalance(paymentBuyButtonIndexNumber) ;
		
			m_ItemImage.spriteName = ImageResourceManager.Instance.GetMainUIShopCoinImageName( _paymentBuyButtonIndexNumber);
			m_ItemImage.MakePixelPerfect();

			if(_paymentBuyButtonIndexNumber > 3)
			{
				m_EffectSprite.spriteName = "storeui_effect_2";
			}else
			{
				m_EffectSprite.spriteName = "storeui_effect_1";
			}
			m_EffectSprite.MakePixelPerfect();

			string paymentItemValueString = "";// = "[ffffff]" ;
			//if(paymentBuyInfoBalance.PaymentItemValueType == 1){ //Gold
			//	paymentItemValueString = "[ffc800]" ;
			//}else if(paymentBuyInfoBalance.PaymentItemValueType == 2){ //Jewel
			//	paymentItemValueString = "[00ffff]" ;
			//}else if(paymentBuyInfoBalance.PaymentItemValueType == 3){ //Cash
			//	paymentItemValueString = "[ffc800]" ;
			//}
			
			float paymentItemValue = paymentBuyInfoBalance.PaymentItemValue ;
			
			if(paymentItemValue == 0f) {
				paymentItemValueString += paymentItemValue.ToString() ;
			}else{
				paymentItemValueString += paymentItemValue.ToString("#,#") ;
			}
			_cashValueInfoLabel.text = Constant.COLOR_STORE_ITEMCOST + paymentItemValueString;
									
			float productValue = paymentBuyInfoBalance.ProductValue ;
			string productValueString = "" ;
			if(productValue == 0f) {
				productValueString += productValue.ToString() ;
			}else{
				productValueString += productValue.ToString("#,#") ;
			}
			_valueInfoLabel.text = Constant.COLOR_STORE_ITEMCOUNT + TextManager.Instance.GetReplaceString(90,productValueString) ;
		}
		
	}
	
	public void OnClickPaymentBuyButton(){
		
		if(_paymentBuyButtonDelegate != null) {
			_paymentBuyButtonDelegate(this,PaymentBuyButtonIndexNumber) ;
		}
	}
	
}
