using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests {
	public class CSharpModelFeatureTest {

		public static IEnumerable<TestCaseData> TestCases {
			get { return TestCaseSource.CSharpTestCases; }
		}

		/// <summary>
		/// 親要素が不適切な要素がないかチェックします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Ignore, Test, TestCaseSource("TestCases")]
		public void VerifyParentProperty(string path) {
			var code = File.ReadAllText(path);
			var model = CSharpModelFactory.CreateModel(code);
			ModelFeatureTest.VerifyParentProperty(model);
		}

		/// <summary>
		/// 深いコピーが正常に動作するかチェックします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Ignore, Test, TestCaseSource("TestCases")]
		public void VerifyDeepCopy(string path) {
			var code = File.ReadAllText(path);
			var model = CSharpModelFactory.CreateModel(code);
			ModelFeatureTest.VerifyDeepCopy(model);
		}
	}
}
