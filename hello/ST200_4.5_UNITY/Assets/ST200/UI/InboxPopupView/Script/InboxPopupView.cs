using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
using SimpleJSON ;

public class InboxPopupView : MonoBehaviour {
	
	[HideInInspector]
	public delegate void InboxPopupViewDelegate(InboxPopupView inboxPopupView, int state);
	protected InboxPopupViewDelegate _inboxPopupViewDelegate ;
	public event InboxPopupViewDelegate InboxPopupViewEvent {
		add{
			
			_inboxPopupViewDelegate = null ;
			
			if (_inboxPopupViewDelegate == null)
        		_inboxPopupViewDelegate += value;
        }
		
		remove{
            _inboxPopupViewDelegate -= value;
		}
	}
	
	public UILabel m_TitleLabel;
	public UILabel m_DescriptionLabel;
	public UILabel m_ReceiveAllLabel;
	
	// GetMessageList
	public struct GetMessageListDataStruct {
		
		private string _msgSeq ;
		public string MsgSeq {
			set { 
				string encryptString = LoadingWindows.NextE(value,Constant.DefalutAppName) ;
				_msgSeq = encryptString ;
			}
			get {
				if(_msgSeq == null || _msgSeq.Equals("")){
					return null ;	
				}
				string decryptString = LoadingWindows.NextD(_msgSeq,Constant.DefalutAppName) ;
				return decryptString;
			}
		}
		
		private string _senderId ;
		public string SenderId {
			set {  _senderId = value ; }
			get { return _senderId; }
		}
		
		private string _senderNickname ;
		public string SenderNickname {
			set { _senderNickname = value ; }
			get { return _senderNickname ; }
		}
		
		private string _messageTitle ;
		public string MessageTitle {
			set { _messageTitle = value ; }
			get { return _messageTitle ; }
		}
		
		private string _itemCode ;
		public string ItemCode {
			set { 
				string encryptString = LoadingWindows.NextE(value,Constant.DefalutAppName) ;
				_itemCode = encryptString ;
			}
			get {
				if(_itemCode == null || _itemCode.Equals("")){
					return null ;	
				}
				string decryptString = LoadingWindows.NextD(_itemCode,Constant.DefalutAppName) ;
				return decryptString;
			}
		}
		
		private string _itemCount ;
		public string ItemCount {
			set { 
				string encryptString = LoadingWindows.NextE(value,Constant.DefalutAppName) ;
				_itemCount = encryptString ;
			}
			get {
				if(_itemCount == null || _itemCount.Equals("")){
					return null ;	
				}
				string decryptString = LoadingWindows.NextD(_itemCount,Constant.DefalutAppName) ;
				return decryptString;
			}
		}
		
	}
	//
	
	
	
	
	public PresentReceivePopupView _presentReceivePopupView ;
	
	public InboxListPanel _inboxListPanel ;
	public GameObject m_PresentListPivot;

	private List<GetMessageListDataStruct> _getMessageListDataList ;
			
	private void Awake() {
		
		_getMessageListDataList = new List<GetMessageListDataStruct>() ;
		
		_presentReceivePopupView.PresentReceivePopupViewEvent += PresentReceivePopupViewDelegate ;
		_presentReceivePopupView.InitLoadPresentReceivePopupView() ;
		
		_inboxListPanel.InboxListPanelEvent += InboxListPanelDelegate ;

		m_TitleLabel.text = Constant.COLOR_MAIL_TITLE + TextManager.Instance.GetString(79);
		m_DescriptionLabel.text = Constant.COLOR_MAIL_INFO + TextManager.Instance.GetString(80);
		m_ReceiveAllLabel.text = Constant.COLOR_MAIL_RECEIVE_ALL + TextManager.Instance.GetString(82);

	}
	
	private void Start() {
		ShowPresentList();
	}
	
	private void Update() {
	}
	
	//Delegate
	private void PresentReceivePopupViewDelegate(PresentReceivePopupView presentReceivePopupView, int state) {
		//Nothing..
	}
	
