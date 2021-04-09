

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief �ݒ�B
*/


/** Setting
*/
public class Setting
{
	/** AUTHOR_NAME
	*/
	public const string AUTHOR_NAME = "BlueBack";

	/** PACKAGE_NAME
	*/
	public const string PACKAGE_NAME = "AssetLib";

	/** PACKAGEJSON
	*/
	public const string PACKAGEJSON_UNITY = "2020.1";

	/** PACKAGEJSON
	*/
	public const string PACKAGEJSON_DISCRIPTION = "�A�Z�b�g����";

	/** PACKAGEJSON
	*/
	public static readonly string[] PACKAGEJSON_KEYWORD = new string[]{
		"asset"
	};

	/** ReadmeMd_StringCreator_Argument
	*/
	public struct ReadmeMd_StringCreator_Argument
	{
		public string version;
	}

	/** ReadmeMd_StringCreator_Type
	*/
	public delegate string[] ReadmeMd_StringCreator_Type(in ReadmeMd_StringCreator_Argument a_argument);

	/** READMEMD_STRINGCREATOR
	*/
	public static readonly ReadmeMd_StringCreator_Type[] READMEMD_STRINGCREATOR = new ReadmeMd_StringCreator_Type[]{

		/** �T�v�B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"# " + AUTHOR_NAME + "." + PACKAGE_NAME,
				"�A�Z�b�g����",
				"* �p�b�P�[�W�̍쐬",
				"* �A�Z�b�g�o���h���̍쐬",
				"* �v���n�u�A�A�Z�b�g�A�e�L�X�g�̃Z�[�u���[�h",
				"* �e�L�X�g�̃G���R�[�h�f�R�[�h",
				"* �f�B���N�g���̍쐬�A�폜",
				"* �t�@�C�����A�f�B���N�g�����̗񋓁A����",
			};
		},

		/** ���C�Z���X�B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## ���C�Z���X",
				"MIT License",
				"* https://github.com/bluebackblue/AssetLib/blob/main/LICENSE",
			};
		},

		/** �ˑ��B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## �O���ˑ� / �g�p���C�Z���X��",
				"### �T���v���̂�",
				"* https://github.com/bluebackblue/AssetLib",
			};
		},

		/** ����m�F�B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## ����m�F",
				"Unity " + UnityEngine.Application.unityVersion,
			};
		},

		/** UPM�B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## UPM",
				"### �ŐV",
				"* https://github.com/bluebackblue/" + PACKAGE_NAME + ".git?path=unity_" + PACKAGE_NAME + "/Assets/UPM#" + a_argument.version,
				"### �J��",
				"* https://github.com/bluebackblue/" + PACKAGE_NAME + ".git?path=unity_" + PACKAGE_NAME + "/Assets/UPM",
			};
		},

		/** �C���X�g�[���B 
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## Unity�ւ̒ǉ����@",
				"* Unity�N��",
				"* ���j���[�I���F�uWindow->Package Manager�v",
				"* �{�^���I���F�u����́{�{�^���v",
				"* ���X�g�I���F�uAdd package from git URL...�v",
				"* ��LUPM��URL��ǉ��u https://github.com/�`�`/UPM#�o�[�W���� �v",
				"### ��",
				"Git�N���C�A���g���C���X�g�[������Ă���K�v������B",
				"* https://docs.unity3d.com/ja/current/Manual/upm-git.html",
				"* https://git-scm.com/",
			};
		},

		/** ��B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## ��",
				"```",
				"```",
			};
		},
	};
}

