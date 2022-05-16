

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ファイル名リスト作成。フルパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreateFileNameListWithFullPath
	*/
	public static class CreateFileNameListWithFullPath
	{
		/** 作成。直下のみ。

			a_full_path						: フルパス。

		*/
		public static System.Collections.Generic.List<string> CreateTopOnly(string a_full_path)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				string[] t_full_path_list = System.IO.Directory.GetFiles(a_full_path,"*",System.IO.SearchOption.TopDirectoryOnly);
				foreach(string t_full_path in t_full_path_list){
					string t_filename = System.IO.Path.GetFileName(t_full_path);
					if(t_filename.Length > 0){
						t_list.Add(t_filename);
					}
				}
			}
			return t_list;
		}

		/** 作成。直下のみ。

			a_full_path						: フルパス。

		*/
		public static MultiResult<bool,System.Collections.Generic.List<string>> TryCreateTopOnly(string a_full_path)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,System.Collections.Generic.List<string>>(true,CreateTopOnly(a_full_path));
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

			a_full_path						: フルパス。

		*/
		public static System.Collections.Generic.List<string> CreateAll(string a_full_path)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				System.Collections.Generic.List<string> t_full_path_directory_list;
				{
					string t_full_path = NormalizePath.NormalizeSeparateAndLast(a_full_path);
					t_full_path_directory_list = CreateDirectoryNameListWithFullPath.CreateAll(t_full_path);
					t_full_path_directory_list.Add(t_full_path);
				}
				{
					foreach(string t_full_path in t_full_path_directory_list){
						System.Collections.Generic.List<string> t_filename_list = CreateTopOnly(t_full_path);
						foreach(string t_filename in t_filename_list){
							t_list.Add(t_full_path + '\\' + t_filename);
						}
					}
				}
			}
			return t_list;
		}

		/** 作成。すべて。

			a_full_path						: フルパス。

		*/
		public static MultiResult<bool,System.Collections.Generic.List<string>> TryCreateAll(string a_full_path)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,System.Collections.Generic.List<string>>(true,CreateAll(a_full_path));
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

