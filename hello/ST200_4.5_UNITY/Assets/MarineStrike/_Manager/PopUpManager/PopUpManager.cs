using UnityEngine;
using System.Collections;

public class PopUpManager : MonoBehaviour {

	public UILabel _displayGameGoldLabel ;
	public UILabel _displayGameJewelLabel ;
	
	public void LoadGameGoldAndGameJewelInfo(){
		
		if(Managers.UserData != null){
			
			int gameGold = Managers.UserData.GetGameGold() ;
			if(gameGold == 0){
				_displayGameGoldLabel.text = gameGold.ToString() ;
			}else{
				_displayGameGoldLabel.text = gameGold.ToString("#,#") ;	
			}
			
			
			int gameJewel = Managers.UserData.GetGameJewel() ;
			if(gameJewel == 0) {
				_displayGameJewelLabel.text = gameJewel.ToString() ;	
			}else {
				_displayGameJewelLabel.text = gameJewel.ToString("#,#") ;	
			}
			
		}		
	}

	public UILabel _displayTorpedoLabel ;
	public UILabel _displayTorpedoTimeLabel ;
	public UISprite _displayTorpedoMaxSprite ;
	
	private void InitializeGameTorpedoInfo() {
		StartCoroutine("LoadGameTorpedoInfo") ;
	}
	
	private IEnumerator LoadGameTorpedoInfo(){
		
		bool _isMax = false ;
		
		while(true){
			
			if(Managers.UserData != null){
				
				int torpedoCount = Managers.Torpedo.GetTorpedoCount();
				if(torpedoCount == 0){
					_displayTorpedoLabel.text = "X "+ torpedoCount.ToString() ;
				}else{
					_displayTorpedoLabel.text = "X "+ torpedoCount.ToString("#,#") ;	
				}
				
				
				if(torpedoCount >= Managers.GameBalanceData.TorpedoMaxValue){
					//_displayTorpedoTimeLabel.text = "MAX" ;
					if(!_isMax){
						NGUITools.SetActive(_displayTorpedoTimeLabel.gameObject, false) ;
						NGUITools.SetActive(_displayTorpedoMaxSprite.gameObject, true) ;
						_isMax = true ;
					}
					
				}else{
					
					if(_isMax){
						NGUITools.SetActive(_displayTorpedoTimeLabel.gameObject, true) ;
						NGUITools.SetActive(_displayTorpedoMaxSprite.gameObject, false) ;
						_isMax = false ;
					}
					
					int remindTime = Managers.UserData.TorpedoRechargeNextTime - Managers.UserData.GetSyncServerTime() ;
					
					if(remindTime < 0){
						remindTime = 0 ;
					}
					
					
					if(remindTime > 0){
						
						int quotient = Mathf.FloorToInt(remindTime/60f) ; //System.Math.Floor(remindTime/60) ;
						int remainder = remindTime % 60 ;
						
						_displayTorpedoTimeLabel.text = string.Format("{0:0}:{1:00}", quotient, remainder);
						
					}else{
						_displayTorpedoTimeLabel.text = "0:00" ;	
					}
					
				}
				
			}
			
			yield return new WaitForSeconds(1f) ;
			
		}
		
	}
}
