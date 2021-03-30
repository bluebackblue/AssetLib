

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ディレクトリ作成。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** CreateDirectory
	*/
	public class CreateDirectory
	{
		/** ディレクトリ作成。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static void CreateDirectoryToAssetsPath(string a_assets_path)
		{
			System.IO.Directory.CreateDirectory(UnityEngine.Application.dataPath + "/" + a_assets_path);
		}

		/** ディレクトリ作成。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static bool TryCreateDirectoryToAssetsPath(string a_assets_path)
		{
			bool t_result;

			try{
				if(System.IO.Directory.Exists(UnityEngine.Application.dataPath + "/" + a_assets_path) == false){
					CreateDirectoryToAssetsPath(a_assets_path);
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

