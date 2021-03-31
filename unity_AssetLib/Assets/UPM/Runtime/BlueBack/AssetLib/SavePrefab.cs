

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief プレハブのセーブ。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** SavePrefab
	*/
	public class SavePrefab
	{
		/** SavePrefabToAssetsPath

			a_mesh			: メッシュ。
			a_assets_path	: 「Assets」からの相対バス。拡張子付き。

		*/
		#if(UNITY_EDITOR)
		public static Result<UnityEngine.GameObject> SavePrefabToAssetsPath(UnityEngine.GameObject a_prefab,string a_assets_path_with_extention)
		{
			Result<UnityEngine.GameObject> t_result;
			t_result.value = UnityEditor.PrefabUtility.SaveAsPrefabAsset(a_prefab,"Assets/" + a_assets_path_with_extention,out t_result.success);

			return t_result;
		}
		#endif
	}
}

