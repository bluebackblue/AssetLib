

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief パッケージ作成。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreatePackage
	*/
	public class CreatePackage
	{
		/** パッケージ作成。

			a_assets_path	: パッケージ化するパス。「Assets」からの相対パス。
			a_package_name	: パッケージ名。
			a_exportoption	: エクスポートオプション。

		*/
		public static void CreatePackageFromAssetsPath(string a_assets_path,string a_package_name,UnityEditor.ExportPackageOptions a_exportoption)
		{
			UnityEditor.AssetDatabase.ExportPackage("Assets/" + a_assets_path,a_package_name,a_exportoption);
		}

		/** パッケージ作成。

			a_assets_path	: パッケージ化するパス。「Assets」からの相対パス。
			a_package_name	: パッケージ名。
			a_exportoption	: エクスポートオプション。

		*/
		public static bool TryCreatePackageFromAssetsPath(string a_assets_path,string a_package_name,UnityEditor.ExportPackageOptions a_exportoption)
		{
			bool t_result;

			#pragma warning disable 0168
			try{
				CreatePackageFromAssetsPath(a_assets_path,a_package_name,a_exportoption);
				t_result = true;
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
#endif

