

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
	public class AssetLib
	{
		/** application_data_path
		*/
		private static string s_application_data_path;

		/** AssetLib
		*/
		static AssetLib()
		{
			//s_application_data_path
			s_application_data_path = UnityEngine.Application.dataPath;
		}

		/** GetApplicationDataPath
		*/
		public static string GetApplicationDataPath()
		{
			return s_application_data_path;
		}
	}
}

