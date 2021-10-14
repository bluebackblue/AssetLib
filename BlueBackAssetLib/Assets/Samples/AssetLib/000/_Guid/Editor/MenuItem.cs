

/** Samples.AssetLib.Guid.Editor
*/
namespace Samples.AssetLib.Guid.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR) && false
	public class MenuItem
	{
		/** パッケージ作成。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Guid/LoadGuidWithMetaString")]
		private static void MenuItem_Sample_AssetLib_Guid_LoadGuidWithMetaString()
		{
			string t_string = "fileFormatVersion: xx\r\nguid: 0123456789abcdef\r\nMonoImporter:";
			string t_guid = BlueBack.AssetLib.Editor.LoadGuidWithMetaString.Load(t_string);
			UnityEngine.Debug.Log(t_guid);
		}

		/** パッケージ作成。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Guid/LoadGuidWithAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Guid_LoadGuidWithAssetsPath()
		{
			string t_guid = BlueBack.AssetLib.Editor.LoadGuidWithAssetsPath.Load("Samples.meta",System.Text.Encoding.UTF8);
			UnityEngine.Debug.Log(t_guid);
		}
	}
	#endif
}

