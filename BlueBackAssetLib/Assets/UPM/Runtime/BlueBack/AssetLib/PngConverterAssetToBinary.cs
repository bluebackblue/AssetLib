

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief PNG
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** PngConverterAssetToBinary
	*/
	public class PngConverterAssetToBinary : ConverterAssetToBinary_Base<UnityEngine.Texture2D>
	{
		/**getpixel
		*/
		public bool getpixel;
		public UnityEngine.TextureFormat getpixel_textureformat;
		
		/** copytexture
		*/
		bool copytexture;
		
		/** ConverterAssetToPngBinary
		*/
		public PngConverterAssetToBinary(bool a_copytexture = false,bool a_getpixel = false,UnityEngine.TextureFormat a_getpixel_textureformat = UnityEngine.TextureFormat.RGBA32)
		{
			this.copytexture = a_copytexture;
			this.getpixel = a_getpixel;
			this.getpixel_textureformat = a_getpixel_textureformat;
		}

		/** [BlueBack.AssetLib.ConverterAssetToBinary_Base]Convert
		*/
		public byte[] Convert(UnityEngine.Texture2D a_asset)
		{
			UnityEngine.Texture2D t_asset = a_asset;

			if(this.copytexture == true){
				UnityEngine.Texture2D t_new = new UnityEngine.Texture2D(t_asset.width,t_asset.height,t_asset.format,true);
				UnityEngine.Graphics.CopyTexture(t_asset,t_new);
				t_asset = t_new;
			}

			if(this.getpixel == true){
				UnityEngine.Texture2D t_new = new UnityEngine.Texture2D(t_asset.width,t_asset.height,this.getpixel_textureformat,true);
				UnityEngine.Color[] t_color = t_asset.GetPixels(0,0,t_asset.width,t_asset.height);
				t_new.SetPixels(0,0,t_asset.width,t_asset.height,t_color);
				t_asset = t_new;
			}

			return UnityEngine.ImageConversion.EncodeToPNG(a_asset);
		}
	}
}

