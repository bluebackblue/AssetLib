

/** BlueBack.AssetLib.Samples.Initialize.Editor
*/
namespace BlueBack.AssetLib.Samples.Initialize.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public static class MenuItem
	{
		/** LoadGuidWithAssetsPath
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Initialize/Initialize")]
		private static void MenuItem_Initialize()
		{
			BlueBack.AssetLib.AssetLib.Initialize();
		}
	}
	#endif
}

