

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief AssetLib。
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

		/** s_application_streamingassets_path
		*/
		private static string s_application_streamingassets_path = null;

		/** AssetLib
		*/
		static AssetLib()
		{
			s_application_data_path = NormalizePath.NormalizeSeparateAndLast(UnityEngine.Application.dataPath);
			s_application_streamingassets_path = NormalizePath.NormalizeSeparateAndLast(UnityEngine.Application.streamingAssetsPath);
		}

		/** GetApplicationDataPath
		*/
		public static string GetApplicationDataPath()
		{
			return s_application_data_path;
		}

		/** GetApplicationStreamingAssetsPath
		*/
		public static string GetApplicationStreamingAssetsPath()
		{
			return s_application_streamingassets_path;
		}
	}
}

