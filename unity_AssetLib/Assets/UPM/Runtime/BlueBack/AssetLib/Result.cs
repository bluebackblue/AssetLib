

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 結果。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** Result
	*/
	public struct Result<T>
	{
		/** success
		*/
		public bool success;

		/** value
		*/
		public T value;
	}
}

