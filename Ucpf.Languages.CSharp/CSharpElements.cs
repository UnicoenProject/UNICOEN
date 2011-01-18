using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.CSharp {
	public static class CSharpElements {
		public static IEnumerable<XElement> If(XElement root) {
			return root.Descendants("if_statement");
		}

		public static XElement IfProcess(XElement element) {
			return element.Elements().ElementAt(4);
		}

		public static IEnumerable<XElement> Else(XElement root) {
			return root.Descendants("else_statement");
		}

		public static XElement ElseProcess(XElement element) {
			return element.Elements().ElementAt(1);
		}

		public static IEnumerable<XElement> While(XElement root) {
			return root.Descendants("while_statement");
		}

		public static XElement WhileProcess(XElement element) {
			return element.Elements().ElementAt(4);
		}

		public static IEnumerable<XElement> DoWhile(XElement root) {
			return root.Descendants("do_statement");
		}

		public static XElement DoWhileProcess(XElement element) {
			return element.Elements().ElementAt(1);
		}

		public static IEnumerable<XElement> For(XElement root) {
			return root.Descendants("for_statement");
		}

		public static XElement ForProcess(XElement element) {
			return ControlFlowProcess(element);
		}

		public static IEnumerable<XElement> ForEach(XElement root) {
			return root.Descendants("foreach_statement");
		}

		public static XElement ForEachProcess(XElement element) {
			return element.Elements().ElementAt(7);
		}

		public static XElement ControlFlowProcess(XElement element) {
			return element.Element("embedded_statement");
		}
	}
}