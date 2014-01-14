using UnityEngine;

public class Sample : MonoBehaviour
{
	string imagePath {
		get {
			return  Application.persistentDataPath + "/image.png";
		}
	}

	void OnGUI ()
	{
		GUILayout.Label (imagePath);

		if (GUILayout.Button ("Take")) {
			Application.CaptureScreenshot ("image.png");
		}

		///=================
		/// Twitter
		///=================

		GUILayout.Label ("<size=50><b>Twitter</b></size>");
		if (GUILayout.Button ("<size=50><b>Text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter, "Social Connector");
		}
		if (GUILayout.Button ("<size=50><b>Text & URL</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter, "Social Connector", "https://github.com/anchan828/social-connector");
		}

		if (GUILayout.Button ("<size=50><b>Text & URL & Image</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter, "Social Connector", "https://github.com/anchan828/social-connector", imagePath);
		}
		
		///=================
		/// Facebook
		///=================
		
		GUILayout.Label ("<size=50><b>Facebook</b></size>");

		if (GUILayout.Button ("<size=50><b>Text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "Social Connector");
		}
		if (GUILayout.Button ("<size=50><b>Text & URL</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "Social Connector", "https://github.com/anchan828/social-connector");
		}
		if (GUILayout.Button ("<size=50><b>Text & URL & Image</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "Social Connector", "https://github.com/anchan828/social-connector", imagePath);
		}
		
		///=================
		/// LINE
		///=================
		
		GUILayout.Label ("<size=50><b>LINE</b></size>");

		if (GUILayout.Button ("<size=50><b>Text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Line, "text");
		}
		if (GUILayout.Button ("<size=50><b>Text & URL</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Line, "text", "http://japan.unity3d.com/");
		}
	}
}
