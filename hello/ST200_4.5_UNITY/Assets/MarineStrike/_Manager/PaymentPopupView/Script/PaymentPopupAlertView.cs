using UnityEngine;
using System.Collections;

public class PaymentPopupAlertView : MonoBehaviour {
	
	
	[HideInInspector]
	public delegate void PaymentPopupAlertViewDelegate(PaymentPopupAlertView paymentPopupAlertView, int alertType);
	protected PaymentPopupAlertViewDelegate _paymentPopupAlertViewOkDelegate ;
	public event PaymentPopupAlertViewDelegate PaymentPopupAlertViewOkEvent {
		add{
			
			_paymentPopupAlertViewOkDelegate = null ;
			
			if (_paymentPopupAlertViewOkDelegate == null)
				_paymentPopupAlertViewOkDelegate += value;
        }
		
		remove{
			_paymentPopupAlertViewOkDelegate -= value;
		}
	}

	protected PaymentPopupAlertViewDelegate _paymentPopupAlertViewConfirmDelegate ;
	public event PaymentPopupAlertViewDelegate PaymentPopupAlertViewConfirmEvent {
		add{
			
			_paymentPopupAlertViewConfirmDelegate = null ;
			
			if (_paymentPopupAlertViewConfirmDelegate == null)
				_paymentPopupAlertViewConfirmDelegate += value;
		}
		
		remove{
			_paymentPopupAlertViewConfirmDelegate -= value;
		}
	}
	
	public UIButton _paymentPopupAlertViewOkButton ;
	public UIButton _paymentPopupAlertViewCancelButton ;
	public UIButton _paymentPopupAlertViewConfirmButton ;
	
	public UILabel _paymentPopupAlertViewMessageLabel ;
	
	private int _alertType ;
	
	
	private void Awake(){
		
	}
	
	private void Start() {
		
	}
	
	public void InitLoadPaymentPopupAlertView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadPaymentPopupAlertView(int alertType) {
		
		_alertType = alertType ;
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetPaymentPopupAlertView(alertType) ;
		
	}
	
	public void RemovePaymentPopupAlertView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetPaymentPopupAlertView(int alertType){
		
		if(alertType == Constant.ST200_POPUP_PURCHASE_OK){ //1:Purchase Ok...   11://Purchase Ok after ChocolateAlertView

			NGUITools.SetActive(_paymentPopupAlertViewCancelButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewOkButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewConfirmButton.gameObject, true) ;
			//_paymentPopupAlertViewOkButton.transform.localPosition = new Vector3(0f, _paymentPopupAlertViewOkButton.transform.localPosition.y, _paymentPopupAlertViewOkButton.transform.localPosition.z) ;

			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_paymentPopupAlertViewMessageLabel.text = TextManager.Instance.GetString(171);
				
			}
			
		}else if(alertType == Constant.ST200_POPUP_RECHARGE_JEWEL){ //Go PaymentView Jewel....
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);

			NGUITools.SetActive(_paymentPopupAlertViewCancelButton.gameObject, true) ;
			NGUITools.SetActive(_paymentPopupAlertViewOkButton.gameObject, true) ;
			NGUITools.SetActive(_paymentPopupAlertViewConfirmButton.gameObject, false) ;
			//_paymentPopupAlertViewOkButton.transform.localPosition = new Vector3(110f, _paymentPopupAlertViewOkButton.transform.localPosition.y, _paymentPopupAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_paymentPopupAlertViewMessageLabel.text = TextManager.Instance.GetString(170);
				
			}

		}else if(alertType == Constant.ST200_POPUP_MESSAGE_INAPP_CANCELED){ //결제가 취소 되었습니다.	
			
			NGUITools.SetActive(_paymentPopupAlertViewCancelButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewOkButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewConfirmButton.gameObject, true) ;
			//_paymentPopupAlertViewOkButton.transform.localPosition = new Vector3(0f, _paymentPopupAlertViewOkButton.transform.localPosition.y, _paymentPopupAlertViewOkButton.transform.localPosition.z) ;
			
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_paymentPopupAlertViewMessageLabel.text = TextManager.Instance.GetString(179); 
				
			}
			
		}else if(alertType == Constant.ST200_POPUP_MESSAGE_INAPP_NO_GOOD_NETWORK) {  //통신이 원활하지 않습니다. 다시 결제해주세요.
			
			NGUITools.SetActive(_paymentPopupAlertViewCancelButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewOkButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewConfirmButton.gameObject, true) ;
			//_paymentPopupAlertViewOkButton.transform.localPosition = new Vector3(0f, _paymentPopupAlertViewOkButton.transform.localPosition.y, _paymentPopupAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_paymentPopupAlertViewMessageLabel.text = TextManager.Instance.GetString(1); 
				
			}
			
		}else if(alertType == Constant.ST200_POPUP_MESSAGE_INCORRECTDATA) {  //데이터가 올바르지 않습니다. 다시 실행해 주세요.
			
			NGUITools.SetActive(_paymentPopupAlertViewCancelButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewOkButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewConfirmButton.gameObject, true) ;
			//_paymentPopupAlertViewOkButton.transform.localPosition = new Vector3(0f, _paymentPopupAlertViewOkButton.transform.localPosition.y, _paymentPopupAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_paymentPopupAlertViewMessageLabel.text =  TextManager.Instance.GetString(5) ;
				
			}
			
		}else if(alertType == Constant.ST200_POPUP_MESSAGE_INAPP_FAILED_TO_CALL) {  // 결제 모듈 호출을 실패하였습니다.\n게임 종료 후 다시 결제해 주세요.
			
			NGUITools.SetActive(_paymentPopupAlertViewCancelButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewOkButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewConfirmButton.gameObject, true) ;
			//_paymentPopupAlertViewOkButton.transform.localPosition = new Vector3(0f, _paymentPopupAlertViewOkButton.transform.localPosition.y, _paymentPopupAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_paymentPopupAlertViewMessageLabel.text = TextManager.Instance.GetString(178);
				
			}			
		}else if(alertType == Constant.ST200_POPUP_MESSAGE_INAPP_SUCCESS)
		{
			NGUITools.SetActive(_paymentPopupAlertViewCancelButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewOkButton.gameObject, false) ;
			NGUITools.SetActive(_paymentPopupAlertViewConfirmButton.gameObject, true) ;
			if(Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_paymentPopupAlertViewMessageLabel.text = TextManager.Instance.GetString(171);
				
			}	
		}
	}
	
	
	
	private void OnClickPaymentPopupAlertViewCancelButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		RemovePaymentPopupAlertView() ;
	}
	
	private void OnClickPaymentPopupAlertViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupAlertViewOkDelegate != null) {
			_paymentPopupAlertViewOkDelegate(this, _alertType) ;
		}
		
		RemovePaymentPopupAlertView() ;
		
	}

	private void OnClickPaymentPopupAlertViewConfirmButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupAlertViewOkDelegate != null) {
			_paymentPopupAlertViewOkDelegate(this, _alertType) ;
		}
		
		RemovePaymentPopupAlertView() ;
		
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			RemovePaymentPopupAlertView();
			return true;
		}
		
		return false;
	}
}
