

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ディレクトリ名リスト。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** PackageList
	*/
	public static class PackageList
	{
		/** 直下のディレクトリ名を列挙。

			a_offlinemode					: オフラインモード
			a_includeindirectdependencies	: 間接的機な依存関係も含める。

		*/
		#pragma warning disable 0162
		public static System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> CreatePackageList(bool a_offlinemode,bool a_includeindirectdependencies)
		{
			UnityEditor.PackageManager.Requests.ListRequest t_request = UnityEditor.PackageManager.Client.List(a_offlinemode,a_includeindirectdependencies);
			while(true){
				System.Threading.Thread.Sleep(1);
				if(t_request.Status != UnityEditor.PackageManager.StatusCode.InProgress){
					switch(t_request.Status){
					case UnityEditor.PackageManager.StatusCode.InProgress:
						{
						}break;
					case UnityEditor.PackageManager.StatusCode.Failure:
						{
							#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
							DebugTool.Assert(false,t_request.Error.message);
							#endif
							return null;
						}break;
					case UnityEditor.PackageManager.StatusCode.Success:
						{
							System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> t_list = new System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo>();
							foreach(UnityEditor.PackageManager.PackageInfo t_item in t_request.Result){
								t_list.Add(t_item);
							}
							return t_list;
						}break;;
					default:
						{
							#if(DEF_BLUEBACK_ASSETLIB_ASSERT)
							DebugTool.Assert(false,"error");
							#endif
							return null;
						}break;
					}
				}
			}
		}
		#pragma warning restore
	}
}
#endif

