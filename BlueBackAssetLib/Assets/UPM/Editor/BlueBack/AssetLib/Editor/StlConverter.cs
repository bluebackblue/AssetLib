

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＳＴＬコンバター。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** StlConverter
	*/
	public static class StlConverter
	{
		/** バイナリ --> メッシュ。

			a_binary			: バイナリ。

		*/
		public static UnityEngine.Mesh BinaryToMesh(byte[] a_binary)
		{
			byte[] t_byte4 = new byte[4];

			//総数。
			System.UInt32 t_count = 0;
			{
				if(a_binary.Length >= 84){
					System.Array.Copy(a_binary,80,t_byte4,0,t_byte4.Length);
					t_count = System.BitConverter.ToUInt32(t_byte4,0);
				}else{
					#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
					DebugTool.Assert(false,"format error");
					#endif
					return null;
				}

				if(t_count <= 0){
					#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
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
							float t_x = System.BitConverter.ToSingle(t_byte4,0);
							t_offset += 4;

							System.Array.Copy(a_binary,t_offset,t_byte4,0,t_byte4.Length);
							float t_y = System.BitConverter.ToSingle(t_byte4,0);
							t_offset += 4;

							System.Array.Copy(a_binary,t_offset,t_byte4,0,t_byte4.Length);
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

		/** バイナリ --> メッシュ。

			a_binary			: バイナリ。
			return == true		: 成功。

		*/
		public static MultiResult<bool,UnityEngine.Mesh> TryBinaryToMesh(byte[] a_binary)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,UnityEngine.Mesh>(true,BinaryToMesh(a_binary));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,UnityEngine.Mesh>(false,null);
			}
			#pragma warning restore
		}

		/** メッシュ --> バイナリ。

			a_mesh				: メッシュ。
			a_scale				: 「Assets」からの相対バス。拡張子付き。

		*/
		public static byte[] MeshToBinary(UnityEngine.Mesh a_mesh,UnityEngine.Vector3 a_scale)
		{
			//頂点、法線、インデックス。
			UnityEngine.Vector3[] t_vertex_list = a_mesh.vertices;
			UnityEngine.Vector3[] t_normal_list = a_mesh.normals;
			int[] t_index_list = a_mesh.triangles;

			//総数。
			System.UInt32 t_count = (System.UInt32)(t_index_list.Length / 3);

			//バイナリ。
			byte[] t_binary = new byte[80 + 4 + t_count * 50];

			//タイトル。
			{
				for(int ii=0;ii<80;ii++){
					t_binary[ii] = 0x20;
				}
			}

			//総数。
			{
				byte[] t_byte4 = System.BitConverter.GetBytes(t_count);
				if(t_byte4.Length == 4){
					t_binary[80] = t_byte4[0];
					t_binary[81] = t_byte4[1];
					t_binary[82] = t_byte4[2];
					t_binary[83] = t_byte4[3];
				}else{
					#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
					DebugTool.Assert(false);
					#endif
					return null;
				}
			}

			for(int ii=0;ii<t_count;ii++){
				int t_offset = 84 + ii * 50;

				UnityEngine.Vector3 t_normal = (t_normal_list[t_index_list[ii * 3 + 0]] + t_normal_list[t_index_list[ii * 3 + 1]] + t_normal_list[t_index_list[ii * 3 + 2]]).normalized;

				//nomal_x
				{
					byte[] t_byte4 = System.BitConverter.GetBytes(t_normal.x);
					if(t_byte4.Length == 4){
						t_binary[t_offset + 0] = t_byte4[0];
						t_binary[t_offset + 1] = t_byte4[1];
						t_binary[t_offset + 2] = t_byte4[2];
						t_binary[t_offset + 3] = t_byte4[3];
						t_offset += 4;
					}else{
						#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
						DebugTool.Assert(false);
						#endif
						return null;
					}
				}


				//nomal_y
				{
					byte[] t_byte4 = System.BitConverter.GetBytes(t_normal.y);
					if(t_byte4.Length == 4){
						t_binary[t_offset + 0] = t_byte4[0];
						t_binary[t_offset + 1] = t_byte4[1];
						t_binary[t_offset + 2] = t_byte4[2];
						t_binary[t_offset + 3] = t_byte4[3];
						t_offset += 4;
					}else{
						#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
						DebugTool.Assert(false);
						#endif
						return null;
					}
				}

				//nomal_z
				{
					byte[] t_byte4 = System.BitConverter.GetBytes(t_normal.z);
					if(t_byte4.Length == 4){
						t_binary[t_offset + 0] = t_byte4[0];
						t_binary[t_offset + 1] = t_byte4[1];
						t_binary[t_offset + 2] = t_byte4[2];
						t_binary[t_offset + 3] = t_byte4[3];
						t_offset += 4;
					}else{
						#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
						DebugTool.Assert(false);
						#endif
						return null;
					}
				}

				for(int jj=0;jj<3;jj++){
					//x
					{
						byte[] t_byte4 = System.BitConverter.GetBytes(t_vertex_list[t_index_list[ii * 3 + jj]].x * a_scale.x);
						if(t_byte4.Length == 4){
							t_binary[t_offset + 0] = t_byte4[0];
							t_binary[t_offset + 1] = t_byte4[1];
							t_binary[t_offset + 2] = t_byte4[2];
							t_binary[t_offset + 3] = t_byte4[3];
							t_offset += 4;
						}else{
							#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
							DebugTool.Assert(false);
							#endif
							return null;
						}
					}

					//y
					{
						byte[] t_byte4 = System.BitConverter.GetBytes(t_vertex_list[t_index_list[ii * 3 + jj]].y * a_scale.y);
						if(t_byte4.Length == 4){
							t_binary[t_offset + 0] = t_byte4[0];
							t_binary[t_offset + 1] = t_byte4[1];
							t_binary[t_offset + 2] = t_byte4[2];
							t_binary[t_offset + 3] = t_byte4[3];
							t_offset += 4;
						}else{
							#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
							DebugTool.Assert(false);
							#endif
							return null;
						}
					}

					//z
					{
						byte[] t_byte4 = System.BitConverter.GetBytes(t_vertex_list[t_index_list[ii * 3 + jj]].z * a_scale.z);
						if(t_byte4.Length == 4){
							t_binary[t_offset + 0] = t_byte4[0];
							t_binary[t_offset + 1] = t_byte4[1];
							t_binary[t_offset + 2] = t_byte4[2];
							t_binary[t_offset + 3] = t_byte4[3];
							t_offset += 4;
						}else{
							#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
							DebugTool.Assert(false);
							#endif
							return null;
						}
					}
				}

				t_binary[t_offset + 0] = 0x00;
				t_binary[t_offset + 1] = 0x00;
			}

			return t_binary;
		}

		/** メッシュ --> バイナリ。

			a_mesh				: メッシュ。
			a_scale				: 「Assets」からの相対バス。拡張子付き。
			return == true		: 成功。

		*/
		public static MultiResult<bool,byte[]> TryMeshToBinary(UnityEngine.Mesh a_mesh,UnityEngine.Vector3 a_scale)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,byte[]>(true,MeshToBinary(a_mesh,a_scale));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,byte[]>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

