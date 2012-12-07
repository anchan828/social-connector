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
	
	
	///==========================///
	
	
	
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
	///	 public
	///
	///=====================================================///
	
	
	/// <summary>
	/// Gets the name of the project.
	/// </summary>
	/// <value>
	/// The name of the project.
	/// </value>
	public static string projectName {
		get {
			string[] split = Application.dataPath.Split ('/');
			return split [split.Length - 2];
		}
	}
	/// <summary>
	/// Gets the editor folder path.
	/// </summary>
	/// <value>
	/// The editor folder path.
	/// </value>
	/// <example>
	/// Assets/SocialConnector/Editor/
	/// </example>
	public static string editorFolderPath {
		get {
			string currentFilePath = new System.Diagnostics.StackTrace (true).GetFrame (0).GetFileName ();
			return "Assets" + currentFilePath.Substring (0, currentFilePath.LastIndexOf ('/') + 1).Replace (Application.dataPath, string.Empty);
		}
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
	
}