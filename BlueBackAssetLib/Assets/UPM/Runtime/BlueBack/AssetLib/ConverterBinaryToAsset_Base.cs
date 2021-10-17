

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アセットコンバート。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** ConverterBinaryToAsset_Base
	*/
	public interface ConverterBinaryToAsset_Base<T>
		where T : UnityEngine.Object
	{
		/** [BlueBack.AssetLib.ConverterBinaryToAsset_Base]Convert
		*/
		T Convert(byte[] a_binary);
	}
}

