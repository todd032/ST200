using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldRankManager : MonoBehaviour {

	private static WorldRankManager instance;
	public static WorldRankManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(WorldRankManager)) as WorldRankManager;
			}
			
			return instance;
		}
	}

	public List<WorldRankData> m_WorldRankingData = new List<WorldRankData>();

	public delegate void SaveWorldRankingDelegate(int _result);
	protected SaveWorldRankingDelegate m_SaveWorldRankingDelegate;
	public event SaveWorldRankingDelegate SaveWorldRankingEvent
	{
		add
		{
			m_SaveWorldRankingDelegate = null;
			m_SaveWorldRankingDelegate += value;
		}
		remove
		{
			m_SaveWorldRankingDelegate -= value;
		}
	}
	public void SaveWorldRanking(string _userid, string _usernickname, int _score, int _stage, string _condata)
	{
		string[] param = null;
		string strParam_Json = "";
		
		// 월드랭킹 저장하기 - SetWorldRankingGameResult.
		string scorestring = _score.ToString();
		string stagestring = _stage.ToString();

		param = new string[9];
		param[0] = _userid;
		param[1] = scorestring;
		param[2] = stagestring;
		param[3] = "0";
		param[4] = "0";
		param[5] = _usernickname;
		param[6] = "";
		param[7] = _condata;
		
		// 개인정보동의 수정 (by 최원석 14.04.22) -------- Start.
		param[8] = Managers.UserData.UserProfileBlock.ToString();
		// 개인정보동의 수정 (by 최원석 14.04.22) -------- End.
		
		strParam_Json = "{\"user_id\":\"" + param[0] +
			"\", \"score\":" + param[1] + 
				", \"season_score\":" + param[2] + 
				", \"last_season_score\":" + param[3] + 
				", \"best_score\":" + param[4] + 
				", \"nickname\":\"" + param[5] + 
				"\", \"profile_image_url\":\"" + param[6] + 
				"\", \"public_data\":\"" + param[7] + 
				"\", \"ProfileBlock_flag\":" + param[8] + "}";
		
		if (Managers.DataStream != null){
			
			// EventDelegate 정의 - SetWorldRankingGameResult.
			Managers.DataStream.Event_Delegate_DataStreamManager_SetWorldRankingGameResult += (intNetworkResultCode_Input) => {
				
				if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
					
				} else {
					
				}
				if(m_SaveWorldRankingDelegate != null)
				{
					m_SaveWorldRankingDelegate(intNetworkResultCode_Input);
				}
			};
			
			StartCoroutine(Managers.DataStream.Network_SetWorldRankingGameResult(strParam_Json)) ;
		}
	}

	public delegate void GetWorldRankingDelegate(int _result);
	protected GetWorldRankingDelegate m_GetWorldRankingDelegate;
	public event GetWorldRankingDelegate GetWorldRankingEvent
	{
		add
		{
			m_GetWorldRankingDelegate = null;
			m_GetWorldRankingDelegate += value;
		}
		remove
		{
			m_GetWorldRankingDelegate -= value;
		}
	}

	public void GetWorldRanking(string _userid) {

		string[] param = null;
		string strParam_Json = "";		

		param = new string[2];
		param[0] =  _userid;
		param[1] = "0";
		
		strParam_Json = "{\"user_id\":\""+param[0]+"\", \"page\":"+param[1]+"}";
		
		// EventDelegate 정의 - WorldRankingData.
		Managers.DataStream.Event_Delegate_DataStreamManager_SetWorldRankingData += (intNetworkResultCode_Input) => {
			
			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){

				if(m_GetWorldRankingDelegate != null)
				{
					m_GetWorldRankingDelegate(Constant.NETWORK_RESULTCODE_OK);
				}
			} else {
				
				if(m_GetWorldRankingDelegate != null)
				{
					m_GetWorldRankingDelegate(Constant.NETWORK_RESULTCODE_Error_Network);
				}
			}
		};
		
		StartCoroutine(Managers.DataStream.Network_SetWorldRankingData(strParam_Json));
	}
	
	public void setWorldRankingData(string _json) {

		Debug.Log("SET WORLD RANK CALLED: " + _json);
		m_WorldRankingData.Clear();

		SimpleJSON.JSONNode root = SimpleJSON.JSON.Parse(_json);
		WorldRankData myrankdata = new WorldRankData();
		if(root["my_rank"].Count > 0)
		{
			SimpleJSON.JSONNode data = root["my_rank"];
			myrankdata.UserRank = data["rank"].AsInt;
			myrankdata.UserId = Managers.UserData.UserID;// data["user_id"].Value;
			myrankdata.UserNickName = Managers.UserData.UserNickName;// data["nickname"].Value;
			myrankdata.UserScore = data["best_score"].AsInt;
			myrankdata.UserStage = data["stage"].AsInt;
			myrankdata.UserCharacter = Managers.UserData.GetCurrentGameCharacter().IndexNumber.ToString();// data["public_data"].Value;
			myrankdata.Country = Managers.CountryCode;
		}
		m_WorldRankingData.Add(myrankdata);
		Debug.Log("MYRANK: " + myrankdata.UserRank);
		//set world rank
		SimpleJSON.JSONArray worldrank = root["top_rank"].AsArray;
		for(int i = 0; i < worldrank.Count; i++)
		{
			SimpleJSON.JSONNode data = worldrank[i];

			WorldRankData worldrankdata = new WorldRankData();


			//Debug.Log("RANK.....?: " + data["rank"].AsInt);
			worldrankdata.UserRank = data["rank"].AsInt;
			worldrankdata.UserId = data["user_id"].Value;
			worldrankdata.UserNickName = data["nickname"].Value;
			worldrankdata.UserScore = data["best_score"].AsInt;
			worldrankdata.UserStage = data["stage"].AsInt;
			worldrankdata.UserCharacter = data["public_data"].Value;
			worldrankdata.Country = data["profile_image_url"];
			if(worldrankdata.UserId != "")
			{
				m_WorldRankingData.Add(worldrankdata);
			}
		}
	}
}


public struct WorldRankData
{
	public int UserRank;
	public string UserId;
	public string UserNickName;
	public int UserScore;
	public int UserStage;
	public string UserCharacter;
	public string Country;
}