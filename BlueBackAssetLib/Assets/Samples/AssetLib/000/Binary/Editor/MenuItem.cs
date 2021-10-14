

/** Samples.AssetLib.Binary.Editor
*/
namespace Samples.AssetLib.Binary.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** CreateAssetBundleWithAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Binary/CreateAssetBundleWithAssetsPath")]
		private static void MenuItem_CreateAssetBundleWithAssetsPath()
		{
			//事前処理。
			{
				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out");
				BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveUtf8("text","Out/text.txt",false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			byte[] t_binary = BlueBack.AssetLib.Editor.LoadBinaryWithAssetsPath.Load("Out/text.txt");
			UnityEngine.Debug.Log(t_binary.Length.ToString());
		}
	}
	#endif
}

