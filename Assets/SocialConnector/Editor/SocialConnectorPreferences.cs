using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
///  Social Connector Preferences
/// </summary>
public class SocialConnectorPreferences
{
	[PreferenceItem("Social Connector")]
	static void Menu ()
	{
		TwitterPreference ();
		FacebookPreference ();
		ContactMe ();
	}
	
	
	
	
	
	
	/// <summary>
	/// Twitters the preference.
	/// </summary>
	static void TwitterPreference ()
	{
		RenderTitle (TwitterKey.logo, TwitterKey.serviceName);
		TwitterKey.consumerKey = EditorGUILayout.TextField (TwitterKey.keyName, TwitterKey.consumerKey);
		TwitterKey.consumerSecret = EditorGUILayout.TextField (TwitterKey.secretName, TwitterKey.consumerSecret);
		
	}
	
	/// <summary>
	/// Facebooks the preference.
	/// </summary>
	static void FacebookPreference ()
	{
		RenderTitle (FacebookKey.logo, FacebookKey.serviceName);
		
		FacebookKey.apiKey = EditorGUILayout.TextField (FacebookKey.keyName, FacebookKey.apiKey);
		FacebookKey.apiSecret = EditorGUILayout.TextField (FacebookKey.secretName, FacebookKey.apiSecret);	
	}
	
	/// <summary>
	/// Contacts me.
	/// </summary>
	static void ContactMe ()
	{
		Rect rect = GUILayoutUtility.GetRect (new GUIContent ("<b>Contact Me</b>"), WindowSettings.style);
		rect.y = Screen.height - 50;
		EditorGUI.LabelField (rect, new GUIContent ("<b>Contact Me</b>"), WindowSettings.style);
		rect.y += 25;
		GUI.TextField (rect, "<color=#00ffffff><b>https://github.com/anchan828/social-connector</b></color>", WindowSettings.style);
	}
	
	
	///=====================================================///
	///
	///	 private
	///
	///=====================================================///
	
	
	
	/// <summary>
	/// Renders the title.
	/// </summary>
	/// <param name='logo'>
	///  Social Logo.
	/// </param>
	/// <param name='serviceName'>
	///  Social Service name.
	/// </param>
	private static void RenderTitle (Texture2D logo, string serviceName)
	{
		EditorGUILayout.BeginHorizontal ();
		{
			Rect rect = GUILayoutUtility.GetRect (new GUIContent (logo), EditorStyles.label);
			rect.width = 32;
			GUI.Label (rect, new GUIContent (logo));
			rect.x += 32;
			rect.y -= 2.5f;
			EditorGUI.LabelField (rect, "<b><size=20>" + serviceName + "</size></b>", WindowSettings.style);
			
		}
		EditorGUILayout.EndHorizontal ();
	}
	
	
	
	/// <summary>
	/// Window settings.
	/// </summary>
	private static class WindowSettings
	{
		public static GUIStyle style {
			get {
				if (_style != null)
					return _style;
				{
					_style = new GUIStyle ();
					_style.alignment = TextAnchor.MiddleLeft;
					_style.richText = true;
				}
				return _style;
			}
		}
		
		private static GUIStyle _style = null;
	}
	
	/// <summary>
	/// Twitter  Infomation.
	/// </summary>
	private static class TwitterKey
	{
		public const string serviceName = "Twitter";
		public const string keyName = "Consumer Key";
		public const string secretName = "Consumer Secret Key";
		private static string _consumerKey = string.Empty;
		private static string _consumerSecret = string.Empty;
		private static Texture2D _logo = null;
		
		public static string consumerKey {
			get {
				
				if (string.IsNullOrEmpty (_consumerKey))
					_consumerKey = EditorPrefs.GetString (projectName + "_twitter_consumerKey");
				
				return _consumerKey;
			}
			set {
				
				if (value.Equals (_consumerKey))
					return;
				
				EditorPrefs.SetString (projectName + "_twitter_consumerKey", value);
				_consumerKey = value;
			}
		}
		
		public static string consumerSecret {
			get {
				
				if (string.IsNullOrEmpty (_consumerSecret))
					_consumerSecret = EditorPrefs.GetString (projectName + "_twitter_consumerSecret");
				
				return _consumerSecret;
			}
			set {
				if (value.Equals (_consumerSecret))
					return;
				
				EditorPrefs.SetString (projectName + "_twitter_consumerSecret", value);
				_consumerSecret = value;
			}
		}
	
		public static Texture2D logo {
			get {
				if (_logo != null)
					return _logo;
				
				_logo = (Texture2D)EditorGUIUtility.LoadRequired ("twitter.png");
				return _logo;
			}
		}
	}
	
	/// <summary>
	/// Facebook Infomation.
	/// </summary>
	private static class FacebookKey
	{
		public const string serviceName = "Facebook";
		public const string keyName = "API Key";
		public const string secretName = "API Secret Key";
		private static string _apiKey = string.Empty;
		private static string _apiSecret = string.Empty;
		private static Texture2D _logo = null;

		public static string apiKey {
			get {
				
				if (string.IsNullOrEmpty (_apiKey))
					_apiKey = EditorPrefs.GetString (projectName + "_facebook_apiKey");
				
				
				return _apiKey;
			}
			set {
				
				if (value.Equals (_apiKey))
					return;
				EditorPrefs.SetString (projectName + "_facebook_apiKey", value);
				_apiKey = value;
			}
		}
		
		public static string apiSecret {
			get {
				
				if (string.IsNullOrEmpty (_apiSecret))
					_apiSecret = EditorPrefs.GetString (projectName + "_facebook_apiSecret");
				
				return _apiSecret;
			}
			set {
				
				if (value.Equals (_apiSecret))
					return;
				
				EditorPrefs.SetString (projectName + "_facebook_apiSecret", value);
				_apiSecret = value;
			}
		}

		public static Texture2D logo {
			get {
				if (_logo != null)
					return _logo;
				
				_logo = (Texture2D)EditorGUIUtility.LoadRequired ("facebook.png");
				return _logo;
			}
		}
	
	}
	
	/// <summary>
	/// Gets the name of the project.
	/// </summary>
	/// <value>
	/// The name of the project.
	/// </value>
	private static string projectName {
		get {
			string[] split = Application.dataPath.Split ('/');
			return split [split.Length - 2];
		}
	}
	
}