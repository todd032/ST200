/*
* AfreecaTvData.cs
* 아프리카TV 게임센터 데이터 셋.
* 게임 센터 관련 데이터를 정의하고 관리.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;


public class AfreecaTvData : MonoBehaviour {

/*
* -------------------------------------------------------------------------	
* 	데이터 클레스 정의.
* -------------------------------------------------------------------------
*/ 
	//내 정보.
	/*{ "action":"GetUserInfo", "resultCode":200, "resultMessage":"성공", "resultMessage":{
	*		"CLAN_ID":"tonic9932",
	*		"USER_ID":"jcsim20",
	*		"CLAN_MASTER_YN":"N",
	*		"CLAN_REG_DATE":"2013-10-23 18:40:46",
	*		"CLAN_PROFILE_URL":"",
	*		"MESSAGE_ALLOW_YN":"Y",
	*		"PROFILE_URL":"",
	*		"USER_SCORE":"0",
	*		"CLAN_NAME":"힝힝홍홍",
	*		"NICKNAME":"초리00"
	*} }
	*/
	public class UserInfo{
		public string clan_id 			{ get; set; }
		public string user_id 			{ get; set; }	//유저 식별코드.
		public string clan_master_yn 	{ get; set; }	//클랜장 여부.
		public string clan_reg_date 	{ get; set; }	//클랜 가입일시.
		public string clan_profile_url 	{ get; set; }	//클랜장의 프로필 이미지 URL.
		public string message_allow_yn 	{ get; set; }	//메시지 수신여부.
		public string profile_url 		{ get; set; }	//내 프로필 이미지 URL.
		public string user_score 		{ get; set; }	//내 게임 점수(문자열).
		public string clan_name 		{ get; set; }	
		public string nickname 			{ get; set; }	//내 닉네임.
		public string ori_json_string	{ get; set; }	//JSON 소스 데이터
	}
	
	
	//클랜 랭킹정보.	
	/*{ "action":"GetClanRanking", "resultCode":200, "resultMessage":"success", "resultMessage":{
	 * 		"MORE_YN":"N",
	 * 		"USER_LIST":[{
	 * 			"CLAN_ID":"tonic9932",
	 * 			"PROFILE_URL":"",
	 * 			"USER_ID":"jcsim20",
	 * 			"SCORE":"0",
	 * 			"CLAN_PROFILE_URL":"",
	 * 			"CLAN_NAME":"힝힝홍홍",
	 * 			"NICKNAME":"초리00"
	 * 		}]
	 * } }
	 */
	//클랜 랭킹 플레이어 개별 정보.
	public class ClanRankingPlayer{
		public string clan_id 			{ get; set; }
		public string profile_url 		{ get; set; }	//프로필 이미지 URL.
		public string user_id 			{ get; set; }	//플레이어 식별코드.
		public string score 			{ get; set; }	//플레이어 점수(문자열).
		public string clan_profile_url 	{ get; set; }	//클랜장의 프로필 이미지 URL.
		public string clan_name 		{ get; set; }
		public string nickname 			{ get; set; }	//플레이어 닉네임.
	}
	
	//클랜 랭킹 정보.
	public class ClanRanking{
		public int page_number			{ get; set; }	//랭킹리스트 페이지 정보.
		public string more_yn			{ get; set; }	//다음 페이지 존재 여부.
		public List<ClanRankingPlayer> user_list { get; set; }
	}
	
	
	//클랜별 탑 플레이어 랭킹 정보.
	/*{ "action":"GetTopRanking", "resultCode":200, "resultMessage":"success", "resultMessage":{
	 * 	"MORE_YN":"N",
	 *	"USER_LIST":[{
	 * 			"USER_ID":"????",
	 * 			"NICKNAME":"?????",
	 * 			"PROFILE_URL":"?????",
	 * 			"CLAN_ID":"??????",
	 * 			"CLAN_NAME":"?????",
	 * 			"CLAN_PROFILE_URL":"???????",
	 * 			"SCORE":"0",
	 *	}]
	 *}}
	 */
	//클랜별 탑 플레이어 랭킹 플레이어 개별 정보.
	public class TopRankingPlayer{
		public string user_id 			{ get; set; }
		public string nickname 			{ get; set; }
		public string profile_url 		{ get; set; }
		public string clan_id 			{ get; set; }
		public string clan_name 		{ get; set; }
		public string clan_profile_url 	{ get; set; }
		public string score 			{ get; set; }
	}
	
	//클랜 랭킹 정보.
	public class TopRanking{
		public int page_number			{ get; set; }	//랭킹리스트 페이지 정보.
		public string more_yn			{ get; set; }	//다음 페이지 존재 여부.
		public List<TopRankingPlayer> user_list { get; set; }
	}

	
	//
	
	
