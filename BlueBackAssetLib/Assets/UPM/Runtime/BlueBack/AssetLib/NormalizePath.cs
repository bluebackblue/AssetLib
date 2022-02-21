

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief パス正規化。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** NormalizePath
	*/
	public static class NormalizePath
	{
		/** 正規化。セパレート。最後。
		
			「/」を「\」に変換。
			最後に「\」を付けない。

		*/
		public static string NormalizeSeparateAndLast(string a_path)
		{
			#pragma warning disable 0162
			int t_length = a_path.Length;
			if(t_length > 0){
				switch(a_path[t_length - 1]){
				case '\\':
				case '/':
					{
						return a_path.Substring(0,t_length - 1).Replace('/','\\');
					}break;
				default:
					{
						return a_path.Replace('/','\\');
					}break;
				}
			}else{
				return "";
			}
			#pragma warning restore
		}
    }
}

