using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;
using SimpleJSON;

public class NativeHelper : MonoBehaviour {

	//private KakaoManager manager;

	public bool isUserLogin;	//로그인 되어 있느지 여부..	
	
	static NativeHelper _instance;
	public static NativeHelper Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(NativeHelper)) as NativeHelper;
                if (_instance == null)
                {
                    _instance = new GameObject("NativeHelper").AddComponent<NativeHelper>();
                }
				_instance.Init();
            }
			
			// Debug.Log("AAA _instance.name=" + _instance.name);
            return _instance;
        }
    }
	
#if UNITY_ANDROID
	public AndroidJavaObject activity;
#endif
	
    void Awake()
    {
		Init();
    }

	bool m_Init = false;
	void Init()
	{
		if(m_Init)
		{
			return;
		}
		m_Init = true;
		// Debug.Log("ST110 NativeHelper.Awake() Run!!!");
		
		//manager = Managers.KaKao;
		
		DontDestroyOnLoad(this);
		isUserLogin = false; //add jcsim
		#if UNITY_EDITOR
		// Debug.Log("NativeHelper : UNITY_EDITOR");
		#elif UNITY_ANDROID
		// Debug.Log("AAA NativeHelper : UNITY_ANDROID");
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
		#elif UNITY_IPHONE
		// Debug.Log("NativeHelper : UNITY_IPHONE");
		#endif

		GetPushInfoString();
		System.Action<Dictionary<string, object>> messagecallaction = OnMessageCall;
		GCM.SetMessageCallback(messagecallaction);
	}

//	public void Request(eKakaoActionType type) {
//
//		 Debug.Log("ST110 NativeHelper.Request().type = " + type.ToString());
//
//		string[] param = null;
//		
//		if( type==eKakaoActionType.Initialize ) {
//			param = new string[2];
//			param[0] = Common.KAKAO_CLIENT_ID;
//			param[1] = Common.KAKAO_CLIENT_SECRET;
//		}
//		else if( type==eKakaoActionType.SendMessage || type==eKakaoActionType.SendInviteMessage ) {
//			param = new string[2];
//			param[0] = KakaoManager.sendMessageUserId;	//receiver_id
//			param[1] = KakaoManager.sendMessageString;	//message
//		}
//		else if( type==eKakaoActionType.PostStory ) {
//			// for capture
//#if UNITY_IPHONE
//			param = new string[1];
//			param[0] = "game_capture_for_upload.png";
//#else
//			param = new string[2];
//			//param[0] = "com.kakao.example.android.ThirdPartyPostStoryActivity";
//			//param[0] = "com.Company.ProductName.ThirdPartyPostStoryActivity";
//			param[0] = "com.kakao.unity.KakaoAndroidPlugin";
//			
//			//param[1] = "game_capture_for_upload.png";
//			param[1] = Application.persistentDataPath+"/game_capture_for_upload.png";
//#endif
//			Application.CaptureScreenshot("game_capture_for_upload.png");
//		}
//		//else if( type==eKakaoActionType.SendPaymentInfo ) {
//		//	param = new string[3];
//		//	param[0] = "google";
//		//	param[1] = "1100";
//		//	param[2] = "KRW";
//		//}
//		else if( type==eKakaoActionType.UseHeart ) {
//			param = new string[1];
//			param[0] = "1";	//하트를 한개 사용한다..
//		}
//		else if( type==eKakaoActionType.UpdateResult ) {
//			param = new string[4];
//			param[0] = KakaoLeaderBoard.Instance.gameResult.score.ToString();
//			param[1] = KakaoLeaderBoard.Instance.gameResult.exp.ToString();
//			param[2] = KakaoLeaderBoard.Instance.gameResult.public_data;
//			param[3] = KakaoLeaderBoard.Instance.gameResult.private_data;
//		}
//		else if( type==eKakaoActionType.UpdateMe ) {
//			param = new string[4];
//			param[0] = KakaoLeaderBoard.Instance.updateGameMe.heart.ToString();
//			param[1] = KakaoLeaderBoard.Instance.updateGameMe.currentHeart.ToString();
//			param[2] = KakaoLeaderBoard.Instance.updateGameMe.public_data;
//			param[3] = KakaoLeaderBoard.Instance.updateGameMe.private_data;
//		}
//		else if( type==eKakaoActionType.SendGameMessage ) {
//			param = new string[5];
//			param[0] = KakaoLeaderBoard.Instance.dataSendGameMessage.userId;
//			param[1] = KakaoLeaderBoard.Instance.dataSendGameMessage.message;
//			param[2] = KakaoLeaderBoard.Instance.dataSendGameMessage.gameMessage;
//			param[3] = KakaoLeaderBoard.Instance.dataSendGameMessage.heart.ToString();
//			param[4] = KakaoLeaderBoard.Instance.dataSendGameMessage.data;
//		}
//		else if( type==eKakaoActionType.AcceptMessage ) {
//			param = new string[1];
//			param[0] = KakaoManager.accept_msg_id.ToString();
//		}
//		else if( type==eKakaoActionType.SendGameInviteMessage ) {
//			param = new string[2];
//			param[0] = KakaoLeaderBoard.Instance.dataSendGameInviteMessage.userId;
//			param[1] = KakaoLeaderBoard.Instance.dataSendGameInviteMessage.message;
//		}
//		else if( type==eKakaoActionType.SendLinkInviteMessage ) {//add 20131119
//			param = new string[5];
//			param[0] = KakaoLeaderBoard.Instance.dataSendLinkInviteMessage.userId;
//			param[1] = KakaoLeaderBoard.Instance.dataSendLinkInviteMessage.message;
//			param[2] = KakaoLeaderBoard.Instance.dataSendLinkInviteMessage.templeteId;
//			param[3] = KakaoLeaderBoard.Instance.dataSendLinkInviteMessage.senderNick;
//			param[4] = KakaoLeaderBoard.Instance.dataSendLinkInviteMessage.executeurl;
//		}
//		else {
//			//eKakaoActionType.Login
//			//eKakaoActionType.Logout
//			//eKakaoActionType.Unregister
//			//eKakaoActionType.LocalUser
//			//eKakaoActionType.Friends
//		}
//		
//		// Debug.Log("ST110 NativeHelper.Request.param[] = " + makeParam(param));
//		// //Debug.LogWarning(type.ToString());
//
//#if UNITY_ANDROID && !UNITY_EDITOR
//		activity.Call("kakaoCommand", type.ToString(), makeParam(param));
//#elif UNITY_IPHONE
//		KakaoActionCall(type, param);
//#endif
//		
//	}

