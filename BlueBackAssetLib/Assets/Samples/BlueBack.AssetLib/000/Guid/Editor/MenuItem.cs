

/** Samples.AssetLib.Guid
*/
namespace Samples.AssetLib.Guid
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** LoadGuidWithAssetsPath
		*/
		[UnityEditor.MenuItem("ƒTƒ“ƒvƒ‹/BlueBack.AssetLib/Guid/LoadGuidWithAssetsPath")]
		private static void MenuItem_LoadGuidWithAssetsPath()
		{
			UnityEngine.Debug.Log(BlueBack.AssetLib.Editor.LoadGuidWithAssetsPath.Load("Samples.meta"));
		}
	}
	#endif
}

