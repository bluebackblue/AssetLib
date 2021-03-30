

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

			#pragma warning disable 0168
			try{
				if(System.IO.Directory.Exists(UnityEngine.Application.dataPath + "/" + a_assets_path) == false){
					System.IO.Directory.Delete(UnityEngine.Application.dataPath + "/" + a_assets_path,true);
					t_result = true;
				}else{
					t_result = false;
				}
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

