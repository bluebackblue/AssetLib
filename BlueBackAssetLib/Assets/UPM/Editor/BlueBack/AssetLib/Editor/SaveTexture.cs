	

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief テクスチャーセーブ。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** SaveTexture
	*/
	public static class SaveTexture
	{
		/** ＰＮＧとしてテクスチャーセーブ。

			a_texture						: テクスチャー。
			a_assets_path_with_extention		: 「Assets」からの相対バス。拡張子付き。

		*/
		public static void SaveAsPngTexture2DToAssetsPath(UnityEngine.Texture2D a_texture,string a_assets_path_with_extention)
		{
			byte[] t_binary = UnityEngine.ImageConversion.EncodeToPNG(a_texture);
			SaveBinaryWithAssetsPath.Save(t_binary,a_assets_path_with_extention);
		}
	}
}
#endif

