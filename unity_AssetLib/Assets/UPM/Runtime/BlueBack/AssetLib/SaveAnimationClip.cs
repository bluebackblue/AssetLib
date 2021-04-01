

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief アニメーションクリップセーブ。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** SaveAnimationClip
	*/
	public class SaveAnimationClip
	{
		/** アニメーションクリップセーブ。

			a_animation_clip					: アニメーションクリップ。
			a_assets_path_with_extention		: 「Assets」からの相対バス。
			a_name							: 名前。

		*/
		#if(UNITY_EDITOR)
		public static void SaveAsAnimationClipToAssetsPath(UnityEngine.AnimationClip a_animation_clip,string a_assets_path_with_extention,string a_name)
		{
			UnityEngine.AnimationClip t_new_animationclip = UnityEngine.Object.Instantiate<UnityEngine.AnimationClip>(a_animation_clip);
			t_new_animationclip.name = a_name;
			UnityEditor.AssetDatabase.CreateAsset(t_new_animationclip,"Assets/" + a_assets_path_with_extention);
		}
		#endif
	}
}

