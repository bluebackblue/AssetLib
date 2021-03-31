

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ファイル検索。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	public class FindFile
	{
		/** FindFileListFromAssetsPath

			a_assets_path	: 「Assets」からの相対パス。
			a_regex_param	: 正規表現。

		*/
		public static System.Collections.Generic.List<string> FindFileListFromAssetsPath(string a_assets_path,string a_directory_regex,string a_file_regex)
		{
			System.Collections.Generic.List<string> t_result = new System.Collections.Generic.List<string>();
			{
				System.Text.RegularExpressions.Regex t_directory_regex = new System.Text.RegularExpressions.Regex(a_directory_regex);
				System.Text.RegularExpressions.Regex t_file_regex = new System.Text.RegularExpressions.Regex(a_file_regex);
				System.Collections.Generic.List<string> t_list = FileNameList.CreateAllFileNameListFromAssetsPath(a_assets_path);
				for(int ii=0;ii<t_list.Count;ii++){
					if(t_file_regex.IsMatch(System.IO.Path.GetFileName(t_list[ii]))){
						if(t_directory_regex.IsMatch(System.IO.Path.GetDirectoryName(t_list[ii]))){
							t_result.Add(t_list[ii]);
						}
					}
				}
			}
			return t_result;
		}

		/** FindFileFistFromAssetsPath

			a_assets_path	: 「Assets」からの相対パス。
			a_regex_param	: 正規表現。

		*/
		public static string FindFileFistFromAssetsPath(string a_assets_path,string a_directory_regex,string a_file_regex)
		{
			System.Text.RegularExpressions.Regex t_directory_regex = new System.Text.RegularExpressions.Regex(a_directory_regex);
			System.Text.RegularExpressions.Regex t_file_regex = new System.Text.RegularExpressions.Regex(a_file_regex);
			System.Collections.Generic.List<string> t_list = FileNameList.CreateAllFileNameListFromAssetsPath(a_assets_path);
			for(int ii=0;ii<t_list.Count;ii++){
				if(t_file_regex.IsMatch(System.IO.Path.GetFileName(t_list[ii]))){
					if(t_directory_regex.IsMatch(System.IO.Path.GetDirectoryName(t_list[ii]))){
						return t_list[ii];
					}
				}
			}

			return null;
		}
	}
}

