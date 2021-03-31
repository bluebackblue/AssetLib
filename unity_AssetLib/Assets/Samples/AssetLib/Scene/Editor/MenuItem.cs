

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
			string t_path = BlueBack.AssetLib.FindFile.FindFileFistFromAssetsPath("",".*\\\\Scene$","^AssetLib_Scene.unity$");
			BlueBack.AssetLib.OpenScene.OpenSceneFromAssetsPath(t_path);
		}
	}
	#endif
}

