
using UnityEngine;
using System.Collections;
using System;
using SimpleJSON;

public class NativeHelper_Afreeca : MonoBehaviour {
	
	[HideInInspector]
	public delegate void AfreecaTVConnectCompleteDelegate(string returnAction);
	protected AfreecaTVConnectCompleteDelegate _afreecaTVConnectCompleteDelegate ;
	public event AfreecaTVConnectCompleteDelegate AfreecaTVConnectCompleteEvent {
		add{
			_afreecaTVConnectCompleteDelegate = null ;
			if (_afreecaTVConnectCompleteDelegate == null) {
        		_afreecaTVConnectCompleteDelegate += value;
			}
        }
		remove{
            _afreecaTVConnectCompleteDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void AfreecaTVConnectErrorDelegate(string returnAction, int errorCode, string errorMessage);
	protected AfreecaTVConnectErrorDelegate _afreecaTVConnectErrorDelegate ;
	public event AfreecaTVConnectErrorDelegate AfreecaTVConnectErrorEvent {
		add{
			_afreecaTVConnectErrorDelegate = null ;
			if (_afreecaTVConnectErrorDelegate == null) {
        		_afreecaTVConnectErrorDelegate += value;
			}
        }
		remove{
            _afreecaTVConnectErrorDelegate -= value;
		}
	}
	

	//-------------- Configuration ------------------
	static readonly bool AFREECA_TEST_MODE = false;	//real => false
	static readonly string AFREECA_CLIENT_ID = "marinestrike355586bfb8ffc7a79e52d833cedce4d275bf";
	static readonly string AFREECA_SECRET_KEY = "ZWYwZGM3NWRlNzYwYjE0MWVkOGFjYjNlODAwMmZiNGUwZDZhYjQ0YzEwOGNmNTBhMDBmZjAzNzY2Y2I5NjdlZg==";
	//-----------------------------------------------


	/*
	//-------------- Configuration Test Server ------------------
	static readonly bool AFREECA_TEST_MODE = true ;	//real => false
	static readonly string AFREECA_CLIENT_ID = "marinestrike3555b68fd63ca41d49bfc1b18251202c053f";
	static readonly string AFREECA_SECRET_KEY = "NTU4M2M3NzI1Y2Y2NzI2MThmNzA4NDllZDhjMDllM2Q0MmRkNjQxNzg4MmQ0YTEwZmUwYzNlMjAwMWIxYjMzMg==";
	//-------------- Configuration Test Server ------------------
	*/
	
	public bool isUserLogin;	//로그인 되어 있느지 여부..

	//Request parameter 관련 변수..
	public string 	paramReceiverId;
	public string 	paramMessage;
	public string 	paramMessageType;
	public int 		paramPageNumber;
	public int 		paramPageLimit;
	public string 	paramMarketType;
	public float 	paramPrice;
	public string 	paramCurrency;

	static NativeHelper_Afreeca _instance;
	public static NativeHelper_Afreeca Instance
    {
        get
        {
            if (_instance == null)
            {
				_instance = FindObjectOfType(typeof(NativeHelper_Afreeca)) as NativeHelper_Afreeca;
                if (_instance == null)
                {
					_instance = new GameObject("NativeHelper_Afreeca").AddComponent<NativeHelper_Afreeca>();

                }
            }
			
			//Debug.Log("AAA _instance.name=" + _instance.name);
            return _instance;
        }
    }
	
#if UNITY_ANDROID
	public AndroidJavaObject activity;
#endif
	
    void Awake()
    {
		//manager = new SampleManager();	//연결하려는 매니저로 수정..
		
		DontDestroyOnLoad(this);
		isUserLogin = false;
		
		paramReceiverId = "";
		paramMessage = "";
		paramMessageType = "";
		paramPageNumber = 0;
		paramPageLimit = 0;
		paramMarketType = "";
		paramPrice = 0;
		paramCurrency = "";
		
		
#if UNITY_EDITOR
		//Debug.Log("NativeHelper_Afreeca : UNITY_EDITOR");
#elif UNITY_ANDROID
		//Debug.Log("AAA NativeHelper_Afreeca : UNITY_ANDROID");
		//AndroidJNI.AttachCurrentThread();
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
#elif UNITY_IPHONE
		//Debug.Log("NativeHelper_Afreeca : UNITY_IPHONE");
#endif
		
		
    }
	

	//-----------------------------------------------------------------------
	// Action Request
	//-----------------------------------------------------------------------
	public void Request(string command){
		string json_param = null;
		
		if(command.Equals("Init")){
			//json_param = "{\"action\":\"Init\", \"clientid\":\""+AFREECA_CLIENT_ID+"\", \"secretkey\":\""+AFREECA_SECRET_KEY+"\", \"testmode\":"+AFREECA_TEST_MODE+"}";
			json_param = "{\"action\":\"Init\", \"clientid\":\""+AFREECA_CLIENT_ID+"\", \"secretkey\":\""+AFREECA_SECRET_KEY+"\", \"testmode\":"+AFREECA_TEST_MODE.ToString().ToLower()+"}";	//edit 20131113

		} else if(command.Equals("Authorize")){
			json_param = "{\"action\":\"Authorize\"}";
		
		} else if(command.Equals("UnAuthorize")){
			json_param = "{\"action\":\"UnAuthorize\"}";
		
		} else if(command.Equals("UnRegister")){
			json_param = "{\"action\":\"UnRegister\"}";
		
		} else if(command.Equals("SendMessage")){
			json_param = "{\"action\":\"SendMessage\", \"receiverId\":\""+ _instance.paramReceiverId +"\", \"message\":\""+ _instance.paramMessage +"\" }";
		
		} else if(command.Equals("SendGroupMessage")){
			json_param = "{\"action\":\"SendGroupMessage\", \"message\":\""+ _instance.paramMessage +"\", \"messageType\":\""+ _instance.paramMessageType +"\" }";
		
		} else if(command.Equals("GetUserInfo")){
			json_param = "{\"action\":\"GetUserInfo\"}";
		
		} else if(command.Equals("GetClanRanking")){
			json_param = "{\"action\":\"GetClanRanking\", \"pageNumber\":"+ _instance.paramPageNumber +", \"pageLimit\":"+ _instance.paramPageLimit +" }";
		
		} else if(command.Equals("GetTopRanking")){
			json_param = "{\"action\":\"GetTopRanking\", \"pageNumber\":"+ _instance.paramPageNumber +", \"pageLimit\":"+ _instance.paramPageLimit +" }";
		
		} else if(command.Equals("SetClan")){
			json_param = "{\"action\":\"SetClan\"}";
		
		} else if(command.Equals("SendPaymentInfo")){
			//google, apple. tstore, olleh, uplus, danal
			//KRW, JPY, USD
			json_param = "{\"action\":\"SendPaymentInfo\", \"marketType\":\""+ _instance.paramMarketType +"\", \"price\":"+ _instance.paramPrice +", \"currency\":\""+ _instance.paramCurrency +"\" }";
		
		}
		
		
		
		//Debug.Log("*******AAA : AfreecaActionCall : " + json_param);
		if(json_param != null){
#if UNITY_ANDROID
			activity.Call("afreecaCommand", json_param);
#elif UNITY_IPHONE
			PlayerPrefs.SetString("afreecaUnityExtension",json_param);
#endif
		}
		
	}
	
	//-----------------------------------------------------------------------
	// Call from native 
	//-----------------------------------------------------------------------
	private void onResponseComplete(String response){
		//Debug.Log("*******AAA : onResponseComplete : " + response);
		//{ "action":"Init", "resultCode":1, "resultMessage":"RESPONSE OK : 로그인 되어 있음" }
		//{ "action":"Init", "resultCode":0, "resultMessage":"RESPONSE OK : 로그인 되어 있지 않음" }
		//{ "action":"Authorize", "resultCode":200, "resultMessage":"null", "resultMessage":"null" }
		//{ "action":"GetUserInfo", "resultCode":200, "resultMessage":"성공", "resultMessage":{"CLAN_ID":"tonic9932","USER_ID":"jcsim20","CLAN_MASTER_YN":"N","CLAN_REG_DATE":"2013-10-23 18:40:46","CLAN_PROFILE_URL":"","MESSAGE_ALLOW_YN":"Y","PROFILE_URL":"","USER_SCORE":"0","CLAN_NAME":"힝힝홍홍","NICKNAME":"초리00"} }
		//{ "action":"GetClanRanking", "resultCode":200, "resultMessage":"success", "resultMessage":{"MORE_YN":"N","USER_LIST":[{"CLAN_ID":"tonic9932","PROFILE_URL":"","USER_ID":"jcsim20","SCORE":"0","CLAN_PROFILE_URL":"","CLAN_NAME":"힝힝홍홍","NICKNAME":"초리00"}]} }
		//{ "action":"GetTopRanking", "resultCode":200, "resultMessage":"success", "resultMessage":{"MORE_YN":"N","USER_LIST":[]} }
		//{ "action":"SetClan", "resultCode":200, "resultMessage":"클랜이 변경되었습니다", "resultMessage":"null" }
		//{ "action":"SendPaymentInfo", "resultCode":200, "resultMessage":"정상.", "resultMessage":"null" }
		
		JSONNode root = JSON.Parse(response);
		string action = root["action"];
		int resultCode = root["resultCode"].AsInt;
		
		if(action.Equals("Init")){
			if(resultCode == 1)
				_instance.isUserLogin = true;
			else
				_instance.isUserLogin = false;
			
		} else if(action.Equals("Authorize")){
			if(resultCode == 200)
				_instance.isUserLogin = true;
			else{
				_instance.isUserLogin = false;
				
				if(_afreecaTVConnectErrorDelegate != null) {
					_afreecaTVConnectErrorDelegate(action, resultCode, "") ;
				}
				return;
			}
		} else if(action.Equals("UnAuthorize")){
			_instance.isUserLogin = false;
		} else if(action.Equals("UnRegister")){
			_instance.isUserLogin = false;
		} else if(action.Equals("SendMessage")){
			
		} else if(action.Equals("SendGroupMessage")){
			
		} else if(action.Equals("GetUserInfo")){
			_instance.isUserLogin = true ; // 2014-01-06 V5....
			AfreecaTvData.Instance.setUserInfo(root["resultData"]);
		} else if(action.Equals("GetClanRanking")){
			AfreecaTvData.Instance.setClanRanking(root["resultData"], _instance.paramPageNumber);
		} else if(action.Equals("GetTopRanking")){
			AfreecaTvData.Instance.setTopRanking(root["resultData"], _instance.paramPageNumber);
		} else if(action.Equals("SetClan")){
			_instance.isUserLogin = false;
		} else if(action.Equals("SendPaymentInfo")){
			
		}
		
		if(_afreecaTVConnectCompleteDelegate != null){
			_afreecaTVConnectCompleteDelegate(action) ;	
		}
		
	}
	
	private void onResponseError(String response){
		//Debug.Log("*******AAA : onResponseError : " + response);
		//{ "action":"Authorize", "errorCode":10002, "errorMessage":"null" }
		//{ "action":"SendMessage", "errorCode":611, "errorMessage":"메시지를 수신할 유저가 없습니다." }
		//{ "action":"SendGroupMessage", "errorCode":10001, "errorMessage":"" }
		//{ "action":"SetClan", "errorCode":10002, "errorMessage":"null" }
		//{ "action":"SendPaymentInfo", "errorCode":620, "errorMessage":"구매 플랫폼 값이 없습니다." }
		//{ "action":"GetUserInfo", "errorCode":900, "errorMessage":"ACEESTOKEN이 유효하지 않습니다." }

		
		JSONNode root = JSON.Parse(response);
		string action = root["action"];
		int errorCode = root["errorCode"].AsInt;
		string errorMessage = root["errorMessage"];
		
		if(_afreecaTVConnectErrorDelegate != null) {
			_afreecaTVConnectErrorDelegate(action, errorCode, errorMessage) ;
		}
		
	}


	//---- CRC Check...

	[HideInInspector]
	public delegate void ClientTimeDelegate(string clientTime);
	protected ClientTimeDelegate _clientTimeDelegate ;
	public event ClientTimeDelegate ClientTimeEvent {
		add{
			_clientTimeDelegate = null ;
			
			if (_clientTimeDelegate == null) {
				_clientTimeDelegate += value;
			}
		}
		
		remove{
			_clientTimeDelegate -= value;
		}
	}

	private void getClientTimeCallBack(String clientTime){
		if(_clientTimeDelegate != null){
			_clientTimeDelegate(clientTime) ;
		}
	}
	
	
	public void GetClientTime(){
#if UNITY_EDITOR
		if(_clientTimeDelegate != null){
			_clientTimeDelegate("editorClientTime") ;
		}
#elif UNITY_ANDROID
		activity.Call("clientTime");
#elif UNITY_IPHONE
		if(_clientTimeDelegate != null){
			_clientTimeDelegate("iphoneClientTime") ;
		}
#endif
	}

}
