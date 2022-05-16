

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief テキストロード。フルパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadTextWithFullPath
	*/
	public static class LoadTextWithFullPath
	{
		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。

		*/
		public static string Load(string a_full_path_with_extention)
		{
			byte[] t_binary = LoadBinaryWithFullPath.Load(a_full_path_with_extention);
			EncodeCheck.Result t_result = EncodeCheck.GetEncoding(t_binary);
			return t_result.encoding.GetString(t_binary,t_result.bomsize,t_binary.Length - t_result.bomsize);
		}

		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。
			return == true					: 成功。

		*/
		public static MultiResult<bool,string> TryLoad(string a_full_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,Load(a_full_path_with_extention));
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

		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。
			a_encoding						: エンコード。
			a_offset						: オフセット。

		*/
		public static string Load(string a_full_path_with_extention,System.Text.Encoding a_encoding,int a_offset)
		{
			byte[] t_binary = LoadBinaryWithFullPath.Load(a_full_path_with_extention);
			return a_encoding.GetString(t_binary,a_offset,t_binary.Length - a_offset);
		}

		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。
			a_encoding						: エンコード。
			a_offset						: オフセット。
			return == true					: 成功。

		*/
		public static MultiResult<bool,string> TryLoad(string a_full_path_with_extention,System.Text.Encoding a_encoding,int a_offset)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,Load(a_full_path_with_extention));
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

		/** ロード。UTF8。BOMなし。

			a_full_path_with_extention		: フルパス。拡張子付き。

		*/
		public static string LoadNoBomUtf8(string a_full_path_with_extention)
		{
			return Load(a_full_path_with_extention,new System.Text.UTF8Encoding(false),0);
		}

		/** ロード。UTF8。BOMなし。

			a_full_path_with_extention		: フルパス。拡張子付き。
			return == true					: 成功。

		*/
		public static MultiResult<bool,string> TryLoadNoBomUtf8(string a_full_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,LoadNoBomUtf8(a_full_path_with_extention));
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

