

/** BlueBack.AssetLib.Samples.Package.Editor
*/
namespace BlueBack.AssetLib.Samples.Package.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public static class MenuItem
	{
		/** CreatePackageInfoList
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Package/CreatePackageInfoList")]
		private static void MenuItem_CreatePackageInfoList()
		{
			{
				System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> t_list = BlueBack.AssetLib.Editor.CreatePackageInfoList.Create(true,true);
				UnityEngine.Debug.Log(string.Format("offlinemode = {0} : include_indirect_dependencies{1} : length = {2}",true,true,t_list.Count));
				for(int ii=0;ii<t_list.Count;ii++){
					UnityEngine.Debug.Log(string.Format("{0}\n{1}\n{2}\n{3}",t_list[ii].name,t_list[ii].assetPath,t_list[ii].resolvedPath,t_list[ii].datePublished.ToString()));
				}
			}

			{
				System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> t_list = BlueBack.AssetLib.Editor.CreatePackageInfoList.Create(false,false);
				UnityEngine.Debug.Log(string.Format("offlinemode = {0} : include_indirect_dependencies{1} : length = {2}",false,false,t_list.Count));
				for(int ii=0;ii<t_list.Count;ii++){
					UnityEngine.Debug.Log(string.Format("{0}\n{1}\n{2}\n{3}",t_list[ii].name,t_list[ii].assetPath,t_list[ii].resolvedPath,t_list[ii].datePublished.ToString()));
				}
			}
		}
	}
	#endif
}

