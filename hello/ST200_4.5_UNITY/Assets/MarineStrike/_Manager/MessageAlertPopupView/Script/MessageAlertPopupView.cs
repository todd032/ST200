using UnityEngine;
using System.Collections;

public class MessageAlertPopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void MessageAlertPopupViewDelegate(MessageAlertPopupView messageAlertPopupView, int state);
	protected MessageAlertPopupViewDelegate _messageAlertPopupViewDelegate ;
	public event MessageAlertPopupViewDelegate MessageAlertPopupViewEvent{
		add{
			
			_messageAlertPopupViewDelegate = null ;
			
			if (_messageAlertPopupViewDelegate == null)
        		_messageAlertPopupViewDelegate += value;
        }
		
		remove{
            _messageAlertPopupViewDelegate -= value;
		}
	}
	
	
	public UILabel _messageAlertPopupViewTextLabel ;
	public UILabel m_TitleLabel;
	

	private void Awake() {
		
	}
	
	private void Start() {
		
	}
	
	private void Update() {
		
	}
	
	
	
	
	public void InitLoadMessageAlertPopupView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadMessageAlertPopupView(string messageText) {
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetMessageAlertPopupView(messageText) ;
		
	}
	
	public void RemoveMessageAlertPopupView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetMessageAlertPopupView(string messageText){
		
		_messageAlertPopupViewTextLabel.text = messageText ;
		
	}
	
	
	private void OnClickMessageAlertPopupViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		RemoveMessageAlertPopupView() ;
		
	}
	
}
