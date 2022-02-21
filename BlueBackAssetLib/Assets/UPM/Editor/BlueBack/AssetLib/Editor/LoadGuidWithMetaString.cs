

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＵＩＤロード。メタ文字列。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadGuidWithMetaString
	*/
	public static class LoadGuidWithMetaString
	{
		/** s_regex
		*/
		private static System.Text.RegularExpressions.Regex s_regex;

		/** LoadGuidWithString
		*/
		static LoadGuidWithMetaString()
		{
			s_regex = new System.Text.RegularExpressions.Regex("^([\\d\\D\\n]*\nguid\\: )(?<guid>[a-zA-Z0-9]*)([\\d\\D\\n]*)$",System.Text.RegularExpressions.RegexOptions.Multiline);
		}

		/** ロード。

			a_meta_string	: メタ文字列。

		*/
		public static string Load(string a_meta_string)
		{
			System.Text.RegularExpressions.Match t_match = s_regex.Match(a_meta_string);
			if(t_match.Success == true){
				return t_match.Groups["guid"].Value;
			}
			return null;
		}
	}
}
#endif

