

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief シーンオープン。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** OpenScene
	*/
	public static class OpenScene
	{
		/** シーンオープン。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static void OpenSceneFromAssetsPath(string a_assets_path_with_extention)
		{
			UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/" + a_assets_path_with_extention,UnityEditor.SceneManagement.OpenSceneMode.Single);
		}
	}
}
#endif

