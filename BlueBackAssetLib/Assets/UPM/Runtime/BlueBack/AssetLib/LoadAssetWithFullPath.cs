

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief アセットロード。フルパス。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** LoadAssetWithFullPath
	*/
	public static class LoadAssetWithFullPath
	{
		/** ロード。コンバター。

			a_converter						: コンバター。
			a_full_path_with_extention		: フルパス。拡張子付き。

		*/
		public static T LoadConverter<T>(ConverterBinaryToAsset_Base<T> a_converter,string a_full_path_with_extention)
			where T : UnityEngine.Object
		{
			return a_converter.Convert(LoadBinaryWithFullPath.Load(a_full_path_with_extention));
		}

		/** ロード。コンバター。

			a_converter						: コンバター。
			a_full_path_with_extention		: フルパス。拡張子付き。

		*/
		public static MultiResult<bool,T> TryLoadConverter<T>(ConverterBinaryToAsset_Base<T> a_converter,string a_full_path_with_extention)
			where T : UnityEngine.Object
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,T>(true,LoadConverter<T>(a_converter,a_full_path_with_extention));
			}catch(System.IO.FileNotFoundException t_exception){
				//ファイルなし。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,T>(false,null);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,T>(false,null);
			}
			#pragma warning restore
		}
	}
}

