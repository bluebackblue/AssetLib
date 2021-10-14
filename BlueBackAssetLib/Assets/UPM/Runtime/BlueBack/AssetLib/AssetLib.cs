

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

		/** AssetLib
		*/
		static AssetLib()
		{
			s_application_data_path = NormalizePath.NormalizeSeparateAndLast(UnityEngine.Application.dataPath);
		}

		/** GetApplicationDataPath
		*/
		public static string GetApplicationDataPath()
		{
			return s_application_data_path;
		}
	}
}

