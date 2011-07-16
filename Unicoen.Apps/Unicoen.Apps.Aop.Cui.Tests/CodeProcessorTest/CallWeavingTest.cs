using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;
using Unicoen.Core.Tests;

namespace Unicoen.Apps.Aop.Cui.Tests.CodeProcessorTest
{
	/// <summary>
	/// 関数呼び出しに関するアスペクトの合成が正しく機能するかテストする
	/// </summary>
	[TestFixture]
	public class CallWeavingTest {
		private readonly string _fibonacciPath =
				FixtureUtil.GetInputPath("Java", "Default", "Fibonacci.java");

		private readonly string _studentPath =
				FixtureUtil.GetInputPath("Java", "Default", "Student.java");

		//指定されたパスのファイルを読み込んで共通コードオブジェクトに変換します
		public UnifiedProgram CreateModel(string path) {
			var ext = Path.GetExtension(path);
			var code = File.ReadAllText(path, XEncoding.SJIS);
			return CodeProcessor.CreateModel(ext, code);
		}

		[Test]
		public void WeavingAtBeforeCallAll() {
			var model = CreateModel(_studentPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath("Java", "Student_callBefore.java"));

			CodeProcessor.InsertAtBeforeCallAll(
					model, CodeProcessor.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}
		
		[Test]
		public void WeavingAtAfterCallAll() {
			var model = CreateModel(_studentPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath("Java", "Student_callAfter.java"));

			CodeProcessor.InsertAtAfterCallAll(
					model, CodeProcessor.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("^w")]
		public void WeavingAtBeforeCallByRegex(string regex) {
			var model = CreateModel(_studentPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath("Java", "Student_callBefore.java"));

			CodeProcessor.InsertAtBeforeCall(
					model, new Regex(regex),
					CodeProcessor.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("^w")]
		public void WeavingAtAfterCallByRegex(string regex) {
			var model = CreateModel(_studentPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath("Java", "Student_callAfter.java"));

			CodeProcessor.InsertAtAfterCall(
					model, new Regex(regex),
					CodeProcessor.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("write")]
		public void WeavingAtBeforeCallByName(string name) {
			var model = CreateModel(_studentPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath("Java", "Student_callBefore.java"));

			CodeProcessor.InsertAtBeforeCallByName(
					model, name, CodeProcessor.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("write")]
		public void WeavingAtAfterCallByName(string name) {
			var model = CreateModel(_studentPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath("Java", "Student_callAfter.java"));

			CodeProcessor.InsertAtAfterCallByName(
					model, name, CodeProcessor.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}
	}
}
