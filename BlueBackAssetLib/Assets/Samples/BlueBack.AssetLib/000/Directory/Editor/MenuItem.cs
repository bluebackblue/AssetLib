

/** BlueBack.AssetLib.Samples.Directory.Editor
*/
namespace BlueBack.AssetLib.Samples.Directory.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** CreateDirectoryWithAssetsPath
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Directory/CreateDirectoryWithAssetsPath")]
		private static void MenuItem_CreateAssetBundleWithAssetsPath()
		{
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out/Directory");
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}

		/** DeleteDirectoryWithAssetsPath
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Directory/DeleteDirectoryWithAssetsPath")]
		private static void MenuItem_DeleteDirectoryWithAssetsPath()
		{
			BlueBack.AssetLib.Editor.DeleteDirectoryWithAssetsPath.TryDelete("Out/Directory");
			BlueBack.AssetLib.Editor.DeleteFileWithAssetsPath.TryDelete("Out/Directory.meta");
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
	}
	#endif
}

