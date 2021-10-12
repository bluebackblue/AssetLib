

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief テキストロード。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadGuid
	*/
	public static class LoadGuid
	{
		/** ＧＵＩＤロード。
		*/
		public static string LoadGuidFromString(string a_string)
		{
			System.Text.RegularExpressions.Match t_match = System.Text.RegularExpressions.Regex.Match(a_string,"^(?<before>[\\d\\D\\n]*\nguid\\: )(?<guid>[a-zA-Z0-9]*)(?<after>[\\d\\D\\n]*)$",System.Text.RegularExpressions.RegexOptions.Multiline);
			if(t_match.Success == true){
				return t_match.Groups["guid"].Value;
			}
			return null;
		}

		/** ＧＵＩＤロード。

			a_full_path_with_extention		: 絶対バス。拡張子付き。
			a_encoding						: 文字列エンコード。

		*/
		public static string LoadGuidFromFullPath(string a_full_path_with_extention,System.Text.Encoding a_encoding)
		{
			string t_text = LoadText.LoadTextFromFullPath(a_full_path_with_extention,a_encoding);
			return LoadGuidFromString(t_text);
		}

		/** ＧＵＩＤロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_encoding						: 文字列エンコード。

		*/
		public static string LoadGuidFromAssetsPath(string a_assets_path_with_extention,System.Text.Encoding a_encoding)
		{
			return LoadGuidFromFullPath(BlueBack.AssetLib.AssetLib.GetApplicationDataPath() + '\\' + a_assets_path_with_extention,a_encoding);
		}

		/** テキストロード。

			a_url							: ファイルのＵＲＬ。
			a_post							: POSTデータ。
			a_encoding						: 文字列エンコード。

		*/
		public static string LoadGuidFromUrl(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post,System.Text.Encoding a_encoding)
		{
			string t_text = LoadText.TryLoadTextFromUrl(a_url,a_post,a_encoding);
			return LoadGuidFromString(t_text);
		}

		/** テキストロード。

			a_full_path_with_extention		: 絶対バス。拡張子付き。
			a_encoding						: 文字列エンコード。

		*/
		public static string TryLoadGuidFromFullPath(string a_full_path_with_extention,System.Text.Encoding a_encoding)
		{
			#pragma warning disable 0168
			try{
				return LoadGuidFromFullPath(a_full_path_with_extention,a_encoding);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return null;
		}

		/** テキストロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_encoding						: 文字列エンコード。

		*/
		public static string TryLoadGuidFromAssetsPath(string a_assets_path_with_extention,System.Text.Encoding a_encoding)
		{
			#pragma warning disable 0168
			try{
				return LoadGuidFromAssetsPath(a_assets_path_with_extention,a_encoding);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return null;
		}

		/** テキストロード。

			a_url			: ファイルのＵＲＬ。
			a_post			: POSTデータ。
			a_encoding		: 文字列エンコード。

		*/
		public static string TryLoadGuidFromUrl(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post,System.Text.Encoding a_encoding)
		{
			#pragma warning disable 0168
			try{
				return LoadGuidFromUrl(a_url,a_post,a_encoding);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return null;
		}
	}
}
#endif

