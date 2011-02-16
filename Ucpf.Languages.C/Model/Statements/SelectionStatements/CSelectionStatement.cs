using System;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.C.Model.Statements.SelectionStatements {
	public class CSelectionStatement : CStatement {
		public new static CSelectionStatement Create(XElement node) {
			// SelectionStatement is consisted of IfStatement and SwitchStatement
			// node :: statement
			var sw = node.Element("selection_statement").Elements("TOKEN").First().Value;
			switch (sw) {
			case "if":
				return new CIfStatement(node);
			case "switch":
				throw new NotImplementedException();
				// return new CSwitchStatement(node)
			default:
				throw new InvalidOperationException();
			}
		}
	}
}