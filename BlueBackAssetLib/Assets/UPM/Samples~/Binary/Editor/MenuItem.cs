

/** Samples.AssetLib.Binary
*/
namespace Samples.AssetLib.Binary
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** LoadBinaryWithAssetsPath
		*/
		[UnityEditor.MenuItem("�T���v��/BlueBack.AssetLib/Binary/LoadBinaryWithAssetsPath")]
		private static void MenuItem_LoadBinaryWithAssetsPath()
		{
			//���O�����B
			{
				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out");
				BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8("text","Out/text.txt",BlueBack.AssetLib.LineFeedOption.CRLF);
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}

			//LoadBinaryWithAssetsPath
			{
				byte[] t_binary = BlueBack.AssetLib.Editor.LoadBinaryWithAssetsPath.Load("Out/text.txt");
				UnityEngine.Debug.Log(t_binary.Length.ToString());
			}
		}
	}
	#endif
}

