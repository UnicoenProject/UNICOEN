﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Apps.UniAspect.Cui.Processor;
using Unicoen.Processor;
using Unicoen.Tests;

namespace Unicoen.Apps.UniAspect.Cui.CodeProcessorTest {
	[TestFixture]
	public class CustomWeavingTest {
		
		private readonly string _sourcePath =
				FixtureUtil.GetInputPath("Aspect", "Custom", "ExceptionSample.java");
		private readonly string _expectationSourcePath =
				FixtureUtil.GetInputPath("Aspect", "Custom", "ExceptionSample_exception.java");

		// TODO コメントアウトしている言語のファイルを用意する
		[Test]
//		[TestCase("Java", ".java", "System.out.println(\"Inserted before.\");")]
//		[TestCase("JavaScript", ".js", "Console.log(\"Inserted before.\");")]
//		[TestCase("C", ".c", "printf(\"Inserted before.\");")]
//		[TestCase("CSharp", ".cs", "Console.WriteLine(\"Inserted before.\");")]
//		[TestCase("Python", ".py", "print \"Inserted before.\"")]
		public void ExceptionBeforeが正しく動作することを検証します(string language, string ext, string code) {
			var model = UniGenerators.GenerateProgramFromFile(
				FixtureUtil.GetInputPath("Aspect", "Exception", "Fibonacci" + ext));
			var actual = UniGenerators.GenerateProgramFromFile(
				FixtureUtil.GetInputPath("Aspect", "Exception", "Fibonacci_expectation_before" + ext));

			CodeProcessorProvider.WeavingBefore("exception", model, "fibonacci",
			                                    UcoGenerator.CreateAdvice(language, code));
			Assert.That(model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void 例外ポイントカットを作成してcatch節の中にコードを追加する() {
			// オリジナルのソースコードのUCOとアスペクト合成後に期待されるソースコードのUCOを生成する
			var model = UniGenerators.GenerateProgramFromFile(_sourcePath);
			var actual = UniGenerators.GenerateProgramFromFile(_expectationSourcePath);

			// オリジナルのUCOに対して、アスペクトを合成する
			CodeProcessorProvider.WeavingBefore("exception", model, "Exception", 
				UcoGenerator.CreateAdvice("Java", "System.out.println(\"test\");"));

			model.Normalize();

			var gen = UniGenerators.GetCodeGeneratorByExtension(".java");
			Console.WriteLine(gen.Generate(model));
			Console.WriteLine(gen.Generate(actual));

			// 両者の構造を比較する
			Assert.That(model, Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}
	}
}