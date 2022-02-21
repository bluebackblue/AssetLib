

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ディレクトリ名リスト作成。フルパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreateDirectoryNameListWithFullPath
	*/
	public static class CreateDirectoryNameListWithFullPath
	{
		/** 作成。直下のみ。

			a_full_path						: フルパス。

		*/
		public static System.Collections.Generic.List<string> CreateTopOnly(string a_full_path)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				string[] t_full_path_list = System.IO.Directory.GetDirectories(a_full_path,"*",System.IO.SearchOption.TopDirectoryOnly);
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
			result.result == true			: 成功。

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
			System.Collections.Generic.Stack<string> t_work = new System.Collections.Generic.Stack<string>();
			{
				t_work.Push(NormalizePath.NormalizeSeparateAndLast(a_full_path));
			}

			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				while(t_work.Count > 0){
					string t_full_path_current = t_work.Pop();
					System.Collections.Generic.List<string> t_directory_name_list = CreateTopOnly(t_full_path_current);
					foreach(string t_directoryname in t_directory_name_list){
						string t_full_path = t_full_path_current + '\\' + t_directoryname;
						t_list.Add(t_full_path);
						t_work.Push(t_full_path);
					}
				}
			}
			return t_list;
		}

		/** 作成。すべて。

			a_full_path						: フルパス。
			result.result == true			: 成功。

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

