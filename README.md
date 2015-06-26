Social Connector v0.3.6
================

**Unity 4.x の方は [v0.3.5](https://github.com/anchan828/social-connector/releases/tag/v0.3.5) を使用してください。**

1つのAPIでTwitter/Facebook/LINEにポスト出来るUnityプラグインです。

今まで使用していたPostMessageを使用したい方は[こちら](https://github.com/anchan828/social-connector/releases/tag/v0.2.9)


**注意:** Facebookは事前のテキスト挿入を許可していないのでテキストの共有できません。 [https://developers.facebook.com/docs/apps/review/prefill](https://developers.facebook.com/docs/apps/review/prefill)

# Requirements

## iOS
* **iOS6.0+** 

## Android
* Android 2.3+

# Usage

```
SocialConnector.Share("Social Connector", "https://github.com/anchan828/social-connector", imagePath);
```


# やらないといけないこと

iOSプロジェクトに[LINEアイコン画像](http://line.me/logo/ja)を含めなければいけません。デフォルトではダミー画像となっています。なので差し替えてください。

サイズ(px)|iOS6|iOS7|iOS8|ファイル名|用途
:---|:---:|:---:|:---:|:---|:---
57x57|○|-|-|LINE_icon01-57~iphone.png|iPhone
114x114|○|-|-|LINE_icon01-57@2x~iphone.png|iPhone
120x120|-|○|-|LINE_icon01-60@2x~iphone.png|iPhone
180x180|-|-|○|LINE_icon01-60@3x~iphone.png|iPhone
72x72|○|-|-|LINE_icon01-72~ipad.png|iPad
144x144|○|○|○|LINE_icon01-72@2x~ipad.png|iPad



![](https://dl.dropboxusercontent.com/u/153254465/screenshot2/ss%202014-12-29%2013.46.57.png)

ファイル名は固定です。変更したい場合は`Contents.json`内を編集してください。

# Example


See  [Assets/Plugins/SocialConnector/Sample/Sample.cs](https://github.com/anchan828/social-connector/blob/master/Assets/Plugins/SocialConnector/Sample/Sample.cs)

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/2014-05-26%2018.23.09.png)

```
using UnityEngine;

public class Sample : MonoBehaviour
{
    string imagePath
    {
        get
        {
            return Application.persistentDataPath + "/image.png";
        }
    }

    void OnGUI()
    {

        if (GUILayout.Button("<size=30><b>Take</b></size>", GUILayout.Height(60)))
        {
            Application.CaptureScreenshot("image.png");
        }

        GUILayout.Space(60);

        ///=================
        /// Share
        ///=================

        if (GUILayout.Button("<size=30><b>Share</b></size>", GUILayout.Height(60)))
        {
            SocialConnector.Share("Social Connector", "https://github.com/anchan828/social-connector", null);
        }
        if (GUILayout.Button("<size=30><b>Share Image</b></size>", GUILayout.Height(60)))
        {
            SocialConnector.Share("Social Connector", "https://github.com/anchan828/social-connector", imagePath);
        }
    }
}
```

# LICENSE

```
Copyright (C) 2011 Keigo Ando

This software is provided 'as-is', without any express or implied
warranty.  In no event will the authors be held liable for any damages
arising from the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:

1. The origin of this software must not be misrepresented; you must not
   claim that you wrote the original software. If you use this software
   in a product, an acknowledgment in the product documentation would be
   appreciated but is not required.
2. Altered source versions must be plainly marked as such, and must not be
   misrepresented as being the original software.
3. This notice may not be removed or altered from any source distribution.

```
