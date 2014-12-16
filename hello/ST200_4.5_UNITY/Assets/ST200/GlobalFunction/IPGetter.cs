using UnityEngine;
using System.Collections;

public class IPGetter : MonoBehaviour {

	protected string url = "http://gamehub.polycube.co.kr/geoip.php?deviceid=79e9ddd65c7b1267186750bde0b71a1c&ostype=2&service=ST200&mtype=2&os=Android+OS+4.1.2+%2f+API-16+(JZO54K%2fIM-A860K.007)&language=Korean&model=PANTECH+IM-A860K";
	protected string m_ServerURL = "http://gamehub.polycube.co.kr/geoip.php";
	protected bool m_TestGlobalServer = true;

	protected string m_ServerIP;
	public string ServerIP
	{
		get
		{
			return m_ServerIP;
		}
	}

	public static readonly int NETWORK_STATE_READY = 0;
	public static readonly int NETWORK_STATE_SUCCESS = 1;
	public static readonly int NETWORK_STATE_ERROR = -1;

	protected int m_NetworkState = IPGetter.NETWORK_STATE_READY;
	public int NetworkState
	{
		get
		{
			return m_NetworkState;
		}
	}
	// Use this for initialization
	void Start () {
		//Init();
	}

	private string deviceid = "1";
	private string ostype = "2";
	private string service = "ST200";
	private string mtype = "2";
	private string os = "pc";
	private string language = "2";
	private string model = "22";

	public void Init()
	{
		deviceid = SystemInfo.deviceUniqueIdentifier;
#if UNITY_ANDROID
		ostype = "2";
		mtype = Constant.CURRENT_MARKET;
#elif UNITY_IOS
		ostype = "1";
		mtype = "1";
#endif
		service = "ST200";
		//os = SystemInfo.operatingSystem;
		//language = Application.systemLanguage.ToString();
		//model = SystemInfo.deviceModel;
	}

	// Update is called once per frame
	void Update () {
	}

	public void GetIP()
	{
		StartCoroutine(IEGetIP());
	}
	
	protected IEnumerator IEGetIP()
	{
		string newurl = m_ServerURL 
				+ "?deviceid=" + deviceid
				+ "&ostype=" + ostype
				+ "&service=" + service
				+ "&mtype=" + mtype
				+ "&os=" +os
				+ "&language=" + language
				+ "&model=" + model;
		if(Constant.CONNECTFROMUS)
		{
			newurl += "&server=AWS-WEST";
		}

		Debug.Log("START GETTING IP: " + newurl);
		WWW www = new WWW(newurl);
		while(!www.isDone)
		{
			yield return null;
		}

		if(www.error != null)
		{
			Debug.Log("URL ERROR: " + www.error);
			m_NetworkState = IPGetter.NETWORK_STATE_ERROR;
		}else
		{
			Debug.Log("URL GET: " + www.text);
			m_NetworkState = IPGetter.NETWORK_STATE_SUCCESS;

			m_ServerIP = "http://" + www.text + "/";
		}

		if(m_ServerIP != "")
		{
			//Constant.URL_DEVELOP_SERVER_URL = m_ServerIP;
			Constant.URL_RELEASE_SERVER_URL = m_ServerIP;
		}

		yield break;
	}
}
