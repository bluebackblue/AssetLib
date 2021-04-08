

/** Editor.VersionManager
*/
namespace Editor.VersionManager
{
	/** Window
	*/
	public class Window : UnityEditor.EditorWindow
	{
		/** s_window
		*/
		private static Window s_window = null;

		/** 開く。
		*/
		public static void Open()
		{
			Window t_window = (Window)UnityEditor.EditorWindow.GetWindow(typeof(Window));
			if(t_window != null){
				t_window.Show();
			}
		}

		/** error
		*/
		private string error;

		/** github_version
		*/
		private int github_version_0;
		private int github_version_1;
		private int github_version_2;

		/** readme_version
		*/
		private int readme_version_0;
		private int readme_version_1;
		private int readme_version_2;

		/** package_version
		*/
		private int package_version_0;
		private int package_version_1;
		private int package_version_2;

		/** constructor
		*/
		public Window()
		{
			s_window = this;

			//error
			this.error = "";

			//github_version
			this.github_version_0 = 0;
			this.github_version_1 = 0;
			this.github_version_2 = 0;

			//readme_version
			this.readme_version_0 = 0;
			this.readme_version_1 = 0;
			this.readme_version_2 = 0;

			//package_version
			this.package_version_0 = 0;
			this.package_version_1 = 0;
			this.package_version_2 = 0;
		}

		/** OnEnable
		*/
		private void OnEnable()
		{
			UnityEngine.UIElements.VisualElement t_root = this.rootVisualElement;
			t_root.Clear();

			//UXMLのロード。
			UnityEngine.UIElements.VisualTreeAsset t_visualtree = BlueBack.AssetLib.Editor.LoadAsset.LoadAssetFromAssetsPath<UnityEngine.UIElements.VisualTreeAsset>("Editor/VersionManager/window.uxml");
			if(t_visualtree == null){
				return;
			}
			UnityEngine.UIElements.VisualElement t_root_element = t_visualtree.CloneTree();
			t_root.Add(t_root_element);

			//USSのロード。
			UnityEngine.UIElements.StyleSheet t_stylesheet = BlueBack.AssetLib.Editor.LoadAsset.LoadAssetFromAssetsPath<UnityEngine.UIElements.StyleSheet>("Editor/VersionManager/window.uss");
			t_root.styleSheets.Add(t_stylesheet);

			//エラー。
			{
				{
					UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"error");
					if(t_label != null){
						//github
						t_label.text = this.error;
					}
				}
			}

			//リロードボタン。
			{
				UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"reload");
				if(t_button != null){
					t_button.clickable.clicked += () => {
						UnityEngine.Debug.Log("Reload");
						this.CallBack_Reload();
						this.OnEnable();
					};
				}
			}

