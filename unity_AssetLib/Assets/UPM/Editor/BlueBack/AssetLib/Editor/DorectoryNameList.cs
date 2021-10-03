

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ディレクトリ名リスト。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** DirectoryNameList
	*/
	public class DirectoryNameList
	{
		/** 直下のディレクトリ名を列挙。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static System.Collections.Generic.List<string> CreateOnlyTopDirectoryNameListFromAssetsPath(string a_assets_path)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				string[] t_fullpath_list = System.IO.Directory.GetDirectories(AssetLib.GetApplicationDataPath() + '\\' + a_assets_path,"*",System.IO.SearchOption.TopDirectoryOnly);
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

			#pragma warning disable 0168
			try{
				t_result.value = CreateOnlyTopDirectoryNameListFromAssetsPath(a_assets_path);
				t_result.success = true;
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif

				t_result.value = null;
				t_result.success = false;
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif

				t_result.value = null;
				t_result.success = false;
			}
			#pragma warning restore

			return t_result;
		}

		/** すべてのディレクトリ名を列挙。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static System.Collections.Generic.List<string> CreateAllDirectoryNameListFromAssetsPath(string a_assets_path)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			System.Collections.Generic.List<string> t_work = new System.Collections.Generic.List<string>();

			{
				if(a_assets_path.Length > 0){
					string t_assets_path = a_assets_path.Replace('/','\\');
					if(t_assets_path[t_assets_path.Length - 1] != '\\'){
						t_work.Add(t_assets_path + '\\');
					}else{
						t_work.Add(t_assets_path);
					}
				}else{
					t_work.Add("");
				}
			}

			while(t_work.Count > 0){
				string t_path = t_work[t_work.Count - 1];
				t_work.RemoveAt(t_work.Count - 1);
				System.Collections.Generic.List<string> t_directory_name_list = CreateOnlyTopDirectoryNameListFromAssetsPath(t_path);
				for(int ii=0;ii<t_directory_name_list.Count;ii++){
					string t_new_path = t_path + t_directory_name_list[ii];
					t_list.Add(t_new_path);

					{
						if(t_new_path.Length > 0){
							if(t_new_path[t_new_path.Length - 1] != '\\'){
								t_work.Add(t_new_path + '\\');
							}else{
								t_work.Add(t_new_path);
							}
						}else{
							t_work.Add("\\");
						}
					}
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

			#pragma warning disable 0168
			try{
				t_result.value = CreateAllDirectoryNameListFromAssetsPath(a_assets_path);
				t_result.success = true;
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif

				t_result.value = null;
				t_result.success = false;
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif

				t_result.value = null;
				t_result.success = false;
			}
			#pragma warning restore

			return t_result;
		}
	}
}
#endif

