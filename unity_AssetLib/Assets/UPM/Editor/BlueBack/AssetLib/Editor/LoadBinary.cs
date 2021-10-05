

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief バイナリロード。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadBinary
	*/
	public class LoadBinary
	{
		/** バイナリロード。

			a_full_path_with_extention		: 絶対バス。拡張子付き。
			a_buffer						: ロード先バッファ。

			return							: 読み込んだサイズ。

		*/
		public static long LoadBinaryToBufferFromFullPath(string a_full_path_with_extention,byte[] a_buffer)
		{
			//ファイルパス。
			System.IO.FileInfo t_fileinfo = new System.IO.FileInfo(a_full_path_with_extention);

			//開く。
			using(System.IO.FileStream t_filestream = t_fileinfo.Open(System.IO.FileMode.Open,System.IO.FileAccess.Read,System.IO.FileShare.ReadWrite)){
				long t_result = t_filestream.Read(a_buffer,0,a_buffer.Length);
				t_filestream.Close();
				return t_result;
			}
		}

		/** バイナリロード。

			a_full_path_with_extention		: 絶対バス。拡張子付き。

		*/
		public static byte[] LoadBinaryFromFullPath(string a_full_path_with_extention)
		{
			//ファイルパス。
			System.IO.FileInfo t_fileinfo = new System.IO.FileInfo(a_full_path_with_extention);

			//開く。
			using(System.IO.FileStream t_filestream = t_fileinfo.Open(System.IO.FileMode.Open,System.IO.FileAccess.Read,System.IO.FileShare.ReadWrite)){
				byte[] t_result = new byte[t_filestream.Length];
				int t_ret_read = t_filestream.Read(t_result,0,t_result.Length);
				t_filestream.Close();

				if(t_ret_read != t_result.Length){
					return null;
				}

				return t_result;
			}
		}


		/** バイナリロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_buffer						: ロード先バッファ。

			return							: 読み込んだサイズ。

		*/
		public static long LoadBinaryToBufferFromAssetsPath(string a_assets_path_with_extention,byte[] a_buffer)
		{
			return LoadBinaryToBufferFromFullPath(AssetLib.GetApplicationDataPath() + "/" + a_assets_path_with_extention,a_buffer);
		}

		/** バイナリロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static byte[] LoadBinaryFromAssetsPath(string a_assets_path_with_extention)
		{
			return LoadBinaryFromFullPath(AssetLib.GetApplicationDataPath() + "/" + a_assets_path_with_extention);
		}

		/** バイナリロード。

			a_url	: ファイルのＵＲＬ。
			a_post	: POSTデータ。

		*/
		public static byte[] LoadBinaryFromUrl(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post)
		{
			using(UnityEngine.Networking.UnityWebRequest t_webrequest = ((System.Func<UnityEngine.Networking.UnityWebRequest>)(()=>{
				if(a_post == null){
					return UnityEngine.Networking.UnityWebRequest.Get(a_url);
				}else{
					return UnityEngine.Networking.UnityWebRequest.Post(a_url,a_post);
				}
			}))()){
				UnityEngine.Networking.UnityWebRequestAsyncOperation t_async = t_webrequest.SendWebRequest();

				while(true){
					System.Threading.Thread.Sleep(1);
					if(t_async.isDone == true){
						if(t_webrequest.error != null){
							#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
							DebugTool.Assert(false,t_webrequest.error);
							#endif

							return null;
						}else{
							byte[] t_binary = t_webrequest.downloadHandler.data;
							if(t_binary == null){
								#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
								DebugTool.Assert(false,t_webrequest.error);
								#endif

								return null;
							}else{
								return t_binary;
							}
						}
					}
				}
			}
		}

		/** バイナリロード。

			a_full_path_with_extention		: 絶対バス。拡張子付き。
			a_buffer						: ロード先バッファ。

			return							: 読み込んだサイズ。
			return == -1					: 読み込み失敗。

		*/
		public static long TryLoadBinaryToBufferFromFullPath(string a_full_path_with_extention,byte[] a_buffer)
		{
			#pragma warning disable 0168
			try{
				return LoadBinaryToBufferFromFullPath(a_full_path_with_extention,a_buffer);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return -1;
		}

		/** バイナリロード。

			a_full_path_with_extention		: 絶対バス。拡張子付き。

		*/
		public static byte[] TryLoadBinaryFromFullPath(string a_full_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return LoadBinaryFromFullPath(a_full_path_with_extention);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return null;
		}

		/** バイナリロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			a_buffer						: ロード先バッファ。

			return							: 読み込んだサイズ。
			return == -1					: 読み込み失敗。

		*/
		public static long TryLoadBinaryToBufferFromAssetsPath(string a_assets_path_with_extention,byte[] a_buffer)
		{
			#pragma warning disable 0168
			try{
				return LoadBinaryToBufferFromAssetsPath(a_assets_path_with_extention,a_buffer);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return -1;
		}

		/** バイナリロード。

			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。

		*/
		public static byte[] TryLoadBinaryFromAssetsPath(string a_assets_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return LoadBinaryFromAssetsPath(a_assets_path_with_extention);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return null;
		}

		/** バイナリロード。

			a_url	: ファイルのＵＲＬ。
			a_post	: POSTデータ。

		*/
		public static byte[] TryLoadBinaryFromUrl(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post)
		{
			#pragma warning disable 0168
			try{
				return LoadBinaryFromUrl(a_url,a_post);
			}catch(System.IO.IOException t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return null;
		}
	}
}
#endif

