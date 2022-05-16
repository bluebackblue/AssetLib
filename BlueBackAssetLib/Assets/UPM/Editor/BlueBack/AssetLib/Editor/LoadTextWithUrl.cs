

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief テキストロード。ＵＲＬ。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadTextWithUrl
	*/
	public static class LoadTextWithUrl
	{
		/** ロード。

			a_url							: URL
			a_post == null					: GET

		*/
		public static string Load(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post)
		{
			byte[] t_binary = LoadBinaryWithUrl.Load(a_url,a_post);
			EncodeCheck.Result t_result = EncodeCheck.GetEncoding(t_binary);
			return t_result.encoding.GetString(t_binary,t_result.bomsize,t_binary.Length - t_result.bomsize);
		}

		/** ロード。

			a_url							: URL
			a_post == null					: GET
			return == true					: 成功。

		*/
		public static MultiResult<bool,string> TryLoad(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,Load(a_url,a_post));
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

			a_url							: URL
			a_post == null					: GET
			a_encoding						: エンコード。
			a_offset						: オフセット。

		*/
		public static string Load(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post,System.Text.Encoding a_encoding,int a_offset)
		{
			byte[] t_binary = LoadBinaryWithUrl.Load(a_url,a_post);
			return a_encoding.GetString(t_binary,a_offset,t_binary.Length - a_offset);
		}

		/** ロード。

			a_url							: URL
			a_post == null					: GET
			a_encoding						: エンコード。
			a_offset						: オフセット。
			return == true					: 成功。

		*/
		public static MultiResult<bool,string> TryLoad(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post,System.Text.Encoding a_encoding,int a_offset)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,Load(a_url,a_post));
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

			a_url							: URL
			a_post == null					: GET

		*/
		public static string LoadNoBomUtf8(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post)
		{
			return Load(a_url,a_post,new System.Text.UTF8Encoding(false),0);
		}

		/** ロード。UTF8。BOMなし。

			a_url							: URL
			a_post == null					: GET
			return == true					: 成功。

		*/
		public static MultiResult<bool,string> TryLoadNoBomUtf8(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,string>(true,LoadNoBomUtf8(a_url,a_post));
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