/*
* -------------------------------------------------------------------------	
* 	싱글톤 객체 생성.
* -------------------------------------------------------------------------
*/ 
	static AfreecaTvData _instance;
	public static AfreecaTvData Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType(typeof(AfreecaTvData)) as AfreecaTvData;
                if (_instance == null) {
                    _instance = new GameObject("AfreecaTvData").AddComponent<AfreecaTvData>();
                }
            }
            return _instance;
        }
    }


	public UserInfo userInfo = new UserInfo();
	public ClanRanking clanRanking = new ClanRanking();
	public List<ClanRankingPlayer> clanRankingPlayer = new List<ClanRankingPlayer>();
	public TopRanking topRanking = new TopRanking();
	public List<TopRankingPlayer> topRankingPlayer = new List<TopRankingPlayer>();


	void Awake(){

		DontDestroyOnLoad(this);

	}


	
/*
* -------------------------------------------------------------------------	
* 	메소드 정의.
* -------------------------------------------------------------------------
*/ 
	
	//내 정보 저장.
	public void setUserInfo(JSONNode node){
		userInfo.clan_id = node["CLAN_ID"];
		userInfo.user_id = node["USER_ID"];
		userInfo.clan_master_yn = node["CLAN_MASTER_YN"];
		userInfo.clan_reg_date = node["CLAN_REG_DATE"];
		userInfo.clan_profile_url = node["CLAN_PROFILE_URL"];
		userInfo.message_allow_yn = node["MESSAGE_ALLOW_YN"];
		userInfo.profile_url = node["PROFILE_URL"];
		userInfo.user_score = node["USER_SCORE"];
		userInfo.clan_name = node["CLAN_NAME"];
		userInfo.nickname = node["NICKNAME"];
		userInfo.ori_json_string = node.ToString();
	}
	
	//클랜 랭킹정보 저장.	
	public void setClanRanking(JSONNode node, int pnum) {
		clanRanking.page_number = pnum;
		clanRanking.more_yn = node["MORE_YN"];
		clanRankingPlayer.Clear();
		for( int i=0; i<node["USER_LIST"].Count; ++i ) {
			JSONNode data = node["USER_LIST"][i];
			ClanRankingPlayer player = new ClanRankingPlayer();
			player.clan_id = data["CLAN_ID"];
			player.profile_url = data["PROFILE_URL"];
			player.user_id = data["USER_ID"];
			player.score = data["SCORE"];
			player.clan_profile_url = data["CLAN_PROFILE_URL"];
			player.clan_name = data["CLAN_NAME"];
			player.nickname = data["NICKNAME"];
			
			//clanRanking.user_list.Add(player);
			clanRankingPlayer.Add(player);
			//Debug.Log("AAAAA("+ i +") setClanRanking(): nickname="+player.nickname+", clan_name="+player.clan_name+ ", score="+player.score );
		}
		clanRanking.user_list = clanRankingPlayer;
	}
	
	//클랜별 탑 플레이어 랭킹 정보 저장.
	public void setTopRanking(JSONNode node, int pnum) {
		topRanking.page_number = pnum;
		topRanking.more_yn = node["MORE_YN"];
		//topRanking.user_list.Clear();
		//topRanking.user_list = new List<TopRankingPlayer>();
		topRankingPlayer.Clear();
		for( int i=0; i<node["USER_LIST"].Count; ++i ) {
			JSONNode data = node["USER_LIST"][i];
			TopRankingPlayer player = new TopRankingPlayer();
			player.user_id = data["USER_ID"];
			player.nickname = data["NICKNAME"];
			player.profile_url = data["PROFILE_URL"];
			player.clan_id = data["CLAN_ID"];
			player.clan_name = data["CLAN_NAME"];
			player.clan_profile_url = data["CLAN_PROFILE_URL"];
			player.score = data["SCORE"];
			
			//topRanking.user_list.Add(player);
			topRankingPlayer.Add(player);
			//Debug.Log("AAAAA("+ i +") setTopRanking(): nickname="+player.nickname+", clan_name="+player.clan_name+ ", score="+player.score);
		}
		topRanking.user_list = topRankingPlayer;
	}
	
}

