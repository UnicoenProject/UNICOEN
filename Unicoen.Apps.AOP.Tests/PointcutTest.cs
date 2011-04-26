using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
		public void WeavingAtFunctionBeforeCorrectly() {
			var model = CreateModel(FibonacciPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Fibonacci_functionBefore.java");
			
			CodeProcessor.InsertBeforeAllFunction(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		public void WeavingAtFunctionAfterCorrectly() {
			var model = CreateModel(FibonacciPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Fibonacci_functionAfter.java");
			
			CodeProcessor.InsertAfterAllFunction(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		public void WeavingAtCallBeforeCorrectly() {
			var model = CreateModel(StudentPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Student_callBefore.java");

			CodeProcessor.InsertBeforeAllCall(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		public void WeavingAtCallAfterCorrectly() {
			var model = CreateModel(StudentPath);
			var actual =
					CreateModel(
							@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\aspect_expectation\Student_callAfter.java");

			CodeProcessor.InsertAfterAllCall(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		//TODO 多項式中や関数の引数として現れるUnifiedCallに対しては、処理が行われないことを確認するテストを書く
	}
}
