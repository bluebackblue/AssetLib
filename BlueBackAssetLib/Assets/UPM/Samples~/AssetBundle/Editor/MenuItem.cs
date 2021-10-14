

/** Samples.AssetLib.AssetBundle.Editor
*/
namespace Samples.AssetLib.AssetBundle.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** CreateAssetBundleWithAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/AssetBundle/CreateAssetBundleWithAssetsPath")]
		private static void MenuItem_CreateAssetBundleWithAssetsPath()
		{
			//事前処理。
			{
				BlueBack.AssetLib.Editor.DeleteDirectoryWithAssetsPath.TryDelete("Out/AssetBundleIn");
				BlueBack.AssetLib.Editor.DeleteDirectoryWithAssetsPath.TryDelete("Out/AssetBundleOut");
				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out/AssetBundleIn");
				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out/AssetBundleOut");
				BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveUtf8("text","Out/AssetBundleIn/text.txt",false,BlueBack.AssetLib.LineFeedOption.CRLF);
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}

			//CreateAssetBundleWithAssetsPath
			{
				BlueBack.AssetLib.Editor.CreateAssetBundleWithAssetsPath.Create(
					"Out/AssetBundleOut",
					new UnityEditor.AssetBundleBuild[]{
						new UnityEditor.AssetBundleBuild(){
							assetBundleName = "test.assetbundle",
							assetBundleVariant = null,
							assetNames = new string[]{"Assets/Out/AssetBundleIn/text.txt"},
							addressableNames = null,
						}
					},
					UnityEditor.BuildAssetBundleOptions.DeterministicAssetBundle,
					UnityEditor.EditorUserBuildSettings.activeBuildTarget
				);
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}

			//ログ。
			{
				UnityEngine.AssetBundle t_assetbundle = UnityEngine.AssetBundle.LoadFromFile("Assets/Out/AssetBundleOut/test.assetbundle");
				UnityEngine.Debug.Log(t_assetbundle.LoadAsset<UnityEngine.TextAsset>("text").text);
				t_assetbundle.Unload(false);
			}
		}
	}
	#endif
}

