

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アセットバンドル作成。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreateAssetBundle
	*/
	public class CreateAssetBundle
	{
		/** アセットバンドル作成。

			a_assets_path	: 出力フォルダ。「Assets」からの相対パス。
			a_list			: アセットバンドル化するリスト。
			a_buildoption	: ビルドオプション。
			a_buildtarget	: ビルドターゲット。

		*/
		
		public static UnityEngine.AssetBundleManifest CreateAssetBundleToAssetsPath(string a_assets_path,UnityEditor.AssetBundleBuild[] a_list,UnityEditor.BuildAssetBundleOptions a_buildoption,UnityEditor.BuildTarget a_buildtarget)
		{
			return UnityEditor.BuildPipeline.BuildAssetBundles("Assets/" + a_assets_path,a_list,a_buildoption,a_buildtarget);
		}

		/** アセットバンドル作成。

			a_assets_path	: 出力フォルダ。「Assets」からの相対パス。
			a_list			: アセットバンドル化するリスト。
			a_buildoption	: ビルドオプション。
			a_buildtarget	: ビルドターゲット。

		*/
		public static Result<UnityEngine.AssetBundleManifest> TryCreateAssetBundleToAssetsPath(string a_assets_path,UnityEditor.AssetBundleBuild[] a_list,UnityEditor.BuildAssetBundleOptions a_buildoption,UnityEditor.BuildTarget a_buildtarget)
		{
			Result<UnityEngine.AssetBundleManifest> t_result;

			#pragma warning disable 0168
			try{
				t_result.value = CreateAssetBundleToAssetsPath(a_assets_path,a_list,a_buildoption,a_buildtarget);
				t_result.success = true;
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif

				t_result.success = false;
				t_result.value = null;
			}
			#pragma warning restore

			return t_result;
		}
	}
}
#endif

