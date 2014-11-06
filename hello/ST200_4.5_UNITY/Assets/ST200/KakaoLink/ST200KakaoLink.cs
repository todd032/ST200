using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class ST200KakaoLink {
	
	private static ST200KakaoLink _instance;
	#if UNITY_ANDROID && !UNITY_EDITOR
	private AndroidJavaClass pluginClass;
#endif
	
	private string m_ImageUrl = "http://dn.api1.kage.kakao.co.kr/14/dn/btqaWmFftyx/tBbQPH764Maw2R6IBhXd6K/o.jpg";
	private string m_LinkText = "임시 임시 임시 임시 임시";
	private string m_ButtonText = "button";

	//[DllImport("__Internal")]
	//private static extern void iOS_InitKakaoLink( string imgageURL, string linkText, string linkBtnText );
	
	[DllImport("__Internal")]
	private static extern void iOS_SendKakaoLink( string imgageURL, string linkText, string linkBtnText );

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

#if UNITY_ANDROID && !UNITY_EDITOR
		pluginClass = new AndroidJavaClass( "com.kakao.sample.kakaolink.KakaoLinkMainActivity" );

		if (pluginClass == null)
		{
			Debug.Log( "Error Init JavaClass" );
		}
		else 
		{
			Debug.Log( "Success Init JavaClass" );

			//pluginClass.CallStatic( "InitKakaoLink", m_ImageUrl, m_LinkText );
		}
#elif UNITY_IPHONE


#endif

		
		//InitLink( m_ImageUrl, m_LinkText );
	}

	public void Call_iOS_SendKakaoLink( string imageURL, string linkText, string linkBtnText )
	{
		iOS_SendKakaoLink( imageURL, linkText, linkBtnText );
	}
	
	public void TestLog( string logMessage )
	{
		Debug.Log( "TestLog = " + logMessage );
	}
	
	public bool InitLink(string _imageurl, string _text, string _buttontext)
	{
		m_ImageUrl = _imageurl;
		m_LinkText = _text;
		m_ButtonText = _buttontext;
#if UNITY_ANDROID && !UNITY_EDITOR
		if( pluginClass.CallStatic<bool>( "InitKakaoLink", _imageurl, _text, _buttontext ) )
		{
			return true;
		}
		else
		{
			return false;
		}
		//NativeHelper.Instance.activity.Call( "InitKakaoLink", m_ImageUrl, m_LinkText , m_ButtonText);
#elif UNITY_IPHONE
		iOS_SendKakaoLink( _imageurl, _text, _buttontext );
#endif
		return true;
	}
	
	public void SendKakaoLinkMessage()
	{
		Debug.Log( "Click KakaoLink" );
		#if UNITY_ANDROID && !UNITY_EDITOR
		pluginClass.CallStatic( "SendKakaoLinkMessage");
		//NativeHelper.Instance.activity.Call( "SendKakaoLinkMessage" );
		#endif
	}
	
}
