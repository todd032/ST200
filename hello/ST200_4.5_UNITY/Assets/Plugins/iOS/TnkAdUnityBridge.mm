//
//  TnkAdUnityBridge.mm
//  Unity-iPhone
//
//  Created by Hyeongdo Kim on 2014. 8. 7..
//
//

#import "tnksdk.h"
#import "TnkAdUnityDelegate.h"

#ifdef UNITY_4_2_0
    #import "UnityAppController.h"
#else
    #import "AppController.h"
#endif

extern "C" {

    void applicationStarted_UnityBridge() {
        //NSLog(@"applicationStarted_UnityBridge");
        [[TnkSession sharedInstance] applicationStarted];
    }
    
    void actionCompleted_UnityBridge(const char* actionName) {
        //NSLog(@"actionCompleted_UnityBridge");
        NSString *actionString = nil;
        if (actionName != NULL) {
            actionString = [NSString stringWithUTF8String:actionName];
        }
        
        [[TnkSession sharedInstance] actionCompleted:actionString];
    }
    
    void buyCompleted_UnityBridge(const char* itemName) {
        //NSLog(@"buyCompleted_UnityBridge");
        NSString *itemString = [NSString stringWithUTF8String:itemName];
        
        [[TnkSession sharedInstance] buyCompleted:itemString];
    }
    
    void prepareInterstitialAd_UnityBridge(const char* logicName, const char* hname) {
        //NSLog(@"prepareInterstitialAd_UnityBridge");
        NSString *logicNameString = [NSString stringWithUTF8String:logicName];
        
        TnkAdUnityDelegate *delegate = nil;
        if (hname != NULL) {
            delegate = [TnkAdUnityDelegate sharedInstance:[NSString stringWithUTF8String:hname]];
        }
        else {
            // set default delegate
            delegate = [TnkAdUnityDelegate sharedInstance:@"__tnk_default__"];
        }
        
        [[TnkSession sharedInstance] prepareInterstitialAd:logicNameString delegate:delegate];
    }
    
    void showInterstitialAd_UnityBridge() {
        //NSLog(@"showInterstitialAd_UnityBridge");
        [[TnkSession sharedInstance] showInterstitialAd];
    }
    
    void showAdList_UnityBridge(const char* title, const char* hname) {
        //NSLog(@"showAdList_UnityBridge %s %s", title, hname);
        
        NSString *titleString = nil;
        if (title != NULL) {
            titleString = [NSString stringWithUTF8String:title];
        }
        
        TnkAdUnityDelegate *delegate = nil;
        if (hname != NULL) {
            delegate = [TnkAdUnityDelegate sharedInstance:[NSString stringWithUTF8String:hname]];
        }
        else {
            // set default delegate
            delegate = [TnkAdUnityDelegate sharedInstance:@"__tnk_default__"];
        }
        
        UIWindow *window = [[UIApplication sharedApplication] keyWindow];
        [[TnkSession sharedInstance] showAdListAsModal:window.rootViewController title:titleString delegate:delegate];
        
        UnityPause(true);
    }
    
    void queryPoint_UnityBridge(const char* hname) {
        NSString *handlerName = [NSString stringWithUTF8String:hname];
        TnkAdUnityDelegate *delegate = [TnkAdUnityDelegate sharedInstance:handlerName];
        
        [[TnkSession sharedInstance] queryPoint:delegate action:@selector(onReturnQueryPoint:)];
    }
    
    void purchaseItem_UnityBridge(int cost, const char* itemName, const char* hname) {
        //NSLog(@"purchaseItem_UnityBridge %d %s %s", cost, itemName, hname);
        
        NSString *itemNameString = [NSString stringWithUTF8String:itemName];
        NSString *handlerName = [NSString stringWithUTF8String:hname];
        TnkAdUnityDelegate *delegate = [TnkAdUnityDelegate sharedInstance:handlerName];
        
        [[TnkSession sharedInstance] purchaseItem:itemNameString cost:cost target:delegate action:@selector(onReturnPurchaseItem:seqId:)];
        
    }
    
    void queryPublishState_UnityBridge(const char* hname) {
        NSString *handlerName = [NSString stringWithUTF8String:hname];
        TnkAdUnityDelegate *delegate = [TnkAdUnityDelegate sharedInstance:handlerName];
        
        [[TnkSession sharedInstance] queryPublishState:delegate action:@selector(onReturnQueryPoint:)];
    }
    
    void setUserName_UnityBridge(const char* userName) {
        if (userName != NULL) {
            NSString *userNameString = [NSString stringWithUTF8String:userName];
            [[TnkSession sharedInstance] setUserName:userNameString];
        }
    }

    void setUserAge_UnityBridge(int age) {
        [[TnkSession sharedInstance] setUserAge:age];
    }
    
    void setUserGender_UnityBridge(int gender) {
        if (gender == 0) {
            [[TnkSession sharedInstance] setUserGender:@"M"];
        }
        else if (gender == 1) {
            [[TnkSession sharedInstance] setUserGender:@"F"];
        }
        
    }
}