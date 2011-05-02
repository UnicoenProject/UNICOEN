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

using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Core.Tests;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Languages.Java.Tests {
	[TestFixture]
	public class JavaModelFeatureTest : ModelFeatureTest {
		public IEnumerable<TestCaseData> TestStatements {
			get { return JavaRegenerateTest.TestStatements; }
		}

		public IEnumerable<TestCaseData> TestCodes {
			get { return JavaRegenerateTest.TestCodes; }
		}

		public IEnumerable<TestCaseData> TestFilePathes {
			get { return JavaRegenerateTest.TestFilePathes; }
		}

		public IEnumerable<TestCaseData> TestDirectoryPathes {
			get { return JavaRegenerateTest.TestDirectoryPathes; }
		}

		protected override UnifiedProgram CreateModel(string code) {
			return JavaModelFactory.Instance.Generate(code);
		}

		/// <summary>
		///   �[���R�s�[������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyDeepCopyUsingCode(string code) {
			VerifyDeepCopy(code);
		}

		/// <summary>
		///   �[���R�s�[������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyDeepCopyUsingFile(string path) {
			VerifyDeepCopy(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   �[���R�s�[������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public void VerifyDeepCopyUsingDirectory(
				string dirPath, string command, string arguments) {
			var paths = JavaFixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyDeepCopy(File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		/// <summary>
		///   �q�v�f�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyGetElementsUsingCode(string code) {
			VerifyGetElements(code);
		}

		/// <summary>
		///   �q�v�f�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementsUsingFile(string path) {
			VerifyGetElements(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   �q�v�f�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public void VerifyGetElementsUsingDirectory(
				string dirPath, string command, string arguments) {
			var paths = JavaFixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyGetElements(File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		/// <summary>
		///   �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyGetElementAndSettersUsingCode(string code) {
			VerifyGetElementAndSetters(code);
		}

		/// <summary>
		///   �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndSettersUsingFile(string path) {
			VerifyGetElementAndSetters(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public void VerifyGetElementAndSettersUsingDirectory(
				string dirPath, string command, string arguments) {
			var paths = JavaFixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyGetElementAndSetters(File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		/// <summary>
		///   �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyGetElementAndDirectSettersUsingCode(string code) {
			VerifyGetElementAndDirectSetters(code);
		}

		/// <summary>
		///   �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndDirectSettersUsingFile(string path) {
			VerifyGetElementAndDirectSetters(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public void VerifyGetElementAndDirectSettersUsingDirectory(
				string dirPath, string command, string arguments) {
			var paths = JavaFixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyGetElementAndDirectSetters(File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		/// <summary>
		///   �e�v�f���s�K�؂ȗv�f���Ȃ����\�[�X�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyParentPropertyUsingCode(string code) {
			VerifyParentProperty(code);
		}

		/// <summary>
		///   �e�v�f���s�K�؂ȗv�f���Ȃ����\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyParentPropertyUsingFile(string path) {
			VerifyParentProperty(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   �e�v�f���s�K�؂ȗv�f���Ȃ����\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public void VerifyParentPropertyUsingDirectory(
				string dirPath, string command, string arguments) {
			var paths = JavaFixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyParentProperty(File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		/// <summary>
		///   �S�v�f�̕���������擾�ł��邩�\�[�X�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyToStringUsingCode(string code) {
			VerifyToString(code);
		}

		/// <summary>
		///   �S�v�f�̕���������擾�ł��邩�\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyToStringUsingFile(string path) {
			VerifyToString(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   �S�v�f�̕���������擾�ł��邩�\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "dirPath">�e�X�g�Ώۂ̃\�[�X�R�[�h���i�[����Ă���f�B���N�g���p�X</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public void VerifyToStringUsingDirectory(
				string dirPath, string command, string arguments) {
			var paths = JavaFixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyToString(File.ReadAllText(path, XEncoding.SJIS));
			}
		}
	}
}