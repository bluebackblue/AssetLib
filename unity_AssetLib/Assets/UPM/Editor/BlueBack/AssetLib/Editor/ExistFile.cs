

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ファイル存在チェック。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** ExistFile
	*/
	public class ExistFile
	{
		/** ファイル存在チェック。

			a_assets_path	: 「Assets」からの相対パス。拡張子付き。

		*/
		public static bool IsExistFileFromAssetsPath(string a_assets_path_with_extention)
		{
			return System.IO.File.Exists(UnityEngine.Application.dataPath + '/' + a_assets_path_with_extention);
		}
	}
}
#endif

