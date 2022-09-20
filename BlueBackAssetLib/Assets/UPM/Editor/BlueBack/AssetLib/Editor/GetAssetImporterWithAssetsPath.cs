

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief インポーター取得。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** GetAssetImporterWithAssetsPath
	*/
	public static class GetAssetImporterWithAssetsPath
	{
		/** 取得。

			a_assets_path_with_extention	: 「Assets」からの相対パス。拡張子付き。

		*/
		public static T Get<T>(string a_assets_path_with_extention)
			where T : UnityEditor.AssetImporter
		{
			return UnityEditor.AssetImporter.GetAtPath("Assets\\" + a_assets_path_with_extention) as T;
		}

		/** 取得。

			a_assets_path_with_extention	: 「Assets」からの相対パス。拡張子付き。

		*/
		public static MultiResult<bool,T> TryGet<T>(string a_assets_path_with_extention)
			where T : UnityEditor.AssetImporter
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,T>(true,Get<T>(a_assets_path_with_extention));
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,T>(false,null);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,T>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

