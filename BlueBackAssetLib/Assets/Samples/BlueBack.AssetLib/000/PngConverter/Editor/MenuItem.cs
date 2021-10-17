

/** Samples.AssetLib.PngConverter
*/
namespace Samples.AssetLib.PngConverter
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** SaveBinaryWithAssetsPath
		*/
		[UnityEditor.MenuItem("サンプル/BlueBack.AssetLib/PngConverter/SaveBinaryWithAssetsPath")]
		private static void MenuItem_xxxxx()
		{
			//texture
			UnityEngine.Texture2D t_texture;
			{
				t_texture = new UnityEngine.Texture2D(32,32);
				for(int xx=0;xx<32;xx++){
					for(int yy=0;yy<32;yy++){
						t_texture.SetPixel(xx,yy,new UnityEngine.Color((float)xx/32,(float)yy/32,0.0f,1.0f));
					}
				}
				t_texture.Apply();
			}

			//SaveAssetWithAssetsPath
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Out");
			BlueBack.AssetLib.Editor.SaveAssetWithAssetsPath.SaveConverter(t_texture,new BlueBack.AssetLib.PngConverterAssetToBinary(),"Out/test.png");
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
	}
	#endif
}

