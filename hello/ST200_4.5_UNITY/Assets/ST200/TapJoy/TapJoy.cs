using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

public class TapJoy : MonoBehaviour, ITapjoyEvent
{
    private static string ENABLE_LOGGING_IOS = "TJC_OPTION_ENABLE_LOGGING";
    private static string ENABLE_LOGGING_ANDROID = "enable_logging";
    string tapPointsLabel = "";
    bool autoRefresh = false;
    bool viewIsShowing = false;
    bool directPlayContent = false;
    bool shouldTransition = false;
    TapjoyEvent diectPlayEvent;
    TapjoyEvent sampleEvent;
    
    void Start ()
    {
        #if UNITY_ANDROID
        // Attach our thread to the java vm; obviously the main thread is already attached but this is good practice..
        if (Application.platform == RuntimePlatform.Android)
            UnityEngine.AndroidJNI.AttachCurrentThread();
        #endif
        
        Dictionary<String, System.Object> connectFlags = new Dictionary<String, System.Object>();
        
        // Connect to the Tapjoy servers.
        if (Application.platform == RuntimePlatform.Android)
        {
            // Enable logging
            connectFlags.Add(ENABLE_LOGGING_ANDROID, true);

            string userID = Managers.UserData.UserID;
            string osType = Managers.DataStream.OsType;
            string serviceCode = Managers.DataStream.GameCode;
            string marketType = Managers.DataStream.MType;
            
            string userDataValue = userID + "|" + osType + "|" + serviceCode + "|" + marketType;  
            
            string md_user_nm = Managers.DataStream.getParameterCheckSum( userID + osType + serviceCode + marketType );
            Debug.Log( "userDataValue = " + userDataValue );
            Debug.Log( "md_user_nm = " + md_user_nm );
            Debug.Log( "Data = " + ( userDataValue + "|" + md_user_nm ) );

            // If you are not using Tapjoy Managed currency, you would set your own user ID here.
            //  connectFlags.Add("user_id", "A_UNIQUE_USER_ID");
            
            // You can also set your event segmentation parameters here.
            //  Dictionary<String, System.Object> segmentationParams = new Dictionary<String, System.Object>();
            //  segmentationParams.Add("iap", true);
            //  connectFlags.Add("segmentation_params", segmentationParams);
            
            TapjoyPlugin.RequestTapjoyConnect("e68ad0c2-5d66-4d0d-b6ac-65fb4a62c1ba",           // YOUR APP ID GOES HERE
                                              "hAE6lInGdWzQFOYgXQsP",                          // YOUR SECRET KEY GOES HERE
                                              connectFlags);                                   // YOUR CONNECT FLAGS

            TapjoyPlugin.SetUserID( ( userDataValue + "|" + md_user_nm ) );
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            
            // Enable logging
            connectFlags.Add(ENABLE_LOGGING_IOS, true);
            
            // Add other connect flags
            connectFlags.Add("TJC_OPTION_COLLECT_MAC_ADDRESS", TapjoyPlugin.MacAddressOptionOffWithVersionCheck);
            
            // If you are not using Tapjoy Managed currency, you would set your own user ID here.
            // connectFlags.Add("TJC_OPTION_USER_ID", "A_UNIQUE_USER_ID");
            
            // You can also set your event segmentation parameters here.
            //  Dictionary<String, System.Object> segmentationParams = new Dictionary<String, System.Object>();
            //  segmentationParams.Add("iap", true);
            //  connectFlags.Add("TJC_OPTION_SEGMENTATION_PARAMS", segmentationParams);
            
            
            TapjoyPlugin.RequestTapjoyConnect("13b0ae6a-8516-4405-9dcf-fe4e526486b2",           // YOUR APP ID GOES HERE
                                              "XHdOwPa8de7p4aseeYP0",                     // YOUR SECRET KEY GOES HERE
                                              connectFlags);                              // YOUR CONNECT FLAGS
        }
        
        // Get the user virtual currency
        //TapjoyPlugin.GetTapPoints();
        
        // Get a banner ad
        //TapjoyPlugin.GetDisplayAd();
    }
    
