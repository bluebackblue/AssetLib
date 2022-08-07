

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ディレクトリ作成。フルパス。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** CreateDirectoryWithFullPath
	*/
	public static class CreateDirectoryWithFullPath
	{
		/** 作成。

			a_full_path						: フルパス。

		*/
		public static System.IO.DirectoryInfo Create(string a_full_path)
		{
			return System.IO.Directory.CreateDirectory(a_full_path);
		}

		/** 作成。

			a_full_path						: フルパス。
			return == true					: 成功。

		*/
		public static MultiResult<bool,System.IO.DirectoryInfo> TryCreate(string a_full_path)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,System.IO.DirectoryInfo>(true,Create(a_full_path));
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,System.IO.DirectoryInfo>(false,null);
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,System.IO.DirectoryInfo>(false,null);
			}
			#pragma warning restore
		}
	}
}

