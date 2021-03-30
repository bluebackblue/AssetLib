

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＦＢＸのロード。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** LoadFbx
	*/
	#if(UNITY_EDITOR)
	public class LoadFbx
	{
		/** LoadMeshFbxFromAssetsPath

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static System.Collections.Generic.List<UnityEngine.Mesh> LoadMeshFbxFromAssetsPath(string a_assets_path_with_extention)
		{
			System.Collections.Generic.List<UnityEngine.Mesh> t_list = new System.Collections.Generic.List<UnityEngine.Mesh>();

			UnityEngine.Object[] t_object_list = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Assets/" + a_assets_path_with_extention);
			if(t_object_list != null){
				for(int ii=0;ii<t_object_list.Length;ii++){
					if(t_object_list[ii].GetType() == typeof(UnityEngine.Mesh)){
						UnityEngine.Mesh t_load_asset = t_object_list[ii] as UnityEngine.Mesh;
						if(t_load_asset != null){
							t_list.Add(t_load_asset);
						}
					}
				}
			}

			return t_list;
		}
	}
	#endif
}

