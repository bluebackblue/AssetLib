

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
		public delegate void ErrorProcType(System.Exception a_text);
		public static ErrorProcType ERRORPROC = DebugTool.ErrorProc;
		#endif
	}
}

