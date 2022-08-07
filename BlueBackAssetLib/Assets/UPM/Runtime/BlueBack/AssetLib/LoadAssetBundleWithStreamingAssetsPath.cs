

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief アセットバンドルロード。ストリーミングアセットパス。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** LoadAssetBundleWithStreamingAssetsPath
	*/
	public static class LoadAssetBundleWithStreamingAssetsPath
	{
		/** ロード。

			a_streamingassets_path_with_extention	: 「StreamingAssets」からの相対バス。拡張子付き。

		*/
		public static UnityEngine.AssetBundle Load(string a_streamingassets_path_with_extention)
		{
			return LoadAssetBundleWithFullPath.Load(AssetLib.application_streamingassets_path + '\\' + a_streamingassets_path_with_extention);
		}

		/** ロード。

			a_streamingassets_path_with_extention	: 「StreamingAssets」からの相対バス。拡張子付き。

		*/
		public static MultiResult<bool,UnityEngine.AssetBundle> TryLoad(string a_streamingassets_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,UnityEngine.AssetBundle>(true,Load(a_streamingassets_path_with_extention));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,UnityEngine.AssetBundle>(false,null);
			}
			#pragma warning restore
		}
	}
}

