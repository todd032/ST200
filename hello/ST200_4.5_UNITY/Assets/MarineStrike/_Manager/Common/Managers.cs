using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
using Prime31;

[RequireComponent (typeof(UserDataManager))]
[RequireComponent (typeof(GameBalanceDataManager))]
[RequireComponent (typeof(GameMissionDataManager))]
[RequireComponent (typeof(AudioManager))]

public class Managers : MonoBehaviour
{
	
	private static UserDataManager userDataManager;
	public static UserDataManager UserData {
		get { return userDataManager; }
	}
	
	private static GameBalanceDataManager gameBalanceDataManager;
	public static GameBalanceDataManager GameBalanceData {
		get { return gameBalanceDataManager; }
	}
	
	private static GameMissionDataManager gameMissionDataManager;
	public static GameMissionDataManager GameMissionData {
		get { return gameMissionDataManager; }
	}
	
	private static AudioManager audioManager;
	public static AudioManager Audio{
		get { return audioManager; }
	}
	
	private static DataStreamManager _dataStreamManager;
	public static DataStreamManager DataStream{
		get { return _dataStreamManager; }
	}
	
	private static PaymentManager _paymentManager;
	public static PaymentManager Payment{
		get { return _paymentManager; }
	}
	
	private static TorpedoManager _torpedoManager;
	public static TorpedoManager Torpedo{
		get { return _torpedoManager; }
	}

	private static TstoreAndroidBridgeManager _tstoreAndroidBridgeManager;
	public static TstoreAndroidBridgeManager TstoreAndroidBridge {
		get { return _tstoreAndroidBridgeManager; }
	}

	//private static KakaoManager	kakaoManager;
	//public static KakaoManager KaKao {
	//	get {return kakaoManager; }
	//}
	//
	//private static KaKaoManagerDelegate	kaKaoManagerDelegate;
	//public static KaKaoManagerDelegate KaKaoManagerDelegate {
	//	get {return kaKaoManagerDelegate; }
	//}

	// 네이버 인앱 추가 (by 최원석 in 14.06.11) - Start ==========
	private static NaverAndroidBridgeManager _naverAndroidBridgeManager;
	public static NaverAndroidBridgeManager NaverAndroidBridge {
		get { return _naverAndroidBridgeManager; }
	}
	// 네이버 인앱 추가 (by 최원석 in 14.06.11) - End ==========

	
	//android gcm sender id
	private string[] SENDER_IDS = {"188643008643"};
	

	private void Awake () {

		//Debug.Log("ST110 Managers.Awake() Run!!!");

		Application.targetFrameRate = 60 ;
		
		//Screen.SetResolution(Screen.width, Screen.width/16*9, false) ;
		
		userDataManager = GetComponent<UserDataManager>() as UserDataManager;
		gameBalanceDataManager = GetComponent<GameBalanceDataManager>() as GameBalanceDataManager;
		gameMissionDataManager = GetComponent<GameMissionDataManager>() as GameMissionDataManager ;
		//kakaoManager = GetComponent<KakaoManager>() as KakaoManager;
		//kaKaoManagerDelegate = GetComponent<KaKaoManagerDelegate>() as KaKaoManagerDelegate;

		_dataStreamManager = GetComponent<DataStreamManager>() as DataStreamManager ;
		
		_paymentManager = GetComponent<PaymentManager>() as PaymentManager ;
		
		audioManager = GetComponent<AudioManager>() as AudioManager;	
		
		_torpedoManager = GetComponent<TorpedoManager>() as TorpedoManager;	


		//TStore...
		if (Constant.CURRENT_MARKET.Equals("3")){
			_tstoreAndroidBridgeManager = gameObject.AddComponent<TstoreAndroidBridgeManager>() as TstoreAndroidBridgeManager;
		}
		//TStore...

		// 네이버 인앱 추가 (by 최원석 in 14.06.11) - Start ==========
		if (Constant.CURRENT_MARKET.Equals("4")){
			_naverAndroidBridgeManager = gameObject.AddComponent<NaverAndroidBridgeManager>() as NaverAndroidBridgeManager;
		}
		// 네이버 인앱 추가 (by 최원석 in 14.06.11) - End ==========


		//Make this game object persistant
		DontDestroyOnLoad(gameObject);
		
	}
	
	private void Start(){

		//Debug.Log("ST110 Managers.Start() Run!!!");

		#if UNITY_IPHONE && !UNITY_EDITOR
		NotificationServices.RegisterForRemoteNotificationTypes(RemoteNotificationType.Alert | 
		                                                        RemoteNotificationType.Badge | 
		                                                        RemoteNotificationType.Sound);

		#elif UNITY_ANDROID && !UNITY_EDITOR

		GCM.Initialize ();
		
		// Set callbacks
		GCM.SetErrorCallback ((string errorId) => {
			//			Debug.Log ("Error!!! " + errorId);
			//			GCM.ShowToast ("Error!!!");
			//			_text = "Error: " + errorId;
		});
		
		GCM.SetMessageCallback ((Dictionary<string, object> table) => {
			//			Debug.Log (" push gcm Message!!!");
			//			GCM.ShowToast ("Message!!!");
			//			_text = "Message: " + System.Environment.NewLine;
			//			foreach (var key in  table.Keys) {
			//				_text += key + "=" + table[key] + System.Environment.NewLine;
			//			}
		});
		
		GCM.SetRegisteredCallback ((string registrationId) => {
			//			Debug.Log (" push gcm Registered!!! " + registrationId);
			//			GCM.ShowToast ("Registered!!!");
			//			_text = "Register: " + registrationId; 
		});
		
		GCM.SetUnregisteredCallback ((string registrationId) => {
			//			Debug.Log (" push gcm Unregistered!!! " + registrationId);
			//			GCM.ShowToast ("Unregistered!!!");
			//			_text = "Unregister: " + registrationId;
		});
		
		GCM.SetDeleteMessagesCallback ((int total) => {
			//			Debug.Log (" push gcm DeleteMessages!!! " + total);
			//			GCM.ShowToast ("DeleteMessaged!!!");
			//			_text = "DeleteMessages: " + total;
		});
		
		GCM.Register (SENDER_IDS);

		#endif

	}

}

