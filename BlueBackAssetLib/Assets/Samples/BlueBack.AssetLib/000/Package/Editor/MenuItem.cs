

/** BlueBack.AssetLib.Samples.Package.Editor
*/
namespace BlueBack.AssetLib.Samples.Package.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public static class MenuItem
	{
		/** ListUp
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Package/ListUp")]
		private static void MenuItem_ListUp()
		{
			System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> t_list = BlueBack.AssetLib.Editor.CreatePackageList.Create(true,true);
			for(int ii=0;ii<t_list.Count;ii++){
				UnityEngine.Debug.Log(string.Format("{0}\n{1}\n{2}\n{3}",t_list[ii].name,t_list[ii].assetPath,t_list[ii].resolvedPath,t_list[ii].datePublished.ToString()));
			}
		}
	}
	#endif
}

