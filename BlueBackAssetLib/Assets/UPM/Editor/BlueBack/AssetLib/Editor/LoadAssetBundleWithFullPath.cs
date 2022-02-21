

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief アセットバンドルロード。フルパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadAssetBundleWithFullPath
	*/
	public static class LoadAssetBundleWithFullPath
	{
		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。

		*/
		public static UnityEngine.AssetBundle Load(string a_full_path_with_extention)
		{
			return UnityEngine.AssetBundle.LoadFromMemory(LoadBinaryWithFullPath.Load(a_full_path_with_extention));
		}

		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。

		*/
		public static MultiResult<bool,UnityEngine.AssetBundle> TryLoad(string a_full_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,UnityEngine.AssetBundle>(true,Load(a_full_path_with_extention));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,UnityEngine.AssetBundle>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

