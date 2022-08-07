

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief STL
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** StlConverterBinaryToAsset
	*/
	public sealed class StlConverterBinaryToAsset : ConverterBinaryToAsset_Base<UnityEngine.Mesh>
	{
		/** scale
		*/
		public UnityEngine.Vector3 scale;

		/** ConverterPngBinaryToAsset
		*/
		public StlConverterBinaryToAsset(in UnityEngine.Vector3 a_scale)
		{
			//scale
			this.scale = a_scale;
		}

		/** [BlueBack.AssetLib.ConverterBinaryToAsset_Base]Convert
		*/
		public UnityEngine.Mesh Convert(byte[] a_binary)
		{
			byte[] t_byte4 = new byte[4];

			//総数。
			System.UInt32 t_count = 0;
			{
				if(a_binary.Length >= 84){
					System.Array.Copy(a_binary,80,t_byte4,0,t_byte4.Length);
					t_count = System.BitConverter.ToUInt32(t_byte4,0);
				}else{
					#if(DEF_BLUEBACK_ASSERT)
					DebugTool.Assert(false,"format error");
					#endif
					return null;
				}

				if(t_count <= 0){
					#if(DEF_BLUEBACK_ASSERT)
					DebugTool.Assert(false,"format error");
					#endif
					return null;
				}
			}

			UnityEngine.Mesh t_mesh = new UnityEngine.Mesh();
			{
				if(a_binary.Length >= (84 + t_count * 50)){

					System.Collections.Generic.List<UnityEngine.Vector3> t_vertex_list = new System.Collections.Generic.List<UnityEngine.Vector3>();
					System.Collections.Generic.List<UnityEngine.Vector3> t_nomal_list = new System.Collections.Generic.List<UnityEngine.Vector3>();
					System.Collections.Generic.List<int> t_index_list = new System.Collections.Generic.List<int>();

					for(int ii=0;ii<t_count;ii++){
						int t_offset = 84 + ii * 50;

						//nomal
						{
							System.Array.Copy(a_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_x = System.BitConverter.ToSingle(t_byte4,0);
							t_offset += 4;

							System.Array.Copy(a_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_y = System.BitConverter.ToSingle(t_byte4,0);
							t_offset += 4;

							System.Array.Copy(a_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_z = System.BitConverter.ToSingle(t_byte4,0);
							t_offset += 4;

							t_nomal_list.Add(new UnityEngine.Vector3(t_x,t_y,t_z));
							t_nomal_list.Add(new UnityEngine.Vector3(t_x,t_y,t_z));
							t_nomal_list.Add(new UnityEngine.Vector3(t_x,t_y,t_z));
						}

						//vertex
						for(int jj=0;jj<3;jj++){
							System.Array.Copy(a_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_x = System.BitConverter.ToSingle(t_byte4,0) * this.scale.x;
							t_offset += 4;

							System.Array.Copy(a_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_y = System.BitConverter.ToSingle(t_byte4,0) * this.scale.y;
							t_offset += 4;

							System.Array.Copy(a_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_z = System.BitConverter.ToSingle(t_byte4,0) * this.scale.z;
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
					#if(DEF_BLUEBACK_ASSERT)
					DebugTool.Assert(false,"format error");
					#endif
					return null;
				}
			}

			t_mesh.RecalculateNormals();
			t_mesh.RecalculateBounds();
			t_mesh.RecalculateTangents();
			return t_mesh;
		}
	}
}

