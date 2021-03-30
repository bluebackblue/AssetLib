

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief エディターツール。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** EditorTool
	*/
	public class EditorTool
	{
		/** RefreshAssetDatabase
		*/
		public static void RefreshAssetDatabase()
		{
			UnityEditor.AssetDatabase.Refresh();
		}
	}
}

