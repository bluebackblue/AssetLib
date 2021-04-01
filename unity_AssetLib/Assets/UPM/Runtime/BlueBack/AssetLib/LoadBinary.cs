

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief バイナリロード。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** LoadBinary
	*/
	public class LoadBinary
	{
		/** バイナリロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static byte[] LoadBinaryFromAssetsPath(string a_assets_path_with_extention)
		{
			//ファイルパス。
			System.IO.FileInfo t_fileinfo = new System.IO.FileInfo(UnityEngine.Application.dataPath + "/" + a_assets_path_with_extention);

			//開く。
			using(System.IO.FileStream t_filestream = t_fileinfo.OpenRead()){
				byte[] t_result = new byte[t_filestream.Length];
				int t_ret_read = t_filestream.Read(t_result,0,t_result.Length);
				t_filestream.Close();

				if(t_ret_read != t_result.Length){
					return null;
				}

				return t_result;
			}
		}

		/** バイナリロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static byte[] TryLoadBinaryFromAssetsPath(string a_assets_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return LoadBinaryFromAssetsPath(a_assets_path_with_extention);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return null;
		}
	}
}

