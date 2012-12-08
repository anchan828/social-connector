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

BOOL IsAvailableForServiceType_(const int *type) {
    return [SLComposeViewController isAvailableForServiceType:type == 0 ? SLServiceTypeTwitter : SLServiceTypeFacebook];
}

void PostMessage_(const int *type, const char *text, const char *url) {

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
    [composeViewController actionForLayer:<#(CALayer *)layer#> forKey:<#(NSString *)event#>]
    [composeViewController setInitialText:[NSString stringWithUTF8String:text ? text : ""]];
    [composeViewController addURL:[NSURL URLWithString:[NSString stringWithUTF8String:url ? url : ""]]];
    [UnityGetGLViewController() presentViewController:composeViewController animated:YES completion:nil];
}

}
