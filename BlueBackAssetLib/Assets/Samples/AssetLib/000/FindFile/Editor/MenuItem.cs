

/** Samples.AssetLib.FindFile.Editor
*/
namespace Samples.AssetLib.FindFile.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** FindFileWithAssetsPath
		*/
		[UnityEditor.MenuItem("�T���v��/AssetLib/FindFile/FindFileWithAssetsPath")]
		private static void MenuItem_FindFileWithAssetsPath()
		{
			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.Editor.FindFileWithAssetsPath.FindAll("",".*","^MenuItem\\.cs$");
			foreach(string t_item in t_list){
				UnityEngine.Debug.Log(t_item);
			}
		}
	}
	#endif
}

