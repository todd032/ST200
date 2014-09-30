using UnityEngine;
using System.Collections;

public class PFP_AdmobSample : MonoBehaviour {

	void OnGUI()
	{
		// Puts some basic buttons onto the screen.
		GUI.skin.button.fontSize = (int) (0.05f * Screen.height);
		
		Rect requestBannerRect = new Rect(0.1f * Screen.width, 0.05f * Screen.height,
		                                  0.8f * Screen.width, 0.1f * Screen.height);
		if (GUI.Button(requestBannerRect, "Request Banner"))
		{
			PFP_AdmobManager.Instance.RequestBanner(GoogleMobileAds.Api.AdSize.SmartBanner, GoogleMobileAds.Api.AdPosition.Bottom);
		}
		
		Rect showBannerRect = new Rect(0.1f * Screen.width, 0.175f * Screen.height,
		                               0.8f * Screen.width, 0.1f * Screen.height);
		if (GUI.Button(showBannerRect, "Show Banner"))
		{
			PFP_AdmobManager.Instance.ShowBanner();
		}
		
		Rect hideBannerRect = new Rect(0.1f * Screen.width, 0.3f * Screen.height,
		                               0.8f * Screen.width, 0.1f * Screen.height);
		if (GUI.Button(hideBannerRect, "Hide Banner"))
		{
			PFP_AdmobManager.Instance.HideBanner();
		}

		Rect destroyBannerRect = new Rect(0.1f * Screen.width, 0.425f * Screen.height,
		                                  0.8f * Screen.width, 0.1f * Screen.height);
		if (GUI.Button(destroyBannerRect, "Destroy Banner"))
		{
			PFP_AdmobManager.Instance.DestroyBanner();
		}

	}
}
