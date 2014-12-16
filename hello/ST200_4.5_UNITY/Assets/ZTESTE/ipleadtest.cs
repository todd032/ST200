using UnityEngine;
using System.Collections;

public class ipleadtest : MonoBehaviour {

	protected string url = "http://gamehub.polycube.co.kr/geoip.php?deviceid=79e9ddd65c7b1267186750bde0b71a1c&ostype=2&service=ST200&mtype=2&os=Android+OS+4.1.2+%2f+API-16+(JZO54K%2fIM-A860K.007)&language=Korean&model=PANTECH+IM-A860K";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			GetIP();
		}
	}	

	protected void GetIP()
	{
		StartCoroutine(IEGetIP());
	}

	protected IEnumerator IEGetIP()
	{
		Debug.Log("START GETTING IP");
		WWW www = new WWW(url);
		while(!www.isDone)
		{
			yield return null;
		}

		if(www.error != null)
		{
			Debug.Log("URL ERROR: " + www.error);
		}else
		{
			Debug.Log("URL GET: " + www.text);
		}

		yield break;
	}
}
