using UnityEngine;
using System.Collections;

public class UpdateInfoPopupView : MonoBehaviour {
	
	
	[HideInInspector]
	public delegate void UpdateInfoPopupViewDelegate(UpdateInfoPopupView updateInfoPopupView, int state);
	protected UpdateInfoPopupViewDelegate _updateInfoPopupViewDelegate ;
	public event UpdateInfoPopupViewDelegate UpdateInfoPopupViewEvent{
		add{
			
			_updateInfoPopupViewDelegate = null ;
			
			if (_updateInfoPopupViewDelegate == null)
        		_updateInfoPopupViewDelegate += value;
        }
		
		remove{
            _updateInfoPopupViewDelegate -= value;
		}
	}
	
	
	public UILabel _updateInfoPopupViewTextLabel ;
	
	

	private void Awake() {
		
	}
	
	private void Start() {
		
	}
	
	private void Update() {
		
	}
	
	
	
	
	public void InitLoadUpdateInfoPopupView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadUpdateInfoPopupView() {
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetUpdateInfoPopupView() ;
		
	}
	
	public void RemoveUpdateInfoPopupView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetUpdateInfoPopupView(){
		
		if(Managers.UserData != null){
		
			string languageCode = Managers.UserData.LanguageCode ;
		
			_updateInfoPopupViewTextLabel.text = Constant.UpdateInfoPopupViewTextLabelString(languageCode) ;
			
		}
		
	}
	
	
	private void OnClickUpdateInfoPopupViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		//RemoveUpdateInfoPopupView() ;
		
		if(_updateInfoPopupViewDelegate != null) {
			_updateInfoPopupViewDelegate(this, 100) ;	
		}	
		
	}
	
}
