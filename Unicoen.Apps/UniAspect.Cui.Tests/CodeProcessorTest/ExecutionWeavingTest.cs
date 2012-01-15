using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Unicoen.Apps.UniAspect.Cui.Processor;
using Unicoen.Apps.UniAspect.Cui.Processor.Pointcut;
using Unicoen.Languages.Java.CodeGenerators;
using Unicoen.Model;
using Unicoen.Processor;
using Unicoen.Tests;

namespace Unicoen.Apps.UniAspect.Cui.CodeProcessorTest {
	/// <summary>
	/// 関数本体に関するアスペクトの合成が正しく機能するかテストする
	/// </summary>
	[TestFixture]
	public class ExecutionWeavingTest {

		private readonly string _fibonacciPath =
				FixtureUtil.GetInputPath("Java", "Default", "Fibonacci.java");

		//指定されたパスのファイルを読み込んで共通コードオブジェクトに変換します
		public UnifiedProgram CreateProgramFromCode(string extension, string code) {
			var gen = UniGenerators.GetProgramGeneratorByExtension(extension);
			return gen.Generate(code);
		}

		// TODO Pythonのコードの準備
		[Test]
		[TestCase("Java", ".java", "System.out.println(\"Inserted before.\");")]
		[TestCase("JavaScript", ".js", "Console.log(\"Inserted before.\");")]
		[TestCase("C", ".c", "printf(\"Inserted before.\");")]
		[TestCase("CSharp", ".cs", "Console.WriteLine(\"Inserted before.\");")]
//		[TestCase("Python", ".py", "print \"Inserted before.\"")]
		public void ExecutionBeforeが正しく動作することを検証します(string language, string ext, string code) {
			var model = UniGenerators.GenerateProgramFromFile(
				FixtureUtil.GetInputPath("Aspect", "Execution", "Fibonacci" + ext));
			var actual = UniGenerators.GenerateProgramFromFile(
				FixtureUtil.GetInputPath("Aspect", "Execution", "Fibonacci_expectation_before" + ext));
	
			CodeProcessorProvider.WeavingBefore("execution", model, "fibonacci", UcoGenerator.CreateAdvice(language, code));
			Assert.That(model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("Java", ".java", "System.out.println(\"Inserted after.\");")]
		[TestCase("JavaScript", ".js", "Console.log(\"Inserted after.\");")]
		[TestCase("C", ".c", "printf(\"Inserted after.\");")]
		[TestCase("CSharp", ".cs", "Console.WriteLine(\"Inserted after.\");")]
//		[TestCase("Python", ".py", "print \"Inserted after.\"")]
		public void ExecutionAfterが正しく動作することを検証します(string language, string ext, string code) {
			var model = UniGenerators.GenerateProgramFromFile(
				FixtureUtil.GetInputPath("Aspect", "Execution", "Fibonacci" + ext));
			var actual = UniGenerators.GenerateProgramFromFile(
				FixtureUtil.GetInputPath("Aspect", "Execution", "Fibonacci_expectation_after" + ext));

			CodeProcessorProvider.WeavingAfter("execution", model, "fibonacci", UcoGenerator.CreateAdvice(language, code));
			Assert.That(model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));		
		}

		# region old

