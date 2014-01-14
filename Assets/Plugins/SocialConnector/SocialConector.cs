using UnityEngine;

#if UNITY_IPHONE

using System.Runtime.InteropServices;

#endif
public class SocialConector
{
	#if UNITY_IPHONE
	[DllImport ("__Internal")]
	private static extern bool SocialConnector_IsAvailableForServiceType (int type);

	[DllImport ("__Internal")]
	private static extern void SocialConnector_PostMessage (int type, string text, string url, string textureUrl);
	

#elif UNITY_ANDROID
	private static AndroidJavaObject clazz = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
	private static AndroidJavaObject activity = clazz.GetStatic<AndroidJavaObject> ("currentActivity");

	#endif
	#if UNITY_IPHONE
	
	private static void _PostMessage (ServiceType type, string text, string url, string textureUrl)
	{
		if (type == ServiceType.Line) {
			Application.OpenURL (string.Format ("line://msg/text/{0}", System.Uri.EscapeUriString (text + (string.IsNullOrEmpty (url) ? "" : " - " + url))));
			return;
		}
		
		
		if (SocialConnector_IsAvailableForServiceType ((int)type)) {
			SocialConnector_PostMessage ((int)type, text, url, textureUrl);
		} 
	}

#elif UNITY_ANDROID
	private static void _PostMessage (ServiceType type, string text, string url, string textureUrl)
	{
		string packageName = string.Empty;

		if (type.Equals (ServiceType.Twitter)) {
			packageName = "com.twitter.android";
		} else if (type.Equals (ServiceType.Facebook)) {
			packageName = "com.facebook.katana";
		} else if (type.Equals (ServiceType.Line)) {
			Application.OpenURL (string.Format ("line://msg/text/{0}", System.Uri.EscapeUriString (text + (string.IsNullOrEmpty (url) ? "" : " - " + url))));
			return;
		}

		using (AndroidJavaObject intent = new AndroidJavaObject ("android.content.Intent")) {

			intent.Call<AndroidJavaObject> ("setAction", "android.intent.action.SEND");
			intent.Call<AndroidJavaObject> ("setPackage", packageName);
			intent.Call<AndroidJavaObject> ("setType", "image/png");

			if (!string.IsNullOrEmpty (url))
				text += "\t" + url;
			if (!string.IsNullOrEmpty (text))
				intent.Call<AndroidJavaObject> ("putExtra", "android.intent.extra.TEXT", text);

			if (!string.IsNullOrEmpty (textureUrl)) {
				AndroidJavaClass uri = new AndroidJavaClass ("android.net.Uri");
				AndroidJavaObject file = new AndroidJavaObject ("java.io.File", textureUrl);
				intent.Call<AndroidJavaObject> ("putExtra", "android.intent.extra.STREAM", uri.CallStatic<AndroidJavaObject> ("fromFile", file));
			}
			AndroidJavaObject chooser = intent.CallStatic<AndroidJavaObject> ("createChooser", intent, "");
			// TODO 複数対応
			chooser.Call<AndroidJavaObject> ("putExtra", "android.intent.extra.EXTRA_INITIAL_INTENTS", intent);
			activity.Call ("startActivity", chooser);
		}
	}
	
	#endif
	public enum ServiceType
	{
		Twitter = 0,
		Facebook = 1,
		Line = 2
	}

	public static void PostMessage (ServiceType type)
	{
		_PostMessage (type, null, null, null);
	}

	public static void PostMessage (ServiceType type, string text)
	{
		_PostMessage (type, text, null, null);
	}

	public static void PostMessage (ServiceType type, string text, string url)
	{
		_PostMessage (type, text, url, null);
	}

	public static void PostMessage (ServiceType type, string text, string url, string textureUrl)
	{
		_PostMessage (type, text, url, textureUrl);
	}
}
