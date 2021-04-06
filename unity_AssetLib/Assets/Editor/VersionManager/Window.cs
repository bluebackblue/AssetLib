

/** Editor.VersionManager
*/
namespace Editor.VersionManager
{
	/** Window
	*/
	public class Window : UnityEditor.EditorWindow
	{
		/**
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

		/** label_remote
		*/
		private string label_remote;

		/** constructor
		*/
		public Window()
		{
			s_window = this;

			this.label_remote = "";
		}

		/** OnEnable
		*/
		private void OnEnable()
		{
			UnityEngine.UIElements.VisualElement t_root = this.rootVisualElement;
			t_root.Clear();

			//UXMLのロード。
			UnityEngine.UIElements.VisualTreeAsset t_visualtree = BlueBack.AssetLib.Editor.LoadAsset.LoadAssetFromAssetsPath<UnityEngine.UIElements.VisualTreeAsset>("Editor/VersionManager/window.uxml");
			UnityEngine.UIElements.VisualElement t_root_element = t_visualtree.CloneTree();
			t_root.Add(t_root_element);

			//USSのロード。
			UnityEngine.UIElements.StyleSheet t_stylesheet = BlueBack.AssetLib.Editor.LoadAsset.LoadAssetFromAssetsPath<UnityEngine.UIElements.StyleSheet>("Editor/VersionManager/window.uss");
			t_root.styleSheets.Add(t_stylesheet);

			//リロード。
			{
				UnityEngine.UIElements.Button t_button_reload = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,null,"button_reload");
				if(t_button_reload != null){
					t_button_reload.text = "リロード";
					t_button_reload.clickable.clicked += () => {
						this.OnEnable();
					};
				}
			}

			//リモート。
			{
				UnityEngine.UIElements.Label t_label_remote = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Label>(t_root,null,"label_remote");
				{
					t_label_remote.text = this.label_remote;
				}

				UnityEngine.UIElements.Button t_button_remote = UnityEngine.UIElements.UQueryExtensions.Q<UnityEngine.UIElements.Button>(t_root,null,"button_remote");
				{
					t_button_remote.text = "リモート";
					t_button_remote.clickable.clicked += () => {
						this.label_remote = BlueBack.AssetLib.Editor.LoadText.TryLoadTextFromUrl("https://api.github.com/repos/bluebackblue/AssetLib/releases/latest",null,System.Text.Encoding.GetEncoding("utf-8"));
						this.OnEnable();
					};
				}
			}

			/*
			System.Collections.Generic.IEnumerable<string> t_list = t_root.GetClasses();
			UnityEngine.UIElements.Toggle ButtonCheck = t_root.Q<UnityEngine.UIElements.Toggle>(className: "ButtonCheck");
			*/

			/*
			// UI取得
			UnityEngine.UIElements.Button CreateButton = root.Q<UnityEngine.UIElements.Button>(className: "CreateButton");
			*/

			/*
			// ボタンアクション
			CreateButton.clickable.clicked += () =>
			{
				// Toggleチェック時のみ反応する
				if (ButtonCheck.value == true)
				{
					Debug.Log("Create");
				}
			};
			*/
		}
	}
}

