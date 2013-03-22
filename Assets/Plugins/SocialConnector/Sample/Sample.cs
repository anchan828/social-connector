using UnityEngine;

public class Sample : MonoBehaviour
{
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
		
		///=================
		/// LINE
		///=================
		
		if (GUILayout.Button ("<size=50><b>LINE</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Line);
		}
		if (GUILayout.Button ("<size=50><b>LINE text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Line, "text");
		}
		if (GUILayout.Button ("<size=50><b>LINE text&url</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Line, "text", "http://japan.unity3d.com/");
		}
	}
}
