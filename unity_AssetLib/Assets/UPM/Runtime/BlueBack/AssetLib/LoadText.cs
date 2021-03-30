

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief テキストのロード。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** LoadText
	*/
	public class LoadText
	{
		/** テキストファイル読み込み。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static Result<string> ReadTextFile(string a_assets_path_with_extention)
		{
			Result<string> t_result = new Result<string>(){success = false,value = null,};

			using(System.IO.StreamReader t_stream = new System.IO.StreamReader(UnityEngine.Application.dataPath + "/" + a_assets_path_with_extention)){
				t_result.value = t_stream.ReadToEnd();
				t_result.success = true;
				t_stream.Close();
			}

			return t_result;
		}
	}
}

