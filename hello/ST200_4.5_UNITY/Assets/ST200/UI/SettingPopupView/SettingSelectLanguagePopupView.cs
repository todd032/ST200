using UnityEngine;
using System.Collections;

public class SettingSelectLanguagePopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void SettingSelectLanguagePopupViewDelegate(SettingSelectLanguagePopupView settingSelectLanguagePopupView, int state);
	protected SettingSelectLanguagePopupViewDelegate _settingSelectLanguagePopupViewDelegate ;
	public event SettingSelectLanguagePopupViewDelegate SettingSelectLanguagePopupViewEvent {
		add{
			
			_settingSelectLanguagePopupViewDelegate = null ;
			
			if (_settingSelectLanguagePopupViewDelegate == null)
        		_settingSelectLanguagePopupViewDelegate += value;
        }
		
		remove{
            _settingSelectLanguagePopupViewDelegate -= value;
		}
	}

	
	//public UICheckbox _selectLanguageEn ;
	//public UICheckbox _selectLanguageKo ;
	//public UICheckbox _selectLanguageHant ;
	//public UICheckbox _selectLanguageHans ;
	//public UICheckbox _selectLanguageJa ;
	//public UICheckbox _selectLanguageFr ;
	
	private bool _isInitCheck = true ;
	
	
	private void Awake() {
		
	}
	
	private void Start() {
		
	}
	
	private void Update() {
	
	}
	
	
	public void InitLoadSettingSelectLanguagePopupView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadSettingSelectLanguagePopupView() {
		
		NGUITools.SetActive(gameObject, true) ;
		SetSettingSelectLanguagePopupView() ;
		
	}
	
	public void RemoveSettingSelectLanguagePopupView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetSettingSelectLanguagePopupView(){
		
		if(Managers.UserData != null){
			
			//_isInitCheck = true ;
			
			string languageCode = Managers.UserData.LanguageCode ;
			
			//if(languageCode.Equals("En")){
			//	_selectLanguageEn.isChecked = true ;
			//}else if(languageCode.Equals("Ko")){
			//	_selectLanguageKo.isChecked = true ;
			//}else if(languageCode.Equals("Hant")){
			//	_selectLanguageHant.isChecked = true ;
			//}else if(languageCode.Equals("Hans")){
			//	_selectLanguageHans.isChecked = true ;
			//}else if(languageCode.Equals("Ja")){
			//	_selectLanguageJa.isChecked = true ;
			//}else if(languageCode.Equals("Fr")){
			//	_selectLanguageFr.isChecked = true ;
			//}
			
		}
		
	}
	
	
	private void OnClickSettingSelectLanguagePopupViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		RemoveSettingSelectLanguagePopupView() ;
		
		if(_settingSelectLanguagePopupViewDelegate != null) {
			_settingSelectLanguagePopupViewDelegate(this, 500) ;	
		}	
		
	}
	
	private void OnActivate(string[] info){
		
		if(info[0].Equals("True")){
		
			if(info[1].Equals("SelectLanguageEn") || info[1].Equals("SelectLanguageKo") || info[1].Equals("SelectLanguageHant") || info[1].Equals("SelectLanguageHans")|| info[1].Equals("SelectLanguageJa")|| info[1].Equals("SelectLanguageFr")){
				if(_isInitCheck) {
					_isInitCheck = false ;
					return ;
				}else{
					if(Managers.Audio != null){
						Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
					}	
				}
			}
		
			
			if(info[1].Equals("SelectLanguageEn")){
				
				if(Managers.UserData != null){
				
					Managers.UserData.SaveLangueCode("En") ;
					
				}
				
			}else if(info[1].Equals("SelectLanguageKo")){
				
				if(Managers.UserData != null){
					
					Managers.UserData.SaveLangueCode("Ko") ;
					
				}
				
			}else if(info[1].Equals("SelectLanguageHant")){
				
				if(Managers.UserData != null){
				
					Managers.UserData.SaveLangueCode("Hant") ;
					
					
				}
				
			}else if(info[1].Equals("SelectLanguageHans")){
				
				if(Managers.UserData != null){
				
					Managers.UserData.SaveLangueCode("Hans") ;
					
					
				}
				
			}else if(info[1].Equals("SelectLanguageJa")){
				
				if(Managers.UserData != null){
				
					Managers.UserData.SaveLangueCode("Ja") ;
					
				}
				
			}else if(info[1].Equals("SelectLanguageFr")){
				
				if(Managers.UserData != null){
				
					Managers.UserData.SaveLangueCode("Fr") ;
					
				}
				
			}
			
		}else if(info[0].Equals("False")){
			//Nothing...
		}
		
	}
	
	
}
