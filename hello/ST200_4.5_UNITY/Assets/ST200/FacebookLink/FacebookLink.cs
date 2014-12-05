using UnityEngine;
using System.Collections;

public class FacebookLink : MonoBehaviour {

	protected string m_Title = "hi";
	protected string m_Message = "me";
	protected string m_Data = "";

	void Start()
	{
		PFPFacebookManager.Instance.OnInitEvent += Init;
		PFPFacebookManager.Instance.OnLogInEvent += LogIn;
		PFPFacebookManager.Instance.OnHideUnityEvent += HideUnity;
		PFPFacebookManager.Instance.OnRequestEvent += OnRequest;
	}

	void OnDestroy()
	{
		PFPFacebookManager.Instance.OnInitEvent -= Init;
		PFPFacebookManager.Instance.OnLogInEvent -= LogIn;
		PFPFacebookManager.Instance.OnHideUnityEvent -= HideUnity;
		PFPFacebookManager.Instance.OnRequestEvent -= OnRequest;
	}

	public void SetData(string _title, string _message, string _data)
	{
		m_Title = _title;
		m_Message = _message;
		m_Data = _data;
	}

	protected void Init()
	{
		if(FB.IsLoggedIn)
		{
			PFPFacebookManager.Instance.InviteFriend(m_Title, m_Message, m_Data);
		}else
		{
			PFPFacebookManager.Instance.LogIn();
		}
	}
	
	protected void HideUnity(bool _shown)
	{
		if(!_shown)
		{

		}else
		{

		}
	}
	
	protected void LogIn(FBResult _result)
	{
		PFPFacebookManager.Instance.InviteFriend(m_Title, m_Message, m_Data);
	}
	
	protected void OnRequest(FBResult _result)
	{

	}

	public void OnClickInviteFacebookFriend()
	{
		//if ( Managers.Audio != null){
		//	Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		//}

		if(!FB.IsInitialized)
		{
			PFPFacebookManager.Instance.Init();
		}else
		{
			if(!FB.IsLoggedIn)
			{
				PFPFacebookManager.Instance.LogIn();
			}else
			{
				PFPFacebookManager.Instance.InviteFriend(m_Title, m_Message, m_Data);
			}
		}
	}
}
