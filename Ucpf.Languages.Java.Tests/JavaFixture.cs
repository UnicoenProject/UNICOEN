using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.Java.Tests
{
	public static class JavaFixture
	{
		/// <summary>
		/// A.javaファイルのメソッド宣言の中身としてテスト
		/// <c>class A { public void M1() { ... } }</c>の...部分に埋め込んだのちテスト
		/// </summary>
		public static IEnumerable<TestCaseData> TestStatements
		{
			get
			{
				return new[] {
					"M1();",
					"new A();",
				}.Select(s => new TestCaseData(CreateCode(s)));
			}
		}

		/// <summary>
		/// A.javaファイルのソースコードとしてテスト
		/// </summary>
		public static IEnumerable<TestCaseData> TestCodes
		{
			get
			{
				return new[] {
					"class A { }",
					"public class A { }",
				}.Select(s => new TestCaseData(s));
			}
		}

		public static IEnumerable<TestCaseData> TestFilePathes
		{
			get
			{
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
					//"ActionListener.java",
					//"Block1.java",
					//"Block2.java",
					//"Block3.java",
					//"Class.java",
					//"Condition.java",
					//"ControlFlow.java",
					//"Exception.java",
					"Fibonacci.java",
					//"Method.java",
					//"Modifier.java",
					//"Operator.java",
					//"Simple.java",
					"Student.java",
					//"Variable.java",
				}
					.Select(s => new TestCaseData(Fixture.GetInputPath("Java", s)));
				//return Directory.EnumerateFiles(Fixture.GetInputPath("Java"))
				//    .Select(path => new TestCaseData(path));
			}
		}

		private static string CreateCode(string statement)
		{
			return "class A { public void M1() {" + statement + "} }";
		}
	}
}