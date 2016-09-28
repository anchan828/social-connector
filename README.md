Social Connector v0.4.1
================

Android/iOSで、様々なアプリと連携を行いゲームスコアなどをシェアするプラグイン。


**注意:** 

* Facebookはプライバシーポリシーにより事前のテキスト挿入を許可していないのでテキストの共有はできません。 [https://developers.facebook.com/docs/apps/review/prefill](https://developers.facebook.com/docs/apps/review/prefill)
* このプラグインでは LINE は 画像(+テキスト)のみ共有できます。テキストのみはできません。（ただし LINE Keepは可能）


## Requirements

### iOS
* **iOS8.2+** 

### Android
* Android 2.3+

## 使い方

```
SocialConnector.Share("Social Connector", "https://github.com/anchan828/social-connector", imagePath);
```


## サンプル


See  [Assets/Plugins/SocialConnector/Sample/Sample.cs](https://github.com/anchan828/social-connector/blob/master/Assets/SocialConnector/Sample/Sample.cs)

```
using UnityEngine;

namespace SocialConnector
{
	public class Sample : MonoBehaviour
	{
		string imagePath {
			get {
				return Application.persistentDataPath + "/image.png";
			}
		}

		void OnGUI ()
		{

			if (GUILayout.Button ("<size=30><b>Take</b></size>", GUILayout.Height (60))) {
				Application.CaptureScreenshot ("image.png");
			}

			GUILayout.Space (60);

			///=================
			/// Share
			///=================

			if (GUILayout.Button ("<size=30><b>Share</b></size>", GUILayout.Height (60))) {
				SocialConnector.Share ("Social Connector", "https://github.com/anchan828/social-connector", null);
			}
			if (GUILayout.Button ("<size=30><b>Share Image</b></size>", GUILayout.Height (60))) {
				SocialConnector.Share ("Social Connector", "https://github.com/anchan828/social-connector", imagePath);
			}
		}
	}
}
```
![](https://dl.dropboxusercontent.com/u/153254465/screenshot/2016-09-24%2019.19.07.png)

## Advanced

* iOS
  * 画像を端末に保存するときにプライバシーアクセス - NSPhotoLibraryUsageDescription が必要です。プラグイン側で自動的に追加していますが、使用目的の説明文が英語で記載されています（Save the Application's screenchot. という文）。もし日本語で表示したい場合は Localizable.strings を追加してください。ja.lproj/InfoPlist.stringsに以下のように追加すれば大丈夫なはず。
      * NSPhotoLibraryUsageDescription="スクリーンショットを保存するためにアクセスします。"
      * InfoPlist.string の追加の仕方 - http://qiita.com/hiroo0529/items/da9909f6787f2dce75e3


## 技術的なお話

このプラグインは、次の技術を使用しています。

* Android: `ACTION_SEND`
* iOS: `UIActivityViewController`

`ACTION_SEND`、`UIActivityViewController` は不特定多数のアプリに対してシェアを行うための機能です。特定のアプリに対してのシェアをサポートしているわけではないということに注意してください。


## 更新履歴

v0.4.1

* [iOS] 画像を保存するときのために NSPhotoLibraryUsageDescription を追加

v0.4.0

* [iOS] UIActivityViewController が日本語で表示されていなかった問題を解決
* [iOS] 通常の機能でシェアができるようになったため、LINEのインテグレーションを削除
* SocialConnectorの名前空間を追加

## ライセンス

```
Copyright (C) 2011 Keigo Ando

This software is provided 'as-is', without any express or implied
warranty.  In no event will the authors be held liable for any damages
arising from the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:

1. The origin of this software must not be misrepresented; you must not
   claim that you wrote the original software. If you use this software
   in a product, an acknowledgment in the product documentation would be
   appreciated but is not required.
2. Altered source versions must be plainly marked as such, and must not be
   misrepresented as being the original software.
3. This notice may not be removed or altered from any source distribution.

```
