using UnityEngine;
using UnityEditor.Callbacks;
using UnityEditor;
using System.IO;
using UnityEditor.iOS.Xcode;
using System.Linq;
using System.Collections.Generic;
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

			AddPermissions(path, new []{
				new KeyValuePair<string,string>("NSPhotoLibraryUsageDescription", "Save the Application's screenshot.")
			});			
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

		static void AddPermissions(string path , params KeyValuePair<string,string>[] permissions){
			var plistPath = Path.Combine (path, "Info.plist");
			var plist = new PlistDocument ();

			plist.ReadFromFile (plistPath);
			foreach(var permission in permissions){


				var count = plist.root.values
					.Where (kv => kv.Key == permission.Key)
					.Select (kv => kv.Value)
					.Count();

				if(count == 0){
					plist.root.SetString(permission.Key,permission.Value);
				}
			}

			plist.WriteToFile (plistPath);
		}
	}
}