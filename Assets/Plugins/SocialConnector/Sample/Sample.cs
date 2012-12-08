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
}
