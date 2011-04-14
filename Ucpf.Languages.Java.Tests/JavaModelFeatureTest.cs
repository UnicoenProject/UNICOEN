using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests
{
	[TestFixture]
	public class JavaModelFeatureTest : ModelFeatureTest
	{
		public IEnumerable<TestCaseData> TestStatements
		{
			get { return JavaRegenerateTest.TestStatements; }
		}

		public IEnumerable<TestCaseData> TestCodes
		{
			get { return JavaRegenerateTest.TestCodes; }
		}

		public IEnumerable<TestCaseData> TestFilePathes
		{
			get { return JavaRegenerateTest.TestFilePathes; }
		}

		protected override UnifiedProgram CreateModel(string code)
		{
			return OldJavaModelFactory.CreateModel(code);
		}

		/// <summary>
		///   �[���R�s�[������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyDeepCopyUsingCode(string code)
		{
			VerifyDeepCopy(code);
		}

		/// <summary>
		///   �[���R�s�[������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyDeepCopyUsingFile(string path)
		{
			VerifyDeepCopy(File.ReadAllText(path));
		}

		/// <summary>
		///   �q�v�f�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyGetElementsUsingCode(string code)
		{
			VerifyGetElements(code);
		}

		/// <summary>
		///   �q�v�f�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementsUsingFile(string path)
		{
			VerifyGetElements(File.ReadAllText(path));
		}

		/// <summary>
		///   �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyGetElementAndSettersUsingCode(string code)
		{
			VerifyGetElementAndSetters(code);
		}

		/// <summary>
		///   �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndSettersUsingFile(string path)
		{
			VerifyGetElementAndSetters(File.ReadAllText(path));
		}

		/// <summary>
		///   �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyGetElementAndDirectSettersUsingCode(string code)
		{
			VerifyGetElementAndDirectSetters(code);
		}

		/// <summary>
		///   �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�\�[�X�[�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndDirectSettersUsingFile(string path)
		{
			VerifyGetElementAndDirectSetters(File.ReadAllText(path));
		}

		/// <summary>
		///   �e�v�f���s�K�؂ȗv�f���Ȃ����\�[�X�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyParentPropertyUsingCode(string code)
		{
			VerifyParentProperty(code);
		}

		/// <summary>
		///   �e�v�f���s�K�؂ȗv�f���Ȃ����\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyParentPropertyUsingFile(string path)
		{
			VerifyParentProperty(File.ReadAllText(path));
		}

		/// <summary>
		///   �S�v�f�̕���������擾�ł��邩�\�[�X�R�[�h���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "code">�e�X�g�Ώۂ̃\�[�X�R�[�h</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyToStringUsingCode(string code)
		{
			VerifyToString(code);
		}

		/// <summary>
		///   �S�v�f�̕���������擾�ł��邩�\�[�X�R�[�h�̃p�X���w�肵�ăe�X�g���܂��B
		/// </summary>
		/// <param name = "path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyToStringUsingFile(string path)
		{
			VerifyToString(File.ReadAllText(path));
		}
	}
}