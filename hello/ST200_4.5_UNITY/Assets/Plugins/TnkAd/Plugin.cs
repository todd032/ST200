using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace TnkAd {
	public class Plugin
	{
		private static Plugin _instance;

		public static string m_UserID;
		
		public static Plugin Instance 
		{
			get 
			{
				if(_instance == null)
				{
					_instance = new Plugin();
				}
				return _instance;
			}
		}

	#if UNITY_ANDROID
		private AndroidJavaClass pluginClass;

		public Plugin()
		{
			pluginClass = new AndroidJavaClass("com.tnkfactory.ad.unity.TnkUnityPlugin");
			setUserName( m_UserID );
		}

		public void prepareInterstitialAdForPPI()
		{
			pluginClass.CallStatic ("prepareInterstitialAdForPPI");
			Debug.Log( "Ad Call" );
		}

		public void prepareInterstitialAdForCPC()
		{
			pluginClass.CallStatic ("prepareInterstitialAdForCPC");
		}

		public void prepareInterstitialAd(string logicName)
		{
			pluginClass.CallStatic ("prepareInterstitialAd", logicName);
		}

		public void prepareInterstitialAd(string logicName, string handlerName)
		{
			pluginClass.CallStatic ("prepareInterstitialAd", logicName, handlerName);
		}

		public void showInterstitialAd() 
		{
			pluginClass.CallStatic ("showInterstitialAd");
			Debug.Log( "ShowAD" );
		}

		public void onBackPressed() 
		{
			pluginClass.CallStatic ("onBackPressed");
		}

		public bool isInterstitialAdVisible() {
			return pluginClass.CallStatic<bool> ("isInterstitialAdVisible");
		}

		public void showAdList() {
			pluginClass.CallStatic ("showAdList");
		}

		public void showAdList(string title) {
			pluginClass.CallStatic ("showAdList", title);
		}

		public void popupAdList() {
			pluginClass.CallStatic ("popupAdList");
		}
		
		public void popupAdList(string title) {
			pluginClass.CallStatic ("popupAdList", title);
		}

		public void popupAdList(string title, string handlerName) {
			pluginClass.CallStatic ("popupAdList", title, handlerName);
		}

		public void applicationStarted() {
			pluginClass.CallStatic ("applicationStarted");
		}

		public void actionCompleted() {
			pluginClass.CallStatic ("actionCompleted");
		}

		public void actionCompleted(string actionName) {
			pluginClass.CallStatic ("actionCompleted", actionName);
		}

		public void buyCompleted(string itemName) {
			pluginClass.CallStatic ("buyCompleted", itemName);
		}

		public void queryPoint(string handlerName) {
			pluginClass.CallStatic ("queryPoint", handlerName);
		}

		public void purchaseItem(int cost, string itemName, string handlerName) {
			pluginClass.CallStatic ("purchaseItem", cost, itemName, handlerName);
		}

		public void queryPublishState(string handlerName) {
			pluginClass.CallStatic ("queryPublishState", handlerName);
		}

		public void setUserName(string userName) {
			pluginClass.CallStatic ("setUserName", userName);
		}

		public void setUserAge(int age) {
			pluginClass.CallStatic ("setUserAge", age);
		}

		// 0 for male, 1 for female
		public void setUserGender(int gender) {
			pluginClass.CallStatic ("setUserGender", gender);
		}

		public void showCpcAdList() {
			pluginClass.CallStatic ("showCpcAdList");
		}
		public void showCpcAdList(string title) {
			pluginClass.CallStatic ("showCpcAdList", title);
		}
		public void showCpcAdList(string title, string handlerName) {
			pluginClass.CallStatic ("showCpcAdList", title, handlerName);
		}
		public void showCpcAdListWithButtons(string title, string closeText, string exitText, string handlerName) {
			pluginClass.CallStatic ("showCpcAdListWithButtons", title, closeText, exitText, handlerName);
		}

		public void popupMoreApps() {
			pluginClass.CallStatic ("popupMoreApps");
		}
		public void popupMoreApps(string title) {
			pluginClass.CallStatic ("popupMoreApps", title);
		}
		public void popupMoreApps(string title, string handlerName) {
			pluginClass.CallStatic ("popupMoreApps", title, handlerName);
		}
		public void popupMoreAppsWithButtons(string title, string closeText, string exitText, string handlerName) {
			pluginClass.CallStatic ("popupMoreAppsWithButtons", title, closeText, exitText, handlerName);
		}
	#elif UNITY_IPHONE
		[DllImport("__Internal")]
		private static extern void applicationStarted_UnityBridge();
		[DllImport("__Internal")]
		private static extern void actionCompleted_UnityBridge(string actionName);
		[DllImport("__Internal")]
		private static extern void buyCompleted_UnityBridge(string itemName);
		[DllImport("__Internal")]
		private static extern void prepareInterstitialAd_UnityBridge(string logicName, string handlerName);
		[DllImport("__Internal")]
		private static extern void showInterstitialAd_UnityBridge();
		[DllImport("__Internal")]
		private static extern void showAdList_UnityBridge(string title, string handlerName);

		[DllImport("__Internal")]
		private static extern void queryPoint_UnityBridge(string handlerName);
		[DllImport("__Internal")]
		private static extern void purchaseItem_UnityBridge (int cost, string itemName, string handlerName);
		[DllImport("__Internal")]
		private static extern void queryPublishState_UnityBridge (string handlerName);
		[DllImport("__Internal")]
		private static extern void setUserName_UnityBridge (string userName);
		[DllImport("__Internal")]
		private static extern void setUserAge_UnityBridge (int age);
		[DllImport("__Internal")]
		private static extern void setUserGender_UnityBridge (int gender);

		public Plugin() {
		}
		public void prepareInterstitialAdForPPI()
		{
			prepareInterstitialAd_UnityBridge ("__tnk_ppi__", null);
		}
		public void prepareInterstitialAdForCPC()
		{
			prepareInterstitialAd_UnityBridge ("__tnk_cpc__", null);
		}
		public void prepareInterstitialAd(string logicName)
		{
			prepareInterstitialAd_UnityBridge (logicName, null);
		}
		public void prepareInterstitialAd(string logicName, string handlerName) 
		{
			prepareInterstitialAd_UnityBridge (logicName, handlerName);
		}
		public void showInterstitialAd() 
		{
			showInterstitialAd_UnityBridge ();
		}
		public void onBackPressed() 
		{}
		public bool isInterstitialAdVisible() 
		{ return false; }

		public void showAdList() 
		{
			showAdList_UnityBridge (null, null);
		}
		public void showAdList(string title) 
		{
			showAdList_UnityBridge (title, null);
		}
		public void popupAdList() 
		{
			showAdList_UnityBridge (null, null);
		}
		public void popupAdList(string title) 
		{
			showAdList_UnityBridge (title, null);
		}
		public void popupAdList(string title, string handlerName) 
		{
			showAdList_UnityBridge (title, handlerName);
		}
		public void applicationStarted() 
		{
			applicationStarted_UnityBridge ();
		}
		public void actionCompleted() 
		{
			actionCompleted_UnityBridge (null);
		}
		public void actionCompleted(string actionName) 
		{
			actionCompleted_UnityBridge (actionName);
		}
		public void buyCompleted(string itemName) 
		{
			buyCompleted_UnityBridge (itemName);
		}
		public void queryPoint(string handlerName) 
		{
			queryPoint_UnityBridge (handlerName);
		}
		public void purchaseItem(int cost, string itemName, string handlerName) 
		{
			Debug.Log("Purchase Item 2");
			purchaseItem_UnityBridge (cost, itemName, handlerName);
		}
		public void queryPublishState(string handlerName) 
		{
			queryPublishState_UnityBridge (handlerName);
		}
		public void setUserName(string userName) 
		{
			setUserName_UnityBridge (userName);
		}
		public void setUserAge(int age) 
		{
			setUserAge_UnityBridge (age);
		}
		public void setUserGender(int gender) 
		{
			setUserGender_UnityBridge (gender);
		}

		public void showCpcAdList() 
		{}
		public void showCpcAdList(string title) 
		{}
		public void showCpcAdList(string title, string handlerName) 
		{}
		public void showCpcAdListWithButtons(string title, string closeText, string exitText, string handlerName) 
		{}
		public void popupMoreApps() 
		{}
		public void popupMoreApps(string title) 
		{}
		public void popupMoreApps(string title, string handlerName) 
		{}
		public void popupMoreAppsWithButtons(string title, string closeText, string exitText, string handlerName) 
		{}
	#else
		public Plugin() {
		}
		public void prepareInterstitialAdForPPI()
		{}
		public void prepareInterstitialAdForCPC()
		{}
		public void prepareInterstitialAd(string logicName)
		{}
		public void prepareInterstitialAd(string logicName, string handlerName) 
		{}
		public void showInterstitialAd() 
		{}
		public void onBackPressed() 
		{}
		public bool isInterstitialAdVisible() 
		{ return false; }
		public void showAdList() 
		{}
		public void showAdList(string title) 
		{}
		public void popupAdList() 
		{}
		public void popupAdList(string title) 
		{}
		public void popupAdList(string title, string handlerName) 
		{}
		public void applicationStarted() 
		{}
		public void actionCompleted() 
		{}
		public void actionCompleted(string actionName) 
		{}
		public void buyCompleted(string itemName) 
		{}
		public void queryPoint(string handlerName) 
		{}
		public void purchaseItem(int cost, string itemName, string handlerName) 
		{}
		public void queryPublishState(string handlerName) 
		{}
		public void setUserName(string userName) 
		{}
		public void setUserAge(int age) 
		{}
		public void setUserGender(int gender) 
		{}
		public void showCpcAdList() 
		{}
		public void showCpcAdList(string title) 
		{}
		public void showCpcAdList(string title, string handlerName) 
		{}
		public void showCpcAdListWithButtons(string title, string closeText, string exitText, string handlerName) 
		{}
		public void popupMoreApps() 
		{}
		public void popupMoreApps(string title) 
		{}
		public void popupMoreApps(string title, string handlerName) 
		{}
		public void popupMoreAppsWithButtons(string title, string closeText, string exitText, string handlerName) 
		{}
	#endif
	}
}
