using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//https://developers.facebook.com/docs/games/unity/unity-tutorial - reference

public class PFPFacebookManager : MonoBehaviour {

	private static PFPFacebookManager s_instance;
	public static PFPFacebookManager Instance
	{
		get
		{
			if(s_instance == null)
			{
				s_instance = FindObjectOfType(typeof(PFPFacebookManager)) as PFPFacebookManager;
			}

			return s_instance;
		}
	}

	void Awake()
	{
		if(s_instance == null)
		{
			s_instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	#region member functions
	public void Init()
	{
		if(FB.IsLoggedIn)
		{
			Debug.Log("Already logged in");
		}else
		{
			FB.Init(OnInit, OnHideUnity);
		}
	}

	public void LogIn()
	{
		if(FB.IsLoggedIn)
		{
			Debug.Log("Already logged in2");
		}else
		{
			FB.Login("", OnLogIn);
		}
	}

	public void InviteFriend(string _title = "title", string _message = "message", string _data = "data")
	{
		FB.AppRequest(_message,
		              null,
		              null,
		              null,
		              100,
		              _data,
		              _title,
		              OnRequest);


	}
	#endregion

	#region Delegate functions
	public delegate void OnInitDelegate();
	protected OnInitDelegate m_OnInitDelegate;
	public event OnInitDelegate OnInitEvent
	{
		add
		{
			m_OnInitDelegate += value;
		}
		remove
		{
			m_OnInitDelegate -= value;
		}
	}

	/// <summary>
	/// Add delegate function [OnInitDelegate] to [OnInitEvent] to get it working.
	/// </summary>
	protected void OnInit()
	{
		if(m_OnInitDelegate != null)
		{
			m_OnInitDelegate();
		}
	}

	public delegate void OnHideUnityDelegate(bool _shown);
	protected OnHideUnityDelegate m_OnHideUnityDelegate;
	public event OnHideUnityDelegate OnHideUnityEvent
	{
		add
		{
			m_OnHideUnityDelegate += value;
		}
		remove
		{
			m_OnHideUnityDelegate -= value;
		}
	}

	/// <summary>
	/// Add delegate function [OnHideUnityDelegate] to [OnHideUnityEvent] to get it working.
	/// </summary>
	/// <param name="_isgameshown">If set to <c>true</c> _isgameshown.</param>
	protected void OnHideUnity(bool _isgameshown)
	{
		if(m_OnHideUnityDelegate != null)
		{
			m_OnHideUnityDelegate(_isgameshown);
		}
	}

	public delegate void OnLogInDelegate(FBResult _result);
	protected OnLogInDelegate m_OnLogInDelegate;
	public event OnLogInDelegate OnLogInEvent
	{
		add
		{
			m_OnLogInDelegate += value;
		}
		remove
		{
			m_OnLogInDelegate -= value;
		}
	}

	/// <summary>
	/// Add delegate function [OnLogInDelegate] to [OnLogInEvent] to get it working.
	/// </summary>
	/// <param name="_result">_result.</param>
	protected void OnLogIn(FBResult _result)
	{
		if(m_OnLogInDelegate != null)
		{
			m_OnLogInDelegate(_result);
		}
	}

	public delegate void OnRequestDelegate(FBResult _result);
	protected OnRequestDelegate m_OnRequestDelegate;
	public event OnRequestDelegate OnRequestEvent
	{
		add
		{
			m_OnRequestDelegate += value;
		}
		remove
		{
			m_OnRequestDelegate -= value;
		}
	}
	
	/// <summary>
	/// Add delegate function [OnRequestDelegate] to [OnRequestEvent] to get it working.
	/// </summary>
	/// <param name="_result">_result.</param>
	protected void OnRequest(FBResult _result)
	{
		if(m_OnRequestDelegate != null)
		{
			m_OnRequestDelegate(_result);
		}
	}
	#endregion
}
