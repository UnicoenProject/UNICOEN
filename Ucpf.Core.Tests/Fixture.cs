using System.IO;
using System.Linq;

namespace Ucpf.Core.Tests {
	public static class Fixture {
		public static string FixturePath = Path.Combine("..", "..", "fixture");
		public const string ExpectationName = "expectation";
		public const string InputName = "input";
		public const string FailedInputName = "failed_input";
		public const string OutputName = "output";
		public const string XmlExpectationName = "xmlexpectation";
		public const string Temp = "temp";

		public static string CleanTemporalPath() {
			var path = GetTemporalPath();
			Directory.Delete(path, true);
			Directory.CreateDirectory(path);
			return path;
		}

		public static string AddSubNames(this string path, params string[] subNames) {
			return subNames.Aggregate(path, Path.Combine);
		}

		public static string GetTemporalPath(params string[] names) {
			return Path.Combine(FixturePath, Temp)
				.AddSubNames(names);
		}

		public static string GetInputPath(string lang, params string[] names) {
			return Path.Combine(FixturePath, lang, InputName)
				.AddSubNames(names);
		}

		public static string GetFailedInputPath(string lang, params string[] names) {
			return Path.Combine(FixturePath, lang, FailedInputName)
				.AddSubNames(names);
		}

		public static string GetOutputDirPath(string lang) {
			var path = Path.Combine(FixturePath, lang, OutputName);
			Directory.CreateDirectory(path);
			return path;
		}

		public static string GetOutputFilePath(string lang, params string[] names) {
			return GetOutputDirPath(lang)
				.AddSubNames(names);
		}

		public static string GetExpectationPath(string lang, params string[] names) {
			return Path.Combine(FixturePath, lang, ExpectationName)
				.AddSubNames(names);
		}

		public static string GetXmlExpectationPath(string lang, params string[] names) {
			return Path.Combine(FixturePath, lang, XmlExpectationName)
				.AddSubNames(names);
		}
	}
}