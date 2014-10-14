using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class ST200KakaoLink : MonoBehaviour {

	private static ST200KakaoLink _instance;
	private AndroidJavaClass pluginClass;

	private string m_ImageUrl = "http://dn.api1.kage.kakao.co.kr/14/dn/btqaWmFftyx/tBbQPH764Maw2R6IBhXd6K/o.jpg";
	private string m_LinkText = "임시 임시 임시 임시 임시";
	
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
	
	#if UNITY_ANDROID
	
	public ST200KakaoLink()
	{
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

	}
	
	public void SendKakaoLinkMessage()
	{
		Debug.Log( "Click KakaoLink" );

		pluginClass.CallStatic( "SendKakaoLinkMessage");
	}
	
	#endif
}
