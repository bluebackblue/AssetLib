

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief テキストのセーブ。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** SaveText
	*/
	public class SaveText
	{
		/** テキストファイル書き込み。

			a_text							: テキスト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_bom							: BOM。

		*/
		public static void SaveUtf8TextToAssetsPath(string a_text,string a_assets_path_with_extention,bool a_bom)
		{
			using(System.IO.StreamWriter t_stream = new System.IO.StreamWriter(UnityEngine.Application.dataPath + "/" + a_assets_path_with_extention,false,new System.Text.UTF8Encoding(a_bom))){
				t_stream.Write(a_text);
				t_stream.Flush();
				t_stream.Close();
			}
		}

		/** テキストファイル書き込み。

			a_text							: テキスト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_bom							: BOM。

		*/
		public static bool TrySaveUtf8TextToAssetsPath(string a_text,string a_assets_path_with_extention,bool a_bom)
		{
			bool t_result;

			try{
				SaveUtf8TextToAssetsPath(a_text,a_assets_path_with_extention,a_bom);
				t_result = true;
			}catch(System.IO.IOException /*t_exception*/){
				//ＩＯエラー。
				DebugTool.Assert(false);
				t_result = false;
			}catch(System.Exception /*t_exception*/){
				//エラー。
				DebugTool.Assert(false);
				t_result = false;
			}

			return t_result;
		}
	}
}

