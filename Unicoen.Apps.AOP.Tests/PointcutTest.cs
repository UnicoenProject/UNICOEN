using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.AOP.Tests {
	/// <summary>
	/// アスペクトが正しく織り込まれているかテストする。
	/// </summary>
	[TestFixture]
	class PointcutTest {
		private const string FibonacciPath =
				@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Fibonacci.java";
		private const string StudentPath =
				@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Student.java";
		
		public UnifiedProgram CreateModel(string path) {
			var ext = Path.GetExtension(path);
			var code = File.ReadAllText(path, XEncoding.SJIS);
			return Program.CreateModel(ext, code);
		}

		[Test]
		public void WeavingAtBeforeExecutionAll() {
			var model = CreateModel(FibonacciPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Fibonacci_functionBefore.java");
			
			CodeProcessor.InsertAtBeforeExecutionAll(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		public void WeavingAtAfterExecutionAll() {
			var model = CreateModel(FibonacciPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Fibonacci_functionAfter.java");
			
			CodeProcessor.InsertAtAfterExecutionAll(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		[TestCase("^fib")]
		public void WeavingAtBeforeExecutionByRegex(string regex) {
			var model = CreateModel(FibonacciPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Fibonacci_functionBefore.java");
			
			CodeProcessor.InsertAtBeforeExecution(model, new Regex(regex), "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		[TestCase("^fib")]
		public void WeavingAtAfterExecutionByRegex(string regex) {
			var model = CreateModel(FibonacciPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Fibonacci_functionAfter.java");
			
			CodeProcessor.InsertAtAfterExecution(model, new Regex(regex), "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		[TestCase("fibonacci")]
		public void WeavingAtBeforeExecutionByName(string name) {
			var model = CreateModel(FibonacciPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Fibonacci_functionBefore.java");
			
			CodeProcessor.InsertAtBeforeExecutionByName(model, name, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		[TestCase("fibonacci")]
		public void WeavingAtAfterExecutionByName(string name) {
			var model = CreateModel(FibonacciPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Fibonacci_functionAfter.java");
			
			CodeProcessor.InsertAtAfterExecutionByName(model, name, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}


		[Test]
		public void WeavingAtBeforeCallAll() {
			var model = CreateModel(StudentPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Student_callBefore.java");

			CodeProcessor.InsertAtBeforeCallAll(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		public void WeavingAtAfterCallAll() {
			var model = CreateModel(StudentPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Student_callAfter.java");

			CodeProcessor.InsertAtAfterCallAll(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		//TODO 関数呼び出し(UnifiedCall)の名前の抽出が現状ではできないので、一旦無視する
		[Test, Ignore]
		[TestCase("^w")]
		public void WeavingAtBeforeCallByRegex(string regex) {
			var model = CreateModel(StudentPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Student_callBefore.java");

			CodeProcessor.InsertAtBeforeCall(model, new Regex(regex), "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test, Ignore]
		[TestCase("^w")]
		public void WeavingAtAfterCallByRegex(string regex) {
			var model = CreateModel(StudentPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Student_callAfter.java");

			CodeProcessor.InsertAtAfterCall(model, new Regex(regex), "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test, Ignore]
		[TestCase("write")]
		public void WeavingAtBeforeCallByName(string name) {
			var model = CreateModel(StudentPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Student_callBefore.java");

			CodeProcessor.InsertAtBeforeCallByName(model, name, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test, Ignore]
		[TestCase("write")]
		public void WeavingAtAfterCallByName(string name) {
			var model = CreateModel(StudentPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Student_callAfter.java");

			CodeProcessor.InsertAtAfterCallByName(model, name, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		//TODO 多項式中や関数の引数として現れるUnifiedCallに対しては、処理が行われないことを確認するテストを書く
	}
}
