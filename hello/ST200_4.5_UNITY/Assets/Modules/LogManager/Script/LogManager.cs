using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using SimpleJSON ;

public class LogManager : MonoBehaviour {

	private List<Dictionary<System.Object, System.Object>> m_LogData = new List<Dictionary<System.Object, System.Object>>();
	private Dictionary<System.Object, System.Object> m_CurDictionary = new Dictionary<System.Object, System.Object>();

	private static LogManager instance;
	public static LogManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(LogManager)) as LogManager;
			}

			return instance;
		}
	}

	void Start()
	{
		//testInit();
	}

	void Update()
	{
		//testCode();
		//testCodea();
		//LogLogData();
		//testsave();
		//testLoad();
	}

	void LogLogData()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			for(int i = 0; i < m_LogData.Count; i++)
			{
				foreach(System.Object key in m_LogData[i].Keys)
				{
					Debug.Log("Log INDEX: " + i + " KEY: " + key.ToString() + " VAL: " + m_LogData[i][key].ToString());
				}
			}
		}
	}

	void testInit()
	{
		msgHeader = new MsgHeader();
		msgHeader.Deviceid = SystemInfo.deviceUniqueIdentifier; //md5되어 있음.
		msgHeader.Ostype = "2";
		msgHeader.Service = "ST200";
		msgHeader.Mtype = "2";
		msgHeader.Loginid = "TEST";
		msgHeader.Os = SystemInfo.operatingSystem;
		msgHeader.Language = Application.systemLanguage.ToString();
		msgHeader.Model = SystemInfo.deviceModel;
		msgHeader.AppVersion = "1";
		msgHeader.CodeName = "5";
	}

	void testCode()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			m_LogData.Clear();
			SetLog("TEST1");
			AddParam("TEST1", "HI");
			AddParam("TEST2", 2);
			
			SetLog("TEST22");
			
			AddParam("TEST1", 3f);
			AddParam("TEST2", 2);

			//SendToServer();
		}
	}

	void testCodea()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			//m_LogData.Clear();
			SetLog("TEST1");
			AddParam("TEST1", "HI");
			AddParam("TEST2", 2);
			
			SetLog("TEST22");
			
			AddParam("TEST1", 3f);
			AddParam("TEST2", 2);
			
			//SendToServer();
		}
	}

	void testsave()
	{
		if(Input.GetKeyDown(KeyCode.S))
		{
			//SetLog(LogMessageTag.TAG0);
			//AddParam("TEST1", "HI");
			//AddParam("TEST2", 2);
			//
			//SetLog(LogMessageTag.TAG1);
			//
			//AddParam("TEST1", 3f);
			//AddParam("TEST2", 2);
			
			SaveToLocal();
		}
	}

	void testLoad()
	{
		if(Input.GetKeyDown(KeyCode.L))
		{
			LoadLocal();
		}
	}

	private string m_LocalSaveKey = "ST200LOGDATA";
	private string m_ServerURL = "http://glog.polycube.co.kr/glog/put.php";
	//real: "http://glog.polycube.co.kr/glog/put.php"
	//test: "http://st110.polycube.co.kr/glog/put.php";
		
	private MsgHeader msgHeader;

	public void SetInitDataStream(string loginid, string ver, string _ostype, string _service, string _mtype, string _codename) 
	{

		msgHeader = new MsgHeader();
		msgHeader.Deviceid = SystemInfo.deviceUniqueIdentifier; //md5되어 있음.
		msgHeader.Ostype = _ostype;
		msgHeader.Service = _service;
		msgHeader.Mtype = _mtype;
		msgHeader.Loginid = loginid;
		msgHeader.Os = SystemInfo.operatingSystem;
		msgHeader.Language = Application.systemLanguage.ToString();
		msgHeader.Model = SystemInfo.deviceModel;
		msgHeader.AppVersion = ver;
		msgHeader.CodeName = _codename;		
	}

	public void SetLog(string _type) { 
		m_CurDictionary = new Dictionary<System.Object, System.Object>();
		m_CurDictionary.Add("TAG", _type.ToString());
		m_LogData.Add (m_CurDictionary);
	}

	/// <summary>
	/// call after setlog()
	/// </summary>
	public void AddParam(System.Object _key, System.Object _val)
	{
		if(m_CurDictionary == null)
		{
			//Debug.LogWarning("NO LOG MESSAGE");
			return;
		}
		m_CurDictionary.Add(_key, _val);
	}

	public void LoadFromLocal()
	{

	}

	public void LoadLocal()
	{
		string loadedmessagelist = PlayerPrefs.GetString(m_LocalSaveKey);
		if(loadedmessagelist != null && loadedmessagelist != "")
		{
			m_LogData = JsonMapper.ToObject<List<Dictionary<System.Object, System.Object>>>(loadedmessagelist);
			List<Dictionary<System.Object, System.Object>> newlist = new List<Dictionary<object, object>>();
			for(int i = 0; i < m_LogData.Count; i++)
			{
				Dictionary<System.Object, System.Object> curnewdic = new Dictionary<object, object>();
				foreach(System.Object key in m_LogData[i].Keys)
				{
					JsonData json = (JsonData)m_LogData[i][key];
					//Debug.Log("KEY TYPE: " + key.GetType().ToString());
					if(json.IsBoolean)
					{
						curnewdic.Add(key, bool.Parse(json.ToString()));
					}else if(json.IsInt)
					{
						curnewdic.Add(key, int.Parse(json.ToString()));
					}else if(json.IsDouble)
					{
						curnewdic.Add(key, float.Parse(json.ToString()));
					}else if(json.IsLong)
					{
						curnewdic.Add(key, long.Parse(json.ToString()));
					}else
					{
						curnewdic.Add(key, ((System.Object)json).ToString());
					}
				}
				newlist.Add(curnewdic);
			}

			m_LogData = newlist;
			//Debug.Log("LOAD FROM LOCAL DONE: " + loadedmessagelist + " LOG DATACOUNT: " + m_LogData.Count);
		}
	}

	public void SaveToLocal()
	{
		//see m_LogMessageList and save in file	
		//Debug.Log("SAVE TO LOCAL CALLED LOGDATA: " + m_LogData.Count);
		if(m_LogData != null && m_LogData.Count != 0)
		{
			//Debug.Log("Log Count: " + m_LogData.Count + " OBJECT: " + m_LogData.ToString());
			//Debug.Log("tempdic Count: " + tempdic.Count + " tempdic: " + tempdic.ToString());
			string logmessagelist = JsonMapper.ToJson(m_LogData);
			PlayerPrefs.SetString(m_LocalSaveKey, logmessagelist);
			//Debug.Log("SAVE TO LOCAL: " + logmessagelist);
		}else
		{
			PlayerPrefs.SetString(m_LocalSaveKey, "");
		}
	}

	public void SendToServer()
	{
		//Debug.Log("SEND TO SERVER CALLED");
		if(m_LogData != null && m_LogData.Count != 0)
		{
			if(!IESendToServerProcessing)
			{
				StartCoroutine(IESendToServer());
			}
		}
	}

	bool IESendToServerProcessing = false;
	private IEnumerator IESendToServer()
	{
		IESendToServerProcessing = true;
		
		string header = JsonMapper.ToJson(msgHeader);		
		string body = JsonMapper.ToJson(m_LogData);
		//Debug.Log("HEAD: " + header + " BODY: " +body);
		WWWForm form = new WWWForm();
		form.AddField("head", header);
		form.AddField("body", body);
		
		WWW w = new WWW(m_ServerURL, form);
		yield return w;

		if(w.error == null)
		{
			m_LogData.Clear();
			SaveToLocal();
			//Debug.Log("LOG SAVE COMPLETE");
		}
		w.Dispose();
		w = null;

		IESendToServerProcessing = false;
		yield break;
	}

	#region Classes
	// Header : 유저 및 단말기 정보 헤더..
	public struct MsgHeader {
		private string deviceid;
		
		public string Deviceid{ get { return deviceid; } set { deviceid = value; } }
		
		private string ostype;
		
		public string Ostype{ get { return ostype; } set { ostype = value; } }
		
		private string service;
		
		public string Service{ get { return service; } set { service = value; } }
		
		private string mtype;
		
		public string Mtype{ get { return mtype; } set { mtype = value; } }
		
		private string loginid;
		
		public string Loginid{ get { return loginid; } set { loginid = value; } }
		
		private string os;
		
		public string Os{ get { return os; } set { os = value; } }
		
		private string language;
		
		public string Language{ get { return language; } set { language = value; } }
		
		private string model;
		
		public string Model{ get { return model; } set { model = value; } }
		
		private string appversion;
		
		public string AppVersion{ get { return appversion; } set { appversion = value; } }
		
		private string codeName ;
		
		public string CodeName{ get { return codeName; } set { codeName = value; } }
		
		private int ct ;
		
		public int Ct{ get { return ct; } set { ct = value; } }
	}

#endregion
}
