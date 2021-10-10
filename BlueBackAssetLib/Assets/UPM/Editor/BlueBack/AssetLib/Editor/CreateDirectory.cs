

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ディレクトリ作成。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreateDirectory
	*/
	public static class CreateDirectory
	{
		/** ディレクトリ作成。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static void CreateDirectoryToAssetsPath(string a_assets_path)
		{
			System.IO.Directory.CreateDirectory(AssetLib.GetApplicationDataPath() + '/' + a_assets_path);
		}

		/** ディレクトリ作成。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static bool TryCreateDirectoryToAssetsPath(string a_assets_path)
		{
			bool t_result;

			#pragma warning disable 0168
			try{
				CreateDirectoryToAssetsPath(a_assets_path);
				t_result = true;
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif

				t_result = false;
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif

				t_result = false;
			}
			#pragma warning restore

			return t_result;
		}
	}
}
#endif

