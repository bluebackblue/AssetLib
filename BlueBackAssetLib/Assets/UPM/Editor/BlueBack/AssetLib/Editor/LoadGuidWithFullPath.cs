

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＵＩＤロード。フルパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadGuidWithFullPath
	*/
	public static class LoadGuidWithFullPath
	{
		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。

		*/
		public static string Load(string a_full_path_with_extention)
		{
			return LoadGuidWithMetaString.Load(LoadTextWithFullPath.Load(a_full_path_with_extention));
		}

		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。

		*/
		public static MultiResult<bool,string> TryLoad(string a_full_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,Load(a_full_path_with_extention));
			}catch(System.IO.FileNotFoundException t_exception){
				return new MultiResult<bool,string>(false,null);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,string>(false,null);
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,string>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

