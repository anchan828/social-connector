using UnityEngine;

#if UNITY_IPHONE

using System.Runtime.InteropServices;

#endif

public class SocialConector
{
	
#if UNITY_IPHONE

	[DllImport("__Internal")]
	private static extern bool IsAvailableForServiceType_( int type );
	
	[DllImport("__Internal")]
	private static extern void PostMessage_( int type, string text, string url ); 

#elif UNITY_ANDROID
	
	private static AndroidJavaObject clazz = new AndroidJavaClass ( "com.unity3d.player.UnityPlayer" );
	private static AndroidJavaObject activity = clazz.GetStatic<AndroidJavaObject> ( "currentActivity" );

#endif
	
	
	
#if UNITY_IPHONE
	
	private static void _PostMessage ( ServiceType type, string text, string url )
	{
		if( type == ServiceType.Line ) {
			Application.OpenURL(string.Format("line://msg/text/{0}", System.Uri.EscapeUriString( text + (string.IsNullOrEmpty( url ) ? "" : " - " + url) ) ) );
			return;
		}
		
		
		if ( IsAvailableForServiceType_ ( (int) type ) ) {
			PostMessage_ ( (int) type, text, url );
		} 
	}

	
#elif UNITY_ANDROID
	
	private static void _PostMessage (ServiceType type, string text, string url)
	{
		string packageName = string.Empty;
		
		if(type.Equals(ServiceType.Twitter)){
			packageName = "com.twitter.android";
		}else if (type.Equals(ServiceType.Facebook)){
			packageName = "com.facebook.katana";
		}else if(type.Equals(ServiceType.Line)){
			Application.OpenURL(string.Format("line://msg/text/{0}", System.Uri.EscapeUriString( text + (string.IsNullOrEmpty( url ) ? "" : " - " + url) ) ) );
			return;
		}
		
		AndroidJavaObject intent = new AndroidJavaObject ( "android.content.Intent" );
	
		
		intent.Call<AndroidJavaObject> ( "setPackage", packageName );
		intent.Call<AndroidJavaObject> ( "setType", "text/plain" );
		intent.Call<AndroidJavaObject> ( "putExtra", "android.intent.extra.TEXT" , text + "\t" + url );
		activity.Call ("startActivity", intent.CallStatic<AndroidJavaObject>( "createChooser", intent, "Sorry" ));
		intent.Dispose ();
	}
	
#endif
	
	
	
	public enum ServiceType
	{
		Twitter = 0,
		Facebook = 1,
		Line =2
	}
	
	
	public static void PostMessage (ServiceType type)
	{
		_PostMessage (type, null, null);
	}
	
	public static void PostMessage (ServiceType type, string text)
	{
		_PostMessage (type, text, null);
	}

	public static void PostMessage (ServiceType type, string text, string url)
	{
		_PostMessage (type, text, url);
	}
}
