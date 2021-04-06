

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アセットリフレッシュ。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** RefreshAsset
	*/
	public class RefreshAsset
	{
		/** アセットリフレッシュ
		*/
		public static void Refresh()
		{
			UnityEditor.AssetDatabase.Refresh();
		}
	}
}
#endif

