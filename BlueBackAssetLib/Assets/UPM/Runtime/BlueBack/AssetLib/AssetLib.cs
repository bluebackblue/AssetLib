

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief AssetLib。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** AssetLib
	*/
	public static class AssetLib
	{
		/** application_streamingassets_path
		*/
		public static string application_streamingassets_path = null;

		/** application_data_path
		*/
		public static string application_data_path = null;

		/** AssetLib
		*/
		static AssetLib()
		{
			Initialize();
		}

		/** 明示的に初期化する。
		*/
		public static void Initialize()
		{
			#if(DEF_BLUEBACK_DEBUG_LOG)
			DebugTool.Log(string.Format("AssetLib.Initialize : CurrentThread(GetApartmentState = {0} , ManagedThreadId = {1} , IsBackground = {2} , IsThreadPoolThread = {3})",
				System.Threading.Thread.CurrentThread.GetApartmentState(),
				System.Threading.Thread.CurrentThread.ManagedThreadId,
				System.Threading.Thread.CurrentThread.IsBackground,
				System.Threading.Thread.CurrentThread.IsThreadPoolThread
			));
			#endif

			//application_streamingassets_path
			if(AssetLib.application_streamingassets_path == null){
				AssetLib.application_streamingassets_path = NormalizePath.NormalizeSeparateAndLast(UnityEngine.Application.streamingAssetsPath);
			}
			#if(DEF_BLUEBACK_DEBUG_LOG)
			DebugTool.Log(string.Format("AssetLib.application_streamingassets_path = {0}",AssetLib.application_streamingassets_path));
			#endif

			//application_data_path
			if(AssetLib.application_data_path == null){
				AssetLib.application_data_path = NormalizePath.NormalizeSeparateAndLast(UnityEngine.Application.dataPath);
			}
			#if(DEF_BLUEBACK_DEBUG_LOG)
			DebugTool.Log(string.Format("AssetLib.application_data_path = {0}",AssetLib.application_data_path));
			#endif
		}
	}
}

