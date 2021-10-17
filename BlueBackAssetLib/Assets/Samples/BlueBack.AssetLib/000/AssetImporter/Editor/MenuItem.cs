

/** Samples.AssetImporter
*/
namespace Samples.AssetImporter
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** GetAssetImporterWithAssetsPath
		*/
		[UnityEditor.MenuItem("�T���v��/AssetLib/AssetImporter/GetAssetImporterWithAssetsPath")]
		private static void MenuItem_GetAssetImporterWithAssetsPath()
		{
			//���O�����B
			{
				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out");
				BlueBack.AssetLib.Editor.SaveAssetWithAssetsPath.SaveConverter(UnityEngine.Texture2D.whiteTexture,new BlueBack.AssetLib.PngConverterAssetToBinary(),"Out/test.png");
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}

			//GetAssetImporterWithAssetsPath
			{
				UnityEditor.TextureImporter t_textureimporter = BlueBack.AssetLib.Editor.GetAssetImporterWithAssetsPath.Get<UnityEditor.TextureImporter>("Out/test.png");
				UnityEngine.Debug.Log(t_textureimporter.filterMode.ToString());
			}
		}
	}
	#endif
}

