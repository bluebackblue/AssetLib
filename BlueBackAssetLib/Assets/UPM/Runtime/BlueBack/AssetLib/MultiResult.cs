

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 結果。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** MultiResult
	*/
	public readonly struct MultiResult<RESULT,VALUE>
	{
		/** result
		*/
		public readonly RESULT result;

		/** value
		*/
		public readonly VALUE value;

		/** constructor
		*/
		public MultiResult(in RESULT a_result,in VALUE a_value)
		{
			//result
			this.result = a_result;

			//value
			this.value = a_value;
		}
	}
}

