using System;
using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;

/// <summary>
/// this class shouldn't be destroyed
/// github - https://github.com/googleads/googleads-mobile-plugins/releases
/// read - https://github.com/googleads/googleads-mobile-plugins/blob/master/unity/README.md
/// </summary>
public class PFP_AdmobManager : MonoBehaviour {

	private readonly string AndroidAdID = "ca-app-pub-2011841791699165/8038213738";
	private readonly string IOSAdID = "ca-app-pub-2011841791699165/8038213738";
	private readonly string AndroidIniAdId = "ca-app-pub-6476722427938963/3575545537";


	private static PFP_AdmobManager instance;
	public static PFP_AdmobManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(PFP_AdmobManager)) as PFP_AdmobManager;
			}

			if(instance == null)
			{
				GameObject newobject = new GameObject();
				newobject.name = "PFP_AdmobManager";
				newobject.AddComponent<PFP_AdmobManager>();
				instance = newobject.GetComponent<PFP_AdmobManager>();
			}

			return instance;
	 	}
	}

	private GoogleMobileAds.Api.BannerView bannerView;
	private InterstitialAd interstitial;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}

	void OnDestroy()
	{
		instance = null;
	}

	public void RequestBanner(AdSize _size, AdPosition _pos)
	{
		if(bannerView == null)
		{

			#if UNITY_EDITOR
			string adUnitId = "unused";
			#elif UNITY_ANDROID
			string adUnitId = AndroidAdID;
			#elif UNITY_IPHONE
			string adUnitId = IOSAdID;
			#else
			string adUnitId = "unexpected_platform";
			#endif
			
			// Create a 320x50 banner at the top of the screen.
			bannerView = new GoogleMobileAds.Api.BannerView(adUnitId, _size, _pos);
			// Register for ad events.
			bannerView.AdLoaded += HandleAdLoaded;
			bannerView.AdFailedToLoad += HandleAdFailedToLoad;
			bannerView.AdOpened += HandleAdOpened;
			bannerView.AdClosing += HandleAdClosing;
			bannerView.AdClosed += HandleAdClosed;
			bannerView.AdLeftApplication += HandleAdLeftApplication;
			// Load a banner ad.
			bannerView.LoadAd(createAdRequest());
		}
	}
	
	public void RequestInterstitial()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = AndroidIniAdId;
		#elif UNITY_IPHONE
		string adUnitId = IOSAdID;
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		interstitial.AdLoaded += HandleInterstitialLoaded;
		interstitial.AdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.AdOpened += HandleInterstitialOpened;
		interstitial.AdClosing += HandleInterstitialClosing;
		interstitial.AdClosed += HandleInterstitialClosed;
		interstitial.AdLeftApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());
	}
	
	// Returns an ad request with custom ad targeting.
	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)
				.AddTestDevice("E00E9E276AF0D6F3E889286CF6A7DCDD")
				.AddKeyword("")
				.SetGender(Gender.Male)
				.SetBirthday(new DateTime(1985, 1, 1))
				.TagForChildDirectedTreatment(false)
				.AddExtra("color_bg", "9B30FF")
				.Build();
		
	}
	
	public void ShowInterstitial()
	{
		if(interstitial != null)
		{
			if (interstitial.IsLoaded())
			{
				interstitial.Show();
			}
			else
			{
				print("Interstitial is not ready yet.");
			}
		}else
		{
			RequestInterstitial();
		}
	}

	public void ShowBanner()
	{
		if(bannerView != null)
		{
			bannerView.Show();
		}
	}

	public void HideBanner()
	{
		if(bannerView != null)
		{
			bannerView.Hide();
		}
	}

	public void DestroyBanner()
	{
		if(bannerView != null)
		{
			bannerView.Destroy();
			bannerView = null;
		}
	}

	#region Banner callback handlers
	
	public void HandleAdLoaded(object sender, EventArgs args)
	{
		print("HandleAdLoaded event received.");
	}
	
	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		print("HandleFailedToReceiveAd event received with message: " + args.Message);
	}
	
	public void HandleAdOpened(object sender, EventArgs args)
	{
		print("HandleAdOpened event received");
	}
	
	void HandleAdClosing(object sender, EventArgs args)
	{
		print("HandleAdClosing event received");
	}
	
	public void HandleAdClosed(object sender, EventArgs args)
	{
		print("HandleAdClosed event received");
	}
	
	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
		print("HandleAdLeftApplication event received");
	}
	
	#endregion
	
	#region Interstitial callback handlers
	
	public void HandleInterstitialLoaded(object sender, EventArgs args)
	{
		print("HandleInterstitialLoaded event received.");
		ShowInterstitial();
	}
	
	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
	}
	
	public void HandleInterstitialOpened(object sender, EventArgs args)
	{
		print("HandleInterstitialOpened event received");
	}
	
	void HandleInterstitialClosing(object sender, EventArgs args)
	{
		print("HandleInterstitialClosing event received");
	}
	
	public void HandleInterstitialClosed(object sender, EventArgs args)
	{
		print("HandleInterstitialClosed event received");
	}
	
	public void HandleInterstitialLeftApplication(object sender, EventArgs args)
	{
		print("HandleInterstitialLeftApplication event received");
	}
	
	#endregion
}
