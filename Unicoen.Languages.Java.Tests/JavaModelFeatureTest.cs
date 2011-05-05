#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using NUnit.Framework;
using Unicoen.Core.ModelFactories;
using Unicoen.Core.Tests;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Languages.Java.Tests {
	[TestFixture]
	public class JavaModelFeatureTest : ModelFeatureTest {
		private readonly JavaFixture _fixture = new JavaFixture();

		protected override LanguageFixture Fixture {
			get { return _fixture; }
		}

		private readonly JavaModelFactory _modelFactory = new JavaModelFactory();

		protected override ModelFactory ModelFactory {
			get { return _modelFactory; }
		}

		/// <summary>
		///   �[���R�s�[������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void VerifyDeepCopyUsingCode(string code) {
			base.VerifyDeepCopyUsingCode(code);
		}

		/// <summary>
		///   �[���R�s�[������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyDeepCopyUsingFile(string path) {
			base.VerifyDeepCopyUsingFile(path);
		}

		/// <summary>
		///   �[���R�s�[������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyDeepCopyUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyDeepCopyUsingDirectory(dirPath, command, arguments);
		}

		/// <summary>
		///   �q�v�f�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void VerifyGetElementsUsingCode(string code) {
			base.VerifyGetElementsUsingCode(code);
		}

		/// <summary>
		///   �q�v�f�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyGetElementsUsingFile(string path) {
			base.VerifyGetElementsUsingFile(path);
		}

		/// <summary>
		///   �q�v�f�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyGetElementsUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyGetElementsUsingDirectory(dirPath, command, arguments);
		}

		/// <summary>
		///   �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void VerifyGetElementAndSettersUsingCode(string code) {
			base.VerifyGetElementAndSettersUsingCode(code);
		}

		/// <summary>
		///   �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyGetElementAndSettersUsingFile(string path) {
			base.VerifyGetElementAndSettersUsingFile(path);
		}

		/// <summary>
		///   �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyGetElementAndSettersUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyGetElementAndSettersUsingDirectory(dirPath, command, arguments);
		}

		/// <summary>
		///   �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void VerifyGetElementAndDirectSettersUsingCode(string code) {
			base.VerifyGetElementAndDirectSettersUsingCode(code);
		}

		/// <summary>
		///   �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyGetElementAndDirectSettersUsingFile(string path) {
			base.VerifyGetElementAndDirectSettersUsingFile(path);
		}

		/// <summary>
		///   �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyGetElementAndDirectSettersUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyGetElementAndDirectSettersUsingDirectory(
					dirPath, command, arguments);
		}

		/// <summary>
		///   �e�v�f���s�K�؂ȗv�f���Ȃ����\�[�X�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void VerifyParentPropertyUsingCode(string code) {
			base.VerifyParentPropertyUsingCode(code);
		}

		/// <summary>
		///   �e�v�f���s�K�؂ȗv�f���Ȃ����\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyParentPropertyUsingFile(string path) {
			base.VerifyParentPropertyUsingFile(path);
		}

		/// <summary>
		///   �e�v�f���s�K�؂ȗv�f���Ȃ����\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyParentPropertyUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyParentPropertyUsingDirectory(dirPath, command, arguments);
		}

		/// <summary>
		///   �S�v�f�̕���������擾�ł��邩�\�[�X�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void VerifyToStringUsingCode(string code) {
			base.VerifyToStringUsingCode(code);
		}

		/// <summary>
		///   �S�v�f�̕���������擾�ł��邩�\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyToStringUsingFile(string path) {
			base.VerifyToStringUsingFile(path);
		}

		/// <summary>
		///   �S�v�f�̕���������擾�ł��邩�\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyToStringUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyToStringUsingDirectory(dirPath, command, arguments);
		}
	}
}