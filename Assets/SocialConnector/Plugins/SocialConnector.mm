//
//  SocialConnector.mm
//  Unity-iPhone
//
//  Created by Ando Keigo on 2012/12/08.
//
//
#if UNITY_VERSION <= 434
#import "iPhone_View.h"
#endif
extern "C" {

    void SocialConnector_Share(const char *text, const char *url, const char *textureURL) {
    
        NSString *_text = [NSString stringWithUTF8String:text ? text : ""];
        NSString *_url = [NSString stringWithUTF8String:url ? url : ""];
        NSString *_textureURL = [NSString stringWithUTF8String:textureURL ? textureURL : ""];
    
        UIImage *image = nil;
    
        if ([_textureURL length] != 0) {
            image = [UIImage imageWithContentsOfFile:_textureURL];
        }
    
        NSArray *actItems = [NSArray arrayWithObjects:_text, _url, image, nil];
    
        UIActivityViewController *activityView = [[[UIActivityViewController alloc] initWithActivityItems:actItems applicationActivities: nil] autorelease];
    
        if(floorf(NSFoundationVersionNumber) > NSFoundationVersionNumber_iOS_7_1)
            activityView.popoverPresentationController.sourceView = UnityGetGLViewController().view;
    
        [UnityGetGLViewController() presentViewController:activityView animated:YES completion:nil];
    }

}