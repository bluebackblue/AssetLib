

/** Samples.AssetLib.Path.Editor
*/
namespace Samples.AssetLib.Path.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** ディレクトリ作成。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/CreateDirectoryToAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Path_CreateDirectoryToAssetsPath()
		{
			BlueBack.AssetLib.CreateDirectory.CreateDirectoryToAssetsPath("Samples/AssetLib/NewDirectory/xxx");
			BlueBack.AssetLib.RefreshAsset.Refresh();
		}

		/** ディレクトリ削除。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/DeleteDirectoryFromAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Path_DeleteDirectoryFromAssetsPath()
		{
			BlueBack.AssetLib.DeleteDirectory.DeleteDirectoryFromAssetsPath("Samples/AssetLib/NewDirectory");
			BlueBack.AssetLib.DeleteFile.DeleteFileFromAssetsPath("Samples/AssetLib/NewDirectory.meta");
			BlueBack.AssetLib.RefreshAsset.Refresh();
		}

		/** ディレクトリ名を列挙。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/CreateAllDirectoryNameListFromAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Path_CreateAllDirectoryNameListFromAssetsPath()
		{
			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.DorectoryNameList.CreateAllDirectoryNameListFromAssetsPath("");
			for(int ii=0;ii<t_list.Count;ii++){
				UnityEngine.Debug.Log(t_list[ii]);
			}
		}

		/** ファイル名を列挙。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/CreateAllFileNameListFromAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Path_CreateAllFileNameListFromAssetsPath()
		{
			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.FileNameList.CreateAllFileNameListFromAssetsPath("");
			for(int ii=0;ii<t_list.Count;ii++){
				UnityEngine.Debug.Log(t_list[ii]);
			}
		}

		/** ファイル存在チェック。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/ExistFile")]
		private static void MenuItem_Sample_AssetLib_Path_ExistFile()
		{
			{
				bool t_isexist = BlueBack.AssetLib.ExistFile.IsExistFileFromAssetsPath("Editor.meta");
				UnityEngine.Debug.Log("Editor.meta : " + t_isexist.ToString());
			}

			{
				bool t_isexist = BlueBack.AssetLib.ExistFile.IsExistFileFromAssetsPath("xxxx.xxx");
				UnityEngine.Debug.Log("xxxx.xxx : " + t_isexist.ToString());
			}
		}

		/** ファイル検索。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Path/FindFile")]
		private static void MenuItem_Sample_AssetLib_Path_FindFile()
		{
			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.FindFile.FindFileListFromAssetsPath("",".*Create.*","^MenuItem\\.cs$");
			for(int ii=0;ii<t_list.Count;ii++){
				UnityEngine.Debug.Log(t_list[ii]);
			}
		}
	}
	#endif
}

