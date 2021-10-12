

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief パッケージ作成。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreatePackageWithAssetsPath
	*/
	public static class CreatePackageWithAssetsPath
	{
		/** パッケージ作成。

			a_assets_path	: パッケージ化するパス。「Assets」からの相対パス。
			a_package_name	: パッケージ名。
			a_exportoption	: エクスポートオプション。

		*/
		public static void Create(string a_assets_path,string a_package_name,UnityEditor.ExportPackageOptions a_exportoption)
		{
			UnityEditor.AssetDatabase.ExportPackage("Assets/" + a_assets_path,a_package_name,a_exportoption);
		}

		/** パッケージ作成。

			a_assets_path	: パッケージ化するパス。「Assets」からの相対パス。
			a_package_name	: パッケージ名。
			a_exportoption	: エクスポートオプション。
			return == true	: 成功。

		*/
		public static bool TryCreate(string a_assets_path,string a_package_name,UnityEditor.ExportPackageOptions a_exportoption)
		{
			#pragma warning disable 0168
			try{
				Create(a_assets_path,a_package_name,a_exportoption);
				return true;
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return false;
			}
			#pragma warning restore
		}
	}
}
#endif

