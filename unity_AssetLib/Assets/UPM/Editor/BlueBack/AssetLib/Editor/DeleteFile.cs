

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ファイル削除。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** DeleteFile
	*/
	public class DeleteFile
	{
		/** ファイル削除。

			a_assets_path_with_extention	: 「Assets」からの相対パス。拡張子付き。

		*/
		public static void DeleteFileFromAssetsPath(string a_assets_path_with_extention)
		{
			System.IO.File.Delete(AssetLib.GetApplicationDataPath() + '/' + a_assets_path_with_extention);
		}

		/** ファイル削除。

			a_assets_path_with_extention	: 「Assets」からの相対パス。拡張子付き。

		*/
		public static bool TryDeleteFileFromAssetsPath(string a_assets_path_with_extention)
		{
			bool t_result;

			#pragma warning disable 0168
			try{
				DeleteFileFromAssetsPath(a_assets_path_with_extention);
				t_result = true;
			}catch(System.IO.FileNotFoundException t_exception){
				t_result = false;
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

