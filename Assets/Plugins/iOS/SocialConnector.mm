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

@interface SocialActivity : UIActivity

- (id)initWithName:(NSString *)title scheme:(NSString *)scheme bundleIdentifier:(NSString *)bundleIdentifier;

+ (id)_activityFunctionImage:(id)arg1;

+ (id)_activityGenericImage:(id)arg1;

+ (id)_activityImageForApplication:(id)arg1;
@end

@implementation SocialActivity

NSString *_title;
NSString *_scheme;
NSString *_bundleIdentifier;
NSArray *_activityItems;

void *(^_myblock)(void);

+ (UIActivityCategory)activityCategory {
    return UIActivityCategoryShare;
}

- (id)initWithTitle:(NSString *)title scheme:(NSString *)scheme bundleIdentifier:(NSString *)bundleIdentifier action:myblock {
    _title = title;
    _scheme = scheme;
    _bundleIdentifier = bundleIdentifier;
    _myblock = [myblock copy];
    return self;
}

- (BOOL)isInstalled {
    return [[UIApplication sharedApplication] canOpenURL:[NSURL URLWithString:_scheme]];
}

- (NSString *)activityType {
    return _bundleIdentifier;
}

- (NSString *)activityTitle {
    return _title;
}

- (UIImage *)_activityImage {
    if ([self isInstalled])
        return [NSClassFromString(@"UIActivity") _activityImageForApplication:_bundleIdentifier];
    else {
        return nil;
    }
}

- (BOOL)canPerformWithActivityItems:(NSArray *)activityItems {
    return YES;

}

- (void)prepareWithActivityItems:(NSArray *)activityItems; {
    _activityItems = activityItems;
    [super prepareWithActivityItems:activityItems];
}

- (UIViewController *)activityViewController {
    return nil;
}

- (void)performActivity {

    _myblock();

    [self activityDidFinish:YES];
}

- (void)activityDidFinish:(BOOL)completed {
    [super activityDidFinish:completed];
}
@end

void SocialConnector_Share(const char *text, const char *url, const char *textureURL) {

    NSString *_text = [NSString stringWithUTF8String:text ? text : ""];
    NSString *_url = [NSString stringWithUTF8String:url ? url : ""];
    NSString *_textureURL = [NSString stringWithUTF8String:textureURL ? textureURL : ""];

    UIImage *image = nil;

    if ([_textureURL length] != 0) {
        image = [UIImage imageWithContentsOfFile:_textureURL];
    }

    NSArray *actItems = [NSArray arrayWithObjects:_text, _url, image, nil];

    SocialActivity *social = [[[SocialActivity alloc] initWithTitle:@"LINE" scheme:@"line://" bundleIdentifier:@"jp.naver.line" action:^() {

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
                contentKey = [contentKey stringByAppendingFormat:@" - %@", _url];
            }
        }

        NSString *lineUrlString = [NSString stringWithFormat:@"line://msg/%@/%@", contentType, contentKey];

        lineUrlString = [lineUrlString stringByAddingPercentEscapesUsingEncoding:NSUTF8StringEncoding];

        [[UIApplication sharedApplication] openURL:[NSURL URLWithString:lineUrlString]];

    }] autorelease];

    NSArray *myItems = [NSArray arrayWithObjects:social, nil];
    UIActivityViewController *activityView = [[[UIActivityViewController alloc] initWithActivityItems:actItems applicationActivities:myItems] autorelease];

    [UnityGetGLViewController() presentViewController:activityView animated:YES completion:nil];
}

}