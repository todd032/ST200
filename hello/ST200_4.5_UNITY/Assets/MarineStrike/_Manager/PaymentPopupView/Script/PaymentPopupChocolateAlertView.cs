using UnityEngine;
using System.Collections;

public class PaymentPopupChocolateAlertView : MonoBehaviour {
	
	
	[HideInInspector]
	public delegate void PaymentPopupChocolateAlertViewDelegate(PaymentPopupChocolateAlertView paymentPopupChocolateAlertView, int state);
	protected PaymentPopupChocolateAlertViewDelegate _paymentPopupChocolateAlertViewDelegate ;
	public event PaymentPopupChocolateAlertViewDelegate PaymentPopupChocolateAlertViewEvent {
		add{
			
			_paymentPopupChocolateAlertViewDelegate = null ;
			
			if (_paymentPopupChocolateAlertViewDelegate == null)
        		_paymentPopupChocolateAlertViewDelegate += value;
        }
		
		remove{
            _paymentPopupChocolateAlertViewDelegate -= value;
		}
	}
	
	
	public UILabel _paymentPopupChocolateAlertViewMessageLabel ;
	
	//private int _chocolateCount ;
	
	
	private void Awake(){
		
	}
	
	private void Start() {
		
	}
	
	public void InitLoadPaymentPopupChocolateAlertView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadPaymentPopupChocolateAlertView(string alertMessage) {
		
		//_chocolateCount = chocolateCount ;
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetPaymentPopupChocolateAlertView(alertMessage) ;
		
	}
	
	public void RemovePaymentPopupChocolateAlertView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetPaymentPopupChocolateAlertView(string alertMessage){
		
		_paymentPopupChocolateAlertViewMessageLabel.text = alertMessage ;
		
	}
	
	
	private void OnClickPaymentPopupChocolateAlertViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupChocolateAlertViewDelegate != null) {
			_paymentPopupChocolateAlertViewDelegate(this, 100) ;
		}
		
		RemovePaymentPopupChocolateAlertView() ;
		
	}
}
