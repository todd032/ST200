/*
 * 제목 : 데이터 스트림 처리 클레스.
 * 작성 : 심재철.
 * 참고 : DataStreamUsageSample.GameUserData 같은 정의된 데이터형을 수정해 줘야함.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using SimpleJSON ;

public class DataStreamManager : MonoBehaviour {
	
	
	[HideInInspector]
	public delegate void DataStreamIAPOkManagerDelegate(string productIdentifier,int state);
	
	protected DataStreamIAPOkManagerDelegate _dataStreamIAPOkManagerDelegate ;
	
	public event DataStreamIAPOkManagerDelegate DataStreamIAPOkManagerEvent {
		add {
			_dataStreamIAPOkManagerDelegate = null;
			if (_dataStreamIAPOkManagerDelegate == null)
				_dataStreamIAPOkManagerDelegate += value;
		}
		
		remove {
			_dataStreamIAPOkManagerDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void DataStreamIAPErrorManagerDelegate(string sendMode,int state);
	
	protected DataStreamIAPErrorManagerDelegate _dataStreamIAPErrorManagerDelegate ;
	
	public event DataStreamIAPErrorManagerDelegate DataStreamIAPErrorManagerEvent {
		add {
			_dataStreamIAPErrorManagerDelegate = null;
			if (_dataStreamIAPErrorManagerDelegate == null)
				_dataStreamIAPErrorManagerDelegate += value;
		}
		
		remove {
			_dataStreamIAPErrorManagerDelegate -= value;
		}
	}
	
	
	
	public struct IAPTransactionStruct {
		
		private string _productIdentifier ;
		
		public string ProductIdentifier {
			set { 
				string encryptString = LoadingWindows.NextE(value, Constant.DefalutAppName);
				_productIdentifier = encryptString;
			}
			get {
				if (_productIdentifier == null || _productIdentifier.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_productIdentifier, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _transactionIdentifier ;
		
		public string TransactionIdentifier {
			set { 
				string encryptString = LoadingWindows.NextE(value, Constant.DefalutAppName);
				_transactionIdentifier = encryptString;
			}
			get {
				if (_transactionIdentifier == null || _transactionIdentifier.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_transactionIdentifier, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _base64EncodedTransactionReceipt ;
		
		public string Base64EncodedTransactionReceipt {
			set { 
				string encryptString = LoadingWindows.NextE(value, Constant.DefalutAppName);
				_base64EncodedTransactionReceipt = encryptString;
			}
			get {
				if (_base64EncodedTransactionReceipt == null || _base64EncodedTransactionReceipt.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_base64EncodedTransactionReceipt, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _quantity ;
		
		public int Quantity {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(), Constant.DefalutAppName);
				_quantity = encryptString;
			}
			get {
				if (_quantity == null || _quantity.Equals("")) {
					return 0;   
				}
				string decryptString = LoadingWindows.NextD(_quantity, Constant.DefalutAppName);
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}
		
	}
	
	public struct IABTransactionStruct {
		
		private string _packageName ;
		
		public string PackageName {
			set {
				string oriString = value;
				if (oriString == null || oriString.Equals("")) {
					oriString = "";
				}
				string encryptString = LoadingWindows.NextE(oriString, Constant.DefalutAppName);
				_packageName = encryptString;
			}
			get {
				if (_packageName == null || _packageName.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_packageName, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _orderId ;
		
		public string OrderId {
			set { 
				string oriString = value;
				if (oriString == null || oriString.Equals("")) {
					oriString = "";
				}
				string encryptString = LoadingWindows.NextE(oriString, Constant.DefalutAppName);
				_orderId = encryptString;
			}
			get {
				if (_orderId == null || _orderId.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_orderId, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _productId ;
		
		public string ProductId {
			set { 
				string oriString = value;
				if (oriString == null || oriString.Equals("")) {
					oriString = "";
				}
				string encryptString = LoadingWindows.NextE(oriString, Constant.DefalutAppName);
				_productId = encryptString;
			}
			get {
				if (_productId == null || _productId.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_productId, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _developerPayload ;
		
		public string DeveloperPayload {
			set { 
				string oriString = value;
				if (oriString == null || oriString.Equals("")) {
					oriString = "";
				}
				string encryptString = LoadingWindows.NextE(oriString, Constant.DefalutAppName);
				_developerPayload = encryptString;
			}
			get {
				if (_developerPayload == null || _developerPayload.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_developerPayload, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _type ;
		
		public string Type {
			set { 
				string oriString = value;
				if (oriString == null || oriString.Equals("")) {
					oriString = "";
				}
				string encryptString = LoadingWindows.NextE(oriString, Constant.DefalutAppName);
				_type = encryptString;
			}
			get {
				if (_type == null || _type.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_type, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _purchaseToken ;
		
		public string PurchaseToken {
			set { 
				string oriString = value;
				if (oriString == null || oriString.Equals("")) {
					oriString = "";
				}
				string encryptString = LoadingWindows.NextE(oriString, Constant.DefalutAppName);
				_purchaseToken = encryptString;
			}
			get {
				if (_purchaseToken == null || _purchaseToken.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_purchaseToken, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _signature ;
		
		public string Signature {
			set { 
				string oriString = value;
				if (oriString == null || oriString.Equals("")) {
					oriString = "";
				}
				string encryptString = LoadingWindows.NextE(oriString, Constant.DefalutAppName);
				_signature = encryptString;
			}
			get {
				if (_signature == null || _signature.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_signature, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _originalJson ;
		
		public string OriginalJson {
			set { 
				string oriString = value;
				if (oriString == null || oriString.Equals("")) {
					oriString = "";
				}
				string encryptString = LoadingWindows.NextE(oriString, Constant.DefalutAppName);
				_originalJson = encryptString;
			}
			get {
				if (_originalJson == null || _originalJson.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_originalJson, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
	}
	
	public struct IAPReturnTransactionStruct {
		
		private string _productIdentifier ;
		
		public string ProductIdentifier {
			set { 
				string encryptString = LoadingWindows.NextE(value, Constant.DefalutAppName);
				_productIdentifier = encryptString;
			}
			get {
				if (_productIdentifier == null || _productIdentifier.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_productIdentifier, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _transactionIdentifier ;
		
		public string TransactionIdentifier {
			set { 
				string encryptString = LoadingWindows.NextE(value, Constant.DefalutAppName);
				_transactionIdentifier = encryptString;
			}
			get {
				if (_transactionIdentifier == null || _transactionIdentifier.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_transactionIdentifier, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
	}
	
	public struct IABReturnTransactionStruct {
		
		private string _productId ;
		
		public string ProductId {
			set { 
				string oriString = value;
				if (oriString == null || oriString.Equals("")) {
					oriString = "";
				}
				string encryptString = LoadingWindows.NextE(oriString, Constant.DefalutAppName);
				_productId = encryptString;
			}
			get {
				if (_productId == null || _productId.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_productId, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
		private string _orderId ;
		
		public string OrderId {
			set { 
				string oriString = value;
				if (oriString == null || oriString.Equals("")) {
					oriString = "";
				}
				string encryptString = LoadingWindows.NextE(oriString, Constant.DefalutAppName);
				_orderId = encryptString;
			}
			get {
				if (_orderId == null || _orderId.Equals("")) {
					return null;    
				}
				string decryptString = LoadingWindows.NextD(_orderId, Constant.DefalutAppName);
				return decryptString;
			}
		}
		
	}
	
	
	
	#if UNITY_IPHONE
	
	private string osType = "1";        //1:iOS.
	private string mType = "1";         //마켓 코드 : 1:Appstore
	
	#elif UNITY_ANDROID
	
	private string osType = "2";        //2:Android.
	//private string mType = "2";           //마켓 코드 :2:Playstore...
	private string mType = Constant.CURRENT_MARKET ;            //마켓 코드 :2:Playstore...
	
	#else
	private string osType = "0";
	private string mType = "0";
	#endif
	private string gameCode = "ST200"; //R100, ST100.
	private string codeName = Constant.AppNameString ; //VersionCode..

	public string OsType
	{
		get
		{
			return osType;
		}
	}

	public string MType
	{
		get
		{
			return mType;
		}
	}

	public string GameCode
	{
		get
		{
			return gameCode;
		}
	}
	//---------------------------------------------
	// Member
	//---------------------------------------------
	
	// Header : 유저 및 단말기 정보 헤더..
	public struct MsgHeader {
		private string deviceid;
		
		public string Deviceid{ get { return deviceid; } set { deviceid = value; } }
		
		private string ostype;
		
		public string Ostype{ get { return ostype; } set { ostype = value; } }
		
		private string service;
		
		public string Service{ get { return service; } set { service = value; } }
		
		private string mtype;
		
		public string Mtype{ get { return mtype; } set { mtype = value; } }
		
		private string loginid;
		
		public string Loginid{ get { return loginid; } set { loginid = value; } }
		
		private string os;
		
		public string Os{ get { return os; } set { os = value; } }
		
		private string language;
		
		public string Language{ get { return language; } set { language = value; } }
		
		private string model;
		
		public string Model{ get { return model; } set { model = value; } }
		
		private string appversion;
		
		public string AppVersion{ get { return appversion; } set { appversion = value; } }
		
		private string codeName ;
		
		public string CodeName{ get { return codeName; } set { codeName = value; } }
		
		private int ct ;
		
		public int Ct{ get { return ct; } set { ct = value; } }
	}
	private MsgHeader msgHeader;
	
	// Return object : 결과값을 object로 변환한 구조형..
	public class ClsReturn {
		public bool result { get; set; }
		
		public string error_msg { get; set; }
		
		public string data { get; set; }
		
		public string extend { get; set; }
		
		public string check { get; set; }
		
		public void init() {
			result = false;
			error_msg = "";
			data = "";
			extend = "";
			check = "";
		}
	}
	private ClsReturn clsReturn;    //결과값 저장..
	
	private string msgResult;       //결과메시지 저장, json string.
	
	// 로그 메시지 버퍼(debug 용).
	private string msgBuffer;
	
	public string MsgBuffer {
		get {
			string str = msgBuffer;
			msgBuffer = "";
			return str;
		}
	}
	
	private string m_strURL = "";

	// Delegate & Event 인터페이스 정의 ===============================================================================
	// Delegate & Event 인터페이스 정의 - GetConData.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_GetConData(string strResultDataJson_Input, int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_GetConData _delegate_DataStreamManager_GetConData ;
	public event Delegate_DataStreamManager_GetConData Event_Delegate_DataStreamManager_GetConData {
		add {
			
			_delegate_DataStreamManager_GetConData = null;
			
			if (_delegate_DataStreamManager_GetConData == null){
				
				_delegate_DataStreamManager_GetConData += value;
				
			}
		}
		remove {
			_delegate_DataStreamManager_GetConData -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - MakeBalanceData.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_MakeBalanceData(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_MakeBalanceData _delegate_DataStreamManager_MakeBalanceData ;
	public event Delegate_DataStreamManager_MakeBalanceData Event_Delegate_DataStreamManager_MakeBalanceData {
		add {
			_delegate_DataStreamManager_MakeBalanceData = null;
			if (_delegate_DataStreamManager_MakeBalanceData == null) _delegate_DataStreamManager_MakeBalanceData += value;
		}
		remove {
			_delegate_DataStreamManager_MakeBalanceData -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - ReadBalanceData.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_ReadBalanceData(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_ReadBalanceData _delegate_DataStreamManager_ReadBalanceData ;
	public event Delegate_DataStreamManager_ReadBalanceData Event_Delegate_DataStreamManager_ReadBalanceData {
		add {
			_delegate_DataStreamManager_ReadBalanceData = null;
			if (_delegate_DataStreamManager_ReadBalanceData == null) _delegate_DataStreamManager_ReadBalanceData += value;
		}
		remove {
			_delegate_DataStreamManager_ReadBalanceData -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - SendMessageInfo.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_SendMessageInfo(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_SendMessageInfo _delegate_DataStreamManager_SendMessageInfo ;
	public event Delegate_DataStreamManager_SendMessageInfo Event_Delegate_DataStreamManager_SendMessageInfo {
		add {
			_delegate_DataStreamManager_SendMessageInfo = null;
			if (_delegate_DataStreamManager_SendMessageInfo == null) _delegate_DataStreamManager_SendMessageInfo += value;
		}
		remove {
			_delegate_DataStreamManager_SendMessageInfo -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - GetMessageList.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_GetMessageList(string strResultExtendJson_Input, int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_GetMessageList _delegate_DataStreamManager_GetMessageList ;
	public event Delegate_DataStreamManager_GetMessageList Event_Delegate_DataStreamManager_GetMessageList {
		add {
			_delegate_DataStreamManager_GetMessageList = null;
			if (_delegate_DataStreamManager_GetMessageList == null) _delegate_DataStreamManager_GetMessageList += value;
		}
		remove {
			_delegate_DataStreamManager_GetMessageList -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - OpenMessage.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_OpenMessage(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_OpenMessage _delegate_DataStreamManager_OpenMessage ;
	public event Delegate_DataStreamManager_OpenMessage Event_Delegate_DataStreamManager_OpenMessage{
		add {
			_delegate_DataStreamManager_OpenMessage = null;
			if (_delegate_DataStreamManager_OpenMessage == null) _delegate_DataStreamManager_OpenMessage += value;
		}
		remove {
			_delegate_DataStreamManager_OpenMessage -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - OpenMessage.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_MessageBlockUserList(string strResultExtendJson_Input, int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_MessageBlockUserList _delegate_DataStreamManager_MessageBlockUserList ;
	public event Delegate_DataStreamManager_MessageBlockUserList Event_Delegate_DataStreamManager_MessageBlockUserList{
		add {
			_delegate_DataStreamManager_MessageBlockUserList = null;
			if (_delegate_DataStreamManager_MessageBlockUserList == null) _delegate_DataStreamManager_MessageBlockUserList += value;
		}
		remove {
			_delegate_DataStreamManager_MessageBlockUserList -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - GetGroupMessageStatus.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_GetGroupMessageStatus(string strResultExtendJson_Input, int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_GetGroupMessageStatus _delegate_DataStreamManager_GetGroupMessageStatus ;
	public event Delegate_DataStreamManager_GetGroupMessageStatus Event_Delegate_DataStreamManager_GetGroupMessageStatus{
		add {
			_delegate_DataStreamManager_GetGroupMessageStatus = null;
			if (_delegate_DataStreamManager_GetGroupMessageStatus == null) _delegate_DataStreamManager_GetGroupMessageStatus += value;
		}
		remove {
			_delegate_DataStreamManager_GetGroupMessageStatus -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - OpenAllMessage.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_OpenAllMessage(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_OpenAllMessage _delegate_DataStreamManager_OpenAllMessage ;
	public event Delegate_DataStreamManager_OpenAllMessage Event_Delegate_DataStreamManager_OpenAllMessage{
		add {
			_delegate_DataStreamManager_OpenAllMessage = null;
			if (_delegate_DataStreamManager_OpenAllMessage == null) _delegate_DataStreamManager_OpenAllMessage += value;
		}
		remove {
			_delegate_DataStreamManager_OpenAllMessage -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - SendGroupMessageInfo.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_SendGroupMessageInfo(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_SendGroupMessageInfo _delegate_DataStreamManager_SendGroupMessageInfo ;
	public event Delegate_DataStreamManager_SendGroupMessageInfo Event_Delegate_DataStreamManager_SendGroupMessageInfo{
		add {
			_delegate_DataStreamManager_SendGroupMessageInfo = null;
			if (_delegate_DataStreamManager_SendGroupMessageInfo == null) _delegate_DataStreamManager_SendGroupMessageInfo += value;
		}
		remove {
			_delegate_DataStreamManager_SendGroupMessageInfo -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - SendGroupInviteInfo.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_SendGroupInviteInfo(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_SendGroupInviteInfo _delegate_DataStreamManager_SendGroupInviteInfo ;
	public event Delegate_DataStreamManager_SendGroupInviteInfo Event_Delegate_DataStreamManager_SendGroupInviteInfo{
		add {
			_delegate_DataStreamManager_SendGroupInviteInfo = null;
			if (_delegate_DataStreamManager_SendGroupInviteInfo == null) _delegate_DataStreamManager_SendGroupInviteInfo += value;
		}
		remove {
			_delegate_DataStreamManager_SendGroupInviteInfo -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - CheckAndUpdateUser.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_CheckAndUpdateUser(string strResultExtendJson_Input, int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_CheckAndUpdateUser _delegate_DataStreamManager_CheckAndUpdateUser ;
	public event Delegate_DataStreamManager_CheckAndUpdateUser Event_Delegate_DataStreamManager_CheckAndUpdateUser{
		add {
			_delegate_DataStreamManager_CheckAndUpdateUser = null;
			if (_delegate_DataStreamManager_CheckAndUpdateUser == null) _delegate_DataStreamManager_CheckAndUpdateUser += value;
		}
		remove {
			_delegate_DataStreamManager_CheckAndUpdateUser -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - SaveUserScore.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_SaveUserScore(string strResultExtendJson_Input, int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_SaveUserScore _delegate_DataStreamManager_SaveUserScore ;
	public event Delegate_DataStreamManager_SaveUserScore Event_Delegate_DataStreamManager_SaveUserScore{
		add {
			_delegate_DataStreamManager_SaveUserScore = null;
			if (_delegate_DataStreamManager_SaveUserScore == null) _delegate_DataStreamManager_SaveUserScore += value;
		}
		remove {
			
			_delegate_DataStreamManager_SaveUserScore -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - ReadBattleData.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_ReadBattleData(string strResultExtendJson_Input, int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_ReadBattleData _delegate_DataStreamManager_ReadBattleData ;
	public event Delegate_DataStreamManager_ReadBattleData Event_Delegate_DataStreamManager_ReadBattleData{
		add {
			_delegate_DataStreamManager_ReadBattleData = null;
			if (_delegate_DataStreamManager_ReadBattleData == null) _delegate_DataStreamManager_ReadBattleData += value;
		}
		remove {
			
			_delegate_DataStreamManager_ReadBattleData -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - GetPushOnOff.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_GetPushOnOff(string strPushOnOffInfo_Input, int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_GetPushOnOff _delegate_DataStreamManager_GetPushOnOff ;
	public event Delegate_DataStreamManager_GetPushOnOff Event_Delegate_DataStreamManager_GetPushOnOff{
		add {
			_delegate_DataStreamManager_GetPushOnOff = null;
			if (_delegate_DataStreamManager_GetPushOnOff == null) _delegate_DataStreamManager_GetPushOnOff += value;
		}
		remove {
			
			_delegate_DataStreamManager_GetPushOnOff -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - SetPushOnOff.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_SetPushOnOff(string strPushOnOffInfo_Input, int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_SetPushOnOff _delegate_DataStreamManager_SetPushOnOff ;
	public event Delegate_DataStreamManager_SetPushOnOff Event_Delegate_DataStreamManager_SetPushOnOff{
		add {
			_delegate_DataStreamManager_SetPushOnOff = null;
			if (_delegate_DataStreamManager_SetPushOnOff == null) _delegate_DataStreamManager_SetPushOnOff += value;
		}
		remove {
			
			_delegate_DataStreamManager_SetPushOnOff -= value;
		}
	}

	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
	// Delegate & Event 인터페이스 정의 - SaveUserData.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_SaveUserData(int intResult_Code_Input, string strResult_Extend_Input);
	protected Delegate_DataStreamManager_SaveUserData _delegate_DataStreamManager_SaveUserData ;
	public event Delegate_DataStreamManager_SaveUserData Event_Delegate_DataStreamManager_SaveUserData{
		add {
			_delegate_DataStreamManager_SaveUserData = null;
			if (_delegate_DataStreamManager_SaveUserData == null) _delegate_DataStreamManager_SaveUserData += value;
		}
		remove {
			
			_delegate_DataStreamManager_SaveUserData -= value;
		}
	}
	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.

	// Delegate & Event 인터페이스 정의 - ReadUserData.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_ReadUserData(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_ReadUserData _delegate_DataStreamManager_ReadUserData ;
	public event Delegate_DataStreamManager_ReadUserData Event_Delegate_DataStreamManager_ReadUserData{
		add {
			_delegate_DataStreamManager_ReadUserData = null;
			if (_delegate_DataStreamManager_ReadUserData == null){
				
				_delegate_DataStreamManager_ReadUserData += value;
			}
		}
		remove {
			
			_delegate_DataStreamManager_ReadUserData -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - ReadUserDataExp.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_ReadUserDataExp(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_ReadUserDataExp _delegate_DataStreamManager_ReadUserDataExp ;
	public event Delegate_DataStreamManager_ReadUserDataExp Event_Delegate_DataStreamManager_ReadUserDataExp{
		add {
			_delegate_DataStreamManager_ReadUserDataExp = null;
			if (_delegate_DataStreamManager_ReadUserDataExp == null) _delegate_DataStreamManager_ReadUserDataExp += value;
		}
		remove {
			
			_delegate_DataStreamManager_ReadUserDataExp -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - DeleteUserData.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_DeleteUserData(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_DeleteUserData _delegate_DataStreamManager_DeleteUserData ;
	public event Delegate_DataStreamManager_DeleteUserData Event_Delegate_DataStreamManager_DeleteUserData{
		add {
			_delegate_DataStreamManager_DeleteUserData = null;
			if (_delegate_DataStreamManager_DeleteUserData == null) _delegate_DataStreamManager_DeleteUserData += value;
		}
		remove {
			
			_delegate_DataStreamManager_DeleteUserData -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - SetWorldRankingData.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_SetWorldRankingData(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_SetWorldRankingData _delegate_DataStreamManager_SetWorldRankingData ;
	public event Delegate_DataStreamManager_SetWorldRankingData Event_Delegate_DataStreamManager_SetWorldRankingData{
		add {
			_delegate_DataStreamManager_SetWorldRankingData = null;
			if (_delegate_DataStreamManager_SetWorldRankingData == null) _delegate_DataStreamManager_SetWorldRankingData += value;
		}
		remove {
			
			_delegate_DataStreamManager_SetWorldRankingData -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - SetWorldRankingGameResult.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_SetWorldRankingGameResult(int intNetworkResultCode_Input);
	protected Delegate_DataStreamManager_SetWorldRankingGameResult _delegate_DataStreamManager_SetWorldRankingGameResult ;
	public event Delegate_DataStreamManager_SetWorldRankingGameResult Event_Delegate_DataStreamManager_SetWorldRankingGameResult{
		add {
			_delegate_DataStreamManager_SetWorldRankingGameResult = null;
			if (_delegate_DataStreamManager_SetWorldRankingGameResult == null) _delegate_DataStreamManager_SetWorldRankingGameResult += value;
		}
		remove {
			
			_delegate_DataStreamManager_SetWorldRankingGameResult -= value;
		}
	}
	
	// Delegate & Event 인터페이스 정의 - Popup_Info.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_Popup_Info(int intNetworkResultCode_Input, string strNetworkResultData_Input);
	protected Delegate_DataStreamManager_Popup_Info _delegate_DataStreamManager_Popup_Info ;
	public event Delegate_DataStreamManager_Popup_Info Event_Delegate_DataStreamManager_Popup_Info {
		add {
			_delegate_DataStreamManager_Popup_Info = null;
			if (_delegate_DataStreamManager_Popup_Info == null) _delegate_DataStreamManager_Popup_Info += value;
		}
		remove {
			_delegate_DataStreamManager_Popup_Info -= value;
		}
	}
	
		// 네이버 인앱 추가 (by 최원석 in 14.06.11) - Start ==========
	// Delegate & Event 인터페이스 정의 - Popup_Info.
	[HideInInspector]
	public delegate void Delegate_DataStreamManager_SaveChargeData_Naver(int intNetworkResultCode_Input, string strNetworkResultData_Input);
	protected Delegate_DataStreamManager_SaveChargeData_Naver _delegate_DataStreamManager_SaveChargeData_Naver ;
	public event Delegate_DataStreamManager_SaveChargeData_Naver Event_Delegate_DataStreamManager_SaveChargeData_Naver {
		add {
			_delegate_DataStreamManager_SaveChargeData_Naver = null;
			if (_delegate_DataStreamManager_SaveChargeData_Naver == null) _delegate_DataStreamManager_SaveChargeData_Naver += value;
		}
		remove {
			_delegate_DataStreamManager_SaveChargeData_Naver -= value;
		}
	}
	// 네이버 인앱 추가 (by 최원석 in 14.06.11) - End ==========

	
	// =====================================================================================================
	
	private void Awake() {
		
	}

	private string m_ClientTime = "";

	private void Start() {
		
		clsReturn = new ClsReturn();
		NativeHelper.Instance.ClientTimeEvent += (clientTime) => 
		{
			m_ClientTime = clientTime;
		};
		NativeHelper.Instance.GetClientTime();
		//da();
	}
	
	void Update() {
		
		#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Space)) {
			//testcodeinituserdata();
			testcodeinitbalancedata();
			//			gachatestcode();
			//StartCoroutine(LuckyTestCode());
			//Managers.UserData.SetPurchaseGameSubmarine(4);
		}
		//if(Input.GetKeyDown(KeyCode.LeftArrow))
		//{
		//	Managers.UserData.UpdateSequence--;
		//}
		#endif
	}
	
	IEnumerator LuckyTestCode()
	{
		int totalpick = 10000;
		int loop = 10;
		int realtotal = loop * totalpick;
		Dictionary<int, int> gradecount = new Dictionary<int, int>();
		Dictionary<int, int> presentcount = new Dictionary<int, int>();
		for(int l = 0; l < loop; l++)
		{
			for(int i = 0; i < totalpick; i++)
			{
				List<GameBalanceDataManager.LuckyPresent> presentlist = Managers.GameBalanceData.GetLuckyPresentGachaList(3);
				if(gradecount.ContainsKey(presentlist[0].Grade))
				{
					gradecount[presentlist[0].Grade]++;
				}else
				{
					gradecount.Add(presentlist[0].Grade, 1);
				}
				
				if(presentcount.ContainsKey(presentlist[0].IndexNumber))
				{
					presentcount[presentlist[0].IndexNumber]++;			
				}else
				{
					presentcount.Add(presentlist[0].IndexNumber, 1);
				}
			}
			yield return new WaitForSeconds(0.2f);
		}
		
		
		
		string gradepickratio = "";
		foreach(int grade in gradecount.Keys)
		{
			gradepickratio += " GRADE" + grade + " HAS RATIO OF: " + (float)gradecount[grade]/(float)realtotal * 100f + '\n';
		}
		
		foreach(int presentindex in presentcount.Keys)
		{
			gradepickratio += " Present Index: " + presentindex + " HAS RATIO OF: " + (float)presentcount[presentindex]/(float)realtotal * 100f + '\n';
		}
//		 Debug.Log("TOTAL RUN TIME: " + realtotal +  '\n' + gradepickratio);
		
		yield break;
	}
	
	void gachatestcode()
	{

	}
	
	void testcodeinituserdata() {
		
		Managers.UserData.MakeUserData();
		Managers.UserData.UpdateSequence++;
		Network_SaveUserData_Input_1 (Managers.UserData.GetUserDataStruct ());

	}
	
	void testcodeinitbalancedata() {
		
		Managers.GameBalanceData.MakeGameBalanceData();
		GameBalanceDataManager.GameBalanceDataStruct datastruct = Managers.GameBalanceData.GetGameBalanceDataStruct();
		StartCoroutine(Network_MakeBalanceData(datastruct));
	}
	
	public void SetInitDataStream(string loginid, string ver) {
		
//		  Debug.Log ("ST200k DataStreamManager.SetInitDataStream().loginid = " + loginid);
		
		msgBuffer = "";
		
		//header set
		msgHeader = new MsgHeader();
		msgHeader.Deviceid = SystemInfo.deviceUniqueIdentifier; //md5되어 있음.
		msgHeader.Ostype = osType;
		msgHeader.Service = gameCode;
		msgHeader.Mtype = mType;
		msgHeader.Loginid = loginid;
		msgHeader.Os = SystemInfo.operatingSystem;
		msgHeader.Language = Application.systemLanguage.ToString();
		msgHeader.Model = SystemInfo.deviceModel;
		msgHeader.AppVersion = ver;
		msgHeader.CodeName = codeName;
		addMessageBuffer("DataStream Init. OK...");
		
//		  Debug.Log ("ST200k DataStreamManager.SetInitDataStream().msgHeader.Loginid = " + msgHeader.Loginid);
		ST200KLogManager.Instance.Init(loginid,
		                               ver,
		                               osType,
		                               gameCode,
		                               mType,
		                               codeName);
	}
	
	
	#if UNITY_IPHONE
	//---- IAP
	public IEnumerator SendIAPValidateReceipt(StoreKitTransaction transaction){
		
		IAPTransactionStruct transactionStruct = new IAPTransactionStruct() ;
		transactionStruct.ProductIdentifier = transaction.productIdentifier ;
		transactionStruct.TransactionIdentifier = transaction.transactionIdentifier ;
		transactionStruct.Base64EncodedTransactionReceipt = transaction.base64EncodedTransactionReceipt ;
		transactionStruct.Quantity = transaction.quantity ;
		
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime() ;
		string header = JsonMapper.ToJson(msgHeader);
		string body = JsonMapper.ToJson(transactionStruct);
		string check = getParameterCheckSum(header + body); //checksum 코드 생성...
		
		
		string sendMode = "" ;
		
		if (Constant.PROJECTMODE_IabTest){
			
			sendMode = Constant.NETWORK_SENDMODE_SaveChargeDataTest ;
			
		} else {
			
			sendMode = Constant.NETWORK_SENDMODE_SaveChargeData ;
		}
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_AppCharge;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_AppCharge;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if(www.error == null){
			addMessageBuffer("RESPONSE OK: "+www.text);
			
			clsReturn.init();   //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if(clsReturn.result == true){
				if(clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))){
					
					IAPReturnTransactionStruct returnTransactionStruct = new IAPReturnTransactionStruct() ;
					returnTransactionStruct = JsonMapper.ToObject<IAPReturnTransactionStruct>(clsReturn.data) ;
					
					//Managers.UserData.ClearChocolateRewardMessageQueue() ; //Remove !!!!!
					//Managers.UserData.SetChocolateRewardMessageQueue(clsReturn.extend) ; //Remove !!!!!
					
					if(_dataStreamIAPOkManagerDelegate != null){
						_dataStreamIAPOkManagerDelegate(returnTransactionStruct.ProductIdentifier, 101) ;   
					}
					
				}else{
					//CheckSum Error..
					if(_dataStreamIAPErrorManagerDelegate != null){
						_dataStreamIAPErrorManagerDelegate(sendMode, 111) ;     
					}
				}
			}else if(clsReturn.result == false){
				if(_dataStreamIAPErrorManagerDelegate != null){
					_dataStreamIAPErrorManagerDelegate(sendMode, 111) ;     
				}
			}
			
		} else {
			addMessageBuffer("RESPONSE ERROR: "+www.error);
			if(_dataStreamIAPErrorManagerDelegate != null){
				_dataStreamIAPErrorManagerDelegate(sendMode, 112) ;     
			}
		}
		
		www.Dispose() ;
		www = null ;
		
	}
	#endif
	
	
	#if UNITY_ANDROID
	//---- IAB
	public IEnumerator SendIABValidateReceipt(GooglePurchase transaction) {
		
		IABTransactionStruct transactionStruct = new IABTransactionStruct();
		transactionStruct.PackageName = transaction.packageName;
		transactionStruct.OrderId = transaction.orderId;
		transactionStruct.ProductId = transaction.productId;
		transactionStruct.DeveloperPayload = transaction.developerPayload;
		transactionStruct.Type = transaction.type;
		transactionStruct.PurchaseToken = transaction.purchaseToken;
		transactionStruct.Signature = transaction.signature;
		transactionStruct.OriginalJson = transaction.originalJson;
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		string body = JsonMapper.ToJson(transactionStruct);
		string check = getParameterCheckSum(header + body); //checksum 코드 생성...
		
		
		string sendMode = "";
		
		if (Constant.PROJECTMODE_IabTest) {
			
			sendMode = Constant.NETWORK_SENDMODE_SaveChargeDataTest;
			
		} else {
			
			sendMode = Constant.NETWORK_SENDMODE_SaveChargeData;
		}
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_AppCharge;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_AppCharge;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		// // //Debug.Log("TEST WWW: " + www.text);
		if (www.error == null) {
			addMessageBuffer("RESPONSE OK: " + www.text);
			
			clsReturn.init();   //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			// // //Debug.Log("CHECK1");
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				
				if (clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))) {
					
					IABReturnTransactionStruct returnTransactionStruct = new IABReturnTransactionStruct();
					returnTransactionStruct = JsonMapper.ToObject<IABReturnTransactionStruct>(clsReturn.data);
					
					//Managers.UserData.ClearChocolateRewardMessageQueue() ;   //Remove!!!!
					//Managers.UserData.SetChocolateRewardMessageQueue(clsReturn.extend) ; //Remove!!!!
					
					// // //Debug.Log("CHECK2");
					if (_dataStreamIAPOkManagerDelegate != null) {
						// // //Debug.Log("CHECK3");
						_dataStreamIAPOkManagerDelegate(returnTransactionStruct.ProductId, 101);   
					}
					
				} else {
					// // //Debug.Log("CHECK4");
					//CheckSum Error..
					if (_dataStreamIAPErrorManagerDelegate != null) {
						// // //Debug.Log("CHECK5");
						_dataStreamIAPErrorManagerDelegate(sendMode, 111);     
					}
				}
				
			} else if (clsReturn.result == false) {
				// // //Debug.Log("CHECK6");
				if (_dataStreamIAPErrorManagerDelegate != null) {
					// // //Debug.Log("CHECK7");
					_dataStreamIAPErrorManagerDelegate(sendMode, 111);     
				}
			}
			
		} else {
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			if (_dataStreamIAPErrorManagerDelegate != null) {
				_dataStreamIAPErrorManagerDelegate(sendMode, 112);     
			}
		}
		
		www.Dispose();
		www = null;
		
	}
	
	
	//TStore
	public IEnumerator SendTstoreValidateReceipt(string receiptData){
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime() ;
		string header = JsonMapper.ToJson(msgHeader);
		string body = receiptData;
		string check = getParameterCheckSum(header + body); //checksum 코드 생성...
		
		string sendMode = "" ;
		
		if (Constant.PROJECTMODE_IabTest){
			
			sendMode = Constant.NETWORK_SENDMODE_SaveChargeDataTest ;
			
		} else {
			
			sendMode = Constant.NETWORK_SENDMODE_SaveChargeData ;
		}
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_AppCharge;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_AppCharge;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if(www.error == null){
			addMessageBuffer("RESPONSE OK: "+www.text);
			
			clsReturn.init();   //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if(clsReturn.result == true){
				
				if(clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))){
					
					IABReturnTransactionStruct returnTransactionStruct = new IABReturnTransactionStruct() ;
					
					JSONNode root = JSON.Parse(clsReturn.data);
					returnTransactionStruct.ProductId = root["ProductId"] ;
					returnTransactionStruct.OrderId = root["Txid"] ;
					
					if(_dataStreamIAPOkManagerDelegate != null){
						_dataStreamIAPOkManagerDelegate(returnTransactionStruct.ProductId, 101) ;   
					}
					
				}else{
					//CheckSum Error..
					if(_dataStreamIAPErrorManagerDelegate != null){
						_dataStreamIAPErrorManagerDelegate(sendMode, 111) ;     
					}
				}
				
			}else if(clsReturn.result == false){
				if(_dataStreamIAPErrorManagerDelegate != null){
					_dataStreamIAPErrorManagerDelegate(sendMode, 111) ;     
				}
			}
			
		} else {
			addMessageBuffer("RESPONSE ERROR: "+www.error);
			if(_dataStreamIAPErrorManagerDelegate != null){
				_dataStreamIAPErrorManagerDelegate(sendMode, 112) ;     
			}
		}
		
		www.Dispose() ;
		www = null ;
	}
	
	
	#endif
	
	
	
	
	
	
	
	// ======================================================================================================
	
	
	
	
	// 데이터 체크섬 문자열 생성..
	public string getParameterCheckSum(string str) {
		
		return Md5Sum(str + Constant.CHECKSUM_Key);
	}
	
	// 문자열 md5 메소드..
	private string Md5Sum(string strToEncrypt) {
		
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);
		
		// encrypt bytes.
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);
		
		// Convert the encrypted bytes back to a string (base 16).
		string hashString = "";
		
		for (int i = 0; i < hashBytes.Length; i++) {
			hashString += System.Convert.ToString(hashBytes [i], 16).PadLeft(2, '0');
		}
		
		return hashString.PadLeft(32, '0');
	}
	
	// 디버그용 출력 메시지 버퍼.
	public void addMessageBuffer(string msg) {
		
		if (Constant.PROJECTMODE_OutDebugMessage) {
			
			msgBuffer = msg + "\n" + msgBuffer;
		}
	}
	
	// 초기접속 통신 (connect.php) - GetConData.
	public IEnumerator Network_GetConData() {
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = "{\"ClientTime\":\"" + m_ClientTime + "\"}";
		
		string check = getParameterCheckSum(header + body);    //checksum 코드 생성...
		
		yield return null;
		
		string sendMode = Constant.NETWORK_SENDMODE_GetConData;
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_Connect;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_Connect;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
//		Debug.Log("ST200k DataStreamManager.Network_GetConData().sendMode = " + sendMode);
//		Debug.Log("ST200k DataStreamManager.Network_GetConData().header = " + header);
//		Debug.Log("ST200k DataStreamManager.Network_GetConData().body = " + body);
//		Debug.Log("ST200k DataStreamManager.Network_GetConData().check = " + check);
//		Debug.Log("ST200k DataStreamManager.Network_GetConData().www.text = " + www.text);
		
		if (www.error == null) {
			
			addMessageBuffer("RESPONSE OK: " + www.text);
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			if (clsReturn.result == true) {
				
				if (clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))) {
					
					if (Managers.UserData != null) {
						
						if (clsReturn.data != null && !clsReturn.data.Equals("")) {
							
							if (_delegate_DataStreamManager_GetConData != null) {
								_delegate_DataStreamManager_GetConData(clsReturn.data, Constant.NETWORK_RESULTCODE_OK);     
							}   
							
						} else {
							
							if (_delegate_DataStreamManager_GetConData != null) {
								_delegate_DataStreamManager_GetConData(null, Constant.NETWORK_RESULTCODE_Error_Result_Data);   
							}
						}
						
					} else {
						
						if (_delegate_DataStreamManager_GetConData != null) {
							_delegate_DataStreamManager_GetConData(null, Constant.NETWORK_RESULTCODE_Error_UserData);   
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_GetConData != null) {
						_delegate_DataStreamManager_GetConData(null, Constant.NETWORK_RESULTCODE_Error_CheckSum);   
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_GetConData != null) {
					_delegate_DataStreamManager_GetConData(null, Constant.NETWORK_RESULTCODE_Error_Result_False);   
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_GetConData != null) {
				_delegate_DataStreamManager_GetConData(null, Constant.NETWORK_RESULTCODE_Error_Network);   
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 밸런스데이터 통신 (config_data.php) - MakeBalanceData.
	// 개발용 메소드(상용에서 호출 금지).
	public IEnumerator Network_MakeBalanceData(object obj_Input) {
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = JsonMapper.ToJson(obj_Input);
		
		string check = getParameterCheckSum(header + body);    //checksum 코드 생성...
		
		string sendMode = Constant.NETWORK_SENDMODE_MakeBalanceData;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_ConfigData;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_ConfigData;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			addMessageBuffer("RESPONSE OK: " + www.text);
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			if (clsReturn.result == true) {
				
				if (_delegate_DataStreamManager_MakeBalanceData != null) {
					_delegate_DataStreamManager_MakeBalanceData(Constant.NETWORK_RESULTCODE_OK);
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_MakeBalanceData != null) {
					_delegate_DataStreamManager_MakeBalanceData(Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_MakeBalanceData != null) {
				_delegate_DataStreamManager_MakeBalanceData(Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}

		Debug.Log("MAKE BALANCE DONE");
	}
	
	// 밸런스데이터 통신 (config_data.php) - ReadBalanceData.
	public IEnumerator Network_ReadBalanceData() {
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = "N/A";
		
		string check = getParameterCheckSum(header + body);
		
		yield return null;
		
		string sendMode = "";
		
		if (Constant.PROJECTMODE_BalanceTest) {
			
			sendMode = Constant.NETWORK_SENDMODE_ReadBalanceDataDebug;
			
		} else {
			
			sendMode = Constant.NETWORK_SENDMODE_ReadBalanceData;
		}
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_ConfigData;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_ConfigData;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
//		Debug.Log ("ST200k DataStreamManager.Network_ReadBalanceData().sendMode = " + sendMode);
//		Debug.Log ("ST200k DataStreamManager.Network_ReadBalanceData().header = " + header);
//		Debug.Log ("ST200k DataStreamManager.Network_ReadBalanceData().body = " + body);
//		Debug.Log ("ST200k DataStreamManager.Network_ReadBalanceData().check = " + check);
//		Debug.Log ("ST200k DataStreamManager.Network_ReadBalanceData().www = " + www.text);
		
		if (www.error == null) {
			
			addMessageBuffer("RESPONSE OK: " + www.text);
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			if (clsReturn.result == true) {
				
				if (clsReturn.check.Equals(getParameterCheckSum(clsReturn.data))) {
					
					if (Managers.GameBalanceData != null) {
						
						GameBalanceDataManager.GameBalanceDataStruct gameBalanceDataStruct = Managers.GameBalanceData.GetGameBalanceDataStruct();
						gameBalanceDataStruct = JsonMapper.ToObject<GameBalanceDataManager.GameBalanceDataStruct>(clsReturn.data); //한 번더 디코딩(실제 body data).
						Managers.GameBalanceData.SetGameBalanceDataStruct(gameBalanceDataStruct);
						
						if (_delegate_DataStreamManager_ReadBalanceData != null) {
							_delegate_DataStreamManager_ReadBalanceData(Constant.NETWORK_RESULTCODE_OK);     
						}
						
					} else {
						
						if (_delegate_DataStreamManager_ReadBalanceData != null) {
							_delegate_DataStreamManager_ReadBalanceData(Constant.NETWORK_RESULTCODE_Error_BalanceData);     
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_ReadBalanceData != null) {
						_delegate_DataStreamManager_ReadBalanceData(Constant.NETWORK_RESULTCODE_Error_CheckSum);
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_ReadBalanceData != null) {
					_delegate_DataStreamManager_ReadBalanceData(Constant.NETWORK_RESULTCODE_Error_Result_False);     
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_ReadBalanceData != null) {
				_delegate_DataStreamManager_ReadBalanceData(Constant.NETWORK_RESULTCODE_Error_Network);     
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 선물함 통신 (message.php) - SendMessageInfo.
	public IEnumerator Network_SendMessageInfo(string strReciverID_Input, string strSenderNickName_Input) {
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = "{\"ReciverID\":\"" + strReciverID_Input + "\", \"SenderNickName\":\"" + strSenderNickName_Input + "\",\"MessageType\":1}";
		
		string check = getParameterCheckSum(header + body);
		
		yield return null;
		
		string sendMode = Constant.NETWORK_SENDMODE_SendMessageInfo;
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_Message;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_Message;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				
				string strExtendJson = clsReturn.extend;
				
				if (strExtendJson != null && !strExtendJson.Equals("")) {
					
					JSONNode root = JSON.Parse(strExtendJson);
					string receiveServerTime = root ["ServerTime"];
					int serverTime = int.Parse(receiveServerTime);
					
					if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
						
						Managers.UserData.SetServerTime(clsReturn.extend);
						
						if (_delegate_DataStreamManager_SendMessageInfo != null) {
							_delegate_DataStreamManager_SendMessageInfo(Constant.NETWORK_RESULTCODE_OK);    
						}
						
					} else {
						
						if (_delegate_DataStreamManager_SendMessageInfo != null) {
							_delegate_DataStreamManager_SendMessageInfo(Constant.NETWORK_RESULTCODE_Error_TimeSync);    
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_SendMessageInfo != null) {
						_delegate_DataStreamManager_SendMessageInfo(Constant.NETWORK_RESULTCODE_Error_Result_Extend);    
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_SendMessageInfo != null) {
					_delegate_DataStreamManager_SendMessageInfo(Constant.NETWORK_RESULTCODE_Error_Result_False);    
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_SendMessageInfo != null) {
				_delegate_DataStreamManager_SendMessageInfo(Constant.NETWORK_RESULTCODE_Error_Network);    
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 선물함 통신 (message.php) - GetMessageList.
	public IEnumerator Network_GetMessageList() {
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = "N/A";
		
		string check = getParameterCheckSum(header + body);    //checksum 코드 생성...
		
		yield return null;
		
		string sendMode = Constant.NETWORK_SENDMODE_GetMessageList;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_Message;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_Message;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			addMessageBuffer("RESPONSE OK: " + www.text);
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				
				if (clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))) {
					
					if (Managers.UserData != null) {
						
						//Managers.UserData.ClearChocolateRewardMessageQueue() ;
						//Managers.UserData.SetChocolateRewardMessageQueue(clsReturn.data) ;
						
						string strExtendJson = clsReturn.extend;
						
						if (strExtendJson != null && !strExtendJson.Equals("")) {
							
							JSONNode root = JSON.Parse(strExtendJson);
							string receiveServerTime = root ["ServerTime"];
							int serverTime = int.Parse(receiveServerTime);
							
							if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
								
								//---
								Managers.UserData.SetServerTime(clsReturn.extend);
								Managers.UserData.SetMessageCount(clsReturn.extend);
								//Managers.UserData.SetMessageNewCount(clsReturn.extend);

								if (clsReturn.data != null && !clsReturn.data.Equals("")) {
									
									if (_delegate_DataStreamManager_GetMessageList != null) {
										_delegate_DataStreamManager_GetMessageList(clsReturn.data, Constant.NETWORK_RESULTCODE_OK);
									}   
									
								} else {
									
									if (_delegate_DataStreamManager_GetMessageList != null) {
										_delegate_DataStreamManager_GetMessageList(null, Constant.NETWORK_RESULTCODE_Error_Result_Data);
									}
								}
								
							} else {
								
								if (_delegate_DataStreamManager_GetMessageList != null) {
									_delegate_DataStreamManager_GetMessageList(null, Constant.NETWORK_RESULTCODE_Error_TimeSync);
								}
							}
							
						} else {
							
							if (_delegate_DataStreamManager_GetMessageList != null) {
								_delegate_DataStreamManager_GetMessageList(null, Constant.NETWORK_RESULTCODE_Error_Result_Extend);
							}
						}
						
					} else {
						
						if (_delegate_DataStreamManager_GetMessageList != null) {
							_delegate_DataStreamManager_GetMessageList(null, Constant.NETWORK_RESULTCODE_Error_UserData);
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_GetMessageList != null) {
						_delegate_DataStreamManager_GetMessageList(null, Constant.NETWORK_RESULTCODE_Error_CheckSum);   
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_GetMessageList != null) {
					_delegate_DataStreamManager_GetMessageList(null, Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_GetMessageList != null) {
				_delegate_DataStreamManager_GetMessageList(null, Constant.NETWORK_RESULTCODE_Error_Network);   
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 선물함 통신 (message.php) - OpenMessage.
	public IEnumerator Network_OpenMessage(string strMsgSeq_Input) {
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = "{\"msg_seq\":\"" + strMsgSeq_Input + "\"}";
		
		string check = getParameterCheckSum(header + body);
		
		yield return null;
		
		string sendMode = Constant.NETWORK_SENDMODE_OpenMessage;
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {			
			m_strURL = Constant.URL_DEVELOP_Message;			
		} else {			
			m_strURL = Constant.URL_RELEASE_Message;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				
				//////////
				string strExtendJson = clsReturn.extend;
				
				if (strExtendJson != null && !strExtendJson.Equals("")) {
					
					JSONNode root = JSON.Parse(strExtendJson);
					string receiveServerTime = root ["ServerTime"];
					int serverTime = int.Parse(receiveServerTime);
					
					if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
						
						Managers.UserData.SetServerTime(clsReturn.extend);
						
						if (_delegate_DataStreamManager_OpenMessage != null) {
							_delegate_DataStreamManager_OpenMessage(Constant.NETWORK_RESULTCODE_OK);    
						}
						
					} else {
						
						if (_delegate_DataStreamManager_OpenMessage != null) {
							_delegate_DataStreamManager_OpenMessage(Constant.NETWORK_RESULTCODE_Error_TimeSync);
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_OpenMessage != null) {
						_delegate_DataStreamManager_OpenMessage(Constant.NETWORK_RESULTCODE_Error_Result_Extend);
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_OpenMessage != null) {
					_delegate_DataStreamManager_OpenMessage(Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_OpenMessage != null) {
				_delegate_DataStreamManager_OpenMessage(Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}
		
		www.Dispose();
		www = null;
		
	}
	
	// 선물함 통신 (message.php) - MessageBlockUserList.
	public IEnumerator Network_MessageBlockUserList() {
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		string body = "N/A";
		string check = getParameterCheckSum(header + body);    //checksum 코드 생성...
		
		yield return null;
		
		string sendMode = Constant.NETWORK_SENDMODE_MessageBlockUserList;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_Message;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_Message;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			addMessageBuffer("RESPONSE OK: " + www.text);
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				
				if (clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))) {
					
					if (Managers.UserData != null) {
						
						string strExtendJson = clsReturn.extend;
						
						if (strExtendJson != null && !strExtendJson.Equals("")) {
							
							JSONNode root = JSON.Parse(strExtendJson);
							string receiveServerTime = root ["ServerTime"];
							int serverTime = int.Parse(receiveServerTime);
							
							if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
								
								Managers.UserData.SetServerTime(clsReturn.extend);
								
								if (clsReturn.data != null && !clsReturn.data.Equals("")) {
									
									if (_delegate_DataStreamManager_MessageBlockUserList != null) {
										_delegate_DataStreamManager_MessageBlockUserList(clsReturn.data, Constant.NETWORK_RESULTCODE_OK);     
									}   
									
								} else {
									
									if (_delegate_DataStreamManager_MessageBlockUserList != null) {
										_delegate_DataStreamManager_MessageBlockUserList(null, Constant.NETWORK_RESULTCODE_Error_Result_Data);   
									}
								}
								
							} else {
								
								if (_delegate_DataStreamManager_MessageBlockUserList != null) {
									_delegate_DataStreamManager_MessageBlockUserList(null, Constant.NETWORK_RESULTCODE_Error_TimeSync);
								}
							}
							
						} else {
							
							if (_delegate_DataStreamManager_MessageBlockUserList != null) {
								_delegate_DataStreamManager_MessageBlockUserList(null, Constant.NETWORK_RESULTCODE_Error_Result_Extend);
							}
						}
						
					} else {
						
						if (_delegate_DataStreamManager_MessageBlockUserList != null) {
							_delegate_DataStreamManager_MessageBlockUserList(null, Constant.NETWORK_RESULTCODE_Error_UserData);
						}
						
					}
					
				} else {
					
					if (_delegate_DataStreamManager_MessageBlockUserList != null) {
						_delegate_DataStreamManager_MessageBlockUserList(null, Constant.NETWORK_RESULTCODE_Error_CheckSum);
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_MessageBlockUserList != null) {
					_delegate_DataStreamManager_MessageBlockUserList(null, Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_MessageBlockUserList != null) {
				_delegate_DataStreamManager_MessageBlockUserList(null, Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 선물함 통신 (message.php) - GetGroupMessageStatus.
	public IEnumerator Network_GetGroupMessageStatus(string strClanID_Input) { // - 일괄 메시지(선물,초대) 보내기전 제한 여부.
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		string body = "{\"ClanID\":\"" + strClanID_Input + "\"}";
		string check = getParameterCheckSum(header + body);    //checksum 코드 생성...
		
		yield return null;
		
		string sendMode = Constant.NETWORK_SENDMODE_GetGroupMessageStatus;
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_Message;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_Message;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			if (clsReturn.result == true) {
				
				if (clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))) {
					
					if (Managers.UserData != null) {
						
						string strExtendJson = clsReturn.extend;
						
						if (strExtendJson != null && !strExtendJson.Equals("")) {
							
							JSONNode root = JSON.Parse(strExtendJson);
							string receiveServerTime = root ["ServerTime"];
							int serverTime = int.Parse(receiveServerTime);
							
							if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
								
								//---
								Managers.UserData.SetServerTime(clsReturn.extend);
								
								if (clsReturn.data != null && !clsReturn.data.Equals("")) {
									
									if (_delegate_DataStreamManager_GetGroupMessageStatus != null) {
										_delegate_DataStreamManager_GetGroupMessageStatus(clsReturn.data, Constant.NETWORK_RESULTCODE_OK);     
									}   
									
								} else {
									
									if (_delegate_DataStreamManager_GetGroupMessageStatus != null) {
										_delegate_DataStreamManager_GetGroupMessageStatus(null, Constant.NETWORK_RESULTCODE_Error_Result_Data);   
									}
								}
								
							} else {
								
								if (_delegate_DataStreamManager_GetGroupMessageStatus != null) {
									_delegate_DataStreamManager_GetGroupMessageStatus(null, Constant.NETWORK_RESULTCODE_Error_TimeSync);
								}
							}
							
						} else {
							
							if (_delegate_DataStreamManager_GetGroupMessageStatus != null) {
								_delegate_DataStreamManager_GetGroupMessageStatus(null, Constant.NETWORK_RESULTCODE_Error_Result_Extend);
							}
						}
						
					} else {
						
						if (_delegate_DataStreamManager_GetGroupMessageStatus != null) {
							_delegate_DataStreamManager_GetGroupMessageStatus(null, Constant.NETWORK_RESULTCODE_Error_UserData);
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_GetGroupMessageStatus != null) {
						_delegate_DataStreamManager_GetGroupMessageStatus(null, Constant.NETWORK_RESULTCODE_Error_CheckSum);
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_GetGroupMessageStatus != null) {
					_delegate_DataStreamManager_GetGroupMessageStatus(null, Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_GetGroupMessageStatus != null) {
				_delegate_DataStreamManager_GetGroupMessageStatus(null, Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 선물함 통신 (message.php) - OpenAllMessage.
	public IEnumerator Network_OpenAllMessage() {
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = "N/A";
		
		string check = getParameterCheckSum(header + body);
		
		yield return null;
		
		string sendMode = Constant.NETWORK_SENDMODE_OpenAllMessage;
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_Message;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_Message;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			if (clsReturn.result == true) {
				
				string strExtendJson = clsReturn.extend;
				
				if (strExtendJson != null && !strExtendJson.Equals("")) {
					
					JSONNode root = JSON.Parse(strExtendJson);
					string receiveServerTime = root ["ServerTime"];
					int serverTime = int.Parse(receiveServerTime);
					
					if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
						
						Managers.UserData.SetServerTime(clsReturn.extend);
						
						if (_delegate_DataStreamManager_OpenAllMessage != null) {
							_delegate_DataStreamManager_OpenAllMessage(Constant.NETWORK_RESULTCODE_OK);
							
						}
						
					} else {
						
						if (_delegate_DataStreamManager_OpenAllMessage != null) {
							_delegate_DataStreamManager_OpenAllMessage(Constant.NETWORK_RESULTCODE_Error_TimeSync);
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_OpenAllMessage != null) {
						_delegate_DataStreamManager_OpenAllMessage(Constant.NETWORK_RESULTCODE_Error_Result_Extend);
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_OpenAllMessage != null) {
					_delegate_DataStreamManager_OpenAllMessage(Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_OpenAllMessage != null) {
				_delegate_DataStreamManager_OpenAllMessage(Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 선물함 통신 (message.php) - SendGroupMessageInfo.
	public IEnumerator Network_SendGroupMessageInfo(string strClanID_Input) {
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = "{\"ClanID\":\"" + strClanID_Input + "\",\"MessageType\":2}";
		
		string check = getParameterCheckSum(header + body);
		
		yield return null;
		
		string sendMode = Constant.NETWORK_SENDMODE_SendGroupMessageInfo;
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_Message;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_Message;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			if (clsReturn.result == true) {
				
				string strExtendJson = clsReturn.extend;
				
				if (strExtendJson != null && !strExtendJson.Equals("")) {
					
					JSONNode root = JSON.Parse(strExtendJson);
					string receiveServerTime = root ["ServerTime"];
					int serverTime = int.Parse(receiveServerTime);
					
					if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
						
						Managers.UserData.SetServerTime(clsReturn.extend);
						
						if (_delegate_DataStreamManager_SendGroupMessageInfo != null) {
							_delegate_DataStreamManager_SendGroupMessageInfo(Constant.NETWORK_RESULTCODE_OK);
						}
						
					} else {
						
						if (_delegate_DataStreamManager_SendGroupMessageInfo != null) {
							_delegate_DataStreamManager_SendGroupMessageInfo(Constant.NETWORK_RESULTCODE_Error_TimeSync);
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_SendGroupMessageInfo != null) {
						_delegate_DataStreamManager_SendGroupMessageInfo(Constant.NETWORK_RESULTCODE_Error_Result_Extend);
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_SendGroupMessageInfo != null) {
					_delegate_DataStreamManager_SendGroupMessageInfo(Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_SendGroupMessageInfo != null) {
				_delegate_DataStreamManager_SendGroupMessageInfo(Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 선물함 통신 (message.php) - SendGroupInviteInfo.
	public IEnumerator Network_SendGroupInviteInfo(string strClanID_Input) { // - 그룹 초대 메시지(푸시) 결과 저장.
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		
		string body = "{\"ClanID\":\"" + strClanID_Input + "\"}";
		
		string check = getParameterCheckSum(header + body);    //checksum 코드 생성...
		
		yield return null;
		
		string sendMode = Constant.NETWORK_SENDMODE_SendGroupInviteInfo;
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_Message;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_Message;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			if (clsReturn.result == true) {
				
				string strExtendJson = clsReturn.extend;
				
				if (strExtendJson != null && !strExtendJson.Equals("")) {
					
					JSONNode root = JSON.Parse(strExtendJson);
					string receiveServerTime = root ["ServerTime"];
					int serverTime = int.Parse(receiveServerTime);
					
					if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
						
						Managers.UserData.SetServerTime(clsReturn.extend);
						
						if (_delegate_DataStreamManager_SendGroupInviteInfo != null) {
							_delegate_DataStreamManager_SendGroupInviteInfo(Constant.NETWORK_RESULTCODE_OK);
						}
						
					} else {
						
						if (_delegate_DataStreamManager_SendGroupInviteInfo != null) {
							_delegate_DataStreamManager_SendGroupInviteInfo(Constant.NETWORK_RESULTCODE_Error_TimeSync);
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_SendGroupInviteInfo != null) {
						_delegate_DataStreamManager_SendGroupInviteInfo(Constant.NETWORK_RESULTCODE_Error_Result_Extend);
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_SendGroupInviteInfo != null) {
					_delegate_DataStreamManager_SendGroupInviteInfo(Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_SendGroupInviteInfo != null) {
				_delegate_DataStreamManager_SendGroupInviteInfo(Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 배너창 통신 (banner_touch.php) - CheckAndUpdateUser.
	public IEnumerator Network_CheckAndUpdateUser(object obj_Input, string strImageBannerEventIndex_Input) { //CheckAndUpdateUser
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = JsonMapper.ToJson(obj_Input);
		
		string extend = "{\"ImageBannerEventIndex\":" + strImageBannerEventIndex_Input + "}";
		
		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		string sendMode = Constant.NETWORK_SENDMODE_CheckAndUpdateUser;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_BannerTouch;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_BannerTouch;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			addMessageBuffer("RESPONSE OK: " + www.text);
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				
				if (clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))) {
					
					if (Managers.UserData != null) {
						
						UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct();
						userDataStruct = JsonMapper.ToObject<UserDataManager.UserDataStruct>(clsReturn.data);  //한 번더 디코딩(실제 body data).
						Managers.UserData.SetUserDataStruct(userDataStruct);
						
						string strExtendJson = clsReturn.extend;
						
						if (strExtendJson != null && !strExtendJson.Equals("")) {
							
							JSONNode root = JSON.Parse(strExtendJson);
							string receiveServerTime = root ["ServerTime"];
							int serverTime = int.Parse(receiveServerTime);
							
							if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
								
								Managers.UserData.SetServerTime(clsReturn.extend);
								
								if (_delegate_DataStreamManager_CheckAndUpdateUser != null) {
									_delegate_DataStreamManager_CheckAndUpdateUser(clsReturn.extend, Constant.NETWORK_RESULTCODE_OK);   
								}
								
							} else {
								
								if (_delegate_DataStreamManager_CheckAndUpdateUser != null) {
									_delegate_DataStreamManager_CheckAndUpdateUser(null, Constant.NETWORK_RESULTCODE_Error_TimeSync);   
								}
							}
							
						} else {
							
							if (_delegate_DataStreamManager_CheckAndUpdateUser != null) {
								_delegate_DataStreamManager_CheckAndUpdateUser(null, Constant.NETWORK_RESULTCODE_Error_Result_Extend);   
							}
						}
						
					} else {
						
						if (_delegate_DataStreamManager_CheckAndUpdateUser != null) {
							_delegate_DataStreamManager_CheckAndUpdateUser(null, Constant.NETWORK_RESULTCODE_Error_UserData);   
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_CheckAndUpdateUser != null) {
						_delegate_DataStreamManager_CheckAndUpdateUser(null, Constant.NETWORK_RESULTCODE_Error_CheckSum);   
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_CheckAndUpdateUser != null) {
					
					//이미 지급된 보상이거나 크로스 배너등으로 나중에 지급될 경우임, user_data 업데이트 필요없음, 팝업 없음.
					_delegate_DataStreamManager_CheckAndUpdateUser(null, Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_CheckAndUpdateUser != null) {
				_delegate_DataStreamManager_CheckAndUpdateUser(null, Constant.NETWORK_RESULTCODE_Error_Network);   
			}
		}
		
		www.Dispose();
		www = null;
		
	}
	
	// 유저 스코어 통신 (clan_battle.php) - SaveUserData.
	public IEnumerator Network_SaveUserScore(int intUserScore_Input, string strClanId_Input) { 
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = "{\"UserScore\":\"" + intUserScore_Input.ToString() + "\",\"ClanId\":\"" + strClanId_Input + "\"}";
		
		string check = getParameterCheckSum(header + body);    //checksum 코드 생성...
		
		yield return null;
		
		//서버에 전송.
		string sendMode = Constant.NETWORK_SENDMODE_SaveUserScore;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_ClanBattle;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_ClanBattle;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				
				//////////
				string strExtendJson = clsReturn.extend;
				
				if (strExtendJson != null && !strExtendJson.Equals("")) {
					
					JSONNode root = JSON.Parse(strExtendJson);
					string receiveServerTime = root ["ServerTime"];
					int serverTime = int.Parse(receiveServerTime);
					
					if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
						
						Managers.UserData.SetServerTime(clsReturn.extend);
						
						if (_delegate_DataStreamManager_SaveUserScore != null) {
							_delegate_DataStreamManager_SaveUserScore(clsReturn.extend, Constant.NETWORK_RESULTCODE_OK);   
						}
						
					} else {
						
						if (_delegate_DataStreamManager_SaveUserScore != null) {
							_delegate_DataStreamManager_SaveUserScore(null, Constant.NETWORK_RESULTCODE_Error_TimeSync);   
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_SaveUserScore != null) {
						_delegate_DataStreamManager_SaveUserScore(null, Constant.NETWORK_RESULTCODE_Error_Result_Extend);   
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_SaveUserScore != null) {
					_delegate_DataStreamManager_SaveUserScore(null, Constant.NETWORK_RESULTCODE_Error_Result_False);   
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_SaveUserScore != null) {
				_delegate_DataStreamManager_SaveUserScore(null, Constant.NETWORK_RESULTCODE_Error_Network);   
			}
		}
		
		www.Dispose();
		www = null;
		
	}
	
	// 유저 스코어 통신 (clan_battle.php) - ReadBattleData.
	public IEnumerator Network_ReadBattleData(string strClanId_Input) { 
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = "{\"ClanId\":\"" + strClanId_Input + "\"}";
		
		string check = getParameterCheckSum(header + body);
		
		yield return null;
		
		//서버에 전송.
		string sendMode = Constant.NETWORK_SENDMODE_ReadBattleData;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_ClanBattle;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_ClanBattle;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			if (clsReturn.result == true) {
				
				if (clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))) {
					
					if (Managers.UserData != null) {
						
						string strExtendJson = clsReturn.extend;
						
						if (strExtendJson != null && !strExtendJson.Equals("")) {
							
							JSONNode root = JSON.Parse(strExtendJson);
							string receiveServerTime = root ["ServerTime"];
							int serverTime = int.Parse(receiveServerTime);
							
							if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
								
								Managers.UserData.SetServerTime(clsReturn.extend);
								
								if (clsReturn.data != null && !clsReturn.data.Equals("")) {
									
									if (_delegate_DataStreamManager_ReadBattleData != null) {
										_delegate_DataStreamManager_ReadBattleData(clsReturn.data, Constant.NETWORK_RESULTCODE_OK);     
									}   
									
								} else {
									
									if (_delegate_DataStreamManager_ReadBattleData != null) {
										_delegate_DataStreamManager_ReadBattleData(null, Constant.NETWORK_RESULTCODE_Error_Result_Data);   
									}
								}
								
							} else {
								
								if (_delegate_DataStreamManager_ReadBattleData != null) {
									_delegate_DataStreamManager_ReadBattleData(null, Constant.NETWORK_RESULTCODE_Error_TimeSync);   
								}
							}
							
						} else {
							
							if (_delegate_DataStreamManager_ReadBattleData != null) {
								_delegate_DataStreamManager_ReadBattleData(null, Constant.NETWORK_RESULTCODE_Error_Result_Extend);   
							}
						}
						
					} else {
						
						if (_delegate_DataStreamManager_ReadBattleData != null) {
							_delegate_DataStreamManager_ReadBattleData(null, Constant.NETWORK_RESULTCODE_Error_UserData);   
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_ReadBattleData != null) {
						_delegate_DataStreamManager_ReadBattleData(null, Constant.NETWORK_RESULTCODE_Error_CheckSum);   
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_ReadBattleData != null) {
					_delegate_DataStreamManager_ReadBattleData(null, Constant.NETWORK_RESULTCODE_Error_Result_False);   
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_ReadBattleData != null) {
				_delegate_DataStreamManager_ReadBattleData(null, Constant.NETWORK_RESULTCODE_Error_Network);   
			}
		}
		
		www.Dispose();
		www = null;
		
	}
	
	// 푸시 스코어 통신 (token.php) - SaveToken.
	public IEnumerator Network_SaveToken() {
		
		//http://14.49.41.8/st100/token.php?mode=SaveToken&service=ST100&ostype=2&mtype=2&udid=db4c3a4f8f1d1f54ceae4981d6e3672c&token=APA91bEDE_94TUNouLbv7WTD342ayYzwf-llPQgTMGi1JeL3uR4pX161zvX5ypAWCJwFz3V6g9S44XQ8-ehKF5t3xUUq73F0UuDeqdK-w2lLY5-LQXaBaijd7H6L09lBJ1_OBTlnXmROktgVtfLhNZd7K_Q6n7fHwuU00nvqAK5-q_MxKh8gxuc
		
		string urlStr = "";
		
		#if UNITY_IPHONE && !UNITY_EDITOR   
		
		var token  = NotificationServices.deviceToken;
		
		if (token != null) {
			
			string hexToken  =  System.BitConverter.ToString(token).Replace("-","");
			
			if (Constant.PROJECTMODE_Develop) {
				
				m_strURL = Constant.URL_DEVELOP_Token;
				
			} else {
				
				m_strURL = Constant.URL_RELEASE_Token;
			}
			
			urlStr = m_strURL+"?" + 
				"mode=" + Constant.NETWORK_SENDMODE_SaveToken + "&" +
					"service="+ gameCode +"&"+
					"ostype="+osType+"&"+
					"mtype="+mType+"&"+
					"udid="+SystemInfo.deviceUniqueIdentifier+"&"+
					"token="+hexToken;
		}else {
			
		}
		
		#elif UNITY_ANDROID && !UNITY_EDITOR    
		
		string hexToken  = GCM.GetRegistrationId();
		
		if (hexToken != null) {
			
			if (Constant.PROJECTMODE_Develop) {
				
				m_strURL = Constant.URL_DEVELOP_Token;
				
			} else {
				
				m_strURL = Constant.URL_RELEASE_Token;
			}
			
			urlStr = m_strURL+"?"+ 
				"mode=" + Constant.NETWORK_SENDMODE_SaveToken + "&" +
					"service="+ gameCode +"&"+
					"ostype="+osType+"&"+
					"mtype="+mType+"&"+
					"udid="+SystemInfo.deviceUniqueIdentifier+"&"+
					"token="+hexToken;
		}else {
			
		}
		
		#endif      
		
		WWW www = new WWW(urlStr);
		yield return www;
		
		if (www.text.Equals("0")) {
			
		} else if (www.text.Equals("1")) {
			
		} else {
			
		}
		
		www.Dispose();
		www = null;
		
	}
	
	// 푸시 스코어 통신 (token.php) - GetPushOnOff.
	public IEnumerator Network_GetPushOnOff() {
		
		//http://14.49.41.8/st100/token.php?mode=GetPushOnOff&service=ST100&ostype=2&mtype=2&udid=ab4c3a4f8f1d1f54ceae4981d6e3672c
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_Token;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_Token;
		}
		
		string urlStr = m_strURL + "?" + 
			"mode=" + Constant.NETWORK_SENDMODE_GetPushOnOff + "&" +
				"service=" + gameCode + "&" +
				"ostype=" + osType + "&" +
				"mtype=" + mType + "&" +
				"udid=" + SystemInfo.deviceUniqueIdentifier;
		
		WWW www = new WWW(urlStr);
		yield return www;
		
		if (www.text.Equals("0") || www.text.Equals("1")) {
			
			if (_delegate_DataStreamManager_GetPushOnOff != null) {
				_delegate_DataStreamManager_GetPushOnOff(www.text, Constant.NETWORK_RESULTCODE_OK);    
			}
			
		} else {
			
			if (_delegate_DataStreamManager_GetPushOnOff != null) {
				_delegate_DataStreamManager_GetPushOnOff(null, Constant.NETWORK_RESULTCODE_Error_Network);     
			}
		}
		
		www.Dispose();
		www = null;
		
	}
	
	// 푸시 스코어 통신 (token.php) - SetPushOnOff.
	public IEnumerator Network_SetPushOnOff(bool boolPushState_Input) {
		
		//http://14.49.41.8/st100/token.php?mode=SetPushOnOff&service=ST100&ostype=2&mtype=2&udid=ab4c3a4f8f1d1f54ceae4981d6e3672c&onoff=1
		
//				 Debug.Log("ST200k DataStreamManager.Network_SetPushOnOff().boolPushState_Input = " + boolPushState_Input);
		
		int pushStateInt = 0;
		
		if (boolPushState_Input) {
			
			pushStateInt = 1;
			
		} else {
			
			pushStateInt = 0;
		}
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_Token;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_Token;
		}
		
		string urlStr = m_strURL + "?" + 
			"mode=" + Constant.NETWORK_SENDMODE_SetPushOnOff + "&" +
				"service=" + gameCode + "&" +
				"ostype=" + osType + "&" +
				"mtype=" + mType + "&" +
				"udid=" + SystemInfo.deviceUniqueIdentifier + "&" + 
				"onoff=" + pushStateInt;
		
		WWW www = new WWW(urlStr);
		yield return www;
		
//				 Debug.Log("ST200k DataStreamManager.Network_SetPushOnOff().www.text = " + www.text);
		
		if (www.text.Equals("0") || www.text.Equals("1")) {
			
			if (_delegate_DataStreamManager_SetPushOnOff != null) {
				_delegate_DataStreamManager_SetPushOnOff(www.text, Constant.NETWORK_RESULTCODE_OK);    
			}
			
		} else {
			
			if (_delegate_DataStreamManager_SetPushOnOff != null) {
				_delegate_DataStreamManager_SetPushOnOff(null, Constant.NETWORK_RESULTCODE_Error_Network);     
			}
		}
		
		www.Dispose();
		www = null;
	}

	public delegate void SetNickNameDelegate(int _type, int _result, string _errormsg);
	protected SetNickNameDelegate m_SetNickNameDelegate;
	public event SetNickNameDelegate SetNickNameEvent
	{
		add
		{
			m_SetNickNameDelegate = null;
			m_SetNickNameDelegate += value;
		}remove
		{
			m_SetNickNameDelegate -= value;
		}
	}

	public void SetNickName(string _userid, string _nickname)
	{
		StartCoroutine(IESetNickName(_userid, _nickname));
	}

	protected IEnumerator IESetNickName(string _userid, string _nickname)
	{			
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);

		string body = "{\"user_id\":\"" + _userid +
			"\", \"nickname\":\"" + _nickname + "\"}";
		//string body = 

		string check = getParameterCheckSum(body);   //checksum 코드 생성...
		
		yield return null;
		//Debug.Log("BODY: " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);

		string url = "";
		if (Constant.PROJECTMODE_Develop) {
			
			url = Constant.URL_DEVELOP_NICKNAME;
			
		} else {
			
			url = Constant.URL_RELEASE_NICKNAME;
		}
		
		WWW www = new WWW(url, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) 
		{
			//Debug.Log("NICKNAME RETURN: " + www.text);
			JSONNode jsonExtend_Root = JSON.Parse(www.text);

			int status = jsonExtend_Root["status"].AsInt;
			string error_msg = jsonExtend_Root["error_msg"];
			
			if (m_SetNickNameDelegate != null) 
			{
				m_SetNickNameDelegate(Constant.NETWORK_RESULTCODE_OK, status, error_msg);
			}
		}
		
		www.Dispose();
		www = null;
	}


	protected IEnumerator IEPush(string _data)
	{			
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = _data;
		//string body = 
		
		string check = getParameterCheckSum(body);   //checksum 코드 생성...
		
		yield return null;
		//Debug.Log("BODY: " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", "RecivePushMessage");
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		string url = "";
		if (Constant.PROJECTMODE_Develop) {
			
			url = Constant.URL_DEVELOP_PushInfo;
			
		} else {
			
			url = Constant.URL_RELEASE_PushInfo;
		}
		
		WWW www = new WWW(url, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) 
		{
			//Debug.Log("NICKNAME RETURN: " + www.text);
			JSONNode jsonExtend_Root = JSON.Parse(www.text);
			
			int result = jsonExtend_Root["result"].AsInt;
			string error_msg = jsonExtend_Root["error_msg"];
			string datastring = jsonExtend_Root["data"];
			string checkstring = jsonExtend_Root["check"];
			
			//if (m_SetNickNameDelegate != null) 
			//{
			//	m_SetNickNameDelegate(Constant.NETWORK_RESULTCODE_OK, status, error_msg);
			//}
		}
		
		www.Dispose();
		www = null;
	}

	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.

	// UserDataManager 데이터만 변경되었을 경우.
	public void Network_SaveUserData_Input_1(object obj_Input){

		StartCoroutine (Network_SaveUserData(obj_Input, 0, false, false));
	}

	// 최고 기록을 경신했을 경우.
	public void Network_SaveUserData_Input_2(object obj_Input, int intBestScore_Input){
		
		StartCoroutine (Network_SaveUserData(obj_Input, intBestScore_Input, false, false));
	}

	// 출석체크보너스 팝업을 확인했을 경우.
	public void Network_SaveUserData_Input_3(object obj_Input, int intBestScore_Input, bool boolAttendMode_Input){
		
		StartCoroutine (Network_SaveUserData(obj_Input, intBestScore_Input, boolAttendMode_Input, false));
	}

	// 게임 진행을 결과화면까지 3회 했을 경우.
	public void Network_SaveUserData_Input_4(object obj_Input, int intBestScore_Input, bool boolAttendMode_Input, bool boolGameClear_Input){
		
		StartCoroutine (Network_SaveUserData(obj_Input, intBestScore_Input, boolAttendMode_Input, boolGameClear_Input));
	}

	// 유저 데이터 통신 (user_data.php) - SaveUserData.
	public IEnumerator Network_SaveUserData(
		object obj_Input,
		int intBestScore_Input,
		bool boolAttendMode_Input,
		bool boolAhaEnglish_Input) {
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = JsonMapper.ToJson(obj_Input);
		
		string extend = "";
		string strProfileBlock = "";
		string strAttendance = "";
		string strAhaEnglish = "";

		if (Managers.UserData.UserProfileBlock == 1){

			strProfileBlock = "\"ProfileBlock_flag\":\"True\"";

		} else {

			strProfileBlock = "\"ProfileBlock_flag\":\"False\"";
		}

		if (boolAttendMode_Input) {

			strAttendance = "\"attendanceComplete\":\"Y\"";

		} else {

			strAttendance = "\"attendanceComplete\":\"N\"";
		}

		if (boolAhaEnglish_Input){

			strAhaEnglish = "\"AhaCouponAction\":\"True\"";

		} else {

			strAhaEnglish = "\"AhaCouponAction\":\"False\"";
		}

		extend = "{" + strProfileBlock + "," + strAttendance + "," + strAhaEnglish + "}";

		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		//서버에 저장.
		string sendMode = Constant.NETWORK_SENDMODE_SaveUserData;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_UserData;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_UserData;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
				  //Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
				  //Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
				  //Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
				  //Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
				  //Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
				  //Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				
				//////////
				string strExtendJson = clsReturn.extend;
				
				if (strExtendJson != null && !strExtendJson.Equals("")) {
					
					JSONNode root = JSON.Parse(strExtendJson);
					string receiveServerTime = root ["ServerTime"];
					int serverTime = int.Parse(receiveServerTime);
					
					if (serverTime >= (Managers.UserData.GetSyncServerTime() - 30) && serverTime <= (Managers.UserData.GetSyncServerTime() + 30)) {
						
						Managers.UserData.SetServerTime(clsReturn.extend);
						Managers.UserData.SetMessageCount(clsReturn.extend);
						Managers.UserData.SetMessageNewCount(clsReturn.extend);

						if (_delegate_DataStreamManager_SaveUserData != null) {
							_delegate_DataStreamManager_SaveUserData(Constant.NETWORK_RESULTCODE_OK, strExtendJson);
						}
						
					} else {
						
						if (_delegate_DataStreamManager_SaveUserData != null) {
							_delegate_DataStreamManager_SaveUserData(Constant.NETWORK_RESULTCODE_Error_TimeSync, "");
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_SaveUserData != null) {
						_delegate_DataStreamManager_SaveUserData(Constant.NETWORK_RESULTCODE_Error_Result_Extend, "");
					}
				}
				
			} else if (clsReturn.result == false) {

				if(clsReturn.error_msg == Constant.NETWORK_RESULTCODE_Error_UserSequence_Message)
				{
					if (_delegate_DataStreamManager_SaveUserData != null) {
						_delegate_DataStreamManager_SaveUserData(Constant.NETWORK_RESULTCODE_Error_UserSequence, "");
					}
				}else
				{
					if (_delegate_DataStreamManager_SaveUserData != null) {
						_delegate_DataStreamManager_SaveUserData(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
					}
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_SaveUserData != null) {
				_delegate_DataStreamManager_SaveUserData(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
	}
	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
	
	// 유저 데이터 통신 (user_data.php) - ReadUserData.
	public IEnumerator Network_ReadUserData() {
		
//		  Debug.Log ("ST200k DataStreamManager.Network_ReadUserData().msgHeader.Loginid = " + msgHeader.Loginid);
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		string sendMode = Constant.NETWORK_SENDMODE_ReadUserData;
		
		string body = "N/A";
		
		string check = getParameterCheckSum(header + body);    //checksum 코드 생성...
		
		yield return null;
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_UserData;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_UserData;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager.Network_ReadUserData().sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager.Network_ReadUserData().header = " + header);
		//Debug.Log ("ST200k DataStreamManager.Network_ReadUserData().body = " + body);
		//Debug.Log ("ST200k DataStreamManager.Network_ReadUserData().check = " + check);
		//Debug.Log ("ST200k DataStreamManager.Network_ReadUserData().www.text = " + www.text);
		
		if (www.error == null) {
			
			addMessageBuffer("RESPONSE OK: " + www.text);
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
//						  Debug.Log ("ST200k DataStreamManager ReadUserData clsReturn.extend = " + clsReturn.extend);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				
				if (clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))) {
					
					if (Managers.UserData != null) {
						
						UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct();
						userDataStruct = Managers.UserData.GetUserDataStruct();
						userDataStruct = JsonMapper.ToObject<UserDataManager.UserDataStruct>(clsReturn.data);  //한 번더 디코딩(실제 body data).
						
						JSONNode jsonExtend_Root = JSON.Parse(clsReturn.extend);
						
						int intMainScene_To_RankingScene = PlayerPrefs.GetInt(Constant.PREFKEY_MainScene_To_RankingScene_INT);
						
						// 게임시작하고 난 직후의 Main Scene인지 여부. - true.
						if (intMainScene_To_RankingScene == Constant.INT_True) {
							
							PlayerPrefs.SetString(Constant.PREFKEY_ReadUserData_Extend, clsReturn.extend);
							
						}
						
						Managers.UserData.SetUserDataStruct(userDataStruct);
						
						Managers.UserData.ClearChocolateRewardMessageQueue();
						Managers.UserData.SetChocolateRewardMessageQueue(clsReturn.extend);
						
						Managers.UserData.SetServerTime(clsReturn.extend);
						Managers.UserData.SetMessageCount(clsReturn.extend);
						Managers.UserData.SetMessageNewCount(clsReturn.extend);

						if (_delegate_DataStreamManager_ReadUserData != null) {
							_delegate_DataStreamManager_ReadUserData(Constant.NETWORK_RESULTCODE_OK);     
						}
						
					} else {
						
						if (_delegate_DataStreamManager_ReadUserData != null) {
							_delegate_DataStreamManager_ReadUserData(Constant.NETWORK_RESULTCODE_Error_UserData);
						}
					}
				} else {
					
					if (_delegate_DataStreamManager_ReadUserData != null) {
						_delegate_DataStreamManager_ReadUserData(Constant.NETWORK_RESULTCODE_Error_CheckSum);
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_ReadUserData != null) {
					_delegate_DataStreamManager_ReadUserData(Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_ReadUserData != null) {
				_delegate_DataStreamManager_ReadUserData(Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 유저 데이터 통신 (user_data.php) - ReadUserDataExp.
	public IEnumerator Network_ReadUserDataExp(string strExperienceIndex_Input) {
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		string sendMode = Constant.NETWORK_SENDMODE_ReadUserDataExp;
		
		string body = "{\"ExperienceIndex\":" + strExperienceIndex_Input + "}";
		
		string check = getParameterCheckSum(header + body);    //checksum 코드 생성...
		
		yield return null;
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_UserData;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_UserData;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
//						  Debug.Log ("ST200k DataStreamManager ReadUserData sendMode = " + sendMode);
//						  Debug.Log ("ST200k DataStreamManager ReadUserData header = " + header);
//						  Debug.Log ("ST200k DataStreamManager ReadUserData body = " + body);
//						  Debug.Log ("ST200k DataStreamManager ReadUserData check = " + check);
//						  Debug.Log ("ST200k DataStreamManager ReadUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			addMessageBuffer("RESPONSE OK: " + www.text);
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				
				if (clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))) {
					
					if (Managers.UserData != null) {
						
						UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct();
						userDataStruct = Managers.UserData.GetUserDataStruct();
						userDataStruct = JsonMapper.ToObject<UserDataManager.UserDataStruct>(clsReturn.data);  //한 번더 디코딩(실제 body data).
						
						Managers.UserData.SetUserDataStruct(userDataStruct);
						
						Managers.UserData.ClearChocolateRewardMessageQueue();
						Managers.UserData.SetChocolateRewardMessageQueue(clsReturn.extend);
						
						Managers.UserData.SetServerTime(clsReturn.extend);
						Managers.UserData.SetMessageCount(clsReturn.extend);

						if (_delegate_DataStreamManager_ReadUserDataExp != null) {
							_delegate_DataStreamManager_ReadUserDataExp(Constant.NETWORK_RESULTCODE_OK);
						}
						
					} else {
						
						if (_delegate_DataStreamManager_ReadUserDataExp != null) {
							_delegate_DataStreamManager_ReadUserDataExp(Constant.NETWORK_RESULTCODE_Error_UserData);
						}
					}
					
				} else {
					
					if (_delegate_DataStreamManager_ReadUserDataExp != null) {
						_delegate_DataStreamManager_ReadUserDataExp(Constant.NETWORK_RESULTCODE_Error_CheckSum);
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_ReadUserDataExp != null) {
					_delegate_DataStreamManager_ReadUserDataExp(Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_ReadUserDataExp != null) {
				_delegate_DataStreamManager_ReadUserDataExp(Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 유저 데이터 통신 (user_data.php) - DeleteUserData.
	public IEnumerator Network_DeleteUserData() {
		
//		  Debug.Log ("ST200k DataStreamManager.Network_DeleteUserData().msgHeader.Loginid = " + msgHeader.Loginid);
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		string sendMode = Constant.NETWORK_SENDMODE_DeleteUserData;
		
		string body = "N/A";
		
		string check = getParameterCheckSum(header + body);    //checksum 코드 생성...
		
		yield return null;
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_UserData;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_UserData;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
//				  Debug.Log ("ST200k DataStreamManager.Network_DeleteUserData().sendMode = " + sendMode);
//				  Debug.Log ("ST200k DataStreamManager.Network_DeleteUserData().header = " + header);
//				  Debug.Log ("ST200k DataStreamManager.Network_DeleteUserData().body = " + body);
//				  Debug.Log ("ST200k DataStreamManager.Network_DeleteUserData().check = " + check);
//				  Debug.Log ("ST200k DataStreamManager.Network_DeleteUserData().www.text = " + www.text);
		
		if (www.error == null) {
			
			addMessageBuffer("RESPONSE OK: " + www.text);
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
//			  Debug.Log ("ST200k DataStreamManager.Network_DeleteUserData().clsReturn.result = " + clsReturn.result.ToString());
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				
//				  Debug.Log ("ST200k DataStreamManager.Network_DeleteUserData().clsReturn.result == true");
				
				if (_delegate_DataStreamManager_DeleteUserData != null) {
					_delegate_DataStreamManager_DeleteUserData(Constant.NETWORK_RESULTCODE_OK);     
				}
				
			} else if (clsReturn.result == false) {
				
				if (_delegate_DataStreamManager_DeleteUserData != null) {
					_delegate_DataStreamManager_DeleteUserData(Constant.NETWORK_RESULTCODE_Error_Result_False);
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_DeleteUserData != null) {
				_delegate_DataStreamManager_DeleteUserData(Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 상품구입	통계기록 통신 (item_log.php) - SaveLog.
	public IEnumerator Network_SaveLog(int intPageCode_Input, int intItemCode_Input) { 
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		string body = "{\"PageCode\":\"" + intPageCode_Input.ToString() + "\",\"ItemCode\":\"" + intItemCode_Input.ToString() + "\"}";
		string check = getParameterCheckSum(header + body);    //checksum 코드 생성...
		
		yield return null;
		
		//서버에 전송.
		string sendMode = Constant.NETWORK_SENDMODE_SaveLog;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_ItemLog;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_ItemLog;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		www.Dispose();
		www = null;
		
	}
	
	
	// 월드랭킹 저장하기 통신 (update_result.php) - SetWorldRankingGameResult.
	public IEnumerator Network_SetWorldRankingGameResult(string strBody_Input){
		
		//Debug.Log ("ST200k DataStreamManager.Network_SetWorldRankingGameResult().strBody_Input = " + strBody_Input);
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string body = strBody_Input;
		
		string check = getParameterCheckSum(body);    //checksum 코드 생성...
		
		yield return null;
		
		WWWForm form = new WWWForm();
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_WorldRanking_Update;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_WorldRanking_Update;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
//		  Debug.Log ("ST200k DataStreamManager.Network_SetWorldRankingGameResult().body = " + body);
//		  Debug.Log ("ST200k DataStreamManager.Network_SetWorldRankingGameResult().check = " + check);
//		  Debug.Log ("ST200k DataStreamManager.Network_SetWorldRankingGameResult().www.text = " + www.text);
		
		if (www.error == null || www.error.Equals("")) {
			
			if (_delegate_DataStreamManager_SetWorldRankingGameResult != null) {
				_delegate_DataStreamManager_SetWorldRankingGameResult(Constant.NETWORK_RESULTCODE_OK);     
			}
			
		} else {
			
			if (_delegate_DataStreamManager_SetWorldRankingGameResult != null) {
				_delegate_DataStreamManager_SetWorldRankingGameResult(Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}
		
		www.Dispose();
		www = null;
	}
	
	// 월드랭킹 불러오기 통신 (get_ranking.php) - SetWorldRankingData.
	public IEnumerator Network_SetWorldRankingData(string strBody_Input){
		
		//Debug.Log ("ST200k DataStreamManager.Network_SetWorldRankingData().strBody_Input = " + strBody_Input);
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		
		string body = strBody_Input;
		
		string check = getParameterCheckSum(body);    //checksum 코드 생성...
		
		yield return null;
		
		WWWForm form = new WWWForm();
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_WorldRanking_Get;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_WorldRanking_Get;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
//		  Debug.Log ("ST200k DataStreamManager.Network_SetWorldRankingData().body = " + body);
//		  Debug.Log ("ST200k DataStreamManager.Network_SetWorldRankingData().check = " + check);
//		  Debug.Log ("ST200k DataStreamManager.Network_SetWorldRankingData().www.text = " + www.text);
		
		if (www.error == null || www.error.Equals("")) {

			WorldRankManager.Instance.setWorldRankingData(www.text);

			if (_delegate_DataStreamManager_SetWorldRankingData != null) {
				_delegate_DataStreamManager_SetWorldRankingData(Constant.NETWORK_RESULTCODE_OK);     
			}
			
		} else {
			
			if (_delegate_DataStreamManager_SetWorldRankingData != null) {
				_delegate_DataStreamManager_SetWorldRankingData(Constant.NETWORK_RESULTCODE_Error_Network);
			}
		}
		
		www.Dispose();
		www = null;
		
	}
	
	public IEnumerator Network_Popup_Info(MainTitleManager.PostData_PushInfo postData_Push_Input){
		
		string data = JsonMapper.ToJson(postData_Push_Input);
		string check = getParameterCheckSum(data);
		
		yield return null;
		
		WWWForm form = new WWWForm();
		form.AddField("data", data);
		form.AddField("check", check);
		
		m_strURL = Constant.URL_Popup_Info;
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
//		Debug.Log ("ST200k DataStreamManager.Network_Popup_Info().data = " + data);
//		Debug.Log ("ST200k DataStreamManager.Network_Popup_Info().check = " + check);
//		Debug.Log ("ST200k DataStreamManager.Network_Popup_Info().www = " + www.text);
		
		if (www.error == null || www.error.Equals("")){
			
			JSONNode root = JSON.Parse(www.text);
			
			if ( root["status"].AsInt == 1 ){
				
				if (_delegate_DataStreamManager_Popup_Info != null) {
					_delegate_DataStreamManager_Popup_Info(Constant.NETWORK_RESULTCODE_OK, www.text);
				}
				
			} else {
				
				if (_delegate_DataStreamManager_Popup_Info != null) {
					_delegate_DataStreamManager_Popup_Info(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
				}
			}
			
		} else {
			
			if (_delegate_DataStreamManager_Popup_Info != null) {
				_delegate_DataStreamManager_Popup_Info(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
		
	}
	
		// 네이버 인앱 추가 (by 최원석 in 14.06.11) - Start ==========
	public IEnumerator Network_SaveChargeData_Naver(string receiptData){
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime() ;
		string header = JsonMapper.ToJson(msgHeader);
		string body = receiptData;
		string check = getParameterCheckSum(header + body); //checksum 코드 생성...
		
		string sendMode = "" ;
		
		if (Constant.PROJECTMODE_IabTest){
			
			sendMode = Constant.NETWORK_SENDMODE_SaveChargeDataTest ;
			
		} else {
			
			sendMode = Constant.NETWORK_SENDMODE_SaveChargeData ;
		}
		
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_AppCharge;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_AppCharge;
		}

		Debug.Log ("ST200k DataStreamManager.Network_SaveChargeData_Naver().Constant.PROJECTMODE_Develop = " + Constant.PROJECTMODE_Develop.ToString());
		Debug.Log ("ST200k DataStreamManager.Network_SaveChargeData_Naver().m_strURL = " + m_strURL);

		WWW www = new WWW(m_strURL, form);
		yield return www;

		Debug.Log ("ST200k DataStreamManager.Network_SaveChargeData_Naver().sendMode = " + sendMode);
		Debug.Log ("ST200k DataStreamManager.Network_SaveChargeData_Naver().header = " + header);
		Debug.Log ("ST200k DataStreamManager.Network_SaveChargeData_Naver().body = " + body);
		Debug.Log ("ST200k DataStreamManager.Network_SaveChargeData_Naver().check = " + check);
		Debug.Log ("ST200k DataStreamManager.Network_SaveChargeData_Naver().www = " + www.text.ToString());
		
		if(www.error == null){
			addMessageBuffer("RESPONSE OK: "+www.text);
			
			clsReturn.init();   //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if(clsReturn.result == true){
				
				if(clsReturn.check.Equals(getParameterCheckSum(clsReturn.data + clsReturn.extend))){
					
					IABReturnTransactionStruct returnTransactionStruct = new IABReturnTransactionStruct() ;
					
					JSONNode root = JSON.Parse(clsReturn.data);
					returnTransactionStruct.ProductId = root["ProductId"] ;
					returnTransactionStruct.OrderId = root["Txid"] ;
					
					if (_delegate_DataStreamManager_SaveChargeData_Naver != null){
						_delegate_DataStreamManager_SaveChargeData_Naver(Constant.NETWORK_RESULTCODE_OK, returnTransactionStruct.ProductId) ;   
					}
					
				}else{

					if (_delegate_DataStreamManager_SaveChargeData_Naver != null){
						_delegate_DataStreamManager_SaveChargeData_Naver(Constant.NETWORK_RESULTCODE_Error_CheckSum, "") ;     
					}
				}
				
			}else if(clsReturn.result == false){

				if (_delegate_DataStreamManager_SaveChargeData_Naver != null){
					_delegate_DataStreamManager_SaveChargeData_Naver(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
				}
			}
			
		} else {

			if (_delegate_DataStreamManager_SaveChargeData_Naver != null){
				_delegate_DataStreamManager_SaveChargeData_Naver(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose() ;
		www = null ;
	}
	// 네이버 인앱 추가 (by 최원석 in 14.06.11) - End ==========
	
	#region PVP 

	[HideInInspector]
	public delegate void Delegate_DataStreamManager_PVP(int intResult_Code_Input, string strResult_Extend_Input);
	protected Delegate_DataStreamManager_PVP _delegate_DataStreamManager_PVP ;
	public event Delegate_DataStreamManager_PVP Event_Delegate_DataStreamManager_PVP{
		add {
			_delegate_DataStreamManager_PVP = null;
			if (_delegate_DataStreamManager_PVP == null) _delegate_DataStreamManager_PVP += value;
		}
		remove {
			
			_delegate_DataStreamManager_PVP -= value;
		}
	}

	public void PVP_Request_Recommend(string _usernickname, int _maxstage)
	{
		StartCoroutine(PVP_Request(_usernickname, _maxstage));
	}
	// 유저 데이터 통신 (user_data.php) - SaveUserData.
	protected IEnumerator PVP_Request(string _usernickname, int _maxstage) 
	{

		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);

		Dictionary<string, string> bodydic = new Dictionary<string, string>();
		bodydic.Add("UserNickName", "\"" + _usernickname + "\"");
		bodydic.Add("MaxStage", _maxstage.ToString());

		string body = TextManager.CreateJsonData(bodydic);
		//Debug.Log("body: " + body);
		string extend = "";
		
		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		//서버에 저장.
		string sendMode = Constant.NETWORK_SENDMODE_PVPRecommendList;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_PvpInfo;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_PvpInfo;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				//Debug.Log("mark");
				string returndata = clsReturn.data;
				//Debug.Log("return data: " + returndata);
				string strExtendJson = clsReturn.extend;
				
				if (returndata != null && !returndata.Equals("")) {

					//JSONNode extendroot = JSON.Parse(strExtendJson);
					//string receiveServerTime = extendroot ["ServerTime"];
					//int serverTime = int.Parse(receiveServerTime);


					JSONNode root = JSON.Parse(returndata);

					JSONNode myinfo = root["MyInfo"];
					string myuserindex = myinfo["pvp_user_index"];
					int mybattlecount = myinfo["battle_count"].AsInt;
					int mywincount = myinfo["win_count"].AsInt;
					int mylosecount = myinfo["lose_count"].AsInt;
					//Debug.Log("myinfo: " + myuserindex + " WIN: " + mywincount);
					
					JSONNode recommend = root["Recommend"];
					List<UserInfoData> pvprecommendlist = new List<UserInfoData>();
					for(int i = 0; i < recommend.Count; i++)
					{
						JSONNode recommenddata = recommend[i];
						//Debug.Log("TOTAL: " + recommenddata.ToString());

						int recommenduserindex = recommenddata["pvp_user_index"].AsInt;
						string recommendnickname = recommenddata["nickname"];
						int recommendbattlecount = recommenddata["battle_count"].AsInt;
						int recommendwincount = recommenddata["win_count"].AsInt;
						int recommendlosecount = recommenddata["lose_count"].AsInt;
						JSONNode armdata = recommenddata["armed_data"];
						int recommendcharacterindex = armdata["CharacterIndex"].AsInt;
						int recommendtacticindex = armdata["TacticIndex"].AsInt;
						int recommendshipindex = armdata["ShipIndex"].AsInt;
						int recommendshiplevel = armdata["ShipLevel"].AsInt;
						JSONArray recommendsubshipindex = armdata["SubShipIndexList"].AsArray;
						JSONArray recommendsubshiplevel = armdata["SubShipLeveList"].AsArray;
						int recommendreward = recommenddata["winning_reward"].AsInt;

						UserInfoData recommendinfodata = new UserInfoData();
						recommendinfodata.UserIndex = recommenduserindex;
						recommendinfodata.UserNickName = recommendnickname;
						recommendinfodata.CharacterIndex = recommendcharacterindex;
						recommendinfodata.TacticIndex = recommendtacticindex;
						recommendinfodata.ShipIndex = recommendshipindex;
						recommendinfodata.ShipLevel = recommendshiplevel;
						int[] subshipindexlist = new int[]{0,0,0,0};
						int[] subshiplevellist = new int[]{0,0,0,0};
						for(int j = 0; j < subshipindexlist.Length; j++)
						{
							if(recommendsubshipindex.Count > j)
							{
								subshipindexlist[j] = recommendsubshipindex[j].AsInt;
							}
						}
						for(int j = 0; j < subshiplevellist.Length; j++)
						{
							if(recommendsubshiplevel.Count > j)
							{
								subshiplevellist[j] = recommendsubshiplevel[j].AsInt;
							}
						}
						recommendinfodata.SubShipIndexList = subshipindexlist;
						recommendinfodata.SubShipLevelList = subshiplevellist;

						recommendinfodata.RewardAmount = recommendreward;

						pvprecommendlist.Add(recommendinfodata);

						//Debug.Log("ARMDATA: " + armdata.ToString());
						//Debug.Log("hmm: " + recommenduserindex + " subship: " + recommendsubshiplevel[0].AsInt);
					}
					PVPDataManager.Instance.SetPVPRecommendList(pvprecommendlist);

					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_OK, strExtendJson);
					}
				} else {
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_Extend, "");
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if(clsReturn.error_msg == Constant.NETWORK_RESULTCODE_Error_UserSequence_Message)
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_UserSequence, "");
					}
				}else
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
					}
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_PVP != null) {
				_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
	}

	public void PVP_Request_FriendList(string _usernickname, int _maxstage)
	{
		StartCoroutine(IEPVP_Request_FriendList(_usernickname, _maxstage));
	}
	// 유저 데이터 통신 (user_data.php) - SaveUserData.
	protected IEnumerator IEPVP_Request_FriendList(string _usernickname, int _maxstage) 
	{
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		Dictionary<string, string> bodydic = new Dictionary<string, string>();
		bodydic.Add("UserNickName", "\""+_usernickname+"\"");
		bodydic.Add("MaxStage", _maxstage.ToString());
		
		string body = TextManager.CreateJsonData(bodydic);
		//Debug.Log("body: " + body);
		string extend = "";
		
		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		//서버에 저장.
		string sendMode = Constant.NETWORK_SENDMODE_PVPFriendList;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_PvpInfo;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_PvpInfo;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				//Debug.Log("mark");
				string returndata = clsReturn.data;
				string strExtendJson = clsReturn.extend;
				
				if (returndata != null && !returndata.Equals("")) {
					
					//JSONNode extendroot = JSON.Parse(strExtendJson);
					//string receiveServerTime = extendroot ["ServerTime"];
					//int serverTime = int.Parse(receiveServerTime);
					
					
					JSONNode root = JSON.Parse(returndata);
					
					JSONNode friendlist = root["FriendsList"];

					PVPDataManager.Instance.m_FriendInfoList.Clear();
					for(int friendindexno = 0; friendindexno < friendlist.Count; friendindexno++)
					{
						JSONNode userdata = friendlist[friendindexno];
						//Debug.Log("TOTAL: " + userdata.ToString());
						
						int userindex = userdata["pvp_user_index"].AsInt;
						string nickname = userdata["nickname"];
						int battlecount = userdata["battle_count"].AsInt;
						int wincount = userdata["win_count"].AsInt;
						int losecount = userdata["lose_count"].AsInt;
						JSONNode armdata = userdata["armed_data"];
						int characterindex = armdata["CharacterIndex"].AsInt;
						int tacticindex = armdata["TacticIndex"].AsInt;
						int shipindex = armdata["ShipIndex"].AsInt;
						int shiplevel = armdata["ShipLevel"].AsInt;
						JSONArray subshipindex = armdata["SubShipIndexList"].AsArray;
						JSONArray subshiplevel = armdata["SubShipLeveList"].AsArray;
						int reward = userdata["winning_reward"].AsInt;
						int repairsec = userdata["sec_under_repair"].AsInt;

						UserInfoData infodata = new UserInfoData();
						infodata.UserIndex = userindex;
						infodata.UserNickName = nickname;
						infodata.CharacterIndex = characterindex;
						infodata.TacticIndex = tacticindex;
						infodata.ShipIndex = shipindex;
						infodata.ShipLevel = shiplevel;
						int[] subshipindexlist = new int[]{0,0,0,0};
						int[] subshiplevellist = new int[]{0,0,0,0};
						for(int j = 0; j < subshipindexlist.Length; j++)
						{
							if(subshipindex.Count > j)
							{
								subshipindexlist[j] = subshipindex[j].AsInt;
							}
						}
						for(int j = 0; j < subshiplevellist.Length; j++)
						{
							if(subshiplevel.Count > j)
							{
								subshiplevellist[j] = subshiplevel[j].AsInt;
							}
						}
						infodata.SubShipIndexList = subshipindexlist;
						infodata.SubShipLevelList = subshiplevellist;

						infodata.RewardAmount = reward;
						infodata.RepairSecond = repairsec;

						PVPDataManager.Instance.m_FriendInfoList.Add(infodata);
						
						//Debug.Log("ARMDATA: " + armdata.ToString());
						//Debug.Log("hmm: " + recommenduserindex + " subship: " + recommendsubshiplevel[0].AsInt);
					}
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_OK, strExtendJson);
					}

				} else {
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_Extend, "");
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if(clsReturn.error_msg == Constant.NETWORK_RESULTCODE_Error_UserSequence_Message)
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_UserSequence, "");
					}
				}else
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
					}
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_PVP != null) {
				_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
	}

	public void PVP_Request_FriendSearch(string _usernickname, int _maxstage, string _nickname)
	{
		StartCoroutine(IEPVP_Request_FriendSearch(_usernickname, _maxstage, _nickname));
	}
	// 유저 데이터 통신 (user_data.php) - SaveUserData.
	protected IEnumerator IEPVP_Request_FriendSearch(string _usernickname, int _maxstage, string _nickname) 
	{
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		Dictionary<string, string> bodydic = new Dictionary<string, string>();
		bodydic.Add("UserNickName", "\""+_usernickname+"\"");
		bodydic.Add("MaxStage", _maxstage.ToString());
		bodydic.Add("SearchNick", "\""+_nickname + "\"");
		
		string body = TextManager.CreateJsonData(bodydic);
		//Debug.Log("body: " + body);
		string extend = "";
		
		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		//서버에 저장.
		string sendMode = Constant.NETWORK_SENDMODE_PVPFriendSearchList;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_PvpInfo;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_PvpInfo;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				//Debug.Log("mark");
				string returndata = clsReturn.data;
				string strExtendJson = clsReturn.extend;
				
				if (returndata != null && !returndata.Equals("")) {
					
					//JSONNode extendroot = JSON.Parse(strExtendJson);
					//string receiveServerTime = extendroot ["ServerTime"];
					//int serverTime = int.Parse(receiveServerTime);
					
					
					JSONNode root = JSON.Parse(returndata);
					
					JSONNode friendlist = root["SearchList"];
					//Debug.Log("TOTAL FRIEND SEARCH COUNT: " + friendlist.Count);

					PVPDataManager.Instance.m_FriendSearchInfoList.Clear();
					for(int friendindexno = 0; friendindexno < friendlist.Count; friendindexno++)
					{
						JSONNode userdata = friendlist[friendindexno];
						//Debug.Log("TOTAL: " + userdata.ToString());
						
						int userindex = userdata["pvp_user_index"].AsInt;
						string nickname = userdata["nickname"];
						int battlecount = userdata["battle_count"].AsInt;
						int wincount = userdata["win_count"].AsInt;
						int losecount = userdata["lose_count"].AsInt;
						JSONNode armdata = userdata["armed_data"];
						int characterindex = armdata["CharacterIndex"].AsInt;
						int tacticindex = armdata["TacticIndex"].AsInt;
						int shipindex = armdata["ShipIndex"].AsInt;
						int shiplevel = armdata["ShipLevel"].AsInt;
						JSONArray subshipindex = armdata["SubShipIndexList"].AsArray;
						JSONArray subshiplevel = armdata["SubShipLeveList"].AsArray;
						int reward = userdata["winning_reward"].AsInt;
						int repairsec = userdata["sec_under_repair"].AsInt;

						UserInfoData infodata = new UserInfoData();
						infodata.UserIndex = userindex;
						infodata.UserNickName = nickname;
						infodata.CharacterIndex = characterindex;
						infodata.TacticIndex = tacticindex;
						infodata.ShipIndex = shipindex;
						infodata.ShipLevel = shiplevel;
						int[] subshipindexlist = new int[]{0,0,0,0};
						int[] subshiplevellist = new int[]{0,0,0,0};
						for(int j = 0; j < subshipindexlist.Length; j++)
						{
							if(subshipindex.Count > j)
							{
								subshipindexlist[j] = subshipindex[j].AsInt;
							}
						}
						for(int j = 0; j < subshiplevellist.Length; j++)
						{
							if(subshiplevel.Count > j)
							{
								subshiplevellist[j] = subshiplevel[j].AsInt;
							}
						}
						infodata.SubShipIndexList = subshipindexlist;
						infodata.SubShipLevelList = subshiplevellist;

						infodata.RewardAmount = reward;
						infodata.RepairSecond = repairsec;

						PVPDataManager.Instance.m_FriendSearchInfoList.Add(infodata);
						
						//Debug.Log("ARMDATA: " + armdata.ToString());
						//Debug.Log("hmm: " + recommenduserindex + " subship: " + recommendsubshiplevel[0].AsInt);
					}
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_OK, friendlist.Count.ToString());
					}
					
				} else {
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_Extend, "");
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if(clsReturn.error_msg == Constant.NETWORK_RESULTCODE_Error_UserSequence_Message)
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_UserSequence, "");
					}
				}else
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
					}
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_PVP != null) {
				_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
	}

	public void PVP_Request_FriendAdd(int _userindex)
	{
		StartCoroutine(IEPVP_Request_FriendAdd(_userindex));
	}
	// 유저 데이터 통신 (user_data.php) - SaveUserData.
	protected IEnumerator IEPVP_Request_FriendAdd(int _userindex) 
	{
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		Dictionary<string, string> bodydic = new Dictionary<string, string>();
		bodydic.Add("UserIndex", _userindex.ToString());
		
		string body = TextManager.CreateJsonData(bodydic);
		//Debug.Log("body: " + body);
		string extend = "";
		
		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		//서버에 저장.
		string sendMode = Constant.NETWORK_SENDMODE_PVPFriendAdd;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_PvpInfo;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_PvpInfo;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			//리턴 오브젝트..
			if (clsReturn.result == true) {

				if (_delegate_DataStreamManager_PVP != null) {
					_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_OK, "");
				}
				
			} else if (clsReturn.result == false) {
				
				if(clsReturn.error_msg == Constant.NETWORK_RESULTCODE_Error_UserSequence_Message)
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_UserSequence, "");
					}
				}else
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
					}
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_PVP != null) {
				_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
	}

	public void PVP_Request_FriendRemove(int _userindex)
	{
		StartCoroutine(IEPVP_Request_FriendRemove(_userindex));
	}
	// 유저 데이터 통신 (user_data.php) - SaveUserData.
	protected IEnumerator IEPVP_Request_FriendRemove(int _userindex) 
	{
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		Dictionary<string, string> bodydic = new Dictionary<string, string>();
		bodydic.Add("UserIndex", _userindex.ToString());
		
		string body = TextManager.CreateJsonData(bodydic);
		Debug.Log("body: " + body);
		string extend = "";
		
		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		//서버에 저장.
		string sendMode = Constant.NETWORK_SENDMODE_PVPFriendRemove;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_PvpInfo;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_PvpInfo;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				//Debug.Log("mark");
				if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_OK, "");
					}
			} else if (clsReturn.result == false) {
				
				if(clsReturn.error_msg == Constant.NETWORK_RESULTCODE_Error_UserSequence_Message)
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_UserSequence, "");
					}
				}else
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
					}
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_PVP != null) {
				_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
	}

	public void PVP_Request_SaveBattleResult(int _userindex, bool _win)
	{
		StartCoroutine(IEPVP_Request_SaveBattleResult(_userindex, _win));
	}
	// 유저 데이터 통신 (user_data.php) - SaveUserData.
	protected IEnumerator IEPVP_Request_SaveBattleResult(int _userindex, bool _win) 
	{
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		Dictionary<string, string> bodydic = new Dictionary<string, string>();
		bodydic.Add("UserIndex", _userindex.ToString());
		if(_win)
		{
			bodydic.Add("Win", "true");
		}else
		{
			bodydic.Add("Win", "false");
		}

		string body = TextManager.CreateJsonData(bodydic);
		//Debug.Log("body: " + body);
		string extend = "";
		
		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		//서버에 저장.
		string sendMode = Constant.NETWORK_SENDMODE_PVPSaveResult;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_PvpInfo;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_PvpInfo;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				//Debug.Log("mark");
				string returndata = clsReturn.data;
				string strExtendJson = clsReturn.extend;
				
				if (returndata != null && !returndata.Equals("")) {
					
					//JSONNode extendroot = JSON.Parse(strExtendJson);
					//string receiveServerTime = extendroot ["ServerTime"];
					//int serverTime = int.Parse(receiveServerTime);
					
					
					JSONNode root = JSON.Parse(returndata);
					
					JSONNode resultdata = root["MyInfo"];

					int wincount = resultdata["win_count"].AsInt;
					int losecount = resultdata["loss_count"].AsInt;
					PVPDataManager.Instance.MyWinCount = wincount;
					PVPDataManager.Instance.MyLoseCount = losecount;

					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_OK, strExtendJson);
					}
					
				} else {
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_Extend, "");
					}
				}
			} else if (clsReturn.result == false) {
				
				if(clsReturn.error_msg == Constant.NETWORK_RESULTCODE_Error_UserSequence_Message)
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_UserSequence, "");
					}
				}else
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
					}
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_PVP != null) {
				_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
	}

	public void PVP_Request_WorldRank()
	{
		StartCoroutine(IEPVP_Request_WorldRank());
	}
	// 유저 데이터 통신 (user_data.php) - SaveUserData.
	protected IEnumerator IEPVP_Request_WorldRank() 
	{
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = "";
		//Debug.Log("body: " + body);
		string extend = "";
		
		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		//서버에 저장.
		string sendMode = Constant.NETWORK_SENDMODE_PVPWorldRank;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_PvpInfo;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_PvpInfo;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				//Debug.Log("mark");
				string returndata = clsReturn.data;
				string strExtendJson = clsReturn.extend;
				
				if (returndata != null && !returndata.Equals("")) {
					
					//JSONNode extendroot = JSON.Parse(strExtendJson);
					//string receiveServerTime = extendroot ["ServerTime"];
					//int serverTime = int.Parse(receiveServerTime);
					
					PVPDataManager.Instance.m_WorldRankList.Clear();
					JSONNode root = JSON.Parse(returndata);

					JSONNode myrank = root["MyRank"];
					int myuserindex = myrank["pvp_user_index"].AsInt;
					int mywincount = myrank["win_count"].AsInt;
					int mylosecount = myrank["loss_count"].AsInt;
					JSONNode myarmdata = myrank["armed_data"];
					int mycharacter = myarmdata["CharacterIndex"].AsInt;
					int mytacticindex = myarmdata["TacticIndex"].AsInt;
					int myshipindex = myarmdata["ShipIndex"].AsInt;
					int myshiplevel = myarmdata["ShipLevel"].AsInt;
					int myrankno = myrank["rank"].AsInt;
					UserPVPRankInfoData myrankinfodata = new UserPVPRankInfoData();
					myrankinfodata.Rank = myrankno;
					myrankinfodata.CharacterIndex = mycharacter;
					myrankinfodata.WinCount = mywincount;
					myrankinfodata.LoseCount = mylosecount;
					myrankinfodata.ShipIndex = myshipindex;
					myrankinfodata.ShipLevel = myshiplevel;
					myrankinfodata.UserIndex = myuserindex;
					myrankinfodata.UserNickName = Managers.UserData.UserNickName;

					PVPDataManager.Instance.m_WorldRankList.Add(myrankinfodata);


					JSONNode friendlist = root["TopRank"];
					//Debug.Log("TOTAL FRIEND SEARCH COUNT: " + friendlist.Count);

					for(int friendindexno = 0; friendindexno < friendlist.Count; friendindexno++)
					{
						JSONNode userdata = friendlist[friendindexno];
						//Debug.Log("TOTAL: " + userdata.ToString());
						
						int userindex = userdata["pvp_user_index"].AsInt;
						string nickname = userdata["nickname"];
						int wincount = userdata["win_count"].AsInt;
						int losecount = userdata["lose_count"].AsInt;
						JSONNode armdata = userdata["armed_data"];
						int characterindex = armdata["CharacterIndex"].AsInt;
						int tacticindex = armdata["TacticIndex"].AsInt;
						int shipindex = armdata["ShipIndex"].AsInt;
						int shiplevel = armdata["ShipLevel"].AsInt;
						int rank = userdata["rank"].AsInt;

						UserPVPRankInfoData infodata = new UserPVPRankInfoData();
						infodata.UserIndex = userindex;
						infodata.UserNickName = nickname;
						infodata.CharacterIndex = characterindex;
						infodata.ShipIndex = shipindex;
						infodata.ShipLevel = shiplevel;
						infodata.LoseCount = losecount;
						infodata.WinCount = wincount;
						infodata.Rank = rank;

						
						PVPDataManager.Instance.m_WorldRankList.Add(infodata);
						
						//Debug.Log("ARMDATA: " + armdata.ToString());
						//Debug.Log("hmm: " + recommenduserindex + " subship: " + recommendsubshiplevel[0].AsInt);
					}

					PVPDataManager.Instance.m_RewardList.Clear();
					JSONNode rewardlist = root["RewardNotice"];
					for(int i = 0; i < rewardlist.Count; i++)
					{
						JSONNode rewarddata = rewardlist[i];
						PVPRewardData data = new PVPRewardData();
						data.ImageIndex = rewarddata["image_index"].AsInt;
						data.WinCount = rewarddata["win_count"].AsInt;
						data.WinColor = rewarddata["color_code"];
						data.RewardString = rewarddata["reward_string"];
						PVPDataManager.Instance.m_RewardList.Add(data);
					}


					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_OK, strExtendJson);
					}
					
				} else {
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_Extend, "");
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if(clsReturn.error_msg == Constant.NETWORK_RESULTCODE_Error_UserSequence_Message)
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_UserSequence, "");
					}
				}else
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
					}
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_PVP != null) {
				_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
	}

	public void PVP_Request_FriendRank()
	{
		StartCoroutine(IEPVP_Request_FriendRank());
	}
	// 유저 데이터 통신 (user_data.php) - SaveUserData.
	protected IEnumerator IEPVP_Request_FriendRank() 
	{
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);
		
		string body = "";
		Debug.Log("body: " + body);
		string extend = "";
		
		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		//서버에 저장.
		string sendMode = Constant.NETWORK_SENDMODE_PVPFriendRank;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_PvpInfo;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_PvpInfo;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			Debug.Log("clsreturn: " + clsReturn.result);
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				Debug.Log("mark");
				string returndata = clsReturn.data;
				string strExtendJson = clsReturn.extend;
				
				if (returndata != null && !returndata.Equals("")) {
					
					//JSONNode extendroot = JSON.Parse(strExtendJson);
					//string receiveServerTime = extendroot ["ServerTime"];
					//int serverTime = int.Parse(receiveServerTime);
					
					PVPDataManager.Instance.m_FriendRankList.Clear();
					JSONNode root = JSON.Parse(returndata);
					
					JSONNode myrank = root["MyRank"];
					int myuserindex = myrank["pvp_user_index"].AsInt;
					int mywincount = myrank["win_count"].AsInt;
					int mylosecount = myrank["loss_count"].AsInt;
					JSONNode myarmdata = myrank["armed_data"];
					int mycharacter = myarmdata["CharacterIndex"].AsInt;
					int mytacticindex = myarmdata["TacticIndex"].AsInt;
					int myshipindex = myarmdata["ShipIndex"].AsInt;
					int myshiplevel = myarmdata["ShipLevel"].AsInt;
					int myrankno = myrank["rank"].AsInt;
					UserPVPRankInfoData myrankinfodata = new UserPVPRankInfoData();
					myrankinfodata.Rank = myrankno;
					myrankinfodata.CharacterIndex = mycharacter;
					myrankinfodata.LoseCount = mylosecount;
					myrankinfodata.WinCount = mywincount;
					myrankinfodata.ShipIndex = myshipindex;
					myrankinfodata.ShipLevel = myshiplevel;
					myrankinfodata.UserIndex = myuserindex;
					myrankinfodata.UserNickName = Managers.UserData.UserNickName;
					
					PVPDataManager.Instance.m_FriendRankList.Add(myrankinfodata);
					
					
					JSONNode friendlist = root["TopRank"];
					Debug.Log("TOTAL FRIEND SEARCH COUNT: " + friendlist.Count);
					
					for(int friendindexno = 0; friendindexno < friendlist.Count; friendindexno++)
					{
						JSONNode userdata = friendlist[friendindexno];
						Debug.Log("TOTAL: " + userdata.ToString());
						
						int userindex = userdata["pvp_user_index"].AsInt;
						string nickname = userdata["nickname"];
						int wincount = userdata["win_count"].AsInt;
						int losecount = userdata["lose_count"].AsInt;
						JSONNode armdata = userdata["armed_data"];
						int characterindex = armdata["CharacterIndex"].AsInt;
						int tacticindex = armdata["TacticIndex"].AsInt;
						int shipindex = armdata["ShipIndex"].AsInt;
						int shiplevel = armdata["ShipLevel"].AsInt;
						int rank = userdata["rank"].AsInt;
						
						UserPVPRankInfoData infodata = new UserPVPRankInfoData();
						infodata.UserIndex = userindex;
						infodata.UserNickName = nickname;
						infodata.CharacterIndex = characterindex;
						infodata.ShipIndex = shipindex;
						infodata.ShipLevel = shiplevel;
						infodata.LoseCount = losecount;
						infodata.WinCount = wincount;
						infodata.Rank = rank;
						
						
						PVPDataManager.Instance.m_FriendRankList.Add(infodata);
						
						//Debug.Log("ARMDATA: " + armdata.ToString());
						//Debug.Log("hmm: " + recommenduserindex + " subship: " + recommendsubshiplevel[0].AsInt);
					}
					
					PVPDataManager.Instance.m_RewardList.Clear();
					JSONNode rewardlist = root["RewardNotice"];
					for(int i = 0; i < rewardlist.Count; i++)
					{
						JSONNode rewarddata = rewardlist[i];
						PVPRewardData data = new PVPRewardData();
						data.ImageIndex = rewarddata["image_index"].AsInt;
						data.WinCount = rewarddata["win_count"].AsInt;
						data.WinColor = rewarddata["color_code"];
						data.RewardString = rewarddata["reward_string"];
						PVPDataManager.Instance.m_RewardList.Add(data);
					}
					
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_OK, strExtendJson);
					}
					
				} else {
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_Extend, "");
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if(clsReturn.error_msg == Constant.NETWORK_RESULTCODE_Error_UserSequence_Message)
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_UserSequence, "");
					}
				}else
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
					}
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_PVP != null) {
				_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
	}

	/// <summary>
	/// 0 - attack
	/// 1 - defend
	/// </summary>
	public void PVP_Request_History(int _mode, int _maxstage)
	{
		StartCoroutine(IEPVP_Request_History(_mode, _maxstage));
	}
	// 유저 데이터 통신 (user_data.php) - SaveUserData.
	protected IEnumerator IEPVP_Request_History(int _mode, int _maxstage) 
	{
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);

		Dictionary<string, string> bodydic = new Dictionary<string, string>();
		bodydic.Add("Mode", (_mode == 0 ? "\"A\"" : "\"D\""));
		bodydic.Add("MaxStage", _maxstage.ToString());
		string body = TextManager.CreateJsonData(bodydic);
		//Debug.Log("body: " + body);
		string extend = "";
		
		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		//서버에 저장.
		string sendMode = Constant.NETWORK_SENDMODE_PVPHistory;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_PvpInfo;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_PvpInfo;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				//Debug.Log("mark");
				string returndata = clsReturn.data;
				string strExtendJson = clsReturn.extend;
				
				if (returndata != null && !returndata.Equals("")) {
					
					//JSONNode extendroot = JSON.Parse(strExtendJson);
					//string receiveServerTime = extendroot ["ServerTime"];
					//int serverTime = int.Parse(receiveServerTime);

					if(_mode == 0)
					{
						PVPDataManager.Instance.m_HistoryAttackList.Clear();
					}else
					{
						PVPDataManager.Instance.m_HistoryDefendList.Clear();
					}

					JSONNode root = JSON.Parse(returndata);			
					
					JSONNode friendlist = root["BattleList"];
					//Debug.Log("TOTAL FRIEND SEARCH COUNT: " + friendlist.Count);
					
					for(int friendindexno = 0; friendindexno < friendlist.Count; friendindexno++)
					{
						JSONNode userdata = friendlist[friendindexno];
						//Debug.Log("TOTAL: " + userdata.ToString());
						
						int userindex = userdata["pvp_user_index"].AsInt;
						string nickname = userdata["nickname"];
						int battlecount = userdata["battle_count"].AsInt;
						int wincount = userdata["win_count"].AsInt;
						int losecount = userdata["lose_count"].AsInt;
						JSONNode armdata = userdata["armed_data"];
						int characterindex = armdata["CharacterIndex"].AsInt;
						int tacticindex = armdata["TacticIndex"].AsInt;
						int shipindex = armdata["ShipIndex"].AsInt;
						int shiplevel = armdata["ShipLevel"].AsInt;
						JSONArray subshipindex = armdata["SubShipIndexList"].AsArray;
						JSONArray subshiplevel = armdata["SubShipLeveList"].AsArray;
						int reward = userdata["winning_reward"].AsInt;
						int repairsec = userdata["sec_under_repair"].AsInt;
						
						UserInfoData infodata = new UserInfoData();
						infodata.UserIndex = userindex;
						infodata.UserNickName = nickname;
						infodata.CharacterIndex = characterindex;
						infodata.TacticIndex = tacticindex;
						infodata.ShipIndex = shipindex;
						infodata.ShipLevel = shiplevel;
						int[] subshipindexlist = new int[]{0,0,0,0};
						int[] subshiplevellist = new int[]{0,0,0,0};
						for(int j = 0; j < subshipindexlist.Length; j++)
						{
							if(subshipindex.Count > j)
							{
								subshipindexlist[j] = subshipindex[j].AsInt;
							}
						}
						for(int j = 0; j < subshiplevellist.Length; j++)
						{
							if(subshiplevel.Count > j)
							{
								subshiplevellist[j] = subshiplevel[j].AsInt;
							}
						}
						infodata.SubShipIndexList = subshipindexlist;
						infodata.SubShipLevelList = subshiplevellist;

						infodata.RewardAmount = reward;
						infodata.RepairSecond = repairsec;
						//Debug.Log("REARD: " +infodata.RewardAmount + " COME: " + reward);
						UserHistoryData historydata = new UserHistoryData();
						historydata.m_UserInfoData = infodata;
						historydata.PastSecond = userdata["psec"].AsInt;
						historydata.Win = userdata["Win"].AsBool;
						if(_mode == 0)
						{
							historydata.AttackHistory = true;
							PVPDataManager.Instance.m_HistoryAttackList.Add(historydata);
						}else
						{
							historydata.AttackHistory = false;
							PVPDataManager.Instance.m_HistoryDefendList.Add(historydata);
						}
						
						//Debug.Log("ARMDATA: " + armdata.ToString());
						//Debug.Log("hmm: " + recommenduserindex + " subship: " + recommendsubshiplevel[0].AsInt);
					}
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_OK, strExtendJson);
					}
					
				} else {
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_Extend, "");
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if(clsReturn.error_msg == Constant.NETWORK_RESULTCODE_Error_UserSequence_Message)
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_UserSequence, "");
					}
				}else
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
					}
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_PVP != null) {
				_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
	}


	/// <summary>
	/// 0 - attack
	/// 1 - defend
	/// </summary>
	public void PVP_Request_Popup()
	{
		StartCoroutine(IEPVP_Request_Popup());
	}
	// 유저 데이터 통신 (user_data.php) - SaveUserData.
	protected IEnumerator IEPVP_Request_Popup() 
	{
		
		msgHeader.Ct = Managers.UserData.GetSyncServerTime();
		string header = JsonMapper.ToJson(msgHeader);

		string body = "";
		//Debug.Log("body: " + body);
		string extend = "";
		
		string check = getParameterCheckSum(header + body + extend);   //checksum 코드 생성...
		
		yield return null;
		
		//서버에 저장.
		string sendMode = Constant.NETWORK_SENDMODE_PVPPopup;
		addMessageBuffer("REQUEST MODE : " + sendMode);
		addMessageBuffer("REQUEST HEADER : " + header);
		addMessageBuffer("REQUEST BODY : " + body);
		addMessageBuffer("REQUEST EXTEND : " + extend);
		
		WWWForm form = new WWWForm();
		form.AddField("mode", sendMode);
		form.AddField("head", header);
		form.AddField("body", body);
		form.AddField("extend", extend);
		form.AddField("check", check);
		
		if (Constant.PROJECTMODE_Develop) {
			
			m_strURL = Constant.URL_DEVELOP_PvpInfo;
			
		} else {
			
			m_strURL = Constant.URL_RELEASE_PvpInfo;
		}
		
		WWW www = new WWW(m_strURL, form);
		yield return www;
		
		//Debug.Log ("ST200k DataStreamManager SaveUserData sendMode = " + sendMode);
		//Debug.Log ("ST200k DataStreamManager SaveUserData header = " + header);
		//Debug.Log ("ST200k DataStreamManager SaveUserData body = " + body);
		//Debug.Log ("ST200k DataStreamManager SaveUserData extend = " + extend);
		//Debug.Log ("ST200k DataStreamManager SaveUserData check = " + check);
		//Debug.Log ("ST200k DataStreamManager SaveUserData www.text = " + www.text);
		
		if (www.error == null) {
			
			clsReturn.init();  //초기화..
			clsReturn = JsonMapper.ToObject<ClsReturn>(www.text);
			
			//리턴 오브젝트..
			if (clsReturn.result == true) {
				//Debug.Log("mark");
				string returndata = clsReturn.data;
				string strExtendJson = clsReturn.extend;
				
				if (returndata != null && !returndata.Equals("")) {

					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_OK, returndata);
					}
					
				} else {
					
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_Extend, "");
					}
				}
				
			} else if (clsReturn.result == false) {
				
				if(clsReturn.error_msg == Constant.NETWORK_RESULTCODE_Error_UserSequence_Message)
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_UserSequence, "");
					}
				}else
				{
					if (_delegate_DataStreamManager_PVP != null) {
						_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Result_False, "");
					}
				}
			}
			
		} else {
			
			addMessageBuffer("RESPONSE ERROR: " + www.error);
			
			if (_delegate_DataStreamManager_PVP != null) {
				_delegate_DataStreamManager_PVP(Constant.NETWORK_RESULTCODE_Error_Network, "");
			}
		}
		
		www.Dispose();
		www = null;
	}
#endregion
	
}
