

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief バージョン。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** Version
	*/
	public class Version
	{
		/** packagename
		*/
		public const string packagename = "AssetLib";

		/** packageversion
		*/
		public const string packageversion = "0.0.31";

		/** GetPackageVersion
		*/
		public static string GetPackageVersion()
		{
			return packageversion;
		}
	}
}

