

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ミッシングチェック。
*/


/** BlueBack.AssetLib.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.AssetLib.Editor
{
	/** CheckMissing
	*/
	public static class CheckMissing
	{
		/** CheckSerializedObject

			a_result : 結果

		*/
		public static void CheckSerializedObject(UnityEditor.SerializedObject a_serializedobject,string a_path,System.Collections.Generic.List<PathResult<string>> a_result)
		{
			UnityEditor.SerializedProperty t_serializedproperty = a_serializedobject.GetIterator();

			do{
				switch(t_serializedproperty.propertyType){
				case UnityEditor.SerializedPropertyType.ObjectReference:
					{
						UnityEngine.Object t_object = t_serializedproperty.objectReferenceValue;
						if(t_object == null){
							if(t_serializedproperty.hasChildren == true){
								UnityEditor.SerializedProperty t_fileid = t_serializedproperty.FindPropertyRelative("m_FileID");
								if(t_fileid != null){
									if(t_fileid.intValue != 0){
										a_result.Add(new PathResult<string>(a_path,t_serializedproperty.propertyPath));
									}
								}
							}
						}						
					}break;
				}
			}while(t_serializedproperty.Next(true));
		}

		/** CheckGameObject
		*/
		private static void CheckGameObject(UnityEngine.GameObject a_gameobject,string a_path,System.Collections.Generic.List<PathResult<string>> a_result)
		{
			//gameobject
			{
				BlueBack.AssetLib.Editor.CheckMissing.CheckSerializedObject(new UnityEditor.SerializedObject(a_gameobject),a_path,a_result);
			}

			//component
			{
				UnityEngine.Component[] t_component_list = a_gameobject.GetComponentsInChildren(typeof(UnityEngine.MonoBehaviour));
				if(t_component_list != null){
					int ii_max = t_component_list.Length;
					for(int ii=0;ii<ii_max;ii++){
						UnityEngine.Component t_component = t_component_list[ii];
						if(t_component != null){
							BlueBack.AssetLib.Editor.CheckMissing.CheckSerializedObject(new UnityEditor.SerializedObject(t_component),a_path,a_result);
						}
					}
				}
			}
		}

		/** CheckScene
		*/
		private static void CheckScene(UnityEngine.SceneManagement.Scene a_scene,string a_path,System.Collections.Generic.List<PathResult<string>> a_result)
		{
			try{
				UnityEngine.GameObject[] t_gameobject_list = a_scene.GetRootGameObjects();
				if(t_gameobject_list != null){
					int ii_max = t_gameobject_list.Length;
					for(int ii=0;ii<ii_max;ii++){
						CheckGameObject(t_gameobject_list[ii],a_path,a_result);
					}
				}
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_DEBUG_LOG)
				DebugTool.Log(string.Format("exception : {0} : path : {1}",t_exception,a_path));
				#endif
			}
		}

		/** CheckAll
		*/
		public static System.Collections.Generic.List<PathResult<string>> CheckAll()
		{
			System.Collections.Generic.List<PathResult<string>> t_result = new System.Collections.Generic.List<PathResult<string>>();

			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.Editor.CreateFileNameListWithAssetsPath.CreateAll("");
			int ii_max = t_list.Count;
			for(int ii=0;ii<ii_max;ii++){
				string t_path = t_list[ii];
				string t_extension = System.IO.Path.GetExtension(t_path);
				switch(t_extension){
				case ".meta":
					{
					}break;
				case ".unity":
					{
						BlueBack.AssetLib.MultiResult<bool,UnityEngine.SceneManagement.Scene> t_scene = BlueBack.AssetLib.Editor.OpenSceneFromAssetsPath.TryOpen(t_path,UnityEditor.SceneManagement.OpenSceneMode.Single);
						if(t_scene.result == true){
							CheckScene(t_scene.value,t_path,t_result);
						}
					}break;
				case ".prefab":
					{
						UnityEngine.GameObject t_gameobject = BlueBack.AssetLib.Editor.LoadAssetWithAssetsPath.Load<UnityEngine.GameObject>(t_path);
						if(t_gameobject != null){
							CheckGameObject(t_gameobject,t_path,t_result);
						}
					}break;
				default:
					{
						UnityEngine.Object t_object = BlueBack.AssetLib.Editor.LoadAssetWithAssetsPath.Load<UnityEngine.Object>(t_path);
						if(t_object != null){
							BlueBack.AssetLib.Editor.CheckMissing.CheckSerializedObject(new UnityEditor.SerializedObject(t_object),t_path,t_result);
						}
					}break;
				}
			}

			return t_result;
		}
	}
}
#endif

