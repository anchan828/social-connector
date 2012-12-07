using UnityEngine;
using UnityEditor;

/// <summary>
/// Twitter  Infomation.
/// </summary>
public static  class TwitterKey
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
				_consumerKey = EditorPrefs.GetString (SocialConnectorPreferences.projectName + "_twitter_consumerKey");
				
			return _consumerKey;
		}
		set {
				
			if (value.Equals (_consumerKey))
				return;
				
			EditorPrefs.SetString (SocialConnectorPreferences.projectName + "_twitter_consumerKey", value);
			_consumerKey = value;
		}
	}
		
	public static string consumerSecret {
		get {
				
			if (string.IsNullOrEmpty (_consumerSecret))
				_consumerSecret = EditorPrefs.GetString (SocialConnectorPreferences.projectName + "_twitter_consumerSecret");
				
			return _consumerSecret;
		}
		set {
			if (value.Equals (_consumerSecret))
				return;
				
			EditorPrefs.SetString (SocialConnectorPreferences.projectName + "_twitter_consumerSecret", value);
			_consumerSecret = value;
		}
	}
	
	public static Texture2D logo {
		get {
			if (_logo != null)
				return _logo;
				
			_logo = (Texture2D)AssetDatabase.LoadAssetAtPath (SocialConnectorPreferences.editorFolderPath + "Texture/twitter.png", typeof(Texture2D));
			return _logo;
		}
	}
}
	