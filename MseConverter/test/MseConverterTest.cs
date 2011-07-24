using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Apps.Aop;
using Unicoen.Model;
using Unicoen.Tests;

namespace MseConverter.test
{
	[TestFixture]
	public class MseConverterTest {

		private readonly string _fibonacciPath = Path.Combine(
				"..", "..", "..", "fixture", "Java", "input", "Default", "Fibonacci.java");

		private readonly string _studentPath = Path.Combine(
				"..", "..", "..", "fixture", "Java", "input", "Default", "Student.java");

		//指定されたパスのファイルを読み込んで共通コードオブジェクトに変換します
		public UnifiedProgram CreateModel() {
			var code = @"package test; class Sample{ public static void main(String[] args) { System.out.println(); } }";
			return CodeProcessor.CreateModel(".java", code);
		}

		[Test]
		public void 共通オブジェクトをmseフォーマットに変換できる() {
			var writer = new StringWriter();
			var converter = new MseConverter();
			converter.Generate(CreateModel(), writer);
			Console.Write(writer.ToString());
		}

	}
}
