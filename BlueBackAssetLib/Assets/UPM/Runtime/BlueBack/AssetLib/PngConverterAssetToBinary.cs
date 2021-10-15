

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief PNG
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** PngConverterAssetToBinary
	*/
	public class PngConverterAssetToBinary : ConverterAssetToBinary_Base<UnityEngine.Texture2D>
	{
		/** ConverterAssetToPngBinary
		*/
		public PngConverterAssetToBinary()
		{
		}

		/** [BlueBack.AssetLib.ConverterAssetToBinary_Base]Convert
		*/
		public byte[] Convert(UnityEngine.Texture2D a_asset)
		{
			return UnityEngine.ImageConversion.EncodeToPNG(a_asset);
		}
	}
}