		[Test]
		public void WeavingAtBeforeExecutionAll() {
			//アスペクト合成処理対象のプログラムをモデル化する
			var model = UniGenerators.GenerateProgramFromFile(_fibonacciPath);
			//あらかじめ用意されたアスペクト合成後の期待値であるプログラムをモデル化する
			var actual =
					UniGenerators.GenerateProgramFromFile(
							FixtureUtil.GetAopExpectationPath(
									"Java", "Fibonacci_functionBefore.java"));

			//アスペクト合成処理の実行
			Execution.InsertAtBeforeExecutionAll(
					model, UcoGenerator.CreateAdvice("Java", "Console.Write();"));
			
			//合成後のモデルと期待値のモデルを比較
			Assert.That(
					model, 
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void WeavingAtAfterExecutionAll() {
			var model = UniGenerators.GenerateProgramFromFile(_fibonacciPath);
			var actual =
					UniGenerators.GenerateProgramFromFile(
							FixtureUtil.GetAopExpectationPath("Java", "Fibonacci_functionAfter.java"));

			Execution.InsertAtAfterExecutionAll(
					model, UcoGenerator.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model, 
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("^fib")]
		public void WeavingAtBeforeExecutionByRegex(string regex) {
			var model = UniGenerators.GenerateProgramFromFile(_fibonacciPath);
			var actual =
					UniGenerators.GenerateProgramFromFile(
							FixtureUtil.GetAopExpectationPath(
									"Java", "Fibonacci_functionBefore.java"));

			Execution.InsertAtBeforeExecution(
					model, new Regex(regex),
					UcoGenerator.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("^fib")]
		public void WeavingAtAfterExecutionByRegex(string regex) {
			var model = UniGenerators.GenerateProgramFromFile(_fibonacciPath);
			var actual =
					UniGenerators.GenerateProgramFromFile(
							FixtureUtil.GetAopExpectationPath("Java", "Fibonacci_functionAfter.java"));

			Execution.InsertAtAfterExecution(
					model, new Regex(regex),
					UcoGenerator.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void Statement数の閾値を5としてStatementを5つ持つ関数にアスペクトを合成する() {
			//statementを5つ含むメソッドを定義
			const string code = @"class A{ public void M() { int a = 0; a = 1; a = 2; a = 3; a = 4; }}";
			//モデル化
			var model = CreateProgramFromCode(".java", code);
			var beforeNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();
			//アスペクトの合成
			Execution.InsertAtBeforeExecutionByName(model, "M", 5, UcoGenerator.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();

			//for debug
			var gen = new JavaCodeGenerator();
			Console.Write(gen.Generate(model));

			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock + 1));
		}

		[Test]
		public void Statement数の閾値を5としてStatementを4つ持つ関数にアスペクトを合成する() {
			//statementを4つ含むメソッドを定義
			const string code = @"class A{ public void M() { int a = 0; a = 1; a = 2; a = 3; }}";
			//モデル化
			var model = CreateProgramFromCode(".java", code);
			var beforeNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();
			//アスペクトの合成
			Execution.InsertAtBeforeExecutionByName(model, "M", 5, UcoGenerator.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();

			//for debug
			var gen = new JavaCodeGenerator();
			Console.Write(gen.Generate(model));

			//合成の前後でブロックの数が変わらない
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock));
		}
		
		[Test]
		public void Statement数の閾値を5としてif文を含む関数にアスペクトを合成する() {
			//statementを4つ含むメソッドを定義
			const string code = @"class A{ public void M() { if(true) { int a = 0; a = 1; a = 2; a = 3; }}}";
			//モデル化
			var model = CreateProgramFromCode(".java", code);
			var beforeNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();
			//アスペクトの合成
			Execution.InsertAtBeforeExecutionByName(model, "M", 5, UcoGenerator.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();

			//for debug
			var gen = new JavaCodeGenerator();
			Console.Write(gen.Generate(model));

			//if文で1statement, trueブロック内で4statementsなので処理が合成される
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock + 1));
		}

		[Test]
		public void For文を含む関数にアスペクトを合成する() {
			//for文を含むメソッドを定義
			const string code = @"class A{ public void M() { for(int i = 0; i < 10; i++) { } } }";
			//モデル化
			var model = CreateProgramFromCode(".java", code);
			var beforeNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();
			//アスペクトの合成
			Execution.InsertAtBeforeExecutionByName(model, "M", typeof(UnifiedFor), UcoGenerator.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();

			//for debug
			var gen = new JavaCodeGenerator();
			Console.Write(gen.Generate(model));

			//For文が含まれているので処理が合成される
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock + 1));
		}

		[Test]
		public void For文を含まない関数にアスペクトを合成する() {
			//for文を含まないメソッドを定義
			const string code = @"class A{ public void M() { int i = 0; while(i < 10) { i++; } } }";
			//モデル化
			var model = CreateProgramFromCode(".java", code);
			var beforeNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();
			//アスペクトの合成
			Execution.InsertAtBeforeExecutionByName(
					model, "M", typeof(UnifiedFor), UcoGenerator.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();

			//for debug
			var gen = new JavaCodeGenerator();
			Console.Write(gen.Generate(model));

			//For文が含まれていないので合成の前後でコードが変わらない
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock));
		}

		# endregion
	}
}
