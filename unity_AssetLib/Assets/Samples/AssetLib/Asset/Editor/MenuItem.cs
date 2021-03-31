

/** Samples.AssetLib.Asset.Editor
*/
namespace Samples.AssetLib.Asset.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** アセットのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadAllAssetFromAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Asset_LoadAllAssetsFromAssetsPath()
		{
			//プレハブの保存。
			{
				UnityEngine.GameObject t_prefab = new UnityEngine.GameObject("temp");
				{
					t_prefab.AddComponent<A_MonoBehaviour>().value = 11;
					t_prefab.AddComponent<B_MonoBehaviour>().value = 22;
					BlueBack.AssetLib.SavePrefab.SavePrefabToAssetsPath(t_prefab,"Samples/AssetLib/ab.prefab");
				}
				UnityEngine.GameObject.DestroyImmediate(t_prefab);
				BlueBack.AssetLib.RefreshAsset.Refresh();
			}

			//全部。
			{
				UnityEngine.Object[] t_list = BlueBack.AssetLib.LoadAsset.LoadAllAssetsFromAssetsPath("Samples/AssetLib/ab.prefab");
				UnityEngine.Debug.Log(t_list.Length.ToString());
				for(int ii=0;ii<t_list.Length;ii++){
					UnityEngine.Debug.Log("LoadAllAssetsFromAssetsPath : " + t_list[ii].GetType().Name);
				}
			}

			//指定型。
			{
				System.Collections.Generic.List<UnityEngine.MonoBehaviour> t_list = BlueBack.AssetLib.LoadAsset.LoadAllSpecifiedAssetsFromAssetsPath<UnityEngine.MonoBehaviour>("Samples/AssetLib/ab.prefab");
				UnityEngine.Debug.Log(t_list.Count.ToString());
				for(int ii=0;ii<t_list.Count;ii++){
					int  t_value = 0;

					A_MonoBehaviour t_a = t_list[ii] as A_MonoBehaviour;
					if(t_a != null){
						t_value = t_a.value;
					}

					B_MonoBehaviour t_b = t_list[ii] as B_MonoBehaviour;
					if(t_b != null){
						t_value = t_b.value;
					}

					UnityEngine.Debug.Log("LoadAllSpecifiedAssetsFromAssetsPath : " + t_list[ii].GetType().Name + " : value = " + t_value.ToString());
				}
			}
		}

		/** テキストのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadTextFromAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Asset_LoadTextFromAssetsPath()
		{
			//テキストの保存。
			{
				BlueBack.AssetLib.SaveText.SaveUtf8TextToAssetsPath("xxxBBBxxx","Samples/AssetLib/xxx.txt",false);
				BlueBack.AssetLib.RefreshAsset.Refresh();
			}

			string t_text = BlueBack.AssetLib.LoadText.TryLoadTextFromAssetsPath("Samples/AssetLib/xxx.txt");
			UnityEngine.Debug.Log(t_text);
		}

		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveAnimationClipToAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Asset_SaveAnimationClipToAssetsPath()
		{
			//TODO:
		}

		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveBinaryToAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Asset_SaveBinaryToAssetsPath()
		{
			//TODO:
		}
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveMeshToAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Asset_SaveMeshToAssetsPath()
		{
			//TODO:
		}
	}
	#endif
}

