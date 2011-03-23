using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Tests;
using Ucpf.Languages.CSharp.Tests;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests {
	[TestFixture]
	public class JavaModelFeatureTest {

		public static IEnumerable<TestCaseData> TestCases {
			get { return TestCaseSource.JavaTestCases; }
		}

		/// <summary>
		/// 親要素が不適切な要素がないかチェックします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Ignore, Test, TestCaseSource("TestCases")]
		public void VerifyParentProperty(string path) {
			var code = File.ReadAllText(path);
			var model = JavaModelFactory.CreateModel(code);
			ModelFeatureTest.VerifyParentProperty(model);
		}

		/// <summary>
		/// 深いコピーが正常に動作するかチェックします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Ignore, Test, TestCaseSource("TestCases")]
		public void VerifyDeepCopy(string path) {
			var code = File.ReadAllText(path);
			var model = JavaModelFactory.CreateModel(code);
			ModelFeatureTest.VerifyDeepCopy(model);
		}
	}
}
