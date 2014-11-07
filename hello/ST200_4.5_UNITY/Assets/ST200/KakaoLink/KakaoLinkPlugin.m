//
//  KakaoLinkPlugin.m
//  Unity-iPhone
//
//  Created by Macbook on 2014. 11. 4..
//
//

#import <Foundation/Foundation.h>
#import <KakaoOpenSDK/KakaoOpenSDK.h>


NSMutableDictionary *kakaoTalkLinkObjects;

void iOS_InitKakaoLink( char* imageURL, char* linkText, char* linkBntText )
{
    NSLog( @"TestKakaoLink" );
    UnitySendMessage( "KakaoLink_IOS", "TestLog", "Hello XCode" );
    //iOS_SendKakaoLink();
}

bool iOS_SendKakaoLink( char* imageURL, char* linkText, char* linkBntText )
{
    kakaoTalkLinkObjects = [[NSMutableDictionary alloc]init];
    
    NSString *key = @"label";
    NSString *nsLinkText = [NSString stringWithUTF8String:linkText];
    
    KakaoTalkLinkObject *label = [KakaoTalkLinkObject createLabel:nsLinkText];
    
    [kakaoTalkLinkObjects setObject:label forKey:key];
    
    
    NSString *key2 = @"image";
    NSString *nsLinkImageUrl = [NSString stringWithUTF8String:imageURL];
    KakaoTalkLinkObject *image = [KakaoTalkLinkObject createImage:nsLinkImageUrl
                                                            width:138
                                                           height:80];
    
    [kakaoTalkLinkObjects setObject:image forKey:key2];
    
    
    KakaoTalkLinkAction *androidAppAction = [KakaoTalkLinkAction createAppAction:KakaoTalkLinkActionOSPlatformAndroid
                                                                      devicetype:KakaoTalkLinkActionDeviceTypePhone
                                                                       execparam:nil];
    
    KakaoTalkLinkAction *iphoneAppAction = [KakaoTalkLinkAction createAppAction:KakaoTalkLinkActionOSPlatformIOS
                                                                     devicetype:KakaoTalkLinkActionDeviceTypePhone
                                                                      execparam:nil];
    
    
    NSString *key3 = @"button";
    NSString *nsBtnText = [NSString stringWithUTF8String:linkBntText];
    KakaoTalkLinkObject *buttonObj = [KakaoTalkLinkObject createAppButton:nsBtnText
                                                                  actions:@[androidAppAction, iphoneAppAction]];
    
    [kakaoTalkLinkObjects setObject:buttonObj forKey:key3];
    
    
    
    if ([KOAppCall canOpenKakaoTalkAppLink])
    {
        [KOAppCall openKakaoTalkAppLink:[kakaoTalkLinkObjects allValues]];
        return true;
    }
    else
    {
        return false;
    }
}

