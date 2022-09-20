

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief バイナリロード。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadBinaryWithAssetsPath
	*/
	public static class LoadBinaryWithAssetsPath
	{
		/** ロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			return							: バイナリ。

		*/
		public static byte[] Load(string a_assets_path_with_extention)
		{
			return LoadBinaryWithFullPath.Load(AssetLib.application_data_path + '\\' + a_assets_path_with_extention);
		}

		/** ロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			return							: バイナリ。

		*/
		public static MultiResult<bool,byte[]> TryLoad(string a_assets_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,byte[]>(true,Load(a_assets_path_with_extention));
			}catch(System.IO.FileNotFoundException t_exception){
				//ファイルなし。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,byte[]>(false,null);
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,byte[]>(false,null);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,byte[]>(false,null);
			}
			#pragma warning restore
		}

		/** ロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_buffer						: バッファ。

			return.result == true			: 成功。
			return.value					: 読み込みサイズ。

		*/
		public static MultiResult<bool,int> LoadToBuffer(string a_assets_path_with_extention,byte[] a_buffer)
		{
			return LoadBinaryWithFullPath.LoadToBuffer(AssetLib.application_data_path + '\\' + a_assets_path_with_extention,a_buffer);
		}

		/** ロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_buffer						: バッファ。

			return.result == true			: 成功。
			return.value					: 読み込みサイズ。

		*/
		public static MultiResult<bool,int> TryLoadToBuffer(string a_assets_path_with_extention,byte[] a_buffer)
		{
			#pragma warning disable 0168
			try{
				return LoadToBuffer(a_assets_path_with_extention,a_buffer);
			}catch(System.IO.FileNotFoundException t_exception){
				//ファイルなし。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,int>(false,0);
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,int>(false,0);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,int>(false,0);
			}
			#pragma warning restore
		}
	}
}
#endif

