

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
	/** LoadText
	*/
	public class LoadText
	{
		/** テキストロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_encoding						: 文字列エンコード。

		*/
		public static string LoadTextFromAssetsPath(string a_assets_path_with_extention,System.Text.Encoding a_encoding)
		{
			byte[] t_data = LoadBinary.LoadBinaryFromAssetsPath(a_assets_path_with_extention);

			System.Text.Encoding t_encoding = a_encoding;
			if(t_encoding == null){
				t_encoding = EncodeCheck.GetEncoding(t_data);
			}

			return t_encoding.GetString(t_data);
		}

		/** テキストロード。

			a_url	: ファイルのＵＲＬ。
			a_post	: POSTデータ。
			a_encoding						: 文字列エンコード。

		*/
		public static string LoadTextFromUrl(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post,System.Text.Encoding a_encoding)
		{
			byte[] t_data = LoadBinary.TryLoadBinaryFromUrl(a_url,a_post);

			System.Text.Encoding t_encoding = a_encoding;
			if(t_encoding == null){
				t_encoding = EncodeCheck.GetEncoding(t_data);
			}

			return t_encoding.GetString(t_data);
		}

		/** テキストロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_encoding						: 文字列エンコード。

		*/
		public static string TryLoadTextFromAssetsPath(string a_assets_path_with_extention,System.Text.Encoding a_encoding)
		{
			#pragma warning disable 0168
			try{
				return LoadTextFromAssetsPath(a_assets_path_with_extention,a_encoding);
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
		public static string TryLoadTextFromUrl(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post,System.Text.Encoding a_encoding)
		{
			#pragma warning disable 0168
			try{
				return LoadTextFromUrl(a_url,a_post,a_encoding);
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

