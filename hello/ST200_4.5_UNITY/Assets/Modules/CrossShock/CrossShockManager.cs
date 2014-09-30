using UnityEngine;
using System.Collections;
using System;
using LitJson;
using SimpleJSON;
using System.Collections.Generic;

public class CrossShockManager : MonoBehaviour {

	private string UserKey = "ST110KTEST";
	private readonly string AppKey = "jzkfcx5olvz";
	private readonly string IconURL = "http://www.crossshock.com/Icon/";
	private readonly string PostUrl = "http://www.crossshock.com:9696/Client/";

	public List<CrossShockAppInfo> AppInfoList = new List<CrossShockAppInfo>();
	#if UNITY_ANDROID
	public AndroidJavaObject activity;
	#endif

	private static CrossShockManager instance;
	public static CrossShockManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(CrossShockManager)) as CrossShockManager;
			}

			return instance;
		}
	}

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}

#if UNITY_ANDROID && !UNITY_EDITOR
		// Debug.Log("AAA NativeHelper : UNITY_ANDROID");
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
#endif
	}

	// Use this for initialization
	void Start () {
		GetUserKey();
#if UNITY_EDITOR
		CrossShockAppInfo info = new CrossShockAppInfo();
		info.AppName = "TEST";
		info.AppKey = "LLLLL";
		info.AppDescription = "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT";
		info.Reward = "5";
		info.AppIcon = "asdasdasdasd";
		for(int i = 0; i < 0; i++)
		{
			AppInfoList.Add(info);
		}
#endif
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetKeyDown(KeyCode.Alpha1))
		//{
		//	StartCoroutine(GameStart());
		//}
		//if(Input.GetKeyDown(KeyCode.Alpha2))
		//{
		//	StartCoroutine(GetList());
		//}
		//
		//if(Input.GetKeyDown(KeyCode.Alpha3))
		//{
		//	StartCoroutine(Click(AppInfoList[UnityEngine.Random.Range(0, AppInfoList.Count)]));
		//}
		//
		//if(Input.GetKeyDown(KeyCode.Alpha4))
		//{
		//	StartCoroutine(RewardCheck(0));
		//}
	}

	public void GetUserKey(){
		#if UNITY_EDITOR

		#elif UNITY_ANDROID

		UserKey = activity.Call<string>("getCrossMarketing_UserKey");
		//Debug.Log("USER KEY:" + UserKey);
		#endif
	}

	public void CheckGameStart()
	{
		StartCoroutine(GameStart());
	}

	private IEnumerator GameStart()
	{
		Dictionary<string, string> data = new Dictionary<string, string>();
		data.Add("UserKey", UserKey);
		data.Add("AppKey", AppKey);
		WWW www = Post(PostUrl + "GameStart.aspx", data);
		yield return www;

		//Debug.Log("GameStart Log: " +  www.text);

		if(www.error == null)
		{
			string result = www.text;
			string[] parsed = result.Split(new string[]{"|"}, StringSplitOptions.None);
			if(parsed[0] == "1")
			{
				CheckGetList();
			}
		}
		yield break;
	}

	
	public void CheckGetList()
	{
		StartCoroutine(GetList());
	}

	private IEnumerator GetList()
	{
		Dictionary<string, string> data = new Dictionary<string, string>();
		data.Add("UserKey", UserKey);
		data.Add("AppKey", AppKey);
		WWW www = Post(PostUrl + "GetList.aspx", data);
		yield return www;
		
		//Debug.Log("Get List Log: " + www.text);
		if(www.error == null)
		{
			AppInfoList.Clear();

			string result = www.text;
			string[] parsedstring = result.Split(new string[]{"|"},StringSplitOptions.None);
			if(parsedstring[0] == "1")
			{
				for(int i = 1; i < parsedstring.Length - 1; i++)
				{
					//Debug.Log("INDEX: " + i);
					string[] parsedappstring = parsedstring[i].Split(new string[]{"&"},StringSplitOptions.None);
					CrossShockAppInfo info = new CrossShockAppInfo();
					info.AppName = parsedappstring[0];
					//Debug.Log("WTF?: " + info.AppName);
					info.AppKey = parsedappstring[1];
					info.AppIcon = IconURL + parsedappstring[2];
					info.AppDescription = parsedappstring[3];
					info.Reward = "5";//parsedappstring[4];
					AppInfoList.Add (info);
				}
			}
		}


		//for(int i = 0; i < AppInfoList.Count; i++)
		//{
		//	Debug.Log("APP NAME: " + AppInfoList[i].AppName + "\nAppKey: " + AppInfoList[i].AppKey +
		//	          "\nIcon: " + AppInfoList[i].AppIcon + "\nDescription: " + AppInfoList[i].AppDescription +
		//	          "\nReward:" + AppInfoList[i].Reward);
		//}

		yield break;
	}

	protected bool m_ClickFlag = false;
	public void GetClick(CrossShockAppInfo _info)
	{
		StartCoroutine(Click(_info));
	}

	private IEnumerator Click(CrossShockAppInfo _info)
	{
		Dictionary<string, string> data = new Dictionary<string, string>();
		data.Add("UserKey", UserKey);
		data.Add("AppKey", AppKey);
		data.Add("DestAppKey", _info.AppKey);
		WWW www = Post(PostUrl + "Click.aspx", data);
		yield return www;
		
		//Debug.Log("Click Log: " + www.text);
		if(www.error == null)
		{
			string result = www.text;
			string[] parsed = result.Split(new string[]{"|"}, StringSplitOptions.None);
			if(parsed[0] == "1")
			{

				m_ClickFlag = true;

				Application.OpenURL(parsed[1]);
			}
		}

		yield break;
	}

	public delegate void CheckRewardDelegate(int _type, int _reward);
	protected CheckRewardDelegate m_CheckRewardDelegate;
	public event CheckRewardDelegate CheckRewardEvent{
		add
		{
			m_CheckRewardDelegate = null;
			m_CheckRewardDelegate += value;
		}
		remove
		{
			m_CheckRewardDelegate -= value;
		}
	}


	public void CheckReward(int _type)
	{
		StartCoroutine(RewardCheck(_type));
	}

	private IEnumerator RewardCheck(int _type)
	{
		Dictionary<string, string> data = new Dictionary<string, string>();
		data.Add("UserKey", UserKey);
		data.Add("AppKey", AppKey);
		data.Add("RewardClear", _type.ToString());
		WWW www = Post(PostUrl + "RewardCheck.aspx", data);
		yield return www;
		
		//Debug.Log("RewardCheck Log: " + www.text);
		int rewardamount = 0;
		if(www.error == null)
		{
			string result = www.text;
			string[] parsed = result.Split(new string[]{"|"}, StringSplitOptions.None);
			if(parsed[0] == "1")
			{
				rewardamount = int.Parse(parsed[1]) / 20;
			}
		}
		if(m_CheckRewardDelegate != null)
		{
			m_CheckRewardDelegate(_type, rewardamount);
		}

		yield break;
	}


	public WWW Post(string url, Dictionary<string, string> post)
	{
		WWWForm form = new WWWForm();
		foreach(KeyValuePair<String,String> post_arg in post)
		{
			form.AddField(post_arg.Key, post_arg.Value);
		}
		WWW www = new WWW(url, form);
		
		StartCoroutine(WaitForRequest(www));
		return www; 
	}

	private IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			//Debug.Log("WWW Ok!: " + www.text);
		} else {
			//Debug.Log("WWW Error: "+ www.error);
		}    
	}

	void OnApplicationPause(bool _pause)
	{
		//if(!_pause)
		//{
		//	if(m_ClickFlag)
		//	{
		//		m_ClickFlag = false;
		//		CheckReward(0);
		//	}
		//}
	}
}

public struct CrossShockAppInfo
{
	public string AppName;
	public string AppKey;
	public string AppIcon;
	public string AppDescription;
	public string Reward;
}
