

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief プレハブセーブ。アセットパス。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** SavePrefabWithAssetsPath
	*/
	public static class SavePrefabWithAssetsPath
	{
		/** セーブ

			a_gameobject_instance			: ゲームオブジェクト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			return							: プレハブ。

		*/
		public static UnityEngine.GameObject Save(UnityEngine.GameObject a_gameobject_instance,string a_assets_path_with_extention)
		{
			return UnityEditor.PrefabUtility.SaveAsPrefabAsset(a_gameobject_instance,"Assets\\" + a_assets_path_with_extention);
		}

		/** セーブ。

			a_gameobject_instance			: ゲームオブジェクト。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			return.value					: プレハブ。
			return.result == true			: 成功。

		*/
		public static MultiResult<bool,UnityEngine.GameObject> TrySave(UnityEngine.GameObject a_gameobject_instance,string a_assets_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,UnityEngine.GameObject>(true,Save(a_gameobject_instance,a_assets_path_with_extention));
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,UnityEngine.GameObject>(false,null);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,UnityEngine.GameObject>(false,null);
			}
			#pragma warning restore
		}

		/** セーブ。別名保存。

			a_prefab						: プレハブ。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			return							: プレハブ。

		*/
		public static UnityEngine.GameObject SaveAs(UnityEngine.GameObject a_prefab,string a_assets_path_with_extention)
		{
			UnityEngine.GameObject t_gameobject = UnityEngine.GameObject.Instantiate(a_prefab);
			UnityEngine.GameObject t_prefab = Save(t_gameobject,a_assets_path_with_extention);
			UnityEngine.GameObject.DestroyImmediate(t_gameobject);
			return t_prefab;
		}

		/** セーブ。別名保存。

			a_gameobject_instance			: プレハブ。
			a_assets_path_with_extention	: 「Assets」からの相対バス。拡張子付き。
			return.value					: プレハブ。
			return.result == true			: 成功。

		*/
		public static MultiResult<bool,UnityEngine.GameObject> TrySaveAs(UnityEngine.GameObject a_prefab,string a_assets_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				return new MultiResult<bool,UnityEngine.GameObject>(true,SaveAs(a_prefab,a_assets_path_with_extention));
			}catch(System.IO.IOException t_exception){
				//ＩＯエラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,UnityEngine.GameObject>(false,null);
			}catch(System.Exception t_exception){
				//エラー。
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0}",t_exception));
				#endif
				return new MultiResult<bool,UnityEngine.GameObject>(false,null);
			}
			#pragma warning restore
		}
	}
}
#endif

