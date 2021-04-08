

/** Editor.VersionManager
*/
namespace Editor.VersionManager
{
	/** PackageJson
	*/
	public class PackageJson
	{
		/** 名前。
		*/
		private const string NAME = "AssetLib";

		/** 説明。
		*/
		private const string DISCRIPTION = "アセット操作";

		/** KEYWORD
		*/
		private readonly string[] KEYWORD = new string[]{"asset"};

		/** version
		*/
		private int[] version;

		/** constructor
		*/
		public PackageJson()
		{
			this.version = new int[3]{0,0,0};
		}

		/** Item
		*/
		private struct Item
		{
			public string name;
			public string displayName;
			public string version;
			public string unity;
			public string discription;
			public struct Author
			{
				public string name;
				public string url;
			};
			public Author author;
			public string[] keyword;
			public System.Collections.Generic.Dictionary<string,string> dependencies;
			public struct Samples
			{
				public string displayName;
				public string path;
			}
			public System.Collections.Generic.List<Samples> samples;
		}

		/** Save
		*/
		public void Save()
		{
			this.version[2] = 10;


			{
				Item t_item;
				{
					//name
					t_item.name = "blueback." + NAME.ToLower();

					//displayName
					t_item.displayName = NAME;

					//version
					t_item.version = string.Format("{0}.{1}.{2}",this.version[0],this.version[1],this.version[2]);

					//unity
					t_item.unity = "2020.1";

					//discription
					t_item.discription = DISCRIPTION;

					//author
					t_item.author.name = "BlueBack";
					t_item.author.url = "https://github.com/bluebackblue";
				
					//keyword
					t_item.keyword = new string[]{
						"asset"
					};
				
					//dependencies
					t_item.dependencies = new System.Collections.Generic.Dictionary<string,string>();
					{
					}

					//samples
					t_item.samples = new System.Collections.Generic.List<Item.Samples>();
					{
						System.Collections.Generic.List<string> t_sample_directory_list = BlueBack.AssetLib.Editor.DirectoryNameList.CreateOnlyTopDirectoryNameListFromAssetsPath("Samples/" + NAME + "/000");
						for(int ii=0;ii<t_sample_directory_list.Count;ii++){
							Item.Samples t_sample_item = new Item.Samples();
							{
								t_sample_item.path = "Samples~/" + t_sample_directory_list[ii];
								t_sample_item.displayName = t_sample_directory_list[ii];
							}
							t_item.samples.Add(t_sample_item);
						}
					}
				}

				string t_jsonstring = BlueBack.JsonItem.Convert.ObjectToJsonString<Item>(t_item);

				BlueBack.AssetLib.Editor.SaveText.SaveUtf8TextToAssetsPath(t_jsonstring,"UPM/package.json",false,BlueBack.AssetLib.LineFeedOption.CRLF);
			}

			


			BlueBack.AssetLib.Editor.RefreshAsset.Refresh();
		}
	
		/** Load
		*/
		/*
		public static void Load()
		{
			string t_jsonstring = BlueBack.AssetLib.Editor.LoadText.LoadTextFromAssetsPath("UPM/package.json",null);
			t_jsonstring = BlueBack.JsonItem.Normalize.Convert(t_jsonstring);
			BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(t_jsonstring);

			//package.jsonからバージョンの取得。
			{
				string t_version_string = t_jsonitem.GetItem("version").GetStringData();
				string[] t_version_string_list = t_version_string.Split('.');
				for(int ii=0;ii<s_version.Length;ii++){
					s_version[ii] = int.Parse(t_version_string_list[ii]);
				}
			}

			{
			}

			try{

				string t_version_string = t_jsonitem.GetItem("version").GetStringData();
				
				this.package_version_0 = int.Parse(t_version_string_list[0]);
				this.package_version_1 = int.Parse(t_version_string_list[1]);
				this.package_version_2 = int.Parse(t_version_string_list[2]);
			}catch(System.Exception t_exception){
				UnityEngine.Debug.Log(t_exception.Message);
			}
		}
		*/




	}
}

