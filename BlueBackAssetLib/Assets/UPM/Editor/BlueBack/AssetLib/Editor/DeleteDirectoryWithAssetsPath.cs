

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ディレクトリ削除。アセットパス。
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

			a_assets_path					: 「Assets」からの相対パス。

		*/
		public static bool Delete(string a_assets_path)
		{
			return DeleteDirectoryWithFullPath.Delete(AssetLib.GetApplicationDataPath() + '\\' + a_assets_path);
		}

		/** 削除。

			a_assets_path					: 「Assets」からの相対パス。
			return == true					: 成功。

		*/
		public static bool TryDelete(string a_assets_path)
		{
			#pragma warning disable 0168
			try{
				return Delete(a_assets_path);
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