    void Awake()
    {
        Debug.Log("C#: Awaking and adding Tapjoy Events");
        
        // Tapjoy Connect Events
        TapjoyPlugin.connectCallSucceeded += HandleTapjoyConnectSuccess;
        TapjoyPlugin.connectCallFailed += HandleTapjoyConnectFailed;
        
        // Tapjoy Virtual Currency Events
        TapjoyPlugin.getTapPointsSucceeded += HandleGetTapPointsSucceeded;
        TapjoyPlugin.getTapPointsFailed += HandleGetTapPointsFailed;
        TapjoyPlugin.spendTapPointsSucceeded += HandleSpendTapPointsSucceeded;
        TapjoyPlugin.spendTapPointsFailed += HandleSpendTapPointsFailed;
        TapjoyPlugin.awardTapPointsSucceeded += HandleAwardTapPointsSucceeded;
        TapjoyPlugin.awardTapPointsFailed += HandleAwardTapPointsFailed;
        TapjoyPlugin.tapPointsEarned += HandleTapPointsEarned;
        
        // Tapjoy Full Screen Ad Events
        TapjoyPlugin.getFullScreenAdSucceeded += HandleGetFullScreenAdSucceeded;
        TapjoyPlugin.getFullScreenAdFailed += HandleGetFullScreenAdFailed;
        
        // Tapjoy Display Ad Events
        TapjoyPlugin.getDisplayAdSucceeded += HandleGetDisplayAdSucceeded;
        TapjoyPlugin.getDisplayAdFailed += HandleGetDisplayAdFailed;
        
        // Tapjoy Video Ad Events
        TapjoyPlugin.videoAdStarted += HandleVideoAdStarted;
        TapjoyPlugin.videoAdFailed += HandleVideoAdFailed;
        TapjoyPlugin.videoAdCompleted += HandleVideoAdCompleted;
        
        // Tapjoy Ad View Closed Events
        TapjoyPlugin.viewOpened += HandleViewOpened;
        TapjoyPlugin.viewClosed += HandleViewClosed;
        
        // Tapjoy Show Offers Events
        TapjoyPlugin.showOffersFailed += HandleShowOffersFailed;
    }
    
    void OnApplicationPause(bool pause)
    {
        Debug.Log("C#: Application Pause: " + pause + " expected transition: " + shouldTransition);
        if (!shouldTransition) {
            if (pause)
            {
                TapjoyPlugin.AppPause();
            }
            else
            {
                TapjoyPlugin.AppResume();
            }
        }
        
    }
    
    void OnDisable()
    {
        Debug.Log("C#: Disabling and removing Tapjoy Events");
        // Tapjoy Connect Events
        TapjoyPlugin.connectCallSucceeded -= HandleTapjoyConnectSuccess;
        TapjoyPlugin.connectCallFailed -= HandleTapjoyConnectFailed;
        
        // Tapjoy Virtual Currency Events
        TapjoyPlugin.getTapPointsSucceeded -= HandleGetTapPointsSucceeded;
        TapjoyPlugin.getTapPointsFailed -= HandleGetTapPointsFailed;
        TapjoyPlugin.spendTapPointsSucceeded -= HandleSpendTapPointsSucceeded;
        TapjoyPlugin.spendTapPointsFailed -= HandleSpendTapPointsFailed;
        TapjoyPlugin.awardTapPointsSucceeded -= HandleAwardTapPointsSucceeded;
        TapjoyPlugin.awardTapPointsFailed -= HandleAwardTapPointsFailed;
        TapjoyPlugin.tapPointsEarned -= HandleTapPointsEarned;
        
        // Tapjoy Full Screen Ad Events
        TapjoyPlugin.getFullScreenAdSucceeded -= HandleGetFullScreenAdSucceeded;
        TapjoyPlugin.getFullScreenAdFailed -= HandleGetFullScreenAdFailed;
        
        // Tapjoy Display Ad Events
        TapjoyPlugin.getDisplayAdSucceeded -= HandleGetDisplayAdSucceeded;
        TapjoyPlugin.getDisplayAdFailed -= HandleGetDisplayAdFailed;
        
        // Tapjoy Video Ad Events
        TapjoyPlugin.videoAdStarted -= HandleVideoAdStarted;
        TapjoyPlugin.videoAdFailed -= HandleVideoAdFailed;
        TapjoyPlugin.videoAdCompleted -= HandleVideoAdCompleted;
        
        // Tapjoy Ad View Closed Events
        TapjoyPlugin.viewOpened -= HandleViewOpened;
        TapjoyPlugin.viewClosed -= HandleViewClosed;
        
        // Tapjoy Show Offers Events
        TapjoyPlugin.showOffersFailed -= HandleShowOffersFailed;
    }
    
    
    #region Tapjoy Callback Methods (These must be implemented in your own c# script file.)
    
