

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ディレクトリ作成。フルパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreateDirectoryWithFullPath
	*/
	public static class CreateDirectoryWithFullPath
	{
		/** 作成。

			a_full_path	: 絶対バス。

		*/
		public static void Create(string a_full_path)
		{
			System.IO.Directory.CreateDirectory(a_full_path);
		}

		/** 作成。

			a_full_path		: 絶対バス。
			return == true	: 成功。

		*/
		public static bool TryCreate(string a_full_path)
		{
			#pragma warning disable 0168
			try{
				Create(a_full_path);
				return true;
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

