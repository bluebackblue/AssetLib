

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＵＩＤロード。フルパス。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
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
				string t_guid = Load(a_full_path_with_extention);
				if(t_guid != null){
					return new MultiResult<bool,string>(true,t_guid);
				}else{
					return new MultiResult<bool,string>(false,null);
				}
			}catch(System.IO.FileNotFoundException t_exception){
				//ファイルなし。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,string>(false,null);
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,string>(false,null);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,string>(false,null);
			}
			#pragma warning restore
		}
	}
}

