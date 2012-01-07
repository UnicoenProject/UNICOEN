using System.Text.RegularExpressions;
using NUnit.Framework;
using Unicoen.Apps.UniAspect.Cui.Processor;
using Unicoen.Apps.UniAspect.Cui.Processor.Pointcut;
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
//		public UnifiedProgram UniGenerators.GenerateProgramFromFile(string path) {
//			var ext = Path.GetExtension(path);
//			var code = File.ReadAllText(path, XEncoding.SJIS);
//			return UcoGenerator.UniGenerators.GenerateProgramFromFile(ext, code);
//		}

		[Test]
		public void WeavingAtBeforeCallAll()
		{
			var model = UniGenerators.GenerateProgramFromFile(_studentPath);
			var actual =
				UniGenerators.GenerateProgramFromFile(FixtureUtil.GetAopExpectationPath("Java", "Student_callBefore.java"));

			Call.InsertAtBeforeCallAll(
					model, UcoGenerator.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}
		
		[Test]
		public void WeavingAtAfterCallAll() {
			var model = UniGenerators.GenerateProgramFromFile(_studentPath);
			var actual =
					UniGenerators.GenerateProgramFromFile(
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
			var model = UniGenerators.GenerateProgramFromFile(_studentPath);
			var actual =
					UniGenerators.GenerateProgramFromFile(
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
			var model = UniGenerators.GenerateProgramFromFile(_studentPath);
			var actual =
					UniGenerators.GenerateProgramFromFile(
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
			var model = UniGenerators.GenerateProgramFromFile(_studentPath);
			var actual =
					UniGenerators.GenerateProgramFromFile(
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
			var model = UniGenerators.GenerateProgramFromFile(_studentPath);
			var actual =
					UniGenerators.GenerateProgramFromFile(
							FixtureUtil.GetAopExpectationPath("Java", "Student_callAfter.java"));

			Call.InsertAtAfterCallByName(
					model, name, UcoGenerator.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}
	}
}
