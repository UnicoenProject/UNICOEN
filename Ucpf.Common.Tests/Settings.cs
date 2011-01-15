using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Tests {
	public static class Settings {
		public static string FixtureDirPath = Path.Combine("..", "..", "fixture");
		public static string ExpectationName = "expectation";
		public static string InputName = "input";
		public static string FailedInputName = "failed_input";
		public static string OutputName = "output";
		public static string XmlExpectationName = "xmlexpectation";

		public static string GetInputDirPath(string lang) {
			return Path.Combine(FixtureDirPath, lang, InputName);
		}

		public static string GetFailedInputDirPath(string lang) {
			return Path.Combine(FixtureDirPath, lang, FailedInputName);
		}

		public static string GetOutputDirPath(string lang) {
			var path = Path.Combine(FixtureDirPath, lang, OutputName);
			Directory.CreateDirectory(path);
			return path;
		}

		public static string GetExpectationDirPath(string lang) {
			return Path.Combine(FixtureDirPath, lang, ExpectationName);
		}

		public static string GetXmlExpectationDirPath(string lang) {
			return Path.Combine(FixtureDirPath, lang, XmlExpectationName);
		}
	}
}
