//
//  TnkAdUnityDelegate
//  spaceship
//
//  Created by Hyeongdo Kim on 2014. 2. 28..
//
//

#import <Foundation/Foundation.h>
#import "tnksdk.h"

@interface TnkAdUnityDelegate : NSObject <TnkAdViewDelegate> {
    NSString *handleName;
    
}

@property (nonatomic, retain) NSString *handleName;

- (id) initWithHandleName:(NSString *)hname;

- (void)onReturnQueryPoint:(NSNumber *)point;
- (void)onReturnPurchaseItem:(NSNumber *)point seqId:(NSNumber *)seqId;
- (void)onReturnQueryPublishState:(NSNumber *)state;

+ (TnkAdUnityDelegate *) sharedInstance:(NSString *)hname;

@end