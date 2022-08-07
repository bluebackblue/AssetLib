

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ファイル存在チェック。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** ExistFileWithAssetsPath
	*/
	public static class ExistFileWithAssetsPath
	{
		/** チェック。

			a_assets_path_with_extention	: 「Assets」からの相対パス。拡張子付き。
			return == true					: 存在する。

		*/
		public static bool Check(string a_assets_path_with_extention)
		{
			return System.IO.File.Exists(AssetLib.application_data_path + '\\' + a_assets_path_with_extention);
		}
	}
}
#endif

