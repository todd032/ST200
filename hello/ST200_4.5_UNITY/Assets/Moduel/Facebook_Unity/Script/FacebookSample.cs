using UnityEngine;
using System.Collections;

public class FacebookSample : MonoBehaviour {

	public GUIText m_Text;
	void Start()
	{
		PFPFacebookManager.Instance.OnInitEvent += Init;
		PFPFacebookManager.Instance.OnLogInEvent += LogIn;
		PFPFacebookManager.Instance.OnHideUnityEvent += HideUnity;
		PFPFacebookManager.Instance.OnRequestEvent += OnRequest;
	}

	void OnGUI()
	{
		float width = Screen.width;
		float height = Screen.height / 5f;

		if(GUI.Button(new Rect(0f, 0f, width, height), "Init"))
		{
			PFPFacebookManager.Instance.Init();
		}

		if(GUI.Button(new Rect(0f, height, width, height), "Login"))
		{
			PFPFacebookManager.Instance.LogIn();
		}

		if(GUI.Button(new Rect(0f, height * 2f, width, height), "Request"))
		{
			PFPFacebookManager.Instance.InviteFriend();
		}
	}


	void AddDebug(string _s)
	{
		m_Text.text += "\n" + _s;
	}

	public void Init()
	{
		AddDebug("Init called");
	}

	public void HideUnity(bool _shown)
	{
		if(!_shown)
		{
			AddDebug("Hide");
		}else
		{
			AddDebug("Show");
		}
	}

	public void LogIn(FBResult _result)
	{
		AddDebug("Log in");
	}

	public void OnRequest(FBResult _result)
	{
		AddDebug("Request");
	}
}
