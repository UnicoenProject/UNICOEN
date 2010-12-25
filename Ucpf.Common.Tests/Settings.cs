using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Tests {
	public static class Settings {
		public static string FixtureDirPath = Path.Combine("..", "fixture");
		public static string ExpectationName = "expectation";
		public static string InputName = "input";
		public static string XmlExpectationName = "xmlexpectation";

		public static string CInputDirPath = GetInputDirPath("C");
		public static string CExpectationDirPath = GetExpectationDirPath("C");
		public static string CXmlExpectationDirPath = GetXmlExpectationDirPath("C");

		public static string CSharpInputDirPath = GetInputDirPath("CSharp");
		public static string CSharpExpectationDirPath = GetExpectationDirPath("CSharp");
		public static string CSharpXmlExpectationDirPath = GetXmlExpectationDirPath("CSharp");

		public static string IronRubyInputDirPath = GetInputDirPath("IronRuby");
		public static string IronRubyExpectationDirPath = GetExpectationDirPath("IronRuby");
		public static string IronRubyXmlExpectationDirPath = GetXmlExpectationDirPath("IronRuby");

		public static string JavaInputDirPath = GetInputDirPath("Java");
		public static string JavaExpectationDirPath = GetExpectationDirPath("Java");
		public static string JavaXmlExpectationDirPath = GetXmlExpectationDirPath("Java");

		public static string JavaScriptInputDirPath = GetInputDirPath("JavaScript");
		public static string JavaScriptExpectationDirPath = GetExpectationDirPath("JavaScript");
		public static string JavaScriptXmlExpectationDirPath = GetXmlExpectationDirPath("JavaScript");

		public static string LuaInputDirPath = GetInputDirPath("Lua");
		public static string LuaExpectationDirPath = GetExpectationDirPath("Lua");
		public static string LuaXmlExpectationDirPath = GetXmlExpectationDirPath("Lua");

		public static string Python2InputDirPath = GetInputDirPath("Python2");
		public static string Python2ExpectationDirPath = GetExpectationDirPath("Python2");
		public static string Python2XmlExpectationDirPath = GetXmlExpectationDirPath("Python2");

		public static string Python3InputDirPath = GetInputDirPath("Python3");
		public static string Python3ExpectationDirPath = GetExpectationDirPath("Python3");
		public static string Python3XmlExpectationDirPath = GetXmlExpectationDirPath("Python3");

		public static string Ruby18InputDirPath = GetInputDirPath("Ruby18");
		public static string Ruby18ExpectationDirPath = GetExpectationDirPath("Ruby18");
		public static string Ruby18XmlExpectationDirPath = GetXmlExpectationDirPath("Ruby18");

		public static string Ruby19InputDirPath = GetInputDirPath("Ruby19");
		public static string Ruby19ExpectationDirPath = GetExpectationDirPath("Ruby19");
		public static string Ruby19XmlExpectationDirPath = GetXmlExpectationDirPath("Ruby19");

		private static string GetInputDirPath(string lang) {
			return Path.Combine(FixtureDirPath, lang, InputName);
		}

		private static string GetExpectationDirPath(string lang) {
			return Path.Combine(FixtureDirPath, lang, ExpectationName);
		}

		private static string GetXmlExpectationDirPath(string lang) {
			return Path.Combine(FixtureDirPath, lang, XmlExpectationName);
		}
	}
}
