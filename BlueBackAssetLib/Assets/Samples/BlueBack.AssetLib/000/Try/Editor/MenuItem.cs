

/** BlueBack.AssetLib.Samples.Try.Editor
*/
namespace BlueBack.AssetLib.Samples.Try.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public static class MenuItem
	{
		/** LoadAssetBundleWithFullPath
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Try/LoadAssetBundleWithFullPath")]
		private static void MenuItem_LoadAssetBundleWithFullPath()
		{
			BlueBack.AssetLib.LoadAssetBundleWithFullPath.TryLoad("xxxxx");
		}

		/** MenuItem_TryLoad
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Try/TryLoadNoBomUtf8")]
		private static void MenuItem_TryLoad()
		{
			BlueBack.AssetLib.Editor.LoadTextWithAssetsPath.TryLoadNoBomUtf8("xxxxxx");
		}
	}
	#endif
}

