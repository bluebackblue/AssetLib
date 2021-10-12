

/** Samples.AssetLib.Package.Editor
*/
namespace Samples.AssetLib.Package.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** パッケージ作成。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Package/CreatePackageFromAssetsPath")]
		private static void MenuItem_Sample_AssetLib_CreatePackage_CreatePackageFromAssetsPath()
		{
			BlueBack.AssetLib.Editor.CreatePackageWithAssetsPath.Create("Samples/AssetLib","sample.unitypackage",UnityEditor.ExportPackageOptions.Recurse);
		}

		/** Asmdef列挙。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Package/ListUpPackageAsmdefGuid")]
		private static void MenuItem_ListUpAsmdefGuid()
		{
			System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo> t_packagelist = BlueBack.AssetLib.Editor.PackageList.CreatePackageList(false,false);
			foreach(UnityEditor.PackageManager.PackageInfo t_packageinfo in t_packagelist){
				System.Collections.Generic.List<string> t_filenamelist = BlueBack.AssetLib.Editor.FindFileWithAssetsPath.FindAll(t_packageinfo.resolvedPath,".*",".*\\.asmdef$");
				foreach(string t_filename in t_filenamelist){

					string t_asmdef_name;
					{
						BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(BlueBack.JsonItem.Normalize.Convert(BlueBack.AssetLib.Editor.LoadText.LoadTextFromFullPath(t_filename,System.Text.Encoding.UTF8)));
						BlueBack.JsonItem.JsonItem t_jsonitem_name = t_jsonitem.GetItem("name");
						t_asmdef_name = t_jsonitem_name.GetStringData();
					}

					string t_asmdef_guid = BlueBack.AssetLib.Editor.LoadGuid.LoadGuidFromFullPath(t_filename + ".meta",System.Text.Encoding.UTF8);

					UnityEngine.Debug.Log(t_asmdef_name + " : " + t_asmdef_guid + " : " + t_filename);
				}
			}
		}

		/** パッケージ列挙。
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
	}
	#endif
}

