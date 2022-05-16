

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief PNG
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** PngConverterBinaryToAsset
	*/
	public class PngConverterBinaryToAsset : ConverterBinaryToAsset_Base<UnityEngine.Texture2D>
	{
		/** ConverterPngBinaryToAsset
		*/
		public PngConverterBinaryToAsset()
		{
		}

		/** [BlueBack.AssetLib.ConverterBinaryToAsset_Base]Convert
		*/
		public UnityEngine.Texture2D Convert(byte[] a_binary)
		{
			UnityEngine.Texture2D t_texture = new UnityEngine.Texture2D(2,2);
			UnityEngine.ImageConversion.LoadImage(t_texture,a_binary);
			return t_texture;
		}
	}
}

