

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief デバッグツール。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** DebugTool
	*/
	public class DebugTool
	{
		/** Assert
		*/
		#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
		public static void Assert(bool a_flag)
		{
			if(a_flag != true){
				Config.ERRORPROC();
			}
		}
		#endif
	}
}

