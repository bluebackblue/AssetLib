

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief バイナリーのセーブ。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** SavelBinary
	*/
	public class SavelBinary
	{
		/** バイナリファイル書き込み。

			a_binary							: バイナリー。
			a_assets_path_with_extention		: 「Assets」からの相対バス。拡張子付き。

		*/
		public static void SaveBinaryToAssetsPath(byte[] a_binary,string a_assets_path_with_extention)
		{
			using(System.IO.BinaryWriter t_stream = new System.IO.BinaryWriter(System.IO.File.Open(UnityEngine.Application.dataPath + "/" + a_assets_path_with_extention,System.IO.FileMode.Create))){
				t_stream.Write(a_binary);
				t_stream.Flush();
				t_stream.Close();
			}
		}
	}
}

