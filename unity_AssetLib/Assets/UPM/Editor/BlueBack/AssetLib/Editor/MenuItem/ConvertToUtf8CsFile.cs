

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ファイル名リスト。
*/


/** BlueBack.AssetLib.Editor.MenuItem
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor.MenuItem
{
	/** ConvertToUtf8CsFile
	*/
	public class ConvertToUtf8CsFile
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
				string t_text = LoadText.LoadTextFromAssetsPath(t_list[ii]);

				t_text = t_text.Replace("\r\n","\n");
				t_text = t_text.Replace("\r","");

				t_text = t_text.Replace("\n","\r\n");
				SaveText.SaveUtf8TextToAssetsPath(t_text,t_path,false,LineFeedOption.CRLF);
			}

			RefreshAsset.Refresh();
		}
	}
}
#endif

