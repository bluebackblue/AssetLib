

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief バイナリロード。フルパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadBinaryWithFullPath
	*/
	public static class LoadBinaryWithFullPath
	{
		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。
			return							: バイナリ。

		*/
		public static byte[] Load(string a_full_path_with_extention)
		{
			System.IO.FileInfo t_fileinfo = new System.IO.FileInfo(a_full_path_with_extention);
			using(System.IO.FileStream t_filestream = t_fileinfo.Open(System.IO.FileMode.Open,System.IO.FileAccess.Read,System.IO.FileShare.ReadWrite)){
				byte[] t_buffer = new byte[t_filestream.Length];
				int t_readsize = t_filestream.Read(t_buffer,0,t_buffer.Length);
				t_filestream.Close();
				if(t_readsize != t_buffer.Length){
					#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
					DebugTool.Assert(false,"readsize:" + t_readsize + ":buffersize" + t_buffer.Length);
					#endif
					return null;
				}
				return t_buffer;
			}
		}

		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。
			return							: バイナリ。

		*/
		public static MultiResult<bool,byte[]> TryLoad(string a_assets_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,byte[]>(true,Load(a_assets_path_with_extention));
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,byte[]>(false,null);
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,byte[]>(false,null);
			}
			#pragma warning restore
		}

		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。
			a_buffer						: バッファ。

			return.result == true			: 成功。
			return.value					: 読み込みサイズ。

		*/
		public static MultiResult<bool,int> LoadToBuffer(string a_full_path_with_extention,byte[] a_buffer)
		{
			System.IO.FileInfo t_fileinfo = new System.IO.FileInfo(a_full_path_with_extention);
			using(System.IO.FileStream t_filestream = t_fileinfo.Open(System.IO.FileMode.Open,System.IO.FileAccess.Read,System.IO.FileShare.ReadWrite)){
				int t_readsize = t_filestream.Read(a_buffer,0,a_buffer.Length);
				t_filestream.Close();
				return new MultiResult<bool,int>(true,t_readsize);
			}
		}

		/** ロード。

			a_full_path_with_extention		: フルパス。拡張子付き。
			a_buffer						: バッファ。

			return.result == true			: 成功。
			return.value					: 読み込みサイズ。

		*/
		public static MultiResult<bool,int> TryLoadToBuffer(string a_full_path_with_extention,byte[] a_buffer)
		{
			#pragma warning disable 0168
			try{
				return LoadToBuffer(a_full_path_with_extention,a_buffer);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,int>(false,0);
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,int>(false,0);
			}
			#pragma warning restore
		}
	}
}
#endif

