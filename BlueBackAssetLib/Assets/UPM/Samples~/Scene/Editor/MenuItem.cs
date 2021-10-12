

/** Samples.AssetLib.Scene.Editor
*/
namespace Samples.AssetLib.Scene.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** シーンを開く。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Scene/OpenSceneFromAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Scene_OpenSceneFromAssetsPath()
		{
			string t_path = BlueBack.AssetLib.Editor.FindFileWithAssetsPath.FindFirst("","^(?!.*Samples\\~\\\\).*$","^AssetLib_Scene\\.unity$");
			UnityEngine.Debug.Log(t_path);
			BlueBack.AssetLib.Editor.OpenSceneFromAssetsPath.Open(t_path,UnityEditor.SceneManagement.OpenSceneMode.Single);
		}
	}
	#endif
}

