

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief アセットロード。パッケージパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadAssetWithPackagesPath
	*/
	public static class LoadAssetWithPackagesPath
	{
		/** ロード。

			a_packages_path_with_extention	: 「Packages」からの相対パス。拡張子付き。

		*/
		public static T Load<T>(string a_packages_path_with_extention)
			where T : UnityEngine.Object
		{
			return UnityEditor.AssetDatabase.LoadAssetAtPath<T>("Packages\\" + a_packages_path_with_extention);
		}

		/** ロード。

			a_packages_path_with_extention	: 「Packages」からの相対パス。拡張子付き。

		*/
		public static MultiResult<bool,T> TryLoad<T>(string a_packages_path_with_extention)
			where T : UnityEngine.Object
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,T>(true,Load<T>(a_packages_path_with_extention));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_DEBUG_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,T>(false,null);
			}
			#pragma warning restore
		}

		/** ロード。すべて。

			a_packages_path_with_extention	: 「Packages」からの相対パス。拡張子付き。

		*/
		public static UnityEngine.Object[] LoadAll(string a_packages_path_with_extention)
		{
			return UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Packages\\" + a_packages_path_with_extention);
		}

		/** ロード。すべて。

			a_packages_path_with_extention	: 「Packages」からの相対パス。拡張子付き。

		*/
		public static MultiResult<bool,UnityEngine.Object[]> TryLoadAll(string a_packages_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,UnityEngine.Object[]>(true,LoadAll(a_packages_path_with_extention));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_DEBUG_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,UnityEngine.Object[]>(false,null);
			}
			#pragma warning restore
		}

		/** ロード。すべて。指定型のみ。

			a_packages_path_with_extention	: 「Packages」からの相対バス。拡張子付き。

		*/
		public static System.Collections.Generic.List<T> LoadAll<T>(string a_packages_path_with_extention)
			where T : class
		{
			System.Collections.Generic.List<T> t_list = new System.Collections.Generic.List<T>();
			UnityEngine.Object[] t_object_list = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Packages\\" + a_packages_path_with_extention);
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

		/** ロード。すべて。指定型のみ。

			a_packages_path_with_extention	: 「Packages」からの相対パス。拡張子付き。

		*/
		public static MultiResult<bool,System.Collections.Generic.List<T>> TryLoadAll<T>(string a_packages_path_with_extention)
			where T : class
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,System.Collections.Generic.List<T>>(true,LoadAll<T>(a_packages_path_with_extention));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_DEBUG_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,System.Collections.Generic.List<T>>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

