

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＥＮＵＭセーブ。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** SaveEnum
	*/
	public class SaveEnum
	{
		/** メッシュセーブ。

			a_enum							: ＥＮＵＭ。
			a_assets_path_with_extention		: 「Assets」からの相対バス。拡張子付き。
			a_template_header				: ヘッダー。
			a_template_loop					: <<V>>を値、<<C>>をコメントに置き換る。アイテムの数だけ出力する。
			a_template_loopend				: <<V>>を値、<<C>>をコメントに置き換る。最後のアイテムは「a_template_loop」ではなく「a_template_loopend」が使用される。
			a_template_footer				: フッター。

		*/
		public static void SaveEnumToAssetsPath(System.Collections.Generic.List<SaveEnumItem> a_enum,string a_assets_path_with_extention,string[] a_template_header,string[] a_template_loop,string[] a_template_loopend,string[] a_template_footer)
		{
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
			foreach(string t_template in a_template_header){
				t_stringbuilder.Append(t_template);
				t_stringbuilder.Append("\n");
			}

			for(int ii = 0;ii < (a_enum.Count-1);ii++){
				foreach(string t_template in a_template_loop){
					t_stringbuilder.Append(t_template.Replace("<<V>>",a_enum[ii].value).Replace("<<C>>",a_enum[ii].comment));
					t_stringbuilder.Append("\n");
				}
			}
			if(a_enum.Count > 1){
				int ii = a_enum.Count - 1;
				foreach(string t_template in a_template_loopend){
					t_stringbuilder.Append(t_template.Replace("<<V>>",a_enum[ii].value).Replace("<<C>>",a_enum[ii].comment));
					t_stringbuilder.Append("\n");
				}
			}

			foreach(string t_template in a_template_footer){
				t_stringbuilder.Append(t_template);
				t_stringbuilder.Append("\n");
			}

			BlueBack.AssetLib.SaveText.SaveUtf8TextToAssetsPath(t_stringbuilder.ToString(),a_assets_path_with_extention,false);
			BlueBack.AssetLib.RefreshAsset.Refresh();
		}

	}
}

