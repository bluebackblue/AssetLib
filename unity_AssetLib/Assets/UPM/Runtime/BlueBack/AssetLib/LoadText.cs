

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief テキストロード。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** LoadText
	*/
	public class LoadText
	{
		/** テキストロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static string LoadTextFromAssetsPath(string a_assets_path_with_extention)
		{
			using(System.IO.StreamReader t_stream = new System.IO.StreamReader(UnityEngine.Application.dataPath + "/" + a_assets_path_with_extention)){
				string t_result = t_stream.ReadToEnd();
				t_stream.Close();
				return t_result;
			}
		}

		/** テキストロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static string TryLoadTextFromAssetsPath(string a_assets_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return LoadTextFromAssetsPath(a_assets_path_with_extention);
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

