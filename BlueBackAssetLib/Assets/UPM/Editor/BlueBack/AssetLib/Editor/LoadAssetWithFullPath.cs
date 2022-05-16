

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief アセットロード。フルパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
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
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,T>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

