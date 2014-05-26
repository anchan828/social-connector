Social Connector v0.2.9
================

1つのAPIでTwitter/Facebook/LINEにポスト出来るUnityプラグインです。

## 追加 v0.2.9 **SocialConnector.Share**

```
SocialConnector.Share("Social Connector", "https://github.com/anchan828/social-connector", imagePath);
```


![](https://dl.dropboxusercontent.com/u/153254465/screenshot/2014-05-26%2017.16.23.png)


**注意:** Android版のFacebookアプリはACTION_SENDを許可していないので使用できません。


![Twitter](https://dl.dropboxusercontent.com/u/153254465/screenshot/2014-01-15%2001.01.26.png)


# Requirements
## iOS
* **iOS6.0+** :  using Social.framework 

## Android
* Android 2.3+

# Usage



```
///=================
/// Twitter
///=================
		
SocialConector.PostMessage ( SocialConector.ServiceType.Twitter, "text" );


///=================
/// Facebook
///=================

SocialConector.PostMessage ( SocialConector.ServiceType.Facebook, "text" );

///=================
/// LINE
///=================

SocialConector.PostMessage ( SocialConector.ServiceType.Line, "text" );	
	
```

# Example

See  [Assets/Plugins/SocialConnector/Sample/Sample.cs](https://github.com/anchan828/social-connector/blob/master/Assets/Plugins/SocialConnector/Sample/Sample.cs)

![Scene](https://dl.dropboxusercontent.com/u/153254465/screenshot/2014-01-15%2000.59.23.png)

```
using UnityEngine;

public class Sample : MonoBehaviour
{
	string imagePath {
		get {

#if UNITY_EDITOR_OSX
			return Application.dataPath +"/../image.png";
#endif

#if UNITY_STANDALONE_OSX
			return Application.dataPath +"/Data/image.png";
#endif

			return  Application.persistentDataPath + "/image.png";
		}
	}

	void OnGUI ()
	{
		GUILayout.Label(System.DateTime.Now.ToString());
		GUILayout.Label (imagePath);

		if (GUILayout.Button ("Take")) {
			Application.CaptureScreenshot ("image.png");
		}

		///=================
		/// Twitter
		///=================

		GUILayout.Label ("<size=40><b>Twitter</b></size>");
		if (GUILayout.Button ("<size=40><b>Text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter, "Social Connector");
		}
		if (GUILayout.Button ("<size=40><b>Text & URL</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter, "Social Connector", "https://github.com/anchan828/social-connector");
		}

		if (GUILayout.Button ("<size=40><b>Text & URL & Image</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter, "Social Connector", "https://github.com/anchan828/social-connector", imagePath);
		}
		
		///=================
		/// Facebook
		///=================
		
		GUILayout.Label ("<size=40><b>Facebook</b></size>");

		if (GUILayout.Button ("<size=40><b>Text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "Social Connector");
		}
		if (GUILayout.Button ("<size=40><b>Text & URL</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "Social Connector", "https://github.com/anchan828/social-connector");
		}
		if (GUILayout.Button ("<size=40><b>Text & URL & Image</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "Social Connector", "https://github.com/anchan828/social-connector", imagePath);
		}

		#if !UNITY_STANDALONE_OSX
		///=================
		/// LINE
		///=================
		
		GUILayout.Label ("<size=40><b>LINE</b></size>");

		if (GUILayout.Button ("<size=40><b>Text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Line, "text");
		}
		if (GUILayout.Button ("<size=40><b>Text & URL</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Line, "text", "http://japan.unity3d.com/");
		}

		if (GUILayout.Button ("<size=40><b>Image</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Line, "", "", imagePath);
		}

		#endif
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

# Future

See [Issue](https://github.com/anchan828/social-connector/issues?state=open)