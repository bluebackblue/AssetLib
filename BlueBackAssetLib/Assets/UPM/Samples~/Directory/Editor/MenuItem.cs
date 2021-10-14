

/** Samples.AssetLib.Directory.Editor
*/
namespace Samples.AssetLib.Directory.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** CreateDirectoryWithAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Directory/CreateDirectoryWithAssetsPath")]
		private static void MenuItem_CreateAssetBundleWithAssetsPath()
		{
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out/Directory");
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}

		/** DeleteDirectoryWithAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Directory/DeleteDirectoryWithAssetsPath")]
		private static void MenuItem_DeleteDirectoryWithAssetsPath()
		{
			BlueBack.AssetLib.Editor.DeleteDirectoryWithAssetsPath.Delete("Out/Directory");
			BlueBack.AssetLib.Editor.DeleteFileWithAssetsPath.Delete("Out/Directory.meta");
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
	}
	#endif
}

