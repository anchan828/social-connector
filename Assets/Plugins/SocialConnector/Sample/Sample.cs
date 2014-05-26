using UnityEngine;

public class Sample : MonoBehaviour
{
    string imagePath
    {
        get
        {

#if UNITY_EDITOR_OSX
            return Application.dataPath + "/../image.png";
#endif

#if UNITY_STANDALONE_OSX
			return Application.dataPath +"/Data/image.png";
#endif

            return Application.persistentDataPath + "/image.png";
        }
    }

    void OnGUI()
    {

     

        GUILayout.Label(System.DateTime.Now.ToString());
        GUILayout.Label(imagePath);

        if (GUILayout.Button("<size=30><b>Take</b></size>", GUILayout.Height(60)))
        {
            Application.CaptureScreenshot("image.png");
        }


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

        ///=================
        /// Twitter
        ///=================

        GUILayout.Label("<size=30><b>Twitter</b></size>", GUILayout.Height(60));

        if (GUILayout.Button("<size=30><b>Text</b></size>", GUILayout.Height(60)))
        {
            SocialConnector.PostMessage(SocialConnector.ServiceType.Twitter, "Social Connector");
        }
        if (GUILayout.Button("<size=30><b>Text & URL</b></size>", GUILayout.Height(60)))
        {
            SocialConnector.PostMessage(SocialConnector.ServiceType.Twitter, "Social Connector", "https://github.com/anchan828/social-connector");
        }

        if (GUILayout.Button("<size=30><b>Text & URL & Image</b></size>", GUILayout.Height(60)))
        {
            SocialConnector.PostMessage(SocialConnector.ServiceType.Twitter, "Social Connector", "https://github.com/anchan828/social-connector", imagePath);
        }

        ///=================
        /// Facebook
        ///=================

        GUILayout.Label("<size=30><b>Facebook</b></size>", GUILayout.Height(60));

        if (GUILayout.Button("<size=30><b>Text</b></size>", GUILayout.Height(60)))
        {
            SocialConnector.PostMessage(SocialConnector.ServiceType.Facebook, "Social Connector");
        }
        if (GUILayout.Button("<size=30><b>Text & URL</b></size>", GUILayout.Height(60)))
        {
            SocialConnector.PostMessage(SocialConnector.ServiceType.Facebook, "Social Connector", "https://github.com/anchan828/social-connector");
        }
        if (GUILayout.Button("<size=30><b>Text & URL & Image</b></size>", GUILayout.Height(60)))
        {
            SocialConnector.PostMessage(SocialConnector.ServiceType.Facebook, "Social Connector", "https://github.com/anchan828/social-connector", imagePath);
        }

#if !UNITY_STANDALONE_OSX
        ///=================
        /// LINE
        ///=================

        GUILayout.Label("<size=30><b>LINE</b></size>", GUILayout.Height(60));

        if (GUILayout.Button("<size=30><b>Text</b></size>", GUILayout.Height(60)))
        {
            SocialConnector.PostMessage(SocialConnector.ServiceType.Line, "text");
        }
        if (GUILayout.Button("<size=30><b>Text & URL</b></size>", GUILayout.Height(60)))
        {
            SocialConnector.PostMessage(SocialConnector.ServiceType.Line, "text", "http://japan.unity3d.com/");
        }

        if (GUILayout.Button("<size=30><b>Image</b></size>", GUILayout.Height(60)))
        {
            SocialConnector.PostMessage(SocialConnector.ServiceType.Line, "", "", imagePath);
        }

#endif
    }
}
