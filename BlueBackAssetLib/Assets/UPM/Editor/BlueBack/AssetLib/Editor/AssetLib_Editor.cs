

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief AssetLibÅB
*/


/** BlueBack.AssetLib.Editor
*/
namespace BlueBack.AssetLib.Editor
{
	/** AssetLib_Editor
	*/
	public static class AssetLib_Editor
	{
		/** application_data_path
		*/
		private static string application_data_path = null;

		/** AssetLib
		*/
		static AssetLib_Editor()
		{
			AssetLib_Editor.application_data_path = NormalizePath.NormalizeSeparateAndLast(UnityEngine.Application.dataPath);
		}

		/** GetApplicationDataPath
		*/
		public static string GetApplicationDataPath()
		{
			return AssetLib_Editor.application_data_path;
		}
	}
}

