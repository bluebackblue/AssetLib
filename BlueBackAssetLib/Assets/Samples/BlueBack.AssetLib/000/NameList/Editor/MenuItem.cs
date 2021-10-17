

/** Samples.NameList
*/
namespace Samples.NameList
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** CreateFileNameListWithAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/NameList/CreateFileNameListWithAssetsPath")]
		private static void MenuItem_CreateFileNameListWithAssetsPath()
		{
			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.Editor.CreateFileNameListWithAssetsPath.CreateAll("");
			foreach(string t_item in t_list){
				UnityEngine.Debug.Log(t_item);
			}
		}

		/** CreateDirectoryNameListWithAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/NameList/CreateDirectoryNameListWithAssetsPath")]
		private static void MenuItem_CreateDirectoryNameListWithAssetsPath()
		{
			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.Editor.CreateDirectoryNameListWithAssetsPath.CreateAll("");
			foreach(string t_item in t_list){
				UnityEngine.Debug.Log(t_item);
			}
		}
	}
	#endif
}

