using UnityEngine;
using System.Collections;

public class PresentSendPopupView : MonoBehaviour {
	
	[HideInInspector]
	public delegate void PresentSendPopupViewDelegate(PresentSendPopupView presentSendPopupView, int state);
	protected PresentSendPopupViewDelegate _presentSendPopupViewDelegate ;
	public event PresentSendPopupViewDelegate PresentSendPopupViewEvent {
		add{
			
			_presentSendPopupViewDelegate = null ;
			
			if (_presentSendPopupViewDelegate == null)
        		_presentSendPopupViewDelegate += value;
        }
		
		remove{
            _presentSendPopupViewDelegate -= value;
		}
	}
	
	
	public UILabel _presentSendPopupViewSendTargetLabel ;
	
	
	//private AfreecaTvData.ClanRankingPlayer _sendTartgetClanPlayer ;
	private ClanRankListCell _clanRankListCell ;
	
	
	
	private void Awake(){
	}
	
	private void Start() {
	}
	
	public void InitLoadPresentSendPopupView(){

		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadPresentSendPopupView(ClanRankListCell clanRankListCell) {

		NGUITools.SetActive(gameObject, true) ;
		
		_clanRankListCell = clanRankListCell ;
		
		SetPresentSendPopupView(clanRankListCell) ;
		
	}
	
	public void RemovePresentSendPopupView() {

		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetPresentSendPopupView(ClanRankListCell clanRankListCell){
		
		string targetUserName = clanRankListCell.ClanRankingPlayerInfo.nickname ;
		
		_presentSendPopupViewSendTargetLabel.text = targetUserName + " 님께";
		
	}
	
	private void OnClickPresentSendPopupViewCancelButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		RemovePresentSendPopupView() ;
	}
	
	private void OnClickPresentSendPopupViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		
		// Connect Indicator Start!!
		if(_presentSendPopupViewDelegate != null){
			_presentSendPopupViewDelegate(this, 1101) ;	
		}
		
		
		NativeHelper_Afreeca.Instance.AfreecaTVConnectCompleteEvent += (returnAction) => {

			if (returnAction.Equals("SendMessage")){

				Managers.DataStream.Event_Delegate_DataStreamManager_SendMessageInfo += (intNetworkResultCode_Input) => {
					
					if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
						
						_clanRankListCell.SetSendTorpedoButtonEnable(false) ;
						
						// Message..
						// 선물을 보냈습니다.
						if(_presentSendPopupViewDelegate != null) {
							
							_presentSendPopupViewDelegate(this, 2101) ;	
						}
						
						if (_presentSendPopupViewDelegate != null){
							_presentSendPopupViewDelegate(this, 1102) ;	
						}

					}else {
						
						if (_presentSendPopupViewDelegate != null) {
							
							_presentSendPopupViewDelegate(this, 2102) ;	
						}
						
						if (_presentSendPopupViewDelegate != null){
							
							_presentSendPopupViewDelegate(this, 1102) ;	
						}
					}
				};

				StartCoroutine(Managers.DataStream.Network_SendMessageInfo(_clanRankListCell.ClanRankingPlayerInfo.user_id, AfreecaTvData.Instance.userInfo.nickname)) ;
			}
		} ;
		
		NativeHelper_Afreeca.Instance.AfreecaTVConnectErrorEvent += (returnAction, errorCode, errorMessage) => {

			if(returnAction.Equals("SendMessage")){
				//로그인 되어 있다고 하더라도.. 오류 발생시 다시 로그인 해야 함..
				//로그인 화면으로 이동.
				
				//Error..
				// 선물을 보내실 수 없습니다.
				if(_presentSendPopupViewDelegate != null) {
					_presentSendPopupViewDelegate(this, 2102) ;	
				}
				
				// Connect End!!
				if(_presentSendPopupViewDelegate != null){
					_presentSendPopupViewDelegate(this, 1102) ;	
				}
				//
				
				//RemovePresentSendPopupView() ;
				
			}
		};
		
		NativeHelper_Afreeca.Instance.paramReceiverId =_clanRankListCell.ClanRankingPlayerInfo.user_id ;
		NativeHelper_Afreeca.Instance.paramMessage = AfreecaTvData.Instance.userInfo.nickname + " 님께서 어뢰를 선물하셨습니다.";
		NativeHelper_Afreeca.Instance.Request("SendMessage");
		
		
	}
	
}
