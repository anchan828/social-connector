Social Connector v0.1.1
================

1つのAPIでTwitter/Facebookにポスト出来るUnityプラグインです。

![Twitter](http://cloud.github.com/downloads/anchan828/social-connector/2012-12-09%2002.07.06.png)


# Requirements
## iOS
* **iOS6.0+** :  using Social.framework 

## Android
* Android 2.1+

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
	
```

# Example

See  [Assets/Plugins/SocialConnector/Sample/Sample.cs](https://github.com/anchan828/social-connector/blob/master/Assets/Plugins/SocialConnector/Sample/Sample.cs)

![Scene](http://cloud.github.com/downloads/anchan828/social-connector/SC20121209-010949.png)

```
	void OnGUI ()
	{
		///=================
		/// Twitter
		///=================
	
		if (GUILayout.Button ("<size=50><b>Twitter</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter);
		}
		if (GUILayout.Button ("<size=50><b>Twitter text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter, "text");
		}
		if (GUILayout.Button ("<size=50><b>Twitter text&url</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter, "text", "http://japan.unity3d.com/");
		}
		
		///=================
		/// Facebook
		///=================
		
		if (GUILayout.Button ("<size=50><b>Facebook</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook);
		}
		if (GUILayout.Button ("<size=50><b>Facebook text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "text");
		}
		if (GUILayout.Button ("<size=50><b>Facebook text&url</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "text", "http://japan.unity3d.com/");
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

* Support iOS4.3 - iOS5.1
* Post Image


![iOS-Facebook](http://cloud.github.com/downloads/anchan828/social-connector/2012-12-09%2002.07.18.png)
![Android-Twitter](http://cloud.github.com/downloads/anchan828/social-connector/SC20121209-010941.png)
![Android-Facebook](http://cloud.github.com/downloads/anchan828/social-connector/SC20121209-011757.png)
![Android](http://cloud.github.com/downloads/anchan828/social-connector/SC20121209-010925.png)