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
		public IEnumerable<TestCaseData> TestCases {
			get { return TestCaseSource.JavaTestCases; }
		}

		protected override UnifiedProgram CreateModel(string code) {
			return JavaModelFactory.CreateModel(code);
		}

		/// <summary>
		/// �[���R�s�[������ɓ��삷�邩�e�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestCases")]
		public override void VerifyDeepCopy(string path) {
			base.VerifyDeepCopy(path);
		}

		/// <summary>
		/// �q�v�f�̗񋓋@�\������ɓ��삷�邩�e�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestCases")]
		public override void VerifyGetElements(string path) {
			base.VerifyGetElements(path);
		}

		/// <summary>
		/// �q�v�f�ƃZ�b�^�[�̗񋓋@�\������ɓ��삷�邩�e�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestCases")]
		public override void GetElementAndSetters(string path) {
			base.GetElementAndSetters(path);
		}

		/// <summary>
		/// �q�v�f�ƃv���p�e�B����Ȃ��Z�b�^�[�̗񋓋@�\������ɓ��삷�邩�e�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestCases")]
		public override void GetElementAndDirectSetters(string path) {
			base.GetElementAndDirectSetters(path);
		}

		/// <summary>
		/// �S�v�f�̕���������擾�ł��邩�e�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestCases")]
		public override void VerifyToString(string path) {
			base.VerifyToString(path);
		}

		/// <summary>
		/// �e�v�f���s�K�؂ȗv�f���Ȃ����e�X�g���܂��B
		/// </summary>
		/// <param name="path">�e�X�g�Ώۂ̃\�[�X�R�[�h�̃p�X</param>
		[Test, TestCaseSource("TestCases")]
		public override void VerifyParentProperty(string path) {
			base.VerifyParentProperty(path);
		}
	}
}
