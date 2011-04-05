using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Ucpf.Core.Tests {
	public static class Fixture {
		public static string FixturePath = Path.Combine("..", "..", "fixture");
		public const string ExpectationName = "expectation";
		public const string InputName = "input";
		public const string FailedInputName = "failed_input";
		public const string OutputName = "output";
		public const string XmlExpectationName = "xmlexpectation";
		public const string Temp = "output";

		public static string CleanTemporalPath() {
			var path = GetTemporalPath();
			if (Directory.Exists(path)) {
				Directory.Delete(path, true);
			}
			Directory.CreateDirectory(path);
			return path.GetFullPathAddingSubNames();
		}

		public static string GetFullPathAddingSubNames(this string path, params string[] subNames) {
			return Path.GetFullPath(subNames.Aggregate(path, Path.Combine));
		}

		public static string GetTemporalPath(params string[] names) {
			var path = Path.Combine(FixturePath, Temp);
			Directory.CreateDirectory(path);
			return path.GetFullPathAddingSubNames(names);
		}

		public static string GetInputPath(string lang, params string[] names) {
			return Path.Combine(FixturePath, lang, InputName)
				.GetFullPathAddingSubNames(names);
		}

		public static string GetFailedInputPath(string lang, params string[] names) {
			return Path.Combine(FixturePath, lang, FailedInputName)
				.GetFullPathAddingSubNames(names);
		}

		public static string GetOutputDirPath(string lang) {
			var path = Path.Combine(FixturePath, lang, OutputName);
			Directory.CreateDirectory(path);
			return path.GetFullPathAddingSubNames();
		}

		public static string GetOutputFilePath(string lang, params string[] names) {
			return GetOutputDirPath(lang)
				.GetFullPathAddingSubNames(names);
		}

		public static string GetExpectationPath(string lang, params string[] names) {
			return Path.Combine(FixturePath, lang, ExpectationName)
				.GetFullPathAddingSubNames(names);
		}

		public static string GetXmlExpectationPath(string lang, params string[] names) {
			return Path.Combine(FixturePath, lang, XmlExpectationName)
				.GetFullPathAddingSubNames(names);
		}

		public static IEnumerable<TestCaseData> CSharpTestCases {
			get {
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
						//new TestCaseData(GetInputPath("CSharp", "Block1.cs")),
						//new TestCaseData(GetInputPath("CSharp", "Block2.cs")),
						//new TestCaseData(GetInputPath("CSharp", "Block3.cs")),
						new TestCaseData(GetInputPath("CSharp", "Fibonacci.cs")),
						//new TestCaseData(GetInputPath("CSharp", "Student.cs")),
				};
				//return Directory.EnumerateFiles(GetInputPath("CSharp"))
				//        .Select(path => new TestCaseData(path));
			}
		}

		public static IEnumerable<TestCaseData> JavaTestCases {
			get {
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
						//new TestCaseData(GetInputPath("Java", "ActionListener.java")),
						//new TestCaseData(GetInputPath("Java", "Block1.java")),
						//new TestCaseData(GetInputPath("Java", "Block2.java")),
						//new TestCaseData(GetInputPath("Java", "Block3.java")),
						//new TestCaseData(GetInputPath("Java", "Class.java")),
						//new TestCaseData(GetInputPath("Java", "Condition.java")),
						//new TestCaseData(GetInputPath("Java", "ControlFlow.java")),
						//new TestCaseData(GetInputPath("Java", "Exception.java")),
						new TestCaseData(GetInputPath("Java", "Fibonacci.java")),
						//new TestCaseData(GetInputPath("Java", "Method.java")),
						//new TestCaseData(GetInputPath("Java", "Modifier.java")),
						//new TestCaseData(GetInputPath("Java", "Operator.java")),
						//new TestCaseData(GetInputPath("Java", "Simple.java")),
						//new TestCaseData(GetInputPath("Java", "Student.java")),
						//new TestCaseData(GetInputPath("Java", "Variable.java")),
				};
				//return Directory.EnumerateFiles(Fixture.GetInputPath("Java"))
				//    .Select(path => new TestCaseData(path));
			}
		}
	}
}