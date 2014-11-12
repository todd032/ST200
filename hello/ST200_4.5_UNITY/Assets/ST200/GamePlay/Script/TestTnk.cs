using UnityEngine;
using System.Collections;

public class TestTnk : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		TnkAd.Plugin.Instance.setUserName ("haha12");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnGUI ()
	{
		if( GUI.Button ( new Rect( 100, 100, 150, 80 ), "Interstitial Ad" ) )
		{
			Debug.Log("interstitial Ad");
			TnkAd.Plugin.Instance.prepareInterstitialAdForPPI();
			TnkAd.Plugin.Instance.showInterstitialAd();
		}
	}
}
