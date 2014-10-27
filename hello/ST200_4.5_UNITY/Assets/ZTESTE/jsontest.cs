using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using SimpleJSON ;

public class jsontest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Parse();
		}

		if(Input.GetKeyDown(KeyCode.S))
		{
			TestAdd();
		}


		if(Input.GetKeyDown(KeyCode.T))
		{
			Timeprint();
		}
	}

	public int TimeSecond = 0;
	public void Timeprint()
	{
		string[] hi = TextManager.GetDHM(TimeSecond);
		Debug.Log("D: " + hi[0] + " H: " +hi[1] + " M: " + hi[2]);
	}

	public void TestAdd()
	{
		Dictionary<string, string> hi = new Dictionary<string, string>();
		hi.Add("user", "dumb");
		hi.Add("HUHU", "2");
		string body = TextManager.CreateJsonData(hi);
		Debug.Log("BODY: " +body);
	}

	public void Parse()
	{
		string returndata = "{\"MyInfo\":{\"pvp_user_index\":\"44689\",\"battle_count\":\"0\",\"win_count\":\"0\",\"loss_count\":\"0\"},\"Recommend\":[{\"pvp_user_index\":\"20436\",\"nickname\":\"\uc624\ud750\uce20\ud06c\ud574\",\"battle_count\":\"0\",\"win_count\":\"0\",\"loss_count\":\"0\",\"stage\":\"42\",\"armed_data\":{\"CharacterIndex\":1,\"TacticIndex\":2,\"ShipIndex\":5,\"ShipLevel\":10,\"SubShipIndexList\":[10,12],\"SubShipLeveList\":[5,5]},\"winning_reward\":800},{\"pvp_user_index\":\"24938\",\"nickname\":\"\uc774\uc21c\uc2e0BOSS\",\"battle_count\":\"0\",\"win_count\":\"0\",\"loss_count\":\"0\",\"stage\":\"40\",\"armed_data\":{\"CharacterIndex\":1,\"TacticIndex\":2,\"ShipIndex\":6,\"ShipLevel\":10,\"SubShipIndexList\":[8],\"SubShipLeveList\":[5]},\"winning_reward\":400},{\"pvp_user_index\":\"324\",\"nickname\":\"\ubd88\ud328\uc2e0\ud654\uc774\uc21c\uc2e0\",\"battle_count\":\"0\",\"win_count\":\"0\",\"loss_count\":\"0\",\"stage\":\"34\",\"armed_data\":{\"CharacterIndex\":1,\"TacticIndex\":2,\"ShipIndex\":1,\"ShipLevel\":10,\"SubShipIndexList\":[6],\"SubShipLeveList\":[2]},\"winning_reward\":600}]}";
			
		JSONNode root = JSON.Parse(returndata);
		
		JSONNode myinfo = root["MyInfo"];
		string myuserindex = myinfo["pvp_user_index"];
		int mybattlecount = myinfo["battle_count"].AsInt;
		int mywincount = myinfo["win_count"].AsInt;
		int mylosecount = myinfo["lose_count"].AsInt;
		//Debug.Log("myinfo: " + myuserindex + " WIN: " + mywincount);

		JSONNode recommend = root["Recommend"];
		
		for(int i = 0; i < 3; i++)
		{
			JSONNode recommenddata = recommend[i];
			int recommenduserindex = recommenddata["pvp_user_index"].AsInt;
			string recommendnickname = recommenddata["nickname"];
			int recommendbattlecount = recommenddata["battle_count"].AsInt;
			int recommendwincount = recommenddata["win_count"].AsInt;
			int recommendlosecount = recommenddata["lose_count"].AsInt;
			JSONNode armdata = recommenddata["armed_data"];
			int recommendcharacterindex = armdata["CharacterIndex"].AsInt;
			int recommendtacticindex = armdata["TacticIndex"].AsInt;
			int recommendshipindex = armdata["ShipIndex"].AsInt;
			int recommendshiplevel = armdata["ShipLevel"].AsInt;
			JSONArray recommendsubshipindex = armdata["SubShipIndexList"].AsArray;
			JSONArray recommendsubshiplevel = armdata["SubShipLeveList"].AsArray;

			UserInfoData recommendinfodata = new UserInfoData();
			recommendinfodata.UserIndex = recommenduserindex;
			recommendinfodata.UserNickName = recommendnickname;
			recommendinfodata.CharacterIndex = recommendcharacterindex;
			recommendinfodata.TacticIndex = recommendtacticindex;
			recommendinfodata.ShipIndex = recommendshipindex;
			recommendinfodata.ShipLevel = recommendshiplevel;
			recommendinfodata.SubShipIndexList = new int[]{0,0,0,0};
			recommendinfodata.SubShipLevelList = new int[]{0,0,0,0};
			for(int j = 0; j < recommendinfodata.SubShipIndexList.Length; j++)
			{
				if(recommendsubshipindex.Count > j)
				{
					recommendinfodata.SubShipIndexList[j] = recommendsubshipindex[j].AsInt;
				}
			}
			for(int j = 0; j < recommendinfodata.SubShipLevelList.Length; j++)
			{
				if(recommendsubshiplevel.Count > j)
				{
					recommendinfodata.SubShipLevelList[j] = recommendsubshiplevel[j].AsInt;
				}
			}
			//Debug.Log("TOTAL: " + recommenddata.ToString());
			//Debug.Log("ARMDATA: " + armdata.ToString());
			//Debug.Log("hmm: " + recommenduserindex + " subship: " + recommendsubshiplevel[0].AsInt);
		}
	}
}
