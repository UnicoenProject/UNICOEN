using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript {
	public static class JavaScriptElements {
		public static IEnumerable<XElement> If(XElement root) {
			return root.Descendants("ifStatement");
		}

		public static IEnumerable<XElement> IfAndElseProcesses(XElement root) {
			return root.Elements("statement");
		}

		public static IEnumerable<XElement> While(XElement root) {
			return root.Descendants("whileStatement");
		}

		public static XElement WhileProcess(XElement element) {
			return element.Elements("statement").First();
		}

		public static IEnumerable<XElement> DoWhile(XElement root) {
			return root.Descendants("doWhileStatement");
		}

		public static XElement DoWhileProcess(XElement element) {
			return element.Elements("statement").First();
		}

		public static IEnumerable<XElement> For(XElement root) {
			return root.Descendants("forStatement");
		}

		public static XElement ForProcess(XElement element) {
			return element.Elements("statement").First();
		}

		public static IEnumerable<XElement> ForEach(XElement root) {
			return root.Descendants("forInStatement");
		}

		public static XElement ForEachProcess(XElement element) {
			return element.Elements("statement").First();
		}

		public static IEnumerable<XElement> With(XElement root) {
			return root.Descendants("withStatement");
		}

		public static XElement WithProcess(XElement element) {
			return element.Elements("statement").First();
		}

		public static XElement ControlFlowProcess(XElement element) {
			return element.Elements("statement").First();
		}
	}
}