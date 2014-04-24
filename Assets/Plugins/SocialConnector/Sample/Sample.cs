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
			SocialConnector.PostMessage (SocialConnector.ServiceType.Twitter, "Social Connector");
		}
		if (GUILayout.Button ("<size=40><b>Text & URL</b></size>")) {
			SocialConnector.PostMessage (SocialConnector.ServiceType.Twitter, "Social Connector", "https://github.com/anchan828/social-connector");
		}

		if (GUILayout.Button ("<size=40><b>Text & URL & Image</b></size>")) {
			SocialConnector.PostMessage (SocialConnector.ServiceType.Twitter, "Social Connector", "https://github.com/anchan828/social-connector", imagePath);
		}
		
		///=================
		/// Facebook
		///=================
		
		GUILayout.Label ("<size=40><b>Facebook</b></size>");

		if (GUILayout.Button ("<size=40><b>Text</b></size>")) {
			SocialConnector.PostMessage (SocialConnector.ServiceType.Facebook, "Social Connector");
		}
		if (GUILayout.Button ("<size=40><b>Text & URL</b></size>")) {
			SocialConnector.PostMessage (SocialConnector.ServiceType.Facebook, "Social Connector", "https://github.com/anchan828/social-connector");
		}
		if (GUILayout.Button ("<size=40><b>Text & URL & Image</b></size>")) {
			SocialConnector.PostMessage (SocialConnector.ServiceType.Facebook, "Social Connector", "https://github.com/anchan828/social-connector", imagePath);
		}

		#if !UNITY_STANDALONE_OSX
		///=================
		/// LINE
		///=================
		
		GUILayout.Label ("<size=40><b>LINE</b></size>");

		if (GUILayout.Button ("<size=40><b>Text</b></size>")) {
			SocialConnector.PostMessage (SocialConnector.ServiceType.Line, "text");
		}
		if (GUILayout.Button ("<size=40><b>Text & URL</b></size>")) {
			SocialConnector.PostMessage (SocialConnector.ServiceType.Line, "text", "http://japan.unity3d.com/");
		}

		if (GUILayout.Button ("<size=40><b>Image</b></size>")) {
			SocialConnector.PostMessage (SocialConnector.ServiceType.Line, "", "", imagePath);
		}

		#endif
	}
}
