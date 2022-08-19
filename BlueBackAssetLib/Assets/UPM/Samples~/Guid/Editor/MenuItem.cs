

/** BlueBack.AssetLib.Samples.Guid.Editor
*/
namespace BlueBack.AssetLib.Samples.Guid.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public static class MenuItem
	{
		/** LoadGuidWithAssetsPath
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Guid/LoadGuidWithAssetsPath")]
		private static void MenuItem_LoadGuidWithAssetsPath()
		{
			UnityEngine.Debug.Log(BlueBack.AssetLib.Editor.LoadGuidWithAssetsPath.Load("Samples.meta"));
		}

		/** CreateGuidList
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Guid/CreateGuidList")]
		private static void MenuItem_CreateGuidList()
		{
			{
				System.Collections.Generic.List<BlueBack.AssetLib.PathResult<string>> t_guid_list = BlueBack.AssetLib.Editor.CreateGuidListWithAssetsPath.Create(".*","^.*\\.asmdef$");
				foreach(PathResult<string> t_pair in t_guid_list){
					UnityEngine.Debug.Log(string.Format("guid = {0} : path = {1}",t_pair.value,t_pair.path));
				}
			}

			{
				System.Collections.Generic.List<BlueBack.AssetLib.PathResult<string>> t_guid_list = BlueBack.AssetLib.Editor.CreateGuidListWithPackagesPath.Create(".*","^.*\\.asmdef$");
				foreach(PathResult<string> t_pair in t_guid_list){
					UnityEngine.Debug.Log(string.Format("guid = {0} : path = {1}",t_pair.value,t_pair.path));
				}
			}
		}
	}
	#endif
}

