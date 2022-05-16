

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief アセットロード。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadAssetWithAssetsPath
	*/
	public static class LoadAssetWithAssetsPath
	{
		/** ロード。

			a_assets_path_with_extention	:「Assets」からの相対パス。拡張子付き。

		*/
		public static T Load<T>(string a_assets_path_with_extention)
			where T : UnityEngine.Object
		{
			return UnityEditor.AssetDatabase.LoadAssetAtPath<T>("Assets/" + a_assets_path_with_extention);
		}

		/** ロード。

			a_assets_path_with_extention	:「Assets」からの相対パス。拡張子付き。

		*/
		public static MultiResult<bool,T> TryLoad<T>(string a_assets_path_with_extention)
			where T : UnityEngine.Object
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,T>(true,Load<T>(a_assets_path_with_extention));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,T>(false,null);
			}
			#pragma warning restore
		}

		/** ロード。すべて。

			a_assets_path_with_extention	:「Assets」からの相対パス。拡張子付き。

		*/
		public static UnityEngine.Object[] LoadAll(string a_assets_path_with_extention)
		{
			return UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Assets/" + a_assets_path_with_extention);
		}

		/** ロード。すべて。

			a_assets_path_with_extention	:「Assets」からの相対パス。拡張子付き。

		*/
		public static MultiResult<bool,UnityEngine.Object[]> TryLoadAll(string a_assets_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,UnityEngine.Object[]>(true,LoadAll(a_assets_path_with_extention));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,UnityEngine.Object[]>(false,null);
			}
			#pragma warning restore
		}

		/** ロード。すべて。指定型のみ。

			a_assets_path_with_extention	:「Assets」からの相対バス。拡張子付き。

		*/
		public static System.Collections.Generic.List<T> LoadAll<T>(string a_assets_path_with_extention)
			where T : UnityEngine.Object
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

		/** ロード。すべて。指定型のみ。

			a_assets_path_with_extention	:「Assets」からの相対パス。拡張子付き。

		*/
		public static MultiResult<bool,System.Collections.Generic.List<T>> TryLoadAll<T>(string a_assets_path_with_extention)
			where T : UnityEngine.Object
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,System.Collections.Generic.List<T>>(true,LoadAll<T>(a_assets_path_with_extention));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,System.Collections.Generic.List<T>>(false,null);
			}
			#pragma warning restore
		}

		/** ロード。コンバター。

			a_converter						: コンバター。
			a_assets_path_with_extention	:「Assets」からの相対バス。拡張子付き。

		*/
		public static T LoadConverter<T>(ConverterBinaryToAsset_Base<T> a_converter,string a_assets_path_with_extention)
			where T : UnityEngine.Object
		{
			return a_converter.Convert(LoadBinaryWithAssetsPath.Load(a_assets_path_with_extention));
		}

		/** ロード。コンバター。

			a_converter						: コンバター。
			a_assets_path_with_extention	:「Assets」からの相対バス。拡張子付き。

		*/
		public static MultiResult<bool,T> TryLoadConverter<T>(ConverterBinaryToAsset_Base<T> a_converter,string a_assets_path_with_extention)
			where T : UnityEngine.Object
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,T>(true,LoadConverter<T>(a_converter,a_assets_path_with_extention));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,T>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

