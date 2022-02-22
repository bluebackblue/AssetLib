

/** BlueBack.AssetLib.Samples.Prefab.Editor
*/
namespace BlueBack.AssetLib.Samples.Prefab.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** SavePrefabWithAssetsPath
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Prefab/SavePrefabWithAssetsPath")]
		private static void MenuItem_SavePrefabWithAssetsPath()
		{
			UnityEngine.GameObject t_gameobject = new UnityEngine.GameObject("new");
			{
			}

			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out");

			{
				UnityEngine.GameObject t_prefab_1 = BlueBack.AssetLib.Editor.SavePrefabWithAssetsPath.Save(t_gameobject,"Out/test1.prefab");
				UnityEngine.Debug.Log(UnityEditor.AssetDatabase.GetAssetPath(t_prefab_1));
			}
			{
				UnityEngine.GameObject t_prefab_2 = BlueBack.AssetLib.Editor.SavePrefabWithAssetsPath.Save(t_gameobject,"Out/test2.prefab");
				UnityEngine.Debug.Log(UnityEditor.AssetDatabase.GetAssetPath(t_prefab_2));
			}
			{
				UnityEngine.GameObject t_prefab_3 = BlueBack.AssetLib.Editor.SavePrefabWithAssetsPath.Save(t_gameobject,"Out/test3.prefab");
				UnityEngine.Debug.Log(UnityEditor.AssetDatabase.GetAssetPath(t_prefab_3));
			}

			UnityEngine.GameObject.DestroyImmediate(t_gameobject);
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}

		/** SaveBinaryWithAssetsPath
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Prefab/SavePrefabWithAssetsPath_SaveAs")]
		private static void MenuItem_SavePrefabWithAssetsPath_SaveAs()
		{
			UnityEngine.GameObject t_prefab;
			{
				UnityEngine.GameObject t_gameobject = new UnityEngine.GameObject("new");
				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out");
				t_prefab = BlueBack.AssetLib.Editor.SavePrefabWithAssetsPath.Save(t_gameobject,"Out/test.prefab");
				UnityEngine.Debug.Log(UnityEditor.AssetDatabase.GetAssetPath(t_prefab));
				UnityEngine.GameObject.DestroyImmediate(t_gameobject);
			}

			{
				UnityEngine.GameObject t_prefab_1 = BlueBack.AssetLib.Editor.SavePrefabWithAssetsPath.SaveAs(t_prefab,"Out/test1.prefab");
				UnityEngine.Debug.Log(UnityEditor.AssetDatabase.GetAssetPath(t_prefab_1));
			}
			{
				UnityEngine.GameObject t_prefab_2 = BlueBack.AssetLib.Editor.SavePrefabWithAssetsPath.SaveAs(t_prefab,"Out/test2.prefab");
				UnityEngine.Debug.Log(UnityEditor.AssetDatabase.GetAssetPath(t_prefab_2));
			}
			{
				UnityEngine.GameObject t_prefab_3 = BlueBack.AssetLib.Editor.SavePrefabWithAssetsPath.SaveAs(t_prefab,"Out/test3.prefab");
				UnityEngine.Debug.Log(UnityEditor.AssetDatabase.GetAssetPath(t_prefab_3));
			}

			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
	}
	#endif
}

