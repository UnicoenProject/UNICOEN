using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Paraiba.Xml.Linq;

namespace Ucpf.Languages.C.AstGenerators {
	public static class CElements {
		public static IEnumerable<XElement> Loop(XElement root) {
			return root.Descendants("iteration_statement");
		}

		public static IEnumerable<XElement> While(XElement root) {
			return Loop(root)
				.Where(e => e.FirstElement().Value == "while");
		}

		public static IEnumerable<XElement> DoWhile(XElement root) {
			return Loop(root)
				.Where(e => e.FirstElement().Value == "do");
		}

		public static IEnumerable<XElement> For(XElement root) {
			return Loop(root)
				.Where(e => e.FirstElement().Value == "for");
		}

		public static XElement LoopProcess(XElement element) {
			return element.Element("statement");
		}

		public static IEnumerable<XElement> Selection(XElement root) {
			return root.Descendants("selection_statement");
		}

		public static IEnumerable<XElement> If(XElement root) {
			return Selection(root)
				.Where(e => e.FirstElement().Value == "if");
		}

		public static IEnumerable<XElement> Switch(XElement root) {
			return Selection(root)
				.Where(e => e.FirstElement().Value == "switch");
		}

		public static IEnumerable<XElement> SelectionProcesses(XElement element) {
			return element.Elements("statement");
		}
	}
}