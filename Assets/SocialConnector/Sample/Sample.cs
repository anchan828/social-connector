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