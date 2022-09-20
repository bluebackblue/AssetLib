

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief テキストセーブ。フルパス。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** SaveTextWithFullPath
	*/
	public static class SaveTextWithFullPath
	{
		/** セーブ。

			a_text							: テキスト。
			a_full_path_with_extention		: フルバス。拡張子付き。
			a_encoding						: エンコード。
			a_linefeedoption				: 改行コード。

		*/
		public static string Save(string a_text,string a_full_path_with_extention,System.Text.Encoding a_encoding,LineFeedOption a_linefeedoption)
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

			using(System.IO.StreamWriter t_stream = new System.IO.StreamWriter(a_full_path_with_extention,false,a_encoding)){
				t_stream.Write(t_text);
				t_stream.Flush();
				t_stream.Close();
			}

			return t_text;
		}

		/** セーブ。

			a_text							: テキスト。
			a_full_path_with_extention		: フルバス。拡張子付き。
			a_encoding						: エンコード。
			a_linefeedoption				: 改行コード。
			return.result == true			: 成功。

		*/
		public static MultiResult<bool,string> TrySave(string a_text,string a_full_path_with_extention,System.Text.Encoding a_encoding,LineFeedOption a_linefeedoption)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,Save(a_text,a_full_path_with_extention,a_encoding,a_linefeedoption));
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,string>(false,null);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,string>(false,null);
			}
			#pragma warning restore
		}


		/** セーブ。BOMなし。UTF8。

			a_text							: テキスト。
			a_full_path_with_extention		: フルバス。拡張子付き。
			a_linefeedoption				: 改行コード。

		*/
		public static string SaveNoBomUtf8(string a_text,string a_full_path_with_extention,LineFeedOption a_linefeedoption)
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

			using(System.IO.StreamWriter t_stream = new System.IO.StreamWriter(a_full_path_with_extention,false,new System.Text.UTF8Encoding(false))){
				t_stream.Write(t_text);
				t_stream.Flush();
				t_stream.Close();
			}

			return t_text;
		}

		/** セーブ。BOMなし。UTF8。

			a_text							: テキスト。
			a_full_path_with_extention		: フルバス。拡張子付き。
			a_linefeedoption				: 改行コード。
			return.result == true			: 成功。

		*/
		public static MultiResult<bool,string> TrySaveNoBomUtf8(string a_text,string a_full_path_with_extention,LineFeedOption a_linefeedoption)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,SaveNoBomUtf8(a_text,a_full_path_with_extention,a_linefeedoption));
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,string>(false,null);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,string>(false,null);
			}
			#pragma warning restore
		}
	}
}