//	public void RequestWorldRanking(eKakaoActionType type) {
//		
//		// Debug.Log("R100 NativeHelper.RequestWorldRanking() Run!!!");
//		
//		//// Debug.Log("****AAA***** Request:"+type.ToString());
//		string[] param = null;
//		string strParam_Json = "";
//		
//		// 월드랭킹 저장하기 - SetWorldRankingGameResult.
//		if (type==eKakaoActionType.WorldRankingUpdateResult ) {
//			param = new string[9];
//			param[0] = KakaoLeaderBoard.Instance.gameMe.user_id;
//			param[1] = KakaoLeaderBoard.Instance.gameResult.score.ToString();
//			param[2] = KakaoLeaderBoard.Instance.gameMe.scores_season_score.ToString();
//			param[3] = KakaoLeaderBoard.Instance.gameMe.scores_last_season_score.ToString();
//			param[4] = KakaoLeaderBoard.Instance.gameMe.scores_best_score.ToString();
//			param[5] = KakaoLeaderBoard.Instance.gameMe.nickname;
//			param[6] = KakaoLeaderBoard.Instance.gameMe.profile_image_url;
//			param[7] = KakaoLeaderBoard.Instance.gameMe.public_data;
//
//			// 개인정보동의 수정 (by 최원석 14.04.22) -------- Start.
//			param[8] = Managers.UserData.UserProfileBlock.ToString();
//			// 개인정보동의 수정 (by 최원석 14.04.22) -------- End.
//
//			strParam_Json = "{\"user_id\":\"" + param[0] +
//				"\", \"score\":" + param[1] + 
//					", \"season_score\":" + param[2] + 
//					", \"last_season_score\":" + param[3] + 
//					", \"best_score\":" + param[4] + 
//					", \"nickname\":\"" + param[5] + 
//					"\", \"profile_image_url\":\"" + param[6] + 
//					"\", \"public_data\":\"" + param[7] + 
//					"\", \"ProfileBlock_flag\":" + param[8] + "}";
//			
//			if (Managers.DataStream != null){
//				
//				// EventDelegate 정의 - SetWorldRankingGameResult.
//				Managers.DataStream.Event_Delegate_DataStreamManager_SetWorldRankingGameResult += (intNetworkResultCode_Input) => {
//					
//					if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
//						
//						manager.CallResponseCompleteWorldRankingUpdateResult(intNetworkResultCode_Input.ToString());
//						
//					} else {
//						
//						manager.CallBackResponseError(intNetworkResultCode_Input.ToString());
//					}
//				};
//				
//				StartCoroutine(Managers.DataStream.Network_SetWorldRankingGameResult(strParam_Json)) ;
//			}
//			
//			// 월드랭킹 불러오기  - SetWorldRankingData.
//		} else if (type==eKakaoActionType.WorldRankingData ) {
//			param = new string[2];
//			param[0] = KakaoLeaderBoard.Instance.gameMe.user_id;
//			param[1] = "0";
//			
//			strParam_Json = "{\"user_id\":\""+param[0]+"\", \"page\":"+param[1]+"}";
//			
//			// EventDelegate 정의 - WorldRankingData.
//			Managers.DataStream.Event_Delegate_DataStreamManager_SetWorldRankingData += (intNetworkResultCode_Input) => {
//				
//				if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
//					
//					manager.CallResponseCompleteWorldRankingData(intNetworkResultCode_Input.ToString());
//					
//				} else {
//					
//					manager.CallBackResponseError(intNetworkResultCode_Input.ToString());
//				}
//			};
//			
//			StartCoroutine(Managers.DataStream.Network_SetWorldRankingData(strParam_Json));
//		}
//	}
//
//
//	private string makeParam(string[] param) {
//
//		if( param==null )
//			return "";
//		
//		string result = "";
//		for( int i=0; i<param.Length; ++i ) {
//			if( i>0 )
//				result += "`";
//			result += param[i];
//		}
//		return result;
//	}
//
//	private void onError(String response) {
//	//private static void onError(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onError() Run!!!");
//
//		// //Debug.LogWarning("*******AAA*********" + response);
//	}
//
//	//로그인창에서 백키나 기타 로그인 에러시 호출됨..
//	private void onLoginError(String response) {
//
//		// Debug.Log("ST110 NativeHelper.onLoginError() Run!!!");
//
//		// //Debug.LogWarning("*******AAA*********" + response);
//		isUserLogin = false;
//		manager.CallBackLogin(isUserLogin);
//	}
//		
//		
//		
//		
//	private void onResponseSetTokens(String accessTokenAndRefreshToken) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseSetTokens().accessTokenAndRefreshToken = " + accessTokenAndRefreshToken);
//		 Debug.Log("ST110 NativeHelper.onResponseSetTokens().accessTokenAndRefreshToken.Length = " + accessTokenAndRefreshToken.Length);
//
//		if (accessTokenAndRefreshToken.Length == 151){
//
//			isUserLogin = true;	//재 로그인 안함
//
//		} else {
//		
//			isUserLogin = false;
//		}
//
//		manager.CallBackLogin(isUserLogin);
//	}
//
//	private void onResponseError(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseError() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response + ", length="+response.Length);
//		manager.CallBackResponseError(response);
//	}
//		
//
//	private void onResponseComplete(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseComplete() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallResponseComplete(response);
//	}
//
//	private void onFriendsComplete(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onFriendsComplete() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);
//		manager.CallFiendsComplete(response);
//		//KakaoFriends.Instance.setFriends(response);	//파싱방법 참고..
//	}
//
//
//	private void onResponseCompleteLogout(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteLogout() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		isUserLogin = false;
//		manager.CallResponseCompleteLogout(response);
//	}
//							
//	private void onResponseCompleteUnregister(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteUnregister() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		isUserLogin = false;
//		manager.CallResponseCompleteUnregister(response);
//	}
//						
//						
//	private void onResponseCompleteLocalUser(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteLocalUser() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallResponseCompleteLocalUser(response);
//	}
//						
//						
//	private void onResponseCompleteSendMessage(String response) {
//
//		Debug.Log("ST110 NativeHelper.onResponseCompleteSendMessage().response = " + response);
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallResponseCompleteSendMessage(response);
//	}
//						
//						
//	private void onResponseCompleteSendInviteMessage(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteSendInviteMessage() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallResponseCompleteSendInviteMessage(response);
//	}
//						
//						
//	private void onResponseCompletePostStory(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompletePostStory() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallResponseCompletePostStory(response);
//	}
//						
//					
//	private void onResponseCompleteLoadGameInfo(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteLoadGameInfo() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackLoadGameInfo(response);
//	}
//
//	private void onResponseCompleteLoadGameMe(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteLoadGameMe() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackLoadGameMe(response);
//	}
//													
//	private void onResponseCompleteLoadGameFriends(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteLoadGameFriends() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackLoadGameFriends(response);
//	}
//
//	private void onResponseCompleteUseHeart(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteUseHeart() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackUseHeart(response);
//	}
//
//	private void onResponseCompleteUpdateResult(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteUpdateResult() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackUpdateResult(response);
//	}
//													
//	private void onResponseCompleteDeleteMe(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteDeleteMe() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackDeleteMe(response);
//	}
//
//	private void onResponseCompleteUpdateMe(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteUpdateMe() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackUpdateMe(response);
//	}
//																			
//	private void onResponseCompleteLoadLeaderboard(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteLoadLeaderboard() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackLoadLeaderboard(response);
//	}
//
//	private void onResponseCompleteSendGameMessage(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteSendGameMessage() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackSendGameMessage(response);
//	}
//																					
//																					
//	private void onResponseCompleteLoadGameMessage(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteLoadGameMessage() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackLoadGameMessage(response);
//	}
//																					
//																					
//	private void onResponseCompleteAcceptMessage(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteAcceptMessage() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackAcceptMessage(response);
//	}
//																					
//	private void onResponseCompleteAcceptAllMessages(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteAcceptAllMessages() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackAcceptAllMessages(response);
//	}
//																					
//																					
//	private void onResponseCompleteMessageBlock(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteMessageBlock() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackMessageBlock(response);
//	}
//																					
//	private void onResponseCompleteSendGameInviteMessage(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteSendGameInviteMessage() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackSendGameInviteMessage(response);
//	}
//	
//	//add 20131119
//	private void onResponseCompleteSendLinkInviteMessage(String response) {
//
//		 Debug.Log("ST110 NativeHelper.onResponseCompleteSendLinkInviteMessage() Run!!!");
//
//		// Debug.Log("*******AAA*********" + response);	
//		manager.CallBackSendLinkInviteMessage(response);
//	}

																											
																											
