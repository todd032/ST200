using UnityEngine;
using System.Collections;

public class NaverAndroidBridgeManager : MonoBehaviour {

	// ==================== Delegate 선언 - Start ====================
	[HideInInspector]
	public delegate void Delegate_NaverAndroidBridgeManager(bool boolSuccess_Input); 
	protected Delegate_NaverAndroidBridgeManager _delegate_NaverAndroidBridgeManager;
	public event Delegate_NaverAndroidBridgeManager EventDelegate_NaverAndroidBridgeManager {
		add{
			_delegate_NaverAndroidBridgeManager = null ;
			if (_delegate_NaverAndroidBridgeManager == null)
				_delegate_NaverAndroidBridgeManager += value;
		}
		remove{
			_delegate_NaverAndroidBridgeManager -= value;
		}
	}
	// ==================== Delegate 선언 - End ====================

	// ==================== 전역 변수 선언 - Start ====================
#if UNITY_ANDROID
	AndroidJavaObject m_androidJavaObject= null;
#endif
	// ==================== 전역 변수 선언 - End ====================

	void Awake() {
		#if UNITY_ANDROID
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		m_androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
#endif
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void NaverInApp_requestPayment(string strInAppCode_Input, int intInAppPrice_Input, string strInAppExtra_Input) {	

		Debug.Log ("ST110 NaverAndroidBridgeManager.NaverInApp_requestPayment.strInAppCode_Input = " + strInAppCode_Input);
		Debug.Log ("ST110 NaverAndroidBridgeManager.NaverInApp_requestPayment.intInAppPrice_Input = " + intInAppPrice_Input.ToString());
		Debug.Log ("ST110 NaverAndroidBridgeManager.NaverInApp_requestPayment.strInAppExtra_Input = " + strInAppExtra_Input);
		#if UNITY_ANDROID
		if (m_androidJavaObject != null) {

			m_androidJavaObject.Call("naverInApp_CallAction_RequestPayment", strInAppCode_Input, intInAppPrice_Input, strInAppExtra_Input);
		}
#endif
	}

	public void NaverInApp_PurchaseComplete(string strParam_Input) {

		Debug.Log ("ST110 NaverAndroidBridgeManager.NaverInApp_PurchaseComplete.strParam_Input = " + strParam_Input);

		Managers.DataStream.Event_Delegate_DataStreamManager_SaveChargeData_Naver += (intNetworkResultCode_Input, strNetworkResultData_Input) => {

			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){

				if (_delegate_NaverAndroidBridgeManager != null){
					_delegate_NaverAndroidBridgeManager(true);
				}

			} else {

				if (_delegate_NaverAndroidBridgeManager != null){
					_delegate_NaverAndroidBridgeManager(false);
				}
			}

			Managers.DataStream.Event_Delegate_DataStreamManager_SaveChargeData_Naver += null;
		};

		StartCoroutine(Managers.DataStream.Network_SaveChargeData_Naver(strParam_Input)) ;

	}

	public void NaverInApp_PurchaseError(string strParam_Input) {

		Debug.Log ("ST110 NaverAndroidBridgeManager.NaverInApp_PurchaseError.strParam_Input = " + strParam_Input);

		if (_delegate_NaverAndroidBridgeManager != null){
			_delegate_NaverAndroidBridgeManager(false);
		}

	}



}
