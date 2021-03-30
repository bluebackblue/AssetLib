

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ファイル削除。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** DeleteFile
	*/
	public class DeleteFile
	{
		/** ファイル削除。

			a_assets_path	: 「Assets」からの相対パス。拡張子付き。

		*/
		public static void DeleteFileFromAssetsPath(string a_assets_path_with_extention)
		{
			System.IO.File.Delete(a_assets_path_with_extention);
		}

		/** ファイル削除。
		*/
		public static bool TryDeleteFileFromAssetsPath(string a_assets_path_with_extention)
		{
			bool t_result;

			try{
				if(System.IO.File.Exists(a_assets_path_with_extention) == true){
					System.IO.File.Delete(a_assets_path_with_extention);
					t_result = true;
				}else{
					t_result = false;
				}
			}catch(System.IO.IOException /*t_exception*/){
				DebugTool.Assert(false);
				t_result = false;
			}catch(System.Exception /*t_exception*/){
				DebugTool.Assert(false);
				t_result = false;
			}

			return t_result;
		}
	}
}

