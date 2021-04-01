

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
	public class RefreshAsset
	{
		/** アセットリフレッシュ
		*/
		#if(UNITY_EDITOR)
		public static void Refresh()
		{
			UnityEditor.AssetDatabase.Refresh();
		}
		#endif
	}
}

