using UnityEngine;
using System.Collections;

public class PaymentTorpedoBuyButton : MonoBehaviour {

	[HideInInspector]
	public delegate void PaymentTorpedoBuyButtonDelegate(PaymentTorpedoBuyButton paymentTorpedoBuyButton, int paymentBuyButtonIndexNumber);
	protected PaymentTorpedoBuyButtonDelegate _paymentBuyButtonDelegate ;
	public event PaymentTorpedoBuyButtonDelegate PaymentTorpedoBuyButtonEvent {
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
	
	public UILabel _cashValueInfoLabel ;
	public UILabel _valueInfoLabel ;
	public UISprite m_ItemImage;
	
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
		
			GameBalanceDataManager.PaymentBuyInfoBalance paymentBuyInfoBalance = Managers.GameBalanceData.GetPaymentTorpedoBuyInfoBalance(paymentBuyButtonIndexNumber) ;
			m_ItemImage.spriteName = "pop_img_missile" + _paymentBuyButtonIndexNumber.ToString();
			m_ItemImage.MakePixelPerfect();
			
			string paymentItemValueString = "";
			float paymentItemValue = paymentBuyInfoBalance.PaymentItemValue ;
			
			if(paymentItemValue == 0f) {
				paymentItemValueString += paymentItemValue.ToString() ;
			}else{
				paymentItemValueString += paymentItemValue.ToString("#,#") ;
			}
			_cashValueInfoLabel.text = paymentItemValueString ;
			
			float productValue = paymentBuyInfoBalance.ProductValue ;
			string productValueString = "" ;
			if(productValue == 0f) {
				productValueString += productValue.ToString() ;
			}else{
				productValueString += productValue.ToString("#,#") ;
			}
			_valueInfoLabel.text = productValueString ;
		}
		
	}
	
	
	
	private void OnClickPaymentBuyButton(){
		
		if(_paymentBuyButtonDelegate != null) {
			_paymentBuyButtonDelegate(this,PaymentBuyButtonIndexNumber) ;
		}
	}
	
}
