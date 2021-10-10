

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
	public static class RefreshAsset
	{
		/** アセットリフレッシュ。

			何かしら変更があったアセットをすべてインポートします。

		*/
		public static void Refresh()
		{
			UnityEditor.AssetDatabase.Refresh();
		}

		/** アセットリフレッシュ。

			アセットを強制的にロードして再シリアライズし、残っているデータ変更をディスクに送ります。

		*/
		public static void ForceReserializeAssets()
		{
			UnityEditor.AssetDatabase.ForceReserializeAssets();
		}
	}
}
#endif

