

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ファイル名リスト作成。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreateFileNameListWithAssetsPath
	*/
	public static class CreateFileNameListWithAssetsPath
	{
		/** 作成。直下のみ。

			a_assets_path					: 「Assets」からの相対パス。

		*/
		public static System.Collections.Generic.List<string> CreateTopOnly(string a_assets_path)
		{
			return CreateFileNameListWithFullPath.CreateTopOnly(AssetLib.GetApplicationDataPath() + '\\' + a_assets_path);
		}

		/** 作成。直下のみ。

			a_assets_path					: 「Assets」からの相対パス。

		*/
		public static MultiResult<bool,System.Collections.Generic.List<string>> TryCreateTopOnly(string a_assets_path)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,System.Collections.Generic.List<string>>(true,CreateTopOnly(a_assets_path));
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,System.Collections.Generic.List<string>>(false,null);
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,System.Collections.Generic.List<string>>(false,null);
			}
			#pragma warning restore
		}

		/** 作成。すべて。

			a_assets_path					: 「Assets」からの相対パス。

		*/
		public static System.Collections.Generic.List<string> CreateAll(string a_assets_path)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				string t_assets_path_root = NormalizePath.NormalizeSeparateAndLast(a_assets_path);

				if(t_assets_path_root.Length == 0){
					System.Collections.Generic.List<string> t_file_name_list = CreateTopOnly(t_assets_path_root);
					foreach(string t_filename in t_file_name_list){
						t_list.Add(t_filename);
					}
				}else{
					System.Collections.Generic.List<string> t_file_name_list = CreateTopOnly(t_assets_path_root);
					foreach(string t_filename in t_file_name_list){
						t_list.Add(t_assets_path_root + '\\' + t_filename);
					}
				}
				{
					System.Collections.Generic.List<string> t_assets_path_directory_list = CreateDirectoryNameListWithAssetsPath.CreateAll(t_assets_path_root);
					foreach(string t_assets_path in t_assets_path_directory_list){
						System.Collections.Generic.List<string> t_file_name_list = CreateTopOnly(t_assets_path);
						foreach(string t_filename in t_file_name_list){
							t_list.Add(t_assets_path + '\\' + t_filename);
						}
					}
				}
			}
			return t_list;
		}

		/** 作成。すべて。

			a_assets_path					: 「Assets」からの相対パス。

		*/
		public static MultiResult<bool,System.Collections.Generic.List<string>> TryCreateAll(string a_assets_path)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,System.Collections.Generic.List<string>>(true,CreateAll(a_assets_path));
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,System.Collections.Generic.List<string>>(false,null);
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,System.Collections.Generic.List<string>>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

