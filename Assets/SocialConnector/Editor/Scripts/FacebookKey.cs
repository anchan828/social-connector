using UnityEngine;
using UnityEditor;

/// <summary>
/// Facebook Infomation.
/// </summary>
public static class FacebookKey
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
				_apiKey = EditorPrefs.GetString (SocialConnectorPreferences.projectName + "_facebook_apiKey");
				
				
			return _apiKey;
		}
		set {
				
			if (value.Equals (_apiKey))
				return;
			EditorPrefs.SetString (SocialConnectorPreferences.projectName + "_facebook_apiKey", value);
			_apiKey = value;
		}
	}
		
	public static string apiSecret {
		get {
				
			if (string.IsNullOrEmpty (_apiSecret))
				_apiSecret = EditorPrefs.GetString (SocialConnectorPreferences.projectName + "_facebook_apiSecret");
				
			return _apiSecret;
		}
		set {
				
			if (value.Equals (_apiSecret))
				return;
				
			EditorPrefs.SetString (SocialConnectorPreferences.projectName + "_facebook_apiSecret", value);
			_apiSecret = value;
		}
	}

	public static Texture2D logo {
		get {
			if (_logo != null)
				return _logo;
				
			_logo = (Texture2D)AssetDatabase.LoadAssetAtPath (SocialConnectorPreferences.editorFolderPath + "Texture/facebook.png", typeof(Texture2D));
			return _logo;
		}
	}
}