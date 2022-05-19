

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief バイナリセーブ。フルパス。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** SaveBinaryWithFullPath
	*/
	public static class SaveBinaryWithFullPath
	{
		/** セーブ。

			a_binary						: バイナリー。
			a_full_path_with_extention		: フルパス。拡張子付き。

		*/
		public static bool Save(byte[] a_binary,string a_full_path_with_extention)
		{
			using(System.IO.BinaryWriter t_stream = new System.IO.BinaryWriter(System.IO.File.Open(a_full_path_with_extention,System.IO.FileMode.Create))){
				t_stream.Write(a_binary);
				t_stream.Flush();
				t_stream.Close();
			}
			return true;
		}

		/** セーブ。

			a_binary						: バイナリー。
			a_full_path_with_extention		: フルパス。拡張子付き。
			return == true					: 成功。

		*/
		public static bool TrySave(byte[] a_binary,string a_full_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return Save(a_binary,a_full_path_with_extention);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return false;
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return false;
			}
			#pragma warning restore
		}
	}
}

