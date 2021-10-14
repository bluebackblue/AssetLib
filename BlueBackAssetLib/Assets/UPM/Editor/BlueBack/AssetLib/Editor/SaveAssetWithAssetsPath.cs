

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アセットセーブ。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** SaveAssetWithAssetsPath
	*/
	public static class SaveAssetWithAssetsPath
	{
		/** セーブ。

			a_assets_path_with_extention	:  「Assets」からの相対パス。拡張子付き。

		*/
		public static bool Save<T>(T a_asset,string a_assets_path_with_extention)
			where T : UnityEngine.Object
		{
			UnityEditor.AssetDatabase.CreateAsset(a_asset,"Assets/" + a_assets_path_with_extention);
			return true;
		}

		/** セーブ。

			a_assets_path_with_extention	:  「Assets」からの相対パス。拡張子付き。

		*/
		public static bool TrySave<T>(T a_asset,string a_assets_path_with_extention)
			where T : UnityEngine.Object
		{
			#pragma warning disable 0168
			try{
				return Save(a_asset,a_assets_path_with_extention);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return false;
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return false;
			}
			#pragma warning restore
		}

		/** セーブ。別名。

			a_assets_path_with_extention	:  「Assets」からの相対パス。拡張子付き。

		*/
		public static T SaveAs<T>(T a_asset,string a_assets_path_with_extention)
			where T : UnityEngine.Object
		{
			T t_asset = UnityEngine.Object.Instantiate<T>(a_asset);
			Save(t_asset,a_assets_path_with_extention);
			return t_asset;
		}

		/** セーブ。別名。

			a_assets_path_with_extention	:  「Assets」からの相対パス。拡張子付き。

		*/
		public static MultiResult<bool,T> TrySaveAs<T>(T a_asset,string a_assets_path_with_extention)
			where T : UnityEngine.Object
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,T>(true,SaveAs(a_asset,a_assets_path_with_extention));
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,T>(false,null);
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

