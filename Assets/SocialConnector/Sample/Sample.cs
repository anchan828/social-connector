using UnityEngine;
using System.Collections;

public class Sample : MonoBehaviour
{
	GUIStyle style = null;

	void Awake ()
	{
		style = new GUIStyle ();
		style.richText = true;
	}

	void OnGUI ()
	{
		///=================
		/// Twitter
		///=================
	
		if (GUILayout.Button ("<size=50><b>ConnectTwitter</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter);
		}
		if (GUILayout.Button ("<size=50><b>ConnectTwitter text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter,"text");
		}
		if (GUILayout.Button ("<size=50><b>ConnectTwitter text&url</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter,"text","http://japan.unity3d.com/");
		}
		
		///=================
		/// Facebook
		///=================
		
		if (GUILayout.Button ("<size=50><b>ConnectFacebook</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook);
		}
		if (GUILayout.Button ("<size=50><b>ConnectFacebook text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "text");
		}
		if (GUILayout.Button ("<size=50><b>ConnectFacebook text&url</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "text", "http://japan.unity3d.com/");
		}
		
	}
}
