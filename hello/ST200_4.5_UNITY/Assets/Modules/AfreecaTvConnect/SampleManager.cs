using UnityEngine;
using System.Collections;

public class SampleManager : MonoBehaviour {

	private Rect rectBtn1, rectBtn2, rectBtn3, rectBtn4, rectBtn5, rectBtn6, rectBtn7, rectBtn8, rectBtn9, rectBtn10, rectBtn11, rectBtn12;	//test
	
	
	
	// Use this for initialization
	void Start () {
		Application.runInBackground = true;
	
		// test
		rectBtn1 = new Rect(Screen.width-200, 10,  200, 100);
		rectBtn2 = new Rect(Screen.width-200, 110, 200, 100);
		rectBtn3 = new Rect(Screen.width-200, 210, 200, 100);
		rectBtn4 = new Rect(Screen.width-200, 310, 200, 100);
		rectBtn5 = new Rect(Screen.width-200, 410, 200, 100);
		rectBtn6 = new Rect(Screen.width-200, 510, 200, 100);
		rectBtn7 = new Rect(Screen.width-400, 10, 200, 100);
		rectBtn8 = new Rect(Screen.width-400, 110, 200, 100);
		rectBtn9 = new Rect(Screen.width-400, 210, 200, 100);
		rectBtn10 = new Rect(Screen.width-400, 310, 200, 100);
		rectBtn11 = new Rect(Screen.width-400, 410, 200, 100);
		rectBtn12 = new Rect(Screen.width-400, 510, 200, 100);
		
		
		// Initialize 처음에 꼭 호출해줘야 함...
		if(isUserLogin() == false){
			NativeHelper_Afreeca.Instance.Request("Init");
		}
		
	}
	
	
	// test  aaa
	void OnGUI(){
		
		if(GUI.Button(rectBtn1, "Authorize")){
			NativeHelper_Afreeca.Instance.Request("Authorize");
		}
		if(GUI.Button(rectBtn2, "UnAuthorize")){
			NativeHelper_Afreeca.Instance.Request("UnAuthorize");
		}
		if(GUI.Button(rectBtn3, "UnRegister")){
			NativeHelper_Afreeca.Instance.Request("UnRegister");
		}
		if(GUI.Button(rectBtn4, "SendMessage")){
			NativeHelper_Afreeca.Instance.paramReceiverId = "jcsim20";
			NativeHelper_Afreeca.Instance.paramMessage = "1:1초대 메시지..";
			NativeHelper_Afreeca.Instance.Request("SendMessage");
		}
		if(GUI.Button(rectBtn6, "SendGroupMessage-invite")){
			NativeHelper_Afreeca.Instance.paramMessage = "그룹 초대 메시지..";
			NativeHelper_Afreeca.Instance.paramMessageType = "invite";	//초대 메시지의 경우..
			NativeHelper_Afreeca.Instance.Request("SendGroupMessage");
		}
		if(GUI.Button(rectBtn7, "SendGroupMessage-gift")){
			NativeHelper_Afreeca.Instance.paramMessage = "그룹 선물 메시지..";
			NativeHelper_Afreeca.Instance.paramMessageType = "gift";	//선물 메시지의 경우..
			NativeHelper_Afreeca.Instance.Request("SendGroupMessage");
		}
		if(GUI.Button(rectBtn8, "GetUserInfo")){
			NativeHelper_Afreeca.Instance.Request("GetUserInfo");
		}
		if(GUI.Button(rectBtn9, "GetClanRanking")){
			NativeHelper_Afreeca.Instance.paramPageNumber = 1;
			NativeHelper_Afreeca.Instance.paramPageLimit = 10;
			NativeHelper_Afreeca.Instance.Request("GetClanRanking");
		}
		if(GUI.Button(rectBtn10, "GetTopRanking")){
			NativeHelper_Afreeca.Instance.paramPageNumber = 1;
			NativeHelper_Afreeca.Instance.paramPageLimit = 10;
			NativeHelper_Afreeca.Instance.Request("GetTopRanking");
		}
		if(GUI.Button(rectBtn11, "SetClan")){
			NativeHelper_Afreeca.Instance.Request("SetClan");
		}
		if(GUI.Button(rectBtn12, "SendPaymentInfo")){
			//google, apple. tstore, olleh, uplus, danal
			//KRW, JPY, USD
			NativeHelper_Afreeca.Instance.paramMarketType = "google";
			NativeHelper_Afreeca.Instance.paramPrice = 0.99f;
			NativeHelper_Afreeca.Instance.paramCurrency = "KRW";
			NativeHelper_Afreeca.Instance.Request("SendPaymentInfo");
		}

	}
	


	
	//--------------------------------------------------------------
	
	//로그인 상태..
	public bool isUserLogin(){
		return NativeHelper_Afreeca.Instance.isUserLogin;
	}
	
	
	
	// 액션 콜백 성공 (콜백 처리 참고)
	public void AfreecaCallBackComplete(string action){
		//Debug.Log("******AAA******* AfreecaCallBackComplete() : action="+action);
		if(action.Equals("Init")){
			if(isUserLogin()){
				//로그인 되어 있으면 유저정보 호출..
				NativeHelper_Afreeca.Instance.Request("GetUserInfo");
			} else {
				//로그인 되어 있지 않으면 로그인 버튼출력..
			}
		} else if(action.Equals("Authorize")){
				//로그인 성공.. 유저정보 호출..
				NativeHelper_Afreeca.Instance.Request("GetUserInfo");
		} else if(action.Equals("UnAuthorize")){
				//로그아웃 처리..
		} else if(action.Equals("UnRegister")){
				//탈퇴 처리.. 우리 서버에 탈퇴 인터페이스 호출..
		} else if(action.Equals("SendMessage")){
				//1:1 메시지 전송 완료 팝업..
		} else if(action.Equals("SendGroupMessage")){
				//그룹 초대 또는 선물 완료 팝업..
		} else if(action.Equals("GetUserInfo")){
				//AfreecaTvData참조하여 유저정보 보여주기..
		} else if(action.Equals("GetClanRanking")){
				//AfreecaTvData참조하여 클랜랭킹 보여주기..
		} else if(action.Equals("GetTopRanking")){
				//AfreecaTvData참조하여 탑유저랭킹 보여주기..
		} else if(action.Equals("SetClan")){
				//클랜변경 호출 후 완료됨.. 
		} else if(action.Equals("SendPaymentInfo")){
				//탈퇴 처리.. 우리 서버에 탈퇴 인터페이스 호출..
		}
		
		
	}
	
	// 액션 콜백 에러
	public void AfreecaCallBackError(string action, int errorCode, string errorMessage){
		//Debug.Log("******AAA******* AfreecaCallBackError() : action="+action+", errorMessage="+errorMessage);
		//액션별 에러 처리.. errorMessage를 필요에 따라 팝업 출력..
		

		//{ "action":"GetUserInfo", "errorCode":900, "errorMessage":"ACEESTOKEN이 유효하지 않습니다." }
		if(action.Equals("GetUserInfo")){
			//로그인 되어 있다고 하더라도.. 오류 발생시 다시 로그인 해야 함..
			//로그인 화면으로 이동.
		}
		
	}
	
	
}