    // CONNECT
    public void HandleTapjoyConnectSuccess()
    {
        Debug.Log("C#: HandleTapjoyConnectSuccess");
        
        // Preload direct play event
        diectPlayEvent = new TapjoyEvent("video_unit", this);
        diectPlayEvent.EnablePreload(true);
        diectPlayEvent.Send();
    }
    
    public void HandleTapjoyConnectFailed()
    {
        Debug.Log("C#: HandleTapjoyConnectFailed");
    }
    
    // VIRTUAL CURRENCY
    void HandleGetTapPointsSucceeded(int points)
    {
        Debug.Log("C#: HandleGetTapPointsSucceeded: " + points);
        tapPointsLabel = "Total TapPoints: " + TapjoyPlugin.QueryTapPoints();
    }
    
    public void HandleGetTapPointsFailed()
    {
        Debug.Log("C#: HandleGetTapPointsFailed");
    }
    
    public void HandleSpendTapPointsSucceeded(int points)
    {
        Debug.Log("C#: HandleSpendTapPointsSucceeded: " + points);
        tapPointsLabel = "Total TapPoints: " + TapjoyPlugin.QueryTapPoints();
    }
    
    public void HandleSpendTapPointsFailed()
    {
        Debug.Log("C#: HandleSpendTapPointsFailed");
    }
    
    public void HandleAwardTapPointsSucceeded()
    {
        Debug.Log("C#: HandleAwardTapPointsSucceeded");
        tapPointsLabel = "Total TapPoints: " + TapjoyPlugin.QueryTapPoints();
    }
    
    public void HandleAwardTapPointsFailed()
    {
        Debug.Log("C#: HandleAwardTapPointsFailed");
    }
    
    public void HandleTapPointsEarned(int points)
    {
        Debug.Log("C#: CurrencyEarned: " + points);
        tapPointsLabel = "Currency Earned: " + points;
        
        TapjoyPlugin.ShowDefaultEarnedCurrencyAlert();
    }
    
    // FULL SCREEN ADS
    public void HandleGetFullScreenAdSucceeded()
    {
        Debug.Log("C#: HandleGetFullScreenAdSucceeded");
        
        TapjoyPlugin.ShowFullScreenAd();
    }
    
    public void HandleGetFullScreenAdFailed()
    {
        Debug.Log("C#: HandleGetFullScreenAdFailed");
    }
    
    // DISPLAY ADS
    public void HandleGetDisplayAdSucceeded()
    {
        Debug.Log("C#: HandleGetDisplayAdSucceeded");
        
        if (!viewIsShowing)
            TapjoyPlugin.ShowDisplayAd();
    }
    
    public void HandleGetDisplayAdFailed()
    {
        Debug.Log("C#: HandleGetDisplayAdFailed");
    }
    
    // VIDEO
    public void HandleVideoAdStarted()
    {
        Debug.Log("C#: HandleVideoAdStarted");
    }
    
