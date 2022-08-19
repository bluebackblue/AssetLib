

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 結果。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** PathResult
	*/
	public struct PathResult<VALUE>
	{
		/** path
		*/
		public string path;

		/** value
		*/
		public VALUE value;

		/** constructor
		*/
		public PathResult(in string a_path,in VALUE a_value)
		{
			//path
			this.path = a_path;

			//value
			this.value = a_value;
		}
	}
}

