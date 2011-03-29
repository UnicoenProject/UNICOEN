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
		/// 深いコピーが正常に動作するかテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestCases")]
		public override void VerifyDeepCopy(string path) {
			base.VerifyDeepCopy(path);
		}

		/// <summary>
		/// 子要素の列挙機能が正常に動作するかテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestCases")]
		public override void VerifyGetElements(string path) {
			base.VerifyGetElements(path);
		}

		/// <summary>
		/// 子要素とセッターの列挙機能が正常に動作するかテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestCases")]
		public override void GetElementAndSetters(string path) {
			base.GetElementAndSetters(path);
		}

		/// <summary>
		/// 子要素とプロパティを介さないセッターの列挙機能が正常に動作するかテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestCases")]
		public override void GetElementAndDirectSetters(string path) {
			base.GetElementAndDirectSetters(path);
		}

		/// <summary>
		/// 全要素の文字列情報を取得できるかテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestCases")]
		public override void VerifyToString(string path) {
			base.VerifyToString(path);
		}

		/// <summary>
		/// 親要素が不適切な要素がないかテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestCases")]
		public override void VerifyParentProperty(string path) {
			base.VerifyParentProperty(path);
		}
	}
}