//#if UNITY_IPHONE
//	//call iOS action --------------------------------------------------------------------------------------------------------------
//	private void KakaoActionCall(eKakaoActionType type, string[] param){
//
//		Debug.Log("ST110 NativeHelper.KakaoActionCall().type = " + type.ToString());
//
//		string accessToken = PlayerPrefs.GetString("access_token");
//		string refreshToken = PlayerPrefs.GetString("refresh_token");
//		string json_param = null;
//		if(type==eKakaoActionType.Initialize ) {
//			//****AAA*KakaoParamInit**** ParamString:{"action":"Init"}
//			//****AAA*KakaoParamInit**** ParamString:{"action":"Init", "access_token":"kPKX1kDl424uobxiSxfKk-qLvFf-AQi4cwbOYwyE_jhPHIRmCORhiCV4Y34Ms5P1yW1KINS2gBvFDxoLObry3A", "refresh_token":"bc8acebeccd1bf4b2e7c9725f5f1c7ee9df3062d814cbc866e1a397e52bba0d7"}
//			if( accessToken!=null && accessToken.Length>0 && refreshToken!=null && refreshToken.Length>0){
//				json_param = "{\"action\":\"Init\", \"access_token\":\""+ accessToken +"\", \"refresh_token\":\""+ refreshToken +"\"}";
//			} else {
//				json_param = "{\"action\":\"Init\"}";
//			}
//		}
//		else if(type==eKakaoActionType.Login) {
//			//****AAA*KakaoParamBase**** ParamString:{"action":"Login"}
//			json_param = "{\"action\":\"Login\"}";
//		}
//		else if(type==eKakaoActionType.LocalUser) {
//			//****AAA*KakaoParamBase**** ParamString:{"action":"LocalUser"}
//			json_param = "{\"action\":\"LocalUser\"}";
//		}
//		else if(type==eKakaoActionType.Friends) {
//			//****AAA*KakaoParamBase**** ParamString:{"action":"Friends"}
//			json_param = "{\"action\":\"Friends\"}";
//		}
//		else if(type==eKakaoActionType.Logout) {
//			//****AAA*KakaoParamBase**** ParamString:{"action":"Logout"}
//			json_param = "{\"action\":\"Logout\"}";
//		}
//		else if(type==eKakaoActionType.Unregister) {
//			//****AAA*KakaoParamBase**** ParamString:{"action":"Unregister"}
//			json_param = "{\"action\":\"Unregister\"}";
//		}
//		else if(type==eKakaoActionType.SendMessage) {
//			//SendMessage("Message from Unity3D Plugin.",friend.userid,"itemid=01&count=1");
//			json_param = "{\"action\":\"SendMessage\", \"message\":\""+ param[1] +"\", \"receiverId\":\""+ param[0] +"\", \"executeUrl\":\"itemid=01&count=1\"}";
//		}
//		else if(type==eKakaoActionType.LoadGameInfo) {
//			//****AAA*KakaoParamBase**** ParamString:{"action":"LoadGameInfo"}
//			json_param = "{\"action\":\"LoadGameInfo\"}";
//		}
//		else if(type==eKakaoActionType.LoadGameMe) {
//			//****AAA*KakaoParamBase**** ParamString:{"action":"LoadGameMe"}
//			json_param = "{\"action\":\"LoadGameMe\"}";
//		}
//		else if(type==eKakaoActionType.LoadGameFriends) {
//			//****AAA*KakaoParamBase**** ParamString:{"action":"LoadGameFriends"}
//			json_param = "{\"action\":\"LoadGameFriends\"}";
//		}
//		else if(type==eKakaoActionType.UseHeart) {
//			json_param = "{\"action\":\"UseHeart\", \"heart\":\""+ param[0] +"\"}";
//		}
//		else if(type==eKakaoActionType.UpdateResult) {
//			//{"action":"UpdateResult", "exp":150, "leaderboard_key":"default", "score":200, "public_data":"AAAA", "private_data":"BBBB"}
//			json_param = "{\"action\":\"UpdateResult\", \"exp\":"+ param[1] +", \"leaderboard_key\":\"default\", \"score\":"+ param[0] +", \"public_data\":\""+ param[2] +"\", \"private_data\":\""+ param[3] +"\"}";
//		}
//		else if(type==eKakaoActionType.DeleteMe) {
//			//****AAA*KakaoParamBase**** ParamString:{"action":"DeleteMe"}
//			json_param = "{\"action\":\"DeleteMe\"}";
//		}
//		else if(type==eKakaoActionType.UpdateMe) {
//			//{"action":"UpdateMe", "heart":10, "current_heart":0, "public_data":"", "private_data":""}
//			json_param = "{\"action\":\"UpdateMe\", \"heart\":"+ param[0] +", \"current_heart\":"+ param[1] +", \"public_data\":\""+ param[2] +"\", \"private_data\":\""+ param[3] +"\"}";
//		}
//		else if(type==eKakaoActionType.LoadLeaderboard) {
//			json_param = "{\"action\":\"LoadLeaderboard\"}";
//		}
//		else if(type==eKakaoActionType.SendGameMessage) {
//			json_param = "{\"action\":\"SendGameMessage\", \"receiver_id\":\""+ param[0] +"\", \"msg\":\""+ param[1] +"\", \"game_msg\":\""+ param[2] +"\", \"heart\":"+ param[3] +", \"executeurl\":\"itemid=01&count=1\", \"data\":\""+ param[4] +"\"}";
//		}
//		else if(type==eKakaoActionType.LoadGameMessage) {
//			json_param = "{\"action\":\"LoadGameMessage\"}";
//		}
//		else if(type==eKakaoActionType.AcceptMessage) {
//			json_param = "{\"action\":\"AcceptMessage\", \"message_id\":\""+ param[0] +"\"}";
//		}
//		else if(type==eKakaoActionType.AcceptAllMessages) {
//			json_param = "{\"action\":\"AcceptAllMessages\"}";
//		}
//		else if(type==eKakaoActionType.MessageBlock) {
//			json_param = "{\"action\":\"MessageBlock\"}";
//		}
//		else if(type==eKakaoActionType.SendGameInviteMessage) {
//			json_param = "{\"action\":\"SendGameInviteMessage\", \"receiver_id\":\""+ param[0] +"\", \"msg\":\""+ param[1] +"\"}";
//
//			//add 20131120
//		} else if(type==eKakaoActionType.SendLinkInviteMessage) {
//				
//			json_param = "{\"action\":\"SendLinkInviteMessage\", \"receiver_id\":\""+ param[0] +"\", \"msg\":\""+ param[1] +"\", \"templeteId\":\""+ param[2] +"\", \"senderNick\":\""+ param[3] +"\", \"executeurl\":\""+ param[4] +"\"}";
//
//		}
//
//		Debug.Log("ST110 NativeHelper.KakaoActionCall().json_param = " + json_param);
//
//		
//		// Debug.Log("*******AAA : KakaoActionCall" + json_param);
//		if(json_param != null){
//			PlayerPrefs.SetString("kakaoUnityExtension",json_param);
//		}
//	}
//	
//	//Response ----------------------------------------------------------------------------------------------------------
//	public static void KakaoResonseComplete(string result) {
//
//		Debug.Log("ST110 NativeHelper.KakaoResonseComplete().result = " + result);
//		
//		if(result != null && !result.Equals("")){
//			JSONNode root = JSON.Parse(result);
//			string action = root["action"];
//			var requestResult = root["result"];
//			
//			if( action.Equals("Init") ) { // for init
//				PlayerPrefs.SetString("kakaoUnityExtension","{\"action\":\"Authorized\"}");	//call direct
//			}
//			else if( action.Equals("Authorized") && requestResult!=null ) {
//				//*******AAA********* KakaoResonseComplete : result={"action":"Authorized","result":{"authorized":"true"}}
//				//*******AAA********* KakaoResonseComplete : result={"action":"Authorized","result":{"authorized":"false"}}
//				string isAuthorized = requestResult["authorized"];
//				// Debug.Log("*******AAA********* : isAuthorized=" + isAuthorized);
//				if( isAuthorized.Equals("true") ) {
//					_instance.isUserLogin = true;
//					_instance.manager.CallBackLogin(true);
//				} else {
//					_instance.isUserLogin = false;
//					_instance.manager.CallBackLogin(false);
//	
//				}
//			}
//			else if( action.Equals("Token") ) {	//for save token
//				//*******AAA********* KakaoResonseComplete : result={"action":"Token","result":{"refresh_token":"fc600dfa7ab9002bd71ba5210cb07d875aa19315301c2adcdf08b48b8b35e6de","access_token":"J-3FATxnhZgvKarPA5fIEYzzYlt26fR3os_t3PFYbDk3KYilAzDVM7HWfSiQbQoRqEwyOS9-hfzmyGbcle7EDg"}}
//				string accessToken = requestResult["access_token"];
//				string refreshToken = requestResult["refresh_token"];
//				if( accessToken==null || refreshToken==null || accessToken.Length==0 || refreshToken.Length==0 ){
//					//empty token
//					//KakaoFriends.Instance.clearFriends();
//					PlayerPrefs.DeleteKey("access_token");
//					PlayerPrefs.DeleteKey("refresh_token");
//					PlayerPrefs.Save();
//					_instance.isUserLogin = false;
//					_instance.manager.CallBackLogin(false);
//				} else {
//					// Debug.Log("*******AAA********* SaveToken : AccessToken = "+accessToken+"\n"+"RefreshToken = "+refreshToken);
//					PlayerPrefs.SetString("access_token",accessToken);
//					PlayerPrefs.SetString("refresh_token",refreshToken);
//					PlayerPrefs.Save();
//					
//					_instance.isUserLogin = true;
//					_instance.manager.CallBackLogin(true);
//				}		
//			}	
//			//KakaoResonseComplete : result={"action":"Login"}	//no action 
//			else if( action.Equals("LocalUser") && requestResult!=null ) {
//				//*******AAA********* KakaoResonseComplete : result={"action":"LocalUser","result":{"user_id":"88316238715999073","message_blocked":false,"verified":true,"profile_image_url":"http://th-p3.talk.kakao.co.kr/th/talkp/wkdTh6FxDU/r0Oym4xXYnpvYIphVMxkt0/6ga2kc_110x110_c.jpg","status":0,"hashed_talk_user_id":"AIs7np47iwA","country_iso":"KR","nickname":"심재철"}}
//				// Debug.Log("*******AAA********* : LocalUser="+requestResult.ToString());
//				_instance.manager.CallResponseCompleteLocalUser(requestResult.ToString());
//	
//			}
//			else if( action.Equals("Friends") && requestResult!=null ) {
//				//*******AAA********* KakaoResonseComplete : result={"action":"Friends","result":{"status":0,"app_friends_info":[{"nickname":"고영민","profile_image_url":"","user_id":"88334147258510417","message_blocked":false,"friend_nickname":"","hashed_talk_user_id":"AbCgwMCgsAE"},{"nickname":"고표현","profile_image_url":"http://th-p1.talk.kakao.co.kr/th/talkp/wkdfztaVJ4/ehTgtlU4hlk6va3XibGfB0/11qb1v_110x110_c.jpg","user_id":"88232124067951648","message_blocked":false,"friend_nickname":"","hashed_talk_user_id":"ADwQYGAQPAA"},{"nickname":"서동영","profile_image_url":"http://th-p45.talk.kakao.co.kr/th/talkp/wkaEGWiTsT/gSo2cg40mYhNVbtOmABUKk/w0m610_110x110_c.jpg","user_id":"88264583203819105","message_blocked":false,"friend_nickname":"","hashed_talk_user_id":"Asm8-Pi8yQI"},{"nickname":"선혜","profile_image_url":"http://th-p19.talk.kakao.co.kr/th/talkp/wkdHnFPTH2/roXsExP4xQSDXz720DuX60/42sdpn_110x110_c.jpg","user_id":"88214206842737745","message_blocked":false,"friend_nickname":"","hashed_talk_user_id":"Aesq4OAq6wE"},{"nickname":"성......
//				// Debug.Log("*******AAA********* : Friends="+requestResult.ToString());
//				_instance.manager.CallFiendsComplete(requestResult.ToString());
//			}
//			else if( action.Equals("Logout") ) {
//				//*******AAA********* KakaoResonseComplete : result={"action":"Logout"}
//				// Debug.Log("*******AAA********* : Logout");
//				_instance.isUserLogin = false;
//				_instance.manager.CallResponseCompleteLogout("");
//			}
//			else if( action.Equals("Unregister") ) {
//				// Debug.Log("*******AAA********* : Unregister");
//				_instance.isUserLogin = false;
//				_instance.manager.CallResponseCompleteUnregister("");
//			}
//			else if( action.Equals("SendMessage") ) {
//				//*******AAA********* KakaoResonseComplete : result={"action":"SendMessage"}
//				 Debug.Log("*******AAA********* : SendMessage");
//				_instance.manager.CallResponseCompleteSendMessage("");
//			}
//			else if( action.Equals("LoadGameInfo") && requestResult!=null ) {
//				//*******AAA********* KakaoResonseComplete : result={"action":"LoadGameInfo","result":{"next_score_reset_time":"2013-10-15T14:00:00+09:00","min_version_for_ios":"1.0","rechargeable_heart":5,"game_message_interval":300,"name":"페이퍼 히어로","current_version_for_android":"1.0","score_reset_hour":14,"leaderboards":[{"key":"default","name":"default"}],"message_expire_day":30,"message_limit":100,"current_version_for_ios":"1.0","last_score_reset_timestamp":1381208400,"invitation_interval":2678400,"last_score_reset_time":"2013-10-08T14:00:00+09:00","next_score_reset_timestamp":1381813200,"season_type":"week","heart_regen_interval":600,"max_heart":999,"score_reset_wday":2,"min_version_for_android":"1.0","status":0,"notice":""}}
//				// Debug.Log("*******AAA********* : LoadGameInfo"+requestResult.ToString());
//				_instance.manager.CallBackLoadGameInfo(requestResult.ToString());
//			}
//			else if( action.Equals("LoadGameMe") && requestResult!=null ) {
//				//*******AAA********* KakaoResonseComplete : result={"action":"LoadGameMe","result":{"exp":150,"private_data":"bbb","heart_regen_starts_at":1381419433,"heart":4,"message_count":0,"public_data":"aaa","scores":[],"user_id":"88316238715999073","server_time":1381419596,"profile_image_url":"http://th-p3.talk.kakao.co.kr/th/talkp/wkdTh6FxDU/r0Oym4xXYnpvYIphVMxkt0/6ga2kc_110x110_c.jpg","nickname":"심재철","status":0,"message_blocked":false}}
//				// Debug.Log("*******AAA********* : LoadGameMe"+requestResult.ToString());
//				_instance.manager.CallBackLoadGameMe(requestResult.ToString());
//			}
//			else if( action.Equals("LoadGameFriends") && requestResult!=null ) {
//				// Debug.Log("*******AAA********* : LoadGameFriends"+requestResult.ToString());
//				_instance.manager.CallBackLoadGameFriends(requestResult.ToString());
//			}
//			else if( action.Equals("UseHeart")  && requestResult!=null ) {
//				//*******AAA********* KakaoResonseComplete : result={"action":"UseHeart","result":{"status":0,"heart_regen_starts_at":1381419433,"update_token":"5a274b","heart":4}}
//				// Debug.Log("*******AAA********* : UseHeart");
//				_instance.manager.CallBackUseHeart(requestResult.ToString());
//			}
//			else if( action.Equals("UpdateResult") && requestResult!=null ) {
//				//*******AAA********* KakaoResonseComplete : result={"action":"UpdateResult","result":{"status":0}}
//				// Debug.Log("*******AAA********* : UpdateResult"+requestResult.ToString());
//				_instance.manager.CallBackUpdateResult(requestResult.ToString());
//			}
//			else if( action.Equals("DeleteMe") && requestResult!=null ) {
//				//*******AAA********* : DeleteMe{"status":"0"}
//				// Debug.Log("*******AAA********* : DeleteMe"+requestResult.ToString());
//				_instance.manager.CallBackDeleteMe(requestResult.ToString());
//			}
//			else if( action.Equals("UpdateMe") && requestResult!=null ) {
//				// Debug.Log("*******AAA********* : UpdateMe"+requestResult.ToString());
//				_instance.manager.CallBackUpdateMe(requestResult.ToString());
//			}
//			else if( action.Equals("LoadLeaderboard") && requestResult!=null ) {
//				// Debug.Log("*******AAA********* : LoadLeaderboard"+requestResult.ToString());
//				_instance.manager.CallBackLoadLeaderboard(requestResult.ToString());
//			}
//			else if( action.Equals("SendGameMessage") && requestResult!=null ) {
//				// Debug.Log("*******AAA********* : SendGameMessage"+requestResult.ToString());
//				_instance.manager.CallBackSendGameMessage(requestResult.ToString());
//			}
//			else if( action.Equals("LoadGameMessage") && requestResult!=null ) {
//				//	{"status":"0", "messages":[ {"heart":"1", "sender_id":"88532247182150000", "message_id":"88532247182150000_1381496968", "data":"1", "message":"민 님에게 행운의 박스를 선물 받았습니다.", "sent_at":"1381496968", "sender_nickname":"민"}, {"heart":"1", "sender_id":"88532247182150000", "message_id":"88532247182150000_1381492754"
//				// Debug.Log("*******AAA********* : LoadGameMessage"+requestResult.ToString());
//				_instance.manager.CallBackLoadGameMessage(requestResult.ToString());
//			}
//			else if( action.Equals("AcceptMessage") && requestResult!=null ) {
//				//{"status":"0"}
//				// Debug.Log("*******AAA********* : AcceptMessage"+requestResult.ToString());
//				_instance.manager.CallBackAcceptMessage(requestResult.ToString());
//			}
//			else if( action.Equals("AcceptAllMessages") && requestResult!=null ) {
//				//{"status":"0"}
//				// Debug.Log("*******AAA********* : AcceptAllMessages"+requestResult.ToString());
//				_instance.manager.CallBackAcceptAllMessages(requestResult.ToString());
//			}
//			else if( action.Equals("MessageBlock") && requestResult!=null ) {
//				// Debug.Log("*******AAA********* : MessageBlock"+requestResult.ToString());
//				_instance.manager.CallBackMessageBlock(requestResult.ToString());
//			}
//			else if( action.Equals("SendGameInviteMessage") && requestResult!=null ) {
//				// Debug.Log("*******AAA********* : SendGameInviteMessage"+requestResult.ToString());
//				_instance.manager.CallBackSendGameInviteMessage(requestResult.ToString());
//			}
//			//add 20131120
//			else if( action.Equals("SendLinkInviteMessage") && requestResult!=null ) {
//				//Debug.Log("*******AAA********* : SendLinkInviteMessage"+requestResult.ToString());
//				_instance.manager.CallBackSendLinkInviteMessage(requestResult.ToString());
//			}
//
//						
//			
//			
//		}	
//	}
//	
//	//Reponse error
//	public static void KakaoResonseError(string error) {
//
//		Debug.Log("ST110 NativeHelper.KakaoResonseError().error = " + error);
//
//		JSONNode root = JSON.Parse(error);
//		//string action = root["action"];
//		//JSONNode failReason = root["error"];
//		
//		//string status = failReason["status"];
//		//string message = failReason["message"];
//		
//		_instance.manager.CallBackResponseError(root["error"].ToString());
//		
//		//*******AAA********* KakaoResonseError : error={"action":"SendMessage","error":{"status":"-500","message":"Invalid Request Parameter : sender or receiver id was not valid"}}
//		//*******AAA********* KakaoResonseError : error={"action":"Logout","error":{"status":"4","message":"Authentication tokens don't exist."}}
//		//*******AAA********* KakaoResonseError : error={"action":"Unregister","error":{"status":"4","message":"Authentication tokens don't exist."}}
//		//*******AAA********* KakaoResonseError : error={"action":"UseHeart","error":{"status":"-42","message":"Not enough heart"}}
//		//error={"action":"UpdateResult","error":{"status":"9","message":"Invalid Parameter."}}
//		//*******AAA********* KakaoResonseError : error={"action":"UpdateResult","error":{"status":"-41","message":"Invalid update token"}}
//		//*******AAA********* KakaoResonseError : error={"action":"UpdateMe","error":{"status":"-18","message":"Current heart mismatch"}}
//
//	}
//#endif


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
		//Debug.Log("GOT CLIENT TIME: " + clientTime);
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

	public string m_PushInfo = "";
	public void GetPushInfoString()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		m_PushInfo = activity.Call<string>("checkLoadingWithExtra");
		Debug.Log("PUSH NULL?: " + (m_PushInfo ==  null) + "PUSH INFO: " + m_PushInfo);
		#endif  		
	}

	protected void OnMessageCall (Dictionary<string, object> _value) 
	{
		GetPushInfoString();
		Debug.Log("OnMessageCall");
	}
}	