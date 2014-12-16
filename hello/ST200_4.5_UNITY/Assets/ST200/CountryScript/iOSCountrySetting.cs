using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class iOSCountrySetting {

	private static iOSCountrySetting _instance;

	public static iOSCountrySetting Instance
	{
		get
		{
			if( _instance == null )
			{
				_instance = new iOSCountrySetting();
			}

			return _instance;
		}
	}

	[DllImport("__Internal")]
	private static extern void iOS_CountrySetting();

	public void GetCountryCode()
	{
		Debug.Log( "GetCountryCode" );
		iOS_CountrySetting();
		//countryCode =
	}

}
