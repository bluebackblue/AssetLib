

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief オープンシーン。アセットパス。
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
			return UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/" + a_assets_path_with_extention,a_mode);
		}
	}
}
#endif

