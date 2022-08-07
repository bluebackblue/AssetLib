

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ファイル検索。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** FindFileWithAssetsPath
	*/
	public static class FindFileWithAssetsPath
	{
		/** 検索。すべて。

			a_assets_path					: 「Assets」からの相対パス。
			a_directory_pattern				: ディレクトリ名の正規表現パターン。
			a_file_pattern					: ファイル名の正規表現パターン。

		*/
		public static System.Collections.Generic.List<string> FindAll(string a_assets_path,string a_directory_pattern,string a_file_pattern)
		{
			System.Collections.Generic.List<string> t_result = new System.Collections.Generic.List<string>();
			{
				System.Text.RegularExpressions.Regex t_directory_regex = new System.Text.RegularExpressions.Regex(a_directory_pattern,System.Text.RegularExpressions.RegexOptions.Multiline);
				System.Text.RegularExpressions.Regex t_file_regex = new System.Text.RegularExpressions.Regex(a_file_pattern,System.Text.RegularExpressions.RegexOptions.Multiline);
				System.Collections.Generic.List<string> t_list = CreateFileNameListWithAssetsPath.CreateAll(a_assets_path);
				foreach(string t_item in t_list){
					if(t_file_regex.IsMatch(System.IO.Path.GetFileName(t_item))){
						if(t_directory_regex.IsMatch(System.IO.Path.GetDirectoryName(t_item))){
							t_result.Add(t_item);
						}
					}
				}
			}
			return t_result;
		}

		/** 検索。すべて。

			a_assets_path					: 「Assets」からの相対パス。

		*/
		public static MultiResult<bool,System.Collections.Generic.List<string>> TryFindAll(string a_assets_path,string a_directory_pattern,string a_file_pattern)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,System.Collections.Generic.List<string>>(true,FindAll(a_assets_path,a_directory_pattern,a_file_pattern));
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,System.Collections.Generic.List<string>>(false,null);
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,System.Collections.Generic.List<string>>(false,null);
			}
			#pragma warning restore
		}

		/** 検索。初回ヒット。

			a_assets_path					: 「Assets」からの相対パス。
			a_directory_pattern				: ディレクトリ名の正規表現パターン。
			a_file_pattern					: ファイル名の正規表現パターン。

		*/
		public static string FindFirst(string a_assets_path,string a_directory_pattern,string a_file_pattern)
		{
			System.Text.RegularExpressions.Regex t_directory_regex = new System.Text.RegularExpressions.Regex(a_directory_pattern,System.Text.RegularExpressions.RegexOptions.Multiline);
			System.Text.RegularExpressions.Regex t_file_regex = new System.Text.RegularExpressions.Regex(a_file_pattern,System.Text.RegularExpressions.RegexOptions.Multiline);
			System.Collections.Generic.List<string> t_list = CreateFileNameListWithAssetsPath.CreateAll(a_assets_path);
			for(int ii=0;ii<t_list.Count;ii++){
				if(t_file_regex.IsMatch(System.IO.Path.GetFileName(t_list[ii]))){
					if(t_directory_regex.IsMatch(System.IO.Path.GetDirectoryName(t_list[ii]))){
						return t_list[ii];
					}
				}
			}
			return null;
		}

		/** 検索。初回ヒット。

			a_assets_path					: 「Assets」からの相対パス。

		*/
		public static MultiResult<bool,string> TryFindFirst(string a_assets_path,string a_directory_pattern,string a_file_pattern)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,FindFirst(a_assets_path,a_directory_pattern,a_file_pattern));
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,string>(false,null);
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,string>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

