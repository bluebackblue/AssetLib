

/** Samples.AssetLib.Path.Editor
*/
namespace Samples.AssetLib.Path.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR) && false
	public class MenuItem
	{
		/** ディレクトリ作成。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/CreateDirectoryWithAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Path_CreateDirectoryWithAssetsPath()
		{
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Samples/BlueBack.AssetLib/NewDirectory/xxx");
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}

		/** ディレクトリ削除。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/DeleteDirectoryWithAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Path_DeleteDirectoryWithAssetsPath()
		{
			BlueBack.AssetLib.Editor.DeleteDirectoryWithAssetsPath.Delete("Samples/BlueBack.AssetLib/NewDirectory");
			BlueBack.AssetLib.Editor.DeleteFileWithAssetsPath.Delete("Samples/BlueBack.AssetLib/NewDirectory.meta");
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}

		/** ディレクトリ名を列挙。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/CreateDirectoryNameListWithAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Path_CreateDirectoryNameListWithAssetsPath()
		{
			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.Editor.CreateDirectoryNameListWithAssetsPath.CreateAll("");
			for(int ii=0;ii<t_list.Count;ii++){
				UnityEngine.Debug.Log(t_list[ii]);
			}
		}

		/** ファイル名を列挙。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/CreateFileNameListWithAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Path_CreateFileNameListWithAssetsPath()
		{
			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.Editor.CreateFileNameListWithAssetsPath.CreateAll("");
			for(int ii=0;ii<t_list.Count;ii++){
				UnityEngine.Debug.Log(t_list[ii]);
			}
		}

		/** ファイル存在チェック。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/ExistFileWithAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Path_ExistFileWithAssetsPath()
		{
			{
				bool t_isexist = BlueBack.AssetLib.Editor.ExistFileWithAssetsPath.Check("Samples.meta");
				UnityEngine.Debug.Log("Samples.meta : " + t_isexist.ToString());
			}

			{
				bool t_isexist = BlueBack.AssetLib.Editor.ExistFileWithAssetsPath.Check("xxxx.xxx");
				UnityEngine.Debug.Log("xxxx.xxx : " + t_isexist.ToString());
			}
		}

		/** ファイル検索。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/FindFileWithAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Path_FindFileWithAssetsPath()
		{
			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.Editor.FindFileWithAssetsPath.FindAll("",".*Lib.*","^MenuItem\\.cs$");
			for(int ii=0;ii<t_list.Count;ii++){
				UnityEngine.Debug.Log(t_list[ii]);
			}
		}
	}
	#endif
}

