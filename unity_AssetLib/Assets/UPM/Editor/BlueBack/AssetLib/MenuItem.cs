

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ファイル名リスト。
*/


/** BlueBack.AssetLib.Editor
*/
namespace BlueBack.AssetLib.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** UTF8のCSファイルにコンバートする。

			ドット始まり、チルダ終わりも含む。

		*/
		[UnityEditor.MenuItem("BlueBack/AssetLib/ConvertToUtf8CsFile")]
		private static void MenuItem_ConvertToUtf8CsFile()
		{
			System.Collections.Generic.List<string> t_list = FindFile.FindFileListFromAssetsPath("",".*","^.*\\.cs$");
			for(int ii=0;ii<t_list.Count;ii++){
				UnityEngine.Debug.Log(t_list[ii]);
				string t_path = t_list[ii];
				string t_body = LoadText.LoadTextFromAssetsPath(t_list[ii]);
				SaveText.SaveUtf8TextToAssetsPath(t_body,t_path,false);
			}

			RefreshAsset.Refresh();
		}
	}
	#endif
}

