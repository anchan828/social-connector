using UnityEngine;
using System.Runtime.InteropServices;

public static class SocialConector
{
	
#if UNITY_IPHONE
	[DllImport("__Internal")]
	private static extern bool IsAvailableForServiceType_(int type);
	
	[DllImport("__Internal")]
	private static extern void PostMessage_(int type, string text, string url); 
#elif UNITY_ANDROID
	
#endif
	
	
	
#if UNITY_IPHONE
	
	public static void PostMessage (ServiceType type, string text, string url)
	{
		if (IsAvailableForServiceType_ ((int)type)) {
			PostMessage_ ((int)type, text, url);
		} else {
			Debug.LogException (new UnassignedReferenceException ());
		}
	}

	
#elif UNITY_ANDROID
	
	public static void PostMessage (ServiceType type, string text, string url)
	{
		
	}
	
#endif
	
	
	
	public enum ServiceType
	{
		Twitter = 0,
		Facebook = 1
	}
	
	
	public static void PostMessage (ServiceType type)
	{
		PostMessage (type, null, null);
	}
	
	public static void PostMessage (ServiceType type, string text)
	{
		PostMessage (type, text, null);
	}
}
