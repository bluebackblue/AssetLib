

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief AssetLib。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** AssetLib
	*/
	public static class AssetLib
	{
		/** application_data_path
		*/
		private static string s_application_data_path = null;

		/** TODO:正規化。
		
			「/」を「\」変換。
			最後に「\」を付けない。

		*/
		private static string Inner_Path_Normalize(string a_path)
		{
			string t_path = a_path.Replace('/','\\');
			if(t_path.Length > 0){
				if(t_path[t_path.Length - 1] == '\\'){
					return t_path.Substring(0,t_path.Length - 1);
				}else{
					return t_path;
				}
			}
			return "";
		}

		/** AssetLib
		*/
		static AssetLib()
		{
			//s_application_data_path
			s_application_data_path = Inner_Path_Normalize(UnityEngine.Application.dataPath);
		}

		/** GetApplicationDataPath
		*/
		public static string GetApplicationDataPath()
		{
			return s_application_data_path;
		}
	}
}

