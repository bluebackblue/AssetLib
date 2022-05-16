

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ファイル存在チェック。フルパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** ExistFileWithFullPath
	*/
	public static class ExistFileWithFullPath
	{
		/** チェック。

			a_full_path_with_extention		: フルパス。拡張子付き。
			return == true					: 存在する。

		*/
		public static bool Check(string a_full_path_with_extention)
		{
			return System.IO.File.Exists(a_full_path_with_extention);
		}
	}
}
#endif

