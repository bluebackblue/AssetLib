

/** Samples.AssetLib.Package.Editor
*/
namespace Samples.AssetLib.Package.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** CreateFileNameListWithAssetsPath
		*/
		[UnityEditor.MenuItem("�T���v��/AssetLib/Package/CreateFileNameListWithAssetsPath")]
		private static void MenuItem_CreateFileNameListWithAssetsPath()
		{
			//���O�����B
			{
				BlueBack.AssetLib.Editor.DeleteDirectoryWithAssetsPath.TryDelete("Out/PackageIn");
				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out/PackageIn");
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("text","Out/PackageIn/text.txt",false,BlueBack.AssetLib.LineFeedOption.CRLF);
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}

			//�p�b�P�[�W�쐬�B
			BlueBack.AssetLib.Editor.CreatePackageWithAssetsPath.Create("Out/PackageIn","Out/test.unitypackage",UnityEditor.ExportPackageOptions.Recurse);
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
	}
	#endif
}

