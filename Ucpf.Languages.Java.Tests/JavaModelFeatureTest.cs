using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Paraiba.Linq;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;
using Ucpf.Core.Tests;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests {
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

		protected override UnifiedProgram CreateModel(string code) {
			return JavaModelFactory.CreateModel(code);
		}

		/// <summary>
		/// �[���R�s�[������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyDeepCopyUsingStatement(string code) {
			base.VerifyDeepCopyUsingCode(code);
		}

		/// <summary>
		/// �[���R�s�[������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyDeepCopyUsingCode(string code) {
			base.VerifyDeepCopyUsingCode(code);
		}

		/// <summary>
		/// �[���R�s�[������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyDeepCopyUsingFile(string path) {
			base.VerifyDeepCopyUsingCode(File.ReadAllText(path));
		}

		/// <summary>
		/// �q�v�f�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyGetElementsUsingStatement(string code) {
			base.VerifyGetElementsUsingCode(code);
		}

		/// <summary>
		/// �q�v�f�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementsUsingCode(string code) {
			base.VerifyGetElementsUsingCode(code);
		}

		/// <summary>
		/// �q�v�f�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementsUsingFile(string path) {
			base.VerifyGetElementsUsingCode(File.ReadAllText(path));
		}

		/// <summary>
		/// �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyGetElementAndSettersUsingStatement(string code) {
			base.VerifyGetElementAndSettersUsingCode(code);
		}

		/// <summary>
		/// �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementAndSettersUsingCode(string code) {
			base.VerifyGetElementAndSettersUsingCode(code);
		}

		/// <summary>
		/// �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndSettersUsingFile(string path) {
			base.VerifyGetElementAndSettersUsingCode(File.ReadAllText(path));
		}

		/// <summary>
		/// �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyGetElementAndDirectSettersUsingStatement(string code) {
			base.VerifyGetElementAndDirectSettersUsingCode(code);
		}

		/// <summary>
		/// �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementAndDirectSettersUsingCode(string code) {
			base.VerifyGetElementAndDirectSettersUsingCode(code);
		}

		/// <summary>
		/// �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndDirectSettersUsingFile(string path) {
			base.VerifyGetElementAndDirectSettersUsingCode(File.ReadAllText(path));
		}

		/// <summary>
		/// �e�v�f���s�K�؂ȗv�f���Ȃ����\�[�X�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyParentPropertyUsingStatements(string code) {
			base.VerifyParentPropertyUsingCode(code);
		}

		/// <summary>
		/// �e�v�f���s�K�؂ȗv�f���Ȃ����\�[�X�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyParentPropertyUsingCode(string code) {
			base.VerifyParentPropertyUsingCode(code);
		}

		/// <summary>
		/// �e�v�f���s�K�؂ȗv�f���Ȃ����\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyParentPropertyUsingFile(string path) {
			base.VerifyParentPropertyUsingCode(File.ReadAllText(path));
		}

		/// <summary>
		/// �S�v�f�̕���������擾�ł��邩�\�[�X�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyToStringUsingStatements(string code) {
			base.VerifyToStringUsingCode(code);
		}

		/// <summary>
		/// �S�v�f�̕���������擾�ł��邩�\�[�X�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyToStringUsingCode(string code) {
			base.VerifyToStringUsingCode(code);
		}

		/// <summary>
		/// �S�v�f�̕���������擾�ł��邩�\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyToStringUsingFile(string path) {
			base.VerifyToStringUsingCode(File.ReadAllText(path));
		}
	}
}