	private void InboxListPanelDelegate(InboxListPanel inboxListPanel, InboxListGrid inboxListGrid, InboxListCell inboxListCell, int state) {
		if(state == 100){ // Present Receive Button
			
			
			// 삭제 및 받은 정보 서버로 전송...
			// Connect Indicator Start..
			if(_inboxPopupViewDelegate != null){
				_inboxPopupViewDelegate(this, 1001) ;  // 1001 : Root Indicator Start!!
			}
			
			Managers.DataStream.Event_Delegate_DataStreamManager_OpenMessage += (intNetworkResultCode_Input) => {

				if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
					
					bool isDone = false ;
					int itemCodeInt = int.Parse(inboxListCell.GetMessageListData.ItemCode) ;
					Debug.Log("ITEMCODE: " + itemCodeInt);

					if(itemCodeInt == Constant.ST200_ITEM_HEART)
					{
						Managers.Torpedo.AddTorpedo(int.Parse(inboxListCell.GetMessageListData.ItemCount));
						_getMessageListDataList.Remove(inboxListCell.GetMessageListData) ;
						
						isDone = true ;
					}else if(itemCodeInt == Constant.ST200_ITEM_JEWEL)
					{
						Managers.UserData.SetGainJewel(int.Parse(inboxListCell.GetMessageListData.ItemCount)) ;
						_getMessageListDataList.Remove(inboxListCell.GetMessageListData) ;
						isDone = true ;
						
						if (_inboxPopupViewDelegate != null){
							
							_inboxPopupViewDelegate(this, 5001) ;  // 5001 : Refresh Gold And Jewel..
						}
					}else if(itemCodeInt == Constant.ST200_ITEM_COIN)
					{
						Managers.UserData.SetPurchaseGold(int.Parse(inboxListCell.GetMessageListData.ItemCount)) ;
						_getMessageListDataList.Remove(inboxListCell.GetMessageListData) ;
						isDone = true ;
						
						if (_inboxPopupViewDelegate != null){
							
							_inboxPopupViewDelegate(this, 5001) ;  // 5001 : Refresh Gold And Jewel..
						}
					}else if(itemCodeInt == Constant.ST200_ITEM_SHOUT ||
					         itemCodeInt == Constant.ST200_ITEM_SINGIJEON || 
					         itemCodeInt == Constant.ST200_ITEM_REVIVE)
					{
						_getMessageListDataList.Remove(inboxListCell.GetMessageListData) ;
						Managers.UserData.SetPurchaseGameItem(itemCodeInt, int.Parse(inboxListCell.GetMessageListData.ItemCount)) ;
						isDone = true ;
					}else if(itemCodeInt >= Constant.ST200_ITEM_CHARACTER_STARTCODE &&
					         itemCodeInt < Constant.ST200_ITEM_CHARACTER_STARTCODE + 1000)
					{
						//receive character
						_getMessageListDataList.Remove(inboxListCell.GetMessageListData) ;
						Managers.UserData.SetPurchaseGameCharacter(itemCodeInt - Constant.ST200_ITEM_CHARACTER_STARTCODE + 1);
						isDone = true ;
					}else if(itemCodeInt >= Constant.ST200_ITEM_SHIP_STARTCODE &&
					         itemCodeInt < Constant.ST200_ITEM_SHIP_STARTCODE + 1000)
					{
						//receive ship
						UserShipData selectshipdata = Managers.UserData.GetUserShipData(itemCodeInt - Constant.ST200_ITEM_SHIP_STARTCODE + 1);
						selectshipdata.IsPurchase = true;
						Managers.UserData.SetSelectedUserShipData(selectshipdata);
						isDone = true ;
					}else if(itemCodeInt >= Constant.ST200_ITEM_SUBSHIP_STARTCODE &&
					         itemCodeInt < Constant.ST200_ITEM_SUBSHIP_STARTCODE + 1000)
					{
						//receive subship

					}

					if (isDone){

						if (Managers.DataStream != null){

							if (Managers.UserData != null){

								Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
								Managers.UserData.UpdateSequence++;
								UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
								
								Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
							}
						}
					}

					_inboxListPanel.DeleteInboxListCell(inboxListCell) ;
					
					_presentReceivePopupView.LoadPresentReceivePopupView(1) ;

					// Connect Indicator Stop..
					if (_inboxPopupViewDelegate != null){

						_inboxPopupViewDelegate(this, 1002) ;  // 1002 : Root Indicator Stop!!
					}
					
				}else { //Fail

					if (_inboxPopupViewDelegate != null){

						_inboxPopupViewDelegate(this, 1002) ;  // 1002 : Root Indicator Stop!!
					}
				}
				GameUIManager.Instance.LoadGameGoldAndGameJewelInfo();
			};

			StartCoroutine(Managers.DataStream.Network_OpenMessage(inboxListCell.GetMessageListData.MsgSeq));
		}

