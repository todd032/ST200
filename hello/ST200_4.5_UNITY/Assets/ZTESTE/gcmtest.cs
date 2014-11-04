using UnityEngine;
using System.Collections;

public class gcmtest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.T))
		{
			System.DateTime curtime = new System.DateTime(System.DateTime.Now.Ticks);
			curtime = curtime.AddSeconds(1f);
			System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0);
			Debug.Log(curtime);
			Debug.Log(epochStart);
			Debug.Log((double)(curtime - epochStart).TotalMilliseconds);

		}
	}

	string titletext = "title";
	string contenttext = "content";
	string time = "0";
	public double actualtimeinmilli = 0;
	void OnGUI()
	{
		float width = Screen.width;
		float height = Screen.height/4f;
		titletext = GUI.TextField(new Rect(0f,0f,width, height), titletext);
		contenttext = GUI.TextField(new Rect(0f,height,width, height), contenttext);
		time = GUI.TextField(new Rect(0f, height + height,width, height), time);
		System.DateTime CurTime =  new System.DateTime(System.DateTime.Now.Ticks);
		System.DateTime epochStart = new System.DateTime(System.DateTime.Now.Ticks);// new System.DateTime(1970, 1, 1, 0, 0, 0);
		double inttime = 0;
		double.TryParse(time, out inttime);
		CurTime = CurTime.AddSeconds(inttime);
		actualtimeinmilli = (double)(CurTime - epochStart).TotalMilliseconds;
		if(GUI.Button(new Rect(0f,height + height + height,width / 2f, height), "Send GCM"))
		{
			showmessage();
		}

		if(GUI.Button(new Rect(width / 2f,height + height + height,width / 2f, height), "clear noti"))
		{
			showmessage();
		}
	}

	void showmessage()
	{
		double cutdouble = actualtimeinmilli - (actualtimeinmilli % 1f);
			Debug.Log("Actual milli: " + cutdouble);

		GCM.SetNotificationMessage(titletext, contenttext, titletext, cutdouble);
	}

	void clearnoti()
	{
		GCM.ClearAllNotifications();
	}
}
