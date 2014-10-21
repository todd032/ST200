using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class ST200KakaoLink {
	
	private static ST200KakaoLink _instance;
	private AndroidJavaClass pluginClass;
	
	private string m_ImageUrl = "http://dn.api1.kage.kakao.co.kr/14/dn/btqaWmFftyx/tBbQPH764Maw2R6IBhXd6K/o.jpg";
	private string m_LinkText = "임시 임시 임시 임시 임시";
	private string m_ButtonText = "button";
	public static ST200KakaoLink g_Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = new ST200KakaoLink();
			}
			return _instance;
		}
	}
	
	public ST200KakaoLink()
	{
		/*
#if UNITY_ANDROID && !UNITY_EDITOR
		pluginClass = new AndroidJavaClass( "com.kakao.sample.kakaolink.KakaoLinkMainActivity" );

		if (pluginClass == null)
		{
			Debug.Log( "Error Init JavaClass" );
		}
		else 
		{
			Debug.Log( "Success Init JavaClass" );

			pluginClass.CallStatic( "InitKakaoLink", m_ImageUrl, m_LinkText );
		}
#endif
*/
		
		//InitLink( m_ImageUrl, m_LinkText );
	}
	
	public void InitLink(string _imageurl, string _text, string _buttontext)
	{
		m_ImageUrl = _imageurl;
		m_LinkText = _text;
		m_ButtonText = _buttontext;
#if UNITY_ANDROID && !UNITY_EDITOR
		NativeHelper.Instance.activity.Call( "InitKakaoLink", m_ImageUrl, m_LinkText , m_ButtonText);
#endif
	}
	
	public void SendKakaoLinkMessage()
	{
		Debug.Log( "Click KakaoLink" );
		#if UNITY_ANDROID && !UNITY_EDITOR
		//pluginClass.CallStatic( "SendKakaoLinkMessage");
		NativeHelper.Instance.activity.Call( "SendKakaoLinkMessage" );
		#endif
	}
	
}
