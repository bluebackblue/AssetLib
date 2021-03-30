

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief メッシュのセーブ。
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
		/** SaveMesh

			a_mesh			: メッシュ。
			a_assets_path	: 「Assets」からの相対バス。

		*/
		public static void SaveMeshToAssetsPath(UnityEngine.Mesh a_mesh,string a_assets_path)
		{
			UnityEngine.Mesh t_new_mesh = UnityEngine.Object.Instantiate<UnityEngine.Mesh>(a_mesh);
			UnityEditor.AssetDatabase.CreateAsset(t_new_mesh,"Assets/" + a_assets_path);
		}
	}
	#endif
}

