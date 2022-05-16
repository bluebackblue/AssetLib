

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief アセットコンバート。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** ConverterAssetToBinary_Base
	*/
	public interface ConverterAssetToBinary_Base<T>
		where T : UnityEngine.Object
	{
		/** [BlueBack.AssetLib.ConverterAssetToBinary_Base]Convert
		*/
		byte[] Convert(T a_asset);
	}
}

