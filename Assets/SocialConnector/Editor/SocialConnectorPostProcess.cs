using UnityEngine;
using System.Collections;
using UnityEditor.Callbacks;
using UnityEditor;
using System.IO;

public class SocialConnectorPostProcess
{
	[PostProcessBuild]
	public static void OnPostProcessBuild (BuildTarget target, string path)
	{
		if (target != BuildTarget.iOS)
			return;
		CopyImageset (path);
	}

	static void CopyImageset (string path)
	{
		var @from = "Assets/SocialConnector/Editor/LINE.imageset";
		var @to = Path.Combine (path, "Unity-iPhone/Images.xcassets/LINE.imageset");

		if(Directory.Exists(@to))
			return;

		FileUtil.CopyFileOrDirectoryFollowSymlinks (@from, @to);

		foreach(var meta in Directory.GetFiles(@to,"*.meta"))
			File.Delete(meta);
	}
}