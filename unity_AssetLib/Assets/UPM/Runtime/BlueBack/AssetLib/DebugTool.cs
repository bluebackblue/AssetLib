

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
		public static void Assert(bool a_flag,System.Exception a_exception = null)
		{
			if(a_flag != true){
				Config.ERRORPROC(a_exception);
			}
		}
		#endif

		/** EditorLog
		*/
		#if(UNITY_EDITOR)
		public static void EditorLog(string a_text)
		{
			UnityEngine.Debug.Log(a_text);
		}
		#endif
	}
}

