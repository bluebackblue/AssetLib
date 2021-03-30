

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
		private static void ErrorProc(System.Exception a_exception)
		{
			if(a_exception != null){
				UnityEngine.Debug.LogError(a_exception.ToString());
			}
			UnityEngine.Debug.Assert(false);
		}
		public delegate void ErrorProcType(System.Exception a_text);
		public static ErrorProcType ERRORPROC = ErrorProc;
		#endif
	}
}

