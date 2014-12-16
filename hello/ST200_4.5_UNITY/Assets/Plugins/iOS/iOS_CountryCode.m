//
//  iOS_CountryCode.m
//  Unity-iPhone
//
//  Created by Macbook on 2014. 12. 11..
//
//

#import <Foundation/Foundation.h>

void iOS_CountrySetting()
{
    NSLocale *locale = [NSLocale currentLocale];
    NSString *countryCode = [locale objectForKey:NSLocaleCountryCode];
    
    UnitySendMessage( "_Managers", "SetiOSCountryCode", [countryCode UTF8String] );
    
    NSLog( @"hi");
}
