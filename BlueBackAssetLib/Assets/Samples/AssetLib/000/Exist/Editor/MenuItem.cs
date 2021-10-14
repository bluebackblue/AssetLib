

/** Samples.AssetLib.Exist.Editor
*/
namespace Samples.AssetLib.Exist.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** CreateDirectoryWithAssetsPath
		*/
		[UnityEditor.MenuItem("�T���v��/AssetLib/Exist/ExistDirectoryWithAssetsPath")]
		private static void MenuItem_ExistDirectoryWithAssetsPath()
		{
			UnityEngine.Debug.Log("Samples : " + BlueBack.AssetLib.Editor.ExistDirectoryWithAssetsPath.Check("Samples").ToString());
		}

		/** CreateDirectoryWithAssetsPath
		*/
		[UnityEditor.MenuItem("�T���v��/AssetLib/Exist/ExistFileWithAssetsPath")]
		private static void MenuItem_ExistFileWithAssetsPath()
		{
			UnityEngine.Debug.Log("Samples.meta : " + BlueBack.AssetLib.Editor.ExistFileWithAssetsPath.Check("Samples.meta").ToString());
		}
	}
	#endif
}

