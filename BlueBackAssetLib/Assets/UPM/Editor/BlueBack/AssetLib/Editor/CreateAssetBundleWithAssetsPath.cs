

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アセットバンドル作成。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreateAssetBundleWithAssetsPath
	*/
	public static class CreateAssetBundleWithAssetsPath
	{
		/** 作成。

			a_assets_path					: 出力フォルダ。「Assets」からの相対パス。
			a_list							: アセットバンドル化するリスト。
			a_buildoption					: ビルドオプション。
			a_buildtarget					: ビルドターゲット。

		*/
		
		public static UnityEngine.AssetBundleManifest Create(string a_assets_path,UnityEditor.AssetBundleBuild[] a_list,UnityEditor.BuildAssetBundleOptions a_buildoption,UnityEditor.BuildTarget a_buildtarget)
		{
			return UnityEditor.BuildPipeline.BuildAssetBundles("Assets/" + a_assets_path,a_list,a_buildoption,a_buildtarget);
		}

		/** 作成。

			a_assets_path					: 出力フォルダ。「Assets」からの相対パス。
			a_list							: アセットバンドル化するリスト。
			a_buildoption					: ビルドオプション。
			a_buildtarget					: ビルドターゲット。
			return.result == true			: 成功。

		*/
		public static MultiResult<bool,UnityEngine.AssetBundleManifest> TryCreate(string a_assets_path,UnityEditor.AssetBundleBuild[] a_list,UnityEditor.BuildAssetBundleOptions a_buildoption,UnityEditor.BuildTarget a_buildtarget)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,UnityEngine.AssetBundleManifest>(true,Create(a_assets_path,a_list,a_buildoption,a_buildtarget));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,UnityEngine.AssetBundleManifest>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

