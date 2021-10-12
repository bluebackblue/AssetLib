

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ディレクトリ存在チェック。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** ExistDirectoryWithAssetsPath
	*/
	public static class ExistDirectoryWithAssetsPath
	{
		/** チェック。

			a_assets_path	: 「Assets」からの相対パス。
			return == true	: 存在する。

		*/
		public static bool Check(string a_assets_path)
		{
			return System.IO.Directory.Exists(AssetLib.GetApplicationDataPath() + '\\' + a_assets_path);
		}
	}
}
#endif

