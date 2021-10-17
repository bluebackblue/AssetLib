

/** Samples.Asset
*/
namespace Samples.Asset
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** LoadAssetWithAssetsPath
		*/
		[UnityEditor.MenuItem("ƒTƒ“ƒvƒ‹/AssetLib/Asset/LoadAssetWithAssetsPath")]
		private static void MenuItem_LoadAssetWithAssetsPath()
		{
			//SaveAssetWithAssetsPath
			{
				UnityEngine.Mesh t_mesh = new UnityEngine.Mesh();
				{
					System.Collections.Generic.List<UnityEngine.Vector3> t_vertex_list = new System.Collections.Generic.List<UnityEngine.Vector3>();
					System.Collections.Generic.List<UnityEngine.Vector3> t_nomal_list = new System.Collections.Generic.List<UnityEngine.Vector3>();
					System.Collections.Generic.List<int> t_index_list = new System.Collections.Generic.List<int>();
					{
						t_vertex_list.Add(new UnityEngine.Vector3(0.0f,0.0f,0.0f));
						t_vertex_list.Add(new UnityEngine.Vector3(0.0f,1.0f,0.0f));
						t_vertex_list.Add(new UnityEngine.Vector3(0.0f,0.0f,1.0f));
						t_nomal_list.Add(new UnityEngine.Vector3(0.0f,0.0f,1.0f));
						t_nomal_list.Add(new UnityEngine.Vector3(0.0f,0.0f,1.0f));
						t_nomal_list.Add(new UnityEngine.Vector3(0.0f,0.0f,1.0f));
						t_index_list.Add(0);
						t_index_list.Add(1);
						t_index_list.Add(2);
					}
					t_mesh.vertices = t_vertex_list.ToArray();
					t_mesh.normals = t_nomal_list.ToArray();
					t_mesh.triangles = t_index_list.ToArray();
					t_mesh.RecalculateNormals();
					t_mesh.RecalculateBounds();
					t_mesh.RecalculateTangents();
				}

				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out");
				BlueBack.AssetLib.Editor.SaveAssetWithAssetsPath.Save<UnityEngine.Mesh>(t_mesh,"Out/test.mesh");
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}

			//LoadAssetWithAssetsPath
			{
				UnityEngine.Mesh t_mesh = BlueBack.AssetLib.Editor.LoadAssetWithAssetsPath.Load<UnityEngine.Mesh>("Out/test.mesh");
				UnityEngine.Debug.Log(t_mesh.triangles.Length.ToString());
			}
		}
	}
	#endif
}

