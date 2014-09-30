using UnityEngine;
using System.Collections;

public class TstoreAndroidBridgeManager : MonoBehaviour {

//#if UNITY_EDITOR

//#elif UNITY_ANDROID


	// ==================== Delegate 선언 - Start ====================
#if UNITY_ANDROID
	[HideInInspector]
	public delegate void TstoreAndroidBridgeManagerOkDelegate(string returnProductIdentifier); 
	protected TstoreAndroidBridgeManagerOkDelegate _TstoreAndroidBridgeManagerOkDelegate ;
	public event TstoreAndroidBridgeManagerOkDelegate TstoreAndroidBridgeManagerOkEvent {
		add{
			
			_TstoreAndroidBridgeManagerOkDelegate = null ;
			
			if (_TstoreAndroidBridgeManagerOkDelegate == null)
				_TstoreAndroidBridgeManagerOkDelegate += value;
		}
		
		remove{
			_TstoreAndroidBridgeManagerOkDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void TstoreAndroidBridgeManagerErrorDelegate(string errorMessage, int state); 
	protected TstoreAndroidBridgeManagerErrorDelegate _TstoreAndroidBridgeManagerErrorDelegate ;
	public event TstoreAndroidBridgeManagerErrorDelegate TstoreAndroidBridgeManagerErrorEvent {
		add{
			
			_TstoreAndroidBridgeManagerErrorDelegate = null ;
			
			if (_TstoreAndroidBridgeManagerErrorDelegate == null)
				_TstoreAndroidBridgeManagerErrorDelegate += value;
		}
		
		remove{
			_TstoreAndroidBridgeManagerErrorDelegate -= value;
		}
	}

	// ==================== Delegate 선언 - End ====================

	// ==================== 전역 변수 선언 - Start ====================
	AndroidJavaObject AndroidPlugin= null;
	private readonly string INAPP_AppID = "OA00663816"; // T store에 등록한 게임 ID.

	// ==================== 전역 변수 선언 - End ====================

	// ==================== Override 함수 - Start ====================
	// Use this for initialization
	private void Start () {

#if UNITY_ANDROID && !UNITY_EDITOR
		AndroidJNI.AttachCurrentThread();
		Initiate();
#endif
	
	}
	
	// Destroy function
	private void Destroy() {

		if(AndroidPlugin!= null)
			AndroidPlugin.Dispose();

	}
	
	// Update is called once per frame
	private void Update () {

	}

	// ==================== Override 함수 - End ====================

	// 초기화 함수
	private int Initiate() {

		// Unity 3D Player 클래스를 가져온다.
		AndroidJavaClass androidClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		
		if(androidClass != null) {
			AndroidPlugin=androidClass.GetStatic<AndroidJavaObject>("currentActivity");
			androidClass.Dispose();
			
			if(AndroidPlugin== null) {
				return -1;
			}
			
			return 0;
		}
		
		return -1;
	}

	/*
	 * 
		조회 결과 상세 코드 ..
		0000: 정상 ..
		1000: 필수 파라미터 부족 (조회 요청시 TXId, APPID, signdata 중 파라미터가 부족할 때 발생하는 코드 ) ..
		9100: 구매이력 없음 (signdata로 구매한 이력이 없을 경우) ..
		9113: 전자영수증 데이터 유효성 검증 오류 ..
		9114: 전자서명 데이터 생성이 실패. 관리자에게 문의하세요 ...
		9115: 영수증 생성 실패 ..
		9116: 구매된 상품 정보와 일치하지 않는 영수증입니다 ...
		9999: SYSTEM ERROR (시스템 에러는 IAP 내부 오류로써 발생할 경우운영팀에 문의 필요 )..
	**/


/*
In-App Product의 구매를 IAP Server에 요청하는 메소드이다 ..
이 메소드를 통한 요청이 성공하면 모바일 웹 페이지가 열리며 페이지 ..
 내에서 구매 절차를 수행할 수 있다 ..
 요청 메시지 형식은 HTTP Post 파라미터 구 성을 따르며 ..
 응답 메시지는 JSON 포맷을 따른다. 요청/응답 메시지 구성은 다음 절에서 상세하게 설명한 다 ..
**/

	public void PurchaseComplete(string strParam) {

		Debug.Log ("ST110 TstoreAndroidBridgeManager.PurchaseComplete().strParam = " + strParam);

		Managers.DataStream.DataStreamIAPOkManagerEvent += (productIdentifier, state) => {
			if(_TstoreAndroidBridgeManagerOkDelegate != null){
				_TstoreAndroidBridgeManagerOkDelegate(productIdentifier) ;
			}
		};
		
		Managers.DataStream.DataStreamIAPErrorManagerEvent += (sendMode, state) => {
			if(state == 111){
				//3: 데이터가 올바르지 않습니다. 다시 실행해 주세요.
				if(_TstoreAndroidBridgeManagerErrorDelegate != null){
					_TstoreAndroidBridgeManagerErrorDelegate("Error", 3) ; //3: 데이터가 올바르지 않습니다. 다시 실행해 주세요.
				}
			}else if(state == 112){
				//1: 통신이 원활하지 않습니다. 다시 결제해주세요.
				if(_TstoreAndroidBridgeManagerErrorDelegate != null){
					_TstoreAndroidBridgeManagerErrorDelegate("Error", 1) ; //1: 통신이 원활하지 않습니다. 다시 결제해주세요.
				}
			}
		};
		
		// 
		StartCoroutine(Managers.DataStream.SendTstoreValidateReceipt(strParam)) ;
		//

	}

	public void PurchaseError(string strParam) {

		Debug.Log ("ST110 TstoreAndroidBridgeManager.PurchaseError().strParam = " + strParam);

		if(_TstoreAndroidBridgeManagerErrorDelegate != null){
			_TstoreAndroidBridgeManagerErrorDelegate("Error", 1) ; //1: 통신이 원활하지 않습니다. 다시 결제해주세요.    
		}

	}

	
	// 안드로이드 라이브러리의 결제 요청 메소드를 호출한다.
	public int CallPaymentRequest(string strPid_Input) {

		Debug.Log ("ST110 TstoreAndroidBridgeManager.CallPaymentRequest().strPid_Input = " + strPid_Input);

		if(AndroidPlugin!= null) {

			int retCode =  AndroidPlugin.Call<int>("PaymentRequest", INAPP_AppID, strPid_Input);  //String appid, String pid

			Debug.Log ("ST110 TstoreAndroidBridgeManager.CallPaymentRequest().retCode = " + retCode.ToString());

			if(retCode != 0) {

				if(_TstoreAndroidBridgeManagerErrorDelegate != null){
					_TstoreAndroidBridgeManagerErrorDelegate("Error", 4) ; // 결제 모듈 호출을 실패하였습니다.\n게임 종료 후 다시 결제해 주세요.
				}
			}

			return retCode;

		}else { 

			if(_TstoreAndroidBridgeManagerErrorDelegate != null){
				_TstoreAndroidBridgeManagerErrorDelegate("Error", 4) ; // 결제 모듈 호출을 실패하였습니다.\n게임 종료 후 다시 결제해 주세요.
			}
		}

		return 0;
	}
	
	// 안드로이드 라이브러리의 Query 요청 메소드를 호출한다.
	public int CallCommandRequest() {

		if(AndroidPlugin!= null) {

			int retCode = AndroidPlugin.Call<int>("CommandRequest", INAPP_AppID, "0000000000","request_purchase_history",0);
			return retCode;
		}
		
		return 0;
	}

#endif
}



