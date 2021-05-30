

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief スクリプトセーブ。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** SaveScript
	*/
	public class SaveScript
	{
		/** 値に置き換えるための文字列。
		*/
		public const string KEY_VALUE = "<<VALUE>>";

		/** コメントに置き換えるための文字列。
		*/
		public const string KEY_COMMENT = "<<COMMENT>>";

		/** コメントに置き換えるための文字列。
		*/
		public const string KEY_COUNT = "<<COUNT>>";

		/** スクリプトセーブ。

			a_list							: リスト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_template_header				: ヘッダー。
			a_template_loop					: <<VALUE>> / <<COMMENT>> / <<COUNT>>を置き換える。アイテムの数だけ出力する。
			a_template_loopend				: <<VALUE>> / <<COMMENT>> / <<COUNT>>を置き換える。最後のアイテムは「a_template_loop」ではなく「a_template_loopend」が使用される。
			a_template_footer				: フッター。
			a_replace_list					: 置き換えリスト。
			a_bom							: BOM。
			a_linefeed_option				: 改行コード。

		*/
		public static string SaveScriptToAssetsPath(System.Collections.Generic.List<SaveScriptItem> a_list,string a_assets_path_with_extention,string[] a_template_header,string[] a_template_loop,string[] a_template_loopend,string[] a_template_footer,System.Collections.Generic.Dictionary<string,string> a_replace_list,bool a_bom,LineFeedOption a_linefeed_option)
		{
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();

			if(a_template_header != null){
				foreach(string t_template in a_template_header){
					t_stringbuilder.Append(t_template);
					t_stringbuilder.Append("\r\n");
				}
			}

			if(a_list != null){
				for(int ii = 0;ii < (a_list.Count-1);ii++){
					foreach(string t_template in a_template_loop){
						t_stringbuilder.Append(t_template.Replace(KEY_VALUE,a_list[ii].value).Replace(KEY_COMMENT,a_list[ii].comment).Replace(KEY_COUNT,ii.ToString()));
						t_stringbuilder.Append("\r\n");
					}
				}

				if(a_list.Count > 0){
					int ii = a_list.Count - 1;
					foreach(string t_template in a_template_loopend){
						t_stringbuilder.Append(t_template.Replace(KEY_VALUE,a_list[ii].value).Replace(KEY_COMMENT,a_list[ii].comment).Replace(KEY_COUNT,ii.ToString()));
						t_stringbuilder.Append("\r\n");
					}
				}
			}

			if(a_template_footer != null){
				foreach(string t_template in a_template_footer){
					t_stringbuilder.Append(t_template);
					t_stringbuilder.Append("\r\n");
				}
			}

			string t_text = t_stringbuilder.ToString();

			for(int ii=0;ii<8;ii++){
				bool t_change = false;

				foreach(System.Collections.Generic.KeyValuePair<string,string> t_pair in a_replace_list){
					string t_text_replace = t_text.Replace(t_pair.Key,t_pair.Value);
					if(t_text != t_text_replace){
						t_text = t_text_replace;
						t_change = true;
					}
				}

				if(t_change == false){
					break;
				}
			}

			BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_text,a_assets_path_with_extention,a_bom,a_linefeed_option);
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();

			return t_text;
		}
	}
}
#endif

