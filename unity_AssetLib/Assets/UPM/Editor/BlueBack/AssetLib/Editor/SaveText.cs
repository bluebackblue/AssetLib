

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief テキストセーブ。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** SaveText
	*/
	public class SaveText
	{
		/** テキストセーブ。

			a_text							: テキスト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_bom							: BOM。
			a_linefeed_option				: 改行コード。

		*/
		public static void SaveUtf8TextToAssetsPath(string a_text,string a_assets_path_with_extention,bool a_bom,LineFeedOption a_linefeed_option)
		{
			string t_text;

			switch(a_linefeed_option){
			case LineFeedOption.LF:
				{
					t_text = a_text.Replace("\r\n","\n");
					t_text = t_text.Replace("\r","\n");
				}break;
			case LineFeedOption.CRLF:
				{
					t_text = a_text.Replace("\r\n","\n");
					t_text = t_text.Replace("\r","\n");
					t_text = t_text.Replace("\n","\r\n");
				}break;
			case LineFeedOption.None:
			default:
				{
					t_text = a_text;
				}break;
			}

			using(System.IO.StreamWriter t_stream = new System.IO.StreamWriter(AssetLib.GetApplicationDataPath() + "/" + a_assets_path_with_extention,false,new System.Text.UTF8Encoding(a_bom))){
				t_stream.Write(t_text);
				t_stream.Flush();
				t_stream.Close();
			}
		}

		/** テキストセーブ。

			a_text							: テキスト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_bom							: BOM。
			a_linefeed_option				: 改行コード。

		*/
		public static bool TrySaveUtf8TextToAssetsPath(string a_text,string a_assets_path_with_extention,bool a_bom,LineFeedOption a_linefeed_option)
		{
			bool t_result;

			#pragma warning disable 0168
			try{
				SaveUtf8TextToAssetsPath(a_text,a_assets_path_with_extention,a_bom,a_linefeed_option);
				t_result = true;
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif

				t_result = false;
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif

				t_result = false;
			}
			#pragma warning restore

			return t_result;
		}
	}
}
#endif

