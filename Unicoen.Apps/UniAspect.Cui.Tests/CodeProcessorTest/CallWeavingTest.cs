using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Apps.UniAspect.Cui.CodeProcessor;
using Unicoen.Apps.UniAspect.Cui.Processor.Pointcut;
using Unicoen.Model;
using Unicoen.Processor;
using Unicoen.Tests;

namespace Unicoen.Apps.UniAspect.Cui.CodeProcessorTest
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
			return UcoGenerator.CreateModel(ext, code);
		}

		[Test]
		public void WeavingAtBeforeCallAll() {
			var model = CreateModel(_studentPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath("Java", "Student_callBefore.java"));

			Call.InsertAtBeforeCallAll(
					model, UcoGenerator.CreateAdvice("Java", "Console.Write();"));

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

			Call.InsertAtAfterCallAll(
					model, UcoGenerator.CreateAdvice("Java", "Console.Write();"));

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

			Call.InsertAtBeforeCall(
					model, new Regex(regex),
					UcoGenerator.CreateAdvice("Java", "Console.Write();"));

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

			Call.InsertAtAfterCall(
					model, new Regex(regex),
					UcoGenerator.CreateAdvice("Java", "Console.Write();"));

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

			Call.InsertAtBeforeCallByName(
					model, name, UcoGenerator.CreateAdvice("Java", "Console.Write();"));

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

			Call.InsertAtAfterCallByName(
					model, name, UcoGenerator.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}
	}
}
