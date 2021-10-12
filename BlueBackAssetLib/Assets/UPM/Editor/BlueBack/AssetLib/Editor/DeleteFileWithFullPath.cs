

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

			a_full_path_with_extention		: 絶対パス。拡張子付き。

		*/
		public static void Delete(string a_full_path)
		{
			System.IO.File.Delete(a_full_path);
		}

		/** 削除。

			a_full_path_with_extention		: 絶対パス。拡張子付き。
			returns == true					: 成功。

		*/
		public static bool TryDelete(string a_full_path)
		{
			#pragma warning disable 0168
			try{
				Delete(a_full_path);
				return true;
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