    public void HandleVideoAdFailed()
    {
        Debug.Log("C#: HandleVideoAdFailed");
    }
    
    public void HandleVideoAdCompleted()
    {
        Debug.Log("C#: HandleVideoAdCompleted");
    }
    
    // VIEW OPENED  
    public void HandleViewOpened(TapjoyViewType viewType)
    {
        Debug.Log("C#: HandleViewOpened");
        viewIsShowing = true;
    }
    
    // VIEW CLOSED  
    public void HandleViewClosed(TapjoyViewType viewType)
    {
        Debug.Log("C#: HandleViewClosed");
        viewIsShowing = false;
    }
    
    // OFFERS
    public void HandleShowOffersFailed()
    {
        Debug.Log("C#: HandleShowOffersFailed");
    }
    
    #endregion
    
    #region ITapjoyEvent callback methods
    
    public void SendEventSucceeded(TapjoyEvent tapjoyEvent, bool contentIsAvailable)
    {
        Debug.Log("C#: SendEventSucceeded, contentIsAvailable: " + contentIsAvailable + " for event: " + tapjoyEvent.GetName());
        
        if (tapjoyEvent.GetName() == diectPlayEvent.GetName()) {
            directPlayContent = contentIsAvailable;
        }
        
    }
    
    public void ContentIsReady(TapjoyEvent tapjoyEvent, int status)
    {
        Debug.Log("C#: ContentIsReady for event: " + tapjoyEvent.GetName() + " with status: " + status);
        
        /*
        switch(status) {
            case TJCEventPreloadPartial:
                // handle partial load of cache
                break;
            case TJCEventPreloadComplete:
                // handle complete load of cache
                break;
        }
        */
    }
    
    public void SendEventFailed(TapjoyEvent tapjoyEvent, string error)
    {
        Debug.Log("C#: SendEventFailed for event: " + tapjoyEvent.GetName() + " with error: " + error);
    }
    
    public void ContentDidAppear(TapjoyEvent tapjoyEvent)
    {
        Debug.Log("C#: ContentDidAppear for event: " + tapjoyEvent.GetName());
    }
    
    public void ContentDidDisappear(TapjoyEvent tapjoyEvent)
    {
        Debug.Log("C#: ContentDidDisappear for event: " + tapjoyEvent.GetName());
        
        // Pre-load next event if direct play event
        if (tapjoyEvent.GetName() == diectPlayEvent.GetName()) {
            diectPlayEvent = new TapjoyEvent("video_unit", this);
            diectPlayEvent.EnablePreload(true);
            diectPlayEvent.Send();
            tapPointsLabel = "Loading next direct play event.";
        }
    }
    
    public void DidRequestAction(TapjoyEvent tapjoyEvent, TapjoyEventRequest request)
    {
        Debug.Log("C#: DidRequestAction type:" + request.type + ", identifier:" + request.identifier + ", quantity:" + request.quantity);
        
        /*
        // Your app should perform an action based on the value of the request.type property
        switch(request.type){
            case TapjoyEventRequest.TYPE_IN_APP_PURCHASE:
                // Your app should initiate an in-app purchase of the product identified by request.identifier
                break;
            case TapjoyEventRequest.TYPE_VIRTUAL_GOOD:
                // Your app should award the user the item specified by request.identifier with the amount specified by request.quantity
                break;
            case TapjoyEventRequest.TYPE_CURRENCY:
                // The user has been awarded the currency specified with request.identifier, with the amount specified by request.quantity
                break;
            case TapjoyEventRequest.TYPE_NAVIGATION:
                // Your app should attempt to navigate to the location specified by request.identifier
                break;
        }
        */
        
        // Your app must call either EventRequestCompleted() or EventRequestCancelled() to complete the lifecycle of the request
        request.EventRequestCompleted();
    }
    
    #endregion
    
    #region GUI for sample app
    
    public void ResetTapPointsLabel()
    {
        tapPointsLabel = "Updating Tap Points...";
    }
    

    
    #endregion
}