

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＵＩＤリスト作成。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreateGuidListWithAssetsPath
	*/
	public static class CreateGuidListWithAssetsPath
	{
		/** 作成。

			a_directory_pattern				: ディレクトリ名の正規表現パターン。
			a_file_pattern					: ファイル名の正規表現パターン。

		*/
		public static System.Collections.Generic.List<PathResult<string>> Create(string a_directory_pattern,string a_file_pattern)
		{
			System.Collections.Generic.List<PathResult<string>> t_guid_list = new System.Collections.Generic.List<PathResult<string>>();
			{
				System.Collections.Generic.List<string> t_path_list = FindFileWithFullPath.FindAll(AssetLib.application_data_path,a_directory_pattern,a_file_pattern);
				foreach(string t_path in t_path_list){
					MultiResult<bool,string> t_result =  BlueBack.AssetLib.LoadGuidWithFullPath.TryLoad(t_path + ".meta");
					if(t_result.result == true){
						t_guid_list.Add(new PathResult<string>(t_path,t_result.value));
					}
				}
			}
			return t_guid_list;
		}
	}
}
#endif

