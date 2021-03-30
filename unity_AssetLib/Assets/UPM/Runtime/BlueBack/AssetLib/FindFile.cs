

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
		public static System.Collections.Generic.List<string> FindFileListFromAssetsPath(string a_assets_path,string a_regex_param)
		{
			System.Collections.Generic.List<string> t_result = new System.Collections.Generic.List<string>();
			{
				System.Text.RegularExpressions.Regex t_regex = new System.Text.RegularExpressions.Regex(a_regex_param);
				System.Collections.Generic.List<string> t_list = FileNameList.CreateAllFileNameListFromAssetsPath(a_assets_path);
				for(int ii=0;ii<t_list.Count;ii++){
					if(t_regex.IsMatch(t_list[ii]) == true){
						t_result.Add(t_list[ii]);
					}
				}
			}

			if(t_result.Count > 0){
				return t_result;
			}

			return null;
		}

		/** FindFileFistFromAssetsPath

			a_assets_path	: 「Assets」からの相対パス。
			a_regex_param	: 正規表現。

		*/
		public static string FindFileFistFromAssetsPath(string a_assets_path,string a_regex_param)
		{
			System.Text.RegularExpressions.Regex t_regex = new System.Text.RegularExpressions.Regex(a_regex_param);
			System.Collections.Generic.List<string> t_list = FileNameList.CreateAllFileNameListFromAssetsPath(a_assets_path);
			for(int ii=0;ii<t_list.Count;ii++){
				if(t_regex.IsMatch(t_list[ii]) == true){
					return t_list[ii];
				}
			}

			return null;
		}
	}
}

