

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＵＩＤロード。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadGuidWithAssetsPath
	*/
	public static class LoadGuidWithAssetsPath
	{
		/** ロード。

			a_assets_path_with_extention	:  「Assets」からの相対パス。拡張子付き。
			a_encoding						: 文字列エンコード。

		*/
		public static string Load(string a_assets_path_with_extention)
		{
			return LoadGuidWithFullPath.Load(AssetLib.application_data_path + '\\' + a_assets_path_with_extention);
		}

		/** ロード。

			a_assets_path_with_extention	:  「Assets」からの相対パス。拡張子付き。
			a_encoding						: 文字列エンコード。

		*/
		public static MultiResult<bool,string> TryLoad(string a_assets_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,Load(a_assets_path_with_extention));
			}catch(System.IO.FileNotFoundException t_exception){
				return new MultiResult<bool,string>(false,null);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,string>(false,null);
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,string>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

