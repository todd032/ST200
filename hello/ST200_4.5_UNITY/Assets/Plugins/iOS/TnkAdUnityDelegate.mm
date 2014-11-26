//
//  TnkAdCocos2dxDelegate.m
//  spaceship
//
//  Created by Hyeongdo Kim on 2014. 2. 28..
//
//

#import "TnkAdUnityDelegate.h"

#ifdef UNITY_4_2_0
    #import "UnityAppController.h"
#else
    #import "AppController.h"
#endif

static NSMutableDictionary *sharedInstance = nil;

@implementation TnkAdUnityDelegate
@synthesize handleName;

+ (TnkAdUnityDelegate *) sharedInstance:(NSString *)hname {
    TnkAdUnityDelegate *delegate = nil;
    
    @synchronized(self) {
        if (sharedInstance == nil) {
            sharedInstance = [[NSMutableDictionary alloc] init];
        }
        
        delegate = [sharedInstance objectForKey:hname];
        
        if (delegate == nil) {
            delegate = [[TnkAdUnityDelegate alloc] initWithHandleName:hname];
            
            if (delegate != nil) {
                [sharedInstance setObject:delegate forKey:hname];
            }
        }
    }
    
    return delegate;
}

- (id) initWithHandleName:(NSString *)hname {
    self = [super init];
    
    if (self) {
        self.handleName = hname;
    }
    
    return self;
}

- (void) dealloc {
    [handleName release];
    
    [super dealloc];
}

#pragma mark - TnkAdViewDelegate

- (void)adViewDidClose:(int)type {
    //NSLog(@"### didClose %@ %d", handleName, type);
    UnityPause(false);
    if (![handleName isEqualToString:@"__tnk_default__"]) {
        NSString *param = [NSString stringWithFormat:@"%d", type];
        UnitySendMessage(handleName.UTF8String, "onCloseBinding", param.UTF8String);
    }
}

- (void)adViewDidFail:(int)errCode {
    //NSLog(@"### didFail %@ %d", handleName, errCode);
    if (![handleName isEqualToString:@"__tnk_default__"]) {
        NSString *param = [NSString stringWithFormat:@"%d", errCode];
        UnitySendMessage(handleName.UTF8String, "onFailureBinding", param.UTF8String);
    }
}

- (void)adViewDidShow {
    //NSLog(@"### didShow %@", handleName);
    UnityPause(true);
    if (![handleName isEqualToString:@"__tnk_default__"]) {
        UnitySendMessage(handleName.UTF8String, "onShowBinding", "0");
    }
}

- (void)adViewDidLoad {
    //NSLog(@"### didLoad %@", handleName);
    UnityPause(false);
    if (![handleName isEqualToString:@"__tnk_default__"]) {
        UnitySendMessage(handleName.UTF8String, "onLoadBinding", "0");
    }
}

- (void)adListViewClosed {
    //NSLog(@"### adListViewClosed %@", handleName);
    UnityPause(false);
    if (![handleName isEqualToString:@"__tnk_default__"]) {
        UnitySendMessage(handleName.UTF8String, "onCloseBinding", "0");
    }
}

#pragma mark - ServiceCallback

- (void)onReturnQueryPoint:(NSNumber *)point {
    //NSLog(@"### onReturnQueryPoint %@ %d", handleName, [point integerValue]);
    UnitySendMessage(handleName.UTF8String, "onReturnQueryPointBinding", [point stringValue].UTF8String);
}

- (void)onReturnPurchaseItem:(NSNumber *)point seqId:(NSNumber *)seqId {
    //NSLog(@"### onReturnPurchaseItem %@ %d %d", handleName, [point integerValue], [seqId integerValue]);
    NSString *param = [NSString stringWithFormat:@"%ld,%ld", [point longValue], [seqId longValue]];
    UnitySendMessage(handleName.UTF8String, "onReturnPurchaseItemBinding", param.UTF8String);
}

- (void)onReturnQueryPublishState:(NSNumber *)state {
    //NSLog(@"### onReturnQueryPublishState %@ %d", handleName, [state integerValue]);
    UnitySendMessage(handleName.UTF8String, "onReturnQueryPublishStateBinding", [state stringValue].UTF8String);
}

@end
