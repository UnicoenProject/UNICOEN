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
		private const string filePath =
				@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Fibonacci.java";
		
		private string _ext;
		private string _code;
		private UnifiedProgram _model;

		[SetUp]
		public void Setup() {
			_ext = Path.GetExtension(filePath);
			_code = File.ReadAllText(filePath, XEncoding.SJIS);
			_model = Program.CreateModel(_ext, _code);
		}

		[Test]
		public void WeavingAtFunctionBeforeCorrectly() {
			var actual = JavaModelFactory.Instance.Generate("public class Fibonacci { public static int fibonacci(int n) { { Console.Write(); } if (n < 2) { return n; } else { return fibonacci(n - 1) + fibonacci(n - 2); } } }");
			CodeProcessor.InsertBeforeAllFunction(_model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(_model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		public void WeavingAtFunctionAfterCorrectly() {
			var actual = JavaModelFactory.Instance.Generate("public class Fibonacci { public static int fibonacci(int n) { if (n < 2) { { Console.Write(); } return n; } else { { Console.Write(); } return fibonacci(n - 1) + fibonacci(n - 2); } } }");
			CodeProcessor.InsertAfterAllFunction(_model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(_model.ToString(), Is.EqualTo(actual.ToString()));
		}
	}
}
