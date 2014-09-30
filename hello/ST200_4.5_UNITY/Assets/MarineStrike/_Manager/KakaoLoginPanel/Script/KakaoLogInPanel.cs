using UnityEngine;
using System.Collections;

public class KakaoLogInPanel : MonoBehaviour {

	// ==================== Layout 변수 정의 - Start ====================
	public UILabel _KakaoStateLabel;
	// ==================== Layout 변수 정의 - End ====================

	// ==================== Unity Override 정의 - Start ====================

	void Awake(){

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ==================== Unity Override 정의 - End ====================

	public void SetLogInText(eKakaoActionType eKakaoActionType_Input){

		//Debug.Log("ST110 KakaoLogInPanel.SetLogInText().eKakaoActionType_Input = " + eKakaoActionType_Input);

		string strTemp = "";

		if (eKakaoActionType_Input == eKakaoActionType.None){
			
			NGUITools.SetActive(gameObject, false);
			
		} else if (eKakaoActionType_Input == eKakaoActionType.Login){
			
			NGUITools.SetActive(gameObject, true);
			strTemp = "로그인 중...";
			
		} else if (eKakaoActionType_Input == eKakaoActionType.LocalUser){
			
			NGUITools.SetActive(gameObject, true);
			strTemp = "로그인 중...";
			
		} else if (eKakaoActionType_Input == eKakaoActionType.LoadGameInfo){
			
			NGUITools.SetActive(gameObject, true);
			strTemp = "서버인증 중...";
			
		} else if (eKakaoActionType_Input == eKakaoActionType.LoadGameMe){
			
			NGUITools.SetActive(gameObject, true);
			strTemp = "유저정보 수신 중...";
			
		} else if (eKakaoActionType_Input == eKakaoActionType.LoadGameFriends){
			
			NGUITools.SetActive(gameObject, true);
			strTemp = "친구리스트 수신 중...";
			
		} else if (eKakaoActionType_Input == eKakaoActionType.WorldRankingData){
			
			NGUITools.SetActive(gameObject, true);
			strTemp = "월드랭킹 수신 중...";
		}

		_KakaoStateLabel.text = strTemp;

	}





}
