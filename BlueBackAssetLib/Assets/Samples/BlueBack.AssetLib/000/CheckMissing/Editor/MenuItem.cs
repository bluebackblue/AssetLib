

/** BlueBack.AssetLib.Samples.CheckMissing.Editor
*/
namespace BlueBack.AssetLib.Samples.CheckMissing.Editor
{
	/** using
	*/
	using PathType = System.String;

	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public static class MenuItem
	{
		/** ExistDirectoryWithAssetsPath
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/CheckMissing/CheckAll")]
		private static void MenuItem_ExistDirectoryWithAssetsPath()
		{
			System.Collections.Generic.List<BlueBack.AssetLib.PathResult<string>> t_list = BlueBack.AssetLib.Editor.CheckMissing.CheckAll();
			for(int ii=0;ii<t_list.Count;ii++){
				UnityEngine.Debug.Log(string.Format("path = {0} : propertypath = {1}",t_list[ii].path,t_list[ii].value));
			}
		}
	}
	#endif
}

