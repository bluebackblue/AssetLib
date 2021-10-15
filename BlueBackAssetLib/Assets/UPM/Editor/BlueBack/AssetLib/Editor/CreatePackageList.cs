

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief パッケージリスト作成。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CreatePackageList
	*/
	public static class CreatePackageList
	{
		/** 作成。

			a_offlinemode					: オフラインモード
			a_includeindirectdependencies	: 間接的機な依存関係も含める。

		*/
		public static System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> Create(bool a_offlinemode,bool a_includeindirectdependencies)
		{
			#pragma warning disable 0162
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
			#pragma warning restore
		}
	}
}
#endif

