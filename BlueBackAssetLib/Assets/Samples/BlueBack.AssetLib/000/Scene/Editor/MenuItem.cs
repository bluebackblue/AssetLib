

/** Samples.AssetLib.Scene
*/
namespace Samples.AssetLib.Scene
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** OpenSceneFromAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/BlueBack.AssetLib/Scene/OpenSceneFromAssetsPath_1")]
		private static void MenuItem_OpenSceneFromAssetsPath_1()
		{
			string t_path = BlueBack.AssetLib.Editor.FindFileWithAssetsPath.FindFirst("Samples",".*","^TestScene1\\.unity$");
			BlueBack.AssetLib.Editor.OpenSceneFromAssetsPath.Open(t_path,UnityEditor.SceneManagement.OpenSceneMode.Single);
		}

		/** OpenSceneFromAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/BlueBack.AssetLib/Scene/OpenSceneFromAssetsPath_2")]
		private static void MenuItem_OpenSceneFromAssetsPath_2()
		{
			string t_path = BlueBack.AssetLib.Editor.FindFileWithAssetsPath.FindFirst("Samples",".*","^TestScene2\\.unity$");
			BlueBack.AssetLib.Editor.OpenSceneFromAssetsPath.Open(t_path,UnityEditor.SceneManagement.OpenSceneMode.Single);
		}
	}
	#endif
}

