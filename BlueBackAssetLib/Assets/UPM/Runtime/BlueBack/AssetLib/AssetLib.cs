

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
		/** application_streamingassets_path
		*/
		private static string application_streamingassets_path = null;

		/** AssetLib
		*/
		static AssetLib()
		{
			AssetLib.application_streamingassets_path = NormalizePath.NormalizeSeparateAndLast(UnityEngine.Application.streamingAssetsPath);
		}

		/** GetApplicationStreamingAssetsPath
		*/
		public static string GetApplicationStreamingAssetsPath()
		{
			return AssetLib.application_streamingassets_path;
		}
	}
}

