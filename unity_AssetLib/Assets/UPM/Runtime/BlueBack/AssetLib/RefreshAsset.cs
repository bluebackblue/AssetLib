

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アセットリフレッシュ。
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
		/** アセットリフレッシュ
		*/
		public static void Refresh()
		{
			UnityEditor.AssetDatabase.Refresh();
		}
	}
	#endif
}

