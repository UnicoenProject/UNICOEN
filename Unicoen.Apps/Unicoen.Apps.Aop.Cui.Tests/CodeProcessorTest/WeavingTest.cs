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

using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;
using Unicoen.Core.Tests;

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