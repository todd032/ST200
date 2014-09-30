using UnityEngine;
using System.Collections;

public class RewardChocolateAlertView : MonoBehaviour {
	
	
	[HideInInspector]
	public delegate void RewardChocolateAlertViewDelegate(RewardChocolateAlertView rewardChocolateAlertView);
	protected RewardChocolateAlertViewDelegate _rewardChocolateAlertViewDelegate ;
	public event RewardChocolateAlertViewDelegate RewardChocolateAlertViewEvent {
		add{
			
			_rewardChocolateAlertViewDelegate = null ;
			
			if (_rewardChocolateAlertViewDelegate == null)
        		_rewardChocolateAlertViewDelegate += value;
        }
		
		remove{
            _rewardChocolateAlertViewDelegate -= value;
		}
	}
	
	public UISprite _rewardIconSprite ;
	public UILabel _rewardChocolateAlertViewMessageLabel ;
	
	
		
	private void Awake(){
		
	}
	
	private void Start() {
		
	}
	
	public void InitLoadRewardChocolateAlertView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadRewardChocolateAlertView(int chocolateNum, string alertMessage) {
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetRewardChocolateAlertView(chocolateNum, alertMessage) ;
		
	}
	
	public void RemoveRewardChocolateAlertView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetRewardChocolateAlertView(int chocolateNum, string alertMessage){

		/* Remove !!!!!
		if(chocolateNum > 0){

			NGUITools.SetActive(_rewardIconSprite.gameObject, true) ;
			_rewardChocolateAlertViewMessageLabel.transform.localPosition = new Vector3(0f, 100f, -0.1f) ;

		}else{

			NGUITools.SetActive(_rewardIconSprite.gameObject, false) ;
			_rewardChocolateAlertViewMessageLabel.transform.localPosition = new Vector3(0f, 30f, -0.1f) ;

		}
		*/ // End Remove !!!!!


		NGUITools.SetActive(_rewardIconSprite.gameObject, false) ;
		_rewardChocolateAlertViewMessageLabel.transform.localPosition = new Vector3(0f, 30f, -0.1f) ;

		_rewardChocolateAlertViewMessageLabel.text = alertMessage ;
		
	}
	
	
	private void OnClickRewardChocolateAlertViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		RemoveRewardChocolateAlertView() ;
		
		if(_rewardChocolateAlertViewDelegate != null) {
			_rewardChocolateAlertViewDelegate(this) ;
		}
		
	}
}
