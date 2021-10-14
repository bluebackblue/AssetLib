

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ファイル削除。フルパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** DeleteFileWithFullPath
	*/
	public static class DeleteFileWithFullPath
	{
		/** 削除。

			a_full_path_with_extention		: フルパス。拡張子付き。

		*/
		public static bool Delete(string a_full_path_with_extention)
		{
			System.IO.File.Delete(a_full_path_with_extention);
			return true;
		}

		/** 削除。

			a_full_path_with_extention		: フルパス。拡張子付き。
			returns == true					: 成功。

		*/
		public static bool TryDelete(string a_full_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return Delete(a_full_path_with_extention);
			}catch(System.IO.FileNotFoundException t_exception){
				return false;
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
	}
}
#endif

