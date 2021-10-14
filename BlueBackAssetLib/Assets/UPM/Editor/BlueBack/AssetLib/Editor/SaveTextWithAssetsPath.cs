

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief テキストセーブ。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** SaveTextWithAssetsPath
	*/
	public static class SaveTextWithAssetsPath
	{
		/** テキストセーブ。

			a_text							: テキスト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_bom							: BOM
			a_linefeedoption				: 改行コード。

		*/
		public static bool SaveUtf8(string a_text,string a_assets_path_with_extention,bool a_bom,LineFeedOption a_linefeedoption)
		{
			return SaveTextWithFullPath.SaveUtf8(a_text,AssetLib.GetApplicationDataPath() + '\\' + a_assets_path_with_extention,a_bom,a_linefeedoption);
		}

		/** テキストセーブ。

			a_text							: テキスト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_bom							: BOM
			a_encoding						: エンコード。
			a_linefeedoption				: 改行コード。
			return == true					: 成功。

		*/
		public static bool TrySaveUtf8(string a_text,string a_assets_path_with_extention,bool a_bom,LineFeedOption a_linefeedoption)
		{
			#pragma warning disable 0168
			try{
				return SaveUtf8(a_text,a_assets_path_with_extention,a_bom,a_linefeedoption);
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

