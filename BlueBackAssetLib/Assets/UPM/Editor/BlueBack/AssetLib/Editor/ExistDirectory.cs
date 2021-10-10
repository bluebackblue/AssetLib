

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ディレクトリ存在チェック。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** ExistDirectory
	*/
	public static class ExistDirectory
	{
		/** ディレクトリ存在チェック。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static bool IsExistDirectoryFromAssetsPath(string a_assets_path)
		{
			return System.IO.Directory.Exists(AssetLib.GetApplicationDataPath() + '/' + a_assets_path);
		}
	}
}
#endif

