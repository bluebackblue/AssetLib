

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief コンフィグ。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** Config
	*/
	public class Config
	{
		/** ERRORPROC
		*/
		#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
		public delegate void ErrorProcType(System.Exception a_exception,string a_message);
		public static ErrorProcType ERRORPROC = DebugTool.ErrorProc;
		#endif

		/** DEFAULT_LINEFEEDOPTION
		*/
		#if(DEF_BLUEBACK_ASSETLIB_LF)
		public static LineFeedOption DEFAULT_LINEFEEDOPTION = LineFeedOption.LF;
		#else
		public static LineFeedOption DEFAULT_LINEFEEDOPTION = LineFeedOption.CRLF;
		#endif

		/** DEFAULT_BOM
		*/
		#if(DEF_BLUEBACK_ASSETLIB_BOM)
		public static bool DEFAULT_BOM = true;
		#else
		public static bool DEFAULT_BOM = false;
		#endif
	}
}

