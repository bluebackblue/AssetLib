

/** Samples.AssetLib.Sample
*/
namespace Samples.AssetLib.Sample
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		[UnityEditor.MenuItem("サンプル/AssetLibSample/Reflash")]
		private static void MenuItem_AssetLibSample_Reflash()
		{
			BlueBack.AssetLib.RefreshAsset.Refresh();
		}
	}
	#endif
}

