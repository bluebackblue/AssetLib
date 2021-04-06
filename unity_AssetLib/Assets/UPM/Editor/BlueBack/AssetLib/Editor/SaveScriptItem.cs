

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief スクリプトセーブ。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** SaveScriptItem
	*/
	public struct SaveScriptItem
	{
		/** value
		*/
		public string value;

		/** comment
		*/
		public string comment;

		/** constructor
		*/
		public SaveScriptItem(string a_value)
		{
			this.value = a_value;
			this.comment = null;
		}

		/** constructor
		*/
		public SaveScriptItem(string a_value,string a_comment)
		{
			this.value = a_value;
			this.comment = a_comment;
		}

		/** constructor
		*/
		public SaveScriptItem(string a_name,int a_value,string a_comment)
		{
			this.value = string.Format("{0} = {1}",a_name,a_value);
			this.comment = a_comment;
		}

		/** constructor
		*/
		public SaveScriptItem(string a_name,System.Int64 a_value,string a_comment)
		{
			this.value = string.Format("{0} = {1}",a_name,a_value);
			this.comment = a_comment;
		}

		/** constructor
		*/
		public SaveScriptItem(string a_name,System.UInt64 a_value,string a_comment)
		{
			this.value = string.Format("{0} = {1}",a_name,a_value);
			this.comment = a_comment;
		}
	}
}
#endif

