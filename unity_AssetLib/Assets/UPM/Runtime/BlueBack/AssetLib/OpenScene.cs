

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief シーンを開く。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** OpenScene
	*/
	#if(UNITY_EDITOR)
	public class OpenScene
	{
		/** シーンを開く。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static void OpenSceneFromAssetsPath(string a_assets_path)
		{
			UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/" + a_assets_path,UnityEditor.SceneManagement.OpenSceneMode.Single);
		}
	}
	#endif
}

