

/** Samples.AssetLib.Package
*/
namespace Samples.AssetLib.Package
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** CreatePackageWithAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/BlueBack.AssetLib/Package/CreatePackageWithAssetsPath")]
		private static void MenuItem_CreatePackageWithAssetsPath()
		{
			//事前処理。
			{
				BlueBack.AssetLib.Editor.DeleteDirectoryWithAssetsPath.TryDelete("Out/PackageIn");
				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out/PackageIn");
				BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8("text","Out/PackageIn/text.txt",BlueBack.AssetLib.LineFeedOption.CRLF);
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}

			//CreatePackageWithAssetsPath
			{
				BlueBack.AssetLib.Editor.CreatePackageWithAssetsPath.Create("Out/PackageIn","Out/test.unitypackage",UnityEditor.ExportPackageOptions.Recurse);
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}
		}
	}
	#endif
}

