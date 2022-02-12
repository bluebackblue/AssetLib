

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アセットロード。アセットバンドル。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadAssetWithAssetBundle
	*/
	public static class LoadAssetWithAssetBundle
	{
		/** ロード。

			a_assetbundle		: アセットバンドル。
			a_assetbundle_path	: アセットバンドル内の相対パス。

		*/
		public static T Load<T>(UnityEngine.AssetBundle a_assetbundle,string a_assetbundle_path)
			where T : UnityEngine.Object
		{
			return a_assetbundle.LoadAsset<T>(a_assetbundle_path);
		}

		/** ロード。

			a_assetbundle		: アセットバンドル。
			a_assetbundle_path	: アセットバンドル内の相対パス。

		*/
		public static MultiResult<bool,T> TryLoad<T>(UnityEngine.AssetBundle a_assetbundle,string a_assetbundle_path)
			where T : UnityEngine.Object
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,T>(true,Load<T>(a_assetbundle,a_assetbundle_path));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,T>(false,null);
			}
			#pragma warning restore
		}

		/** ロード。すべて。

			a_assetbundle		: アセットバンドル。

		*/
		public static UnityEngine.Object[] LoadAll(UnityEngine.AssetBundle a_assetbundle)
		{
			return a_assetbundle.LoadAllAssets();
		}

		/** ロード。すべて。

			a_assetbundle		: アセットバンドル。

		*/
		public static MultiResult<bool,UnityEngine.Object[]> TryLoadAll(UnityEngine.AssetBundle a_assetbundle)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,UnityEngine.Object[]>(true,LoadAll(a_assetbundle));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,UnityEngine.Object[]>(false,null);
			}
			#pragma warning restore
		}

		/** ロード。すべて。指定型のみ。

			a_assetbundle		: アセットバンドル。

		*/
		public static System.Collections.Generic.List<T> LoadAll<T>(UnityEngine.AssetBundle a_assetbundle)
			where T : UnityEngine.Object
		{
			System.Collections.Generic.List<T> t_list = new System.Collections.Generic.List<T>();
			UnityEngine.Object[] t_object_list = a_assetbundle.LoadAllAssets();
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

			a_assetbundle		: アセットバンドル。

		*/
		public static MultiResult<bool,System.Collections.Generic.List<T>> TryLoadAll<T>(UnityEngine.AssetBundle a_assetbundle)
			where T : UnityEngine.Object
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,System.Collections.Generic.List<T>>(true,LoadAll<T>(a_assetbundle));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,System.Collections.Generic.List<T>>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

