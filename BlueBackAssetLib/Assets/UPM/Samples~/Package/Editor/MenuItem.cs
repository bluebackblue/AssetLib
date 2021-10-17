

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
		[UnityEditor.MenuItem("�T���v��/BlueBack.AssetLib/Package/CreatePackageWithAssetsPath")]
		private static void MenuItem_CreatePackageWithAssetsPath()
		{
			//���O�����B
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

