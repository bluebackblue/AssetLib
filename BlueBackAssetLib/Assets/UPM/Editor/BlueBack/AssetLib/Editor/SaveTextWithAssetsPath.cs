

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief テキストセーブ。アセットパス。
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
		/** セーブ。

			a_text							: テキスト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_encoding						: エンコード。
			a_linefeedoption				: 改行コード。

		*/
		public static string Save(string a_text,string a_assets_path_with_extention,System.Text.Encoding a_encoding,LineFeedOption a_linefeedoption)
		{
			return SaveTextWithFullPath.Save(a_text,AssetLib.GetApplicationDataPath() + '\\' + a_assets_path_with_extention,a_encoding,a_linefeedoption);
		}

		/** セーブ。

			a_text							: テキスト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_bom							: BOM
			a_encoding						: エンコード。
			a_linefeedoption				: 改行コード。
			return.result == true			: 成功。

		*/
		public static MultiResult<bool,string> TrySave(string a_text,string a_assets_path_with_extention,System.Text.Encoding a_encoding,LineFeedOption a_linefeedoption)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,Save(a_text,a_assets_path_with_extention,a_encoding,a_linefeedoption));
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,string>(false,null);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,string>(false,null);
			}
			#pragma warning restore
		}


		/** セーブ。BOMなし。UTF8。

			a_text							: テキスト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_linefeedoption				: 改行コード。

		*/
		public static string SaveNoBomUtf8(string a_text,string a_assets_path_with_extention,LineFeedOption a_linefeedoption)
		{
			return SaveTextWithFullPath.SaveNoBomUtf8(a_text,AssetLib.GetApplicationDataPath() + '\\' + a_assets_path_with_extention,a_linefeedoption);
		}

		/** セーブ。BOMなし。UTF8。

			a_text							: テキスト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_encoding						: エンコード。
			a_linefeedoption				: 改行コード。
			return.result == true			: 成功。

		*/
		public static MultiResult<bool,string> TrySaveNoBomUtf8(string a_text,string a_assets_path_with_extention,LineFeedOption a_linefeedoption)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,SaveNoBomUtf8(a_text,a_assets_path_with_extention,a_linefeedoption));
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,string>(false,null);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,string>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

