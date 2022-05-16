

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief デバッグツール。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** Asmdef
	*/
	public struct Asmdef
	{
		/** VersionDefine
		*/
		public struct VersionDefine
		{
			/** name
			*/
			public string name;

			/** expression
			*/
			public string expression;

			/** define
			*/
			public string define;
		}

		/** name
		*/
		public string name;

		/** rootNamespace
		*/
		public string rootNamespace;

		/** references
		*/
		public string[] references;

		/** includePlatforms
		*/
		public string[] includePlatforms;

		/** excludePlatforms
		*/
		public string[] excludePlatforms;

		/** allowUnsafeCode
		*/
		public bool allowUnsafeCode;

		/** overrideReferences
		*/
		public bool overrideReferences;

		/** precompiledReferences
		*/
		public string[] precompiledReferences;

		/** autoReferenced
		*/
		public bool autoReferenced;

		/** defineConstraints
		*/
		public string[] defineConstraints;

		/** versionDefines
		*/
		public VersionDefine[] versionDefines;

		/** noEngineReferences
		*/
		public bool noEngineReferences;
	}
}

