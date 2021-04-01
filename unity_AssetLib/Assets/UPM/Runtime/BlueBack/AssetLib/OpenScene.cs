

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief シーンオープン。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** OpenScene
	*/
	public class OpenScene
	{
		/** シーンオープン。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		#if(UNITY_EDITOR)
		public static void OpenSceneFromAssetsPath(string a_assets_path_with_extention)
		{
			UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/" + a_assets_path_with_extention,UnityEditor.SceneManagement.OpenSceneMode.Single);
		}
		#endif
	}
}

