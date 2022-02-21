/**
	Copyright (c) blueback
	Released under the MIT License
	@brief バイナリロード。ＵＲＬ。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** LoadBinaryWithUrl
	*/
	public static class LoadBinaryWithUrl
	{
		/** ロード。

			a_url							: URL
			a_post == null					: GET
			return							: バイナリ。

		*/
		public static byte[] Load(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post)
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

		/** ロード。

			a_url							: URL
			a_post == null					: GET
			return							: バイナリ。

		*/
		public static MultiResult<bool,byte[]> TryLoad(string a_url,System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a_post)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,byte[]>(true,Load(a_url,a_post));
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
				return new MultiResult<bool,byte[]>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

