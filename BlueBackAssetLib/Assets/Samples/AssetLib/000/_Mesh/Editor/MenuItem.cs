

/** Samples.AssetLib.Mesh.Editor
*/
namespace Samples.AssetLib.Mesh.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR) && false
	public class MenuItem
	{
		/** Inner_CreateMesh
		*/
		private static UnityEngine.Mesh Inner_CreateMesh()
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
			return t_mesh;
		}

		/** SaveAssetWithAssetsPath
		*/
		/*
		[UnityEditor.MenuItem("サンプル/AssetLib/Mesh/SaveAssetWithAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Mesh_SaveAssetWithAssetsPath()
		{
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out");

			UnityEngine.Mesh t_mesh = Inner_CreateMesh();
			BlueBack.AssetLib.Editor.SaveAssetWithAssetsPath.Save<UnityEngine.Mesh>(t_mesh,"Out/mesh.mesh");

			BlueBack.AssetLib.Editor.StlConverter.MeshToBinary(t_mesh
		}
		*/

		/** SaveAssetWithAssetsPath_SaveAs
		*/
		/*
		[UnityEditor.MenuItem("サンプル/AssetLib/Mesh/SaveAssetWithAssetsPath_SaveAs")]
		private static void MenuItem_Sample_AssetLib_Mesh_SaveAssetWithAssetsPath_SaveAs()
		{
			UnityEngine.Mesh t_mesh = BlueBack.AssetLib.Editor.LoadAssetWithAssetsPath.TryLoad<UnityEngine.Mesh>("Out/mesh.mesh").value;
			if(t_mesh != null){
				BlueBack.AssetLib.Editor.SaveAssetWithAssetsPath.SaveAs<UnityEngine.Mesh>(t_mesh,"Out/mesh2.mesh");
				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}
		}
		*/
	}
	#endif
}

