

/** BlueBack.AssetLib.Samples.StlConverter.Editor
*/
namespace BlueBack.AssetLib.Samples.StlConverter.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** LoadBinaryWithAssetsPath
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/StlConverter/LoadBinaryWithAssetsPath")]
		private static void MenuItem_LoadBinaryWithAssetsPath()
		{
			//SaveBinaryWithAssetsPath
			{
				UnityEngine.Mesh t_mesh = new UnityEngine.Mesh();
				{
					System.Collections.Generic.List<UnityEngine.Vector3> t_vertex_list = new System.Collections.Generic.List<UnityEngine.Vector3>();
					System.Collections.Generic.List<UnityEngine.Vector3> t_nomal_list = new System.Collections.Generic.List<UnityEngine.Vector3>();
					System.Collections.Generic.List<int> t_index_list = new System.Collections.Generic.List<int>();
					{
						t_vertex_list.Add(new UnityEngine.Vector3(0.0f,0.0f,0.0f));
						t_vertex_list.Add(new UnityEngine.Vector3(1.0f,0.0f,0.0f));
						t_vertex_list.Add(new UnityEngine.Vector3(0.0f,1.0f,0.0f));
						t_vertex_list.Add(new UnityEngine.Vector3(0.0f,0.0f,1.0f));
						t_nomal_list.Add(new UnityEngine.Vector3(0.0f,0.0f,1.0f));
						t_nomal_list.Add(new UnityEngine.Vector3(0.0f,0.0f,1.0f));
						t_nomal_list.Add(new UnityEngine.Vector3(0.0f,0.0f,1.0f));
						t_nomal_list.Add(new UnityEngine.Vector3(0.0f,0.0f,1.0f));
						t_index_list.Add(0);
						t_index_list.Add(2);
						t_index_list.Add(1);
						t_index_list.Add(0);
						t_index_list.Add(1);
						t_index_list.Add(3);
						t_index_list.Add(1);
						t_index_list.Add(2);
						t_index_list.Add(3);

						t_index_list.Add(2);
						t_index_list.Add(0);
						t_index_list.Add(3);
					}
					t_mesh.vertices = t_vertex_list.ToArray();
					t_mesh.normals = t_nomal_list.ToArray();
					t_mesh.triangles = t_index_list.ToArray();
					t_mesh.RecalculateNormals();
					t_mesh.RecalculateBounds();
					t_mesh.RecalculateTangents();
				}

				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out");
				BlueBack.AssetLib.Editor.SaveAssetWithAssetsPath.SaveConverter(t_mesh,new BlueBack.AssetLib.StlConverterAssetToBinary(new UnityEngine.Vector3(50.0f,50.0f,50.0f)),"Out/test.stl");
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}

			//LoadBinaryWithAssetsPath
			{
				UnityEngine.Mesh t_mesh = BlueBack.AssetLib.Editor.LoadAssetWithAssetsPath.LoadConverter(new BlueBack.AssetLib.StlConverterBinaryToAsset(new UnityEngine.Vector3(1.0f,1.0f,1.0f)),"Out/test.stl");
				UnityEngine.Debug.Log(t_mesh.triangles.Length.ToString());
			}
		}
	}
	#endif
}

