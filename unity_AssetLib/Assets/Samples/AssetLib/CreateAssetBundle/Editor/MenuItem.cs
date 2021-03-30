

/** Samples.AssetLib.CreateAssetBundle
*/
namespace Samples.AssetLib.CreateAssetBundle.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		[UnityEditor.MenuItem("サンプル/AssetLib/CreateAssetBundle")]
		private static void MenuItem_Sample_AssetLib_CreateAssetBundle()
		{
			UnityEditor.AssetBundleBuild[] t_list = new UnityEditor.AssetBundleBuild[]{
				new UnityEditor.AssetBundleBuild(){
					assetBundleName = "sample.assetbundle",
					assetBundleVariant = "sample",
					assetNames = new string[]{
						"Assets/Samples/AssetLib/CreateAssetBundle/Data/data.txt",
					},
					addressableNames = new string[]{
						"data",
					},
				}	
			};

			BlueBack.AssetLib.CreateAssetBundle.CreateAssetBundleToAssetsPath("Samples/AssetLib/CreateAssetBundle/Data",t_list,UnityEditor.BuildAssetBundleOptions.None,UnityEditor.EditorUserBuildSettings.activeBuildTarget);
			BlueBack.AssetLib.RefreshAsset.Refresh();
		}
	}
	#endif
}

