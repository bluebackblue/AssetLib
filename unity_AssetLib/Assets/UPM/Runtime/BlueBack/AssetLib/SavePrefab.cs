

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief プレハブセーブ。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** SavePrefab
	*/
	public class SavePrefab
	{
		/** プレハブセーブ

			a_prefab							: プレハブ。
			a_assets_path_with_extention		: 「Assets」からの相対バス。拡張子付き。

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

