

/** Samples.AssetLib.Asset.Editor
*/
namespace Samples.AssetLib.Asset.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** パッケージリスト。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Package/ListUpPackageAsmdefGuid")]
		private static void MenuItem_ListUpAsmdefGuid()
		{
			System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> t_packagelist = BlueBack.AssetLib.Editor.PackageList.CreatePackageList(false,false);
			foreach(UnityEditor.PackageManager.PackageInfo t_packageinfo in t_packagelist){
				System.Collections.Generic.List<string> t_filenamelist = BlueBack.AssetLib.Editor.FindFile.FindFileListFromFullPath(t_packageinfo.resolvedPath,".*",".*\\.asmdef$");
				foreach(string t_filename in t_filenamelist){

					string t_asmdef_name;
					{
						BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(BlueBack.JsonItem.Normalize.Convert(BlueBack.AssetLib.Editor.LoadText.LoadTextFromFullPath(t_filename,System.Text.Encoding.UTF8)));
						BlueBack.JsonItem.JsonItem t_jsonitem_name = t_jsonitem.GetItem("name");
						t_asmdef_name = t_jsonitem_name.GetStringData();
					}

					string t_asmdef_guid;
					{
						t_asmdef_guid = System.Text.RegularExpressions.Regex.Replace(BlueBack.AssetLib.Editor.LoadText.LoadTextFromFullPath(t_filename + ".meta",System.Text.Encoding.UTF8),"^(?<before>[\\d\\D\\n]*\nguid\\: )(?<guid>[a-zA-Z0-9]*)(?<after>[\\d\\D\\n]*)$",(System.Text.RegularExpressions.Match a_a_match)=>{
							return a_a_match.Groups["guid"].Value;
						},System.Text.RegularExpressions.RegexOptions.Multiline);
					}

					UnityEngine.Debug.Log(t_asmdef_name + " : " + t_asmdef_guid + " : " + t_filename);
				}
			}
		}

		/** パッケージリスト。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Package/CreatePackageList")]
		private static void MenuItem_CreatePackageList()
		{
			System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> t_packagelist = BlueBack.AssetLib.Editor.PackageList.CreatePackageList(false,true);
			foreach(UnityEditor.PackageManager.PackageInfo t_packageinfo in t_packagelist){
				UnityEngine.Debug.Log(t_packageinfo.name + " : " + t_packageinfo.displayName);
				UnityEngine.Debug.Log(t_packageinfo.name + " : type = " + t_packageinfo.type);
				UnityEngine.Debug.Log(t_packageinfo.name + " : author = " + t_packageinfo.author.name + " : " + t_packageinfo.author.url + " : " + t_packageinfo.author.email);
				UnityEngine.Debug.Log(t_packageinfo.name + " : version = " + t_packageinfo.version);
				UnityEngine.Debug.Log(t_packageinfo.name + " : resolvedPath = " + t_packageinfo.resolvedPath);
				UnityEngine.Debug.Log(t_packageinfo.name + " : assetPath = " + t_packageinfo.assetPath);
				UnityEngine.Debug.Log(t_packageinfo.name + " : source = " + t_packageinfo.source);
				UnityEngine.Debug.Log(t_packageinfo.name + " : packageId = " + t_packageinfo.packageId);
				UnityEngine.Debug.Log(t_packageinfo.name + " : git = " + ((t_packageinfo.git == null) ? ("null") : (t_packageinfo.git.revision + " : " + t_packageinfo.git.hash)));
				UnityEngine.Debug.Log(t_packageinfo.name + " : repository = " + ((t_packageinfo.registry == null) ? ("null") : (t_packageinfo.registry.name + " : " + t_packageinfo.registry.url)));

				{
					string t_dependency_list = "";
					foreach(UnityEditor.PackageManager.DependencyInfo t_dependency in t_packageinfo.resolvedDependencies){
						t_dependency_list += t_dependency.name + " : " + t_dependency.version + " ";
					}
					UnityEngine.Debug.Log(t_packageinfo.name + " : resolvedDependencies = " + t_dependency_list);
				}

				{
					string t_dependency_list = "";
					foreach(UnityEditor.PackageManager.DependencyInfo t_dependency in t_packageinfo.dependencies){
						t_dependency_list += t_dependency.name + " : " + t_dependency.version + " ";
					}
					UnityEngine.Debug.Log(t_packageinfo.name + " : dependencies = " + t_dependency_list);
				}

				{
					string t_keyword_list = "";
					foreach(string t_keyword in t_packageinfo.keywords){
						t_keyword_list += t_keyword + " ";
					}
					UnityEngine.Debug.Log(t_packageinfo.name + " : keywords = " + t_keyword_list);
				}

				{
					string t_version_list = "";
					foreach(string t_version in t_packageinfo.versions.all){
						t_version_list += t_version + " ";
					}
					UnityEngine.Debug.Log(t_packageinfo.name + " : versions = " + t_version_list);
				}

				UnityEngine.Debug.Log(t_packageinfo.name + " : description = " + t_packageinfo.description);
				UnityEngine.Debug.Log(t_packageinfo.name + " : datePublished = " + t_packageinfo.datePublished);
				UnityEngine.Debug.Log(t_packageinfo.name + " : registry = " + ((t_packageinfo.registry == null) ? ("null") : (t_packageinfo.registry.name)));
				UnityEngine.Debug.Log(t_packageinfo.name + " : licensesUrl = " + t_packageinfo.licensesUrl);
				UnityEngine.Debug.Log(t_packageinfo.name + " : changelogUrl = " + t_packageinfo.changelogUrl);
				UnityEngine.Debug.Log(t_packageinfo.name + " : documentationUrl = " + t_packageinfo.documentationUrl);
				UnityEngine.Debug.Log(t_packageinfo.name + " : category = " + t_packageinfo.category);
				UnityEngine.Debug.Log(t_packageinfo.name + " : isDirectDependency = " + t_packageinfo.isDirectDependency);
			}

			UnityEngine.Debug.Log(UnityEditor.Compilation.CompilationPipeline.GetAssemblyDefinitionFilePathFromAssemblyName("BlueBack.Code"));
		}

		/** パッケージからのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadAssetFromPackagesPath")]
		private static void MenuItem_LoadAssetFromPackagesPath()
		{
			UnityEngine.TextAsset t_textasset = BlueBack.AssetLib.Editor.LoadAsset.LoadAssetFromPackagesPath<UnityEngine.TextAsset>("blueback.jsonitem/README.md");
			UnityEngine.Debug.Log(t_textasset);
		}

		/** テキストのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadTextFromAssetsPath")]
		private static void MenuItem_LoadTextFromAssetsPath()
		{
			//テキストの保存。
			{
				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath("xxxBBBxxx\nxxxBBBxxx","Samples/AssetLib/xxx.txt",true,BlueBack.AssetLib.LineFeedOption.LF);
				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}

			string t_text = BlueBack.AssetLib.Editor.LoadText.TryLoadTextFromAssetsPath("Samples/AssetLib/xxx.txt",null);
			UnityEngine.Debug.Log(t_text);
		}

		/** バイナリのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadBinaryFromAssetsPath")]
		private static void MenuItem_LoadBinaryFromAssetsPath()
		{
			//バイナリのセーブ。
			{
				BlueBack.AssetLib.Editor.SaveBinary.SaveBinaryToAssetsPath(new byte[]{0x01,0x02,0x03},"Samples/AssetLib/binary.dat");
				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}

			byte[] t_binary = BlueBack.AssetLib.Editor.LoadBinary.LoadBinaryFromAssetsPath("Samples/AssetLib/binary.dat");
			for(int ii=0;ii<t_binary.Length;ii++){
				UnityEngine.Debug.Log(t_binary[ii].ToString("X2"));
			}
		}

		/** アセットのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadAllAssetsFromAssetsPath")]
		private static void MenuItem_LoadAllAssetsFromAssetsPath()
		{
			//プレハブのセーブ。
			{
				BlueBack.AssetLib.Result<UnityEngine.GameObject> t_prefab = BlueBack.AssetLib.Editor.SavePrefab.CreatePrefabToAssetsPath("Samples/AssetLib/ab.prefab");
				if(t_prefab.value != null){
					t_prefab.value.AddComponent<A_MonoBehaviour>().value = 11;
					t_prefab.value.AddComponent<B_MonoBehaviour>().value = 22;
				}
				BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
			}

			//全部。
			{
				UnityEngine.Object[] t_list = BlueBack.AssetLib.Editor.LoadAsset.LoadAllAssetsFromAssetsPath("Samples/AssetLib/ab.prefab");
				UnityEngine.Debug.Log(t_list.Length.ToString());
				for(int ii=0;ii<t_list.Length;ii++){
					UnityEngine.Debug.Log("LoadAllAssetsFromAssetsPath : " + t_list[ii].GetType().Name);
				}
			}

			//指定型。
			{
				System.Collections.Generic.List<UnityEngine.MonoBehaviour> t_list = BlueBack.AssetLib.Editor.LoadAsset.LoadAllSpecifiedAssetsFromAssetsPath<UnityEngine.MonoBehaviour>("Samples/AssetLib/ab.prefab");
				UnityEngine.Debug.Log(t_list.Count.ToString());
				for(int ii=0;ii<t_list.Count;ii++){
					int  t_value = 0;

					A_MonoBehaviour t_a = t_list[ii] as A_MonoBehaviour;
					if(t_a != null){
						t_value = t_a.value;
					}

					B_MonoBehaviour t_b = t_list[ii] as B_MonoBehaviour;
					if(t_b != null){
						t_value = t_b.value;
					}

					UnityEngine.Debug.Log("LoadAllSpecifiedAssetsFromAssetsPath : " + t_list[ii].GetType().Name + " : value = " + t_value.ToString());
				}
			}
		}

		/** アニメーションクリップのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveAsAnimationClipToAssetsPath")]
		private static void MenuItem_SaveAsAnimationClipToAssetsPath()
		{
			UnityEngine.AnimationClip t_animationclip = new UnityEngine.AnimationClip();
			t_animationclip.wrapMode = UnityEngine.WrapMode.Loop;

			BlueBack.AssetLib.Editor.SaveAnimationClip.SaveAsAnimationClipToAssetsPath(t_animationclip,"Samples/AssetLib/anim.anim","xxx");
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}

		/** メッシュのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveMeshToAssetsPath")]
		private static void MenuItem_SaveMeshToAssetsPath()
		{
			UnityEngine.Mesh t_mesh = new UnityEngine.Mesh();
			t_mesh.vertices = new UnityEngine.Vector3[]{new UnityEngine.Vector3(0,0,0),new UnityEngine.Vector3(1,0,0),new UnityEngine.Vector3(0,1,0)};
			t_mesh.triangles = new int[]{0,1,2};

			BlueBack.AssetLib.Editor.SaveMesh.SaveAsMeshToAssetsPath(t_mesh,"Samples/AssetLib/mesh.mesh");
		}

		/** メッシュのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveAsMeshToAssetsPath")]
		private static void MenuItem_SaveAsMeshToAssetsPath()
		{
			UnityEngine.Mesh t_mesh = new UnityEngine.Mesh();
			t_mesh.vertices = new UnityEngine.Vector3[]{new UnityEngine.Vector3(0,0,0),new UnityEngine.Vector3(1,0,0),new UnityEngine.Vector3(0,1,0)};
			t_mesh.triangles = new int[]{0,1,2};

			BlueBack.AssetLib.Editor.SaveMesh.SaveAsMeshToAssetsPath(t_mesh,"Samples/AssetLib/mesh.mesh");
		}

		/** メッシュのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveAsStlMeshToAssetsPath")]
		private static void MenuItem_CreateStl()
		{
			string t_path = BlueBack.AssetLib.Editor.FindFile.FindFileFistFromAssetsPath("Samples/AssetLib",".*","^cylinder\\.mesh$");
			UnityEngine.Mesh t_mesh = BlueBack.AssetLib.Editor.LoadMesh.LoadMeshFromAssetsPath(t_path);
			BlueBack.AssetLib.Editor.SaveMesh.SaveAsStlMeshToAssetsPath(t_mesh,"Samples/AssetLib/cylinder.stl",new UnityEngine.Vector3(100.0f,100.0f,100.0f));
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}

		/** ＰＮＧのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveAsPngTexture2DToAssetsPath")]
		private static void MenuItem_CreatePng()
		{
			UnityEngine.Texture2D t_texture = new UnityEngine.Texture2D(16,16);
			for(int xx=0;xx<t_texture.width;xx++){
				for(int yy=0;yy<t_texture.height;yy++){
					t_texture.SetPixel(xx,yy,new UnityEngine.Color(1.0f,0.0f,0.0f,1.0f));
				}
			}
			BlueBack.AssetLib.Editor.SaveTexture.SaveAsPngTexture2DToAssetsPath(t_texture,"Samples/AssetLib/red.png");
			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}


		/** ダウンロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/Download")]
		private static void MenuItem_Download()
		{
			byte[] t_data = BlueBack.AssetLib.Editor.LoadBinary.TryLoadBinaryFromUrl("https://raw.githubusercontent.com/bluebackblue/AssetLib/main/unity_AssetLib/Assets/UPM/package.json",null);
			string t_text = BlueBack.AssetLib.EncodeCheck.GetEncoding(t_data).encoding.GetString(t_data);

			UnityEngine.Debug.Log(t_text);
		}
	}
	#endif
}

