

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ファイル名リスト。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** FileNameList
	*/
	public class FileNameList
	{
		/** 直下のファイル名を列挙。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static System.Collections.Generic.List<string> CreateOnlyTopFileNameListFromAssetsPath(string a_assets_path)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				string[] t_fullpath_list = System.IO.Directory.GetFiles(UnityEngine.Application.dataPath + '/' + a_assets_path,"*",System.IO.SearchOption.TopDirectoryOnly);
				for(int ii=0;ii<t_fullpath_list.Length;ii++){
					string t_name = System.IO.Path.GetFileName(t_fullpath_list[ii]);
					if(t_name.Length > 0){
						t_list.Add(t_name);
					}
				}
			}
			return t_list;
		}

		/** 直下のファイル名を列挙。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static Result<System.Collections.Generic.List<string>> TryCreateOnlyTopFileNameListFromAssetsPath(string a_assets_path)
		{
			Result<System.Collections.Generic.List<string>> t_result;

			#pragma warning disable 0168
			try{
				t_result.value = CreateOnlyTopFileNameListFromAssetsPath(a_assets_path);
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

		/** すべてのファイル名を列挙。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static System.Collections.Generic.List<string> CreateAllFileNameListFromAssetsPath(string a_assets_path)
		{
			System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
			{
				string t_assets_path = a_assets_path.Replace('/','\\');

				{
					string t_path;
					if(t_assets_path.Length > 0){
						if(t_assets_path[t_assets_path.Length - 1] != '\\'){
							t_path = t_assets_path + '\\';
						}else{
							t_path = t_assets_path;
						}
					}else{
						t_path = "";
					}

					System.Collections.Generic.List<string> t_file_name_list = CreateOnlyTopFileNameListFromAssetsPath(t_assets_path);
					for(int ii=0;ii<t_file_name_list.Count;ii++){
						string t_new_path = t_path + t_file_name_list[ii];
						t_list.Add(t_new_path);
					}
				}

				System.Collections.Generic.List<string> t_directory_list = DirectoryNameList.CreateAllDirectoryNameListFromAssetsPath(t_assets_path);
				foreach(string t_path in t_directory_list){
					System.Collections.Generic.List<string> t_file_name_list = CreateOnlyTopFileNameListFromAssetsPath(t_path);
					for(int ii=0;ii<t_file_name_list.Count;ii++){
						string t_new_path = t_path + '\\' + t_file_name_list[ii];
						t_list.Add(t_new_path);
					}
				}
			}
			return t_list;
		}

		/** すべてのファイル名を列挙。

			a_assets_path	: 「Assets」からの相対パス。

		*/
		public static Result<System.Collections.Generic.List<string>> TryCreateAllFileNameListFromAssetsPath(string a_assets_path)
		{
			Result<System.Collections.Generic.List<string>> t_result;

			#pragma warning disable 0168
			try{
				t_result.value = CreateOnlyTopFileNameListFromAssetsPath(a_assets_path);
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

