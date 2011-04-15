using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests {
	public static class CSharpFixture {
		public static IEnumerable<TestCaseData> TestStatements {
			get {
				return new[] {
						"{ M1(); }",
				}.Select(s => new TestCaseData(CreateCode(s)));
			}
		}

		public static IEnumerable<TestCaseData> TestCodes {
			get {
				return new[] {
						"class A { }",
				}.Select(s => new TestCaseData(s));
			}
		}

		public static IEnumerable<TestCaseData> TestFilePathes {
			get {
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
						//"Block1.cs",
						//"Block2.cs",
						//"Block3.cs",
						"Fibonacci.cs",
						//"Student.cs",
				}
						.Select(s => new TestCaseData(Fixture.GetInputPath("CSharp", s)));
				//return Directory.EnumerateFiles(GetInputPath("CSharp"))
				//        .Select(path => new TestCaseData(path));
			}
		}

		private static string CreateCode(string statement) {
			return "class A { public void M1() {" + statement + "} }";
		}
	}
}