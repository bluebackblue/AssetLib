

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アセットのリフレッシュ。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** RefreshAsset
	*/
	#if(UNITY_EDITOR)
	public class RefreshAsset
	{
		/** Refresh
		*/
		public static void Refresh()
		{
			UnityEditor.AssetDatabase.Refresh();
		}
	}
	#endif
}

