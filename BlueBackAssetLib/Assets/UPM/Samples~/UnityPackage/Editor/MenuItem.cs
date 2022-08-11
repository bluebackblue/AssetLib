

/** BlueBack.AssetLib.Samples.UnityPackage.Editor
*/
namespace BlueBack.AssetLib.Samples.UnityPackage.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public static class MenuItem
	{
		/** CreateUnityPackageWithAssetsPath
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/UnityPackage/CreateUnityPackageWithAssetsPath")]
		private static void MenuItem_CreateUnityPackageWithAssetsPath()
		{
			//事前処理。
			{
				BlueBack.AssetLib.Editor.DeleteDirectoryWithAssetsPath.TryDelete("Out/UnityPackageIn");
				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out/UnityPackageIn");
				BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8("text","Out/UnityPackageIn/text.txt",BlueBack.AssetLib.LineFeedOption.CRLF);
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}

			//CreateUnityPackageWithAssetsPath
			{
				BlueBack.AssetLib.Editor.CreateUnityPackageWithAssetsPath.Create("Out/UnityPackageIn","Out/test.unitypackage",UnityEditor.ExportPackageOptions.Recurse);
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}
		}
	}
	#endif
}

