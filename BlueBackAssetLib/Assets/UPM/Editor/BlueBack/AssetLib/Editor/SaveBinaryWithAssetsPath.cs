

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief バイナリセーブ。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** SaveBinaryWithAssetsPath
	*/
	public static class SaveBinaryWithAssetsPath
	{
		/** セーブ。

			a_binary						: バイナリー。
			a_full_path_with_extention		: フルパス。拡張子付き。

		*/
		public static bool Save(byte[] a_binary,string a_full_path_with_extention)
		{
			return SaveBinaryWithFullPath.Save(a_binary,AssetLib.application_data_path + '\\' + a_full_path_with_extention);
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
#endif

