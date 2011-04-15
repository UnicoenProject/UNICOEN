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
		public const string Temp = "output";

		public static string CleanTemporalPath() {
			var path = GetTemporalPath();
			if (Directory.Exists(path)) {
				Directory.Delete(path, true);
			}
			Directory.CreateDirectory(path);
			return path.GetFullPathAddingSubNames();
		}

		public static string GetFullPathAddingSubNames(this string path,
		                                               params string[] subNames) {
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
	}
}