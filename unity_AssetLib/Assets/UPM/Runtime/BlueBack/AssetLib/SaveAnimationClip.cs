

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アニメーションクリップのセーブ。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** SaveAnimationClip
	*/
	#if(UNITY_EDITOR)
	public class SaveAnimationClip
	{
		/** SaveAnimationClipToAssetsPath

			a_animation_clip	: アニメーションクリップ。
			a_assets_path		: 「Assets」からの相対バス。

		*/
		public static void SaveAnimationClipToAssetsPath(UnityEngine.AnimationClip a_animation_clip,string a_assets_path)
		{
			UnityEngine.AnimationClip t_new_animationclip = UnityEngine.Object.Instantiate<UnityEngine.AnimationClip>(a_animation_clip);
			UnityEditor.AssetDatabase.CreateAsset(t_new_animationclip,"Assets/" + a_assets_path);
		}
	}
	#endif
}

