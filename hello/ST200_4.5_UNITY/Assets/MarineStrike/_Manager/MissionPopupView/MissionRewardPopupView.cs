using UnityEngine;
using System.Collections;

public class MissionRewardPopupView : MonoBehaviour {
	
	[HideInInspector]
	public delegate void MissionRewardPopupViewDelegate(MissionRewardPopupView missionRewardPopupView, int state);
	protected MissionRewardPopupViewDelegate _missionRewardPopupViewDelegate ;
	public event MissionRewardPopupViewDelegate MissionRewardPopupViewEvent {
		add{
			
			_missionRewardPopupViewDelegate = null ;
			
			if (_missionRewardPopupViewDelegate == null)
        		_missionRewardPopupViewDelegate += value;
        }
		
		remove{
            _missionRewardPopupViewDelegate -= value;
		}
	}
	
	
	
	public UILabel _rewardTextLabel ;
	public UILabel _rewardValueLabel ;
	public UISprite _rewardTypeSprite ;
	
	public UISprite _fxLightSprite ;
	
	
	
	private void Awake(){
		
	}
	
	private void Start() {
		
	}
	
	
	public void InitLoadMissionRewardPopupView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadMissionRewardPopupView(int compensationType, int compensationNumber) {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Gain,false);
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetMissionRewardPopupView(compensationType, compensationNumber) ;
		
	}
	
	public void RemoveMissionRewardPopupView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	
	// 
	private void SetMissionRewardPopupView(int compensationType, int compensationNumber) {
		
		
		if(Managers.UserData != null) {
			string languageCode = Managers.UserData.LanguageCode ;
			
			_rewardTextLabel.text = Constant.MissionRewardPopupViewRewardTextLabelString(languageCode) ;
			
		}
		
		
		//
		if(compensationType == 1 ){
			_rewardTypeSprite.spriteName = "item_gold_B" ;
		}else if(compensationType == 2){
			_rewardTypeSprite.spriteName = "item_TopCrystal_B" ;
		}
		
		_rewardValueLabel.text = compensationNumber.ToString("#,#") ;
		
		
	}
	
	//
	private void OnClickRewardOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		RemoveMissionRewardPopupView() ;
	}
	
	
	
	
}
