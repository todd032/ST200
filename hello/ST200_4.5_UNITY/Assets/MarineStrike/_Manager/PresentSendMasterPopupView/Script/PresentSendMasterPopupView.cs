using UnityEngine;
using System.Collections;

public class PresentSendMasterPopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void PresentSendMasterPopupViewDelegate(PresentSendMasterPopupView presentSendMasterPopupView, int state);
	protected PresentSendMasterPopupViewDelegate _presentSendMasterPopupViewDelegate ;
	public event PresentSendMasterPopupViewDelegate PresentSendMasterPopupViewEvent {
		add{
			
			_presentSendMasterPopupViewDelegate = null ;
			
			if (_presentSendMasterPopupViewDelegate == null)
        		_presentSendMasterPopupViewDelegate += value;
        }
		
		remove{
            _presentSendMasterPopupViewDelegate -= value;
		}
	}
	
	
	public UILabel _presentSendMasterPopupViewMessageLabel ;
	
	private int _sendMessageType ;
	
	private void Awake(){
	}
	
	private void Start() {
	}
	
	public void InitLoadPresentSendMasterPopupView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadPresentSendMasterPopupView(int sendMessageType) {
		NGUITools.SetActive(gameObject, true) ;
		
		_sendMessageType = sendMessageType ;
		
		SetPresentSendMasterPopupView(sendMessageType) ;
		
	}
	
	public void RemovePresentSendMasterPopupView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetPresentSendMasterPopupView(int sendMessageType){
		
		if(sendMessageType == 1){ //클랜원들에게 초대장을 보내시겠습니까?
			_presentSendMasterPopupViewMessageLabel.text = "클랜원들에게 초대장을 보내시겠습니까?" ;
		}else if(sendMessageType == 2){ // 모든 클랜원에게 어뢰를 선물하시겠습니까?
			_presentSendMasterPopupViewMessageLabel.text = "모든 클랜원에게 어뢰를 선물하시겠습니까?" ;
		}
		
	}
	
	private void OnClickPresentSendMasterPopupViewCancelButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		RemovePresentSendMasterPopupView() ;
	}
	
	private void OnClickPresentSendMasterPopupViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		
		// Connect Indicator Start!!
		if(_presentSendMasterPopupViewDelegate != null){
			_presentSendMasterPopupViewDelegate(this, 1101) ;	
		}
		
		
		if(_sendMessageType == 1){ //클랜원들에게 초대장을 보내시겠습니까?
			
			NativeHelper_Afreeca.Instance.AfreecaTVConnectCompleteEvent += (returnAction) => {

				if (returnAction.Equals("SendGroupMessage")){

					Managers.DataStream.Event_Delegate_DataStreamManager_SendGroupInviteInfo += (intNetworkResultCode_Input) => {

						if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){ // OK!!
							
							//클랜원들에게 초대장을 보냈습니다.
							if (_presentSendMasterPopupViewDelegate != null) {

								_presentSendMasterPopupViewDelegate(this, 4101) ;	
							}
							
							// Connect End!!
							if (_presentSendMasterPopupViewDelegate != null){

								_presentSendMasterPopupViewDelegate(this, 1102) ;	
							}

						}else{ //Fail

							//Error..
							// 5101 : 네트워크 오류입니다.\n잠시 후 다시 시도해 주세요.
							if (_presentSendMasterPopupViewDelegate != null) {

								_presentSendMasterPopupViewDelegate(this, 5101) ;	
							}

							// Connect End!!
							if(_presentSendMasterPopupViewDelegate != null){
								_presentSendMasterPopupViewDelegate(this, 1102) ;	
							}
						}
					};

					StartCoroutine(Managers.DataStream.Network_SendGroupInviteInfo(AfreecaTvData.Instance.userInfo.clan_id)) ;
				}
			} ;
			
			NativeHelper_Afreeca.Instance.AfreecaTVConnectErrorEvent += (returnAction, errorCode, errorMessage) => {
				if(returnAction.Equals("SendGroupMessage")){
					
					//Error..
					// 클랜원들에게 초대장을 보내실 수 없습니다.
					if(_presentSendMasterPopupViewDelegate != null) {
						_presentSendMasterPopupViewDelegate(this, 4102) ;	
					}
					
					// Connect End!!
					if(_presentSendMasterPopupViewDelegate != null){
						_presentSendMasterPopupViewDelegate(this, 1102) ;	
					}
					//
					
					//RemovePresentSendPopupView() ;
					
				}
			};
			
			NativeHelper_Afreeca.Instance.paramMessage = "클랜장으로부터 특별한 초대… BJ와 함께 GO! GO!" ;
			NativeHelper_Afreeca.Instance.paramMessageType = "invite";	//초대 메시지의 경우..
			NativeHelper_Afreeca.Instance.Request("SendGroupMessage");
			
			
		}else if(_sendMessageType == 2){ // 모든 클랜원에게 어뢰를 선물하시겠습니까?
			
			NativeHelper_Afreeca.Instance.AfreecaTVConnectCompleteEvent += (returnAction) => {
				if(returnAction.Equals("SendGroupMessage")){
					
					Managers.DataStream.Event_Delegate_DataStreamManager_SendGroupInviteInfo += (intNetworkResultCode_Input) => {

						if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
							
							// Message..
							// 모든 클랜원에게 어뢰를 선물하였습니다.
							if (_presentSendMasterPopupViewDelegate != null) {

								_presentSendMasterPopupViewDelegate(this, 3101) ;	
							}

							// Connect End!!
							if (_presentSendMasterPopupViewDelegate != null){

								_presentSendMasterPopupViewDelegate(this, 1102) ;	
							}
							//

						} else { //Fail

							//Error..
							// 선물을 보내실 수 없습니다.
							if (_presentSendMasterPopupViewDelegate != null) {

								_presentSendMasterPopupViewDelegate(this, 3103) ;	
							}

							// Connect End!!
							if (_presentSendMasterPopupViewDelegate != null){

								_presentSendMasterPopupViewDelegate(this, 1102) ;	
							}

							//RemovePresentSendPopupView() ;
						}
					};

					StartCoroutine(Managers.DataStream.Network_SendGroupMessageInfo(AfreecaTvData.Instance.userInfo.user_id)) ;
				}
			} ;
			
			NativeHelper_Afreeca.Instance.AfreecaTVConnectErrorEvent += (returnAction, errorCode, errorMessage) => {
				if(returnAction.Equals("SendGroupMessage")){
					
					//Error..
					// 선물을 보내실 수 없습니다.
					if(_presentSendMasterPopupViewDelegate != null) {
						_presentSendMasterPopupViewDelegate(this, 3102) ;	
					}
					
					// Connect End!!
					if(_presentSendMasterPopupViewDelegate != null){
						_presentSendMasterPopupViewDelegate(this, 1102) ;	
					}
					//
					
					//RemovePresentSendPopupView() ;
					
				}
			};
			
			NativeHelper_Afreeca.Instance.paramMessage = "클랜장으로부터 특별한 선물." ;
			NativeHelper_Afreeca.Instance.paramMessageType = "gift";	//선물 메시지의 경우..
			NativeHelper_Afreeca.Instance.Request("SendGroupMessage");
			
		}
		
	}
	
	
}