		UpdateNewMessage();
	}

	
	public void InitLoadInboxPopupView(){
		NGUITools.SetActive(gameObject, false) ;
		//NGUITools.SetActive(_inboxInfoNoItemMessageLabel.gameObject, false) ;
	}
	
	public void LoadInboxPopupView() {
		NGUITools.SetActive(gameObject, true) ;
		SetInboxPopupView() ;
		UpdateNewMessage();
	}
	
	public void RemoveInboxPopupView() {
		NGUITools.SetActive(_presentReceivePopupView.gameObject, false) ;
		NGUITools.SetActive(gameObject, false) ;
		GameUIManager.Instance.m_MainUI.UpdateUI();
	}
	
	private void SetInboxPopupView(){
		
		_inboxListPanel.DeleteAllInboxListGrid(false) ;
		
		
		// 만약 RankManager에서 수신함 데이터를 처리할 시..
		
		// Connect Indicator Start..
		if(_inboxPopupViewDelegate != null){
			_inboxPopupViewDelegate(this, 1001) ;  // 1001 : Root Indicator Start!!
		}
		
		
		Managers.DataStream.Event_Delegate_DataStreamManager_GetMessageList += (strResultExtendJson_Input, intNetworkResultCode_Input) => {

			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
				
				_getMessageListDataList.Clear() ;
				
				JSONNode root = JSON.Parse(strResultExtendJson_Input);

				for ( int i=0; i<root.Count; ++i ) {

					JSONNode data = root[i];
					
					GetMessageListDataStruct getMessageListDataStruct = new GetMessageListDataStruct() ;
					getMessageListDataStruct.MsgSeq = data["msg_seq"] ;
					getMessageListDataStruct.SenderId = data["sender_id"] ;
					getMessageListDataStruct.SenderNickname = data["sender_nickname"] ;
					getMessageListDataStruct.MessageTitle = data["msg_title"] ;
					getMessageListDataStruct.ItemCode = data["item_code"] ;
					getMessageListDataStruct.ItemCount = data["item_count"] ;
					
					_getMessageListDataList.Add(getMessageListDataStruct) ;
				}
				Debug.Log("GOT COUT: " +root.Count);

#if UNITY_EDITOR
				GetMessageListDataStruct getMessageListDataStructtest = new GetMessageListDataStruct() ;
				getMessageListDataStructtest.MsgSeq =  "1";
				getMessageListDataStructtest.SenderId = "123" ;
				getMessageListDataStructtest.SenderNickname = "hi";
				getMessageListDataStructtest.MessageTitle = "SHOUT ITEM TEST";
				getMessageListDataStructtest.ItemCode = Constant.ST200_ITEM_SHOUT.ToString();
				getMessageListDataStructtest.ItemCount = "1";
				_getMessageListDataList.Add(getMessageListDataStructtest) ;
#endif
				//GetMessageListDataStruct tempdata = new GetMessageListDataStruct();
				//tempdata.MsgSeq = "2";
				//tempdata.SenderId = "00";
				//tempdata.SenderNickname = "TEST";
				//tempdata.MessageTitle = "TTT";
				//_getMessageListDataList.Add(tempdata);

				_inboxListPanel.LoadInboxListPanel(_getMessageListDataList);

				// Connect Indicator Stop..
				if (_inboxPopupViewDelegate != null){

					_inboxPopupViewDelegate(this, 1002) ;  // 1002 : Root Indicator Stop!!
				}
				
			} else { //Fail
				
				// Connect Indicator Stop..
				if (_inboxPopupViewDelegate != null){

					_inboxPopupViewDelegate(this, 1002) ;  // 1002 : Root Indicator Stop!!
				}
			}

		};
		
		StartCoroutine(Managers.DataStream.Network_GetMessageList()) ;
	}
	
	
	public void OnClickInboxPopupViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		RemoveInboxPopupView() ;
		
		if(_inboxPopupViewDelegate != null) {
			_inboxPopupViewDelegate(this, 500);
		}	
		
	}
	
	public void OnClickInboxPopupViewAllReceiveButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		
		// 삭제 및 받은 정보 서버로 전송...
		// Connect Indicator Start..
		if(_inboxPopupViewDelegate != null){
			_inboxPopupViewDelegate(this, 1001) ;  // 1001 : Root Indicator Start!!
		}
			
		Managers.DataStream.Event_Delegate_DataStreamManager_OpenAllMessage += (intNetworkResultCode_Input) => {

			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){

				int TorpedoTotalAddCount = 0;
				for (int i = 0 ; i < _getMessageListDataList.Count ; i++)
				{
					
					GetMessageListDataStruct getMessageListDataStruct = _getMessageListDataList[i] ;
					
					int itemCodeInt = int.Parse(getMessageListDataStruct.ItemCode) ;

					if(itemCodeInt == Constant.ST200_ITEM_HEART)
					{
						TorpedoTotalAddCount++;

					}else if(itemCodeInt == Constant.ST200_ITEM_JEWEL)
					{
						Managers.UserData.SetGainJewel(int.Parse(getMessageListDataStruct.ItemCount)) ;
												
						if (_inboxPopupViewDelegate != null){
							
							_inboxPopupViewDelegate(this, 5001) ;  // 5001 : Refresh Gold And Jewel..
						}
					}else if(itemCodeInt == Constant.ST200_ITEM_COIN)
					{
						Managers.UserData.SetPurchaseGold(int.Parse(getMessageListDataStruct.ItemCount)) ;
						
						if (_inboxPopupViewDelegate != null){
							
							_inboxPopupViewDelegate(this, 5001) ;  // 5001 : Refresh Gold And Jewel..
						}
					}else if(itemCodeInt == Constant.ST200_ITEM_SHOUT ||
					         itemCodeInt == Constant.ST200_ITEM_SINGIJEON || 
					         itemCodeInt == Constant.ST200_ITEM_REVIVE)
					{
						Managers.UserData.SetPurchaseGameItem(itemCodeInt, int.Parse(getMessageListDataStruct.ItemCount)) ;
					}else if(itemCodeInt >= Constant.ST200_ITEM_CHARACTER_STARTCODE &&
					         itemCodeInt < Constant.ST200_ITEM_CHARACTER_STARTCODE + 1000)
					{
						//receive character
						Managers.UserData.SetPurchaseGameCharacter(itemCodeInt - Constant.ST200_ITEM_CHARACTER_STARTCODE + 1);
					}else if(itemCodeInt >= Constant.ST200_ITEM_SHIP_STARTCODE &&
					         itemCodeInt < Constant.ST200_ITEM_SHIP_STARTCODE + 1000)
					{
						//receive ship
						UserShipData selectshipdata = Managers.UserData.GetUserShipData(itemCodeInt - Constant.ST200_ITEM_SHIP_STARTCODE + 1);
						selectshipdata.IsPurchase = true;
						Managers.UserData.SetSelectedUserShipData(selectshipdata);
					}else if(itemCodeInt >= Constant.ST200_ITEM_SUBSHIP_STARTCODE &&
					         itemCodeInt < Constant.ST200_ITEM_SUBSHIP_STARTCODE + 1000)
					{
						//receive subship
						
					}
				}

				Managers.Torpedo.AddTorpedo(TorpedoTotalAddCount);
				for(int i = 0 ; i < _getMessageListDataList.Count;)
				{
					if(int.Parse(_getMessageListDataList[i].ItemCode) != 0)
					{
						_getMessageListDataList.RemoveAt(i);
					}else
					{
						i++;
					}
				}
				_inboxListPanel.DeleteAllInboxListGrid(true) ;

				Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
				Managers.UserData.UpdateSequence++;
				UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;

				// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
				Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
				// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.

				_presentReceivePopupView.LoadPresentReceivePopupView(2) ;
								
				// Connect Indicator Stop..
				if (_inboxPopupViewDelegate != null){

					_inboxPopupViewDelegate(this, 1002) ;  // 1002 : Root Indicator Stop!!
				}
				
			}else { //Fail
				// Connect Indicator Stop..
				if (_inboxPopupViewDelegate != null){

					_inboxPopupViewDelegate(this, 1002) ;  // 1002 : Root Indicator Stop!!
				}
			}
			GameUIManager.Instance.LoadGameGoldAndGameJewelInfo();
		};

		StartCoroutine(Managers.DataStream.Network_OpenAllMessage()) ;
		UpdateNewMessage();
	}

	public void OnClickPresentTap()
	{
		ShowPresentList();
	}

	public void ShowPresentList()
	{
		// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== Start.
		//NGUITools.SetActive(_inboxInfoNoItemMessageLabel.gameObject, true);
		// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== End.

		UpdateNewMessage();
		Managers.UserData.InboxMessageCountNew = 0;
	}

	public void InitFriendMessagePanel()
	{
		//Managers.KaKao.Event_Delegate_KakaoManager_LoadGameMessage += (intResultCode_Input) => {
		//
		//	//init contents here.
		//	m_FriendMessagePanel.Init(this);
		//};
		//
		//Managers.KaKao.ActionLoadGameMessage();
	}

	public void UpdateNewMessage()
	{

	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			if(_presentReceivePopupView.OnEscapePress())
			{
				return true;
			}else
			{
				RemoveInboxPopupView();
				return true;
			}
		}
		
		return false;
	}
}
