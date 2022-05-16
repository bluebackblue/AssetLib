

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 結果。
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

	/** MultiResult
	*/
	public readonly struct MultiResult<R,V>
	{
		/** result
		*/
		public readonly R result;

		/** value
		*/
		public readonly V value;

		/** constructor
		*/
		public MultiResult(in R a_result,in V a_value)
		{
			//result
			this.result = a_result;

			//value
			this.value = a_value;
		}
	}
}

