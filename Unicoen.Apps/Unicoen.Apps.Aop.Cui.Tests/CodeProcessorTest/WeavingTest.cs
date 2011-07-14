#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;
using Unicoen.Core.Tests;
using Unicoen.Languages.Java.CodeFactories;

namespace Unicoen.Apps.Aop.Tests {
	/// <summary>
	///   アスペクトが正しく織り込まれているかテストする。
	/// </summary>
	[TestFixture]
	public class WeavingTest {
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
		public void WeavingAtBeforeExecutionAll() {
			//アスペクト合成処理対象のプログラムをモデル化する
			var model = CreateModel(_fibonacciPath);
			//あらかじめ用意されたアスペクト合成後の期待値であるプログラムをモデル化する
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath(
									"Java", "Fibonacci_functionBefore.java"));

			//アスペクト合成処理の実行
			CodeProcessor.InsertAtBeforeExecutionAll(
					model, CodeProcessor.CreateAdvice("Java", "Console.Write();"));
			
			//合成後のモデルと期待値のモデルを比較
			Assert.That(
					model, 
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void WeavingAtAfterExecutionAll() {
			var model = CreateModel(_fibonacciPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath("Java", "Fibonacci_functionAfter.java"));

			CodeProcessor.InsertAtAfterExecutionAll(
					model, CodeProcessor.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model, 
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("^fib")]
		public void WeavingAtBeforeExecutionByRegex(string regex) {
			var model = CreateModel(_fibonacciPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath(
									"Java", "Fibonacci_functionBefore.java"));

			CodeProcessor.InsertAtBeforeExecution(
					model, new Regex(regex),
					CodeProcessor.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("^fib")]
		public void WeavingAtAfterExecutionByRegex(string regex) {
			var model = CreateModel(_fibonacciPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath("Java", "Fibonacci_functionAfter.java"));

			CodeProcessor.InsertAtAfterExecution(
					model, new Regex(regex),
					CodeProcessor.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("fibonacci")]
		public void WeavingAtBeforeExecutionByName(string name) {
			var model = CreateModel(_fibonacciPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath(
									"Java", "Fibonacci_functionBefore.java"));

			CodeProcessor.InsertAtBeforeExecutionByName(
					model, name, CodeProcessor.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("fibonacci")]
		public void WeavingAtAfterExecutionByName(string name) {
			var model = CreateModel(_fibonacciPath);
			var actual =
					CreateModel(
							FixtureUtil.GetAopExpectationPath("Java", "Fibonacci_functionAfter.java"));

			CodeProcessor.InsertAtAfterExecutionByName(
					model, name, CodeProcessor.CreateAdvice("Java", "Console.Write();"));

			Assert.That(
					model,
					Is.EqualTo(actual).Using(StructuralEqualityComparer.Instance));		
		}

		[Test]
		public void Statement数の閾値を5としてStatementを5つ持つ関数にアスペクトを合成する() {
			//statementを5つ含むメソッドを定義
			const string code = @"class A{ public void M() { int a = 0; a = 1; a = 2; a = 3; a = 4; }}";
			//モデル化
			var model = CodeProcessor.CreateModel(".java", code);
			var beforeNumBlock = model.Descendants().Where<UnifiedBlock>().ToCollection().Count;
			//アスペクトの合成
			CodeProcessor.InsertAtBeforeExecutionByName(model, "M", 5, CodeProcessor.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().Where<UnifiedBlock>().ToCollection().Count;

			//for debug
			var gen = new JavaCodeFactory();
			Console.Write(gen.Generate(model));

			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock + 1));
		}

		[Test]
		public void Statement数の閾値を5としてStatementを4つ持つ関数にアスペクトを合成する() {
			//statementを4つ含むメソッドを定義
			const string code = @"class A{ public void M() { int a = 0; a = 1; a = 2; a = 3; }}";
			//モデル化
			var model = CodeProcessor.CreateModel(".java", code);
			var beforeNumBlock = model.Descendants().Where<UnifiedBlock>().ToCollection().Count;
			//アスペクトの合成
			CodeProcessor.InsertAtBeforeExecutionByName(model, "M", 5, CodeProcessor.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().Where<UnifiedBlock>().ToCollection().Count;

			//for debug
			var gen = new JavaCodeFactory();
			Console.Write(gen.Generate(model));

			//合成の前後でブロックの数が変わらない
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock));
		}
		
		[Test]
		public void Statement数の閾値を5としてif文を含む関数にアスペクトを合成する() {
			//statementを4つ含むメソッドを定義
			const string code = @"class A{ public void M() { if(true) { int a = 0; a = 1; a = 2; a = 3; }}}";
			//モデル化
			var model = CodeProcessor.CreateModel(".java", code);
			var beforeNumBlock = model.Descendants().Where<UnifiedBlock>().ToCollection().Count;
			//アスペクトの合成
			CodeProcessor.InsertAtBeforeExecutionByName(model, "M", 5, CodeProcessor.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().Where<UnifiedBlock>().ToCollection().Count;

			//for debug
			var gen = new JavaCodeFactory();
			Console.Write(gen.Generate(model));

			//if文で1statement, trueブロック内で4statementsなので処理が合成される
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock + 1));
		}

		[Test]
		public void For文を含む関数にアスペクトを合成する() {
			//for文を含むメソッドを定義
			const string code = @"class A{ public void M() { for(int i = 0; i < 10; i++) { } } }";
			//モデル化
			var model = CodeProcessor.CreateModel(".java", code);
			var beforeNumBlock = model.Descendants().Where<UnifiedBlock>().ToCollection().Count;
			//アスペクトの合成
			CodeProcessor.InsertAtBeforeExecutionByName(model, "M", typeof(UnifiedFor), CodeProcessor.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().Where<UnifiedBlock>().ToCollection().Count;

			//for debug
			var gen = new JavaCodeFactory();
			Console.Write(gen.Generate(model));

			//For文が含まれているので処理が合成される
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock + 1));
		}

		[Test]
		public void For文を含まない関数にアスペクトを合成する() {
			//for文を含まないメソッドを定義
			const string code = @"class A{ public void M() { int i = 0; while(i < 10) { i++; } } }";
			//モデル化
			var model = CodeProcessor.CreateModel(".java", code);
			var beforeNumBlock = model.Descendants().Where<UnifiedBlock>().ToCollection().Count;
			//アスペクトの合成
			CodeProcessor.InsertAtBeforeExecutionByName(model, "M", typeof(UnifiedFor), CodeProcessor.CreateAdvice("Java", "System.out.println();"));
			var afterNumBlock = model.Descendants().Where<UnifiedBlock>().ToCollection().Count;

			//for debug
			var gen = new JavaCodeFactory();
			Console.Write(gen.Generate(model));

			//For文が含まれていないので合成の前後でコードが変わらない
			Assert.That(afterNumBlock, Is.EqualTo(beforeNumBlock));
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

		//TODO 多項式中や、プロパティとしての関数呼び出し、関数の引数として現れるUnifiedCallに対しては、処理が行われないことを確認するテストを書く
	}
}