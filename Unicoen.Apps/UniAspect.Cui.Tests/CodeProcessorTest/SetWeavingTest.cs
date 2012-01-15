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
	/// 変数代入に関するアスペクトの合成が正しく機能するかテストする
	/// </summary>
	[TestFixture]
	public class SetWeavingTest {
		//指定されたパスのファイルを読み込んで共通コードオブジェクトに変換します
		public UnifiedProgram CreateProgramFromCode(string extension, string code) {
			var gen = UnifiedGenerators.GetProgramGeneratorByExtension(extension);
			return gen.Generate(code);
		}

		// TODO コメントアウトしている言語のファイルを用意する
		// TODO CodeProcessorProviderを使うようにする
		[Test]
//		[TestCase("Java", ".java", "System.out.println(\"Inserted before.\");")]
//		[TestCase("JavaScript", ".js", "Console.log(\"Inserted before.\");")]
//		[TestCase("C", ".c", "printf(\"Inserted before.\");")]
//		[TestCase("CSharp", ".cs", "Console.WriteLine(\"Inserted before.\");")]
//		[TestCase("Python", ".py", "print \"Inserted before.\"")]
		public void SetBeforeが正しく動作することを検証します(string language, string ext, string code) {
			var model = UnifiedGenerators.GenerateProgramFromFile(
				FixtureUtil.GetInputPath("Aspect", "Set", "Fibonacci" + ext));
			var actual = UnifiedGenerators.GenerateProgramFromFile(
				FixtureUtil.GetInputPath("Aspect", "Set", "Fibonacci_expectation_before" + ext));

			Set.InsertAtBeforeSetByName(
					model, "fibonacci", UcoGenerator.CreateAdvice(language, code));

			Assert.That(model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
//		[TestCase("Java", ".java", "System.out.println(\"Inserted after.\");")]
//		[TestCase("JavaScript", ".js", "Console.log(\"Inserted after.\");")]
//		[TestCase("C", ".c", "printf(\"Inserted after.\");")]
//		[TestCase("CSharp", ".cs", "Console.WriteLine(\"Inserted after.\");")]
//		[TestCase("Python", ".py", "print \"Inserted after.\"")]
		public void SetAfterが正しく動作することを検証します(string language, string ext, string code) {
			var model = UnifiedGenerators.GenerateProgramFromFile(
				FixtureUtil.GetInputPath("Aspect", "Set", "Fibonacci" + ext));
			var actual = UnifiedGenerators.GenerateProgramFromFile(
				FixtureUtil.GetInputPath("Aspect", "Set", "Fibonacci_expectation_after" + ext));

			Set.InsertAtAfterSetByName(
					model, "fibonacci", UcoGenerator.CreateAdvice(language, code));

			Assert.That(model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));		
		}

		[Test]
		public void Setポイントカットを用いて代入文の直前にアスペクトを合成できる() {
			const string code = @"class A{ public void M() { int a = 10; int b; b = a; } }";
			//モデル化
			var model = CreateProgramFromCode(".java", code);
			var beforeNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();
			//アスペクトの合成
			Set.InsertAtBeforeSet(model, new Regex("b"), UcoGenerator.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();

			//for debug
			var gen = new JavaCodeGenerator();
			Console.Write(gen.Generate(model));

			//アスペクトが合成されるためブロックの数が1つ増える
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock + 1));
		}

		[Test]
		public void Setポイントカットを用いて初期化子つき変数宣言の直前にアスペクトを合成できる() {
			const string code = @"class A{ public void M() { int a = 10; int b = a; } }";
			//モデル化
			var model = CreateProgramFromCode(".java", code);
			var beforeNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();
			//アスペクトの合成
			Set.InsertAtBeforeSet(model, new Regex("b"), UcoGenerator.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();

			//for debug
			var gen = new JavaCodeGenerator();
			Console.Write(gen.Generate(model));

			//アスペクトが合成されるためブロックの数が1つ増える
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock + 1));
		}

		[Test]
		public void Setポイントカットを用いて代入文の直後にアスペクトを合成できる() {
			const string code = @"class A{ public void M() { int a = 10; int b; b = a; } }";
			//モデル化
			var model = CreateProgramFromCode(".java", code);
			var beforeNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();
			//アスペクトの合成
			Set.InsertAtAfterSet(model, new Regex("b"), UcoGenerator.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();

			//for debug
			var gen = new JavaCodeGenerator();
			Console.Write(gen.Generate(model));

			//アスペクトが合成されるためブロックの数が1つ増える
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock + 1));
		}

		[Test]
		public void Setポイントカットを用いて初期化子つき変数宣言の直後にアスペクトを合成できる() {
			const string code = @"class A{ public void M() { int a = 10; int b = a; } }";
			//モデル化
			var model = CreateProgramFromCode(".java", code);
			var beforeNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();
			//アスペクトの合成
			Set.InsertAtAfterSet(model, new Regex("b"), UcoGenerator.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().OfType<UnifiedBlock>().Count();

			//for debug
			var gen = new JavaCodeGenerator();
			Console.Write(gen.Generate(model));

			//アスペクトが合成されるためブロックの数が1つ増える
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock + 1));
		}
	}
}
