Social Connector v0.5.0
================

Android/iOSで、様々なアプリと連携を行いゲームスコアなどをシェアするプラグイン。


**注意:** 

* Facebookはプライバシーポリシーにより事前のテキスト挿入を許可していないのでテキストの共有はできません。 [https://developers.facebook.com/docs/apps/review/prefill](https://developers.facebook.com/docs/apps/review/prefill)
* このプラグインでは LINE は 画像(+テキスト)のみ共有できます。テキストのみはできません。（ただし LINE Keepは可能）
* AndroidはFileProviderに対応しなければいけません。詳細は[FileProviderに対応する](#fileproviderに対応する)を参照してください。


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
![](https://i.gyazo.com/09bb3de393fad3dbbc7151639317f960.png)

## FileProviderに対応する

Android API Level 24 から、画像のシェアにおいて FileProvider の使用が必須となりました。このため、プロジェクト単位で `AndroidManifest.xml` をカスタマイズしなければいけません。

### Social Connectorが用意したAndroidManifest.xmlを使用する

実装例として`SocialConnector/Plugins/Android`フォルダー配下に`AndroidManifest.xml`を配置しています。
以下の手順に沿うことで、FileProviderに対応することが可能です。

1. `SocialConnector/Plugins/Android`フォルダーを`Plugins/Android`フォルダーに移動する 
   ![](https://i.gyazo.com/1a6d9f42d66448371cdc538230719b23.png)
2. `AndroidManifest.xml`内の`com.kyusyukeigo.socialconnector.fileprovider`をプロジェクトのパッケージ名に書き換える。（例: パッケージ名が`com.example.game`であれば `com.example.game.fileprovider`に書き換える）
   * パッケージ名は、Player Settingsの`Identification`や`Application.identifier`で確認することができます。
     ![](https://i.gyazo.com/1bcaa3d67748fe6fd253c1da8a9963bd.png)

### トラブルシューティング

もし、何かしらのエラーが起きた場合 `support-core-utils-25.3.1.aar` を削除してみてください。ライブラリの競合が解決し、ビルドが通るかもしれません。

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

v0.5.0

* [Android] FileProvider に対応。詳細は[FileProviderに対応する](#fileproviderに対応する)を参照してください。

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
