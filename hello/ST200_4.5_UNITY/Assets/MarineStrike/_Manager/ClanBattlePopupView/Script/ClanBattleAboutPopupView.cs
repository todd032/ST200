using UnityEngine;
using System.Collections;

public class ClanBattleAboutPopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void ClanBattleAboutPopupViewDelegate(ClanBattleAboutPopupView clanBattleAboutPopupView, int state);
	protected ClanBattleAboutPopupViewDelegate _clanBattleAboutPopupViewDelegate ;
	public event ClanBattleAboutPopupViewDelegate ClanBattleAboutPopupViewEvent {
		add{
			
			_clanBattleAboutPopupViewDelegate = null ;
			
			if (_clanBattleAboutPopupViewDelegate == null)
				_clanBattleAboutPopupViewDelegate += value;
		}
		
		remove{
			_clanBattleAboutPopupViewDelegate -= value;
		}
	}

	public UISprite _clanBattleAboutBackgroundSprite ;
	public UILabel _clanBattleAboutPopupViewTextLabel ;


	private void Awake(){
		
	}
	
	private void Start() {
		
	}
	
	
	public void InitLoadClanBattleAboutPopupView(){
		
		NGUITools.SetActive(gameObject, false) ;
		
	}
	
	public void LoadClanBattleAboutPopupView(float viewHeight, string aboutMessage) {
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetClanBattleAboutPopupView(viewHeight, aboutMessage) ;
		
	}
	
	public void RemoveClanBattleAboutPopupView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetClanBattleAboutPopupView(float viewHeight, string aboutMessage){

		_clanBattleAboutBackgroundSprite.transform.localScale = new Vector3(450f, viewHeight, 1f) ;

		_clanBattleAboutPopupViewTextLabel.text = aboutMessage ;
		
	}
	
	private void OnClickClanBattleAboutPopupViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_clanBattleAboutPopupViewDelegate != null) {
			_clanBattleAboutPopupViewDelegate(this, 1) ; //Close ClanBattleAboutPopupView
		}
		
		RemoveClanBattleAboutPopupView() ;
		
	}

}
