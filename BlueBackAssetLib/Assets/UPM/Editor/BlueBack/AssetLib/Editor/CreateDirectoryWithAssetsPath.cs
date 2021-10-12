

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ディレクトリ作成。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreateDirectoryWithAssetsPath
	*/
	public static class CreateDirectoryWithAssetsPath
	{
		/** 作成。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static void Create(string a_assets_path)
		{
			CreateDirectoryWithFullPath.Create(AssetLib.GetApplicationDataPath() + '\\' + a_assets_path);
		}

		/** 作成。

			a_assets_path	: 「Assets」からの相対パス。
			return == true	: 成功。

		*/
		public static bool TryCreate(string a_assets_path)
		{
			#pragma warning disable 0168
			try{
				Create(a_assets_path);
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

