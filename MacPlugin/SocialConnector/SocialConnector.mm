//
//  SocialConnector.mm
//  Mac Plugin用
//
//  Created by Keigo Ando on 2014/02/07.
//  Copyright (c) 2014年 Keigo Ando. All rights reserved.
//

#define TWITTER 0
#define FACEBOOK 1
#define LINE 2

extern "C"{

    void SocialConnector_PostMessage(const int *type, const char *text, const char *url, const char *textureURL) {

        if(type == (int const *) LINE) {
            return;
        }

        NSString *_text = [NSString stringWithUTF8String:text ? text : ""];
        NSString *_url = [NSString stringWithUTF8String:url ? url : ""];
        NSString *_textureURL = [NSString stringWithUTF8String:textureURL ? textureURL : ""];

        if ([_url length] != 0) {
            _text = [_text stringByAppendingFormat:@" - %@", _url];
        }

        NSImage *image = nil;

        if ([_textureURL length] != 0) {
            image = [[NSImage alloc]initWithContentsOfFile:_textureURL];
        }

        NSArray *items = [NSArray arrayWithObjects:_text,image, nil];

        NSString *shareName;

        if(type == (int const *)TWITTER){
            shareName = NSSharingServiceNamePostOnTwitter;
        }else if (type == (int const *)FACEBOOK){
            shareName = NSSharingServiceNamePostOnFacebook;
        }

        NSSharingService *service = [NSSharingService sharingServiceNamed:shareName];
        [service performWithItems:items];
    }
}