

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief テキストコンバート。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** TextConvertWithAssetsPath
	*/
	public static class TextConvertWithAssetsPath
	{
		/** テキストコンバート。

			a_assets_path					: 「Assets」からの相対パス。
			a_directory_pattern				: ディレクトリ名の正規表現パターン。
			a_file_pattern					: ファイル名の正規表現パターン。
			a_encoding						: エンコード。
			a_linefeed_option				: 改行コード。

		*/
		public static bool ConvertAll(string a_assets_path,string a_directory_pattern,string a_file_pattern,System.Text.Encoding a_encoding,LineFeedOption a_linefeed_option)
		{
			System.Collections.Generic.List<string> t_list = FindFileWithAssetsPath.FindAll(a_assets_path,a_directory_pattern,a_file_pattern);
			for(int ii=0;ii<t_list.Count;ii++){
				string t_path = t_list[ii];
				string t_text = LoadTextWithAssetsPath.Load(t_list[ii]);
				SaveTextWithAssetsPath.Save(t_text,t_path,a_encoding,a_linefeed_option);
			}
			RefreshAssetDatabase.Refresh();
			return true;
		}

		/** テキストコンバート。

			a_assets_path					: 「Assets」からの相対パス。
			a_directory_pattern				: ディレクトリ名の正規表現パターン。
			a_file_pattern					: ファイル名の正規表現パターン。
			a_encoding						: エンコード。
			a_linefeed_option				: 改行コード。

		*/
		public static bool TryConvertAll(string a_assets_path,string a_directory_pattern,string a_file_pattern,System.Text.Encoding a_encoding,LineFeedOption a_linefeed_option)
		{
			#pragma warning disable 0168
			try{
				return ConvertAll(a_assets_path,a_directory_pattern,a_file_pattern,a_encoding,a_linefeed_option);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return false;
			}
			#pragma warning restore
		}
	}
}
#endif

