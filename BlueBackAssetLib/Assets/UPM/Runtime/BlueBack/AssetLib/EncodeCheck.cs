

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief エンコードチェック。
*/


/** BlueBack.AssetLib
*/
namespace BlueBack.AssetLib
{
	/** EncodeCheck
	*/
	public static class EncodeCheck
	{
		/** Result
		*/
		public struct Result
		{
			public bool success;
			public System.Text.Encoding encoding;
			public int bomsize;
		}

		/** GetEncoding
		*/
		public static Result GetEncoding(byte[] a_data)
		{
			if(IsUtf8Bom(a_data) == true){
				//utf-8:bom
				return new Result(){
					success = true,
					encoding = System.Text.Encoding.GetEncoding(65001),
					bomsize = 3,
				};
			}else if(IsUtf16LeBom(a_data) == true){
				//utf-16:le:bom
				return new Result(){
					success = true,
					encoding = System.Text.Encoding.GetEncoding(1200),
					bomsize = 2,
				};
			}else if(IsUtf16BeBom(a_data) == true){
				//utf-16:be:bom
				return new Result(){
					success = true,
					encoding = System.Text.Encoding.GetEncoding(1201),
					bomsize = 2,
				};
			}else if(IsUtf32LeBom(a_data) == true){
				//utf-32:le:bom
				return new Result(){
					success = true,
					encoding = System.Text.Encoding.GetEncoding(12000),
					bomsize = 4,
				};
			}else if(IsUtf32BeBom(a_data) == true){
				//utf-32:be:bom
				return new Result(){
					success = true,
					encoding = System.Text.Encoding.GetEncoding(12001),
					bomsize = 4,
				};
			}else if(IsUtf8(a_data) == true){
				//utf-8
				return new Result(){
					success = true,
					encoding = System.Text.Encoding.GetEncoding(65001),
					bomsize = 0,
				};
			}else if(IsSjis(a_data) == true){
				//sjis
				return new Result(){
					success = true,
					encoding = System.Text.Encoding.GetEncoding(932),
					bomsize = 0,
				};
			}else{
				#if(DEF_BLUEBACK_ASSERT)
				DebugTool.Assert(false);
				#endif

				return new Result(){
					success = false,
					encoding = System.Text.Encoding.GetEncoding(65001),
					bomsize = 0,
				};
			}
		}

		/** IsUtf8Bom
		*/
		public static bool IsUtf8Bom(byte[] a_data)
		{
			if(a_data.Length >= 3){
				if((a_data[0] == 0xEF)&&(a_data[1] == 0xBB)&&(a_data[2] == 0xBF)){
					return true;
				}
			}
			return false;
		}

		/** IsUtf16LeBom
		*/
		public static bool IsUtf16LeBom(byte[] a_data)
		{
			if(a_data.Length >= 2){
				if((a_data[0] == 0xFF)&&(a_data[1] == 0xFE)){
					if(a_data.Length >= 4){
						if((a_data[0] == 0xFF)&&(a_data[1] == 0xFE)&&(a_data[2] == 0x00)&&(a_data[3] == 0x00)){
							return false;
						}
					}
					return true;
				}
			}

			return false;
		}

		/** IsUtf16BeBom
		*/
		public static bool IsUtf16BeBom(byte[] a_data)
		{
			if(a_data.Length >= 2){
				if((a_data[0] == 0xFE)&&(a_data[1] == 0xFF)){
					return true;
				}
			}

			return false;
		}

		/** IsUtf32LeBom
		*/
		public static bool IsUtf32LeBom(byte[] a_data)
		{
			if(a_data.Length >= 4){
				if((a_data[0] == 0xFF)&&(a_data[1] == 0xFE)&&(a_data[2] == 0x00)&&(a_data[3] == 0x00)){
					return true;
				}
			}

			return false;
		}

		/** IsUtf32BeBom
		*/
		public static bool IsUtf32BeBom(byte[] a_data)
		{
			if(a_data.Length >= 4){
				if((a_data[0] == 0x00)&&(a_data[1] == 0x00)&&(a_data[2] == 0xFE)&&(a_data[3] == 0xFF)){
					return true;
				}
			}

			return false;
		}

		/** IsSjis
		*/
		public static bool IsSjis(byte[] a_data)
		{
			for(int ii=0;ii<a_data.Length;ii++){
				byte t_data1 = a_data[ii];
				if(t_data1 < 0x80){
					//ASCII。制御コード。
				}else if((0xA1 <= t_data1)&&(t_data1 <= 0xDF)){
					//半角カタカナ。
				}else if(((0x81 <= t_data1)&&(t_data1 <= 0x9F))||((0xE0 <= t_data1)&&(t_data1 <= 0xEF))){
					//２バイト文字。
					if((ii + 1)<a_data.Length){
						byte t_data2 = a_data[ii + 1];
						if(((0x40 <= t_data2)&&(t_data2 <= 0x7E))||((0x80 <= t_data2)&&(t_data2 <= 0xFC))){
							ii++;
							continue;
						}else{
							return false;
						}
					}else{
						return false;
					}
				}else{
					return false;
				}
			}

			return true;
		}

		/** IsUtf8
		*/
		public static bool IsUtf8(byte[] a_data)
		{
			for(int ii=0;ii<a_data.Length;ii++){
				byte t_data1 = a_data[ii];
				if(t_data1 < 0x80){
					//ASCII。制御コード。
				}else if((t_data1 & 0xE0) == 0xC0){
					//２バイト。
					if((ii+1)<a_data.Length){
						byte t_data2 = a_data[ii + 1];
						if((t_data1 & 0xC0) == 0x80){
							ii++;
							continue;
						}else{
							return false;
						}
					}else{
						return false;
					}
				}else if((t_data1 & 0xF0) == 0xE0){
					//３バイト。
					if((ii+2)<a_data.Length){
						byte t_data2 = a_data[ii + 1];
						byte t_data3 = a_data[ii + 2];
						if((t_data2 & 0xC0) == 0x80){
							if((t_data3 & 0xC0) == 0x80){
								ii += 2;
								continue;
							}else{
								return false;
							}
						}else{
							return false;
						}
					}else{
						return false;
					}
				}else if((t_data1 & 0xF8) == 0xF0){
					//４バイト。
					if((ii+3)<a_data.Length){
						byte t_data2 = a_data[ii + 1];
						byte t_data3 = a_data[ii + 2];
						byte t_data4 = a_data[ii + 3];
						if((t_data2 & 0xC0) == 0x80){
							if((t_data3 & 0xC0) == 0x80){
								if((t_data4 & 0xC0) == 0x80){
									ii += 3;
									continue;
								}else{
									return false;
								}
							}else{
								return false;
							}
						}else{
							return false;
						}
					}else{
						return false;
					}
				}else{
					return false;
				}
			}

			return true;
		}
	}
}

