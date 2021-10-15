

/** Samples.AssetLib.AssetImporter.Editor
*/
namespace Samples.AssetLib.AssetImporter.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** GetAssetImporterWithAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/AssetImporter/GetAssetImporterWithAssetsPath")]
		private static void MenuItem_GetAssetImporterWithAssetsPath()
		{
			//事前処理。
			{
				BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out");
				byte[] t_binary = BlueBack.AssetLib.Editor.PngConverter.TextureToBinary(UnityEngine.Texture2D.whiteTexture);
				BlueBack.AssetLib.Editor.SaveBinaryWithAssetsPath.Save(t_binary,"Out/texture.png");
				BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
			}

			//GetAssetImporterWithAssetsPath
			{
				UnityEditor.TextureImporter t_textureimporter = BlueBack.AssetLib.Editor.GetAssetImporterWithAssetsPath.Get<UnityEditor.TextureImporter>("Out/texture.png");
				UnityEngine.Debug.Log(t_textureimporter.filterMode.ToString());
			}
		}
	}
	#endif
}

