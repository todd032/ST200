using UnityEngine;
using System.Collections;

public class PresentSendAlertPopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void PresentSendAlertPopupViewDelegate(PresentSendAlertPopupView presentSendAlertPopupView, int alertType);
	protected PresentSendAlertPopupViewDelegate _presentSendAlertPopupViewDelegate ;
	public event PresentSendAlertPopupViewDelegate PresentSendAlertPopupViewEvent {
		add{
			
			_presentSendAlertPopupViewDelegate = null ;
			
			if (_presentSendAlertPopupViewDelegate == null)
        		_presentSendAlertPopupViewDelegate += value;
        }
		
		remove{
            _presentSendAlertPopupViewDelegate -= value;
		}
	}

	
	public UISprite _presentSendAlertPopupViewBlackSprite ;

	public UILabel _presentSendAlertPopupViewMessageLabel ;


	private int _alertType ;
	
	
	private void Awake(){
		
	}
	
	private void Start() {
		
	}
	
	public void InitLoadPresentSendAlertPopupView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadPresentSendAlertPopupView(int alertType) {
		
		_alertType = alertType ;
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetPresentSendAlertPopupView(alertType) ;
		
	}
	
	public void RemovePresentSendAlertPopupView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetPresentSendAlertPopupView(int alertType){
		
		if(alertType == 2101){ // 2101 : 선물을 보냈습니다.
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			if(Managers.UserData != null){ 
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_presentSendAlertPopupViewMessageLabel.text = Constant.AlertSendGiftOkMessageString(languageCode) ;
				
			}
			
		}else if(alertType == 2102){ // 2102 : 선물을 보내실 수 없습니다.
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_presentSendAlertPopupViewMessageLabel.text = Constant.AlertSendGiftErrorMessageString(languageCode) ;
				
			}
			
		}else if(alertType == 3101){ // 3101 : 모든 클랜원에게 어뢰를 선물하였습니다.
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_presentSendAlertPopupViewMessageLabel.text = Constant.AlertSendAllGiftOkMessageString(languageCode) ;
				
			}
			
		}else if(alertType == 3102){ // 3102 : 선물을 보내실 수 없습니다. (TimeOut)
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_presentSendAlertPopupViewMessageLabel.text = Constant.AlertSendAllGiftLimitErrorMessageString(languageCode) ;
				
			}
			
		}else if(alertType == 3103){ // 3103 : 선물을 보내실 수 없습니다.
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_presentSendAlertPopupViewMessageLabel.text = Constant.AlertSendAllGiftErrorMessageString(languageCode) ;
				
			}
			
		}else if(alertType == 4101){ // 4101 : 클랜원들에게 초대장을 보냈습니다.
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_presentSendAlertPopupViewMessageLabel.text = Constant.AlertSendAllInviteOkMessageString(languageCode) ;
				
			}
			
		}else if(alertType == 4102){ // 4102 : 클랜원들에게 초대장을 보내실 수 없습니다.(Time Out)
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_presentSendAlertPopupViewMessageLabel.text = Constant.AlertSendAllInviteErrorMessageString(languageCode) ;
				
			}
			
		}else if(alertType == 5101){ // 5101 : 네트워크 오류입니다.\n잠시 후 다시 시도해 주세요.
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			if(Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				//_presentSendAlertPopupViewMessageLabel.text = Constant.AlertSendAllInviteOkMessageString(languageCode) ;
				_presentSendAlertPopupViewMessageLabel.text = Constant.AlertSendAllNetworkErrorMessageString(languageCode) ;

			}
			
		}
		
	}

	public void SetPresentSendAlertPopupViewBlackSpriteAlpha(float alphaValue){
		_presentSendAlertPopupViewBlackSprite.alpha = alphaValue ;
	}
	
	private void OnClickPresentSendAlertPopupViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		RemovePresentSendAlertPopupView() ;
		
		if(_presentSendAlertPopupViewDelegate != null) {
			_presentSendAlertPopupViewDelegate(this, _alertType) ;
		}
		
	}
}
