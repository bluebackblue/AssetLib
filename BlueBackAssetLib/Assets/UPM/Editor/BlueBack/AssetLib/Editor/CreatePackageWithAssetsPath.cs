

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief パッケージ作成。アセットパス。
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

			a_assets_path							: パッケージ化するパス。「Assets」からの相対パス。
			a_assets_path_unitypackage_filename		: 「xxx.unitypackage」。
			a_option								: オプション。

		*/
		public static bool Create(string a_assets_path,string a_assets_path_unitypackage_filename,UnityEditor.ExportPackageOptions a_option)
		{
			UnityEditor.AssetDatabase.ExportPackage("Assets/" + a_assets_path,"Assets/" + a_assets_path_unitypackage_filename,a_option);
			return true;
		}

		/** パッケージ作成。

			a_assets_path							: パッケージ化するパス。「Assets」からの相対パス。
			a_assets_path_unitypackage_filename		: 「xxx.unitypackage」。
			a_option								: オプション。
			return == true							: 成功。

		*/
		public static bool TryCreate(string a_assets_path,string a_assets_path_unitypackage_filename,UnityEditor.ExportPackageOptions a_option)
		{
			#pragma warning disable 0168
			try{
				return Create(a_assets_path,a_assets_path_unitypackage_filename,a_option);
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

