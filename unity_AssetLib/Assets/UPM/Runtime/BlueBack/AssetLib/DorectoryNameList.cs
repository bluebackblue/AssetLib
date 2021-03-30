

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ディレクトリ名リスト。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** DorectoryNameList
	*/
	public class DorectoryNameList
	{
		/** 直下のディレクトリ名を列挙。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static System.Collections.Generic.List<string> CreateOnlyTopDirectoryNameListFromAssetsPath(string a_assets_path)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				string[] t_fullpath_list = System.IO.Directory.GetDirectories(UnityEngine.Application.dataPath + "/" + a_assets_path,"*",System.IO.SearchOption.TopDirectoryOnly);
				for(int ii=0;ii<t_fullpath_list.Length;ii++){
					string t_name = System.IO.Path.GetFileName(t_fullpath_list[ii]);
					if(t_name.Length > 0){
						t_list.Add(t_name);
					}
				}
			}
			return t_list;
		}

		/** 直下のディレクトリ名を列挙。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static Result<System.Collections.Generic.List<string>> TryCreateOnlyTopDirectoryNameListFromAssetsPath(string a_assets_path)
		{
			Result<System.Collections.Generic.List<string>> t_result;

			try{
				t_result.value = CreateOnlyTopDirectoryNameListFromAssetsPath(a_assets_path);
				t_result.success = true;
			}catch(System.IO.IOException /*t_exception*/){
				DebugTool.Assert(false);
				t_result.value = null;
				t_result.success = false;
			}catch(System.Exception /*t_exception*/){
				DebugTool.Assert(false);
				t_result.value = null;
				t_result.success = false;
			}

			return t_result;
		}

		/** すべてのディレクトリ名を列挙。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static System.Collections.Generic.List<string> CreateAllDirectoryNameListFromAssetsPath(string a_assets_path)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			System.Collections.Generic.List<string> t_work = new System.Collections.Generic.List<string>();

			t_list.Add(a_assets_path);
			t_work.Add(a_assets_path);

			while(t_work.Count > 0){
				string t_path = t_work[t_work.Count - 1];
				t_work.RemoveAt(t_work.Count - 1);
				System.Collections.Generic.List<string> t_directory_name_list = CreateOnlyTopDirectoryNameListFromAssetsPath(t_path);
				for(int ii=0;ii<t_directory_name_list.Count;ii++){
					string t_new_path = t_path + "/" + t_directory_name_list[ii];
					t_list.Add(t_new_path);
					t_work.Add(t_new_path);
				}
			}

			return t_list;
		}

		/** すべてのディレクトリ名を列挙。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static Result<System.Collections.Generic.List<string>> TryCreateAllDirectoryNameListFromAssetsPath(string a_assets_path)
		{
			Result<System.Collections.Generic.List<string>> t_result;

			try{
				t_result.value = CreateAllDirectoryNameListFromAssetsPath(a_assets_path);
				t_result.success = true;
			}catch(System.IO.IOException /*t_exception*/){
				DebugTool.Assert(false);
				t_result.value = null;
				t_result.success = false;
			}catch(System.Exception /*t_exception*/){
				DebugTool.Assert(false);
				t_result.value = null;
				t_result.success = false;
			}

			return t_result;
		}
	}
}

