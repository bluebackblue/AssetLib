

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アセットロード。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadAsset
	*/
	public class LoadAsset
	{
		/** 全アセットロード。

			a_assets_path_with_extention	: 「Assets」からの相対パス。拡張子付き。

		*/
		public static UnityEngine.Object[] LoadAllAssetsFromAssetsPath(string a_assets_path_with_extention)
		{
			return UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Assets/" + a_assets_path_with_extention);
		}

		/** 全指定アセットロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static System.Collections.Generic.List<T> LoadAllSpecifiedAssetsFromAssetsPath<T>(string a_assets_path_with_extention)
			where T : class
		{
			System.Collections.Generic.List<T> t_list = new System.Collections.Generic.List<T>();

			UnityEngine.Object[] t_object_list = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Assets/" + a_assets_path_with_extention);
			if(t_object_list != null){
				for(int ii=0;ii<t_object_list.Length;ii++){
					T t_load_asset = t_object_list[ii] as T;
					if(t_load_asset != null){
						t_list.Add(t_load_asset);
					}
				}
			}

			return t_list;
		}

		/** アセットロード。

			a_assets_path_with_extention	: 「Assets」からの相対パス。拡張子付き。

		*/
		public static T LoadAssetFromAssetsPath<T>(string a_assets_path_with_extention)
			where T : UnityEngine.Object
		{
			return UnityEditor.AssetDatabase.LoadAssetAtPath<T>("Assets/" + a_assets_path_with_extention);
		}

		/** アセットインポーターロード。

			a_assets_path_with_extention	: 「Assets」からの相対パス。拡張子付き。

		*/
		public static T GetAssetImportaer<T>(string a_assets_path_with_extention)
			where T : UnityEditor.AssetImporter
		{
			return UnityEditor.AssetImporter.GetAtPath("Assets/" + a_assets_path_with_extention) as T;
		}
	}
}
#endif

