

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ディレクトリ名リスト作成。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreateDirectoryNameListWithAssetsPath
	*/
	public static class CreateDirectoryNameListWithAssetsPath
	{
		/** 作成。直下のみ。

			a_assets_path					: 「Assets」からの相対パス。

		*/
		public static System.Collections.Generic.List<string> CreateTopOnly(string a_assets_path)
		{
			return CreateDirectoryNameListWithFullPath.CreateTopOnly(AssetLib.GetApplicationDataPath() + '\\' + a_assets_path);
		}

		/** 作成。直下のみ。

			a_assets_path					: 「Assets」からの相対パス。
			result.result == true			: 成功。

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
				System.Collections.Generic.Stack<string> t_work = new System.Collections.Generic.Stack<string>();
				{
					string t_assets_path_root = NormalizePath.NormalizeSeparateAndLast(a_assets_path);
					System.Collections.Generic.List<string> t_directory_name_list = CreateTopOnly(t_assets_path_root);
					if(t_assets_path_root.Length == 0){
						foreach(string t_directoryname in t_directory_name_list){
							t_list.Add(t_directoryname);
							t_work.Push(t_directoryname);
						}
					}else{
						foreach(string t_directoryname in t_directory_name_list){
							string t_assets_path = t_assets_path_root + "\\" + t_directoryname;
							t_list.Add(t_assets_path);
							t_work.Push(t_assets_path);
						}
					}
				}
				{
					while(t_work.Count > 0){
						string t_assets_path_current = t_work.Pop();
						System.Collections.Generic.List<string> t_directory_name_list = CreateTopOnly(t_assets_path_current);
						foreach(string t_directoryname in t_directory_name_list){
							string t_assets_path = t_assets_path_current + "\\" + t_directoryname;
							t_list.Add(t_assets_path);
							t_work.Push(t_assets_path);
						}
					}
				}
			}
			return t_list;
		}

		/** 作成。すべて。

			a_assets_path					: 「Assets」からの相対パス。
			result.result == true			: 成功。

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