			//更新ボタン。
			{
				UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"update");
				if(t_button != null){
					t_button.clickable.clicked += () => {
						UnityEngine.Debug.Log("Update");
						this.CallBack_Update();
						this.OnEnable();
					};
				}
			}

			//ステータス。
			{
				//github
				{
					UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"status_github_version");
					if(t_label != null){
						t_label.text = string.Format("{0}.{1}.{2}",this.github_version_0,this.github_version_1,this.github_version_2);
					}
				}

				//readme
				{
					UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"status_readme_version");
					if(t_label != null){
						t_label.text = string.Format("{0}.{1}.{2}",this.readme_version_0,this.readme_version_1,this.readme_version_2);
					}
				}

				//package
				{
					UnityEngine.UIElements.Label t_label = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,"status_package_version");
					if(t_label != null){
						t_label.text = string.Format("{0}.{1}.{2}",this.package_version_0,this.package_version_1,this.package_version_2);
					}
				}
			}

			//バージョンボタン。リードミー。
			{
				for(int ii=0;ii<3;ii++){
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"button_readme_" + ii.ToString());
					if(t_button != null){
						t_button.text = string.Format("{0}.{1}.{2}",this.readme_version_0,this.readme_version_1,this.readme_version_2 + ii - 1);
						if(ii==1){
							t_button.AddToClassList("red");
						}
					}
				}
			}

			//バージョンボタン。パッケージ。
			{
				for(int ii=0;ii<3;ii++){
					UnityEngine.UIElements.Button t_button = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,"button_package_" + ii.ToString());
					if(t_button != null){
						t_button.text = string.Format("{0}.{1}.{2}",this.readme_version_0,this.readme_version_1,this.readme_version_2 + ii - 1);
						if(ii==1){
							t_button.AddToClassList("red");
						}
					}
				}
			}
		}

		/** CallBack_Reload
		*/
		private void CallBack_Reload()
		{
			//error
			this.error = "";

			//github_version
			this.github_version_0 = 0;
			this.github_version_1 = 0;
			this.github_version_2 = 0;

			//readme_version
			this.readme_version_0 = 0;
			this.readme_version_1 = 0;
			this.readme_version_2 = 0;

			//package_version
			this.package_version_0 = 0;
			this.package_version_1 = 0;
			this.package_version_2 = 0;
		}

		/** CallBack_Update
		*/
		private void CallBack_Update()
		{
			//error
			this.error = "";

			//github_version
			this.github_version_0 = 0;
			this.github_version_1 = 0;
			this.github_version_2 = 0;

			//readme_version
			this.readme_version_0 = 0;
			this.readme_version_1 = 0;
			this.readme_version_2 = 0;

			//package_version
			this.package_version_0 = 0;
			this.package_version_1 = 0;
			this.package_version_2 = 0;

			//github
			{
				/*
				try{
					string t_jsonstring = BlueBack.AssetLib.Editor.LoadText.TryLoadTextFromUrl("https://api.github.com/repos/bluebackblue/AssetLib/releases/latest",null,System.Text.Encoding.GetEncoding("utf-8"));
					t_jsonstring = BlueBack.JsonItem.Normalize.Convert(t_jsonstring);
					BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(t_jsonstring);
					string t_version_string = t_jsonitem.GetItem("name").GetStringData();
					string[] t_version_string_list = t_version_string.Split('.');
					this.github_version_0 = int.Parse(t_version_string_list[0]);
					this.github_version_1 = int.Parse(t_version_string_list[1]);
					this.github_version_2 = int.Parse(t_version_string_list[2]);
				}catch(System.Exception t_exception){
					this.error = t_exception.Message;
				}
				*/
			}

			//readme
			{
				try{
					string t_version_string = null;
					{
						string t_text = BlueBack.AssetLib.Editor.LoadText.LoadTextFromAssetsPath("../../README.md",System.Text.Encoding.GetEncoding("utf-8"));
						string[] t_text_list = t_text.Split(new char[]{'\r','\n'});

						string t_library_name = "AssetLib";
						string t_url = ("https://github.com/bluebackblue/" + t_library_name + ".git?path=unity_" + t_library_name + "/Assets/UPM").Replace(":","\\:").Replace("/","\\/").Replace(".","\\.").Replace("?","\\?").Replace("=","\\=");

						System.Text.RegularExpressions.Regex t_regex = new System.Text.RegularExpressions.Regex("\\* " + t_url + "\\#" + "(?<version>.*)");
						foreach(string t_text_line in t_text_list){
							System.Text.RegularExpressions.Match t_match = t_regex.Match(t_text_line);
							if(t_match.Success == true){
								System.Text.RegularExpressions.GroupCollection t_group_collection = t_match.Groups;
								foreach(System.Text.RegularExpressions.Group t_group in t_group_collection){
									if(t_group.Success == true){
										if(t_group.Name == "version"){
											t_version_string = t_group.Value;
										}
									}
								}
							}
						}
					}

					string[] t_version_string_list = t_version_string.Split('.');
					this.readme_version_0 = int.Parse(t_version_string_list[0]);
					this.readme_version_1 = int.Parse(t_version_string_list[1]);
					this.readme_version_2 = int.Parse(t_version_string_list[2]);

				}catch(System.Exception t_exception){
					UnityEngine.Debug.Log(t_exception.Message);
					this.error = t_exception.Message;
				}
			}

			//package
			{
				try{
					string t_jsonstring = BlueBack.AssetLib.Editor.LoadText.LoadTextFromAssetsPath("UPM/package.json",null);
					t_jsonstring = BlueBack.JsonItem.Normalize.Convert(t_jsonstring);
					BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(t_jsonstring);

					string t_version_string = t_jsonitem.GetItem("version").GetStringData();
					string[] t_version_string_list = t_version_string.Split('.');
					this.package_version_0 = int.Parse(t_version_string_list[0]);
					this.package_version_1 = int.Parse(t_version_string_list[1]);
					this.package_version_2 = int.Parse(t_version_string_list[2]);
				}catch(System.Exception t_exception){
					UnityEngine.Debug.Log(t_exception.Message);
					this.error = t_exception.Message;
				}
			}
		}
	}
}

