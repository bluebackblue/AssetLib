

/** Samples.Guid
*/
namespace Samples.Guid
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** LoadGuidWithAssetsPath
		*/
		[UnityEditor.MenuItem("�T���v��/AssetLib/Guid/LoadGuidWithAssetsPath")]
		private static void MenuItem_LoadGuidWithAssetsPath()
		{
			UnityEngine.Debug.Log(BlueBack.AssetLib.Editor.LoadGuidWithAssetsPath.Load("Samples.meta"));
		}
	}
	#endif
}

