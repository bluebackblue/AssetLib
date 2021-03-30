

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ディレクトリ削除。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** DeleteDirectory
	*/
	public class DeleteDirectory
	{
		/** ディレクトリ削除。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static void DeleteDirectoryFromAssetsPath(string a_assets_path)
		{
			System.IO.Directory.Delete(UnityEngine.Application.dataPath + "/" + a_assets_path,true);
		}

		/** ディレクトリ削除。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static bool TryDeleteDirectoryFromAssetsPath(string a_assets_path)
		{
			bool t_result;

			try{
				if(System.IO.Directory.Exists(UnityEngine.Application.dataPath + "/" + a_assets_path) == false){
					System.IO.Directory.Delete(UnityEngine.Application.dataPath + "/" + a_assets_path,true);
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

