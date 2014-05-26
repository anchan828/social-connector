using UnityEngine;

#if UNITY_IPHONE || UNITY_STANDALONE_OSX

using System.Runtime.InteropServices;

#endif
public class SocialConnector
{
#if UNITY_IPHONE
    [DllImport("__Internal")]
    private static extern void SocialConnector_PostMessage(int type, string text, string url, string textureUrl);

    [DllImport("__Internal")]
    private static extern void SocialConnector_Share(string text, string url, string textureUrl);

#elif UNITY_ANDROID
    private static AndroidJavaObject clazz = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    private static AndroidJavaObject activity = clazz.GetStatic<AndroidJavaObject>("currentActivity");


#elif UNITY_STANDALONE_OSX
	[DllImport ("SocialConnector")]
	private static extern void SocialConnector_PostMessage (int type, string text, string url, string textureUrl);

#endif

#if UNITY_IPHONE || UNITY_STANDALONE_OSX

    private static void _Share(string text, string url, string textureUrl)
    {
        SocialConnector_Share(text, url, textureUrl);
    }

    private static void _PostMessage(ServiceType type, string text, string url, string textureUrl)
    {
        SocialConnector_PostMessage((int)type, text, url, textureUrl);
    }

#elif UNITY_ANDROID

    private static void _Share(string text, string url, string textureUrl)
    {
        ActionSend(text, url, textureUrl, null);
    }

    private static void _PostMessage(ServiceType type, string text, string url, string textureUrl)
    {
        var packageName = string.Empty;

        if (type.Equals(ServiceType.Twitter))
        {
            packageName = "com.twitter.android";
        }
        else if (type.Equals(ServiceType.Facebook))
        {
            packageName = "com.facebook.katana";
        }
        else if (type.Equals(ServiceType.Line))
        {
            string contentType;
            string contentKey;

            if (string.IsNullOrEmpty(textureUrl))
            {
                contentType = "text";
                contentKey = text;

                if (!string.IsNullOrEmpty(url))
                {
                    contentKey += " - " + url;
                }
            }
            else
            {
                contentType = "image";
                contentKey = textureUrl;
            }

            var lineUrl = string.Format("line://msg/{0}/{1}", contentType, contentKey);
            Application.OpenURL(lineUrl);
            return;
        }

        ActionSend(text, url, textureUrl, packageName);
    }

    private static void ActionSend(string text, string url, string textureUrl, string packageName)
    {
        using (var intent = new AndroidJavaObject("android.content.Intent"))
        {
            intent.Call<AndroidJavaObject>("setAction", "android.intent.action.SEND");
            intent.Call<AndroidJavaObject>("setType", string.IsNullOrEmpty(textureUrl) ? "text/plain" : "image/png");

            if (!string.IsNullOrEmpty(packageName))
            {
                intent.Call<AndroidJavaObject>("setPackage", packageName);
            }

            if (!string.IsNullOrEmpty(url))
                text += "\t" + url;
            if (!string.IsNullOrEmpty(text))
                intent.Call<AndroidJavaObject>("putExtra", "android.intent.extra.TEXT", text);

            if (!string.IsNullOrEmpty(textureUrl))
            {
                var uri = new AndroidJavaClass("android.net.Uri");
                var file = new AndroidJavaObject("java.io.File", textureUrl);
                intent.Call<AndroidJavaObject>("putExtra", "android.intent.extra.STREAM", uri.CallStatic<AndroidJavaObject>("fromFile", file));
            }
            var chooser = intent.CallStatic<AndroidJavaObject>("createChooser", intent, "");
            chooser.Call<AndroidJavaObject>("putExtra", "android.intent.extra.EXTRA_INITIAL_INTENTS", intent);
            activity.Call("startActivity", chooser);
        }
    }
#endif


    public static void Share(string text)
    {
        Share(text, null, null);
    }

    public static void Share(string text, string url)
    {
        Share(text, url, null);
    }

    public static void Share(string text, string url, string textureUrl)
    {
        _Share(text, url, textureUrl);
    }



    public enum ServiceType
    {
        Twitter = 0,
        Facebook = 1,
        Line = 2
    }

    public static void PostMessage(ServiceType type)
    {
        _PostMessage(type, null, null, null);
    }

    public static void PostMessage(ServiceType type, string text)
    {
        _PostMessage(type, text, null, null);
    }

    public static void PostMessage(ServiceType type, string text, string url)
    {
        _PostMessage(type, text, url, null);
    }

    public static void PostMessage(ServiceType type, string text, string url, string textureUrl)
    {
        _PostMessage(type, text, url, textureUrl);
    }
}