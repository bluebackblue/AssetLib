

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ディレクトリ削除。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** DeleteDirectoryWithAssetsPath
	*/
	public static class DeleteDirectoryWithAssetsPath
	{
		/** 削除。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static void Delete(string a_assets_path)
		{
			DeleteDirectoryWithFullPath.Delete(AssetLib.GetApplicationDataPath() + '\\' + a_assets_path);
		}

		/** 削除。

			a_assets_path	: 「Assets」からの相対パス。
			return == true	: 成功。

		*/
		public static bool TryDelete(string a_assets_path)
		{
			#pragma warning disable 0168
			try{
				Delete(a_assets_path);
				return true;
			}catch(System.IO.DirectoryNotFoundException t_exception){
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

