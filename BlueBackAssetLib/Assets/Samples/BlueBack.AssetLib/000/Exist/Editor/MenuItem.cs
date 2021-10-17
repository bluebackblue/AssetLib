

/** Samples.AssetLib.Exist
*/
namespace Samples.AssetLib.Exist
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** ExistDirectoryWithAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/BlueBack.AssetLib/Exist/ExistDirectoryWithAssetsPath")]
		private static void MenuItem_ExistDirectoryWithAssetsPath()
		{
			UnityEngine.Debug.Log("Samples : " + BlueBack.AssetLib.Editor.ExistDirectoryWithAssetsPath.Check("Samples").ToString());
		}

		/** ExistFileWithAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/BlueBack.AssetLib/Exist/ExistFileWithAssetsPath")]
		private static void MenuItem_ExistFileWithAssetsPath()
		{
			UnityEngine.Debug.Log("Samples.meta : " + BlueBack.AssetLib.Editor.ExistFileWithAssetsPath.Check("Samples.meta").ToString());
		}
	}
	#endif
}

