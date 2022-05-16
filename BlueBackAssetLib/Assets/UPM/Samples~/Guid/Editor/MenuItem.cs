

/** BlueBack.AssetLib.Samples.Guid.Editor
*/
namespace BlueBack.AssetLib.Samples.Guid.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** LoadGuidWithAssetsPath
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.AssetLib/Guid/LoadGuidWithAssetsPath")]
		private static void MenuItem_LoadGuidWithAssetsPath()
		{
			UnityEngine.Debug.Log(BlueBack.AssetLib.Editor.LoadGuidWithAssetsPath.Load("Samples.meta"));
		}
	}
	#endif
}

