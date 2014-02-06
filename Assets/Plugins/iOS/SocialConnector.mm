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

#define TWITTER 0
#define FACEBOOK 1
#define LINE 2

extern "C" {
    
    void SocialConnector_PostMessage(const int *type, const char *text, const char *url, const char *textureURL) {
        
        NSString *_text = [NSString stringWithUTF8String:text ? text : ""];
        NSString *_url = [NSString stringWithUTF8String:url ? url : ""];
        NSString *_textureURL = [NSString stringWithUTF8String:textureURL ? textureURL : ""];
        
        
        if (type == (int const *) LINE) {
            NSString *contentType;
            NSString *contentKey;
            
            if ([_textureURL length] != 0) {
                UIImage *image = [UIImage imageWithContentsOfFile:_textureURL];
                if (image == nil) {
                    return;
                }
                
                UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];
                pasteboard.image = image;
                contentType = @"image";
                contentKey = pasteboard.name;
                
            } else if ([_text length] != 0) {
                contentType = @"text";
                contentKey = _text;
                
                if ([_url length] != 0) {
                    contentKey = [contentKey stringByAppendingFormat:@"%%20%%2d%%20%@", _url];
                }
            }
            
            NSURL *lineUrl = [NSURL URLWithString:[NSString stringWithFormat:@"line://msg/%@/%@", contentType, contentKey]];
            
            [[UIApplication sharedApplication] openURL:lineUrl];
            
        } else {
            
            SLComposeViewController *composeViewController = [SLComposeViewController composeViewControllerForServiceType:type == TWITTER ? SLServiceTypeTwitter : SLServiceTypeFacebook];
            
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
}
