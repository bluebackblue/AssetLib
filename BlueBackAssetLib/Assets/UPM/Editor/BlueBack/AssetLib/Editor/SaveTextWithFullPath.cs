

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief テキストセーブ。フルパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** SaveTextWithFullPath
	*/
	public static class SaveTextWithFullPath
	{
		/** テキストセーブ。

			a_text							: テキスト。
			a_full_path_with_extention		: フルバス。拡張子付き。
			a_bom							: BOM
			a_linefeedoption				: 改行コード。

		*/
		public static bool SaveUtf8(string a_text,string a_full_path_with_extention,bool a_bom,LineFeedOption a_linefeedoption)
		{
			string t_text;

			switch(a_linefeedoption){
			case LineFeedOption.LF:
				{
					t_text = a_text.Replace("\r","");
				}break;
			case LineFeedOption.CRLF:
				{
					t_text = a_text.Replace("\r","");
					t_text = t_text.Replace("\n","\r\n");
				}break;
			case LineFeedOption.None:
			default:
				{
					t_text = a_text;
				}break;
			}

			using(System.IO.StreamWriter t_stream = new System.IO.StreamWriter(a_full_path_with_extention,false,new System.Text.UTF8Encoding(a_bom))){
				t_stream.Write(t_text);
				t_stream.Flush();
				t_stream.Close();
			}

			return true;
		}

		/** テキストセーブ。

			a_text							: テキスト。
			a_full_path_with_extention		: フルバス。拡張子付き。
			a_bom							: BOM
			a_encoding						: エンコード。
			a_linefeedoption				: 改行コード。
			return == true					: 成功。

		*/
		public static bool TrySaveUtf8(string a_text,string a_full_path_with_extention,bool a_bom,LineFeedOption a_linefeedoption)
		{
			#pragma warning disable 0168
			try{
				return SaveUtf8(a_text,a_full_path_with_extention,a_bom,a_linefeedoption);
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return false;
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return false;
			}
			#pragma warning restore
		}
	}
}
#endif

