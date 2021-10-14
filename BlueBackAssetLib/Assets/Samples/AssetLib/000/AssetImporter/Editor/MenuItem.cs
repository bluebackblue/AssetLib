

/** Samples.AssetLib.AssetImporter.Editor
*/
namespace Samples.AssetLib.AssetImporter.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** CreateDirectoryWithAssetsPath
		*/
		[UnityEditor.MenuItem("�T���v��/AssetLib/AssetImporter/CreateDirectoryWithAssetsPath")]
		private static void MenuItem_CreateAssetBundleWithAssetsPath()
		{
			//���O�����B
			{
				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out");
				BlueBack.AssetLib.Editor.SaveTexture.SaveAsPngTexture2DToAssetsPath(UnityEngine.Texture2D.whiteTexture,"Out/texture.png");
			}

			UnityEditor.TextureImporter t_textureimporter = BlueBack.AssetLib.Editor.GetAssetImporterWithAssetsPath.Get<UnityEditor.TextureImporter>("Out/texture.png");
			UnityEngine.Debug.Log(t_textureimporter.filterMode.ToString());
		}
	}
	#endif
}

