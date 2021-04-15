	

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief メッシュセーブ。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** SaveMesh
	*/
	public class SaveMesh
	{
		/** メッシュセーブ。

			a_mesh							: メッシュ。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static void SaveAsMeshToAssetsPath(UnityEngine.Mesh a_mesh,string a_assets_path_with_extention)
		{
			UnityEngine.Mesh t_new_mesh = UnityEngine.Object.Instantiate<UnityEngine.Mesh>(a_mesh);
			UnityEditor.AssetDatabase.CreateAsset(t_new_mesh,"Assets/" + a_assets_path_with_extention);
		}

		/** ＳＴＬとしてメッシュセーブ。

			a_mesh							: メッシュ。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static void SaveAsStlMeshToAssetsPath(UnityEngine.Mesh a_mesh,string a_assets_path_with_extention)
		{
			//総数。
			System.UInt32 t_count = (System.UInt32)(a_mesh.triangles.Length / 3);

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
					return;
				}
			}

			for(int ii=0;ii<t_count;ii++){
				int t_offset = 84 + ii * 50;

				UnityEngine.Vector3 t_normal = (a_mesh.normals[ii * 3 + 0] + a_mesh.normals[ii * 3 + 1] + a_mesh.normals[ii * 3 + 2]).normalized;

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
						return;
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
						return;
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
						return;
					}
				}

				for(int jj=0;jj<3;jj++){
					//x
					{
						byte[] t_byte4 = System.BitConverter.GetBytes(a_mesh.vertices[ii * 3 + jj].x);
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
							return;
						}
					}

					//y
					{
						byte[] t_byte4 = System.BitConverter.GetBytes(a_mesh.vertices[ii * 3 + jj].y);
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
							return;
						}
					}

					//z
					{
						byte[] t_byte4 = System.BitConverter.GetBytes(a_mesh.vertices[ii * 3 + jj].z);
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
							return;
						}
					}
				}

				t_binary[t_offset + 0] = 0x00;
				t_binary[t_offset + 1] = 0x00;
			}

			SaveBinary.SaveBinaryToAssetsPath(t_binary,a_assets_path_with_extention);
		}
	}
}
#endif

