

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アセットのロード。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** LoadAsset
	*/
	#if(UNITY_EDITOR)
	public class LoadAsset
	{
		/** アセットをロード。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static UnityEngine.Object[] LoadAllAssetFromAssetsPath(string a_assets_path)
		{
			return UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Assets/" + a_assets_path);
		}

		/** アセットをロード。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static T LoadAssetFromAssetsPath<T>(string a_assets_path)
			where T : UnityEngine.Object
		{
			return UnityEditor.AssetDatabase.LoadAssetAtPath<T>("Assets/" + a_assets_path);
		}
	}
	#endif
}

