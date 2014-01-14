//
//  SocialConnector.mm
//  Unity-iPhone
//
//  Created by Ando Keigo on 2012/12/08.
//
//
#import <QuartzCore/QuartzCore.h>
#import "iPhone_View.h"
#import "Social/Social.h"


extern "C" {
    
    BOOL SocialConnector_IsAvailableForServiceType(const int *type) {
        return [SLComposeViewController isAvailableForServiceType:type == 0 ? SLServiceTypeTwitter : SLServiceTypeFacebook];
    }
    
    void SocialConnector_PostMessage(const int *type, const char *text, const char *url, const char *textureURL) {
        
        NSString *_text = [NSString stringWithUTF8String:text ? text : ""];
        NSString *_url = [NSString stringWithUTF8String:url ? url : ""];
        NSString *_textureURL = [NSString stringWithUTF8String:textureURL ? textureURL : ""];
        
        SLComposeViewController *composeViewController = [SLComposeViewController composeViewControllerForServiceType:type == 0 ? SLServiceTypeTwitter : SLServiceTypeFacebook];
        
        composeViewController.completionHandler = ^(SLComposeViewControllerResult res) {
            if (res == SLComposeViewControllerResultCancelled) {
                // Cancel
                // UnitySendMessage(<#(char const *)obj#>, <#(char const *)method#>, <#(char const *)msg#>)
            }
            else if (res == SLComposeViewControllerResultDone) {
                // done!
                // UnitySendMessage(<#(char const *)obj#>, <#(char const *)method#>, <#(char const *)msg#>)
            }
            [composeViewController dismissViewControllerAnimated:YES completion:nil];
        };
        
        if ([_text length] != 0) {
            [composeViewController setInitialText:_text];
        }
        if ([_url length] != 0) {
            [composeViewController addURL:[NSURL URLWithString:_url]];
        }
        if ([_textureURL length] != 0) {
            UIImage *image = [UIImage imageWithContentsOfFile:_textureURL];
            if (image != nil) {
                [composeViewController addImage:image];
            }
        }
        
        [UnityGetGLViewController() presentViewController:composeViewController animated:YES completion:nil];
    }
    
}
