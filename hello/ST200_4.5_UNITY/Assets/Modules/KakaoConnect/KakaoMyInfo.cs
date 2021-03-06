/*
*  KakaoMyInfo
*  유저 정보 (싱글톤)
*/


using System;
using UnityEngine;
using System.Collections.Generic;
//using LitJson;
using SimpleJSON;

public class KakaoMyInfo : MonoBehaviour {
	//{"message_blocked":false,"hashed_talk_user_id":"AIs7np47iwA","nickname":"심재철","status":0,"verified":true,"country_iso":"KR","user_id":88316238715999073,"profile_image_url":"http:\/\/th-p3.talk.kakao.co.kr\/th\/talkp\/wkcEUR4Br0\/GfTvRqmADOL5kDfVECvNXK\/6gn53g_110x110_c.jpg"}
	//{"user_id":"88316238715999073", "message_blocked":"false", "verified":"true", "profile_image_url":"http://th-p3.talk.kakao.co.kr/th/talkp/wkdTh6FxDU/r0Oym4xXYnpvYIphVMxkt0/6ga2kc_110x110_c.jpg", "status":"0", "hashed_talk_user_id":"AIs7np47iwA", "country_iso":"KR", "nickname":"심재철"}
	
	public class MyInfo {
		public string nickname { get; set; }
		public string user_id { get; set; }
		public string country_iso { get; set; }
		public string profile_image_url { get; set; }
		public bool message_blocked { get; set; }	//메시지 차단 여부 (true/false)
	}
	
	static KakaoMyInfo _instance;
	public static KakaoMyInfo Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType(typeof(KakaoMyInfo)) as KakaoMyInfo;
                if (_instance == null) {
                    _instance = new GameObject("KakaoMyInfo").AddComponent<KakaoMyInfo>();
                }
            }

            return _instance;
        }
    }
	
	
	public MyInfo myInfo = new MyInfo();
	
	public int status;	//0정상, -1세팅전, 0> 에러

	void Awake() {
		status = -1;
		DontDestroyOnLoad(this);

	}
	
	public void set(string json) {
		JSONNode root = JSON.Parse(json);
		status = root["status"].AsInt;
		myInfo.nickname = root["nickname"];
		if(root["hashed_talk_user_id"].Equals("")){		//사용자가 탈퇴한 경우, 기기변경후 로그인 전..
			myInfo.user_id = "NA";
		} else {
			myInfo.user_id = root["user_id"];
		}
		myInfo.country_iso = root["country_iso"];
		myInfo.profile_image_url = root["profile_image_url"];
		myInfo.message_blocked = root["message_blocked"].AsBool;
	}





}



/*
 * LocalUser의 결과 hashed_talk_user_id 값이 빈 스트링인 경우, 우선 게임 로그인은 성공시켜 주되
 * 친구목록 화면 등에서 '현재 카카오계정이 카카오톡과 연결되어 있지 않습니다. 카카오톡에서 계정 로그인을 해주세요'라는 안내 메시지를 출력
*/