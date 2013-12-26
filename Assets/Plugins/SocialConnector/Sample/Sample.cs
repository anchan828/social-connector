using UnityEngine;

public class Sample : MonoBehaviour
{
	string imagePath {
		get {
			return  Application.persistentDataPath + "/image.png";
		}
	}

	void Start ()
	{
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

		if (GUILayout.Button ("Twitter")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter);
		}
		if (GUILayout.Button ("Twitter<size=50><b> text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter, "text");
		}
		if (GUILayout.Button ("Twitter<size=50><b> text&url</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter, "text", "http://japan.unity3d.com/");
		}

		if (GUILayout.Button ("Twitter<size=50><b> text&url&image</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Twitter, "text", "http://japan.unity3d.com/", imagePath);
		}
		
		///=================
		/// Facebook
		///=================
		
		if (GUILayout.Button ("Facebook")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook);
		}
		if (GUILayout.Button ("Facebook<size=50><b> text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "text");
		}
		if (GUILayout.Button ("Facebook<size=50><b> text&url</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Facebook, "text", "http://japan.unity3d.com/");
		}
		
		///=================
		/// LINE
		///=================
		
		if (GUILayout.Button ("LINE")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Line);
		}
		if (GUILayout.Button ("LINE<size=50><b> text</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Line, "text");
		}
		if (GUILayout.Button ("LINE<size=50><b> text&url</b></size>")) {
			SocialConector.PostMessage (SocialConector.ServiceType.Line, "text", "http://japan.unity3d.com/");
		}
	}
}
