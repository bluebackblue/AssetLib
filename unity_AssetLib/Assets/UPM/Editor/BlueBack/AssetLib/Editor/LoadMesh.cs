

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief メッシュロード。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadMesh
	*/
	public class LoadMesh
	{
		/** メッシュロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static UnityEngine.Mesh LoadMeshFromAssetsPath(string a_assets_path_with_extention)
		{
			return UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.Mesh>("Assets/" + a_assets_path_with_extention);
		}

		/** ＳＴＬからメッシュロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static UnityEngine.Mesh LoadStlMeshFromAssetsPath(string a_assets_path_with_extention)
		{
			byte[] t_binary = BlueBack.AssetLib.Editor.LoadBinary.LoadBinaryFromAssetsPath(a_assets_path_with_extention);

			/*
			{
				if(t_binary.Length >= 80){
					byte[] t_byte80 = new byte[80];
					System.Array.Copy(t_binary,0,t_byte80,0,t_byte80.Length);
					//System.Text.Encoding.GetEncoding("utf-8").GetString(t_byte80);
				}else{
					#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
					DebugTool.Assert(false,"fromat_error");
					#endif
					return null;
				}
			}
			*/

			byte[] t_byte4 = new byte[4];

			//総数。
			System.UInt32 t_count = 0;
			{
				if(t_binary.Length >= 84){
					System.Array.Copy(t_binary,80,t_byte4,0,t_byte4.Length);
					t_count = System.BitConverter.ToUInt32(t_byte4,0);
				}else{
					#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
					DebugTool.Assert(false,"fromat_error");
					#endif
					return null;
				}

				if(t_count <= 0){
					#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
					DebugTool.Assert(false,"fromat_error");
					#endif
					return null;
				}
			}

			UnityEngine.Mesh t_mesh = new UnityEngine.Mesh();
			{
				if(t_binary.Length >= (84 + t_count * 50)){

					System.Collections.Generic.List<UnityEngine.Vector3> t_vertex_list = new System.Collections.Generic.List<UnityEngine.Vector3>();
					System.Collections.Generic.List<UnityEngine.Vector3> t_nomal_list = new System.Collections.Generic.List<UnityEngine.Vector3>();
					System.Collections.Generic.List<int> t_index_list = new System.Collections.Generic.List<int>();

					for(int ii=0;ii<t_count;ii++){
						int t_offset = 84 + ii * 50;
						
						{
							System.Array.Copy(t_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_x = System.BitConverter.ToSingle(t_byte4,0);
							t_offset += 4;

							System.Array.Copy(t_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_y = System.BitConverter.ToSingle(t_byte4,0);
							t_offset += 4;

							System.Array.Copy(t_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_z = System.BitConverter.ToSingle(t_byte4,0);
							t_offset += 4;

							t_nomal_list.Add(new UnityEngine.Vector3(t_x,t_y,t_z));
							t_nomal_list.Add(new UnityEngine.Vector3(t_x,t_y,t_z));
							t_nomal_list.Add(new UnityEngine.Vector3(t_x,t_y,t_z));
						}

						for(int jj=0;jj<3;jj++){
							System.Array.Copy(t_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_x = System.BitConverter.ToSingle(t_byte4,0);
							t_offset += 4;

							System.Array.Copy(t_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_y = System.BitConverter.ToSingle(t_byte4,0);
							t_offset += 4;

							System.Array.Copy(t_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_z = System.BitConverter.ToSingle(t_byte4,0);
							t_offset += 4;

							t_index_list.Add(t_vertex_list.Count);
							t_vertex_list.Add(new UnityEngine.Vector3(t_x,t_y,t_z));
						}
					}

					{
						t_mesh.vertices = t_vertex_list.ToArray();
						t_mesh.triangles = t_index_list.ToArray();
						t_mesh.normals = t_nomal_list.ToArray();
					}
				}else{
					#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
					DebugTool.Assert(false,"fromat_error");
					#endif
					return null;
				}
			}

			t_mesh.RecalculateBounds();
			t_mesh.RecalculateTangents();
			return t_mesh;
		}
	}
}
#endif

