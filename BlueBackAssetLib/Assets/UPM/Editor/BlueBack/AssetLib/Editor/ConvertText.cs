

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief テキストコンバート。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** ConvertText
	*/
	public static class ConvertText
	{
		/** テキストコンバート。

			a_assets_path		: 「Assets」からの相対パス。
			a_directory_regex	: ディレクトリの正規表現。例（.*）
			a_file_regex		: ファイル名の正規表現。例（^xxx.xxx$）
			a_linefeed_option	: 改行コード。

		*/
		public static void ConvertTextToUtf8FromAssetsPath(string a_assets_path,string a_directory_regex,string a_file_regex,bool a_bom,LineFeedOption a_linefeed_option)
		{
			System.Collections.Generic.List<string> t_list = FindFileWithAssetsPath.FindAll(a_assets_path,a_directory_regex,a_file_regex);
			for(int ii=0;ii<t_list.Count;ii++){
				string t_path = t_list[ii];
				string t_text = LoadText.LoadTextFromAssetsPath(t_list[ii],null);
				SaveText.SaveUtf8TextToAssetsPath(t_text,t_path,a_bom,a_linefeed_option);
			}

			RefreshAsset.Refresh();
		}

		/** テキストコンバート。

			a_assets_path		: 「Assets」からの相対パス。
			a_directory_regex	: ディレクトリの正規表現。例（.*）
			a_file_regex		: ファイル名の正規表現。例（^xxx.xxx$）
			a_linefeed_option	: 改行コード。

		*/
		public static void TryConvertTextToUtf8FromAssetsPath(string a_assets_path,string a_directory_regex,string a_file_regex,bool a_bom,LineFeedOption a_linefeed_option)
		{
			#pragma warning disable 0168
			try{
				ConvertTextToUtf8FromAssetsPath(a_assets_path,a_directory_regex,a_file_regex,a_bom,a_linefeed_option);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore
		}
	}
}
#endif

