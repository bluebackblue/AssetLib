

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief オープンシーン。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** OpenSceneFromAssetsPath
	*/
	public static class OpenSceneFromAssetsPath
	{
		/** オープン。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_mode							: モード。

		*/
		public static UnityEngine.SceneManagement.Scene Open(string a_assets_path_with_extention,UnityEditor.SceneManagement.OpenSceneMode a_mode)
		{
			return UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets\\" + a_assets_path_with_extention,a_mode);
		}

		/** オープン。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_mode							: モード。

		*/
		public static MultiResult<bool,UnityEngine.SceneManagement.Scene> TryOpen(string a_assets_path_with_extention,UnityEditor.SceneManagement.OpenSceneMode a_mode)
		{
			try{
				UnityEngine.SceneManagement.Scene t_scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets\\" + a_assets_path_with_extention,a_mode);
				return new MultiResult<bool,UnityEngine.SceneManagement.Scene>(true,t_scene);
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,UnityEngine.SceneManagement.Scene>(false,default);
			}
		}
	}
}
#endif

