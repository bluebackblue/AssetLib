

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
		private static void Error()
		{
			UnityEngine.Debug.Assert(false);
		}
		public delegate void ErrorProcType();
		public static ErrorProcType ERRORPROC = Error;
	}
}

