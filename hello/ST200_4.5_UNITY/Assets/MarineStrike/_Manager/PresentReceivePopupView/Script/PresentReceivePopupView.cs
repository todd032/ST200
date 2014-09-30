using UnityEngine;
using System.Collections;

public class PresentReceivePopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void PresentReceivePopupViewDelegate(PresentReceivePopupView presentReceivePopupView, int state);
	protected PresentReceivePopupViewDelegate _presentReceivePopupViewDelegate ;
	public event PresentReceivePopupViewDelegate PresentReceivePopupViewEvent {
		add{
			
			_presentReceivePopupViewDelegate = null ;
			
			if (_presentReceivePopupViewDelegate == null)
        		_presentReceivePopupViewDelegate += value;
        }
		
		remove{
            _presentReceivePopupViewDelegate -= value;
		}
	}
	
	public UILabel _presentReceivePopupViewMessageLabel ;
	
	
	private int _alertType ;
	public UILabel m_OkLabel;
	private void Awake(){
		m_OkLabel.text = Constant.COLOR_POPUP_BUTTON + TextManager.Instance.GetString(147);
	}
	
	private void Start() {
	}
	
	public void InitLoadPresentReceivePopupView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadPresentReceivePopupView(int alertType) { // 1:One Receive Present   2:All Receive Present
		NGUITools.SetActive(gameObject, true) ;
		
		_alertType = alertType ;
		
		SetPresentReceivePopupView(alertType) ;
	}
	
	public void RemovePresentReceivePopupView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetPresentReceivePopupView(int alertType){
		if(alertType == 1) { // 1:One Receive Present   2:All Receive Present
			if(Managers.UserData != null){
				string languageCode = Managers.UserData.LanguageCode ;
				_presentReceivePopupViewMessageLabel.text = Constant.COLOR_BLACK + TextManager.Instance.GetString (83);
			}
		}else if(alertType == 2){ // 1:One Receive Present   2:All Receive Present
			if(Managers.UserData != null){
				string languageCode = Managers.UserData.LanguageCode ;
				_presentReceivePopupViewMessageLabel.text = Constant.COLOR_BLACK + TextManager.Instance.GetString (83);
			}
		}
	}
	
	public void OnClickPresentReceivePopupViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		RemovePresentReceivePopupView() ;
		
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			RemovePresentReceivePopupView();
			return true;
		}
		
		return false;
	}
}
