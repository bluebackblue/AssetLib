

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ディレクトリ削除。フルパス。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** DeleteDirectoryWithFullPath
	*/
	public static class DeleteDirectoryWithFullPath
	{
		/** 削除。

			a_full_path						: フルパス。

		*/
		public static bool Delete(string a_full_path)
		{
			System.IO.Directory.Delete(a_full_path,true);
			return true;
		}

		/** 削除。

			a_full_path						: フルパス。
			return == true					: 成功。

		*/
		public static bool TryDelete(string a_full_path)
		{
			#pragma warning disable 0168
			try{
				return Delete(a_full_path);
			}catch(System.IO.DirectoryNotFoundException t_exception){
				return false;
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_DEBUG_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return false;
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_DEBUG_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return false;
			}
			#pragma warning restore
		}
	}
}

