

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief メッシュセーブ。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** SaveMesh
	*/
	#if(UNITY_EDITOR)
	public class SaveMesh
	{
		/** メッシュセーブ。

			a_mesh							: メッシュ。
			a_assets_path_with_extention		: 「Assets」からの相対バス。拡張子付き。

		*/
		public static void SaveAsMeshToAssetsPath(UnityEngine.Mesh a_mesh,string a_assets_path)
		{
			UnityEngine.Mesh t_new_mesh = UnityEngine.Object.Instantiate<UnityEngine.Mesh>(a_mesh);
			UnityEditor.AssetDatabase.CreateAsset(t_new_mesh,"Assets/" + a_assets_path);
		}
	}
	#endif
}

