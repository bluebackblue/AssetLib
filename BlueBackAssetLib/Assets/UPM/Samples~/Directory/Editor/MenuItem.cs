

/** Samples.Directory
*/
namespace Samples.Directory
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
			BlueBack.AssetLib.Editor.DeleteDirectoryWithAssetsPath.TryDelete("Out/Directory");
			BlueBack.AssetLib.Editor.DeleteFileWithAssetsPath.TryDelete("Out/Directory.meta");
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
	}
	#endif
}

