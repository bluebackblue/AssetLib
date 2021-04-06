

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief プレハブセーブ。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** SavePrefab
	*/
	public class SavePrefab
	{
		/** プレハブセーブ

			a_gameobject						: プレハブ化するゲームオブジェクト。
			a_assets_path_with_extention		: 「Assets」からの相対バス。拡張子付き。

		*/
		public static Result<UnityEngine.GameObject> SavePrefabToAssetsPath(UnityEngine.GameObject a_gameobject,string a_assets_path_with_extention)
		{
			Result<UnityEngine.GameObject> t_result;
			t_result.value = UnityEditor.PrefabUtility.SaveAsPrefabAsset(a_gameobject,"Assets/" + a_assets_path_with_extention,out t_result.success);

			return t_result;
		}

		/** プレハブセーブ

			a_gameobject						: プレハブ化するゲームオブジェクト。
			a_assets_path_with_extention		: 「Assets」からの相対バス。拡張子付き。

		*/
		public static Result<UnityEngine.GameObject> SaveAsPrefabToAssetsPath(UnityEngine.GameObject a_gameobject,string a_assets_path_with_extention)
		{
			UnityEngine.GameObject t_temp = UnityEngine.GameObject.Instantiate(a_gameobject);

			Result<UnityEngine.GameObject> t_result;
			t_result.value = UnityEditor.PrefabUtility.SaveAsPrefabAsset(t_temp,"Assets/" + a_assets_path_with_extention,out t_result.success);

			UnityEngine.GameObject.DestroyImmediate(t_temp);

			return t_result;
		}

		/** プレハブセーブ

			a_assets_path_with_extention		: 「Assets」からの相対バス。拡張子付き。

		*/
		public static Result<UnityEngine.GameObject> CreatePrefabToAssetsPath(string a_assets_path_with_extention)
		{
			UnityEngine.GameObject t_gameobject = new UnityEngine.GameObject("temp");
			Result<UnityEngine.GameObject> t_result;
			t_result.value = UnityEditor.PrefabUtility.SaveAsPrefabAsset(t_gameobject,"Assets/" + a_assets_path_with_extention,out t_result.success);
			UnityEngine.GameObject.DestroyImmediate(t_gameobject);

			return t_result;
		}
	}
}
#endif

