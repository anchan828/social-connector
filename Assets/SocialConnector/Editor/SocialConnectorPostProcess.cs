using UnityEngine;
using UnityEditor.Callbacks;
using UnityEditor;
using System.IO;
using UnityEditor.iOS.Xcode;
using System.Linq;

namespace SocialConnector
{
	public class SocialConnectorPostProcess
	{
		[PostProcessBuild]
		public static void OnPostProcessBuild (BuildTarget target, string path)
		{
			if (target != BuildTarget.iOS)
				return;
			AddLanguage (path, "ja");
		}

		static void AddLanguage (string path, params string[] languages)
		{
			var plistPath = Path.Combine (path, "Info.plist");
			var plist = new PlistDocument ();

			plist.ReadFromFile (plistPath);

			var localizationKey = "CFBundleLocalizations";

			var localizations = plist.root.values
			.Where (kv => kv.Key == localizationKey)
			.Select (kv => kv.Value)
			.Cast<PlistElementArray> ()
			.FirstOrDefault ();
		

			if (localizations == null)
				localizations = plist.root.CreateArray (localizationKey);

			foreach (var language in languages) {
				if (localizations.values.Select (el => el.AsString ()).Contains (language) == false)
					localizations.AddString (language);
			}
			
			plist.WriteToFile (plistPath);
		}
	}
}